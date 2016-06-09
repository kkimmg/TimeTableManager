namespace TimeTableManager.Component {
    partial class UCheckList {
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
            this.ListGrid = new System.Windows.Forms.DataGridView();
            this.ClmResultType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmBody = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ListGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // ListGrid
            // 
            this.ListGrid.AllowUserToAddRows = false;
            this.ListGrid.AllowUserToDeleteRows = false;
            this.ListGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ListGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClmResultType,
            this.ClmDate,
            this.ClmBody});
            this.ListGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListGrid.Location = new System.Drawing.Point(0, 0);
            this.ListGrid.Name = "ListGrid";
            this.ListGrid.ReadOnly = true;
            this.ListGrid.RowHeadersVisible = false;
            this.ListGrid.RowHeadersWidth = 10;
            this.ListGrid.RowTemplate.Height = 21;
            this.ListGrid.Size = new System.Drawing.Size(521, 150);
            this.ListGrid.TabIndex = 0;
            this.ListGrid.VirtualMode = true;
            this.ListGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ListGrid_CellDoubleClick);
            this.ListGrid.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.ListGrid_CellValueNeeded);
            // 
            // ClmResultType
            // 
            this.ClmResultType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ClmResultType.HeaderText = "重要度";
            this.ClmResultType.Name = "ClmResultType";
            this.ClmResultType.ReadOnly = true;
            this.ClmResultType.Width = 70;
            // 
            // ClmDate
            // 
            this.ClmDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ClmDate.HeaderText = "日付";
            this.ClmDate.Name = "ClmDate";
            this.ClmDate.ReadOnly = true;
            this.ClmDate.Width = 70;
            // 
            // ClmBody
            // 
            this.ClmBody.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ClmBody.HeaderText = "内容";
            this.ClmBody.Name = "ClmBody";
            this.ClmBody.ReadOnly = true;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "重要度";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 66;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "日付";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 54;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "内容";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 54;
            // 
            // CheckList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ListGrid);
            this.Name = "CheckList";
            this.Size = new System.Drawing.Size(521, 150);
            ((System.ComponentModel.ISupportInitialize)(this.ListGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView ListGrid;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmResultType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmBody;

    }
}
