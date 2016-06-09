namespace TimeTableManager.Component {
    /// <summary>エディタ部分のパーシャルクラス
    /// </summary>
    partial class UMultiEditor {
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
            this.components = new System.ComponentModel.Container();
            this.DsPatten = new System.Data.DataSet();
            this.TblPattern = new System.Data.DataTable();
            this.ClmDsPattern = new System.Data.DataColumn();
            this.ClmPatternName = new System.Data.DataColumn();
            this.BodyTable = new System.Windows.Forms.DataGridView();
            this.ClmMember = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CmsMember = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TsmiAddMember = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmiEditMember = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmiRemoveMember = new System.Windows.Forms.ToolStripMenuItem();
            this.ClmPattern = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.CmsPattern = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TsmiAddPattern = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmiEditPattern = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmiRemovePattern = new System.Windows.Forms.ToolStripMenuItem();
            this.ClmBarChart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CmsBarChart = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TsmiComment = new System.Windows.Forms.ToolStripMenuItem();
            this.CmsBodyTable = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TmsiAddMemberOnly = new System.Windows.Forms.ToolStripMenuItem();
            this.TmsiAddPatternOnly = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewComboBoxColumn1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DsPatten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TblPattern)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BodyTable)).BeginInit();
            this.CmsMember.SuspendLayout();
            this.CmsPattern.SuspendLayout();
            this.CmsBarChart.SuspendLayout();
            this.CmsBodyTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // DsPatten
            // 
            this.DsPatten.DataSetName = "DsPatten";
            this.DsPatten.Tables.AddRange(new System.Data.DataTable[] {
            this.TblPattern});
            // 
            // TblPattern
            // 
            this.TblPattern.Columns.AddRange(new System.Data.DataColumn[] {
            this.ClmDsPattern,
            this.ClmPatternName});
            this.TblPattern.Constraints.AddRange(new System.Data.Constraint[] {
            new System.Data.UniqueConstraint("Constraint1", new string[] {
                        "ClmDsPattern"}, true)});
            this.TblPattern.PrimaryKey = new System.Data.DataColumn[] {
        this.ClmDsPattern};
            this.TblPattern.TableName = "TblPattern";
            // 
            // ClmDsPattern
            // 
            this.ClmDsPattern.AllowDBNull = false;
            this.ClmDsPattern.ColumnName = "ClmDsPattern";
            // 
            // ClmPatternName
            // 
            this.ClmPatternName.ColumnName = "ClmPatternName";
            // 
            // BodyTable
            // 
            this.BodyTable.AllowUserToAddRows = false;
            this.BodyTable.AllowUserToDeleteRows = false;
            this.BodyTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BodyTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClmMember,
            this.ClmPattern,
            this.ClmBarChart});
            this.BodyTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BodyTable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.BodyTable.Location = new System.Drawing.Point(0, 0);
            this.BodyTable.Name = "BodyTable";
            this.BodyTable.RowHeadersVisible = false;
            this.BodyTable.RowTemplate.Height = 21;
            this.BodyTable.Size = new System.Drawing.Size(636, 230);
            this.BodyTable.TabIndex = 2;
            this.BodyTable.VirtualMode = true;
            this.BodyTable.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.BodyTable_CellMouseDown);
            this.BodyTable.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.BodyTable_CellMouseMove);
            this.BodyTable.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.BodyTable_CellValueNeeded);
            this.BodyTable.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.BodyTable_CellPainting);
            this.BodyTable.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.BodyTable_CellMouseUp);
            this.BodyTable.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.BodyTable_CellMouseDoubleClick);
            this.BodyTable.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.BodyTable_CellValuePushed);
            this.BodyTable.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.BodyTable_CellEnter);
            // 
            // ClmMember
            // 
            this.ClmMember.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ClmMember.ContextMenuStrip = this.CmsMember;
            this.ClmMember.HeaderText = "メンバー";
            this.ClmMember.Name = "ClmMember";
            this.ClmMember.ReadOnly = true;
            // 
            // CmsMember
            // 
            this.CmsMember.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsmiAddMember,
            this.TsmiEditMember,
            this.TsmiRemoveMember});
            this.CmsMember.Name = "CmsMember";
            this.CmsMember.Size = new System.Drawing.Size(147, 70);
            // 
            // TsmiAddMember
            // 
            this.TsmiAddMember.Name = "TsmiAddMember";
            this.TsmiAddMember.Size = new System.Drawing.Size(146, 22);
            this.TsmiAddMember.Text = "メンバーの追加";
            this.TsmiAddMember.Click += new System.EventHandler(this.TsmiAddMember_Click);
            // 
            // TsmiEditMember
            // 
            this.TsmiEditMember.Name = "TsmiEditMember";
            this.TsmiEditMember.Size = new System.Drawing.Size(146, 22);
            this.TsmiEditMember.Text = "メンバーの修正";
            this.TsmiEditMember.Click += new System.EventHandler(this.TsmiEditMember_Click);
            // 
            // TsmiRemoveMember
            // 
            this.TsmiRemoveMember.Name = "TsmiRemoveMember";
            this.TsmiRemoveMember.Size = new System.Drawing.Size(146, 22);
            this.TsmiRemoveMember.Text = "メンバーの削除";
            this.TsmiRemoveMember.Click += new System.EventHandler(this.TsmiRemoveMember_Click);
            // 
            // ClmPattern
            // 
            this.ClmPattern.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ClmPattern.ContextMenuStrip = this.CmsPattern;
            this.ClmPattern.DataSource = this.DsPatten;
            this.ClmPattern.DisplayMember = "TblPattern.ClmPatternName";
            this.ClmPattern.DisplayStyleForCurrentCellOnly = true;
            this.ClmPattern.HeaderText = "勤務シフト";
            this.ClmPattern.Name = "ClmPattern";
            this.ClmPattern.ValueMember = "TblPattern.ClmDsPattern";
            // 
            // CmsPattern
            // 
            this.CmsPattern.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsmiAddPattern,
            this.TsmiEditPattern,
            this.TsmiRemovePattern});
            this.CmsPattern.Name = "CmsPattern";
            this.CmsPattern.Size = new System.Drawing.Size(147, 70);
            // 
            // TsmiAddPattern
            // 
            this.TsmiAddPattern.Name = "TsmiAddPattern";
            this.TsmiAddPattern.Size = new System.Drawing.Size(146, 22);
            this.TsmiAddPattern.Text = "勤務シフトの追加";
            this.TsmiAddPattern.Click += new System.EventHandler(this.TsmiAddPattern_Click);
            // 
            // TsmiEditPattern
            // 
            this.TsmiEditPattern.Name = "TsmiEditPattern";
            this.TsmiEditPattern.Size = new System.Drawing.Size(146, 22);
            this.TsmiEditPattern.Text = "勤務シフトの修正";
            this.TsmiEditPattern.Click += new System.EventHandler(this.TsmiEditPattern_Click);
            // 
            // TsmiRemovePattern
            // 
            this.TsmiRemovePattern.Name = "TsmiRemovePattern";
            this.TsmiRemovePattern.Size = new System.Drawing.Size(146, 22);
            this.TsmiRemovePattern.Text = "勤務シフトの削除";
            this.TsmiRemovePattern.Click += new System.EventHandler(this.TsmiRemovePattern_Click);
            // 
            // ClmBarChart
            // 
            this.ClmBarChart.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ClmBarChart.ContextMenuStrip = this.CmsBarChart;
            this.ClmBarChart.HeaderText = "";
            this.ClmBarChart.Name = "ClmBarChart";
            this.ClmBarChart.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ClmBarChart.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // CmsBarChart
            // 
            this.CmsBarChart.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsmiComment});
            this.CmsBarChart.Name = "CmsBarChart";
            this.CmsBarChart.Size = new System.Drawing.Size(109, 26);
            // 
            // TsmiComment
            // 
            this.TsmiComment.Name = "TsmiComment";
            this.TsmiComment.Size = new System.Drawing.Size(108, 22);
            this.TsmiComment.Text = "コメント";
            this.TsmiComment.Click += new System.EventHandler(this.TsmiComment_Click);
            // 
            // CmsBodyTable
            // 
            this.CmsBodyTable.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TmsiAddMemberOnly,
            this.TmsiAddPatternOnly});
            this.CmsBodyTable.Name = "CmsBodyTable";
            this.CmsBodyTable.Size = new System.Drawing.Size(147, 48);
            // 
            // TmsiAddMemberOnly
            // 
            this.TmsiAddMemberOnly.Name = "TmsiAddMemberOnly";
            this.TmsiAddMemberOnly.Size = new System.Drawing.Size(146, 22);
            this.TmsiAddMemberOnly.Text = "メンバーの追加";
            this.TmsiAddMemberOnly.Click += new System.EventHandler(this.TsmiAddMember_Click);
            // 
            // TmsiAddPatternOnly
            // 
            this.TmsiAddPatternOnly.Name = "TmsiAddPatternOnly";
            this.TmsiAddPatternOnly.Size = new System.Drawing.Size(146, 22);
            this.TmsiAddPatternOnly.Text = "勤務シフトの追加";
            this.TmsiAddPatternOnly.Click += new System.EventHandler(this.TsmiAddPattern_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn1.HeaderText = "メンバー";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewComboBoxColumn1
            // 
            this.dataGridViewComboBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewComboBoxColumn1.DataSource = this.DsPatten;
            this.dataGridViewComboBoxColumn1.DisplayMember = "TblPattern.ClmPatternName";
            this.dataGridViewComboBoxColumn1.DisplayStyleForCurrentCellOnly = true;
            this.dataGridViewComboBoxColumn1.HeaderText = "勤務シフト";
            this.dataGridViewComboBoxColumn1.Name = "dataGridViewComboBoxColumn1";
            this.dataGridViewComboBoxColumn1.ValueMember = "TblPattern.ClmDsPattern";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.HeaderText = "";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // MultiEditor2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.BodyTable);
            this.Name = "MultiEditor2";
            this.Size = new System.Drawing.Size(636, 230);
            ((System.ComponentModel.ISupportInitialize)(this.DsPatten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TblPattern)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BodyTable)).EndInit();
            this.CmsMember.ResumeLayout(false);
            this.CmsPattern.ResumeLayout(false);
            this.CmsBarChart.ResumeLayout(false);
            this.CmsBodyTable.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Data.DataSet DsPatten;
        private System.Data.DataTable TblPattern;
        private System.Data.DataColumn ClmDsPattern;
        private System.Data.DataColumn ClmPatternName;
        private System.Windows.Forms.DataGridView BodyTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.ContextMenuStrip CmsMember;
        private System.Windows.Forms.ContextMenuStrip CmsPattern;
        private System.Windows.Forms.ContextMenuStrip CmsBarChart;
        private System.Windows.Forms.ToolStripMenuItem TsmiAddMember;
        private System.Windows.Forms.ToolStripMenuItem TsmiEditMember;
        private System.Windows.Forms.ToolStripMenuItem TsmiRemoveMember;
        private System.Windows.Forms.ToolStripMenuItem TsmiAddPattern;
        private System.Windows.Forms.ToolStripMenuItem TsmiEditPattern;
        private System.Windows.Forms.ToolStripMenuItem TsmiRemovePattern;
        private System.Windows.Forms.ToolStripMenuItem TsmiComment;
        private System.Windows.Forms.ContextMenuStrip CmsBodyTable;
        private System.Windows.Forms.ToolStripMenuItem TmsiAddMemberOnly;
        private System.Windows.Forms.ToolStripMenuItem TmsiAddPatternOnly;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmMember;
        private System.Windows.Forms.DataGridViewComboBoxColumn ClmPattern;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmBarChart;
    }
}
