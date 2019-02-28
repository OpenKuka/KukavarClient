using nucs.JsonSettings;
using OpenKuka.KRL.DataParser;
using OpenKuka.KukavarClient.TCP;
using OpenKuka.KukavarClient.Protocol;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenKuka.KukavarClient;
using System.Collections.Concurrent;
using OpenKuka.KRL.Types;
using System.Threading;
using BrightIdeasSoftware;
using System.Collections;

namespace Kukavar.DemoApp
{
    public partial class Form1 : Form
    {
        private bool bConnect = false;
        private bool bMonitor = false;

        internal AppSettings settings = JsonSettings.Load<AppSettings>();

        private System.Threading.Timer infoTimer, monitoringTimer, ioTimer;

        int cmdinfoRefreshRate = 1000;
        int monitoRefreshRate = 200;

        private const int readHistoryMaxCount = 30;
        private const int readTemplatesMaxCount = 10;

        private KukavarClient client;
        private Stopwatch chrono = Stopwatch.StartNew();
        private DataTable dtrecords, dtio;
        public Form1()
        {
            InitializeComponent();

            // Load Settings
            settings.ReadHistory = settings.ReadHistory ?? new List<string>();
            scbRead.DataSource = settings.ReadHistory;
            scbRead.SelectedIndex = -1;

            settings.WriteHistory = settings.WriteHistory ?? new List<WriteVariable>();
            scbWrite.DataSource = settings.WriteHistory;
            scbWrite.SelectedIndex = -1;

            settings.ReadTemplateList = settings.ReadTemplateList ?? new Dictionary<string, List<String>>();
            RefreshTemplateCombobox();

            tbServerIP.Text = settings.ServerIP ?? "127.0.0.1";
            tbServerPort.Text = settings.ServerPort.ToString();
            tbMaxIdleTime.Text = settings.MaxIdleTime.ToString();
            tbReconnectionTO.Text = settings.ReconnectionTimeout.ToString();
            ckAutoReconnect.Checked = settings.AutoReconnect;

            InitList();

            // info timer
            infoTimer = new System.Threading.Timer((state) =>
            {
                if (client.Status == ClientStatus.Connected)
                {
                    KVReplyCallback callback = async (reply) =>
                    {
                        if (reply.Successful)
                        {
                            this.BeginInvoke((Action)delegate ()
                            {
                                var varName1 = ((KVReadQuery)reply.Query).VarName;
                                switch (varName1)
                                {
                                    case "$PRO_STATE0":
                                        lbProState0.Text = reply.Answer.VarValue;
                                        CmdInfoColors(lbProState0, reply.Answer.VarValue);
                                        break;

                                    case "$PRO_STATE1":
                                        lbProState1.Text = reply.Answer.VarValue;
                                        CmdInfoColors(lbProState1, reply.Answer.VarValue);
                                        break;

                                    case "$PRO_NAME0[]":
                                        lbProName0.Text = reply.Answer.VarValue;
                                        break;

                                    case "$PRO_NAME1[]":
                                        lbProName1.Text = reply.Answer.VarValue;
                                        break;
                                }
                            });
                        }
                    };
                    var t1 = client.SendAsync(KVReadQuery.Build(0, "$PRO_STATE0"), callback);
                    var t2 = client.SendAsync(KVReadQuery.Build(0, "$PRO_STATE1"), callback);
                    var t3 = client.SendAsync(KVReadQuery.Build(0, "$PRO_NAME0[]"), callback);
                    var t4 = client.SendAsync(KVReadQuery.Build(0, "$PRO_NAME1[]"), callback);
                }
            }, null, Timeout.Infinite, Timeout.Infinite);

            // monitoring timer
            lbMonitoRate.Text = string.Format("elapsed time : {0,4:F0} ms", monitoRefreshRate);
            monitoringTimer = new System.Threading.Timer((state) =>
            {
                if (client.Status == ClientStatus.Connected)
                {
                    KVReplyCallback callback = async (reply) =>
                    {
                        if (reply.Successful)
                        {
                            this.BeginInvoke((Action)delegate ()
                            {
                                var varName1 = ((KVReadQuery)reply.Query).VarName;
                                lbMonitoTime.Text = string.Format("elapsed time : {0,4:F0} ms", reply.RoundTripTime.TotalMilliseconds);
                                var ast = reply.Answer.GetAST();
                                var format = "{0:F1}";
                                switch (varName1)
                                {
                                    case "$OV_PRO":
                                        try
                                        {
                                            lb_OV.Text = FormatNumber("{0}", (ast as IntData).Value);
                                        }
                                        catch { }
                                        break;

                                    case "$POS_ACT":
                                        try
                                        {
                                            var e6pos = new E6POS(ast);
                                            lb_X.Text = FormatNumber(format, e6pos.X);
                                            lb_Y.Text = FormatNumber(format, e6pos.Y);
                                            lb_Z.Text = FormatNumber(format, e6pos.Z);
                                            lb_A.Text = FormatNumber(format, e6pos.A);
                                            lb_B.Text = FormatNumber(format, e6pos.B);
                                            lb_C.Text = FormatNumber(format, e6pos.C);
                                            lb_E1.Text = FormatNumber(format, e6pos.E1);
                                            lb_E2.Text = FormatNumber(format, e6pos.E2);
                                            lb_E3.Text = FormatNumber(format, e6pos.E3);
                                            lb_E4.Text = FormatNumber(format, e6pos.E4);
                                            lb_E5.Text = FormatNumber(format, e6pos.E5);
                                            lb_E6.Text = FormatNumber(format, e6pos.E6);

                                            lb_S.Text = (e6pos.GetStatus()).Value.ToString(true);
                                            lb_T.Text = (e6pos.GetTurn()).Value.ToString(true);
                                        }
                                        catch (Exception)
                                        {
                                            //throw;
                                        }
                                        break;

                                    case "$AXIS_ACT":
                                        try
                                        {
                                            var e6axis = new E6AXIS(ast);
                                            lb_A1.Text = FormatNumber(format, e6axis.A1);
                                            lb_A2.Text = FormatNumber(format, e6axis.A2);
                                            lb_A3.Text = FormatNumber(format, e6axis.A3);
                                            lb_A4.Text = FormatNumber(format, e6axis.A4);
                                            lb_A5.Text = FormatNumber(format, e6axis.A5);
                                            lb_A6.Text = FormatNumber(format, e6axis.A6);
                                            lb_E1.Text = FormatNumber(format, e6axis.E1);
                                            lb_E2.Text = FormatNumber(format, e6axis.E2);
                                            lb_E3.Text = FormatNumber(format, e6axis.E3);
                                            lb_E4.Text = FormatNumber(format, e6axis.E4);
                                            lb_E5.Text = FormatNumber(format, e6axis.E5);
                                            lb_E6.Text = FormatNumber(format, e6axis.E6);
                                        }
                                        catch (Exception)
                                        {

                                            //throw;
                                        }
                                        break;

                                    case "$VEL":
                                        try
                                        {
                                            var vel = new CP(ast);
                                            lb_VelCP.Text = FormatNumber(format, vel.LIN);
                                            lb_VelORI1.Text = FormatNumber(format, vel.ORI1);
                                            lb_VelORI2.Text = FormatNumber(format, vel.ORI2);
                                        }
                                        catch (Exception)
                                        {

                                            //throw;
                                        }
                                        break;

                                    case "$ACC":
                                        try
                                        {
                                            var acc = new CP(ast);
                                            lb_AccCP.Text = FormatNumber(format, acc.LIN);
                                            lb_AccORI1.Text = FormatNumber(format, acc.ORI1);
                                            lb_AccORI2.Text = FormatNumber(format, acc.ORI2);
                                        }
                                        catch (Exception)
                                        {

                                            //throw;
                                        }
                                        break;

                                    case "$BASE":
                                        try
                                        {
                                            var frame = new FRAME(ast);
                                            lb_BX.Text = FormatNumber(format, frame.X);
                                            lb_BY.Text = FormatNumber(format, frame.Y);
                                            lb_BZ.Text = FormatNumber(format, frame.Z);
                                            lb_BA.Text = FormatNumber(format, frame.A);
                                            lb_BB.Text = FormatNumber(format, frame.B);
                                            lb_BC.Text = FormatNumber(format, frame.C);

                                        }
                                        catch (Exception)
                                        {
                                            //throw;
                                        }
                                        break;

                                    case "$TOOL":
                                        try
                                        {
                                            var frame = new FRAME(ast);
                                            lb_TX.Text = FormatNumber(format, frame.X);
                                            lb_TY.Text = FormatNumber(format, frame.Y);
                                            lb_TZ.Text = FormatNumber(format, frame.Z);
                                            lb_TA.Text = FormatNumber(format, frame.A);
                                            lb_TB.Text = FormatNumber(format, frame.B);
                                            lb_TC.Text = FormatNumber(format, frame.C);

                                        }
                                        catch (Exception)
                                        {
                                            //throw;
                                        }
                                        break;


                                }
                            });
                        }
                    };

                    var t1 = client.SendAsync(KVReadQuery.Build(0, "$POS_ACT"), callback);
                    var t2 = client.SendAsync(KVReadQuery.Build(0, "$AXIS_ACT"), callback);
                    var t3 = client.SendAsync(KVReadQuery.Build(0, "$VEL"), callback);
                    var t4 = client.SendAsync(KVReadQuery.Build(0, "$ACC"), callback);
                    var t5 = client.SendAsync(KVReadQuery.Build(0, "$BASE"), callback);
                    var t6 = client.SendAsync(KVReadQuery.Build(0, "$TOOL"), callback);
                    var t7 = client.SendAsync(KVReadQuery.Build(0, "$OV_PRO"), callback);
                }
            }, null, Timeout.Infinite, Timeout.Infinite);

            // Init Tree
            InitTree();

            // Init Record
            InitRecord();

            // Init Client
            client = new KukavarClient(1, KukavarLogManager.GetLogger(1))
            {
                ServerIP = IPAddress.Parse("192.168.10.4"),
                ServerPort = 7000,
            };

            client.Connecting += ConnectingHandler;
            client.Connected += Connected;
            client.ConnectionError += ConnectionErrorHandler;
            client.Closing += ClosingErrorHandler;
            client.Closed += ClosedErrorHandler;
        }

