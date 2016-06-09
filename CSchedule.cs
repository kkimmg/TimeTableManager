using System;
namespace TimeTableManager.Element {
    /// <summary>メンバーと勤務シフトの組み合わせ
    /// </summary>
	public class CSchedule:CAbstractElement {
		/// <summary>メンバー
		/// </summary>
		virtual public CMember Member {
			get {
                if (this.member == null) this.member = CMember.NULL;
				return member;
			}
			set {
				this.member = value;
                if (value == null) this.member = CMember.NULL;
                //if (Root != null) {
                //    if (Root.ScheduleEditedEvnetIsValid) {
                //        Root.ScheduleEdited(this);
                //    }
                //}
			}			
		}
		/// <summary>勤務シフト
		/// </summary>
		virtual public CPattern Pattern {
			get {
                if (this.pattern == null) this.pattern = CPattern.NULL;
                if (Date != null) {
                    if (!pattern.IsAvailable(Date.Date)) {
                        this.pattern = CPattern.NULL;
                    }
                    if (!member.IsAvailable(Date.Date)) {
                        this.pattern = CPattern.NULL;
                    }
                }
				return pattern;
			}
			set {
                bool Changing = (this.pattern != value);
				this.pattern = value;
                if (value == null) this.pattern = CPattern.NULL;
                if (TimeTable != null && Changing) {
                    if (TimeTable.ScheduleEditedEvnetIsValid) {
                        TimeTable.NotifyScheduleEdited(this);
                    }
                }
			}
		}
		/// <summary>開始時間
		/// </summary>
		virtual public DateTime StartTime {
			get {
				// シフトが設定されていなければ０時
				if (Pattern == null) return Date.Date;
				// シフトの開始時間
				DateTime time = Date.Date + Pattern.Start;
				return time;
			}
		}
		/// <summary>終了時間
		/// </summary>
		virtual public DateTime EndTime {
			get {
				// シフトが設定されていなければ０時
				if (Pattern == null) return Date.Date;
				// シフトの終了時間
				return this.StartTime + this.Pattern.Scope;
			}
		}
		/// <summary>タイムテーブル
		/// </summary>
		override public CTimeTable TimeTable {
			get {
				return parent.TimeTable;
			}
		}
		/// <summary>スケジュールの火
		/// </summary>
		public CScheduledDate Date {
			get {
				return parent;
			}
		}
		/// <summary>このスケジュールのメンバー 
        /// </summary>
		private CMember member; // = new Member();
		/// <summary>このスケジュールを格納する日付 
        /// </summary>
		private CScheduledDate parent;
		/// <summary>このスケジュールのシフト 
        /// </summary>
		private CPattern pattern; 
		/// <summary>コンストラクタ
		/// </summary>
		/// <param name="Parent">この組み合わせを保持する日付</param>
		public CSchedule(CScheduledDate Parent):base() {
			this.parent = Parent;
		}
        /// <summary>メモ
        /// </summary>
        public override string Notes {
            get {
                return base.Notes;
            }
            set {
                base.Notes = value;
            }
        }
	}
}