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
            this.btStart = new System.Windows.Forms.Button();
            this.grpCSettings = new System.Windows.Forms.GroupBox();
            this.ckAutoReconnect = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbReconnectionTO = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbMaxIdleTime = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btStop = new System.Windows.Forms.Button();
            this.lbConnectionStatus = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btReadTemplate = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.tbTemplateName = new System.Windows.Forms.TextBox();
            this.cbTemplate = new System.Windows.Forms.ComboBox();
            this.lstbRead = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.scbRead = new AutoCompleteComboBox.SuggestComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btReadSingle = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.treeListView = new BrightIdeasSoftware.TreeListView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btRemoveHistory = new System.Windows.Forms.Button();
            this.btEditTemplateName = new System.Windows.Forms.Button();
            this.btAddReadTemplate = new System.Windows.Forms.Button();
            this.btRemoveReadTemplate = new System.Windows.Forms.Button();
            this.btUp = new System.Windows.Forms.Button();
            this.btAddTemplateVar = new System.Windows.Forms.Button();
            this.btRemoveTemplateVar = new System.Windows.Forms.Button();
            this.btDown = new System.Windows.Forms.Button();
            this.btExpandAll = new System.Windows.Forms.Button();
            this.btCollapseAll = new System.Windows.Forms.Button();
            this.lbReadTime = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tbRobName = new System.Windows.Forms.TextBox();
            this.tbRobHours = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbRobVersion = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.grpCSettings.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListView)).BeginInit();
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
            // btStart
            // 
            this.btStart.Location = new System.Drawing.Point(28, 28);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(100, 24);
            this.btStart.TabIndex = 4;
            this.btStart.Text = "Start";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
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
            // btStop
            // 
            this.btStop.Location = new System.Drawing.Point(28, 60);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(100, 24);
            this.btStop.TabIndex = 10;
            this.btStop.Text = "Stop";
            this.btStop.UseVisualStyleBackColor = true;
            this.btStop.Click += new System.EventHandler(this.btStop_Click);
            // 
            // lbConnectionStatus
            // 
            this.lbConnectionStatus.BackColor = System.Drawing.SystemColors.InactiveCaption;
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
            this.tabControl1.Enabled = false;
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
            this.tabPage1.Text = "READ";
            this.tabPage1.UseVisualStyleBackColor = true;
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
            // lstbRead
            // 
            this.lstbRead.FormattingEnabled = true;
            this.lstbRead.Location = new System.Drawing.Point(15, 213);
            this.lstbRead.Name = "lstbRead";
            this.lstbRead.Size = new System.Drawing.Size(150, 147);
            this.lstbRead.TabIndex = 33;
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
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(687, 393);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "WRITE";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btStop);
            this.groupBox3.Controls.Add(this.btStart);
            this.groupBox3.Controls.Add(this.lbConnectionStatus);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(199, 193);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Start/Stop";
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
            this.btAddTemplateVar.Image = global::Kukavar.DemoApp.Properties.Resources.add1;
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
            // lbReadTime
            // 
            this.lbReadTime.Location = new System.Drawing.Point(372, 363);
            this.lbReadTime.Name = "lbReadTime";
            this.lbReadTime.Size = new System.Drawing.Size(297, 13);
            this.lbReadTime.TabIndex = 50;
            this.lbReadTime.Text = "elapsed time : ms";
            this.lbReadTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            // tbRobName
            // 
            this.tbRobName.Location = new System.Drawing.Point(78, 28);
            this.tbRobName.Name = "tbRobName";
            this.tbRobName.Size = new System.Drawing.Size(182, 20);
            this.tbRobName.TabIndex = 9;
            this.tbRobName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            this.Name = "Form1";
            this.Text = "OpenKuka | KukavarClient.DemoApp";
            this.grpCSettings.ResumeLayout(false);
            this.grpCSettings.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListView)).EndInit();
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
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.GroupBox grpCSettings;
        private System.Windows.Forms.TextBox tbReconnectionTO;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbMaxIdleTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox ckAutoReconnect;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btStop;
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
    }
}