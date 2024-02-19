using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace TimeTableManager.UI {
    /// <summary>
    /// PatternDialog の概要の説明です。
    /// </summary>
    public partial class FPatternDialog : System.Windows.Forms.Form {
        /// <summary>勤務シフト
        /// </summary>
        private TimeTableManager.Element.BPattern pattern;
        /// <summary>コンストラクタ
        /// </summary>
        public FPatternDialog () {
            //
            // Windows フォーム デザイナ サポートに必要です。
            //
            InitializeComponent();

            //
            // TODO: InitializeComponent 呼び出しの後に、コンストラクタ コードを追加してください。
            //
        }
        /// <summary>OK
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        private void btnOK_Click (object sender, System.EventArgs e) {
            if (this.ActiveControl != btnOK) {
                btnOK.Select();
            }
            Components2Pattern();
            this.Dispose(true);
        }
        /// <summary>勤務シフト
        /// </summary>
        public TimeTableManager.Element.BPattern Pattern {
            get {
                return pattern;
            }
            set {
                this.pattern = value;

            }
        }
        /// <summary>コンポーネントからシフトへ
        /// </summary>
        private void Components2Pattern () {
            this.pattern.Name = this.txtName.Text;
            this.pattern.Start = this.txtStart.Value.TimeOfDay;
            if (this.txtStart.Value.TimeOfDay > this.txtEnd.Value.TimeOfDay) {
                this.pattern.Scope = this.txtEnd.Value.TimeOfDay - this.txtStart.Value.TimeOfDay + new TimeSpan(24, 0, 0);
            } else {
                this.pattern.Scope = this.txtEnd.Value.TimeOfDay - this.txtStart.Value.TimeOfDay;
            }
            this.pattern.Rest = this.txtRest.Value.TimeOfDay;
            this.pattern.Notes = this.txtNotes.Text;
            this.pattern.Created = txtCreated.Value.Date;
            if (this.pattern.Removed != null) {
                this.pattern.Removed = (DateTime)txtRemoved.Value.Date;
            }
            // イベント
            this.pattern.TimeTable.NotifyPatternsEdited(TimeTableManager.Element.EnumTimeTableElementEventTypes.ElementEdited, this.pattern);
        }
        /// <summary>勤務シフトからコンポーネントへ
        /// </summary>
        private void Pattern2Components () {
            this.txtName.Text = pattern.Name;
            try {
                this.txtStart.Value = txtStart.MinDate.Date + pattern.Start;
            } catch {
            }
            try {
                this.txtEnd.Value = txtEnd.MinDate.Date + pattern.End;
            } catch {
            }
            try {
                this.txtRest.Value = txtRest.MinDate.Date + pattern.Rest;
            } catch {
            }
            try {
                this.txtCreated.Value = this.pattern.Created;
            } catch {
            }
            this.txtNotes.Text = pattern.Notes;
            if (pattern.Removed != null) {
                try {
                    this.txtRemoved.Value = (DateTime)this.pattern.Removed;
                } catch {
                }
            } else {
                try {
                    this.txtRemoved.Value = this.txtRemoved.MaxDate;
                } catch {
                }
            }
        }
        /// <summary>初期表示
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        private void PatternDialog_Shown (object sender, EventArgs e) {
            Pattern2Components();
            // 表示など
            bool available = (pattern.Removed == null);
            this.txtName.Enabled = available;
            this.txtStart.Enabled = available;
            this.txtEnd.Enabled = available;
            this.txtRest.Enabled = available;
            this.txtNotes.Enabled = available;
            this.txtCreated.Enabled = available;
            this.lblRemoved.Visible = !available;
            this.txtRemoved.Visible = !available;
            this.txtRemoved.Enabled = !available;
        }
    }
}
