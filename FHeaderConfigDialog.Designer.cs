namespace TimeTableManager.UI {
    partial class FHeaderConfigDialog {
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
            this.dlgLeftFont = new System.Windows.Forms.FontDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbLeftText = new System.Windows.Forms.ComboBox();
            this.btnLeftFont = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbCenterText = new System.Windows.Forms.ComboBox();
            this.btnCenterFont = new System.Windows.Forms.Button();
            this.cmbRightText = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRightFont = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbDateFormat = new System.Windows.Forms.ComboBox();
            this.txtPageFormat = new System.Windows.Forms.TextBox();
            this.txtPageAllFormat = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dlgCenterFont = new System.Windows.Forms.FontDialog();
            this.dlgRightFont = new System.Windows.Forms.FontDialog();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dlgLeftFont
            // 
            this.dlgLeftFont.AllowScriptChange = false;
            this.dlgLeftFont.ShowEffects = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "左側";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbLeftText
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cmbLeftText, 4);
            this.cmbLeftText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbLeftText.FormattingEnabled = true;
            this.cmbLeftText.Items.AddRange(new object[] {
            "タイムテーブル",
            "{$START_DATE}",
            "{$END_DATE}",
            "{$PAGE_START_DATE}",
            "{$PAGE_END_DATE}",
            "{$START_DATE}～{$END_DATE}",
            "{$PAGE_START_DATE}～{$PAGE_END_DATE}",
            "ページ：{$PAGE}",
            "ページ：{$PAGE}/{$PAGE_ALL}",
            "{$PAGE}",
            "{$PAGE}/{$PAGE_ALL}"});
            this.cmbLeftText.Location = new System.Drawing.Point(102, 3);
            this.cmbLeftText.Name = "cmbLeftText";
            this.cmbLeftText.Size = new System.Drawing.Size(254, 20);
            this.cmbLeftText.TabIndex = 1;
            this.cmbLeftText.Text = "タイムテーブル";
            // 
            // btnLeftFont
            // 
            this.btnLeftFont.AutoSize = true;
            this.btnLeftFont.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLeftFont.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnLeftFont.Location = new System.Drawing.Point(362, 3);
            this.btnLeftFont.Name = "btnLeftFont";
            this.btnLeftFont.Size = new System.Drawing.Size(48, 22);
            this.btnLeftFont.TabIndex = 2;
            this.btnLeftFont.Text = "フォント";
            this.btnLeftFont.UseVisualStyleBackColor = true;
            this.btnLeftFont.Click += new System.EventHandler(this.btnLeftFont_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 28);
            this.label2.TabIndex = 3;
            this.label2.Text = "中央";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbCenterText
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cmbCenterText, 4);
            this.cmbCenterText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbCenterText.FormattingEnabled = true;
            this.cmbCenterText.Items.AddRange(new object[] {
            "タイムテーブル",
            "{$START_DATE}",
            "{$END_DATE}",
            "{$PAGE_START_DATE}",
            "{$PAGE_END_DATE}",
            "{$START_DATE}～{$END_DATE}",
            "{$PAGE_START_DATE}～{$PAGE_END_DATE}",
            "ページ：{$PAGE}",
            "ページ：{$PAGE}/{$PAGE_ALL}",
            "{$PAGE}",
            "{$PAGE}/{$PAGE_ALL}"});
            this.cmbCenterText.Location = new System.Drawing.Point(102, 31);
            this.cmbCenterText.Name = "cmbCenterText";
            this.cmbCenterText.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbCenterText.Size = new System.Drawing.Size(254, 20);
            this.cmbCenterText.TabIndex = 4;
            this.cmbCenterText.Text = "{$START_DATE}～{$ENDDATE}";
            // 
            // btnCenterFont
            // 
            this.btnCenterFont.AutoSize = true;
            this.btnCenterFont.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCenterFont.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCenterFont.Location = new System.Drawing.Point(362, 31);
            this.btnCenterFont.Name = "btnCenterFont";
            this.btnCenterFont.Size = new System.Drawing.Size(48, 22);
            this.btnCenterFont.TabIndex = 5;
            this.btnCenterFont.Text = "フォント";
            this.btnCenterFont.UseVisualStyleBackColor = true;
            this.btnCenterFont.Click += new System.EventHandler(this.btnCenterFont_Click);
            // 
            // cmbRightText
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cmbRightText, 4);
            this.cmbRightText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbRightText.FormattingEnabled = true;
            this.cmbRightText.Items.AddRange(new object[] {
            "タイムテーブル",
            "{$START_DATE}",
            "{$END_DATE}",
            "{$PAGE_START_DATE}",
            "{$PAGE_END_DATE}",
            "{$START_DATE}～{$END_DATE}",
            "{$PAGE_START_DATE}～{$PAGE_END_DATE}",
            "ページ：{$PAGE}",
            "ページ：{$PAGE}/{$PAGE_ALL}",
            "{$PAGE}",
            "{$PAGE}/{$PAGE_ALL}"});
            this.cmbRightText.Location = new System.Drawing.Point(102, 59);
            this.cmbRightText.Name = "cmbRightText";
            this.cmbRightText.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbRightText.Size = new System.Drawing.Size(254, 20);
            this.cmbRightText.TabIndex = 7;
            this.cmbRightText.Text = "ページ：{$PAGE}";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 28);
            this.label3.TabIndex = 6;
            this.label3.Text = "右側";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnRightFont
            // 
            this.btnRightFont.AutoSize = true;
            this.btnRightFont.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRightFont.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnRightFont.Location = new System.Drawing.Point(362, 59);
            this.btnRightFont.Name = "btnRightFont";
            this.btnRightFont.Size = new System.Drawing.Size(48, 22);
            this.btnRightFont.TabIndex = 8;
            this.btnRightFont.Text = "フォント";
            this.btnRightFont.UseVisualStyleBackColor = true;
            this.btnRightFont.Click += new System.EventHandler(this.btnRightFont_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 26);
            this.label4.TabIndex = 9;
            this.label4.Text = "日付の表現形式";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 25);
            this.label5.TabIndex = 10;
            this.label5.Text = "ページの表現形式";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbDateFormat
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cmbDateFormat, 3);
            this.cmbDateFormat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbDateFormat.FormattingEnabled = true;
            this.cmbDateFormat.Items.AddRange(new object[] {
            "MM/dd",
            "yyyy/MM/dd",
            "yyyy年MM月dd日",
            "MM月dd日",
            "MM月"});
            this.cmbDateFormat.Location = new System.Drawing.Point(102, 87);
            this.cmbDateFormat.Name = "cmbDateFormat";
            this.cmbDateFormat.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbDateFormat.Size = new System.Drawing.Size(112, 20);
            this.cmbDateFormat.TabIndex = 11;
            this.cmbDateFormat.Text = "yyyy/MM/dd";
            // 
            // txtPageFormat
            // 
            this.txtPageFormat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPageFormat.Location = new System.Drawing.Point(102, 113);
            this.txtPageFormat.Name = "txtPageFormat";
            this.txtPageFormat.Size = new System.Drawing.Size(43, 19);
            this.txtPageFormat.TabIndex = 12;
            this.txtPageFormat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtPageAllFormat
            // 
            this.txtPageAllFormat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPageAllFormat.Location = new System.Drawing.Point(168, 113);
            this.txtPageAllFormat.Name = "txtPageAllFormat";
            this.txtPageAllFormat.Size = new System.Drawing.Size(46, 19);
            this.txtPageAllFormat.TabIndex = 13;
            this.txtPageAllFormat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(151, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 25);
            this.label6.TabIndex = 14;
            this.label6.Text = "/";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dlgCenterFont
            // 
            this.dlgCenterFont.AllowScriptChange = false;
            this.dlgCenterFont.ShowEffects = false;
            // 
            // dlgRightFont
            // 
            this.dlgRightFont.AllowScriptChange = false;
            this.dlgRightFont.ShowEffects = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cmbRightText, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.cmbDateFormat, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtPageFormat, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label6, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtPageAllFormat, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmbLeftText, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbCenterText, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnLeftFont, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnCenterFont, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnRightFont, 6, 2);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(414, 167);
            this.tableLayoutPanel1.TabIndex = 17;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.SetColumnSpan(this.flowLayoutPanel1, 7);
            this.flowLayoutPanel1.Controls.Add(this.btnCancel);
            this.flowLayoutPanel1.Controls.Add(this.btnOK);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 138);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(408, 28);
            this.flowLayoutPanel1.TabIndex = 17;
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = true;
            this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCancel.Location = new System.Drawing.Point(343, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(62, 22);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "キャンセル";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOK.Location = new System.Drawing.Point(275, 3);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(62, 22);
            this.btnOK.TabIndex = 18;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // HeaderConfigDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(414, 167);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HeaderConfigDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "印刷ヘッダの設定";
            this.Shown += new System.EventHandler(this.HeaderConfigDialog_Shown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FontDialog dlgLeftFont;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbLeftText;
        private System.Windows.Forms.Button btnLeftFont;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbCenterText;
        private System.Windows.Forms.Button btnCenterFont;
        private System.Windows.Forms.ComboBox cmbRightText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRightFont;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbDateFormat;
        private System.Windows.Forms.TextBox txtPageFormat;
        private System.Windows.Forms.TextBox txtPageAllFormat;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.FontDialog dlgCenterFont;
        private System.Windows.Forms.FontDialog dlgRightFont;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
    }
}