        private void InitList()
        {
            dtio = new DataTable("IO");
            dtio.Columns.Add("Name");
            dtio.Columns.Add("Tag");
            dtio.Columns.Add("Group");
            dtio.Columns.Add("Value");
            dtio.Columns.Add("Type");

            AddIOItem("X_RPMDemande_Broche", "RPM prog", "Usinage");
            AddIOItem("X_FacteurRPM_Broche", "+/- RPM (50-150%)", "Usinage");
            AddIOItem("X_RPMModifie_Broche", "RPM actuel", "Usinage");

            AddIOItem("X_AUEnCours", "Arret d'urgence", "Etats");
            AddIOItem("X_InterStopRob", "Arret general", "Etats");
            AddIOItem("X_RPMNonAtteint_Broche", "Stop vitesse broche", "Etats");

            //olvIO.DataSource = dtio;

            
            objectListView.CellEditActivation = ObjectListView.CellEditActivateMode.DoubleClick;
            objectListView.SortGroupItemsByPrimaryColumn = true;

            // Do that here because of Internet Zone pb woth image strem and VMWare network share.
            var imglist = new ImageList();
            imglist.Images.Add("bfalse", Properties.Resources.bfalse);
            imglist.Images.Add("btrue", Properties.Resources.btrue);
            objectListView.SmallImageList = imglist;

            objectListView.Refresh();
            olvColValue.ImageGetter = delegate (object model)
            {   
                var drv = model as DataRowView;
                if (drv["Type"].ToString() == "BOOL")
                {
                    if (drv["Value"].ToString() == "TRUE")
                        return "btrue";
                    else
                        return "bfalse";
                }
                return "";
            };

            var ds = new DataSet();
            ds.Tables.Add(dtio);
            objectListView.DataSource = new BindingSource(ds, "IO");
            objectListView.Sort("Group");

            ioTimer = new System.Threading.Timer((state) =>
            {
                if (client.Status == ClientStatus.Connected)
                {
                    KVReplyCallback callback = async (reply) =>
                    {
                        if (reply.Successful)
                        {
                            this.BeginInvoke((Action)delegate ()
                            {
                                var varName = ((KVReadQuery)reply.Query).VarName;
                                //lbMonitoTime.Text = string.Format("elapsed time : {0,4:F0} ms", reply.RoundTripTime.TotalMilliseconds);
                                var ast = reply.Answer.GetAST();
                                foreach (DataRow dr in dtio.Rows)
                                {
                                    if (dr["Name"].ToString() == varName)
                                    {
                                        dr["Value"] = ast.ToKrlString();
                                        dr["Type"] = ast.KrlType;
                                        return;
                                    }
                                }
                            });
                        }
                    };

                    foreach (DataRow dr in dtio.Rows)
                    {
                        var varName = dr["Name"].ToString();
                        client.SendAsync(KVReadQuery.Build(0, varName), callback);
                    }
                }
            }, null, Timeout.Infinite, Timeout.Infinite);

        }
        private void AddIOItem(string krl, string tag, string group)
        {
            DataRow dr;

            dr = dtio.NewRow();

            dr["Name"] = krl;
            dr["Tag"] = tag;
            dr["Group"] = group;
            dr["Value"] = "";
            dr["Type"] = "";

            dtio.Rows.Add(dr);
        }

