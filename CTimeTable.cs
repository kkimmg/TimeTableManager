using System;
using System.Collections.Generic;
using TimeTableManager.ElementCollection;
using TimeTableManager.Element;
using TimeTableManager.Evaluation;
namespace TimeTableManager.Element {
    /// <summary>タイムテーブル
    /// </summary>
    public class CTimeTable {
        private System.Collections.Specialized.NameValueCollection Properties;
        /// <summary>初期化処理
        /// </summary>
        private void InitBlock () {
            defaults = new CRequirePatterns[7];
            Properties = new System.Collections.Specialized.NameValueCollection();
        }
        /// <summary>日付の一覧
        /// </summary>
        public CScheduledDateCollection Dates {
            get { return dates; }
        }
        /// <summary>メンバーの一覧
        /// </summary>
        virtual public CMemberCollection Members {
            get {
                return members;
            }
        }
        /// <summary>勤務シフトの一覧
        /// </summary>
        virtual public CPatternCollection Patterns {
            get {
                return patterns;
            }
        }
        /// <summary>休日の一覧
        /// </summary>
        public CDayOffCollection DayOffs {
            get {
                return daysoff;
            }
        }
        /// <summary>人員配置の一覧
        /// </summary>
        virtual public CRequirePatternsCollection Requires {
            get {
                return requires;
            }
        }
        /// <summary>このタイムテーブルは日付をまたぐ
        /// </summary>
        virtual public bool Over {
            get {
                return (around > TimeSpan.FromHours(24.0));
            }

        }
        /// <summary>現在のID
        /// </summary>
        private long id;
        /// <summary>現在のID
        /// </summary>
        virtual public long CurrentID {
            set {
                this.id = value;
            }
            get {
                return this.id;
            }
        }
        /// <summary>次のID
        /// </summary>
        virtual public long NextID {
            get {
                if (id == long.MaxValue) {
                    id = 0;
                }
                return ++id;
            }
        }
        /// <summary>人員配置を保持するかどうか
        /// </summary>
        private bool keepRequire = false;
        #region 一覧
        /// <summary>日付の一覧
        /// </summary>
        private CScheduledDateCollection dates;
        /// <summary>メンバーの一覧
        /// </summary>
        private CMemberCollection members;
        /// <summary>休日の一覧
        /// </summary>
        private CDayOffCollection daysoff;
        /// <summary>勤務シフトの一覧
        /// </summary>
        private CPatternCollection patterns;
        /// <summary>人員配置の一覧
        /// </summary>
        private CRequirePatternsCollection requires;
        #endregion
        #region デフォルトの人員配置
        /// <summary>デフォルトの人員配置
        /// </summary>
        private CRequirePatterns defaultRequire = null;
        /// <summary>デフォルトの人員配置
        /// </summary>
        private CRequirePatterns[] defaults;
        #endregion
        #region 営業時間の開始終了
        /// <summary>開始時間
        /// </summary>
        private TimeSpan start = TimeSpan.FromHours(9.0D);
        /// <summary>営業時間の終了
        /// </summary>
        private TimeSpan around = TimeSpan.FromHours(8.0D);
        #endregion
        /// <summary>コンストラクタ
        /// </summary>
        public CTimeTable ()
            : base() {
            InitBlock();
            //DayOffs = new DayOffCollection(this);
            members = new CMemberCollection(this);
            patterns = new CPatternCollection(this);
            daysoff = new CDayOffCollection(this);
            requires = new CRequirePatternsCollection(this);
            dates = new CScheduledDateCollection(this);
        }
        /// <summary>
        /// 日付を削除する
        /// </summary>
        public virtual void Delete (System.DateTime n) {
            dates.DelScheduledDate(this[n]);
        }
        /// <summary>
        /// 日付を削除する
        /// </summary>
        public virtual void Delete (int n) {
            dates.DelScheduledDate(dates[n]);
        }
        /// <summary>
        /// デフォルトの人員配置
        /// </summary>
        public CRequirePatterns DefaultRequire {
            get {
                return defaultRequire;
            }
            set {
                this.defaultRequire = value;
            }
        }
        /// <summary>月曜日</summary>
        public const int tMonday = 0;
        /// <summary>火曜日</summary>
        public const int tTuesday = 1;
        /// <summary>水曜日</summary>
        public const int tWednesday = 2;
        /// <summary>木曜日</summary>
        public const int tThursday = 3;
        /// <summary>金曜日</summary>
        public const int tFriday = 4;
        /// <summary>土曜日</summary>
        public const int tSaturday = 5;
        /// <summary>日曜日</summary>
        public const int tSunday = 6;
        /// <summary>
        /// 曜日（int→DayoOfWeek）
        /// </summary>
        public static int DayOfWeek2Int (System.DayOfWeek weekday) {
            int wday = 0;
            if (weekday == System.DayOfWeek.Monday) {
                wday = tMonday;
            } else if (weekday == System.DayOfWeek.Tuesday) {
                wday = tTuesday;
            } else if (weekday == System.DayOfWeek.Wednesday) {
                wday = tWednesday;
            } else if (weekday == System.DayOfWeek.Thursday) {
                wday = tThursday;
            } else if (weekday == System.DayOfWeek.Friday) {
                wday = tFriday;
            } else if (weekday == System.DayOfWeek.Saturday) {
                wday = tSaturday;
            } else if (weekday == System.DayOfWeek.Sunday) {
                wday = tSunday;
            }
            return wday;
        }
        /// <summary>
        /// 曜日（DayoOfWeek→int）
        /// </summary>
        public static DayOfWeek Int2DayOfWeek (int wday) {
            DayOfWeek weekday = DayOfWeek.Sunday;
            if (wday == tMonday) {
                weekday = System.DayOfWeek.Monday;
            } else if (wday == tTuesday) {
                weekday = System.DayOfWeek.Tuesday;
            } else if (wday == tWednesday) {
                weekday = System.DayOfWeek.Wednesday;
            } else if (wday == tThursday) {
                weekday = System.DayOfWeek.Thursday;
            } else if (wday == tFriday) {
                weekday = System.DayOfWeek.Friday;
            } else if (wday == tSaturday) {
                weekday = System.DayOfWeek.Saturday;
            } else if (wday == tSunday) {
                weekday = System.DayOfWeek.Sunday;
            }
            return weekday;
        }
        /// <summary>人員配置
        /// </summary>
        public CRequirePatterns GetDefaultRequire (System.DayOfWeek weekday) {
            int wday = DayOfWeek2Int(weekday);
            return GetDefaultRequire(wday);
        }
        /// <summary>人員配置
        /// </summary>
        public void SetDefaultRequire (System.DayOfWeek weekday, CRequirePatterns value) {
            int wday = DayOfWeek2Int(weekday);
            defaults[wday] = value;
        }
        /// <summary>曜日ごとの人員配置
        /// </summary>
        /// <param name="weekday">曜日</param>
        /// <returns>人員配置</returns>
        public CRequirePatterns GetDefaultRequire (int weekday) {
            CRequirePatterns ret = null;
            ret = defaults[weekday];
            if (ret == null) {
                ret = DefaultRequire;
            }
            return ret;
        }
        /// <summary>
        /// 人員配置
        /// </summary>
        public void SetDefaultRequire (int weekday, CRequirePatterns value) {
            defaults[weekday] = value;
        }

