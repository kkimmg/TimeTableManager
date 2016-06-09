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
        private readonly CSchedule schedule;
        /// <summary>
        /// 変更されたスケジュール
        /// </summary>
        public CSchedule Schedule {
            get { return schedule; }
        } 
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="param"></param>
        public EScheduleEditedEventArgs (CSchedule param) {
            this.schedule = param;
        }
    }
    /// <summary>勤務シフトが変更された
    /// </summary>
    public class EPatternsEditedEventArgs : EventArgs {
        private EnumTimeTableElementEventTypes type;
        private readonly CPattern source;
        /// <summary>イベントの種別
        /// </summary>
        public EnumTimeTableElementEventTypes Type {
            get { return type; }
        }
        /// <summary>イベントの発生元である勤務シフト
        /// </summary>
        public CPattern Source {
            get { return source; }
        }
        /// <summary>コンストラクタ
        /// </summary>
        /// <param name="EventType">イベント種別</param>
        /// <param name="EventSource">イベントの発生元</param>
        public EPatternsEditedEventArgs (EnumTimeTableElementEventTypes EventType, CPattern EventSource) {
            this.type = EventType;
            this.source = EventSource;
        }
    }
    /// <summary>メンバーが変更された
    /// </summary>
    public class EMembersEditedEventArgs : EventArgs {
        private EnumTimeTableElementEventTypes type;
        private readonly CMember source;
        /// <summary>イベント種別
        /// </summary>
        public EnumTimeTableElementEventTypes Type {
            get { return type; }
        }
        /// <summary>イベントの発生源であるメンバー
        /// </summary>
        public CMember Source {
            get { return source; }
        }
        /// <summary>コンストラクタ
        /// </summary>
        /// <param name="EventType">イベント種別</param>
        /// <param name="EventSource">発生源</param>
        public EMembersEditedEventArgs (EnumTimeTableElementEventTypes EventType, CMember EventSource) {
            this.type = EventType;
            this.source = EventSource;
        }
    }
    /// <summary>人員配置が変更された
    /// </summary>
    public class ERequirePatternssEditedEventArgs : EventArgs {
        private EnumTimeTableElementEventTypes type;
        private readonly CRequirePatterns source;
        /// <summary>イベント種別
        /// </summary>
        public EnumTimeTableElementEventTypes Type {
            get { return type; }
        }
        /// <summary>イベントの発生元となる人員配置
        /// </summary>
        public CRequirePatterns Source {
            get { return source; }
        }
        /// <summary>コンストラクタ
        /// </summary>
        /// <param name="EventType">イベント種別</param>
        /// <param name="EventSource">発生源</param>
        public ERequirePatternssEditedEventArgs (EnumTimeTableElementEventTypes EventType, CRequirePatterns EventSource) {
            this.type = EventType;
            this.source = EventSource;
        }
    }
    /// <summary>休日が変更された
    /// </summary>
    public class EDayOffsEditedEventArgs : EventArgs {
        private EnumTimeTableElementEventTypes type;
        private readonly CDayOff source;
        /// <summary>イベント種別
        /// </summary>
        public EnumTimeTableElementEventTypes Type {
            get { return type; }
        }
        /// <summary>イベントの発生した休日
        /// </summary>
        public CDayOff Source {
            get { return source; }
        }
        /// <summary>コンストラクタ
        /// </summary>
        /// <param name="EventType">イベント種別</param>
        /// <param name="EventSource">発生源</param>
        public EDayOffsEditedEventArgs (EnumTimeTableElementEventTypes EventType, CDayOff EventSource) {
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
        private readonly CScheduledDate sdate;
        private readonly CRequirePatterns require;
        /// <summary>スケジュール日
        /// </summary>
        public CScheduledDate ScheduledDate {
            get { return sdate; }
        }
        /// <summary>人員配置
        /// </summary>
        public CRequirePatterns RequirePatterns {
            get { return require; }
        }
        /// <summary>コンストラクタ
        /// </summary>
        /// <param name="SDate">スケジュール日</param>
        /// <param name="Requires">人員配置</param>
        public EScheduleDateRequirePatternsEditedEventArgs (CScheduledDate SDate, CRequirePatterns Requires) {
            this.sdate = SDate;
            this.require = Requires;
        }
    }
    /// <summary>分析結果が変更された
    /// </summary>
    public class EEvaluationItemEditedEventArgs : EventArgs {
        private EnumTimeTableElementEventTypes type;
        private readonly CEvaluationItem source;
        /// <summary>イベント種別
        /// </summary>
        public EnumTimeTableElementEventTypes Type {
            get { return type; }
        }
        /// <summary>イベントの発生した分析要素
        /// </summary>
        public CEvaluationItem Source {
            get { return source; }
        }
        /// <summary>コンストラクタ
        /// </summary>
        /// <param name="EventType">イベント種別</param>
        /// <param name="EventSource">発生源</param>
        public EEvaluationItemEditedEventArgs (EnumTimeTableElementEventTypes EventType, CEvaluationItem EventSource) {
            this.type = EventType;
            this.source = EventSource;
        }
    }
}