        public void TimedFilter(ObjectListView olv, string txt)
        {
            TimedFilter(olv, txt, 0);
        }
        public void TimedFilter(ObjectListView olv, string txt, int matchKind)
        {
            TextMatchFilter filter = null;
            if (!String.IsNullOrEmpty(txt))
            {
                switch (matchKind)
                {
                    case 0:
                    default:
                        filter = TextMatchFilter.Contains(olv, txt);
                        break;
                    case 1:
                        filter = TextMatchFilter.Prefix(olv, txt);
                        break;
                    case 2:
                        filter = TextMatchFilter.Regex(olv, txt);
                        break;
                }
            }

            // Text highlighting requires at least a default renderer
            if (olv.DefaultRenderer == null)
                olv.DefaultRenderer = new HighlightTextRenderer(filter);

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            olv.ModelFilter = filter;
            //olv.Invalidate();
            stopWatch.Stop();

            //IList objects = olv.Objects as IList;
            //if (objects == null)
            //    this.ToolStripStatus1 = prefixForNextSelectionMessage =
            //        String.Format("Filtered in {0}ms", stopWatch.ElapsedMilliseconds);
            //else
            //    this.ToolStripStatus1 = prefixForNextSelectionMessage =
            //        String.Format("Filtered {0} items down to {1} items in {2}ms",
            //                      objects.Count,
            //                      olv.Items.Count,
            //                      stopWatch.ElapsedMilliseconds);
        }


        #region Connection
        private async void ckConnect_CheckedChanged(object sender, EventArgs e)
        {
            if (ckConnect.Checked)
            {
                // start connection
                ckConnect.Text = "Disconnect";
                grpCSettings.Enabled = false;
                settings.ServerIP = tbServerIP.Text;
                settings.ServerPort = int.Parse(tbServerPort.Text);
                settings.MaxIdleTime = int.Parse(tbMaxIdleTime.Text);
                settings.ReconnectionTimeout = int.Parse(tbReconnectionTO.Text);
                settings.AutoReconnect = ckAutoReconnect.Checked;
                settings.Save();
                await client.ConnectAsync();
                Task.Run(() => client.EnqueuingAsync());
            }
            else
            {
                // stop connection
                ckConnect.Text = "Connect";
                client.Close();
                grpCSettings.Enabled = true;
            }
        }
        private Task ConnectingHandler(object sender, EventArgs e)
        {
            this.BeginInvoke((Action)delegate ()
            {
                //code to update UI
                lbConnectionStatus.Text = "connecting...";
                lbConnectionStatus.BackColor = Color.Yellow;
                tabControl1.Enabled = false;
            });
            return Task.CompletedTask;
        }
        private Task Connected(object sender, EventArgs e)
        {
            this.BeginInvoke((Action)delegate ()
            {
                //code to update UI
                lbConnectionStatus.Text = "connected";
                lbConnectionStatus.BackColor = Color.LimeGreen;
                tabControl1.Enabled = true;
                ckMonitor.Enabled = true;
            });
              
            var t1 = client.SendAsync(KVReadQuery.Build(0, "$MODEL_NAME[]"), async (reply) =>
            {
                if (!reply.Answer.Successful) return;
                this.BeginInvoke((Action)delegate ()
                {
                    var name = reply.Answer.VarValue;
                    tbRobName.Text = name.Substring(1, name.Length - 2); 
                });
            });

            var t2 = client.SendAsync(KVReadQuery.Build(0, "$V_ROBCOR[]"), async (reply) =>
            {
                if (!reply.Answer.Successful) return;
                this.BeginInvoke((Action)delegate ()
                {
                    var name = reply.Answer.VarValue;
                    tbRobVersion.Text = name.Substring(1, name.Length - 2);
                });
            });

            var t3 = client.SendAsync(KVReadQuery.Build(0, "$ROBRUNTIME"), async (reply) =>
            {
                if (!reply.Answer.Successful) return;
                this.BeginInvoke((Action)delegate ()
                {
                    var min = int.Parse(reply.Answer.VarValue);
                    tbRobHours.Text = string.Format("{0}:{1:00}", min / 60, min % 60);
                });
            });

            infoTimer.Change(TimeSpan.FromMilliseconds(0), TimeSpan.FromMilliseconds(cmdinfoRefreshRate));
            return Task.CompletedTask;
        }
        private Task ConnectionErrorHandler(object sender, ConnectionErrorEventArgs e)
        {
            infoTimer.Change(Timeout.Infinite, Timeout.Infinite);
            CmdInfoReset();

            this.BeginInvoke((Action)delegate ()
            {
                //code to update UI
                lbConnectionStatus.Text = "disconnected";
                lbConnectionStatus.BackColor = Color.Red;
                tabControl1.Enabled = false;
                ckMonitor.Enabled = false;
            });
            return Task.CompletedTask;
        }
        private Task ClosingErrorHandler(object sender, ClosingEventArgs e)
        {
            infoTimer.Change(Timeout.Infinite, Timeout.Infinite);
            CmdInfoReset();

            this.BeginInvoke((Action)delegate ()
            {
                //code to update UI
                lbConnectionStatus.Text = "closing...";
                lbConnectionStatus.BackColor = Color.Yellow;
                tabControl1.Enabled = false;
                ckMonitor.Enabled = false;
            });
            return Task.CompletedTask;
        }
        private Task ClosedErrorHandler(object sender, EventArgs e)
        {
            infoTimer.Change(Timeout.Infinite, Timeout.Infinite);
            CmdInfoReset();

            this.BeginInvoke((Action)delegate ()
            {
                //code to update UI
                lbConnectionStatus.Text = "closed";
                lbConnectionStatus.BackColor = Color.Gray;
                tabControl1.Enabled = false;
                ckMonitor.Enabled = false;
            });
            return Task.CompletedTask;
        }
        
        private void CmdInfoColors(Label label, string state)
        {
            switch (state)
            {
                case "#P_ACTIVE":
                    label.BackColor = Color.LimeGreen;
                    break;
                case "#P_STOP":
                case "#P_UNKNOWN":
                    label.BackColor = Color.Red;
                    break;
                case "#P_END":
                    label.BackColor = Color.Yellow;
                    break;
                case "#P_RESET":
                    label.BackColor = Color.Orange;
                    break;
                default:
                    label.BackColor = Color.LightGray;
                    break;
            }
        }
        private void CmdInfoReset()
        {
            var list = new List<Label>() { lbProName0, lbProName1, lbProState0, lbProState1 };
            foreach (var label in list)
            {
                label.Text = "";
                label.BackColor = Color.LightGray;
            }
        }
        #endregion

