namespace TimeTableManager.UI {
    partial class FImportDialog {
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose (bool disposing) {
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
        private void InitializeComponent () {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FImportDialog));
            this.DsImportMember = new System.Data.DataSet();
            this.TblImportMember = new System.Data.DataTable();
            this.ClmImportMember = new System.Data.DataColumn();
            this.ClmImportMemberName = new System.Data.DataColumn();
            this.DsImportPattern = new System.Data.DataSet();
            this.TblImportPattern = new System.Data.DataTable();
            this.ClmImportPattern = new System.Data.DataColumn();
            this.ClmImportPatternName = new System.Data.DataColumn();
            this.DsImportRequires = new System.Data.DataSet();
            this.TblImportRequires = new System.Data.DataTable();
            this.ClmImportRequires = new System.Data.DataColumn();
            this.ClmImportRequiresName = new System.Data.DataColumn();
            this.DsImportDayOff = new System.Data.DataSet();
            this.TblImportDayOff = new System.Data.DataTable();
            this.ClmImportDayOff = new System.Data.DataColumn();
            this.ClmImportDayOffName = new System.Data.DataColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.LstImportMember = new System.Windows.Forms.CheckedListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.LstImportPattern = new System.Windows.Forms.CheckedListBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.LstImportRequires = new System.Windows.Forms.CheckedListBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.LstImportDayOff = new System.Windows.Forms.CheckedListBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnOK = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TxtSourceFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DsImportMember)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TblImportMember)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsImportPattern)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TblImportPattern)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsImportRequires)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TblImportRequires)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsImportDayOff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TblImportDayOff)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DsImportMember
            // 
            this.DsImportMember.DataSetName = "DsImportMember";
            this.DsImportMember.Tables.AddRange(new System.Data.DataTable[] {
            this.TblImportMember});
            // 
            // TblImportMember
            // 
            this.TblImportMember.Columns.AddRange(new System.Data.DataColumn[] {
            this.ClmImportMember,
            this.ClmImportMemberName});
            this.TblImportMember.TableName = "TblImportMember";
            // 
            // ClmImportMember
            // 
            this.ClmImportMember.ColumnName = "ClmImportMember";
            this.ClmImportMember.DataType = typeof(TimeTableManager.Element.BMember);
            // 
            // ClmImportMemberName
            // 
            this.ClmImportMemberName.ColumnName = "ClmImportMemberName";
            // 
            // DsImportPattern
            // 
            this.DsImportPattern.DataSetName = "DsImportPattern";
            this.DsImportPattern.Tables.AddRange(new System.Data.DataTable[] {
            this.TblImportPattern});
            // 
            // TblImportPattern
            // 
            this.TblImportPattern.Columns.AddRange(new System.Data.DataColumn[] {
            this.ClmImportPattern,
            this.ClmImportPatternName});
            this.TblImportPattern.TableName = "TblImportPattern";
            // 
            // ClmImportPattern
            // 
            this.ClmImportPattern.ColumnName = "ClmImportPattern";
            this.ClmImportPattern.DataType = typeof(TimeTableManager.Element.BPattern);
            // 
            // ClmImportPatternName
            // 
            this.ClmImportPatternName.ColumnName = "ClmImportPatternName";
            // 
            // DsImportRequires
            // 
            this.DsImportRequires.DataSetName = "DsImportRequires";
            this.DsImportRequires.Tables.AddRange(new System.Data.DataTable[] {
            this.TblImportRequires});
            // 
            // TblImportRequires
            // 
            this.TblImportRequires.Columns.AddRange(new System.Data.DataColumn[] {
            this.ClmImportRequires,
            this.ClmImportRequiresName});
            this.TblImportRequires.TableName = "TblImportRequires";
            // 
            // ClmImportRequires
            // 
            this.ClmImportRequires.ColumnName = "ClmImportRequires";
            this.ClmImportRequires.DataType = typeof(TimeTableManager.Element.BRequirePatterns);
            // 
            // ClmImportRequiresName
            // 
            this.ClmImportRequiresName.ColumnName = "ClmImportRequiresName";
            // 
            // DsImportDayOff
            // 
            this.DsImportDayOff.DataSetName = "DsImportDayOff";
            this.DsImportDayOff.Tables.AddRange(new System.Data.DataTable[] {
            this.TblImportDayOff});
            // 
            // TblImportDayOff
            // 
            this.TblImportDayOff.Columns.AddRange(new System.Data.DataColumn[] {
            this.ClmImportDayOff,
            this.ClmImportDayOffName});
            this.TblImportDayOff.TableName = "TblImportDayOff";
            // 
            // ClmImportDayOff
            // 
            this.ClmImportDayOff.ColumnName = "ClmImportDayOff";
            this.ClmImportDayOff.DataType = typeof(TimeTableManager.Element.BDayOff);
            // 
            // ClmImportDayOffName
            // 
            this.ClmImportDayOffName.ColumnName = "ClmImportDayOffName";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 31);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(394, 211);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.LstImportMember);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(386, 186);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "メンバー";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // LstImportMember
            // 
            this.LstImportMember.DataSource = this.TblImportMember;
            this.LstImportMember.DisplayMember = "ClmImportMemberName";
            this.LstImportMember.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LstImportMember.FormattingEnabled = true;
            this.LstImportMember.Location = new System.Drawing.Point(3, 3);
            this.LstImportMember.Name = "LstImportMember";
            this.LstImportMember.Size = new System.Drawing.Size(380, 172);
            this.LstImportMember.TabIndex = 0;
            this.LstImportMember.ValueMember = "ClmImportMember";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.LstImportPattern);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(386, 186);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "勤務シフト";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // LstImportPattern
            // 
            this.LstImportPattern.DataSource = this.TblImportPattern;
            this.LstImportPattern.DisplayMember = "ClmImportPatternName";
            this.LstImportPattern.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LstImportPattern.FormattingEnabled = true;
            this.LstImportPattern.Location = new System.Drawing.Point(3, 3);
            this.LstImportPattern.Name = "LstImportPattern";
            this.LstImportPattern.Size = new System.Drawing.Size(380, 172);
            this.LstImportPattern.TabIndex = 0;
            this.LstImportPattern.ValueMember = "ClmImportPattern";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.LstImportRequires);
            this.tabPage3.Location = new System.Drawing.Point(4, 21);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(386, 186);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "人員配置";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // LstImportRequires
            // 
            this.LstImportRequires.DataSource = this.TblImportRequires;
            this.LstImportRequires.DisplayMember = "ClmImportRequiresName";
            this.LstImportRequires.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LstImportRequires.FormattingEnabled = true;
            this.LstImportRequires.Location = new System.Drawing.Point(3, 3);
            this.LstImportRequires.Name = "LstImportRequires";
            this.LstImportRequires.Size = new System.Drawing.Size(380, 172);
            this.LstImportRequires.TabIndex = 0;
            this.LstImportRequires.ValueMember = "ClmImportRequires";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.LstImportDayOff);
            this.tabPage4.Location = new System.Drawing.Point(4, 21);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(386, 186);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "休日";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // LstImportDayOff
            // 
            this.LstImportDayOff.DataSource = this.TblImportDayOff;
            this.LstImportDayOff.DisplayMember = "ClmImportDayOffName";
            this.LstImportDayOff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LstImportDayOff.FormattingEnabled = true;
            this.LstImportDayOff.Location = new System.Drawing.Point(3, 3);
            this.LstImportDayOff.Name = "LstImportDayOff";
            this.LstImportDayOff.Size = new System.Drawing.Size(380, 172);
            this.LstImportDayOff.TabIndex = 0;
            this.LstImportDayOff.ValueMember = "ClmImportDayOff";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.BtnCancel);
            this.flowLayoutPanel1.Controls.Add(this.BtnOK);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 242);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flowLayoutPanel1.Size = new System.Drawing.Size(394, 33);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // BtnCancel
            // 
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(316, 3);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 1;
            this.BtnCancel.Text = "キャンセル";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnOK
            // 
            this.BtnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnOK.Location = new System.Drawing.Point(216, 3);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(94, 23);
            this.BtnOK.TabIndex = 0;
            this.BtnOK.Text = "インポート開始";
            this.BtnOK.UseVisualStyleBackColor = true;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TxtSourceFile);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(394, 31);
            this.panel1.TabIndex = 2;
            // 
            // TxtSourceFile
            // 
            this.TxtSourceFile.Location = new System.Drawing.Point(72, 6);
            this.TxtSourceFile.Name = "TxtSourceFile";
            this.TxtSourceFile.ReadOnly = true;
            this.TxtSourceFile.Size = new System.Drawing.Size(318, 19);
            this.TxtSourceFile.TabIndex = 1;
            this.TxtSourceFile.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "インポート元";
            // 
            // FImportDialog
            // 
            this.AcceptButton = this.BtnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(394, 275);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FImportDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "インポート";
            this.Shown += new System.EventHandler(this.FImportDialog_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.DsImportMember)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TblImportMember)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsImportPattern)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TblImportPattern)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsImportRequires)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TblImportRequires)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsImportDayOff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TblImportDayOff)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Data.DataSet DsImportMember;
        private System.Data.DataSet DsImportPattern;
        private System.Data.DataSet DsImportRequires;
        private System.Data.DataSet DsImportDayOff;
        private System.Data.DataTable TblImportMember;
        private System.Data.DataColumn ClmImportMember;
        private System.Data.DataColumn ClmImportMemberName;
        private System.Data.DataTable TblImportPattern;
        private System.Data.DataColumn ClmImportPattern;
        private System.Data.DataColumn ClmImportPatternName;
        private System.Data.DataTable TblImportRequires;
        private System.Data.DataColumn ClmImportRequires;
        private System.Data.DataColumn ClmImportRequiresName;
        private System.Data.DataTable TblImportDayOff;
        private System.Data.DataColumn ClmImportDayOff;
        private System.Data.DataColumn ClmImportDayOffName;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button BtnOK;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtSourceFile;
        private System.Windows.Forms.CheckedListBox LstImportMember;
        private System.Windows.Forms.CheckedListBox LstImportPattern;
        private System.Windows.Forms.CheckedListBox LstImportRequires;
        private System.Windows.Forms.CheckedListBox LstImportDayOff;
    }
}