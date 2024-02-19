using System;
using System.Collections;
using TimeTableManager.Element;
using TimeTableManager.ElementCollection;
namespace TimeTableManager.Element {
    /// <summary>メンバー
    /// </summary>
	public class BMember:BAbstractElement {
        /// <summary>ナル値の替わり
        /// </summary>
        public static readonly BMember NULL = new NULL_MEMBER();
		/// <summary>メンバー名 
        /// </summary>
		private string name;
		/// <summary>このメンバーはチーフかどうか 
        /// </summary>
		public bool IsChief = false;
		/// <summary>このメンバーの休みの割合の期待値 
        /// </summary>
		private double expectedRest = 0.25;
		/// <summary>このメンバーの勤務時間の平均の期待値 
        /// </summary>
		private TimeSpan expectedWork = new TimeSpan(8, 0, 0);
		/// <summary>メンバーコレクション 
        /// </summary>
		private BMemberCollection parent;
		/// <summary>このメンバーの表示順 
        /// </summary>
		private int priority;
		/// <summary>このメンバーが就労可能なシフト 
        /// </summary>
		private ArrayList selectedpatterns;
        /// <summary>稼働日
        /// </summary>
        private bool[] availDay = new bool[7];// {true, true, true, true, true, true, true};
        /// <summary>連続稼働日
        /// </summary>
        private TimeSpan continuas = new TimeSpan(6, 0, 0, 0);
        /// <summary>稼動間隔
        /// </summary>
        private TimeSpan spacetime = new TimeSpan(12, 0, 0);
    	/// <summary>休みの割合
        /// </summary>
		virtual public double ExpectedRest {
			get {
				return expectedRest;
			}
			
			set {
				this.expectedRest = value;
			}
		}
		/// <summary>稼働時間
        /// </summary>
		virtual public TimeSpan ExpectedWork {
			get {
				return expectedWork;
			}
			
			set {
				this.expectedWork = value;
			}
		}
		/// <summary>メンバー名
        /// </summary>
		virtual public string Name {
			get {
				return name;
			}
			
			set {
				name = value;
			}
			
		}
		/// <summary>勤務シフト数
        /// </summary>
		virtual public int PatternSize {
			get {
				return selectedpatterns.Count;
			}
		}
		/// <summary>優先順位
        /// </summary>
		virtual public int Priority {
			get {
				return priority;
			}
			
			set {
				this.priority = value;
				parent.Refresh();
			}			
		}
		/// <summary>スケジュール全て 
        /// </summary>
		override public BTimeTable TimeTable {
			get {
				return parent.TimeTable;
			}			
		}
		/// <summary>コンストラクタ
		/// </summary>
		/// <param name="parent">メンバーコレクション</param>
		public BMember(BMemberCollection parent):base() {
			name = new System.Text.StringBuilder().ToString();
			this.parent = parent;
            availDay[0] = true;
            availDay[1] = true;
            availDay[2] = true;
            availDay[3] = true;
            availDay[4] = true;
            availDay[5] = true;
            availDay[6] = true;
			selectedpatterns = new ArrayList();
		}
		/// <summary>コンストラクタ
		/// </summary>
		/// <param name="parent">メンバーコレクション</param>
		/// <param name="id">メンバーのID</param>
		public BMember(BMemberCollection parent, long id):this(parent) {
			ObjectID = id;
		}
		/// <summary>勤務シフトの追加
		/// </summary>
		/// <param name="pattern">追加するシフト</param>
		public virtual void  AddPattern(BPattern pattern) {
			if (!selectedpatterns.Contains(pattern)) {
				selectedpatterns.Add(pattern);
			}
		}
		/// <summary>勤務シフトの取得
		/// </summary>
		/// <param name="n">n番目</param>
		/// <returns>勤務シフト</returns>
		public virtual BPattern GetPattern(int n) {
			return (BPattern) selectedpatterns[n];
		}
		/// <summary>勤務シフトの削除
		/// </summary>
		/// <param name="pattern">削除するシフト</param>
		public virtual void  RemovePattern(BPattern pattern) {
			selectedpatterns.Remove(pattern);
		}
		/// <summary>勤務シフト
		/// </summary>
		public BPattern this[int n] {
			get {
				return GetPattern(n);
			}
		}
		/// <summary>勤務シフトをクリアする
		/// </summary>
		public void ClearPatterns () {
			this.selectedpatterns.Clear();
		}
		/// <summary>勤務シフトを含んでいるか？
		/// </summary>
		public bool Contains(BPattern pattern) {
			return this.selectedpatterns.Contains(pattern);
		}
        /// <summary>指定された曜日は稼働日かどうか
        /// </summary>
        /// <param name="weekday">曜日をあらわすint</param>
        /// <returns>true:稼働日 false:休み</returns>
        public bool IsAvailableDay (int weekday) {
            return availDay[weekday];
        }
        /// <summary>指定された曜日を稼働日とするかどうか
        /// </summary>
        /// <param name="weekday">曜日をあらわすint</param>
        /// <param name="available">true:稼働日 false:休み</param>
        public void SetAvailableDay (int weekday, bool available) {
            availDay[weekday] = available;
        }
        /// <summary>指定された曜日は稼働日かどうか
        /// </summary>
        /// <param name="weekday">曜日</param>
        /// <returns>true:稼働日 false:休み</returns>
        public bool IsAvalableDay (DayOfWeek weekday) {
            return IsAvailableDay(BTimeTable.DayOfWeek2Int(weekday));
        }
        /// <summary>指定された曜日を稼働日とするかどうか
        /// </summary>
        /// <param name="weekday">曜日</param>
        /// <param name="available">true:稼働日 false:休み</param>
        public void SetAvailableDay (DayOfWeek weekday, bool available) {
            SetAvailableDay(BTimeTable.DayOfWeek2Int(weekday), available);
        }
        /// <summary>指定された日は稼働日かどうか
        /// </summary>
        /// <param name="date">日付</param>
        /// <returns>true:稼働日 false:休み</returns>
        public bool IsAvalableDay (DateTime date) {
            return IsAvalableDay(date.DayOfWeek);
        }
        /// <summary>連続して稼動してよい日数
        /// </summary>
        public TimeSpan Continuas {
            get { return continuas; }
            set { continuas = value; }
        }
        /// <summary>稼動間隔
        /// 稼動と稼動の間に必要な時間
        /// </summary>
        public TimeSpan Spacetime {
            get { return spacetime; }
            set { spacetime = value; }
        }
        /// <summary>連続して稼動してよい日数
        /// </summary>
        public int ContinuasInt {
            get { return continuas.Days; }
            set { continuas = new TimeSpan(value, 0, 0, 0); }
        }
        /// <summary>稼動間隔
        /// 稼動と稼動の間に必要な時間
        /// </summary>
        public int SpacetimeInt {
            get { return spacetime.Hours; }
            set { spacetime = new TimeSpan(value, 0, 0); }
        }
	}
    /// <summary>Nullの替わり
    /// </summary>
    public class NULL_MEMBER : BMember {
        /// <summary>コンストラクタ
        /// </summary>
        public NULL_MEMBER ()
            : base(null) {
        }
        /// <summary>名無しの権兵衛
        /// </summary>
        public override string Name {
            get {
                return "";
            }
        }
        /// <summary>勤務シフトの追加不可
        /// </summary>
        /// <param name="pattern">勤務シフト</param>
        public override void AddPattern (BPattern pattern) {
            // Do Nothing
        }
    }
}