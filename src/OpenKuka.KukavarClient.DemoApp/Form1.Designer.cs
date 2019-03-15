namespace Kukavar.DemoApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tbServerIP = new System.Windows.Forms.TextBox();
            this.tbServerPort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.grpCSettings = new System.Windows.Forms.GroupBox();
            this.ckAutoReconnect = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbReconnectionTO = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbMaxIdleTime = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lbConnectionStatus = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lbReadTime = new System.Windows.Forms.Label();
            this.btExpandAll = new System.Windows.Forms.Button();
            this.btCollapseAll = new System.Windows.Forms.Button();
            this.btRemoveHistory = new System.Windows.Forms.Button();
            this.btReadTemplate = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.tbTemplateName = new System.Windows.Forms.TextBox();
            this.btEditTemplateName = new System.Windows.Forms.Button();
            this.cbTemplate = new System.Windows.Forms.ComboBox();
            this.btAddReadTemplate = new System.Windows.Forms.Button();
            this.lstbRead = new System.Windows.Forms.ListBox();
            this.btRemoveReadTemplate = new System.Windows.Forms.Button();
            this.btUp = new System.Windows.Forms.Button();
            this.btAddTemplateVar = new System.Windows.Forms.Button();
            this.btRemoveTemplateVar = new System.Windows.Forms.Button();
            this.btDown = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.scbRead = new AutoCompleteComboBox.SuggestComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btReadSingle = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.treeListView = new BrightIdeasSoftware.TreeListView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lbWriteStatus = new System.Windows.Forms.Label();
            this.lbWriteElapsed = new System.Windows.Forms.Label();
            this.tbVarValue = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.btWrite = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.scbWrite = new AutoCompleteComboBox.SuggestComboBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.rblRecordHeader = new EWSoftware.ListControls.RadioButtonList();
            this.label18 = new System.Windows.Forms.Label();
            this.cbRecordFormat = new EWSoftware.ListControls.AutoCompleteComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.rblRecordFilter = new EWSoftware.ListControls.RadioButtonList();
            this.label14 = new System.Windows.Forms.Label();
            this.dgvRecords = new System.Windows.Forms.DataGridView();
            this.btRecordReset = new System.Windows.Forms.Button();
            this.btRemoveRecord = new System.Windows.Forms.Button();
            this.btAddRecord = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.lbMonitoRate = new System.Windows.Forms.Label();
            this.lbMonitoTime = new System.Windows.Forms.Label();
            this.grp_TOOL = new System.Windows.Forms.GroupBox();
            this.lb_TC = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.label61 = new System.Windows.Forms.Label();
            this.lb_TZ = new System.Windows.Forms.Label();
            this.lb_TY = new System.Windows.Forms.Label();
            this.lb_TB = new System.Windows.Forms.Label();
            this.label67 = new System.Windows.Forms.Label();
            this.lb_TX = new System.Windows.Forms.Label();
            this.label69 = new System.Windows.Forms.Label();
            this.label71 = new System.Windows.Forms.Label();
            this.lb_TA = new System.Windows.Forms.Label();
            this.grp_BASE = new System.Windows.Forms.GroupBox();
            this.lb_BC = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.lb_BZ = new System.Windows.Forms.Label();
            this.lb_BY = new System.Windows.Forms.Label();
            this.lb_BB = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.lb_BX = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.lb_BA = new System.Windows.Forms.Label();
            this.grp_ACC = new System.Windows.Forms.GroupBox();
            this.lb_AccORI2 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.lb_AccORI1 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.lb_AccCP = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.grp_VEL = new System.Windows.Forms.GroupBox();
            this.label62 = new System.Windows.Forms.Label();
            this.lb_VelORI2 = new System.Windows.Forms.Label();
            this.label63 = new System.Windows.Forms.Label();
            this.lb_VelORI1 = new System.Windows.Forms.Label();
            this.label70 = new System.Windows.Forms.Label();
            this.lb_VelCP = new System.Windows.Forms.Label();
            this.grp_EXT = new System.Windows.Forms.GroupBox();
            this.lb_E6 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.lb_E3 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.lb_E2 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.lb_E5 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.lb_E1 = new System.Windows.Forms.Label();
            this.lb_E4 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.grp_AXIS = new System.Windows.Forms.GroupBox();
            this.lb_A6 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.lb_A3 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.lb_A2 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.lb_A5 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.lb_A1 = new System.Windows.Forms.Label();
            this.lb_A4 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.grp_TCP = new System.Windows.Forms.GroupBox();
            this.lb_OV = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.lb_S = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.lb_T = new System.Windows.Forms.Label();
            this.label65 = new System.Windows.Forms.Label();
            this.lb_C = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.lb_Z = new System.Windows.Forms.Label();
            this.lb_Y = new System.Windows.Forms.Label();
            this.lb_B = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.lb_X = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.lb_A = new System.Windows.Forms.Label();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.label48 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.tbIOSearch = new System.Windows.Forms.TextBox();
            this.objectListView = new BrightIdeasSoftware.DataListView();
            this.olvColTag = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColValue = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColFiller = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColGroup = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColType = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.cb_IOGroup = new System.Windows.Forms.ComboBox();
            this.btIOGrpDelete = new System.Windows.Forms.Button();
            this.btIO_Add = new System.Windows.Forms.Button();
            this.btIO_Remove = new System.Windows.Forms.Button();
            this.label35 = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbModeOP = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.lbProName1 = new System.Windows.Forms.Label();
            this.lbProState1 = new System.Windows.Forms.Label();
            this.lbProState0 = new System.Windows.Forms.Label();
            this.lbProName0 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.tbRobVersion = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tbRobHours = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbRobName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ckMonitor = new System.Windows.Forms.CheckBox();
            this.ckConnect = new System.Windows.Forms.CheckBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.grpCSettings.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListView)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rblRecordHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rblRecordFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecords)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.grp_TOOL.SuspendLayout();
            this.grp_BASE.SuspendLayout();
            this.grp_ACC.SuspendLayout();
            this.grp_VEL.SuspendLayout();
            this.grp_EXT.SuspendLayout();
            this.grp_AXIS.SuspendLayout();
            this.grp_TCP.SuspendLayout();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objectListView)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbServerIP
            // 
            this.tbServerIP.Location = new System.Drawing.Point(107, 28);
            this.tbServerIP.Name = "tbServerIP";
            this.tbServerIP.Size = new System.Drawing.Size(97, 20);
            this.tbServerIP.TabIndex = 0;
            this.tbServerIP.Text = "192.168.10.4";
            // 
            // tbServerPort
            // 
            this.tbServerPort.Location = new System.Drawing.Point(107, 54);
            this.tbServerPort.Name = "tbServerPort";
            this.tbServerPort.Size = new System.Drawing.Size(97, 20);
            this.tbServerPort.TabIndex = 1;
            this.tbServerPort.Text = "7000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "IP Address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Port";
            // 
            // grpCSettings
            // 
            this.grpCSettings.Controls.Add(this.ckAutoReconnect);
            this.grpCSettings.Controls.Add(this.label5);
            this.grpCSettings.Controls.Add(this.tbReconnectionTO);
            this.grpCSettings.Controls.Add(this.label4);
            this.grpCSettings.Controls.Add(this.label3);
            this.grpCSettings.Controls.Add(this.tbMaxIdleTime);
            this.grpCSettings.Controls.Add(this.label1);
            this.grpCSettings.Controls.Add(this.tbServerIP);
            this.grpCSettings.Controls.Add(this.label2);
            this.grpCSettings.Controls.Add(this.tbServerPort);
            this.grpCSettings.Location = new System.Drawing.Point(217, 12);
            this.grpCSettings.Name = "grpCSettings";
            this.grpCSettings.Size = new System.Drawing.Size(214, 193);
            this.grpCSettings.TabIndex = 5;
            this.grpCSettings.TabStop = false;
            this.grpCSettings.Text = "Connection Settings";
            // 
            // ckAutoReconnect
            // 
            this.ckAutoReconnect.AutoSize = true;
            this.ckAutoReconnect.Location = new System.Drawing.Point(189, 161);
            this.ckAutoReconnect.Name = "ckAutoReconnect";
            this.ckAutoReconnect.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ckAutoReconnect.Size = new System.Drawing.Size(15, 14);
            this.ckAutoReconnect.TabIndex = 8;
            this.ckAutoReconnect.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckAutoReconnect.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Auto Reconnect";
            // 
            // tbReconnectionTO
            // 
            this.tbReconnectionTO.Location = new System.Drawing.Point(154, 133);
            this.tbReconnectionTO.Name = "tbReconnectionTO";
            this.tbReconnectionTO.Size = new System.Drawing.Size(50, 20);
            this.tbReconnectionTO.TabIndex = 7;
            this.tbReconnectionTO.Text = "600";
            this.tbReconnectionTO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Reconnection Timeout (s)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Max Idle Time (s)";
            // 
            // tbMaxIdleTime
            // 
            this.tbMaxIdleTime.Location = new System.Drawing.Point(154, 107);
            this.tbMaxIdleTime.Name = "tbMaxIdleTime";
            this.tbMaxIdleTime.Size = new System.Drawing.Size(50, 20);
            this.tbMaxIdleTime.TabIndex = 4;
            this.tbMaxIdleTime.Text = "2";
            this.tbMaxIdleTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Connection Status :";
            // 
            // lbConnectionStatus
            // 
            this.lbConnectionStatus.BackColor = System.Drawing.Color.LightGray;
            this.lbConnectionStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbConnectionStatus.Location = new System.Drawing.Point(9, 162);
            this.lbConnectionStatus.Name = "lbConnectionStatus";
            this.lbConnectionStatus.Size = new System.Drawing.Size(160, 13);
            this.lbConnectionStatus.TabIndex = 11;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(12, 216);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(695, 419);
            this.tabControl1.TabIndex = 13;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lbReadTime);
            this.tabPage1.Controls.Add(this.btExpandAll);
            this.tabPage1.Controls.Add(this.btCollapseAll);
            this.tabPage1.Controls.Add(this.btRemoveHistory);
            this.tabPage1.Controls.Add(this.btReadTemplate);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.tbTemplateName);
            this.tabPage1.Controls.Add(this.btEditTemplateName);
            this.tabPage1.Controls.Add(this.cbTemplate);
            this.tabPage1.Controls.Add(this.btAddReadTemplate);
            this.tabPage1.Controls.Add(this.lstbRead);
            this.tabPage1.Controls.Add(this.btRemoveReadTemplate);
            this.tabPage1.Controls.Add(this.btUp);
            this.tabPage1.Controls.Add(this.btAddTemplateVar);
            this.tabPage1.Controls.Add(this.btRemoveTemplateVar);
            this.tabPage1.Controls.Add(this.btDown);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.scbRead);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.btReadSingle);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.treeListView);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(687, 393);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Read Variables";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lbReadTime
            // 
            this.lbReadTime.Location = new System.Drawing.Point(372, 363);
            this.lbReadTime.Name = "lbReadTime";
            this.lbReadTime.Size = new System.Drawing.Size(297, 13);
            this.lbReadTime.TabIndex = 50;
            this.lbReadTime.Text = "elapsed time : ms";
            this.lbReadTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btExpandAll
            // 
            this.btExpandAll.Image = global::Kukavar.DemoApp.Properties.Resources.unfold;
            this.btExpandAll.Location = new System.Drawing.Point(615, 14);
            this.btExpandAll.Name = "btExpandAll";
            this.btExpandAll.Size = new System.Drawing.Size(24, 28);
            this.btExpandAll.TabIndex = 49;
            this.toolTip.SetToolTip(this.btExpandAll, "Expand All");
            this.btExpandAll.UseVisualStyleBackColor = true;
            this.btExpandAll.Click += new System.EventHandler(this.btExpandAll_Click);
            // 
            // btCollapseAll
            // 
            this.btCollapseAll.Image = global::Kukavar.DemoApp.Properties.Resources.fold;
            this.btCollapseAll.Location = new System.Drawing.Point(645, 14);
            this.btCollapseAll.Name = "btCollapseAll";
            this.btCollapseAll.Size = new System.Drawing.Size(24, 28);
            this.btCollapseAll.TabIndex = 48;
            this.toolTip.SetToolTip(this.btCollapseAll, "Collapse All");
            this.btCollapseAll.UseVisualStyleBackColor = true;
            this.btCollapseAll.Click += new System.EventHandler(this.btCollapseAll_Click);
            // 
            // btRemoveHistory
            // 
            this.btRemoveHistory.Image = global::Kukavar.DemoApp.Properties.Resources.remove;
            this.btRemoveHistory.Location = new System.Drawing.Point(171, 48);
            this.btRemoveHistory.Name = "btRemoveHistory";
            this.btRemoveHistory.Size = new System.Drawing.Size(24, 24);
            this.btRemoveHistory.TabIndex = 46;
            this.btRemoveHistory.Text = " ";
            this.toolTip.SetToolTip(this.btRemoveHistory, "Remove selected item from history");
            this.btRemoveHistory.UseVisualStyleBackColor = true;
            this.btRemoveHistory.Click += new System.EventHandler(this.btRemoveHistory_Click);
            // 
            // btReadTemplate
            // 
            this.btReadTemplate.Location = new System.Drawing.Point(262, 117);
            this.btReadTemplate.Name = "btReadTemplate";
            this.btReadTemplate.Size = new System.Drawing.Size(75, 24);
            this.btReadTemplate.TabIndex = 44;
            this.btReadTemplate.Text = "Read >>";
            this.toolTip.SetToolTip(this.btReadTemplate, "Read the variables in the selected template");
            this.btReadTemplate.UseVisualStyleBackColor = true;
            this.btReadTemplate.Click += new System.EventHandler(this.btReadTemplate_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 149);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(97, 13);
            this.label10.TabIndex = 38;
            this.label10.Text = "Edit template name";
            // 
            // tbTemplateName
            // 
            this.tbTemplateName.Enabled = false;
            this.tbTemplateName.Location = new System.Drawing.Point(15, 165);
            this.tbTemplateName.Name = "tbTemplateName";
            this.tbTemplateName.Size = new System.Drawing.Size(150, 20);
            this.tbTemplateName.TabIndex = 37;
            this.tbTemplateName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbTemplateName_KeyPress);
            this.tbTemplateName.Validating += new System.ComponentModel.CancelEventHandler(this.tbTemplateName_Validating);
            // 
            // btEditTemplateName
            // 
            this.btEditTemplateName.CausesValidation = false;
            this.btEditTemplateName.Image = global::Kukavar.DemoApp.Properties.Resources.edit;
            this.btEditTemplateName.Location = new System.Drawing.Point(171, 163);
            this.btEditTemplateName.Name = "btEditTemplateName";
            this.btEditTemplateName.Size = new System.Drawing.Size(24, 24);
            this.btEditTemplateName.TabIndex = 36;
            this.btEditTemplateName.Text = " ";
            this.toolTip.SetToolTip(this.btEditTemplateName, "Edit template name");
            this.btEditTemplateName.UseVisualStyleBackColor = true;
            this.btEditTemplateName.Click += new System.EventHandler(this.btEditTemplateName_Click);
            // 
            // cbTemplate
            // 
            this.cbTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTemplate.FormattingEnabled = true;
            this.cbTemplate.Location = new System.Drawing.Point(15, 118);
            this.cbTemplate.Name = "cbTemplate";
            this.cbTemplate.Size = new System.Drawing.Size(150, 21);
            this.cbTemplate.TabIndex = 35;
            this.cbTemplate.SelectedIndexChanged += new System.EventHandler(this.cbTemplate_SelectedIndexChanged);
            // 
            // btAddReadTemplate
            // 
            this.btAddReadTemplate.Image = global::Kukavar.DemoApp.Properties.Resources.addfilled;
            this.btAddReadTemplate.Location = new System.Drawing.Point(172, 117);
            this.btAddReadTemplate.Name = "btAddReadTemplate";
            this.btAddReadTemplate.Size = new System.Drawing.Size(24, 24);
            this.btAddReadTemplate.TabIndex = 34;
            this.btAddReadTemplate.Text = " ";
            this.toolTip.SetToolTip(this.btAddReadTemplate, "Add a new template");
            this.btAddReadTemplate.UseVisualStyleBackColor = true;
            this.btAddReadTemplate.Click += new System.EventHandler(this.btAddReadTemplate_Click);
            // 
            // lstbRead
            // 
            this.lstbRead.FormattingEnabled = true;
            this.lstbRead.Location = new System.Drawing.Point(15, 213);
            this.lstbRead.Name = "lstbRead";
            this.lstbRead.Size = new System.Drawing.Size(150, 147);
            this.lstbRead.TabIndex = 33;
            // 
            // btRemoveReadTemplate
            // 
            this.btRemoveReadTemplate.Image = global::Kukavar.DemoApp.Properties.Resources.delete;
            this.btRemoveReadTemplate.Location = new System.Drawing.Point(198, 117);
            this.btRemoveReadTemplate.Name = "btRemoveReadTemplate";
            this.btRemoveReadTemplate.Size = new System.Drawing.Size(24, 24);
            this.btRemoveReadTemplate.TabIndex = 31;
            this.btRemoveReadTemplate.Text = " ";
            this.toolTip.SetToolTip(this.btRemoveReadTemplate, "Delete the selected template");
            this.btRemoveReadTemplate.UseVisualStyleBackColor = true;
            this.btRemoveReadTemplate.Click += new System.EventHandler(this.btRemoveReadTemplate_Click);
            // 
            // btUp
            // 
            this.btUp.Image = global::Kukavar.DemoApp.Properties.Resources.up;
            this.btUp.Location = new System.Drawing.Point(171, 213);
            this.btUp.Name = "btUp";
            this.btUp.Size = new System.Drawing.Size(24, 24);
            this.btUp.TabIndex = 30;
            this.toolTip.SetToolTip(this.btUp, "Move item Up");
            this.btUp.UseVisualStyleBackColor = true;
            this.btUp.Click += new System.EventHandler(this.btUp_Click);
            // 
            // btAddTemplateVar
            // 
            this.btAddTemplateVar.Image = global::Kukavar.DemoApp.Properties.Resources.add;
            this.btAddTemplateVar.Location = new System.Drawing.Point(171, 306);
            this.btAddTemplateVar.Name = "btAddTemplateVar";
            this.btAddTemplateVar.Size = new System.Drawing.Size(24, 24);
            this.btAddTemplateVar.TabIndex = 29;
            this.btAddTemplateVar.Text = " ";
            this.toolTip.SetToolTip(this.btAddTemplateVar, "Add the variable to the list");
            this.btAddTemplateVar.UseVisualStyleBackColor = true;
            this.btAddTemplateVar.Click += new System.EventHandler(this.btAddTemplateVar_Click);
            // 
            // btRemoveTemplateVar
            // 
            this.btRemoveTemplateVar.Image = global::Kukavar.DemoApp.Properties.Resources.remove;
            this.btRemoveTemplateVar.Location = new System.Drawing.Point(171, 336);
            this.btRemoveTemplateVar.Name = "btRemoveTemplateVar";
            this.btRemoveTemplateVar.Size = new System.Drawing.Size(24, 24);
            this.btRemoveTemplateVar.TabIndex = 28;
            this.btRemoveTemplateVar.Text = " ";
            this.toolTip.SetToolTip(this.btRemoveTemplateVar, "Remove the selected item from the variable list");
            this.btRemoveTemplateVar.UseVisualStyleBackColor = true;
            this.btRemoveTemplateVar.Click += new System.EventHandler(this.btRemoveTemplateVar_Click);
            // 
            // btDown
            // 
            this.btDown.Image = global::Kukavar.DemoApp.Properties.Resources.down;
            this.btDown.Location = new System.Drawing.Point(171, 243);
            this.btDown.Name = "btDown";
            this.btDown.Size = new System.Drawing.Size(24, 24);
            this.btDown.TabIndex = 25;
            this.toolTip.SetToolTip(this.btDown, "Move item Down");
            this.btDown.UseVisualStyleBackColor = true;
            this.btDown.Click += new System.EventHandler(this.btDown_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 102);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Select a template";
            // 
            // scbRead
            // 
            this.scbRead.FilterRule = null;
            this.scbRead.FormattingEnabled = true;
            this.scbRead.Location = new System.Drawing.Point(15, 50);
            this.scbRead.Name = "scbRead";
            this.scbRead.PropertySelector = null;
            this.scbRead.Size = new System.Drawing.Size(150, 21);
            this.scbRead.SuggestBoxHeight = 96;
            this.scbRead.SuggestListOrderRule = null;
            this.scbRead.TabIndex = 20;
            this.scbRead.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.scbRead_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 197);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(139, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Template variables (max 10)";
            // 
            // btReadSingle
            // 
            this.btReadSingle.Location = new System.Drawing.Point(262, 48);
            this.btReadSingle.Name = "btReadSingle";
            this.btReadSingle.Size = new System.Drawing.Size(75, 24);
            this.btReadSingle.TabIndex = 12;
            this.btReadSingle.Text = "Read >>";
            this.toolTip.SetToolTip(this.btReadSingle, "Read a single variable");
            this.btReadSingle.UseVisualStyleBackColor = true;
            this.btReadSingle.Click += new System.EventHandler(this.btReadSingle_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Variable name";
            // 
            // treeListView
            // 
            this.treeListView.CellEditUseWholeCell = false;
            this.treeListView.Location = new System.Drawing.Point(372, 48);
            this.treeListView.Name = "treeListView";
            this.treeListView.ShowGroups = false;
            this.treeListView.Size = new System.Drawing.Size(297, 312);
            this.treeListView.TabIndex = 0;
            this.treeListView.UseCompatibleStateImageBehavior = false;
            this.treeListView.View = System.Windows.Forms.View.Details;
            this.treeListView.VirtualMode = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lbWriteStatus);
            this.tabPage2.Controls.Add(this.lbWriteElapsed);
            this.tabPage2.Controls.Add(this.tbVarValue);
            this.tabPage2.Controls.Add(this.label23);
            this.tabPage2.Controls.Add(this.btWrite);
            this.tabPage2.Controls.Add(this.label21);
            this.tabPage2.Controls.Add(this.scbWrite);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(687, 393);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Write Variables";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lbWriteStatus
            // 
            this.lbWriteStatus.AutoSize = true;
            this.lbWriteStatus.Location = new System.Drawing.Point(267, 82);
            this.lbWriteStatus.Name = "lbWriteStatus";
            this.lbWriteStatus.Size = new System.Drawing.Size(69, 13);
            this.lbWriteStatus.TabIndex = 52;
            this.lbWriteStatus.Text = "Write status :";
            this.lbWriteStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbWriteElapsed
            // 
            this.lbWriteElapsed.AutoSize = true;
            this.lbWriteElapsed.Location = new System.Drawing.Point(12, 363);
            this.lbWriteElapsed.Name = "lbWriteElapsed";
            this.lbWriteElapsed.Size = new System.Drawing.Size(88, 13);
            this.lbWriteElapsed.TabIndex = 51;
            this.lbWriteElapsed.Text = "elapsed time : ms";
            this.lbWriteElapsed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbVarValue
            // 
            this.tbVarValue.Location = new System.Drawing.Point(15, 98);
            this.tbVarValue.Name = "tbVarValue";
            this.tbVarValue.Size = new System.Drawing.Size(150, 20);
            this.tbVarValue.TabIndex = 41;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(12, 82);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(74, 13);
            this.label23.TabIndex = 40;
            this.label23.Text = "Variable value";
            // 
            // btWrite
            // 
            this.btWrite.Location = new System.Drawing.Point(262, 48);
            this.btWrite.Name = "btWrite";
            this.btWrite.Size = new System.Drawing.Size(75, 24);
            this.btWrite.TabIndex = 23;
            this.btWrite.Text = "Write >>";
            this.toolTip.SetToolTip(this.btWrite, "Read a single variable");
            this.btWrite.UseVisualStyleBackColor = true;
            this.btWrite.Click += new System.EventHandler(this.btWrite_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(12, 35);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(74, 13);
            this.label21.TabIndex = 22;
            this.label21.Text = "Variable name";
            // 
            // scbWrite
            // 
            this.scbWrite.DisplayMember = "VarName";
            this.scbWrite.FilterRule = null;
            this.scbWrite.FormattingEnabled = true;
            this.scbWrite.Location = new System.Drawing.Point(15, 50);
            this.scbWrite.Name = "scbWrite";
            this.scbWrite.PropertySelector = null;
            this.scbWrite.Size = new System.Drawing.Size(150, 21);
            this.scbWrite.SuggestBoxHeight = 96;
            this.scbWrite.SuggestListOrderRule = null;
            this.scbWrite.TabIndex = 24;
            this.scbWrite.ValueMember = "VarValue";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label19);
            this.tabPage3.Controls.Add(this.label20);
            this.tabPage3.Controls.Add(this.rblRecordHeader);
            this.tabPage3.Controls.Add(this.label18);
            this.tabPage3.Controls.Add(this.cbRecordFormat);
            this.tabPage3.Controls.Add(this.label17);
            this.tabPage3.Controls.Add(this.label16);
            this.tabPage3.Controls.Add(this.label15);
            this.tabPage3.Controls.Add(this.rblRecordFilter);
            this.tabPage3.Controls.Add(this.label14);
            this.tabPage3.Controls.Add(this.dgvRecords);
            this.tabPage3.Controls.Add(this.btRecordReset);
            this.tabPage3.Controls.Add(this.btRemoveRecord);
            this.tabPage3.Controls.Add(this.btAddRecord);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(687, 393);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Record Positions";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(97, 24);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(35, 13);
            this.label19.TabIndex = 64;
            this.label19.Text = "Reset";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(45, 24);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(23, 13);
            this.label20.TabIndex = 63;
            this.label20.Text = "Del";
            // 
            // rblRecordHeader
            // 
            this.rblRecordHeader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.rblRecordHeader.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.rblRecordHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rblRecordHeader.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.rblRecordHeader.LayoutMethod = EWSoftware.ListControls.LayoutMethod.SingleRow;
            this.rblRecordHeader.ListBackColor = System.Drawing.Color.Transparent;
            this.rblRecordHeader.Location = new System.Drawing.Point(584, 37);
            this.rblRecordHeader.Name = "rblRecordHeader";
            this.rblRecordHeader.Size = new System.Drawing.Size(97, 24);
            this.rblRecordHeader.TabIndex = 60;
            this.rblRecordHeader.TitleBorderColor = System.Drawing.Color.Transparent;
            this.rblRecordHeader.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.rblRecordHeader.TitleForeColor = System.Drawing.Color.Transparent;
            this.toolTip.SetToolTip(this.rblRecordHeader, "Do you want the table headers to be incuded when copying data to the clipboard ?");
            this.rblRecordHeader.SelectedIndexChanged += new System.EventHandler(this.rblRecordHeader_SelectedIndexChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(589, 24);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(89, 13);
            this.label18.TabIndex = 59;
            this.label18.Text = "Include headers :";
            // 
            // cbRecordFormat
            // 
            this.cbRecordFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRecordFormat.FormattingEnabled = true;
            this.cbRecordFormat.Items.AddRange(new object[] {
            "G",
            "F0",
            "F1",
            "F3",
            "F3",
            "F4",
            "F5",
            "F6"});
            this.cbRecordFormat.Location = new System.Drawing.Point(153, 41);
            this.cbRecordFormat.Name = "cbRecordFormat";
            this.cbRecordFormat.Size = new System.Drawing.Size(53, 21);
            this.cbRecordFormat.TabIndex = 58;
            this.toolTip.SetToolTip(this.cbRecordFormat, "Select a format for numbers.");
            this.cbRecordFormat.SelectedIndexChanged += new System.EventHandler(this.cbRecordFormat_SelectedIndexChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(150, 24);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(45, 13);
            this.label17.TabIndex = 57;
            this.label17.Text = "Format :";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(230, 24);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(35, 13);
            this.label16.TabIndex = 56;
            this.label16.Text = "Filter :";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 24);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(27, 13);
            this.label15.TabIndex = 55;
            this.label15.Text = "Rec";
            // 
            // rblRecordFilter
            // 
            this.rblRecordFilter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.rblRecordFilter.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.rblRecordFilter.DefaultSelection = 4;
            this.rblRecordFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rblRecordFilter.Items.AddRange(new object[] {
            "$POS_ACT",
            "$AXIS_ACT",
            "$BASE",
            "$TOOL",
            "ALL"});
            this.rblRecordFilter.LayoutMethod = EWSoftware.ListControls.LayoutMethod.SingleRow;
            this.rblRecordFilter.ListBackColor = System.Drawing.Color.Transparent;
            this.rblRecordFilter.Location = new System.Drawing.Point(226, 37);
            this.rblRecordFilter.Name = "rblRecordFilter";
            this.rblRecordFilter.Size = new System.Drawing.Size(345, 24);
            this.rblRecordFilter.TabIndex = 54;
            this.rblRecordFilter.TitleBorderColor = System.Drawing.Color.Transparent;
            this.rblRecordFilter.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.rblRecordFilter.TitleForeColor = System.Drawing.Color.Transparent;
            this.toolTip.SetToolTip(this.rblRecordFilter, "Choose a filter.");
            this.rblRecordFilter.SelectedIndexChanged += new System.EventHandler(this.rblRecordFilter_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(12, 361);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(414, 32);
            this.label14.TabIndex = 50;
            this.label14.Text = "Warning : do not use this for accurate recording when the robot is moving. \r\nFor " +
    "each record, several requests are sent to the robot and there will be some laten" +
    "cy between them.\r\n";
            // 
            // dgvRecords
            // 
            this.dgvRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecords.Location = new System.Drawing.Point(15, 70);
            this.dgvRecords.Name = "dgvRecords";
            this.dgvRecords.ReadOnly = true;
            this.dgvRecords.Size = new System.Drawing.Size(666, 288);
            this.dgvRecords.TabIndex = 0;
            // 
            // btRecordReset
            // 
            this.btRecordReset.Image = global::Kukavar.DemoApp.Properties.Resources.delete;
            this.btRecordReset.Location = new System.Drawing.Point(100, 40);
            this.btRecordReset.Name = "btRecordReset";
            this.btRecordReset.Size = new System.Drawing.Size(24, 24);
            this.btRecordReset.TabIndex = 61;
            this.btRecordReset.Text = " ";
            this.toolTip.SetToolTip(this.btRecordReset, "Reset the recorder. Delete all records.");
            this.btRecordReset.UseVisualStyleBackColor = true;
            this.btRecordReset.Click += new System.EventHandler(this.btRecordReset_Click);
            // 
            // btRemoveRecord
            // 
            this.btRemoveRecord.Image = global::Kukavar.DemoApp.Properties.Resources.clear;
            this.btRemoveRecord.Location = new System.Drawing.Point(44, 40);
            this.btRemoveRecord.Name = "btRemoveRecord";
            this.btRemoveRecord.Size = new System.Drawing.Size(24, 24);
            this.btRemoveRecord.TabIndex = 48;
            this.btRemoveRecord.Text = " ";
            this.toolTip.SetToolTip(this.btRemoveRecord, "Remove the selected records from the table.");
            this.btRemoveRecord.UseVisualStyleBackColor = true;
            this.btRemoveRecord.Click += new System.EventHandler(this.btRemoveRecord_Click);
            // 
            // btAddRecord
            // 
            this.btAddRecord.Image = global::Kukavar.DemoApp.Properties.Resources.record;
            this.btAddRecord.Location = new System.Drawing.Point(14, 40);
            this.btAddRecord.Name = "btAddRecord";
            this.btAddRecord.Size = new System.Drawing.Size(24, 24);
            this.btAddRecord.TabIndex = 47;
            this.btAddRecord.Text = " ";
            this.toolTip.SetToolTip(this.btAddRecord, "Record the current position of the robot.");
            this.btAddRecord.UseVisualStyleBackColor = true;
            this.btAddRecord.Click += new System.EventHandler(this.btAddRecord_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.lbMonitoRate);
            this.tabPage4.Controls.Add(this.lbMonitoTime);
            this.tabPage4.Controls.Add(this.grp_TOOL);
            this.tabPage4.Controls.Add(this.grp_BASE);
            this.tabPage4.Controls.Add(this.grp_ACC);
            this.tabPage4.Controls.Add(this.grp_VEL);
            this.tabPage4.Controls.Add(this.grp_EXT);
            this.tabPage4.Controls.Add(this.grp_AXIS);
            this.tabPage4.Controls.Add(this.grp_TCP);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(687, 393);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Monitoring ROB";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // lbMonitoRate
            // 
            this.lbMonitoRate.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMonitoRate.Location = new System.Drawing.Point(499, 326);
            this.lbMonitoRate.Name = "lbMonitoRate";
            this.lbMonitoRate.Size = new System.Drawing.Size(163, 13);
            this.lbMonitoRate.TabIndex = 52;
            this.lbMonitoRate.Text = "refresh rate :      ms";
            this.lbMonitoRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbMonitoTime
            // 
            this.lbMonitoTime.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMonitoTime.Location = new System.Drawing.Point(499, 339);
            this.lbMonitoTime.Name = "lbMonitoTime";
            this.lbMonitoTime.Size = new System.Drawing.Size(163, 13);
            this.lbMonitoTime.TabIndex = 51;
            this.lbMonitoTime.Text = "elapsed time :      ms";
            this.lbMonitoTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grp_TOOL
            // 
            this.grp_TOOL.Controls.Add(this.lb_TC);
            this.grp_TOOL.Controls.Add(this.label57);
            this.grp_TOOL.Controls.Add(this.label60);
            this.grp_TOOL.Controls.Add(this.label61);
            this.grp_TOOL.Controls.Add(this.lb_TZ);
            this.grp_TOOL.Controls.Add(this.lb_TY);
            this.grp_TOOL.Controls.Add(this.lb_TB);
            this.grp_TOOL.Controls.Add(this.label67);
            this.grp_TOOL.Controls.Add(this.lb_TX);
            this.grp_TOOL.Controls.Add(this.label69);
            this.grp_TOOL.Controls.Add(this.label71);
            this.grp_TOOL.Controls.Add(this.lb_TA);
            this.grp_TOOL.Enabled = false;
            this.grp_TOOL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.grp_TOOL.Location = new System.Drawing.Point(521, 38);
            this.grp_TOOL.Margin = new System.Windows.Forms.Padding(5);
            this.grp_TOOL.Name = "grp_TOOL";
            this.grp_TOOL.Padding = new System.Windows.Forms.Padding(5);
            this.grp_TOOL.Size = new System.Drawing.Size(141, 152);
            this.grp_TOOL.TabIndex = 29;
            this.grp_TOOL.TabStop = false;
            this.grp_TOOL.Text = "TOOL";
            // 
            // lb_TC
            // 
            this.lb_TC.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_TC.Location = new System.Drawing.Point(53, 125);
            this.lb_TC.Name = "lb_TC";
            this.lb_TC.Size = new System.Drawing.Size(70, 20);
            this.lb_TC.TabIndex = 26;
            this.lb_TC.Text = "Y";
            this.lb_TC.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label57
            // 
            this.label57.Location = new System.Drawing.Point(8, 26);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(30, 20);
            this.label57.TabIndex = 17;
            this.label57.Text = "X";
            // 
            // label60
            // 
            this.label60.Location = new System.Drawing.Point(8, 66);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(30, 20);
            this.label60.TabIndex = 21;
            this.label60.Text = "Z";
            // 
            // label61
            // 
            this.label61.Location = new System.Drawing.Point(8, 126);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(30, 20);
            this.label61.TabIndex = 27;
            this.label61.Text = "C";
            // 
            // lb_TZ
            // 
            this.lb_TZ.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_TZ.Location = new System.Drawing.Point(53, 65);
            this.lb_TZ.Name = "lb_TZ";
            this.lb_TZ.Size = new System.Drawing.Size(70, 20);
            this.lb_TZ.TabIndex = 20;
            this.lb_TZ.Text = "Y";
            this.lb_TZ.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lb_TY
            // 
            this.lb_TY.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_TY.Location = new System.Drawing.Point(53, 45);
            this.lb_TY.Name = "lb_TY";
            this.lb_TY.Size = new System.Drawing.Size(70, 20);
            this.lb_TY.TabIndex = 18;
            this.lb_TY.Text = "Y";
            this.lb_TY.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lb_TB
            // 
            this.lb_TB.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_TB.Location = new System.Drawing.Point(53, 105);
            this.lb_TB.Name = "lb_TB";
            this.lb_TB.Size = new System.Drawing.Size(70, 20);
            this.lb_TB.TabIndex = 24;
            this.lb_TB.Text = "Y";
            this.lb_TB.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label67
            // 
            this.label67.Location = new System.Drawing.Point(8, 86);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(30, 20);
            this.label67.TabIndex = 23;
            this.label67.Text = "A";
            // 
            // lb_TX
            // 
            this.lb_TX.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_TX.Location = new System.Drawing.Point(53, 25);
            this.lb_TX.Name = "lb_TX";
            this.lb_TX.Size = new System.Drawing.Size(70, 20);
            this.lb_TX.TabIndex = 16;
            this.lb_TX.Text = "Y";
            this.lb_TX.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label69
            // 
            this.label69.Location = new System.Drawing.Point(8, 46);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(30, 20);
            this.label69.TabIndex = 19;
            this.label69.Text = "Y";
            // 
            // label71
            // 
            this.label71.Location = new System.Drawing.Point(8, 106);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(30, 20);
            this.label71.TabIndex = 25;
            this.label71.Text = "B";
            // 
            // lb_TA
            // 
            this.lb_TA.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_TA.Location = new System.Drawing.Point(53, 85);
            this.lb_TA.Name = "lb_TA";
            this.lb_TA.Size = new System.Drawing.Size(70, 20);
            this.lb_TA.TabIndex = 22;
            this.lb_TA.Text = "Y";
            this.lb_TA.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // grp_BASE
            // 
            this.grp_BASE.Controls.Add(this.lb_BC);
            this.grp_BASE.Controls.Add(this.label27);
            this.grp_BASE.Controls.Add(this.label29);
            this.grp_BASE.Controls.Add(this.label31);
            this.grp_BASE.Controls.Add(this.lb_BZ);
            this.grp_BASE.Controls.Add(this.lb_BY);
            this.grp_BASE.Controls.Add(this.lb_BB);
            this.grp_BASE.Controls.Add(this.label45);
            this.grp_BASE.Controls.Add(this.lb_BX);
            this.grp_BASE.Controls.Add(this.label49);
            this.grp_BASE.Controls.Add(this.label53);
            this.grp_BASE.Controls.Add(this.lb_BA);
            this.grp_BASE.Enabled = false;
            this.grp_BASE.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.grp_BASE.Location = new System.Drawing.Point(370, 38);
            this.grp_BASE.Margin = new System.Windows.Forms.Padding(5);
            this.grp_BASE.Name = "grp_BASE";
            this.grp_BASE.Padding = new System.Windows.Forms.Padding(5);
            this.grp_BASE.Size = new System.Drawing.Size(141, 152);
            this.grp_BASE.TabIndex = 28;
            this.grp_BASE.TabStop = false;
            this.grp_BASE.Text = "BASE";
            // 
            // lb_BC
            // 
            this.lb_BC.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_BC.Location = new System.Drawing.Point(53, 125);
            this.lb_BC.Name = "lb_BC";
            this.lb_BC.Size = new System.Drawing.Size(70, 20);
            this.lb_BC.TabIndex = 26;
            this.lb_BC.Text = "Y";
            this.lb_BC.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label27
            // 
            this.label27.Location = new System.Drawing.Point(8, 26);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(30, 20);
            this.label27.TabIndex = 17;
            this.label27.Text = "X";
            // 
            // label29
            // 
            this.label29.Location = new System.Drawing.Point(8, 66);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(30, 20);
            this.label29.TabIndex = 21;
            this.label29.Text = "Z";
            // 
            // label31
            // 
            this.label31.Location = new System.Drawing.Point(8, 126);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(30, 20);
            this.label31.TabIndex = 27;
            this.label31.Text = "C";
            // 
            // lb_BZ
            // 
            this.lb_BZ.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_BZ.Location = new System.Drawing.Point(53, 65);
            this.lb_BZ.Name = "lb_BZ";
            this.lb_BZ.Size = new System.Drawing.Size(70, 20);
            this.lb_BZ.TabIndex = 20;
            this.lb_BZ.Text = "Y";
            this.lb_BZ.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lb_BY
            // 
            this.lb_BY.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_BY.Location = new System.Drawing.Point(53, 45);
            this.lb_BY.Name = "lb_BY";
            this.lb_BY.Size = new System.Drawing.Size(70, 20);
            this.lb_BY.TabIndex = 18;
            this.lb_BY.Text = "Y";
            this.lb_BY.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lb_BB
            // 
            this.lb_BB.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_BB.Location = new System.Drawing.Point(53, 105);
            this.lb_BB.Name = "lb_BB";
            this.lb_BB.Size = new System.Drawing.Size(70, 20);
            this.lb_BB.TabIndex = 24;
            this.lb_BB.Text = "Y";
            this.lb_BB.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label45
            // 
            this.label45.Location = new System.Drawing.Point(8, 86);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(30, 20);
            this.label45.TabIndex = 23;
            this.label45.Text = "A";
            // 
            // lb_BX
            // 
            this.lb_BX.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_BX.Location = new System.Drawing.Point(53, 25);
            this.lb_BX.Name = "lb_BX";
            this.lb_BX.Size = new System.Drawing.Size(70, 20);
            this.lb_BX.TabIndex = 16;
            this.lb_BX.Text = "Y";
            this.lb_BX.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label49
            // 
            this.label49.Location = new System.Drawing.Point(8, 46);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(30, 20);
            this.label49.TabIndex = 19;
            this.label49.Text = "Y";
            // 
            // label53
            // 
            this.label53.Location = new System.Drawing.Point(8, 106);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(30, 20);
            this.label53.TabIndex = 25;
            this.label53.Text = "B";
            // 
            // lb_BA
            // 
            this.lb_BA.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_BA.Location = new System.Drawing.Point(53, 85);
            this.lb_BA.Name = "lb_BA";
            this.lb_BA.Size = new System.Drawing.Size(70, 20);
            this.lb_BA.TabIndex = 22;
            this.lb_BA.Text = "Y";
            this.lb_BA.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // grp_ACC
            // 
            this.grp_ACC.Controls.Add(this.lb_AccORI2);
            this.grp_ACC.Controls.Add(this.label37);
            this.grp_ACC.Controls.Add(this.lb_AccORI1);
            this.grp_ACC.Controls.Add(this.label41);
            this.grp_ACC.Controls.Add(this.lb_AccCP);
            this.grp_ACC.Controls.Add(this.label42);
            this.grp_ACC.Enabled = false;
            this.grp_ACC.Location = new System.Drawing.Point(524, 200);
            this.grp_ACC.Margin = new System.Windows.Forms.Padding(5);
            this.grp_ACC.Name = "grp_ACC";
            this.grp_ACC.Padding = new System.Windows.Forms.Padding(5);
            this.grp_ACC.Size = new System.Drawing.Size(141, 98);
            this.grp_ACC.TabIndex = 29;
            this.grp_ACC.TabStop = false;
            this.grp_ACC.Text = "ACC";
            // 
            // lb_AccORI2
            // 
            this.lb_AccORI2.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_AccORI2.Location = new System.Drawing.Point(53, 71);
            this.lb_AccORI2.Name = "lb_AccORI2";
            this.lb_AccORI2.Size = new System.Drawing.Size(70, 20);
            this.lb_AccORI2.TabIndex = 45;
            this.lb_AccORI2.Text = "Y";
            this.lb_AccORI2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label37
            // 
            this.label37.Location = new System.Drawing.Point(15, 32);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(40, 20);
            this.label37.TabIndex = 17;
            this.label37.Text = "CP";
            // 
            // lb_AccORI1
            // 
            this.lb_AccORI1.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_AccORI1.Location = new System.Drawing.Point(53, 51);
            this.lb_AccORI1.Name = "lb_AccORI1";
            this.lb_AccORI1.Size = new System.Drawing.Size(70, 20);
            this.lb_AccORI1.TabIndex = 44;
            this.lb_AccORI1.Text = "Y";
            this.lb_AccORI1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label41
            // 
            this.label41.Location = new System.Drawing.Point(15, 72);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(40, 20);
            this.label41.TabIndex = 21;
            this.label41.Text = "ORI2";
            // 
            // lb_AccCP
            // 
            this.lb_AccCP.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_AccCP.Location = new System.Drawing.Point(53, 31);
            this.lb_AccCP.Name = "lb_AccCP";
            this.lb_AccCP.Size = new System.Drawing.Size(70, 20);
            this.lb_AccCP.TabIndex = 43;
            this.lb_AccCP.Text = "Y";
            this.lb_AccCP.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label42
            // 
            this.label42.Location = new System.Drawing.Point(15, 52);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(40, 20);
            this.label42.TabIndex = 19;
            this.label42.Text = "ORI1";
            // 
            // grp_VEL
            // 
            this.grp_VEL.Controls.Add(this.label62);
            this.grp_VEL.Controls.Add(this.lb_VelORI2);
            this.grp_VEL.Controls.Add(this.label63);
            this.grp_VEL.Controls.Add(this.lb_VelORI1);
            this.grp_VEL.Controls.Add(this.label70);
            this.grp_VEL.Controls.Add(this.lb_VelCP);
            this.grp_VEL.Enabled = false;
            this.grp_VEL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grp_VEL.Location = new System.Drawing.Point(370, 200);
            this.grp_VEL.Margin = new System.Windows.Forms.Padding(5);
            this.grp_VEL.Name = "grp_VEL";
            this.grp_VEL.Padding = new System.Windows.Forms.Padding(5);
            this.grp_VEL.Size = new System.Drawing.Size(141, 98);
            this.grp_VEL.TabIndex = 28;
            this.grp_VEL.TabStop = false;
            this.grp_VEL.Text = "VEL";
            // 
            // label62
            // 
            this.label62.Location = new System.Drawing.Point(15, 32);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(40, 20);
            this.label62.TabIndex = 17;
            this.label62.Text = "CP";
            // 
            // lb_VelORI2
            // 
            this.lb_VelORI2.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_VelORI2.Location = new System.Drawing.Point(53, 71);
            this.lb_VelORI2.Name = "lb_VelORI2";
            this.lb_VelORI2.Size = new System.Drawing.Size(70, 20);
            this.lb_VelORI2.TabIndex = 42;
            this.lb_VelORI2.Text = "Y";
            this.lb_VelORI2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label63
            // 
            this.label63.Location = new System.Drawing.Point(15, 72);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(40, 20);
            this.label63.TabIndex = 21;
            this.label63.Text = "ORI2";
            // 
            // lb_VelORI1
            // 
            this.lb_VelORI1.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_VelORI1.Location = new System.Drawing.Point(53, 52);
            this.lb_VelORI1.Name = "lb_VelORI1";
            this.lb_VelORI1.Size = new System.Drawing.Size(70, 20);
            this.lb_VelORI1.TabIndex = 41;
            this.lb_VelORI1.Text = "Y";
            this.lb_VelORI1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label70
            // 
            this.label70.Location = new System.Drawing.Point(15, 52);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(40, 20);
            this.label70.TabIndex = 19;
            this.label70.Text = "ORI1";
            // 
            // lb_VelCP
            // 
            this.lb_VelCP.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_VelCP.Location = new System.Drawing.Point(53, 32);
            this.lb_VelCP.Name = "lb_VelCP";
            this.lb_VelCP.Size = new System.Drawing.Size(70, 20);
            this.lb_VelCP.TabIndex = 40;
            this.lb_VelCP.Text = "Y";
            this.lb_VelCP.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // grp_EXT
            // 
            this.grp_EXT.Controls.Add(this.lb_E6);
            this.grp_EXT.Controls.Add(this.label50);
            this.grp_EXT.Controls.Add(this.lb_E3);
            this.grp_EXT.Controls.Add(this.label51);
            this.grp_EXT.Controls.Add(this.lb_E2);
            this.grp_EXT.Controls.Add(this.label52);
            this.grp_EXT.Controls.Add(this.lb_E5);
            this.grp_EXT.Controls.Add(this.label56);
            this.grp_EXT.Controls.Add(this.lb_E1);
            this.grp_EXT.Controls.Add(this.lb_E4);
            this.grp_EXT.Controls.Add(this.label58);
            this.grp_EXT.Controls.Add(this.label59);
            this.grp_EXT.Enabled = false;
            this.grp_EXT.ForeColor = System.Drawing.Color.Black;
            this.grp_EXT.Location = new System.Drawing.Point(186, 200);
            this.grp_EXT.Margin = new System.Windows.Forms.Padding(5);
            this.grp_EXT.Name = "grp_EXT";
            this.grp_EXT.Padding = new System.Windows.Forms.Padding(5);
            this.grp_EXT.Size = new System.Drawing.Size(141, 152);
            this.grp_EXT.TabIndex = 29;
            this.grp_EXT.TabStop = false;
            this.grp_EXT.Text = "EXT AXIS";
            // 
            // lb_E6
            // 
            this.lb_E6.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_E6.Location = new System.Drawing.Point(53, 123);
            this.lb_E6.Name = "lb_E6";
            this.lb_E6.Size = new System.Drawing.Size(70, 20);
            this.lb_E6.TabIndex = 33;
            this.lb_E6.Text = "Y";
            this.lb_E6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label50
            // 
            this.label50.Location = new System.Drawing.Point(8, 26);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(30, 20);
            this.label50.TabIndex = 17;
            this.label50.Text = "E1";
            // 
            // lb_E3
            // 
            this.lb_E3.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_E3.Location = new System.Drawing.Point(53, 63);
            this.lb_E3.Name = "lb_E3";
            this.lb_E3.Size = new System.Drawing.Size(70, 20);
            this.lb_E3.TabIndex = 30;
            this.lb_E3.Text = "Y";
            this.lb_E3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label51
            // 
            this.label51.Location = new System.Drawing.Point(8, 66);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(30, 20);
            this.label51.TabIndex = 21;
            this.label51.Text = "E3";
            // 
            // lb_E2
            // 
            this.lb_E2.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_E2.Location = new System.Drawing.Point(53, 43);
            this.lb_E2.Name = "lb_E2";
            this.lb_E2.Size = new System.Drawing.Size(70, 20);
            this.lb_E2.TabIndex = 29;
            this.lb_E2.Text = "Y";
            this.lb_E2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label52
            // 
            this.label52.Location = new System.Drawing.Point(8, 126);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(30, 20);
            this.label52.TabIndex = 27;
            this.label52.Text = "E6";
            // 
            // lb_E5
            // 
            this.lb_E5.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_E5.Location = new System.Drawing.Point(53, 103);
            this.lb_E5.Name = "lb_E5";
            this.lb_E5.Size = new System.Drawing.Size(70, 20);
            this.lb_E5.TabIndex = 32;
            this.lb_E5.Text = "Y";
            this.lb_E5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label56
            // 
            this.label56.Location = new System.Drawing.Point(8, 86);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(30, 20);
            this.label56.TabIndex = 23;
            this.label56.Text = "E4";
            // 
            // lb_E1
            // 
            this.lb_E1.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_E1.Location = new System.Drawing.Point(53, 23);
            this.lb_E1.Name = "lb_E1";
            this.lb_E1.Size = new System.Drawing.Size(70, 20);
            this.lb_E1.TabIndex = 28;
            this.lb_E1.Text = "Y";
            this.lb_E1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lb_E4
            // 
            this.lb_E4.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_E4.Location = new System.Drawing.Point(53, 83);
            this.lb_E4.Name = "lb_E4";
            this.lb_E4.Size = new System.Drawing.Size(70, 20);
            this.lb_E4.TabIndex = 31;
            this.lb_E4.Text = "Y";
            this.lb_E4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label58
            // 
            this.label58.Location = new System.Drawing.Point(8, 46);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(30, 20);
            this.label58.TabIndex = 19;
            this.label58.Text = "E2";
            // 
            // label59
            // 
            this.label59.Location = new System.Drawing.Point(8, 106);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(30, 20);
            this.label59.TabIndex = 25;
            this.label59.Text = "E5";
            // 
            // grp_AXIS
            // 
            this.grp_AXIS.Controls.Add(this.lb_A6);
            this.grp_AXIS.Controls.Add(this.label38);
            this.grp_AXIS.Controls.Add(this.lb_A3);
            this.grp_AXIS.Controls.Add(this.label39);
            this.grp_AXIS.Controls.Add(this.lb_A2);
            this.grp_AXIS.Controls.Add(this.label40);
            this.grp_AXIS.Controls.Add(this.lb_A5);
            this.grp_AXIS.Controls.Add(this.label44);
            this.grp_AXIS.Controls.Add(this.lb_A1);
            this.grp_AXIS.Controls.Add(this.lb_A4);
            this.grp_AXIS.Controls.Add(this.label46);
            this.grp_AXIS.Controls.Add(this.label47);
            this.grp_AXIS.Enabled = false;
            this.grp_AXIS.ForeColor = System.Drawing.Color.Blue;
            this.grp_AXIS.Location = new System.Drawing.Point(186, 38);
            this.grp_AXIS.Margin = new System.Windows.Forms.Padding(5);
            this.grp_AXIS.Name = "grp_AXIS";
            this.grp_AXIS.Padding = new System.Windows.Forms.Padding(5);
            this.grp_AXIS.Size = new System.Drawing.Size(141, 152);
            this.grp_AXIS.TabIndex = 28;
            this.grp_AXIS.TabStop = false;
            this.grp_AXIS.Text = "ROB AXIS";
            // 
            // lb_A6
            // 
            this.lb_A6.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_A6.Location = new System.Drawing.Point(53, 125);
            this.lb_A6.Name = "lb_A6";
            this.lb_A6.Size = new System.Drawing.Size(70, 20);
            this.lb_A6.TabIndex = 39;
            this.lb_A6.Text = "Y";
            this.lb_A6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label38
            // 
            this.label38.Location = new System.Drawing.Point(8, 26);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(30, 20);
            this.label38.TabIndex = 17;
            this.label38.Text = "A1";
            // 
            // lb_A3
            // 
            this.lb_A3.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_A3.Location = new System.Drawing.Point(53, 65);
            this.lb_A3.Name = "lb_A3";
            this.lb_A3.Size = new System.Drawing.Size(70, 20);
            this.lb_A3.TabIndex = 36;
            this.lb_A3.Text = "Y";
            this.lb_A3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label39
            // 
            this.label39.Location = new System.Drawing.Point(8, 66);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(30, 20);
            this.label39.TabIndex = 21;
            this.label39.Text = "A3";
            // 
            // lb_A2
            // 
            this.lb_A2.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_A2.Location = new System.Drawing.Point(53, 45);
            this.lb_A2.Name = "lb_A2";
            this.lb_A2.Size = new System.Drawing.Size(70, 20);
            this.lb_A2.TabIndex = 35;
            this.lb_A2.Text = "Y";
            this.lb_A2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label40
            // 
            this.label40.Location = new System.Drawing.Point(8, 126);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(30, 20);
            this.label40.TabIndex = 27;
            this.label40.Text = "A6";
            // 
            // lb_A5
            // 
            this.lb_A5.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_A5.Location = new System.Drawing.Point(53, 105);
            this.lb_A5.Name = "lb_A5";
            this.lb_A5.Size = new System.Drawing.Size(70, 20);
            this.lb_A5.TabIndex = 38;
            this.lb_A5.Text = "Y";
            this.lb_A5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label44
            // 
            this.label44.Location = new System.Drawing.Point(8, 86);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(30, 20);
            this.label44.TabIndex = 23;
            this.label44.Text = "A4";
            // 
            // lb_A1
            // 
            this.lb_A1.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_A1.Location = new System.Drawing.Point(53, 25);
            this.lb_A1.Name = "lb_A1";
            this.lb_A1.Size = new System.Drawing.Size(70, 20);
            this.lb_A1.TabIndex = 34;
            this.lb_A1.Text = "Y";
            this.lb_A1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lb_A4
            // 
            this.lb_A4.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_A4.Location = new System.Drawing.Point(53, 85);
            this.lb_A4.Name = "lb_A4";
            this.lb_A4.Size = new System.Drawing.Size(70, 20);
            this.lb_A4.TabIndex = 37;
            this.lb_A4.Text = "Y";
            this.lb_A4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label46
            // 
            this.label46.Location = new System.Drawing.Point(8, 46);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(30, 20);
            this.label46.TabIndex = 19;
            this.label46.Text = "A2";
            // 
            // label47
            // 
            this.label47.Location = new System.Drawing.Point(8, 106);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(30, 20);
            this.label47.TabIndex = 25;
            this.label47.Text = "A5";
            // 
            // grp_TCP
            // 
            this.grp_TCP.Controls.Add(this.lb_OV);
            this.grp_TCP.Controls.Add(this.label33);
            this.grp_TCP.Controls.Add(this.lb_S);
            this.grp_TCP.Controls.Add(this.label55);
            this.grp_TCP.Controls.Add(this.lb_T);
            this.grp_TCP.Controls.Add(this.label65);
            this.grp_TCP.Controls.Add(this.lb_C);
            this.grp_TCP.Controls.Add(this.label25);
            this.grp_TCP.Controls.Add(this.label30);
            this.grp_TCP.Controls.Add(this.label36);
            this.grp_TCP.Controls.Add(this.lb_Z);
            this.grp_TCP.Controls.Add(this.lb_Y);
            this.grp_TCP.Controls.Add(this.lb_B);
            this.grp_TCP.Controls.Add(this.label32);
            this.grp_TCP.Controls.Add(this.lb_X);
            this.grp_TCP.Controls.Add(this.label28);
            this.grp_TCP.Controls.Add(this.label34);
            this.grp_TCP.Controls.Add(this.lb_A);
            this.grp_TCP.Enabled = false;
            this.grp_TCP.ForeColor = System.Drawing.Color.Red;
            this.grp_TCP.Location = new System.Drawing.Point(35, 38);
            this.grp_TCP.Margin = new System.Windows.Forms.Padding(5);
            this.grp_TCP.Name = "grp_TCP";
            this.grp_TCP.Padding = new System.Windows.Forms.Padding(5);
            this.grp_TCP.Size = new System.Drawing.Size(141, 314);
            this.grp_TCP.TabIndex = 22;
            this.grp_TCP.TabStop = false;
            this.grp_TCP.Text = "TCP";
            // 
            // lb_OV
            // 
            this.lb_OV.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_OV.Location = new System.Drawing.Point(53, 285);
            this.lb_OV.Name = "lb_OV";
            this.lb_OV.Size = new System.Drawing.Size(70, 20);
            this.lb_OV.TabIndex = 32;
            this.lb_OV.Text = "Y";
            this.lb_OV.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label33
            // 
            this.label33.Location = new System.Drawing.Point(8, 286);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(30, 20);
            this.label33.TabIndex = 33;
            this.label33.Text = "$OV";
            // 
            // lb_S
            // 
            this.lb_S.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_S.Location = new System.Drawing.Point(53, 165);
            this.lb_S.Name = "lb_S";
            this.lb_S.Size = new System.Drawing.Size(70, 20);
            this.lb_S.TabIndex = 30;
            this.lb_S.Text = "Y";
            this.lb_S.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label55
            // 
            this.label55.Location = new System.Drawing.Point(8, 166);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(30, 20);
            this.label55.TabIndex = 31;
            this.label55.Text = "S";
            // 
            // lb_T
            // 
            this.lb_T.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_T.Location = new System.Drawing.Point(53, 185);
            this.lb_T.Name = "lb_T";
            this.lb_T.Size = new System.Drawing.Size(70, 20);
            this.lb_T.TabIndex = 28;
            this.lb_T.Text = "Y";
            this.lb_T.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label65
            // 
            this.label65.Location = new System.Drawing.Point(8, 186);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(30, 20);
            this.label65.TabIndex = 29;
            this.label65.Text = "T";
            // 
            // lb_C
            // 
            this.lb_C.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_C.Location = new System.Drawing.Point(53, 125);
            this.lb_C.Name = "lb_C";
            this.lb_C.Size = new System.Drawing.Size(70, 20);
            this.lb_C.TabIndex = 26;
            this.lb_C.Text = "Y";
            this.lb_C.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label25
            // 
            this.label25.Location = new System.Drawing.Point(8, 26);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(30, 20);
            this.label25.TabIndex = 17;
            this.label25.Text = "X";
            // 
            // label30
            // 
            this.label30.Location = new System.Drawing.Point(8, 66);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(30, 20);
            this.label30.TabIndex = 21;
            this.label30.Text = "Z";
            // 
            // label36
            // 
            this.label36.Location = new System.Drawing.Point(8, 126);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(30, 20);
            this.label36.TabIndex = 27;
            this.label36.Text = "C";
            // 
            // lb_Z
            // 
            this.lb_Z.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Z.Location = new System.Drawing.Point(53, 65);
            this.lb_Z.Name = "lb_Z";
            this.lb_Z.Size = new System.Drawing.Size(70, 20);
            this.lb_Z.TabIndex = 20;
            this.lb_Z.Text = "Y";
            this.lb_Z.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lb_Y
            // 
            this.lb_Y.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Y.Location = new System.Drawing.Point(53, 45);
            this.lb_Y.Name = "lb_Y";
            this.lb_Y.Size = new System.Drawing.Size(70, 20);
            this.lb_Y.TabIndex = 18;
            this.lb_Y.Text = "Y";
            this.lb_Y.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lb_B
            // 
            this.lb_B.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_B.Location = new System.Drawing.Point(53, 105);
            this.lb_B.Name = "lb_B";
            this.lb_B.Size = new System.Drawing.Size(70, 20);
            this.lb_B.TabIndex = 24;
            this.lb_B.Text = "Y";
            this.lb_B.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label32
            // 
            this.label32.Location = new System.Drawing.Point(8, 86);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(30, 20);
            this.label32.TabIndex = 23;
            this.label32.Text = "A";
            // 
            // lb_X
            // 
            this.lb_X.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_X.Location = new System.Drawing.Point(53, 25);
            this.lb_X.Name = "lb_X";
            this.lb_X.Size = new System.Drawing.Size(70, 20);
            this.lb_X.TabIndex = 16;
            this.lb_X.Text = "Y";
            this.lb_X.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label28
            // 
            this.label28.Location = new System.Drawing.Point(8, 46);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(30, 20);
            this.label28.TabIndex = 19;
            this.label28.Text = "Y";
            // 
            // label34
            // 
            this.label34.Location = new System.Drawing.Point(8, 106);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(30, 20);
            this.label34.TabIndex = 25;
            this.label34.Text = "B";
            // 
            // lb_A
            // 
            this.lb_A.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_A.Location = new System.Drawing.Point(53, 85);
            this.lb_A.Name = "lb_A";
            this.lb_A.Size = new System.Drawing.Size(70, 20);
            this.lb_A.TabIndex = 22;
            this.lb_A.Text = "Y";
            this.lb_A.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.label48);
            this.tabPage6.Controls.Add(this.label26);
            this.tabPage6.Controls.Add(this.tbIOSearch);
            this.tabPage6.Controls.Add(this.objectListView);
            this.tabPage6.Controls.Add(this.cb_IOGroup);
            this.tabPage6.Controls.Add(this.btIOGrpDelete);
            this.tabPage6.Controls.Add(this.btIO_Add);
            this.tabPage6.Controls.Add(this.btIO_Remove);
            this.tabPage6.Controls.Add(this.label35);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(687, 393);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Monitoring IO";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(257, 24);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(126, 13);
            this.label48.TabIndex = 72;
            this.label48.Text = "Add/Remove a variable :";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(575, 24);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(47, 13);
            this.label26.TabIndex = 71;
            this.label26.Text = "Search :";
            // 
            // tbIOSearch
            // 
            this.tbIOSearch.Location = new System.Drawing.Point(578, 44);
            this.tbIOSearch.Name = "tbIOSearch";
            this.tbIOSearch.Size = new System.Drawing.Size(100, 20);
            this.tbIOSearch.TabIndex = 70;
            this.tbIOSearch.TextChanged += new System.EventHandler(this.tbIOSearch_TextChanged);
            // 
            // objectListView
            // 
            this.objectListView.AllColumns.Add(this.olvColTag);
            this.objectListView.AllColumns.Add(this.olvColValue);
            this.objectListView.AllColumns.Add(this.olvColFiller);
            this.objectListView.AllColumns.Add(this.olvColName);
            this.objectListView.AllColumns.Add(this.olvColGroup);
            this.objectListView.AllColumns.Add(this.olvColType);
            this.objectListView.CellEditUseWholeCell = false;
            this.objectListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColTag,
            this.olvColValue,
            this.olvColFiller,
            this.olvColName,
            this.olvColGroup,
            this.olvColType});
            this.objectListView.Cursor = System.Windows.Forms.Cursors.Default;
            this.objectListView.DataSource = null;
            this.objectListView.Location = new System.Drawing.Point(15, 70);
            this.objectListView.Name = "objectListView";
            this.objectListView.Size = new System.Drawing.Size(663, 288);
            this.objectListView.TabIndex = 68;
            this.objectListView.UseCompatibleStateImageBehavior = false;
            this.objectListView.UseFiltering = true;
            this.objectListView.View = System.Windows.Forms.View.Details;
            // 
            // olvColTag
            // 
            this.olvColTag.AspectName = "Tag";
            this.olvColTag.Groupable = false;
            this.olvColTag.Sortable = false;
            this.olvColTag.Text = "Tag";
            this.olvColTag.Width = 150;
            // 
            // olvColValue
            // 
            this.olvColValue.AspectName = "Value";
            this.olvColValue.Groupable = false;
            this.olvColValue.Sortable = false;
            this.olvColValue.Text = "Value";
            this.olvColValue.Width = 100;
            // 
            // olvColFiller
            // 
            this.olvColFiller.FillsFreeSpace = true;
            this.olvColFiller.Text = "";
            // 
            // olvColName
            // 
            this.olvColName.AspectName = "Name";
            this.olvColName.Groupable = false;
            this.olvColName.Sortable = false;
            this.olvColName.Text = "Variable";
            this.olvColName.Width = 150;
            // 
            // olvColGroup
            // 
            this.olvColGroup.AspectName = "Group";
            this.olvColGroup.Text = "Group";
            this.olvColGroup.Width = 75;
            // 
            // olvColType
            // 
            this.olvColType.AspectName = "Type";
            this.olvColType.IsEditable = false;
            this.olvColType.Text = "Type";
            this.olvColType.UseFiltering = false;
            this.olvColType.Width = 75;
            // 
            // cb_IOGroup
            // 
            this.cb_IOGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_IOGroup.FormattingEnabled = true;
            this.cb_IOGroup.Location = new System.Drawing.Point(15, 40);
            this.cb_IOGroup.Name = "cb_IOGroup";
            this.cb_IOGroup.Size = new System.Drawing.Size(150, 21);
            this.cb_IOGroup.TabIndex = 59;
            this.cb_IOGroup.SelectedIndexChanged += new System.EventHandler(this.cb_IOGroup_SelectedIndexChanged);
            // 
            // btIOGrpDelete
            // 
            this.btIOGrpDelete.Image = global::Kukavar.DemoApp.Properties.Resources.delete;
            this.btIOGrpDelete.Location = new System.Drawing.Point(171, 39);
            this.btIOGrpDelete.Name = "btIOGrpDelete";
            this.btIOGrpDelete.Size = new System.Drawing.Size(24, 24);
            this.btIOGrpDelete.TabIndex = 56;
            this.btIOGrpDelete.Text = " ";
            this.toolTip.SetToolTip(this.btIOGrpDelete, "Delete the selected template");
            this.btIOGrpDelete.UseVisualStyleBackColor = true;
            this.btIOGrpDelete.Click += new System.EventHandler(this.btIOGrpDelete_Click);
            // 
            // btIO_Add
            // 
            this.btIO_Add.Image = global::Kukavar.DemoApp.Properties.Resources.add;
            this.btIO_Add.Location = new System.Drawing.Point(255, 39);
            this.btIO_Add.Name = "btIO_Add";
            this.btIO_Add.Size = new System.Drawing.Size(24, 24);
            this.btIO_Add.TabIndex = 54;
            this.btIO_Add.Text = " ";
            this.toolTip.SetToolTip(this.btIO_Add, "Add the variable to the list");
            this.btIO_Add.UseVisualStyleBackColor = true;
            this.btIO_Add.Click += new System.EventHandler(this.btIO_Add_Click);
            // 
            // btIO_Remove
            // 
            this.btIO_Remove.Image = global::Kukavar.DemoApp.Properties.Resources.remove;
            this.btIO_Remove.Location = new System.Drawing.Point(285, 39);
            this.btIO_Remove.Name = "btIO_Remove";
            this.btIO_Remove.Size = new System.Drawing.Size(24, 24);
            this.btIO_Remove.TabIndex = 53;
            this.btIO_Remove.Text = " ";
            this.toolTip.SetToolTip(this.btIO_Remove, "Remove the selected item from the variable list");
            this.btIO_Remove.UseVisualStyleBackColor = true;
            this.btIO_Remove.Click += new System.EventHandler(this.btIO_Remove_Click);
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(12, 24);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(79, 13);
            this.label35.TabIndex = 51;
            this.label35.Text = "Filter by group :";
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(687, 393);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Tests";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbModeOP);
            this.groupBox2.Controls.Add(this.label43);
            this.groupBox2.Controls.Add(this.lbProName1);
            this.groupBox2.Controls.Add(this.lbProState1);
            this.groupBox2.Controls.Add(this.lbProState0);
            this.groupBox2.Controls.Add(this.lbProName0);
            this.groupBox2.Controls.Add(this.label24);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.tbRobVersion);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.tbRobHours);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.tbRobName);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Location = new System.Drawing.Point(437, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(266, 193);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "System Info";
            // 
            // lbModeOP
            // 
            this.lbModeOP.BackColor = System.Drawing.Color.LightGray;
            this.lbModeOP.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbModeOP.Location = new System.Drawing.Point(190, 110);
            this.lbModeOP.Name = "lbModeOP";
            this.lbModeOP.Size = new System.Drawing.Size(67, 13);
            this.lbModeOP.TabIndex = 21;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(6, 110);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(57, 13);
            this.label43.TabIndex = 20;
            this.label43.Text = "MODE OP";
            // 
            // lbProName1
            // 
            this.lbProName1.BackColor = System.Drawing.Color.LightGray;
            this.lbProName1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbProName1.Location = new System.Drawing.Point(75, 161);
            this.lbProName1.Name = "lbProName1";
            this.lbProName1.Size = new System.Drawing.Size(106, 13);
            this.lbProName1.TabIndex = 19;
            // 
            // lbProState1
            // 
            this.lbProState1.BackColor = System.Drawing.Color.LightGray;
            this.lbProState1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbProState1.Location = new System.Drawing.Point(190, 161);
            this.lbProState1.Name = "lbProState1";
            this.lbProState1.Size = new System.Drawing.Size(67, 13);
            this.lbProState1.TabIndex = 18;
            // 
            // lbProState0
            // 
            this.lbProState0.BackColor = System.Drawing.Color.LightGray;
            this.lbProState0.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbProState0.Location = new System.Drawing.Point(190, 136);
            this.lbProState0.Name = "lbProState0";
            this.lbProState0.Size = new System.Drawing.Size(67, 13);
            this.lbProState0.TabIndex = 17;
            // 
            // lbProName0
            // 
            this.lbProName0.BackColor = System.Drawing.Color.LightGray;
            this.lbProName0.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbProName0.Location = new System.Drawing.Point(75, 136);
            this.lbProName0.Name = "lbProName0";
            this.lbProName0.Size = new System.Drawing.Size(106, 13);
            this.lbProName0.TabIndex = 16;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(6, 162);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(30, 13);
            this.label24.TabIndex = 15;
            this.label24.Text = "ROB";
            this.label24.Click += new System.EventHandler(this.label24_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(6, 136);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(27, 13);
            this.label22.TabIndex = 14;
            this.label22.Text = "PLC";
            // 
            // tbRobVersion
            // 
            this.tbRobVersion.Location = new System.Drawing.Point(78, 54);
            this.tbRobVersion.Name = "tbRobVersion";
            this.tbRobVersion.Size = new System.Drawing.Size(182, 20);
            this.tbRobVersion.TabIndex = 12;
            this.tbRobVersion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 57);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 13);
            this.label13.TabIndex = 13;
            this.label13.Text = "System";
            // 
            // tbRobHours
            // 
            this.tbRobHours.Location = new System.Drawing.Point(190, 80);
            this.tbRobHours.Name = "tbRobHours";
            this.tbRobHours.Size = new System.Drawing.Size(70, 20);
            this.tbRobHours.TabIndex = 10;
            this.tbRobHours.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 83);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 13);
            this.label12.TabIndex = 11;
            this.label12.Text = "Hours (hh:mm)";
            // 
            // tbRobName
            // 
            this.tbRobName.Location = new System.Drawing.Point(78, 28);
            this.tbRobName.Name = "tbRobName";
            this.tbRobName.Size = new System.Drawing.Size(182, 20);
            this.tbRobName.TabIndex = 9;
            this.tbRobName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 31);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 13);
            this.label11.TabIndex = 9;
            this.label11.Text = "Name";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ckMonitor);
            this.groupBox3.Controls.Add(this.ckConnect);
            this.groupBox3.Controls.Add(this.lbConnectionStatus);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(199, 193);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Start/Stop";
            // 
            // ckMonitor
            // 
            this.ckMonitor.Appearance = System.Windows.Forms.Appearance.Button;
            this.ckMonitor.Location = new System.Drawing.Point(39, 76);
            this.ckMonitor.Name = "ckMonitor";
            this.ckMonitor.Size = new System.Drawing.Size(120, 28);
            this.ckMonitor.TabIndex = 14;
            this.ckMonitor.Text = "Monitoring: START";
            this.ckMonitor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ckMonitor.UseVisualStyleBackColor = true;
            this.ckMonitor.CheckedChanged += new System.EventHandler(this.ckMonitor_CheckedChanged);
            // 
            // ckConnect
            // 
            this.ckConnect.Appearance = System.Windows.Forms.Appearance.Button;
            this.ckConnect.Location = new System.Drawing.Point(39, 42);
            this.ckConnect.Name = "ckConnect";
            this.ckConnect.Size = new System.Drawing.Size(120, 28);
            this.ckConnect.TabIndex = 13;
            this.ckConnect.Text = "Connect";
            this.ckConnect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ckConnect.UseVisualStyleBackColor = true;
            this.ckConnect.CheckedChanged += new System.EventHandler(this.ckConnect_CheckedChanged);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 647);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.grpCSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OpenKuka | KukavarClient.DemoApp";
            this.grpCSettings.ResumeLayout(false);
            this.grpCSettings.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListView)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rblRecordHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rblRecordFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecords)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.grp_TOOL.ResumeLayout(false);
            this.grp_BASE.ResumeLayout(false);
            this.grp_ACC.ResumeLayout(false);
            this.grp_VEL.ResumeLayout(false);
            this.grp_EXT.ResumeLayout(false);
            this.grp_AXIS.ResumeLayout(false);
            this.grp_TCP.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objectListView)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbServerIP;
        private System.Windows.Forms.TextBox tbServerPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grpCSettings;
        private System.Windows.Forms.TextBox tbReconnectionTO;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbMaxIdleTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox ckAutoReconnect;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox lbConnectionStatus;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private BrightIdeasSoftware.TreeListView treeListView;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btReadSingle;
        private System.Windows.Forms.Label label8;
        private AutoCompleteComboBox.SuggestComboBox scbRead;
        private System.Windows.Forms.Button btDown;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btRemoveTemplateVar;
        private System.Windows.Forms.Button btAddTemplateVar;
        private System.Windows.Forms.Button btUp;
        private System.Windows.Forms.Button btRemoveReadTemplate;
        private System.Windows.Forms.ListBox lstbRead;
        private System.Windows.Forms.Button btAddReadTemplate;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button btEditTemplateName;
        private System.Windows.Forms.ComboBox cbTemplate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbTemplateName;
        private System.Windows.Forms.Button btReadTemplate;
        private System.Windows.Forms.Button btRemoveHistory;
        private System.Windows.Forms.Button btExpandAll;
        private System.Windows.Forms.Button btCollapseAll;
        private System.Windows.Forms.Label lbReadTime;
        private System.Windows.Forms.TextBox tbRobHours;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbRobName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbRobVersion;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.DataGridView dgvRecords;
        private System.Windows.Forms.Button btRemoveRecord;
        private System.Windows.Forms.Button btAddRecord;
        private System.Windows.Forms.Label label14;
        private EWSoftware.ListControls.RadioButtonList rblRecordFilter;
        private EWSoftware.ListControls.AutoCompleteComboBox cbRecordFormat;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private EWSoftware.ListControls.RadioButtonList rblRecordHeader;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button btRecordReset;
        private System.Windows.Forms.Label label23;
        private AutoCompleteComboBox.SuggestComboBox scbWrite;
        private System.Windows.Forms.Button btWrite;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox tbVarValue;
        private System.Windows.Forms.Label lbWriteElapsed;
        private System.Windows.Forms.Label lbWriteStatus;
        private System.Windows.Forms.Label lbProState0;
        private System.Windows.Forms.Label lbProName0;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lbProState1;
        private System.Windows.Forms.Label lbProName1;
        private System.Windows.Forms.GroupBox grp_VEL;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.GroupBox grp_EXT;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.GroupBox grp_AXIS;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.GroupBox grp_TCP;
        private System.Windows.Forms.Label lb_C;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label lb_Z;
        private System.Windows.Forms.Label lb_Y;
        private System.Windows.Forms.Label lb_B;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label lb_X;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label lb_A;
        private System.Windows.Forms.GroupBox grp_ACC;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.GroupBox grp_TOOL;
        private System.Windows.Forms.Label lb_TC;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.Label label60;
        private System.Windows.Forms.Label label61;
        private System.Windows.Forms.Label lb_TZ;
        private System.Windows.Forms.Label lb_TY;
        private System.Windows.Forms.Label lb_TB;
        private System.Windows.Forms.Label label67;
        private System.Windows.Forms.Label lb_TX;
        private System.Windows.Forms.Label label69;
        private System.Windows.Forms.Label label71;
        private System.Windows.Forms.Label lb_TA;
        private System.Windows.Forms.GroupBox grp_BASE;
        private System.Windows.Forms.Label lb_BC;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label lb_BZ;
        private System.Windows.Forms.Label lb_BY;
        private System.Windows.Forms.Label lb_BB;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Label lb_BX;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.Label lb_BA;
        private System.Windows.Forms.Label lb_AccORI2;
        private System.Windows.Forms.Label lb_AccORI1;
        private System.Windows.Forms.Label lb_AccCP;
        private System.Windows.Forms.Label lb_VelORI2;
        private System.Windows.Forms.Label lb_VelORI1;
        private System.Windows.Forms.Label lb_VelCP;
        private System.Windows.Forms.Label lb_E6;
        private System.Windows.Forms.Label lb_E3;
        private System.Windows.Forms.Label lb_E2;
        private System.Windows.Forms.Label lb_E5;
        private System.Windows.Forms.Label lb_E1;
        private System.Windows.Forms.Label lb_E4;
        private System.Windows.Forms.Label lb_A6;
        private System.Windows.Forms.Label lb_A3;
        private System.Windows.Forms.Label lb_A2;
        private System.Windows.Forms.Label lb_A5;
        private System.Windows.Forms.Label lb_A1;
        private System.Windows.Forms.Label lb_A4;
        private System.Windows.Forms.Label lb_S;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.Label lb_T;
        private System.Windows.Forms.Label label65;
        private System.Windows.Forms.Label lbMonitoTime;
        private System.Windows.Forms.Label lb_OV;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label lbMonitoRate;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.CheckBox ckConnect;
        private System.Windows.Forms.CheckBox ckMonitor;
        private System.Windows.Forms.ComboBox cb_IOGroup;
        private System.Windows.Forms.Button btIOGrpDelete;
        private System.Windows.Forms.Button btIO_Add;
        private System.Windows.Forms.Button btIO_Remove;
        private System.Windows.Forms.Label label35;
        private BrightIdeasSoftware.DataListView objectListView;
        private BrightIdeasSoftware.OLVColumn olvColName;
        private BrightIdeasSoftware.OLVColumn olvColValue;
        private BrightIdeasSoftware.OLVColumn olvColGroup;
        private BrightIdeasSoftware.OLVColumn olvColTag;
        private BrightIdeasSoftware.OLVColumn olvColType;
        private System.Windows.Forms.TextBox tbIOSearch;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label lbModeOP;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.Label label26;
        private BrightIdeasSoftware.OLVColumn olvColFiller;
    }
}