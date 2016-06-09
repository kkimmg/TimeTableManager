using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using TimeTableManager.Element;
using TimeTableManager.ElementCollection;
namespace TimeTableManager.UI {
	/// <summary>
	/// Form1 の概要の説明です。
	/// </summary>
	public partial class FMemberDialog : System.Windows.Forms.Form {
        /// <summary>編集するメンバー
        /// </summary>
		private TimeTableManager.Element.CMember member;
        /// <summary>コンストラクタ
        /// </summary>
		public FMemberDialog() {
			//
			// Windows フォーム デザイナ サポートに必要です。
			//
			InitializeComponent();

			//
			// TODO: InitializeComponent 呼び出しの後に、コンストラクタ コードを追加してください。
			//
		}
        /// <summary>メンバー
        /// </summary>
		public TimeTableManager.Element.CMember Member {
			get {
				return member;
			}
			set {
				member = value;
				//this.Member2Componets();
			}
		}
        /// <summary>メンバーからコンポーネントへ
        /// </summary>
		private void Member2Components () {
			this.NumPriority.Value = Member.Priority;               // 優先度
			this.TxtMemberName.Text = Member.Name;                  // 名前
            try {
                // 期待される作業時間
                this.TxtWorkTime.Value = this.TxtWorkTime.MinDate + Member.ExpectedWork;
            } catch { }
            try {
                // 期待される休憩時間
                this.TxtRest.Text = Member.ExpectedRest.ToString("000.000");
            } catch { }
			this.ChkChief.Checked = Member.IsChief;                 // チーフですか？
            // 作成日
			if (Member.Created > this.txtCreated.MinDate) {
				this.txtCreated.Value = Member.Created.Date;
			} else {
				this.txtCreated.Value = System.DateTime.Today;
			}
            // 削除日
            if (Member.Removed != null) {
                this.txtRemoved.Value = (DateTime)Member.Removed;
            } else {
                this.txtRemoved.Value = this.txtRemoved.MaxDate;
            }
			// シフトの一覧
			this.TblPatterns.Clear();
			CTimeTable timetable = Member.TimeTable;
			CPatternCollection patterns = timetable.Patterns;
			for (int i = 0; i < patterns.Size(); i++) {
				CPattern pattern = patterns[i];
				if (!pattern.BuiltIn) {
					System.Data.DataRow row = this.TblPatterns.NewRow();
					row["ClmPattern"] = pattern;
					row["ClmPatternName"] = pattern.Name;
					this.TblPatterns.Rows.Add(row);
				}
			}
            // シフトの選択状況
			this.LstPatterns.ClearSelected();
			for (int i = 0; i < this.TblPatterns.Rows.Count; i++) {
				System.Data.DataRow row = this.TblPatterns.Rows[i];
				CPattern pattern = row["ClmPattern"] as CPattern;
				if (Member.Contains(pattern)) {
                    this.LstPatterns.SetItemChecked(i, true);
				} else {
                    this.LstPatterns.SetItemChecked(i, false);
				}
			}
            // 稼働日
            chkMonday.Checked = Member.IsAvailableDay(CTimeTable.tMonday);
            chkTuesday.Checked = Member.IsAvailableDay(CTimeTable.tTuesday);
            chkWednesday.Checked = Member.IsAvailableDay(CTimeTable.tWednesday);
            chkThursday.Checked = Member.IsAvailableDay(CTimeTable.tThursday);
            chkFriday.Checked = Member.IsAvailableDay(CTimeTable.tFriday);
            chkSaturday.Checked = Member.IsAvailableDay(CTimeTable.tSaturday);
            chkSunday.Checked = Member.IsAvailableDay(CTimeTable.tSunday);
            // めも
            txtNotes.Text = Member.Notes;
            // 稼動間隔
            dtpSpace.Value = dtpSpace.MinDate + Member.Spacetime;
            // 連続稼働日
            numContinuas.Value = Member.ContinuasInt;
		}
        /// <summary>コンポーネントからメンバーへ
        /// </summary>
		private void Components2Member () {
			this.Member.Priority = (int)this.NumPriority.Value;     // 優先度
			this.Member.Name = this.TxtMemberName.Text;             // 名前
			this.Member.ExpectedWork = TxtWorkTime.Value.TimeOfDay; // 気体の作業時間
            // 期待される休憩時間
            double ExpectedRest;
            if (double.TryParse(this.TxtRest.Text, out ExpectedRest)) {
                this.Member.ExpectedRest = ExpectedRest;
            } else {
                this.Member.ExpectedRest = 1.0;
            }
			this.Member.IsChief = this.ChkChief.Checked;            // チーフメンバーですか？
			// シフトの追加
			this.Member.ClearPatterns();    // とりあえず最初にクリア
            foreach (System.Data.DataRowView view in this.LstPatterns.CheckedItems) {
                // そのあとで有効なものを追加する
				CPattern pattern = view.Row["ClmPattern"] as CPattern;
				this.Member.AddPattern(pattern);
			}
            // 稼働日
            Member.SetAvailableDay(CTimeTable.tMonday, chkMonday.Checked);
            Member.SetAvailableDay(CTimeTable.tTuesday, chkTuesday.Checked);
            Member.SetAvailableDay(CTimeTable.tWednesday, chkWednesday.Checked);
            Member.SetAvailableDay(CTimeTable.tThursday, chkThursday.Checked);
            Member.SetAvailableDay(CTimeTable.tFriday, chkFriday.Checked);
            Member.SetAvailableDay(CTimeTable.tSaturday, chkSaturday.Checked);
            Member.SetAvailableDay(CTimeTable.tSunday, chkSunday.Checked);
            // 稼動間隔
            Member.Spacetime = dtpSpace.Value.TimeOfDay;
            // 連続稼働日
            Member.ContinuasInt = (int)numContinuas.Value;
            // メモ
            Member.Notes = txtNotes.Text;
            // 作成日
            Member.Created = txtCreated.Value.Date;
            // 削除日
            if (Member.Removed != null) {
                Member.Removed = txtRemoved.Value.Date;
            }
            // イベント発生
            this.Member.TimeTable.NotifyMembersEdited(EnumTimeTableElementEventTypes.ElementEdited, this.Member);
		}
        /// <summary>OK
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
		private void btnOK_Click(object sender, System.EventArgs e) {
			this.Components2Member();
			this.Dispose();
		}
        /// <summary>初期表示
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        private void MemberDialog_Shown (object sender, EventArgs e) {
            this.Member2Components();
            #region 表示灯の設定
            bool available = (Member.Removed == null);
            this.NumPriority.Enabled = available;
            this.TxtMemberName.Enabled = available;
            this.TxtWorkTime.Enabled = available;
            this.TxtRest.Enabled = available;
            this.ChkChief.Enabled = available;
            this.LstPatterns.Enabled = available;
            this.chkMonday.Enabled = available;
            this.chkTuesday.Enabled = available;
            this.chkWednesday.Enabled = available;
            this.chkThursday.Enabled = available;
            this.chkFriday.Enabled = available;
            this.chkSaturday.Enabled = available;
            this.chkSunday.Enabled = available;
            this.dtpSpace.Enabled = available;
            this.numContinuas.Enabled = available;
            this.txtNotes.Enabled = available;
            this.txtCreated.Enabled = available;
            this.lblRemoved.Visible = !available;
            this.txtRemoved.Enabled = !available;
            this.txtRemoved.Visible = !available;
            #endregion
        }
	}
}
