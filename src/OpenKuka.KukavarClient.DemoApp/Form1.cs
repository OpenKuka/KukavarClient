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

namespace Kukavar.DemoApp
{
    public partial class Form1 : Form
    {
        internal AppSettings settings = JsonSettings.Load<AppSettings>();

        private const int readHistoryMaxCount = 30;
        private const int readTemplatesMaxCount = 10;

        private KukavarClient client;
        public ConcurrentQueue<KVCommunication> CommunicationGroup;
        public ConcurrentQueue<int> CommunicationGroupIds;

        private Stopwatch chrono = new Stopwatch();

        public Form1()
        {
            InitializeComponent();

            // Load Settings
            settings.ReadHistory = settings.ReadHistory ?? new List<string>();
            scbRead.DataSource = settings.ReadHistory;
            scbRead.SelectedIndex = -1;

            settings.ReadTemplateList = settings.ReadTemplateList ?? new Dictionary<string, List<String>>();
            RefreshTemplateCombobox();

            tbServerIP.Text = settings.ServerIP ?? "127.0.0.1";
            tbServerPort.Text = settings.ServerPort.ToString();
            tbMaxIdleTime.Text = settings.MaxIdleTime.ToString();
            tbReconnectionTO.Text = settings.ReconnectionTimeout.ToString();
            ckAutoReconnect.Checked = settings.AutoReconnect;

            // Init Tree
            InitTree();

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

            CommunicationGroup = new ConcurrentQueue<KVCommunication>();
            CommunicationGroupIds = new ConcurrentQueue<int>();

            client.KVAnswerReceivedCallback = async (com) =>
            {
                if (CommunicationGroupIds.Any(id => id == com.Answer.Id))
                {
                    // a group of request is pending so we stack the answers in a group
                    CommunicationGroup.Enqueue(com);
                    int id;
                    if (CommunicationGroupIds.TryDequeue(out id))
                    {
                        Debug.WriteLine("CommunicationGroupIds.Dequeue : " + id);
                    }
                    else
                    {
                        throw new Exception("Dequeue failed");
                    }
                }
                else
                {
                    // this is a single request
                    this.BeginInvoke((Action)delegate ()
                    {
                        //code to update UI
                        if (com.Answer.Successful)
                        {
                            var mode = com.Query.Mode;
                            switch (mode)
                            {
                                case RWMode.READ:
                                    var readQuery = (KVReadQuery)com.Query;
                                    if (readQuery.VarName == "$MODEL_NAME[]")
                                    {
                                        var name = com.Answer.VarValue;
                                        tbRobName.Text = name.Substring(1, name.Length - 2); 
                                    }
                                    else if (readQuery.VarName == "$V_ROBCOR[]")
                                    {
                                        var name = com.Answer.VarValue;
                                        tbRobVersion.Text = name.Substring(1, name.Length - 2);
                                    }
                                    else if (readQuery.VarName == "$ROBRUNTIME")
                                    {
                                        var min = int.Parse(com.Answer.VarValue);
                                        tbRobHours.Text = string.Format("{0}:{1:00}", min / 60, min % 60);
                                    }
                                    else
                                    {
                                        var ast = com.Answer.GetAST();
                                        ast.Name = readQuery.VarName;
                                        SetReadElapsedTime(com.RoundTripTime.TotalMilliseconds);
                                        FillTree(ast);
                                    }    
                                    break;

                                case RWMode.WRITE:
                                    break;

                                case RWMode.UNDEF:
                                    break;

                                default:
                                    break;
                            }
                            
                        }
                        else
                        {
                            treeListView.ClearObjects();
                            MessageBox.Show("Invalid answer : " + com.Answer.ToString());
                        }
                    });
                }
            };
        }

