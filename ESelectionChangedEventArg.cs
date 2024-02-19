using System;
using System.Collections.Generic;
using System.Text;

namespace TimeTableManager.UI {
    /// <summary>選択内容が変わったイベント
    /// </summary>
    public class ESelectionChangedEventArg : EventArgs {
        private readonly TimeTableManager.Element.BTimeTable timeTable;
        /// <summary>タイムテーブル
        /// </summary>
        public TimeTableManager.Element.BTimeTable TimeTable {
            get { return timeTable; }
        } 

        private readonly List<DateTime> selectedDates;
        /// <summary>
        /// カレントのスケジュール日
        /// </summary>
        public List<DateTime> SelectedDates {
            get { return selectedDates; }
        }
        /// <summary>
        /// 選択された日付の終わり
        /// </summary>
        public DateTime MaximumSelection {
            get {
                DateTime maximumSelection;// = this.EndDate;
                if (selectedDates.Count == 0) {
                    maximumSelection = DateTime.MaxValue;
                } else {
                    maximumSelection = selectedDates[selectedDates.Count - 1];
                }
                return maximumSelection;
            }
        }
        /// <summary>
        /// 選択された日付の始まり
        /// </summary>
        public DateTime MinimumSelection {
            get {
                DateTime minimumSelection;// = this.EndDate;
                if (selectedDates.Count == 0) {
                    minimumSelection = DateTime.MinValue;
                } else {
                    minimumSelection = selectedDates[0];
                }
                return minimumSelection;
            }
        }
   
        /// <summary>
        /// 選択された日付の日数
        /// </summary>
        public int SelectedDateCount {
            get {
                if (SelectedDates == null) return 0;
                return selectedDates.Count;
            }
        }
        /// <summary>
        /// 選択された日付
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public DateTime SelectedDate (int i) {
            return selectedDates[i].Date;
        }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="source">イベントの発生元</param>
        /// <param name="table">タイムテーブル</param>
        public ESelectionChangedEventArg (List<DateTime> source, TimeTableManager.Element.BTimeTable table) {
            this.selectedDates = source;
            this.timeTable = table;
        }

    }
}
