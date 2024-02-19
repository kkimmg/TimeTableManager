using System;
using System.Collections.Generic;
using System.Text;
using TimeTableManager.Evaluation;

namespace TimeTableManager.Element {
    /// <summary>追加・修正・削除・完全削除
    /// </summary>
    public enum EnumTimeTableElementEventTypes {
        /// <summary>エレメントが追加されました</summary>
        ElementAdded = 0,
        /// <summary>エレメントが修正されました</summary>
        ElementEdited = 1,
        /// <summary>エレメントが削除されました</summary>
        ElementRemoved = 2,
        /// <summary>エレメントが完全に削除されました</summary>
        ElementRemovedForce = 3,
        /// <summary>エレメントが復活されました</summary>
        ElementRescued = 4
    }
    /// <summary>スケジュールが編集された
    /// </summary>
    public class EScheduleEditedEventArgs : EventArgs {
        private readonly BSchedule schedule;
        /// <summary>
        /// 変更されたスケジュール
        /// </summary>
        public BSchedule Schedule {
            get { return schedule; }
        } 
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="param"></param>
        public EScheduleEditedEventArgs (BSchedule param) {
            this.schedule = param;
        }
    }
    /// <summary>勤務シフトが変更された
    /// </summary>
    public class EPatternsEditedEventArgs : EventArgs {
        private EnumTimeTableElementEventTypes type;
        private readonly BPattern source;
        /// <summary>イベントの種別
        /// </summary>
        public EnumTimeTableElementEventTypes Type {
            get { return type; }
        }
        /// <summary>イベントの発生元である勤務シフト
        /// </summary>
        public BPattern Source {
            get { return source; }
        }
        /// <summary>コンストラクタ
        /// </summary>
        /// <param name="EventType">イベント種別</param>
        /// <param name="EventSource">イベントの発生元</param>
        public EPatternsEditedEventArgs (EnumTimeTableElementEventTypes EventType, BPattern EventSource) {
            this.type = EventType;
            this.source = EventSource;
        }
    }
    /// <summary>メンバーが変更された
    /// </summary>
    public class EMembersEditedEventArgs : EventArgs {
        private EnumTimeTableElementEventTypes type;
        private readonly BMember source;
        /// <summary>イベント種別
        /// </summary>
        public EnumTimeTableElementEventTypes Type {
            get { return type; }
        }
        /// <summary>イベントの発生源であるメンバー
        /// </summary>
        public BMember Source {
            get { return source; }
        }
        /// <summary>コンストラクタ
        /// </summary>
        /// <param name="EventType">イベント種別</param>
        /// <param name="EventSource">発生源</param>
        public EMembersEditedEventArgs (EnumTimeTableElementEventTypes EventType, BMember EventSource) {
            this.type = EventType;
            this.source = EventSource;
        }
    }
    /// <summary>人員配置が変更された
    /// </summary>
    public class ERequirePatternssEditedEventArgs : EventArgs {
        private EnumTimeTableElementEventTypes type;
        private readonly BRequirePatterns source;
        /// <summary>イベント種別
        /// </summary>
        public EnumTimeTableElementEventTypes Type {
            get { return type; }
        }
        /// <summary>イベントの発生元となる人員配置
        /// </summary>
        public BRequirePatterns Source {
            get { return source; }
        }
        /// <summary>コンストラクタ
        /// </summary>
        /// <param name="EventType">イベント種別</param>
        /// <param name="EventSource">発生源</param>
        public ERequirePatternssEditedEventArgs (EnumTimeTableElementEventTypes EventType, BRequirePatterns EventSource) {
            this.type = EventType;
            this.source = EventSource;
        }
    }
    /// <summary>休日が変更された
    /// </summary>
    public class EDayOffsEditedEventArgs : EventArgs {
        private EnumTimeTableElementEventTypes type;
        private readonly BDayOff source;
        /// <summary>イベント種別
        /// </summary>
        public EnumTimeTableElementEventTypes Type {
            get { return type; }
        }
        /// <summary>イベントの発生した休日
        /// </summary>
        public BDayOff Source {
            get { return source; }
        }
        /// <summary>コンストラクタ
        /// </summary>
        /// <param name="EventType">イベント種別</param>
        /// <param name="EventSource">発生源</param>
        public EDayOffsEditedEventArgs (EnumTimeTableElementEventTypes EventType, BDayOff EventSource) {
            this.type = EventType;
            this.source = EventSource;
        }
    }
    /// <summary>プロパティが変更された
    /// </summary>
    public class EPropertyChangedEventArgs : EventArgs {
        private readonly string key, val;
        /// <summary>キー
        /// </summary>
        public String Key {
            get {
                return key;
            }
        }
        /// <summary>値
        /// </summary>
        public String Value {
            get {
                return val;
            }
        }
        /// <summary>コンストラクタ
        /// </summary>
        /// <param name="Key">キー</param>
        /// <param name="Value">値</param>
        public EPropertyChangedEventArgs (string Key, string Value) {
            this.key = Key;
            this.val = Value;
        }
    }
    /// <summary>スケジュール日の人員配置が変更された
    /// </summary>
    public class EScheduleDateRequirePatternsEditedEventArgs : EventArgs {
        private readonly BScheduledDate sdate;
        private readonly BRequirePatterns require;
        /// <summary>スケジュール日
        /// </summary>
        public BScheduledDate ScheduledDate {
            get { return sdate; }
        }
        /// <summary>人員配置
        /// </summary>
        public BRequirePatterns RequirePatterns {
            get { return require; }
        }
        /// <summary>コンストラクタ
        /// </summary>
        /// <param name="SDate">スケジュール日</param>
        /// <param name="Requires">人員配置</param>
        public EScheduleDateRequirePatternsEditedEventArgs (BScheduledDate SDate, BRequirePatterns Requires) {
            this.sdate = SDate;
            this.require = Requires;
        }
    }
    /// <summary>分析結果が変更された
    /// </summary>
    public class EEvaluationItemEditedEventArgs : EventArgs {
        private EnumTimeTableElementEventTypes type;
        private readonly BEvaluationItem source;
        /// <summary>イベント種別
        /// </summary>
        public EnumTimeTableElementEventTypes Type {
            get { return type; }
        }
        /// <summary>イベントの発生した分析要素
        /// </summary>
        public BEvaluationItem Source {
            get { return source; }
        }
        /// <summary>コンストラクタ
        /// </summary>
        /// <param name="EventType">イベント種別</param>
        /// <param name="EventSource">発生源</param>
        public EEvaluationItemEditedEventArgs (EnumTimeTableElementEventTypes EventType, BEvaluationItem EventSource) {
            this.type = EventType;
            this.source = EventSource;
        }
    }
}