        /// <summary>
        /// 該当する日付が休日かどうか判定する.
        /// </summary>
        public virtual bool IsDayOff (System.DateTime date) {
            return this.DayOffs.IsDayOff(date);
        }
        /// <summary>営業開始時刻
        /// </summary>
        public TimeSpan StartTime {
            get {
                return start;
            }
            set {
                this.start = value;
            }
        }
        /// <summary>営業終了時刻
        /// </summary>
        public TimeSpan EndTime {
            get {
                TimeSpan end = start + around;
                while (end <= start) {
                    end += TimeSpan.FromHours(24.0);
                }
                return end;
            }
            set {
                TimeSpan end = value;
                while (end <= start) {
                    end += TimeSpan.FromHours(24.0);
                }
                around = end - StartTime;
            }
        }
        /// <summary>営業時間
        /// </summary>
        public TimeSpan Around {
            get {
                return around;
            }
            set {
                around = value;
            }
        }
        /// <summary>
        /// 読み込み済みの日付の数
        /// </summary>
        /// <returns></returns>
        public virtual int Size () {
            return dates.Size();
        }
        /// <summary>
        /// 人員配置を保持するかどうか
        /// </summary>
        public bool KeepRequire {
            get {
                return keepRequire;
            }
            set {
                keepRequire = value;
            }
        }
        /// <summary>
        /// 人員配置
        /// </summary>
        public CScheduledDate this[int n] {
            get {
                return dates[n];
            }
        }
        /// <summary>
        /// 人員配置
        /// </summary>
        public CScheduledDate this[DateTime n] {
            get {
                return dates[n];
            }
        }
        /// <summary>プロパティキーの一覧
        /// </summary>
        /// <returns></returns>
        public System.Collections.IEnumerator GetEnumerator () {
            return Properties.Keys.GetEnumerator();
        }
        /// <summary>
        /// プロパティ
        /// </summary>
        public string this[string key] {
            get {
                return this.Properties[key];
            }
            set {
                if (value != null) {
                    this.Properties[key] = value;
                } else {
                    this.Properties.Remove(key);
                }
                if (OnPropertyChanged != null && scheduleEditedEvnetIsValid) {
                    EPropertyChangedEventArgs e = new EPropertyChangedEventArgs(key, value);
                    OnPropertyChanged(this, e);
                }
            }
        }
        /// <summary>
        /// 休日が変更された
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        public delegate void PropertyChangeEventHandler (object sender, EPropertyChangedEventArgs e);
        /// <summary>
        /// 休日が変更された
        /// </summary>
        public event PropertyChangeEventHandler OnPropertyChanged;
        /// <summary>
        /// リフレッシュ
        /// </summary>
        public void Refresh () {
            this.members.RefreshPriority();
        }
        private bool scheduleEditedEvnetIsValid = true;
        /// <summary>
        /// スケジュールが変更されたらイベントを発生する
        /// </summary>
        public bool ScheduleEditedEvnetIsValid {
            get {
                return scheduleEditedEvnetIsValid;
            }
            set {
                scheduleEditedEvnetIsValid = value;
            }
        }
        /// <summary>
        /// スケジュールが変更されたよ
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        public delegate void ScheduleEditedEventHandler (object sender, EScheduleEditedEventArgs e);
        /// <summary>
        /// スケジュールが変更された
        /// </summary>
        public event ScheduleEditedEventHandler OnScheduleEdited;
        /// <summary>
        /// スケジュールが変更された
        /// </summary>
        /// <param name="param"></param>
        public void NotifyScheduleEdited (CSchedule param) {
            if (OnScheduleEdited != null && ScheduleEditedEvnetIsValid) {
                EScheduleEditedEventArgs e = new EScheduleEditedEventArgs(param);
                OnScheduleEdited(this, e);
            }
        }
        /// <summary>
        /// シフトが変更された
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        public delegate void PatternsEditedEventHandler (object sender, EPatternsEditedEventArgs e);
        /// <summary>
        /// シフトが変更された
        /// </summary>
        public event PatternsEditedEventHandler OnPatternsEdited;
        /// <summary>
        /// シフトが変更された
        /// </summary>
        /// <param name="type"></param>
        /// <param name="source"></param>
        public void NotifyPatternsEdited (EnumTimeTableElementEventTypes type, CPattern source) {
            if (OnPatternsEdited != null && scheduleEditedEvnetIsValid) {
                EPatternsEditedEventArgs e = new EPatternsEditedEventArgs(type, source);
                OnPatternsEdited(this, e);
            }
        }
        /// <summary>
        /// メンバーが変更された
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        public delegate void MembersEditedEventHandler (object sender, EMembersEditedEventArgs e);
        /// <summary>
        /// メンバーが変更された
        /// </summary>
        public event MembersEditedEventHandler OnMembersEdited;
        /// <summary>
        /// メンバーが変更された
        /// </summary>
        /// <param name="type"></param>
        /// <param name="source"></param>
        public void NotifyMembersEdited (EnumTimeTableElementEventTypes type, CMember source) {
            if (OnMembersEdited != null && scheduleEditedEvnetIsValid) {
                //Members.Refresh();
                EMembersEditedEventArgs e = new EMembersEditedEventArgs(type, source);
                OnMembersEdited(this, e);
            }
        }
        /// <summary>
        /// 人員配置が変更された
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        public delegate void RequirePatternssEditedEventHandler (object sender, ERequirePatternssEditedEventArgs e);
        /// <summary>
        /// 人員配置が変更された
        /// </summary>
        public event RequirePatternssEditedEventHandler OnRequirePatternssEdited;
        /// <summary>
        /// 人員配置が変更された
        /// </summary>
        /// <param name="type"></param>
        /// <param name="source"></param>
        public void NotifyRequirePatternssEdited (EnumTimeTableElementEventTypes type, CRequirePatterns source) {
            if (OnRequirePatternssEdited != null && scheduleEditedEvnetIsValid) {
                ERequirePatternssEditedEventArgs e = new ERequirePatternssEditedEventArgs(type, source);
                OnRequirePatternssEdited(this, e);
            }
        }
        /// <summary>
        /// 休日が変更された
        /// </summary>
        /// <param name="sender">イベントの発生したオブジェクト</param>
        /// <param name="e">発生したイベント</param>
        public delegate void DayOffsEditedEventHandler (object sender, EDayOffsEditedEventArgs e);
        /// <summary>
        /// 休日が変更された
        /// </summary>
        public event DayOffsEditedEventHandler OnDayOffsEdited;
        /// <summary>
        /// 休日が変更された
        /// </summary>
        /// <param name="type"></param>
        /// <param name="source"></param>
        public void NotifyDayOffsEdited (EnumTimeTableElementEventTypes type, CDayOff source) {
            if (OnDayOffsEdited != null && scheduleEditedEvnetIsValid) {
                EDayOffsEditedEventArgs e = new EDayOffsEditedEventArgs(type, source);
                OnDayOffsEdited(this, e);
            }
        }
        /// <summary>
        /// スケジュール日の人員配置が変更された
        /// </summary>
        public delegate void ScheduleDateRequirePatternsEditedEventHandler (object sender, EScheduleDateRequirePatternsEditedEventArgs e);
        /// <summary>
        /// スケジュール日の人員配置が変更された
        /// </summary>
        public event ScheduleDateRequirePatternsEditedEventHandler OnScheduleDateRequirePatternsEdited;
        /// <summary>
        /// スケジュール日の人員配置が変更された
        /// </summary>
        public void NotifyScheduleDateRequirePatternsEdited (CScheduledDate param0, CRequirePatterns param1) {
            if (OnDayOffsEdited != null && scheduleEditedEvnetIsValid) {
                EScheduleDateRequirePatternsEditedEventArgs e = new EScheduleDateRequirePatternsEditedEventArgs(param0, param1);
                OnScheduleDateRequirePatternsEdited(this, e);
            }
        }
        /// <summary>評価の一覧
        /// </summary>
        private List<CEvaluationItem> evaluationItems = new List<CEvaluationItem>();
        /// <summary> 評価の一覧
        /// </summary>
        public List<CEvaluationItem> EvaluationItems {
            get {
                return evaluationItems;
            }
        }
    }
}