        #region Connection
        private async void btStart_Click(object sender, EventArgs e)
        {
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
        private void btStop_Click(object sender, EventArgs e)
        {
            client.Close();
            grpCSettings.Enabled = true;

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
                lbConnectionStatus.BackColor = Color.Green;
                tabControl1.Enabled = true;

                client.SendAsync(KVReadQuery.Build(0, "$MODEL_NAME[]"));
                client.SendAsync(KVReadQuery.Build(0, "$V_ROBCOR[]"));
                client.SendAsync(KVReadQuery.Build(0, "$ROBRUNTIME"));

            });
            return Task.CompletedTask;
        }
        private Task ConnectionErrorHandler(object sender, ConnectionErrorEventArgs e)
        {
            this.BeginInvoke((Action)delegate ()
            {
                //code to update UI
                lbConnectionStatus.Text = "disconnected";
                lbConnectionStatus.BackColor = Color.Red;
                tabControl1.Enabled = false;
            });
            return Task.CompletedTask;
        }
        private Task ClosingErrorHandler(object sender, ClosingEventArgs e)
        {
            this.BeginInvoke((Action)delegate ()
            {
                //code to update UI
                lbConnectionStatus.Text = "closing...";
                lbConnectionStatus.BackColor = Color.Yellow;
                tabControl1.Enabled = false;
            });
            return Task.CompletedTask;
        }
        private Task ClosedErrorHandler(object sender, EventArgs e)
        {
            this.BeginInvoke((Action)delegate ()
            {
                //code to update UI
                lbConnectionStatus.Text = "closed";
                lbConnectionStatus.BackColor = Color.Gray;
                tabControl1.Enabled = false;
            });
            return Task.CompletedTask;
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
        private void FillTree(IEnumerable<Data> dataList)
        {
            // set the tree roots
            treeListView.ClearObjects();
            this.treeListView.Roots = dataList;
            treeListView.ExpandAll();
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
            await client.SendAsync(KVReadQuery.Build(1, varName));

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
        #endregion

        #region Read template
        private async void btReadTemplate_Click(object sender, EventArgs e)
        {
            if (CommunicationGroupIds.Count == 0)
            {
                chrono.Restart();
                btReadTemplate.Enabled = false;
                var queries = lstbRead.Items.OfType<string>().Select(name => KVReadQuery.Build(1, name));

                // send all queries
                var sendQueries = Task.Run(async () =>
                {
                    foreach (var query in queries)
                    {
                        var id = await client.SendAsync(query);
                        CommunicationGroupIds.Enqueue(id);
                        Debug.WriteLine("CommunicationGroupIds.Enqueue : " + id);
                    }
                });

                sendQueries.Wait();

                var waitError = false;
                var waitAnswers = Task.Run(() =>
                {
                    var timeout = new Stopwatch();
                    timeout.Start();
                    while (CommunicationGroupIds.Count > 0)
                    {
                        Task.Delay(1);
                        if (timeout.ElapsedMilliseconds > 2000)
                        {
                            waitError = true;
                            break;
                        }
                    }
                });
               
                waitAnswers.Wait();

                if (!waitError)
                {
                    chrono.Stop();
                    SetReadElapsedTime((double)chrono.ElapsedMilliseconds);
                    Debug.WriteLine("CommunicationGroup.Count = " + CommunicationGroup.Count);

                    treeListView.ClearObjects();

                    var dataList = new List<Data>();
                    while (!CommunicationGroup.IsEmpty)
                    {
                        KVCommunication com;
                        if (CommunicationGroup.TryDequeue(out com))
                        {
                            if (com.Answer.Successful)
                            {
                                var ast = com.Answer.GetAST();
                                ast.Name = ((KVReadQuery)com.Query).VarName;
                                dataList.Add(ast);
                            }
                        }
                        else
                        {
                            Debug.WriteLine("CommunicationGroup.TryDequeue : false");
                        }
                    }

                    FillTree(dataList);
                    treeListView.CollapseAll();
                    btReadTemplate.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Read template aborted (timeout)");
                    while (!CommunicationGroup.IsEmpty)
                    {
                        KVCommunication com;
                        CommunicationGroup.TryDequeue(out com);
                    }
                    while (!CommunicationGroupIds.IsEmpty)
                    {
                        int id;
                        CommunicationGroupIds.TryDequeue(out id);
                    }
                }
            }
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

        
        

        private void SetReadElapsedTime(double time)
        {
            lbReadTime.Text = "elapsed time : " + Math.Round(time, 1) + "ms";
        }
    }
}
