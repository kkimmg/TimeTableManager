using System;
using System.Collections.Generic;
using System.Text;
using TimeTableManager.DefaultElement;

namespace TimeTableManager.UI {
    class ECurrentDateChangedArgs : EventArgs {
        private readonly CScheduledDate scheduleDate;
        /// <summary>
        /// カレントのスケジュール日
        /// </summary>
        public CScheduledDate ScheduleDate {
            get { return scheduleDate; }
        }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="source"></param>
        public ECurrentDateChangedArgs (CScheduledDate source) {
            this.scheduleDate = source;
        }
    }
}
