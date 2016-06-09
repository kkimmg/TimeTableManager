namespace TimeTableManager.Component {
    /// <summary>乱数化されたスケジュール日の表示／編集コンポーネント
    /// </summary>
    partial class UFavoriteEditor {
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

        #region コンポーネント デザイナで生成されたコード

        /// <summary> 
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent () {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.LeftPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.MemberPatternView = new System.Windows.Forms.DataGridView();
            this.RightPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.PatternMemberView = new System.Windows.Forms.DataGridView();
            this.DsMembers = new System.Data.DataSet();
            this.TblMembers = new System.Data.DataTable();
            this.ClmMember = new System.Data.DataColumn();
            this.ClmMemberName = new System.Data.DataColumn();
            this.DsPattern = new System.Data.DataSet();
            this.TblPatterns = new System.Data.DataTable();
            this.ClmPattern = new System.Data.DataColumn();
            this.ClmPatternName = new System.Data.DataColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LeftMemberColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RightPatternColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.LeftPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MemberPatternView)).BeginInit();
            this.RightPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PatternMemberView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsMembers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TblMembers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsPattern)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TblPatterns)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.LeftPanel);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.RightPanel);
            this.splitContainer1.Size = new System.Drawing.Size(629, 191);
            this.splitContainer1.SplitterDistance = 300;
            this.splitContainer1.TabIndex = 0;
            // 
            // LeftPanel
            // 
            this.LeftPanel.ColumnCount = 1;
            this.LeftPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LeftPanel.Controls.Add(this.label1, 0, 0);
            this.LeftPanel.Controls.Add(this.MemberPatternView, 0, 1);
            this.LeftPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LeftPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftPanel.Name = "LeftPanel";
            this.LeftPanel.RowCount = 2;
            this.LeftPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.LeftPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LeftPanel.Size = new System.Drawing.Size(300, 191);
            this.LeftPanel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(294, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "メンバーのシフトの優先順位";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MemberPatternView
            // 
            this.MemberPatternView.AllowUserToAddRows = false;
            this.MemberPatternView.AllowUserToDeleteRows = false;
            this.MemberPatternView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.MemberPatternView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MemberPatternView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LeftMemberColumn});
            this.MemberPatternView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MemberPatternView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.MemberPatternView.Location = new System.Drawing.Point(3, 15);
            this.MemberPatternView.Name = "MemberPatternView";
            this.MemberPatternView.RowHeadersVisible = false;
            this.MemberPatternView.RowTemplate.Height = 21;
            this.MemberPatternView.Size = new System.Drawing.Size(294, 173);
            this.MemberPatternView.TabIndex = 1;
            this.MemberPatternView.VirtualMode = true;
            this.MemberPatternView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.MemberPatternView_CellValueNeeded);
            this.MemberPatternView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.MemberPatternView_CellValuePushed);
            // 
            // RightPanel
            // 
            this.RightPanel.ColumnCount = 1;
            this.RightPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.RightPanel.Controls.Add(this.label2, 0, 0);
            this.RightPanel.Controls.Add(this.PatternMemberView, 0, 1);
            this.RightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightPanel.Location = new System.Drawing.Point(0, 0);
            this.RightPanel.Name = "RightPanel";
            this.RightPanel.RowCount = 2;
            this.RightPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.RightPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.RightPanel.Size = new System.Drawing.Size(325, 191);
            this.RightPanel.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(319, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "勤務シフトのメンバーの優先順位";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PatternMemberView
            // 
            this.PatternMemberView.AllowUserToAddRows = false;
            this.PatternMemberView.AllowUserToDeleteRows = false;
            this.PatternMemberView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.PatternMemberView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PatternMemberView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RightPatternColumn});
            this.PatternMemberView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PatternMemberView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.PatternMemberView.Location = new System.Drawing.Point(3, 15);
            this.PatternMemberView.Name = "PatternMemberView";
            this.PatternMemberView.RowHeadersVisible = false;
            this.PatternMemberView.RowTemplate.Height = 21;
            this.PatternMemberView.Size = new System.Drawing.Size(319, 173);
            this.PatternMemberView.TabIndex = 1;
            this.PatternMemberView.VirtualMode = true;
            this.PatternMemberView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.PatternMemberView_CellValueNeeded);
            this.PatternMemberView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.PatternMemberView_CellValuePushed);
            // 
            // DsMembers
            // 
            this.DsMembers.DataSetName = "DsMembers";
            this.DsMembers.Tables.AddRange(new System.Data.DataTable[] {
            this.TblMembers});
            // 
            // TblMembers
            // 
            this.TblMembers.Columns.AddRange(new System.Data.DataColumn[] {
            this.ClmMember,
            this.ClmMemberName});
            this.TblMembers.TableName = "TblMembers";
            // 
            // ClmMember
            // 
            this.ClmMember.Caption = "メンバー";
            this.ClmMember.ColumnName = "ClmMember";
            // 
            // ClmMemberName
            // 
            this.ClmMemberName.Caption = "メンバー";
            this.ClmMemberName.ColumnName = "ClmMemberName";
            // 
            // DsPattern
            // 
            this.DsPattern.DataSetName = "DsPattern";
            this.DsPattern.Tables.AddRange(new System.Data.DataTable[] {
            this.TblPatterns});
            // 
            // TblPatterns
            // 
            this.TblPatterns.Columns.AddRange(new System.Data.DataColumn[] {
            this.ClmPattern,
            this.ClmPatternName});
            this.TblPatterns.TableName = "TblPatterns";
            // 
            // ClmPattern
            // 
            this.ClmPattern.Caption = "勤務シフト";
            this.ClmPattern.ColumnName = "ClmPattern";
            // 
            // ClmPatternName
            // 
            this.ClmPatternName.Caption = "勤務シフト";
            this.ClmPatternName.ColumnName = "ClmPatternName";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "メンバー";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 291;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "勤務シフト";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 316;
            // 
            // LeftMemberColumn
            // 
            this.LeftMemberColumn.HeaderText = "メンバー";
            this.LeftMemberColumn.Name = "LeftMemberColumn";
            this.LeftMemberColumn.ReadOnly = true;
            // 
            // RightPatternColumn
            // 
            this.RightPatternColumn.HeaderText = "勤務シフト";
            this.RightPatternColumn.Name = "RightPatternColumn";
            this.RightPatternColumn.ReadOnly = true;
            // 
            // FavoriteEditor2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "FavoriteEditor2";
            this.Size = new System.Drawing.Size(629, 191);
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.FavoriteEditor2_Layout);
            this.Resize += new System.EventHandler(this.FavoriteEditor2_Resize);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.LeftPanel.ResumeLayout(false);
            this.LeftPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MemberPatternView)).EndInit();
            this.RightPanel.ResumeLayout(false);
            this.RightPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PatternMemberView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsMembers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TblMembers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsPattern)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TblPatterns)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel LeftPanel;
        private System.Windows.Forms.TableLayoutPanel RightPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView MemberPatternView;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView PatternMemberView;
        private System.Data.DataSet DsMembers;
        private System.Data.DataTable TblMembers;
        private System.Data.DataSet DsPattern;
        private System.Data.DataColumn ClmMember;
        private System.Data.DataColumn ClmMemberName;
        private System.Data.DataTable TblPatterns;
        private System.Data.DataColumn ClmPattern;
        private System.Data.DataColumn ClmPatternName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn LeftMemberColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn RightPatternColumn;
    }
}
