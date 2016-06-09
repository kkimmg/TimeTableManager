using System;
using TimeTableManager.ElementCollection;

namespace TimeTableManager.Element {
    /// <summary>休日
    /// </summary>
    public class CDayOff : CAbstractElement {
        private CDayOffCollection parent;
        private string name;
        private DateTime start;
        private DateTime end;
        /// <summary>コンストラクタ
        /// </summary>
        /// <param name="parent">休日の一覧</param>
        public CDayOff (CDayOffCollection parent) {
            // 
            // TODO: コンストラクタ ロジックをここに追加してください。
            //
            this.parent = parent;
        }
        /// <summary>
        /// 休日の開始
        /// </summary>
        public DateTime StartDate {
            get {
                return start;
            }
            set {
                start = value;
            }
        }
        /// <summary>
        /// 休日の終了
        /// </summary>
        public DateTime EndDate {
            get {
                return end;
            }
            set {
                end = value;
            }
        }
        /// <summary>
        /// タイムテーブル
        /// </summary>
        public override CTimeTable TimeTable {
            get {
                return parent.TimeTable;
            }
        }
        /// <summary>
        /// 休日の名称
        /// </summary>
        public string Name {
            get {
                return name;
            }
            set {
                name = value;
            }
        }
        /// <summary>
        /// 削除日
        /// </summary>
        public override DateTime? Removed {
            get {
                return this.EndDate;
            }
        }
    }
}
