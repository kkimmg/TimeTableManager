using System;
using System.Collections;
using System.Collections.Generic;
using TimeTableManager.Element;

namespace TimeTableManager.ElementCollection {
    /// <summary>ソート用
    /// </summary>
    class DateComparer1 : IComparer<DateTime> {
        #region IComparer メンバ
        public int Compare (DateTime x, DateTime y) {
            DateTime date1 = x;
            DateTime date2 = y;
            return date1.CompareTo(date2);
        }
        #endregion
    }
    /// <summary>ソート用
    /// </summary>
    class DateComparer2 : IComparer<BScheduledDate> {
        #region IComparer メンバ
        public int Compare (BScheduledDate x, BScheduledDate y) {
            DateTime date1 = x.Date;
            DateTime date2 = y.Date;
            return date1.CompareTo(date2);
        }
        #endregion
    }
    /// <summary>スケジュール日のコレクション
    /// </summary>
    public class BScheduledDateCollection {
        /// <summary>初期化処理
        /// </summary>
        private void InitBlock () {
            schedules = new List<BScheduledDate>();
        }
        /// <summary>スケジュールすべて</summary>
        virtual public BTimeTable TimeTable {
            get {
                return timeTable;
            }
        }
        /// <summary>スケジュールすべて </summary>
        private BTimeTable timeTable;
        /// <summary>スケジュール（オブジェクトID順） </summary>
        private List<BScheduledDate> schedules;
        /// <summary>XMLノードよりスケジュール化された日付のコレクションを作成する</summary>
        public BScheduledDateCollection (BTimeTable parent) {
            InitBlock();
            timeTable = parent;
            timeTable.OnMembersEdited += new BTimeTable.MembersEditedEventHandler(timeTable_OnMembersEdited);
        }
        /// <summary>スケジュール日の追加</summary>
        protected internal virtual void AddScheduleDate (BScheduledDate sd) {
            schedules.Add(sd);
            //schedules.Sort();
            Sort2();
        }
        /// <summary>スケジュール日の作成</summary>
        protected internal virtual BScheduledDate CreateScheduledDate (System.DateTime d) {
            BScheduledDate ret = new BScheduledDate(d, TimeTable);
            if (this.TimeTable.IsDayOff(d)) {
                ret.Require = BRequirePatterns.DAYOFF;
            } else {
                if (this.TimeTable.GetDefaultRequire(d.DayOfWeek) != null) {
                    ret.Require = this.TimeTable.GetDefaultRequire(d.DayOfWeek);
                } else {
                    if (this.TimeTable.DefaultRequire != null) {
                        ret.Require = this.TimeTable.DefaultRequire;
                    }
                }
            }
            return ret;
        }
        /// <summary>スケジュール日の削除
        /// </summary>
        /// <param name="d">削除するスケジュール日</param>
        public virtual void DelScheduledDate (BScheduledDate d) {
            schedules.Remove(d);
        }
        /// <summary>スケジュール日の取得
        /// </summary>
        /// <param name="n">日付</param>
        /// <returns>スケジュール日</returns>
        private BScheduledDate GetScheduledDate (DateTime n) {
            BScheduledDate retValue = null;


            int index = n.Year * 10000 + n.Month * 100 + n.Day;

            retValue = GetByID(index);

            if (retValue == null) {
                retValue = CreateScheduledDate(n);
                AddScheduleDate(retValue);
            }
            return retValue;
        }
        /// <summary>スケジュール日の取得
        /// </summary>
        /// <param name="n">n番目のスケジュール日</param>
        /// <returns>n番目のスケジュール日</returns>
        private BScheduledDate GetScheduledDate (int n) {
            return schedules[n];
        }
        /// <summary>IDによるスケジュール日の取得
        /// </summary>
        /// <param name="index">ID</param>
        /// <returns>スケジュール日</returns>
        public virtual BScheduledDate GetByID (int index) {
            DateTime datetime = new DateTime(index / 10000, (index % 10000) / 100, index % 100);
            BScheduledDate work = new BScheduledDate(datetime, this.TimeTable);
            //work.ObjectID = index;
            int i = schedules.BinarySearch(work);
            if (i < 0) {
                work = CreateScheduledDate(datetime);
                AddScheduleDate(work);
                return work;
            }
            return (BScheduledDate)schedules[i];
        }
        /// <summary>サイズ
        /// </summary>
        /// <returns>サイズ</returns>
        public virtual int Size () {
            return schedules.Count;
        }
        /// <summary>含まれる要素の数=Size()
        /// </summary>
        public int Count {
            get {
                return Size();
            }
        }
        /// <summary>スケジュール日の取得
        /// </summary>
        /// <param name="n">n番目のスケジュール日</param>
        /// <returns>n番目のスケジュール日</returns>
        public BScheduledDate this[int n] {
            get {
                return GetScheduledDate(n);
            }
        }
        /// <summary>日付によるスケジュール日の所得
        /// </summary>
        /// <param name="d">日付</param>
        /// <returns>スケジュール日</returns>
        public BScheduledDate this[DateTime d] {
            get {
                return GetScheduledDate(d);
            }
        }
        /// <summary>内部ソートの呼び出し
        /// </summary>
        public void Sort2 () {
            DateComparer2 comp = new DateComparer2();
            this.schedules.Sort(comp);
        }
        /// <summary>メンバーの削除
        /// </summary>
        /// <param name="member">削除するメンバー</param>
        /// <param name="date">削除する日</param>
        public void ClearMember (BMember member, DateTime date) {
            BScheduledDate work = CreateScheduledDate(date);
            int i = schedules.BinarySearch(work);
            if (i < 0) return;
            for (int j = i; j < schedules.Count; j++) {
                BScheduledDate sdate = schedules[j];
                BSchedule schedule = sdate[member];
                schedule.Pattern = null;
            }
        }
        /// <summary>メンバーの削除
        /// </summary>
        /// <param name="member">削除するメンバー</param>
        public void ClearMember (BMember member) {
            if (member.Removed != null) {
                TimeTable.ScheduleEditedEvnetIsValid = false;
                ClearMember(member, (DateTime)member.Removed);
                TimeTable.ScheduleEditedEvnetIsValid = true;
            }
        }
        /// <summary>メンバーが削除された
        /// </summary>
        /// <param name="sender">タイムテーブル</param>
        /// <param name="e">イベント</param>
        void timeTable_OnMembersEdited (object sender, EMembersEditedEventArgs e) {
            if (e.Type == EnumTimeTableElementEventTypes.ElementRemoved) {       
                ClearMember(e.Source);                
            }
        }
    }
}