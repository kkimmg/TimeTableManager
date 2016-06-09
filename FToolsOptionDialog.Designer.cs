namespace TimeTableManager.UI {
    partial class FToolsOptionDialog {
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            this.GrpAutoSettings = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.RdoDefault = new System.Windows.Forms.RadioButton();
            this.RdoWeekly = new System.Windows.Forms.RadioButton();
            this.RdoMonthly = new System.Windows.Forms.RadioButton();
            this.RdoMonthlyWeekly = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TabGeneral = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.NumChangeMonth = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.ChkAdjustCalendar = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel6 = new System.Windows.Forms.FlowLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.DspEditorThreshold = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ChkEditHistory = new System.Windows.Forms.CheckBox();
            this.TabAutoSettings = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.NumAutoBuf = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.TabPlugins = new System.Windows.Forms.TabPage();
            this.BtnConfigPlugin = new System.Windows.Forms.Button();
            this.LstPlugins = new System.Windows.Forms.ListBox();
            this.DsPlugins = new System.Data.DataSet();
            this.TblPlugins = new System.Data.DataTable();
            this.ClmPlugin = new System.Data.DataColumn();
            this.ClmPluginDesc = new System.Data.DataColumn();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnOK = new System.Windows.Forms.Button();
            this.GrpAutoSettings.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.TabGeneral.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumChangeMonth)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.flowLayoutPanel5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.flowLayoutPanel6.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.TabAutoSettings.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumAutoBuf)).BeginInit();
            this.TabPlugins.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DsPlugins)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TblPlugins)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrpAutoSettings
            // 
            this.GrpAutoSettings.Controls.Add(this.flowLayoutPanel2);
            this.GrpAutoSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrpAutoSettings.Location = new System.Drawing.Point(3, 3);
            this.GrpAutoSettings.Name = "GrpAutoSettings";
            this.GrpAutoSettings.Size = new System.Drawing.Size(266, 64);
            this.GrpAutoSettings.TabIndex = 2;
            this.GrpAutoSettings.TabStop = false;
            this.GrpAutoSettings.Text = "自動設定機能";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.RdoDefault);
            this.flowLayoutPanel2.Controls.Add(this.RdoWeekly);
            this.flowLayoutPanel2.Controls.Add(this.RdoMonthly);
            this.flowLayoutPanel2.Controls.Add(this.RdoMonthlyWeekly);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 15);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(260, 46);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // RdoDefault
            // 
            this.RdoDefault.AutoSize = true;
            this.RdoDefault.Location = new System.Drawing.Point(3, 3);
            this.RdoDefault.Name = "RdoDefault";
            this.RdoDefault.Size = new System.Drawing.Size(101, 16);
            this.RdoDefault.TabIndex = 4;
            this.RdoDefault.TabStop = true;
            this.RdoDefault.Text = "日替わり（既定）";
            this.RdoDefault.UseVisualStyleBackColor = true;
            // 
            // RdoWeekly
            // 
            this.RdoWeekly.AutoSize = true;
            this.RdoWeekly.Location = new System.Drawing.Point(110, 3);
            this.RdoWeekly.Name = "RdoWeekly";
            this.RdoWeekly.Size = new System.Drawing.Size(65, 16);
            this.RdoWeekly.TabIndex = 5;
            this.RdoWeekly.TabStop = true;
            this.RdoWeekly.Text = "週替わり";
            this.RdoWeekly.UseVisualStyleBackColor = true;
            // 
            // RdoMonthly
            // 
            this.RdoMonthly.AutoSize = true;
            this.RdoMonthly.Location = new System.Drawing.Point(181, 3);
            this.RdoMonthly.Name = "RdoMonthly";
            this.RdoMonthly.Size = new System.Drawing.Size(65, 16);
            this.RdoMonthly.TabIndex = 6;
            this.RdoMonthly.TabStop = true;
            this.RdoMonthly.Text = "月替わり";
            this.RdoMonthly.UseVisualStyleBackColor = true;
            // 
            // RdoMonthlyWeekly
            // 
            this.RdoMonthlyWeekly.AutoSize = true;
            this.RdoMonthlyWeekly.Location = new System.Drawing.Point(3, 25);
            this.RdoMonthlyWeekly.Name = "RdoMonthlyWeekly";
            this.RdoMonthlyWeekly.Size = new System.Drawing.Size(115, 16);
            this.RdoMonthlyWeekly.TabIndex = 7;
            this.RdoMonthlyWeekly.TabStop = true;
            this.RdoMonthlyWeekly.Text = "曜日ごとに月替わり";
            this.RdoMonthlyWeekly.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87.54578F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.45421F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(292, 273);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.TabGeneral);
            this.tabControl1.Controls.Add(this.TabAutoSettings);
            this.tabControl1.Controls.Add(this.TabPlugins);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(286, 233);
            this.tabControl1.TabIndex = 0;
            // 
            // TabGeneral
            // 
            this.TabGeneral.Controls.Add(this.tableLayoutPanel3);
            this.TabGeneral.Location = new System.Drawing.Point(4, 21);
            this.TabGeneral.Name = "TabGeneral";
            this.TabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.TabGeneral.Size = new System.Drawing.Size(278, 208);
            this.TabGeneral.TabIndex = 1;
            this.TabGeneral.Text = "全般";
            this.TabGeneral.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.groupBox3, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.groupBox4, 0, 3);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(272, 202);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanel4);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(266, 48);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "カレンダー";
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.label3);
            this.flowLayoutPanel4.Controls.Add(this.NumChangeMonth);
            this.flowLayoutPanel4.Controls.Add(this.label4);
            this.flowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel4.Location = new System.Drawing.Point(3, 15);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(260, 30);
            this.flowLayoutPanel4.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "毎月";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NumChangeMonth
            // 
            this.NumChangeMonth.Location = new System.Drawing.Point(38, 3);
            this.NumChangeMonth.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.NumChangeMonth.Name = "NumChangeMonth";
            this.NumChangeMonth.Size = new System.Drawing.Size(49, 19);
            this.NumChangeMonth.TabIndex = 1;
            this.NumChangeMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(93, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 25);
            this.label4.TabIndex = 2;
            this.label4.Text = "日以後は次の月を表示する。";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.flowLayoutPanel5);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 57);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(266, 40);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "列幅";
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.Controls.Add(this.ChkAdjustCalendar);
            this.flowLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel5.Location = new System.Drawing.Point(3, 15);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(260, 22);
            this.flowLayoutPanel5.TabIndex = 0;
            // 
            // ChkAdjustCalendar
            // 
            this.ChkAdjustCalendar.AutoSize = true;
            this.ChkAdjustCalendar.Checked = true;
            this.ChkAdjustCalendar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkAdjustCalendar.Location = new System.Drawing.Point(3, 3);
            this.ChkAdjustCalendar.Name = "ChkAdjustCalendar";
            this.ChkAdjustCalendar.Size = new System.Drawing.Size(180, 16);
            this.ChkAdjustCalendar.TabIndex = 0;
            this.ChkAdjustCalendar.Text = "カレンダーの列幅を自動調整する";
            this.ChkAdjustCalendar.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.flowLayoutPanel6);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 103);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(266, 45);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "詳細タブ";
            // 
            // flowLayoutPanel6
            // 
            this.flowLayoutPanel6.Controls.Add(this.label6);
            this.flowLayoutPanel6.Controls.Add(this.DspEditorThreshold);
            this.flowLayoutPanel6.Controls.Add(this.label5);
            this.flowLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel6.Location = new System.Drawing.Point(3, 15);
            this.flowLayoutPanel6.Name = "flowLayoutPanel6";
            this.flowLayoutPanel6.Size = new System.Drawing.Size(260, 27);
            this.flowLayoutPanel6.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "マウスによる編集時、";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DspEditorThreshold
            // 
            this.DspEditorThreshold.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DspEditorThreshold.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.DspEditorThreshold.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.DspEditorThreshold.Location = new System.Drawing.Point(112, 3);
            this.DspEditorThreshold.Name = "DspEditorThreshold";
            this.DspEditorThreshold.ShowUpDown = true;
            this.DspEditorThreshold.Size = new System.Drawing.Size(68, 19);
            this.DspEditorThreshold.TabIndex = 1;
            this.DspEditorThreshold.Value = new System.DateTime(2007, 5, 28, 0, 0, 0, 0);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(186, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "毎にする。";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ChkEditHistory);
            this.groupBox4.Location = new System.Drawing.Point(3, 154);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(266, 45);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "過去の編集";
            // 
            // ChkEditHistory
            // 
            this.ChkEditHistory.AutoSize = true;
            this.ChkEditHistory.Location = new System.Drawing.Point(6, 19);
            this.ChkEditHistory.Name = "ChkEditHistory";
            this.ChkEditHistory.Size = new System.Drawing.Size(143, 16);
            this.ChkEditHistory.TabIndex = 0;
            this.ChkEditHistory.Text = "過去の編集を可能にする";
            this.ChkEditHistory.UseVisualStyleBackColor = true;
            // 
            // TabAutoSettings
            // 
            this.TabAutoSettings.Controls.Add(this.tableLayoutPanel2);
            this.TabAutoSettings.Location = new System.Drawing.Point(4, 21);
            this.TabAutoSettings.Name = "TabAutoSettings";
            this.TabAutoSettings.Padding = new System.Windows.Forms.Padding(3);
            this.TabAutoSettings.Size = new System.Drawing.Size(278, 208);
            this.TabAutoSettings.TabIndex = 0;
            this.TabAutoSettings.Text = "自動設定";
            this.TabAutoSettings.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.GrpAutoSettings, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel3, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 62.7907F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 37.2093F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(272, 202);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.label1);
            this.flowLayoutPanel3.Controls.Add(this.NumAutoBuf);
            this.flowLayoutPanel3.Controls.Add(this.label2);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 73);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(266, 35);
            this.flowLayoutPanel3.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "当日から";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NumAutoBuf
            // 
            this.NumAutoBuf.Location = new System.Drawing.Point(56, 3);
            this.NumAutoBuf.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.NumAutoBuf.Name = "NumAutoBuf";
            this.NumAutoBuf.Size = new System.Drawing.Size(51, 19);
            this.NumAutoBuf.TabIndex = 7;
            this.NumAutoBuf.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(113, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "日以内は自動設定しない。";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TabPlugins
            // 
            this.TabPlugins.Controls.Add(this.BtnConfigPlugin);
            this.TabPlugins.Controls.Add(this.LstPlugins);
            this.TabPlugins.Location = new System.Drawing.Point(4, 21);
            this.TabPlugins.Name = "TabPlugins";
            this.TabPlugins.Padding = new System.Windows.Forms.Padding(3);
            this.TabPlugins.Size = new System.Drawing.Size(278, 208);
            this.TabPlugins.TabIndex = 2;
            this.TabPlugins.Text = "追加機能";
            this.TabPlugins.UseVisualStyleBackColor = true;
            // 
            // BtnConfigPlugin
            // 
            this.BtnConfigPlugin.Location = new System.Drawing.Point(232, 6);
            this.BtnConfigPlugin.Name = "BtnConfigPlugin";
            this.BtnConfigPlugin.Size = new System.Drawing.Size(39, 196);
            this.BtnConfigPlugin.TabIndex = 1;
            this.BtnConfigPlugin.Text = "設定";
            this.BtnConfigPlugin.UseVisualStyleBackColor = true;
            this.BtnConfigPlugin.Click += new System.EventHandler(this.BtnConfigPlugin_Click);
            // 
            // LstPlugins
            // 
            this.LstPlugins.DataSource = this.DsPlugins;
            this.LstPlugins.DisplayMember = "TblPlugins.ClmPluginDesc";
            this.LstPlugins.FormattingEnabled = true;
            this.LstPlugins.ItemHeight = 12;
            this.LstPlugins.Location = new System.Drawing.Point(6, 6);
            this.LstPlugins.Name = "LstPlugins";
            this.LstPlugins.Size = new System.Drawing.Size(220, 196);
            this.LstPlugins.TabIndex = 0;
            this.LstPlugins.ValueMember = "TblPlugins.ClmPlugin";
            this.LstPlugins.DoubleClick += new System.EventHandler(this.LstPlugins_DoubleClick);
            // 
            // DsPlugins
            // 
            this.DsPlugins.DataSetName = "DsPlugins";
            this.DsPlugins.Tables.AddRange(new System.Data.DataTable[] {
            this.TblPlugins});
            // 
            // TblPlugins
            // 
            this.TblPlugins.Columns.AddRange(new System.Data.DataColumn[] {
            this.ClmPlugin,
            this.ClmPluginDesc});
            this.TblPlugins.TableName = "TblPlugins";
            // 
            // ClmPlugin
            // 
            this.ClmPlugin.ColumnName = "ClmPlugin";
            this.ClmPlugin.DataType = typeof(TimeTableManager.Plugin.IPlugin);
            // 
            // ClmPluginDesc
            // 
            this.ClmPluginDesc.ColumnName = "ClmPluginDesc";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.BtnCancel);
            this.flowLayoutPanel1.Controls.Add(this.BtnOK);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 242);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(286, 28);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // BtnCancel
            // 
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(208, 3);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 99;
            this.BtnCancel.Text = "キャンセル";
            this.BtnCancel.UseVisualStyleBackColor = true;
            // 
            // BtnOK
            // 
            this.BtnOK.Location = new System.Drawing.Point(127, 3);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(75, 23);
            this.BtnOK.TabIndex = 98;
            this.BtnOK.Text = "OK";
            this.BtnOK.UseVisualStyleBackColor = true;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // FToolsOptionDialog
            // 
            this.AcceptButton = this.BtnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FToolsOptionDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "設定";
            this.Shown += new System.EventHandler(this.ToolsOptionDialog_Shown);
            this.GrpAutoSettings.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.TabGeneral.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumChangeMonth)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.flowLayoutPanel5.ResumeLayout(false);
            this.flowLayoutPanel5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.flowLayoutPanel6.ResumeLayout(false);
            this.flowLayoutPanel6.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.TabAutoSettings.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumAutoBuf)).EndInit();
            this.TabPlugins.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DsPlugins)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TblPlugins)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpAutoSettings;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.RadioButton RdoDefault;
        private System.Windows.Forms.RadioButton RdoWeekly;
        private System.Windows.Forms.RadioButton RdoMonthly;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage TabAutoSettings;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TabPage TabGeneral;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnOK;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown NumAutoBuf;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown NumChangeMonth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel6;
        private System.Windows.Forms.CheckBox ChkAdjustCalendar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker DspEditorThreshold;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton RdoMonthlyWeekly;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox ChkEditHistory;
        private System.Windows.Forms.TabPage TabPlugins;
        private System.Windows.Forms.Button BtnConfigPlugin;
        private System.Windows.Forms.ListBox LstPlugins;
        private System.Data.DataSet DsPlugins;
        private System.Data.DataTable TblPlugins;
        private System.Data.DataColumn ClmPlugin;
        private System.Data.DataColumn ClmPluginDesc;
    }
}