        #region TreeList
        private void InitTree()
        {
            // set the delegate that the tree uses to know if a node is expandable
            this.treeListView.CanExpandGetter = x => (x is StrucData && (x as StrucData).Value.Count > 0);
            // set the delegate that the tree uses to know the children of a node
            this.treeListView.ChildrenGetter = x =>
            {
                if (x is StrucData) return (x as StrucData).Value.Values;
                return null;
            };

            // create the tree columns and set the delegates to print the desired object proerty
            var nameColumn = new BrightIdeasSoftware.OLVColumn("Name", "Name");
            //nameColumn.Width = 150;
            nameColumn.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            nameColumn.UseFiltering = false;
            nameColumn.AspectGetter = x =>
            {
                var data = x as Data;
                return data.Name;
            };

            var typeColumn = new BrightIdeasSoftware.OLVColumn("Type", "Type");
            //typeColumn.Width = 100;
            typeColumn.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            typeColumn.UseFiltering = false;
            typeColumn.AspectGetter = x => {
                if (x is StrucData)
                {
                    var data = x as StrucData;
                    return data.StrucType;
                }
                else
                {
                    var data = x as Data;
                    return data.Type;
                }
            };

            var valueColumn = new BrightIdeasSoftware.OLVColumn("Value", "Value");
            //valueColumn.Width = 100;
            valueColumn.UseFiltering = false;
            valueColumn.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            valueColumn.AspectGetter = x => {
                var data = x as Data;
                switch (data.Type)
                {
                    case DataType.BOOL:
                        return (data as BoolData).Value;
                    case DataType.INT:
                        return (data as IntData).Value;
                    case DataType.REAL:
                        return (data as RealData).Value;
                    case DataType.CHAR:
                        return (data as CharData).Value;
                    case DataType.STRING:
                        return (data as StringData).Value;
                    case DataType.ENUM:
                        return (data as EnumData).Value;
                    case DataType.STRUC:
                        return "";
                    default:
                        return "";
                }
            };

            // add the columns to the tree
            this.treeListView.Columns.Add(nameColumn);
            this.treeListView.Columns.Add(valueColumn);
            this.treeListView.Columns.Add(typeColumn);

            treeListView.CellClick += treeListView_CellClick;
        }
        private void FillTree(Data data)
        {
            FillTree(new List<Data> { data });
        }
        private void FillTree(IEnumerable<Data> dataList, bool expandall = false)
        {
            // set the tree roots
            treeListView.ClearObjects();
            treeListView.Roots = dataList;

            if (dataList.Count() > 1)
            {
                if (expandall) treeListView.ExpandAll();
                else treeListView.CollapseAll();
            }
            else
            {
                treeListView.ExpandAll();
            }
            
            treeListView.AutoResizeColumns();
        }
        private void treeListView_CellClick(object sender, BrightIdeasSoftware.CellClickEventArgs e)
        {
            var rowIndex = treeListView.SelectedIndex;
            if (rowIndex > -1)
            {
                var data = treeListView.GetItem(rowIndex).RowObject;

                var name = "";
                var value = "";
                if (data is StrucData)
                {
                    foreach (var element in (data as StrucData).Value)
                    {
                        name += element.Key + "\t";

                        switch ((element.Value as Data).Type)
                        {
                            case DataType.BOOL:
                                value += (element.Value as BoolData).Value + "\t";
                                break;
                            case DataType.INT:
                                value += (element.Value as IntData).Value + "\t";
                                break;
                            case DataType.REAL:
                                value += (element.Value as RealData).Value + "\t";
                                break;
                            case DataType.CHAR:
                                value += (element.Value as CharData).Value + "\t";
                                break;
                            case DataType.STRING:
                                value += (element.Value as StringData).Value + "\t";
                                break;
                            case DataType.ENUM:
                                value += (element.Value as EnumData).Value + "\t";
                                break;
                            case DataType.STRUC:
                                break;
                            default:
                                break;
                        }

                    }
                }
                else
                {
                    var element = (data as Data);
                    name += element.Name + "\t";
                    switch (element.Type)
                    {
                        case DataType.BOOL:
                            value += (element as BoolData).Value + "\t";
                            break;
                        case DataType.INT:
                            value += (element as IntData).Value + "\t";
                            break;
                        case DataType.REAL:
                            value += (element as RealData).Value + "\t";
                            break;
                        case DataType.CHAR:
                            value += (element as CharData).Value + "\t";
                            break;
                        case DataType.STRING:
                            value += (element as StringData).Value + "\t";
                            break;
                        case DataType.ENUM:
                            value += (element as EnumData).Value + "\t";
                            break;
                        case DataType.STRUC:
                            break;
                        default:
                            break;
                    }
                }

                Clipboard.SetDataObject(name + Environment.NewLine + value, true);
                MessageBox.Show("Content copied to clipboard !", "Copy to Clipboard");
            }

        }
        private void btExpandAll_Click(object sender, EventArgs e)
        {
            treeListView.ExpandAll();
        }
        private void btCollapseAll_Click(object sender, EventArgs e)
        {
            treeListView.CollapseAll();
        }
        #endregion

        #region Read single
        private async void btReadSingle_Click(object sender, EventArgs e)
        {
            var varName = scbRead.Text;
            if (varName == "")
            {
                MessageBox.Show("Please, enter a variable name.");
                return;
            }

            await client.SendAsync(KVReadQuery.Build(1, varName), async (reply) =>
            {
                if (!reply.Answer.Successful) return;

                this.BeginInvoke((Action)delegate ()
                {
                    var ast = reply.Answer.GetAST();
                    ast.Name = ((KVReadQuery)reply.Query).VarName;
                    SetReadElapsedTime(reply.RoundTripTime.TotalMilliseconds);
                    FillTree(ast);
                });
            });

            // update combobox history
            if (varName!= "")
            {
                // removes other occurence
                // ensure unique varnames in list and last occurence goes on top of the list
                settings.ReadHistory.RemoveAll(s => s.Equals(varName, StringComparison.OrdinalIgnoreCase));
                settings.ReadHistory.Insert(0, scbRead.Text.ToUpper());

                if (settings.ReadHistory.Count == readHistoryMaxCount) settings.ReadHistory.RemoveAt(scbRead.Items.Count - 1);

                // rebind the source to update the control
                scbRead.DataSource = new BindingSource(settings.ReadHistory, null);
                settings.Save();
            }
            
        }
        private void scbRead_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btReadSingle_Click(sender, e);
        }
        private void btRemoveHistory_Click(object sender, EventArgs e)
        {
            if (settings.ReadHistory.Remove(scbRead.Text))
            {
                scbRead.DataSource = new BindingSource(settings.ReadHistory, null);
                settings.Save();
                scbRead.SelectedIndex = -1;
            }
        }
        private void SetReadElapsedTime(double time)
        {
            lbReadTime.Text = "elapsed time : " + Math.Round(time, 1) + "ms";
        }
        #endregion

