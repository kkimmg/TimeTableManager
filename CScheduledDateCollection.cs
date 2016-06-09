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
    class DateComparer2 : IComparer<CScheduledDate> {
        #region IComparer メンバ
        public int Compare (CScheduledDate x, CScheduledDate y) {
            DateTime date1 = x.Date;
            DateTime date2 = y.Date;
            return date1.CompareTo(date2);
        }
        #endregion
    }
    /// <summary>スケジュール日のコレクション
    /// </summary>
    public class CScheduledDateCollection {
        /// <summary>初期化処理
        /// </summary>
        private void InitBlock () {
            schedules = new List<CScheduledDate>();
        }
        /// <summary>スケジュールすべて</summary>
        virtual public CTimeTable TimeTable {
            get {
                return timeTable;
            }
        }
        /// <summary>スケジュールすべて </summary>
        private CTimeTable timeTable;
        /// <summary>スケジュール（オブジェクトID順） </summary>
        private List<CScheduledDate> schedules;
        /// <summary>XMLノードよりスケジュール化された日付のコレクションを作成する</summary>
        public CScheduledDateCollection (CTimeTable parent) {
            InitBlock();
            timeTable = parent;
            timeTable.OnMembersEdited += new CTimeTable.MembersEditedEventHandler(timeTable_OnMembersEdited);
        }
        /// <summary>スケジュール日の追加</summary>
        protected internal virtual void AddScheduleDate (CScheduledDate sd) {
            schedules.Add(sd);
            //schedules.Sort();
            Sort2();
        }
        /// <summary>スケジュール日の作成</summary>
        protected internal virtual CScheduledDate CreateScheduledDate (System.DateTime d) {
            CScheduledDate ret = new CScheduledDate(d, TimeTable);
            if (this.TimeTable.IsDayOff(d)) {
                ret.Require = CRequirePatterns.DAYOFF;
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
        public virtual void DelScheduledDate (CScheduledDate d) {
            schedules.Remove(d);
        }
        /// <summary>スケジュール日の取得
        /// </summary>
        /// <param name="n">日付</param>
        /// <returns>スケジュール日</returns>
        private CScheduledDate GetScheduledDate (DateTime n) {
            CScheduledDate retValue = null;


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
        private CScheduledDate GetScheduledDate (int n) {
            return schedules[n];
        }
        /// <summary>IDによるスケジュール日の取得
        /// </summary>
        /// <param name="index">ID</param>
        /// <returns>スケジュール日</returns>
        public virtual CScheduledDate GetByID (int index) {
            DateTime datetime = new DateTime(index / 10000, (index % 10000) / 100, index % 100);
            CScheduledDate work = new CScheduledDate(datetime, this.TimeTable);
            //work.ObjectID = index;
            int i = schedules.BinarySearch(work);
            if (i < 0) {
                work = CreateScheduledDate(datetime);
                AddScheduleDate(work);
                return work;
            }
            return (CScheduledDate)schedules[i];
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
        public CScheduledDate this[int n] {
            get {
                return GetScheduledDate(n);
            }
        }
        /// <summary>日付によるスケジュール日の所得
        /// </summary>
        /// <param name="d">日付</param>
        /// <returns>スケジュール日</returns>
        public CScheduledDate this[DateTime d] {
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
        public void ClearMember (CMember member, DateTime date) {
            CScheduledDate work = CreateScheduledDate(date);
            int i = schedules.BinarySearch(work);
            if (i < 0) return;
            for (int j = i; j < schedules.Count; j++) {
                CScheduledDate sdate = schedules[j];
                CSchedule schedule = sdate[member];
                schedule.Pattern = null;
            }
        }
        /// <summary>メンバーの削除
        /// </summary>
        /// <param name="member">削除するメンバー</param>
        public void ClearMember (CMember member) {
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