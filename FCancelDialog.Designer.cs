namespace TimeTableManager {
    partial class FCancelDialog {
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
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BgSetting = new System.ComponentModel.BackgroundWorker();
            this.BgProgress = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // BtnCancel
            // 
            this.BtnCancel.AutoSize = true;
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(12, 41);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(236, 25);
            this.BtnCancel.TabIndex = 0;
            this.BtnCancel.Text = "自動設定を終了する";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BgSetting
            // 
            this.BgSetting.WorkerReportsProgress = true;
            this.BgSetting.WorkerSupportsCancellation = true;
            this.BgSetting.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BgSetting_ProgressChanged);
            // 
            // BgProgress
            // 
            this.BgProgress.Location = new System.Drawing.Point(12, 12);
            this.BgProgress.Name = "BgProgress";
            this.BgProgress.Size = new System.Drawing.Size(236, 23);
            this.BgProgress.TabIndex = 1;
            // 
            // FCancelDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(260, 72);
            this.ControlBox = false;
            this.Controls.Add(this.BgProgress);
            this.Controls.Add(this.BtnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FCancelDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "自動設定中";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnCancel;
        private System.ComponentModel.BackgroundWorker BgSetting;
        private System.Windows.Forms.ProgressBar BgProgress;
    }
}