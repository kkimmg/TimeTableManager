using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using TimeTableManager.Element;

namespace TimeTableManager.UI {
	/// <summary>DayOffDialog の概要の説明です。
	/// </summary>
	public class FDayOffDialog : System.Windows.Forms.Form {
		private System.Windows.Forms.DateTimePicker txtRemoved;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.DateTimePicker txtCreated;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.MonthCalendar monthCalendar1;
		/// <summary>内部の休日</summary>
        private CDayOff dayoff;
		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
		private System.ComponentModel.Container components = null;
        /// <summary>コンストラクタ
        /// </summary>
		public FDayOffDialog() {
			//
			// Windows フォーム デザイナ サポートに必要です。
			//
			InitializeComponent();

			//
			// TODO: InitializeComponent 呼び出しの後に、コンストラクタ コードを追加してください。
			//
		}

		/// <summary>
		/// 使用されているリソースに後処理を実行します。
		/// </summary>
		protected override void Dispose( bool disposing ) {
			if( disposing ) {
				if(components != null) {
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows フォーム デザイナで生成されたコード 
		/// <summary>
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディタで変更しないでください。
		/// </summary>
		private void InitializeComponent() {
            this.txtRemoved = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCreated = new System.Windows.Forms.DateTimePicker();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.SuspendLayout();
            // 
            // txtRemoved
            // 
            this.txtRemoved.Enabled = false;
            this.txtRemoved.Location = new System.Drawing.Point(8, 112);
            this.txtRemoved.Name = "txtRemoved";
            this.txtRemoved.Size = new System.Drawing.Size(56, 19);
            this.txtRemoved.TabIndex = 21;
            this.txtRemoved.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 20;
            this.label7.Text = "削除日";
            this.label7.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.label7.Visible = false;
            // 
            // txtCreated
            // 
            this.txtCreated.Location = new System.Drawing.Point(8, 64);
            this.txtCreated.Name = "txtCreated";
            this.txtCreated.Size = new System.Drawing.Size(56, 19);
            this.txtCreated.TabIndex = 19;
            this.txtCreated.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(150, 241);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 24);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "キャンセル";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(64, 241);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(80, 24);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 16;
            this.label5.Text = "作成日";
            this.label5.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.label5.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 22;
            this.label1.Text = "休日名";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // textBox1
            // 
            this.textBox1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.textBox1.Location = new System.Drawing.Point(64, 8);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(220, 19);
            this.textBox1.TabIndex = 0;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(64, 40);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 1;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // FDayOffDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(294, 275);
            this.ControlBox = false;
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtRemoved);
            this.Controls.Add(this.txtCreated);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FDayOffDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "休日のプロパティ";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void btnOK_Click(object sender, System.EventArgs e) {
			this.DayOff.Name = this.textBox1.Text;
			this.DayOff.StartDate = this.monthCalendar1.SelectionStart;
			this.DayOff.EndDate = this.monthCalendar1.SelectionEnd;
            this.DayOff.TimeTable.NotifyDayOffsEdited(EnumTimeTableElementEventTypes.ElementEdited, this.DayOff);
		}

		private void btnCancel_Click(object sender, System.EventArgs e) {
		
		}

		private void monthCalendar1_DateChanged(object sender, System.Windows.Forms.DateRangeEventArgs e) {
		
		}

		/// <summary>
		/// 編集する休日
		/// </summary>
		public CDayOff DayOff {
			get {
				return dayoff;
			}
			set {
				dayoff = value;
				// 値を設定する
				this.textBox1.Text = dayoff.Name;
				this.monthCalendar1.SelectionStart = dayoff.StartDate;
				this.monthCalendar1.SelectionEnd = dayoff.EndDate;
			}
		}
	}
}
