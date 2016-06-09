namespace TimeTableManager.UI {
    partial class FCSVExport {
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
            this.label1 = new System.Windows.Forms.Label();
            this.TxtOutFile = new System.Windows.Forms.TextBox();
            this.BtnOutFile = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.BtnExport = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LstItemList = new System.Windows.Forms.CheckedListBox();
            this.TblOutputItems = new System.Data.DataTable();
            this.ClmItem = new System.Data.DataColumn();
            this.ClmItemHead = new System.Data.DataColumn();
            this.DsOutputItems = new System.Data.DataSet();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TblOutputItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsOutputItems)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "出力ファイル";
            // 
            // TxtOutFile
            // 
            this.TxtOutFile.Location = new System.Drawing.Point(83, 13);
            this.TxtOutFile.Name = "TxtOutFile";
            this.TxtOutFile.Size = new System.Drawing.Size(246, 19);
            this.TxtOutFile.TabIndex = 1;
            // 
            // BtnOutFile
            // 
            this.BtnOutFile.AutoSize = true;
            this.BtnOutFile.Location = new System.Drawing.Point(335, 12);
            this.BtnOutFile.Name = "BtnOutFile";
            this.BtnOutFile.Size = new System.Drawing.Size(47, 23);
            this.BtnOutFile.TabIndex = 2;
            this.BtnOutFile.Text = "参照";
            this.BtnOutFile.UseVisualStyleBackColor = true;
            this.BtnOutFile.Click += new System.EventHandler(this.BtnOutFile_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "csv";
            this.saveFileDialog1.Filter = "CSVファイル|*.csv|全てのファイル|*.*";
            // 
            // BtnExport
            // 
            this.BtnExport.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnExport.Location = new System.Drawing.Point(226, 240);
            this.BtnExport.Name = "BtnExport";
            this.BtnExport.Size = new System.Drawing.Size(75, 23);
            this.BtnExport.TabIndex = 3;
            this.BtnExport.Text = "エクスポート";
            this.BtnExport.UseVisualStyleBackColor = true;
            this.BtnExport.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(307, 240);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 4;
            this.BtnCancel.Text = "キャンセル";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LstItemList);
            this.groupBox1.Location = new System.Drawing.Point(16, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(366, 193);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "出力項目の選択";
            // 
            // LstItemList
            // 
            this.LstItemList.CheckOnClick = true;
            this.LstItemList.DataSource = this.TblOutputItems;
            this.LstItemList.DisplayMember = "ClmItemHead";
            this.LstItemList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LstItemList.Location = new System.Drawing.Point(3, 15);
            this.LstItemList.Name = "LstItemList";
            this.LstItemList.Size = new System.Drawing.Size(360, 172);
            this.LstItemList.TabIndex = 0;
            this.LstItemList.ValueMember = "ClmItem";
            // 
            // TblOutputItems
            // 
            this.TblOutputItems.Columns.AddRange(new System.Data.DataColumn[] {
            this.ClmItem,
            this.ClmItemHead});
            this.TblOutputItems.TableName = "TblOutputItems";
            // 
            // ClmItem
            // 
            this.ClmItem.Caption = "出力項目";
            this.ClmItem.ColumnName = "ClmItem";
            this.ClmItem.DataType = typeof(TimeTableManager.UI.EnmCSVItem);
            // 
            // ClmItemHead
            // 
            this.ClmItemHead.Caption = "出力項目";
            this.ClmItemHead.ColumnName = "ClmItemHead";
            // 
            // DsOutputItems
            // 
            this.DsOutputItems.DataSetName = "DsOutputItems";
            this.DsOutputItems.Tables.AddRange(new System.Data.DataTable[] {
            this.TblOutputItems});
            // 
            // FCVSExport
            // 
            this.AcceptButton = this.BtnExport;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(394, 275);
            this.Controls.Add(this.TxtOutFile);
            this.Controls.Add(this.BtnOutFile);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnExport);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FCVSExport";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "エクスポート";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TblOutputItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsOutputItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtOutFile;
        private System.Windows.Forms.Button BtnOutFile;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button BtnExport;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckedListBox LstItemList;
        private System.Data.DataSet DsOutputItems;
        private System.Data.DataTable TblOutputItems;
        private System.Data.DataColumn ClmItem;
        private System.Data.DataColumn ClmItemHead;
    }
}