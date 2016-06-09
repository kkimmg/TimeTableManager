namespace TimeTableManager.Component {
    partial class UScheduleCalenderView {
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.CalenderView = new System.Windows.Forms.DataGridView();
            this.DateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RequirePatternColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.DsPatternComboBox = new System.Data.DataSet();
            this.TblPatternComboBox = new System.Data.DataTable();
            this.ClmPatternComboBox = new System.Data.DataColumn();
            this.ClmPatternNameComboBox = new System.Data.DataColumn();
            this.DsRequireComboBox = new System.Data.DataSet();
            this.TblRequireComboBox = new System.Data.DataTable();
            this.ClmRequireOfRequireCombo = new System.Data.DataColumn();
            this.ClmRequireOfRequireNameCombo = new System.Data.DataColumn();
            this.dataGridViewComboBoxColumn1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.CalenderView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsPatternComboBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TblPatternComboBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsRequireComboBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TblRequireComboBox)).BeginInit();
            this.SuspendLayout();
            // 
            // CalenderView
            // 
            this.CalenderView.AllowUserToAddRows = false;
            this.CalenderView.AllowUserToDeleteRows = false;
            this.CalenderView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.CalenderView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.CalenderView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CalenderView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DateColumn,
            this.RequirePatternColumn});
            this.CalenderView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CalenderView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.CalenderView.Location = new System.Drawing.Point(0, 0);
            this.CalenderView.Name = "CalenderView";
            this.CalenderView.RowHeadersWidth = 21;
            this.CalenderView.RowTemplate.Height = 21;
            this.CalenderView.Size = new System.Drawing.Size(572, 470);
            this.CalenderView.TabIndex = 0;
            this.CalenderView.VirtualMode = true;
            this.CalenderView.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.CalenderView_RowEnter);
            this.CalenderView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.CalenderView_CellValueNeeded);
            this.CalenderView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.CalenderView_CellValuePushed);
            this.CalenderView.CurrentCellChanged += new System.EventHandler(this.CalenderView_CurrentCellChanged);
            this.CalenderView.SelectionChanged += new System.EventHandler(this.CalenderView_SelectionChanged);
            // 
            // DateColumn
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "M";
            this.DateColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.DateColumn.HeaderText = "日付";
            this.DateColumn.Name = "DateColumn";
            this.DateColumn.ReadOnly = true;
            // 
            // RequirePatternColumn
            // 
            this.RequirePatternColumn.DataSource = this.DsPatternComboBox;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.RequirePatternColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.RequirePatternColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.RequirePatternColumn.DisplayStyleForCurrentCellOnly = true;
            this.RequirePatternColumn.HeaderText = "人員配置";
            this.RequirePatternColumn.Name = "RequirePatternColumn";
            // 
            // DsPatternComboBox
            // 
            this.DsPatternComboBox.DataSetName = "DsPatternComboBox";
            this.DsPatternComboBox.Tables.AddRange(new System.Data.DataTable[] {
            this.TblPatternComboBox});
            // 
            // TblPatternComboBox
            // 
            this.TblPatternComboBox.Columns.AddRange(new System.Data.DataColumn[] {
            this.ClmPatternComboBox,
            this.ClmPatternNameComboBox});
            this.TblPatternComboBox.Constraints.AddRange(new System.Data.Constraint[] {
            new System.Data.UniqueConstraint("Constraint1", new string[] {
                        "ClmPatternComboBox"}, true)});
            this.TblPatternComboBox.PrimaryKey = new System.Data.DataColumn[] {
        this.ClmPatternComboBox};
            this.TblPatternComboBox.TableName = "TblPatternComboBox";
            // 
            // ClmPatternComboBox
            // 
            this.ClmPatternComboBox.AllowDBNull = false;
            this.ClmPatternComboBox.Caption = "勤務シフト";
            this.ClmPatternComboBox.ColumnName = "ClmPatternComboBox";
            // 
            // ClmPatternNameComboBox
            // 
            this.ClmPatternNameComboBox.Caption = "勤務シフト";
            this.ClmPatternNameComboBox.ColumnName = "ClmPatternNameComboBox";
            // 
            // DsRequireComboBox
            // 
            this.DsRequireComboBox.DataSetName = "DsRequireComboBox";
            this.DsRequireComboBox.Tables.AddRange(new System.Data.DataTable[] {
            this.TblRequireComboBox});
            // 
            // TblRequireComboBox
            // 
            this.TblRequireComboBox.Columns.AddRange(new System.Data.DataColumn[] {
            this.ClmRequireOfRequireCombo,
            this.ClmRequireOfRequireNameCombo});
            this.TblRequireComboBox.Constraints.AddRange(new System.Data.Constraint[] {
            new System.Data.UniqueConstraint("Constraint1", new string[] {
                        "ClmRequireOfRequireCombo"}, true)});
            this.TblRequireComboBox.PrimaryKey = new System.Data.DataColumn[] {
        this.ClmRequireOfRequireCombo};
            this.TblRequireComboBox.TableName = "TblRequireComboBox";
            // 
            // ClmRequireOfRequireCombo
            // 
            this.ClmRequireOfRequireCombo.AllowDBNull = false;
            this.ClmRequireOfRequireCombo.Caption = "人員配置（オブジェクト）";
            this.ClmRequireOfRequireCombo.ColumnName = "ClmRequireOfRequireCombo";
            // 
            // ClmRequireOfRequireNameCombo
            // 
            this.ClmRequireOfRequireNameCombo.Caption = "人員配置";
            this.ClmRequireOfRequireNameCombo.ColumnName = "ClmRequireOfRequireNameCombo";
            // 
            // dataGridViewComboBoxColumn1
            // 
            this.dataGridViewComboBoxColumn1.DataSource = this.DsPatternComboBox;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewComboBoxColumn1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewComboBoxColumn1.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.dataGridViewComboBoxColumn1.DisplayStyleForCurrentCellOnly = true;
            this.dataGridViewComboBoxColumn1.HeaderText = "人員配置";
            this.dataGridViewComboBoxColumn1.Name = "dataGridViewComboBoxColumn1";
            // 
            // ScheduleCalenderView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CalenderView);
            this.Name = "ScheduleCalenderView";
            this.Size = new System.Drawing.Size(572, 470);
            ((System.ComponentModel.ISupportInitialize)(this.CalenderView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsPatternComboBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TblPatternComboBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsRequireComboBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TblRequireComboBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView CalenderView;
        private System.Data.DataSet DsRequireComboBox;
        private System.Data.DataTable TblRequireComboBox;
        private System.Data.DataColumn ClmRequireOfRequireCombo;
        private System.Data.DataColumn ClmRequireOfRequireNameCombo;
        private System.Data.DataTable TblPatternComboBox;
        private System.Data.DataColumn ClmPatternComboBox;
        private System.Data.DataColumn ClmPatternNameComboBox;
        private System.Data.DataSet DsPatternComboBox;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn RequirePatternColumn;
    }
}
