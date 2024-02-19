using System;
using System.Collections.Generic;
using System.Text;
using TimeTableManager.Element;

namespace TimeTableManager.UI {
    /// <summary>
    /// 選択行が変わったのでカレント日が変わった
    /// </summary>
    public class ECurrentDateChangedArgs : EventArgs {
        private readonly BScheduledDate scheduleDate;
        /// <summary>
        /// カレントのスケジュール日
        /// </summary>
        public BScheduledDate ScheduleDate {
            get { return scheduleDate; }
        }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="source"></param>
        public ECurrentDateChangedArgs (BScheduledDate source) {
            this.scheduleDate = source;
        }
    }
}
