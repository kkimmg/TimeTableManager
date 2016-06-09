using System;
using System.Collections.Generic;
using System.Text;
using TimeTableManager.Evaluation;

namespace TimeTableManager.DefaultElement {
    /// <summary>追加・修正・削除・完全削除
    /// </summary>
    public enum EnumTimeTableElementEventTypes {
        ElementAdded = 0,
        ElementEdited = 1,
        ElementRemoved = 2,
        ElementRemovedForce = 3,
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
    /// <summary>パターンが変更された
    /// </summary>
    public class EPatternsEditedEventArgs : EventArgs {
        private EnumTimeTableElementEventTypes type;
        private readonly CPattern source;
        public EnumTimeTableElementEventTypes Type {
            get { return type; }
        }
        public CPattern Source {
            get { return source; }
        }
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
        public EnumTimeTableElementEventTypes Type {
            get { return type; }
        }
        public CMember Source {
            get { return source; }
        }
        public EMembersEditedEventArgs (EnumTimeTableElementEventTypes EventType, CMember EventSource) {
            this.type = EventType;
            this.source = EventSource;
        }
    }
    /// <summary>必要人数が変更された
    /// </summary>
    public class ERequirePatternssEditedEventArgs : EventArgs {
        private EnumTimeTableElementEventTypes type;
        private readonly CRequirePatterns source;
        public EnumTimeTableElementEventTypes Type {
            get { return type; }
        }
        public CRequirePatterns Source {
            get { return source; }
        }
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
        public EnumTimeTableElementEventTypes Type {
            get { return type; }
        }
        public CDayOff Source {
            get { return source; }
        }
        public EDayOffsEditedEventArgs (EnumTimeTableElementEventTypes EventType, CDayOff EventSource) {
            this.type = EventType;
            this.source = EventSource;
        }
    }
    /// <summary>プロパティが変更された
    /// </summary>
    public class EPropertyChangedEventArgs : EventArgs {
        private readonly string key, val;
        public String Key {
            get {
                return key;
            }
        }
        public String Value {
            get {
                return val;
            }
        }
        public EPropertyChangedEventArgs (string param0, string param1) {
            this.key = param0;
            this.val = param1;
        }
    }
    /// <summary>スケジュール日の必要人数が変更された
    /// </summary>
    public class EScheduleDateRequirePatternsEditedEventArgs : EventArgs {
        private readonly CScheduledDate sdate;
        private readonly CRequirePatterns require;
        public CScheduledDate ScheduledDate {
            get { return sdate; }
        }
        public CRequirePatterns RequirePatterns {
            get { return require; }
        }
        public EScheduleDateRequirePatternsEditedEventArgs (CScheduledDate param0, CRequirePatterns param1) {
            this.sdate = param0;
            this.require = param1;
        }
    }
    /// <summary>分析結果が変更された
    /// </summary>
    public class EEvaluationItemEditedEventArgs : EventArgs {
        private EnumTimeTableElementEventTypes type;
        private readonly CEvaluationItem source;
        public EnumTimeTableElementEventTypes Type {
            get { return type; }
        }
        public CEvaluationItem Source {
            get { return source; }
        }
        public EEvaluationItemEditedEventArgs (EnumTimeTableElementEventTypes EventType, CEvaluationItem EventSource) {
            this.type = EventType;
            this.source = EventSource;
        }
    }
}