        #region Read template
        private async void btReadTemplate_Click(object sender, EventArgs e)
        {
            chrono.Restart();
            btReadTemplate.Enabled = false;

            var queue = new ConcurrentQueue<KVReply>();

            // send all queries
            var queries = lstbRead.Items.OfType<string>().Select(name => KVReadQuery.Build(1, name));
            var sendQueries = Task.Run(async () =>
            {
                foreach (var query in queries)
                {
                    await client.SendAsync(query, async (reply) =>
                    {
                        queue.Enqueue(reply);
                    });
                }
            });

            // time out
            var replyTimeout = false;
            var waitAnswers = Task.Run(() =>
            {
                var queriesCount = queries.Count();
                var timeout = Stopwatch.StartNew();
                while (queue.Count < queriesCount)
                {
                    Task.Delay(1);
                    if (timeout.ElapsedMilliseconds > 2000)
                    {
                        replyTimeout = true;
                        break;
                    }
                }
            });
            waitAnswers.Wait();

            if (!replyTimeout)
            {
                SetReadElapsedTime((double)chrono.ElapsedMilliseconds);

                var dataList = new List<Data>();
                while (!queue.IsEmpty)
                {
                    KVReply reply;
                    if (queue.TryDequeue(out reply))
                    {
                        if (reply.Answer.Successful)
                        {
                            var ast = reply.Answer.GetAST();
                            ast.Name = ((KVReadQuery)reply.Query).VarName;
                            dataList.Add(ast);
                        }
                    }
                    else
                    {
                        Debug.WriteLine("CommunicationGroup.TryDequeue : false");
                    }
                }

                FillTree(dataList, true);
            }
            else
            {
                client.ClearQueue();
                MessageBox.Show("Read template aborted (timeout).");
            }

            btReadTemplate.Enabled = true;
        }
        private void btAddReadTemplate_Click(object sender, EventArgs e)
        {
            if (settings.ReadTemplateList.Count == readTemplatesMaxCount)
            {
                MessageBox.Show("Only " + readTemplatesMaxCount + "can be created. Remove an existing template if you want to create a new one.");
            }
            else
            {
                var templateNames = settings.ReadTemplateList.Keys;
                var templateName = "New Template";

                if (templateNames.Any(s => s.Equals(templateName, StringComparison.OrdinalIgnoreCase)))
                {
                    for (int i = 1; i < 1000; i++)
                    {
                        templateName = "New Template " + i;
                        if (!templateNames.Any(s => s.Equals(templateName, StringComparison.OrdinalIgnoreCase))) break;
                    }
                }

                settings.ReadTemplateList.Add(templateName, new List<string>());
                RefreshTemplateCombobox(templateName);
                btEditTemplateName_Click(sender, e);
            }
        }
        private void btAddTemplateVar_Click(object sender, EventArgs e)
        {
            if (cbTemplate.SelectedIndex > -1)
            {
                if (scbRead.Text != "")
                {
                    var item = (KeyValuePair<string, List<string>>)cbTemplate.SelectedItem;
                    if (!item.Value.Any(s => s.Equals(scbRead.Text, StringComparison.OrdinalIgnoreCase)))
                    {
                        item.Value.Add(scbRead.Text.ToUpper());
                        RefreshTemplateList(item.Value.Count - 1);
                    }
                    else
                    {
                        MessageBox.Show("A variable with the same name already exists in the list.");
                    }
                }
           }
        }
        private void btRemoveTemplateVar_Click(object sender, EventArgs e)
        {
            if (lstbRead.SelectedIndex > -1)
            {
                var item = (KeyValuePair<string, List<string>>)cbTemplate.SelectedItem;
                var dialogResult = MessageBox.Show("Are you sure you want to remove the variable '" + lstbRead.SelectedValue + "' from the template ?", "Read template deletion", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    var index = item.Value.IndexOf(lstbRead.SelectedValue.ToString());
                    item.Value.RemoveAt(index);
                    RefreshTemplateList(Math.Min(index, item.Value.Count -1));
                }
            }
        }
        private void cbTemplate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTemplate.SelectedIndex > -1)
            {
                var item = (KeyValuePair<string, List<string>>)cbTemplate.SelectedItem ;
                tbTemplateName.Text = item.Key;
                lstbRead.DataSource = new BindingSource(item.Value, null);
            }
            else
            {
                tbTemplateName.Text = "";
                lstbRead.DataSource = null;
            }       
        }
        private void btEditTemplateName_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Click ...");
            if (!tbTemplateName.Enabled)
            {
                tbTemplateName.Enabled = true;
                tbTemplateName.Select();
            }
            else
            {
                ValidateTemplateName();
            }
        }
        private void tbTemplateName_Validating(object sender, CancelEventArgs e)
        {
            Debug.WriteLine("Validation ...");
            ValidateTemplateName();
        }
        private void ValidateTemplateName()
        {
            var item = (KeyValuePair<string, List<string>>)cbTemplate.SelectedItem;
            var diff = settings.ReadTemplateList.Keys.Where(s => s != item.Key);
            if (diff.Any(s => s.Equals(tbTemplateName.Text)))
            {
                MessageBox.Show("This name already exists in the template list. Change the template name.");
                tbTemplateName.Select();
            }
            else
            {
                var value = item.Value;
                settings.ReadTemplateList.Remove(item.Key);
                settings.ReadTemplateList.Add(tbTemplateName.Text, value);
                RefreshTemplateCombobox(tbTemplateName.Text);
                tbTemplateName.Enabled = false;
            }
        }
        private void btRemoveReadTemplate_Click(object sender, EventArgs e)
        {
            if (cbTemplate.SelectedIndex > -1)
            {
                var item = (KeyValuePair<string, List<string>>)cbTemplate.SelectedItem;
                var dialogResult = MessageBox.Show("Are you sure you want to delete the template '" + item.Key + "' ?", "Read template deletion", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    settings.ReadTemplateList.Remove(item.Key);
                    RefreshTemplateCombobox();
                }
            }            
        }
        private void RefreshTemplateCombobox(string selectedTemplateName = "")
        {
            if (settings.ReadTemplateList.Count > 0)
            {
                cbTemplate.DataSource = new BindingSource(settings.ReadTemplateList.OrderBy(kv => kv.Key), null);
                cbTemplate.DisplayMember = "Key";
                cbTemplate.ValueMember = "Key";
                cbTemplate.SelectedValue = selectedTemplateName;
            }
            settings.Save();
        }
        private void RefreshTemplateList(int selectedIndex = -1)
        {
            if (cbTemplate.SelectedIndex > -1)
            {
                var template = (KeyValuePair<string, List<string>>)cbTemplate.SelectedItem;
                lstbRead.DataSource = new BindingSource(settings.ReadTemplateList[template.Key], null);
                lstbRead.SelectedIndex = selectedIndex;
                settings.Save();
            }
            else
            {
                lstbRead.DataSource = null;
            }
        }
        private void tbTemplateName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                ValidateTemplateName();
        }
        private void btUp_Click(object sender, EventArgs e)
        {
            if (cbTemplate.SelectedIndex > -1 && lstbRead.SelectedIndex > -1)
            {
                if (lstbRead.SelectedIndex > 0)
                {
                    var template = (KeyValuePair<string, List<string>>)cbTemplate.SelectedItem;
                    var varList = settings.ReadTemplateList[template.Key];
                    
                    var iprev = lstbRead.SelectedIndex;
                    var vprev = varList[iprev];

                    // swap
                    varList[iprev] = varList[iprev - 1];
                    varList[iprev - 1] = vprev;

                    RefreshTemplateList(iprev - 1);
                }
            }
        }
        private void btDown_Click(object sender, EventArgs e)
        {

            if (cbTemplate.SelectedIndex > -1 && lstbRead.SelectedIndex > -1)
            {
                if (lstbRead.SelectedIndex < lstbRead.Items.Count - 1)
                {
                    var template = (KeyValuePair<string, List<string>>)cbTemplate.SelectedItem;
                    var varList = settings.ReadTemplateList[template.Key];

                    var iprev = lstbRead.SelectedIndex;
                    var vprev = varList[iprev];

                    // swap
                    varList[iprev] = varList[iprev + 1];
                    varList[iprev + 1] = vprev;

                    RefreshTemplateList(iprev + 1);
                }
            }
        }
        #endregion

        #region Record
        private void InitRecord()
        {
            dtrecords = new DataTable("Positions");

            // record ID
            DataColumn colId = new DataColumn("Id");
            colId.DataType = System.Type.GetType("System.Int32");
            colId.AutoIncrement = true;
            colId.AutoIncrementSeed = 1;
            colId.AutoIncrementStep = 1;

            // record Date
            DataColumn colDate = new DataColumn("$DATE");
            colDate.DataType = System.Type.GetType("System.DateTime");

            // data fields
            dtrecords.Columns.Add(colId);
            dtrecords.Columns.Add(colDate);

            dtrecords.Columns.Add("$POS_ACT.X");
            dtrecords.Columns.Add("$POS_ACT.Y");
            dtrecords.Columns.Add("$POS_ACT.Z");
            dtrecords.Columns.Add("$POS_ACT.A");
            dtrecords.Columns.Add("$POS_ACT.B");
            dtrecords.Columns.Add("$POS_ACT.C");
            dtrecords.Columns.Add("$POS_ACT.E1");
            dtrecords.Columns.Add("$POS_ACT.E2");
            dtrecords.Columns.Add("$POS_ACT.E3");
            dtrecords.Columns.Add("$POS_ACT.E4");
            dtrecords.Columns.Add("$POS_ACT.E5");
            dtrecords.Columns.Add("$POS_ACT.E6");
            dtrecords.Columns.Add("$POS_ACT.S");
            dtrecords.Columns.Add("$POS_ACT.T");

            dtrecords.Columns.Add("$AXIS_ACT.A1");
            dtrecords.Columns.Add("$AXIS_ACT.A2");
            dtrecords.Columns.Add("$AXIS_ACT.A3");
            dtrecords.Columns.Add("$AXIS_ACT.A4");
            dtrecords.Columns.Add("$AXIS_ACT.A5");
            dtrecords.Columns.Add("$AXIS_ACT.A6");
            dtrecords.Columns.Add("$AXIS_ACT.E1");
            dtrecords.Columns.Add("$AXIS_ACT.E2");
            dtrecords.Columns.Add("$AXIS_ACT.E3");
            dtrecords.Columns.Add("$AXIS_ACT.E4");
            dtrecords.Columns.Add("$AXIS_ACT.E5");
            dtrecords.Columns.Add("$AXIS_ACT.E6");

            dtrecords.Columns.Add("$BASE.X");
            dtrecords.Columns.Add("$BASE.Y");
            dtrecords.Columns.Add("$BASE.Z");
            dtrecords.Columns.Add("$BASE.A");
            dtrecords.Columns.Add("$BASE.B");
            dtrecords.Columns.Add("$BASE.C");

            dtrecords.Columns.Add("$TOOL.X");
            dtrecords.Columns.Add("$TOOL.Y");
            dtrecords.Columns.Add("$TOOL.Z");
            dtrecords.Columns.Add("$TOOL.A");
            dtrecords.Columns.Add("$TOOL.B");
            dtrecords.Columns.Add("$TOOL.C");

            for (int i = 2; i < dtrecords.Columns.Count; i++)
            {
                if (dtrecords.Columns[i].ColumnName == "$POS_ACT.S" || dtrecords.Columns[i].ColumnName == "$POS_ACT.T")
                {
                    dtrecords.Columns[i].DataType = System.Type.GetType("System.Int32");
                }
                else
                {
                    dtrecords.Columns[i].DataType = System.Type.GetType("System.Double");
                }
            }

            // load settings
            settings.Records = settings.Records ?? new List<Record>();
            if (settings.Records.Count > 0)
            {
                foreach (var record in settings.Records)
                {
                    dtrecords.Rows.Add(record.ToArray());
                }
            }

            // Bind the view
            dgvRecords.DataSource = dtrecords;

            // Clipboard
            dgvRecords.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
            cbRecordFormat.SelectedIndex = 0;

            // DataGridView Format
            dgvRecords.AllowUserToAddRows = false;
            dgvRecords.RowsDefaultCellStyle.BackColor = Color.White;
            dgvRecords.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dgvRecords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgvRecords.AllowUserToResizeRows = false;

            dgvRecords.RowHeadersVisible = true;
            dgvRecords.RowHeadersWidth = 30;

            dgvRecords.Columns["Id"].DefaultCellStyle.BackColor = Color.Gray;

            dgvRecords.Columns["$DATE"].DefaultCellStyle.BackColor = Color.Gray;
            dgvRecords.Columns["$DATE"].DefaultCellStyle.Format = "yyyy/MM/dd HH:mm:ss";

            for (int i = 0; i < dtrecords.Columns.Count; i++)
            {
                dgvRecords.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                dgvRecords.Columns[i].FillWeight = 1;
            }

            dtrecords.TableNewRow += (s, e) => {
                if (dtrecords.Rows.Count == 0)
                    rblRecordFilter_SelectedIndexChanged(null, null);
            };

            cbRecordFormat.SelectedIndex = 0;
        }
        private async void btAddRecord_Click(object sender, EventArgs e)
        {
            chrono.Restart();
            btAddRecord.Enabled = false;

            var queue = new ConcurrentQueue<KVReply>();

            // send all queries
            var queries = (new List<string> { "$DATE", "$POS_ACT", "$AXIS_ACT", "$BASE", "$TOOL" }).Select(name => KVReadQuery.Build(1, name));
            var sendQueries = Task.Run(async () =>
            {
                foreach (var query in queries)
                {
                    await client.SendAsync(query, async (reply) =>
                    {
                        queue.Enqueue(reply);
                    });
                }
            });

            // time out
            var replyTimeout = false;
            var waitAnswers = Task.Run(() =>
            {
                var queriesCount = queries.Count();
                var timeout = Stopwatch.StartNew();
                while (queue.Count < queriesCount)
                {
                    Task.Delay(1);
                    if (timeout.ElapsedMilliseconds > 2000)
                    {
                        replyTimeout = true;
                        break;
                    }
                }
            });
            waitAnswers.Wait();

            if (!replyTimeout)
            {
                //MessageBox.Show("All replies recieved !");
                var row = dtrecords.NewRow();
                while (!queue.IsEmpty)
                {
                    KVReply reply;
                    if (queue.TryDequeue(out reply))
                    {
                        if (reply.Answer.Successful)
                        {
                            var query = (KVReadQuery)reply.Query;
                            var ast = reply.Answer.GetAST();
                            switch (query.VarName)
                            {
                                case "$DATE":
                                    var date = new DATE(ast);
                                    row["$DATE"] = date.ToDateTime();
                                    break;

                                case "$POS_ACT":
                                    var e6pos = new E6POS(ast);
                                    row["$POS_ACT.X"] = e6pos.X;
                                    row["$POS_ACT.Y"] = e6pos.Y;
                                    row["$POS_ACT.Z"] = e6pos.Z;
                                    row["$POS_ACT.A"] = e6pos.A;
                                    row["$POS_ACT.B"] = e6pos.B;
                                    row["$POS_ACT.C"] = e6pos.C;
                                    row["$POS_ACT.E1"] = e6pos.E1;
                                    row["$POS_ACT.E2"] = e6pos.E2;
                                    row["$POS_ACT.E3"] = e6pos.E3;
                                    row["$POS_ACT.E4"] = e6pos.E4;
                                    row["$POS_ACT.E5"] = e6pos.E5;
                                    row["$POS_ACT.E6"] = e6pos.E6;
                                    row["$POS_ACT.S"] = e6pos.S;
                                    row["$POS_ACT.T"] = e6pos.T;
                                    break;

                                case "$AXIS_ACT":
                                    var e6axis = new E6AXIS(ast);
                                    row["$AXIS_ACT.A1"] = e6axis.A1;
                                    row["$AXIS_ACT.A2"] = e6axis.A2;
                                    row["$AXIS_ACT.A3"] = e6axis.A3;
                                    row["$AXIS_ACT.A4"] = e6axis.A4;
                                    row["$AXIS_ACT.A5"] = e6axis.A5;
                                    row["$AXIS_ACT.A6"] = e6axis.A6;
                                    row["$AXIS_ACT.E1"] = e6axis.E1;
                                    row["$AXIS_ACT.E2"] = e6axis.E2;
                                    row["$AXIS_ACT.E3"] = e6axis.E3;
                                    row["$AXIS_ACT.E4"] = e6axis.E4;
                                    row["$AXIS_ACT.E5"] = e6axis.E5;
                                    row["$AXIS_ACT.E6"] = e6axis.E6;
                                    break;

                                case "$BASE":
                                    var baseFrame = new FRAME(ast);
                                    row["$BASE.X"] = baseFrame.X;
                                    row["$BASE.Y"] = baseFrame.Y;
                                    row["$BASE.Z"] = baseFrame.Z;
                                    row["$BASE.A"] = baseFrame.A;
                                    row["$BASE.B"] = baseFrame.B;
                                    row["$BASE.C"] = baseFrame.C;
                                    break;

                                case "$TOOL":
                                    var toolFrame = new FRAME(ast);
                                    row["$TOOL.X"] = toolFrame.X;
                                    row["$TOOL.Y"] = toolFrame.Y;
                                    row["$TOOL.Z"] = toolFrame.Z;
                                    row["$TOOL.A"] = toolFrame.A;
                                    row["$TOOL.B"] = toolFrame.B;
                                    row["$TOOL.C"] = toolFrame.C;
                                    break;

                                default:
                                    break;
                            }
                        }
                    }
                    else
                    {
                        Debug.WriteLine("CommunicationGroup.TryDequeue : false");
                    }
                }
                dtrecords.Rows.Add(row);

                settings.Records.Clear();
                foreach (var dr in dtrecords.Rows.OfType<DataRow>())
                {
                    var rec = Record.FromDatarow(dr);
                    settings.Records.Add(rec);
                }

                //settings.Records = records.Rows.OfType<DataRow>().Select(dr => Record.FromDatarow(dr)).ToList();
                settings.Save();
            }
            else
            {
                client.ClearQueue();
                MessageBox.Show("Read template aborted (timeout).");
            }
            btAddRecord.Enabled = true;
        }
        private void btRemoveRecord_Click(object sender, EventArgs e)
        {
            var selectedRows = dgvRecords.SelectedRows;
            if (selectedRows.Count > 0)
            {
                var result = MessageBox.Show("Are you sure you want to delete the selected rows ?", "Delete Records", MessageBoxButtons.OKCancel);
                switch (result)
                {
                    case DialogResult.OK:
                        foreach (DataGridViewRow item in selectedRows)
                        {
                            dgvRecords.Rows.RemoveAt(item.Index);
                        }
                        settings.Save();
                        break;
                }
            }
            else
            {
                MessageBox.Show("No rows are selected. Please, select one or severl rows to delete by clicking on rows header.");
            }
        }
        private void btRecordReset_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Are you sure you want to clear all records ?", "Reset Records", MessageBoxButtons.OKCancel);
            switch (res)
            {
                case DialogResult.OK:
                    dtrecords.Rows.Clear();
                    // us this too reset auto-increment
                    dtrecords.Columns["Id"].AutoIncrementStep = -1;
                    dtrecords.Columns["Id"].AutoIncrementSeed = -1;
                    dtrecords.Columns["Id"].AutoIncrementStep = 1;
                    dtrecords.Columns["Id"].AutoIncrementSeed = 1;

                    settings.Records.Clear();
                    settings.Save();
                    break;
            }
        }
        private void rblRecordFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dtrecords == null) return;
            if (dtrecords.Columns == null) return;

            var cols = dtrecords.Columns.OfType<DataColumn>();
            switch (rblRecordFilter.SelectedIndex)
            {
                case 0:
                    foreach (var col in cols)
                    {
                        var colName = col.ColumnName;
                        if (colName.Contains("$POS_ACT"))
                        {
                            dgvRecords.Columns[colName].Visible = true;
                            dgvRecords.Columns[colName].HeaderText = colName.Split(char.Parse("."))[1];
                        }
                        else
                        {
                            dgvRecords.Columns[colName].Visible = false;
                        }
                    }
                    break;

                case 1:
                    foreach (var col in cols)
                    {
                        var colName = col.ColumnName;
                        if (colName.Contains("$AXIS_ACT"))
                        {
                            dgvRecords.Columns[colName].Visible = true;
                            dgvRecords.Columns[colName].HeaderText = colName.Split(char.Parse("."))[1];
                        }
                        else
                        {
                            dgvRecords.Columns[colName].Visible = false;
                        }
                    }
                    break;

                case 2:
                    foreach (var col in cols)
                    {
                        var colName = col.ColumnName;
                        if (colName.Contains("$BASE"))
                        {
                            dgvRecords.Columns[colName].Visible = true;
                            dgvRecords.Columns[colName].HeaderText = colName.Split(char.Parse("."))[1];
                        }
                        else
                        {
                            dgvRecords.Columns[colName].Visible = false;
                        }
                    }
                    break;

                case 3:
                    foreach (var col in cols)
                    {
                        var colName = col.ColumnName;
                        if (colName.Contains("$TOOL"))
                        {
                            dgvRecords.Columns[colName].Visible = true;
                            dgvRecords.Columns[colName].HeaderText = colName.Split(char.Parse("."))[1];
                        }
                        else
                        {
                            dgvRecords.Columns[colName].Visible = false;
                        }
                    }
                    break;

                case 4:
                    foreach (var col in cols)
                    {
                        var colName = col.ColumnName;
                        dgvRecords.Columns[colName].Visible = true;
                        dgvRecords.Columns[colName].HeaderText = colName;
                    }
                    break;
            }

            dgvRecords.Columns["Id"].Visible = true;
            dgvRecords.Columns["$DATE"].Visible = true;
        }
        private void cbRecordFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbRecordFormat.SelectedIndex >= 0)
            {
                for (int i = 2; i < dgvRecords.Columns.Count; i++)
                {
                    dgvRecords.Columns[i].DefaultCellStyle.Format = cbRecordFormat.Text;
                }
                dgvRecords.Columns["$POS_ACT.S"].DefaultCellStyle.Format = "F0";
                dgvRecords.Columns["$POS_ACT.T"].DefaultCellStyle.Format = "F0";
            }

        }
        private void rblRecordHeader_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (rblRecordHeader.SelectedIndex)
            {
                case 0:
                    dgvRecords.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
                    break;

                case 1:
                    dgvRecords.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
                    break;
            }
        }
        #endregion

        #region Write
        private async void btWrite_Click(object sender, EventArgs e)
        {
            var varName = scbWrite.Text;
            var varValue = tbVarValue.Text;

            if (varName == "")
            {
                MessageBox.Show("Please, enter a variable name.");
                return;
            }

            if (varValue == "")
            {
                MessageBox.Show("Please, enter a variable value.");
                return;
            }

            await client.SendAsync(KVPWriteQuery.Build(1, varName, varValue), async (reply) =>
            {
                this.BeginInvoke((Action)delegate ()
                {
                    lbWriteStatus.Text = "Write status : " + (reply.Answer.Successful ? "ok" : "error");
                    if (!reply.Answer.Successful) return;

                    var ast = reply.Answer.GetAST();
                    ast.Name = ((KVPWriteQuery)reply.Query).VarName;
                    lbWriteElapsed.Text = "elapsed time : " + Math.Round(reply.RoundTripTime.TotalMilliseconds, 1) + "ms";
                    
                });
            });

            // update combobox history
            if (varName != "")
            {
                // removes other occurence
                // ensure unique varnames in list and last occurence goes on top of the list
                settings.WriteHistory.RemoveAll(s => s.VarName.Equals(varName, StringComparison.OrdinalIgnoreCase));
                settings.WriteHistory.Insert(0, new WriteVariable() { VarName = varName, VarValue = varValue });

                if (settings.WriteHistory.Count == readHistoryMaxCount) settings.WriteHistory.RemoveAt(scbWrite.Items.Count - 1);

                // rebind the source to update the control
                scbWrite.DataSource = new BindingSource(settings.WriteHistory, null);
                settings.Save();
            }
        }
        #endregion

        private void label24_Click(object sender, EventArgs e)
        {

        }


        private void textBoxFilterData_TextChanged(object sender, EventArgs e)
        {
            TimedFilter(objectListView, ((TextBox)sender).Text);
        }

        private void btIO_Remove_Click(object sender, EventArgs e)
        {
            var index = objectListView.SelectedIndex;
            if (index > -1)
            {
                objectListView.Items.RemoveAt(index);
            }
        }

        private void btIO_Add_Click(object sender, EventArgs e)
        {
            var dr = dtio.NewRow();
            dr["Name"] = "KrlName";
            dr["Tag"] = "Insert your description";
            dr["Group"] = "New";
            dr["Value"] = "";
            dr["Type"] = "";

            dtio.Rows.Add(dr);
        }

        private void ckMonitor_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Control ctrl in tabPage4.Controls) ctrl.Enabled = !ctrl.Enabled;
            if (ckMonitor.Checked)
            {
                // start monitoring
                ckMonitor.Text = "Monitoring : STOP";
                monitoringTimer.Change(TimeSpan.FromMilliseconds(0), TimeSpan.FromMilliseconds(monitoRefreshRate));
                ioTimer.Change(TimeSpan.FromMilliseconds(0), TimeSpan.FromMilliseconds(monitoRefreshRate));
            }
            else
            {
                // stop monitoring
                ckMonitor.Text = "Monitoring : START";
                monitoringTimer.Change(Timeout.Infinite, Timeout.Infinite);
                ioTimer.Change(Timeout.Infinite, Timeout.Infinite);
            }
        }

        private string FormatNumber(string format, double? number, int length = 6)
        {
            if (number.HasValue)
            {
                var str = string.Format(format, number);
                //return str;
                int pos = str.IndexOf(',');
                if (pos == -1)
                    pos = str.Length;
                return new String(' ', length - pos) + str;
            }
            else
            {
                return "";
            }
        }
    }
}
