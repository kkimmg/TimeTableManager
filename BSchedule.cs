using System;
namespace TimeTableManager.Element {
    /// <summary>メンバーと勤務シフトの組み合わせ
    /// </summary>
	public class BSchedule:BAbstractElement {
		/// <summary>メンバー
		/// </summary>
		virtual public BMember Member {
			get {
                if (this.member == null) this.member = BMember.NULL;
				return member;
			}
			set {
				this.member = value;
                if (value == null) this.member = BMember.NULL;
                //if (Root != null) {
                //    if (Root.ScheduleEditedEvnetIsValid) {
                //        Root.ScheduleEdited(this);
                //    }
                //}
			}			
		}
		/// <summary>勤務シフト
		/// </summary>
		virtual public BPattern Pattern {
			get {
                if (this.pattern == null) this.pattern = BPattern.NULL;
                if (Date != null) {
                    if (!pattern.IsAvailable(Date.Date)) {
                        this.pattern = BPattern.NULL;
                    }
                    if (!member.IsAvailable(Date.Date)) {
                        this.pattern = BPattern.NULL;
                    }
                }
				return pattern;
			}
			set {
                bool Changing = (this.pattern != value);
				this.pattern = value;
                if (value == null) this.pattern = BPattern.NULL;
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
		override public BTimeTable TimeTable {
			get {
				return parent.TimeTable;
			}
		}
		/// <summary>スケジュールの火
		/// </summary>
		public BScheduledDate Date {
			get {
				return parent;
			}
		}
		/// <summary>このスケジュールのメンバー 
        /// </summary>
		private BMember member; // = new Member();
		/// <summary>このスケジュールを格納する日付 
        /// </summary>
		private BScheduledDate parent;
		/// <summary>このスケジュールのシフト 
        /// </summary>
		private BPattern pattern; 
		/// <summary>コンストラクタ
		/// </summary>
		/// <param name="Parent">この組み合わせを保持する日付</param>
		public BSchedule(BScheduledDate Parent):base() {
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