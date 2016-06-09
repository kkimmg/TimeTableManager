using System;
using System.Collections.Generic;
namespace TimeTableManager.Element {
    /// <summary>ランダム化する（デフォルト）
    /// </summary>
    public class CDefaultFavoriteRandomizer : IFavoriteRandomizer {
        /// <summary>名称
        /// </summary>
        public const string RANDNAME = "DEFAULT";
        /// <summary>タイムテーブル
        /// </summary>
        private CTimeTable table;
        /// <summary>乱数発生装置
        /// </summary>
        private System.Random random;
        /// <summary>コンストラクタ
        /// </summary>
        public CDefaultFavoriteRandomizer() {
            random = new System.Random();
        }
        /// <summary>名称
        /// </summary>
        public virtual string Name {
            get {
                return CDefaultFavoriteRandomizer.RANDNAME;
            }
        }
        /// <summary>当日からこの日数分は自動設定しない
        /// </summary>
        private int dayAfter = 0;
        /// <summary>当日からこの日数分は自動設定しない
        /// </summary>
        public virtual int DayAfter {
            get {
                return dayAfter;
            }
            set {
                dayAfter = value;
            }
        }
        /// <summary> 乱数発生装置
        /// </summary>
        protected virtual System.Random Random1 {
            get {
                return random;
            }

            set {
                this.random = value;
            }

        }
        /// <summary>タイムテーブル
        /// </summary>
        protected virtual CTimeTable Table {
            get { return table; }
            set { table = value; }
        }
        /// <summary>自動設定する
        /// </summary>
        /// <param name="ptable">設定するタイムテーブル</param>
        /// <param name="Adate">開始</param>
        public virtual void AutoAllwithChief(CTimeTable ptable, DateTime Adate) {
            AutoAllwithChief(ptable, Adate, Adate);
        }
        /// <summary>自動設定する
        /// </summary>
        /// <param name="ptable">設定するタイムテーブル</param>
        /// <param name="start">開始</param>
        /// <param name="end">終了</param>
        public virtual void AutoAllwithChief(CTimeTable ptable, DateTime start, DateTime end) {
            DateTime today = DateTime.Today;
            if (DayAfter > 0) {
                today = DateTime.Today.AddDays(DayAfter);
            }
            AutoAllwithChief(ptable, today, start, end);
        }
        /// <summary>自動設定する
        /// </summary>
        /// <param name="ptable">設定するタイムテーブル</param>
        /// <param name="today">基準日</param>
        /// <param name="start">開始</param>
        /// <param name="end">終了</param>
        public virtual void AutoAllwithChief(CTimeTable ptable, DateTime today, DateTime start, DateTime end) {
            this.Table = ptable;
            DateTime work = start.Date;
            while (work <= end) {
                // 終了日以前で
                if (work >= today) {
                    // 今日以降
                    CScheduledDate sdate = this.Table[work];
                    AutoAllwithChief(sdate);
                }
                work = work.AddDays(1.0);
            }
        }
        /// <summary> メンバーとシフトの好みの組み合わせを自動設定してみる。
        /// </summary>
        protected virtual void AutoAllwithChief(CScheduledDate sDate) {
            // メンバーのこのみをセットする
            for (int i = 0; i < sDate.ValidMemberSize; i++) {
                SetFavoriteMemberStand(sDate, sDate.GetValidMember(i));
            }
            // スケジュールのこのみをセットする
            CRequirePatterns req = sDate.Require;
            if (req != null) {
                for (int i = 0; i < req.ValidSize; i++) {
                    SetFavoritePatternStand(sDate, sDate.Require.GetValid(i));
                }
            }
        }
        /// <summary> メンバーのシフトの好みを自動設定する
        /// </summary>
        /// <param name="sDate">スケジュール化された（自動設定対象の）日付</param>
        /// <param name="member">設定するメンバー</param>
        protected virtual void SetFavoriteMemberStand(CScheduledDate sDate, CMember member) {
            SetFavoriteMemberStand(sDate, member, false);
        }
        /// <summary> メンバーのシフトの好みを自動設定する
        /// </summary>
        /// <param name="sDate">スケジュール化された（自動設定対象の）日付</param>
        /// <param name="member">設定するメンバー</param>
        /// <param name="force">休みを気にするかどうか</param>
        protected virtual void SetFavoriteMemberStand(CScheduledDate sDate, CMember member, bool force) {
            //
            List<CPattern> Candicates = new List<CPattern>();
            //	メンバーの有効なシフトのリストを作成する
            for (int i = 0; i < member.PatternSize; i++) {
                CPattern pattern = member.GetPattern(i);
                if (pattern.IsAvailable(sDate.Date)) {
                    CRequirePatterns require = sDate.Require;
                    if (require != null) {
                        for (int j = 0; j < require.ValidSize; j++) {
                            CPattern reqpat = sDate.Require.GetValid(j);
                            if (pattern.Equals(reqpat)) {
                                Candicates.Add(pattern);
                            }
                        }
                    }
                }
            }
            // 休み設定
            int conu = member.ContinuasInt;
            int cont = sDate.GetMemberContinues(member, conu);
            int rest = conu - cont;
            // 候補の数
            int candicateSize = Candicates.Count;
            // 作成したリストからメンバーに対して好みを割り振る
            for (int i = 0; i < candicateSize; i++) {
                int rand = 0;
                if (Candicates.Count > 1) {
                    rand = Random1.Next(Candicates.Count);
                }
                CPattern pattern = Candicates[rand];
                Candicates.Remove(pattern);
                if (member.IsAvalableDay(sDate.Date.DayOfWeek)) {
                    // 稼動の曜日
                    if ((rest > i || conu <= 0) || force) {
                        // 連続稼動の許容範囲内
                        sDate.SetPatternRank(member, pattern, i);
                    } else {
                        // 連続稼動の許容範囲外
                        sDate.SetPatternRank(member, CPattern.DAYOFF, i);
                    }
                } else {
                    // せっかく設定したんですが曜日の都合で・・・                
                    sDate.SetPatternRank(member, CPattern.DAYOFF, i);
                }
            }
        }
        /// <summary> シフトのメンバーの好みを自動設定する
        /// </summary>
        /// <param name="sDate">スケジュール化された（自動設定対象の）日付</param>
        /// <param name="pattern">設定するシフト</param>
        protected virtual void SetFavoritePatternStand(CScheduledDate sDate, CPattern pattern) {
            if (!pattern.IsAvailable(sDate.Date)) {
                // シフトが無効なら処理を抜ける
                return;
            }
            List<CMember> Candicates = new List<CMember>();
            //	シフトの有効なメンバーのリストを作成する
            for (int i = 0; i < sDate.ValidMemberSize; i++) {
                CMember m = sDate.GetValidMember(i);
                for (int j = 0; j < m.PatternSize; j++) {
                    CPattern pat = m.GetPattern(j);
                    if (pattern.Equals(pat)) {
                        Candicates.Add(m);
                    }
                }
            }
            int candicateSize = Candicates.Count;
            //	作成したリストからシフトに対して好みを割り振る
            for (int i = 0; i < candicateSize; i++) {
                int rand = 0;
                if (Candicates.Count > 1) {
                    rand = Random1.Next(Candicates.Count);
                }
                CMember member = Candicates[rand];
                Candicates.Remove(member);
                sDate.SetMemberRank(pattern, member, i);
            }
        }
        /// <summary>好みをコピーする
        /// </summary>
        /// <param name="src">元</param>
        /// <param name="dst">先</param>
        protected virtual void CopyFavorites(CScheduledDate src, CScheduledDate dst) {
            // メンバーのシフトの好み
            for (int i = 0; i < src.ValidMemberSize; i++) {
                CMember member = src[i].Member;
                for (int j = 0; j < member.PatternSize; j++) {
                    CPattern pattern = src.GetMembersPattern(member, j);
                    dst.SetPatternRank(member, pattern, j);
                }
            }
            // スケジュールのこのみをセットする
            CRequirePatterns req = dst.Require;
            if (req != null && req == src.Require) {
                for (int i = 0; i < req.ValidSize; i++) {
                    CPattern pattern = req.GetValid(i);
                    for (int j = 0; j < src.ValidMemberSize; j++) {
                        CMember member = src.GetPatternsMember(pattern, j);
                        dst.SetMemberRank(pattern, member, j);
                    }
                }
            }
        }
    }
    /// <summary>１ヶ月同じシフトを繰り返す
    /// </summary>
    public class CMonthlyFavoriteRandomizer : CDefaultFavoriteRandomizer {
        /// <summary>名称
        /// </summary>
        public new const string RANDNAME = "MONTHLY";
        private Dictionary<CRequirePatterns, CScheduledDate> dic = new Dictionary<CRequirePatterns, CScheduledDate>();
        /// <summary>名称
        /// </summary>
        public override string Name {
            get {
                return CMonthlyFavoriteRandomizer.RANDNAME;
            }
        }
        /// <summary>オーバーライド
        /// </summary>
        /// <param name="sDate"></param>
        protected override void AutoAllwithChief(CScheduledDate sDate) {
            if (sDate.Date.Day == 1) {
                // 月の頭にクリアする
                dic.Clear();
            }
            if (sDate.Require == null || sDate.Require.BuiltIn) {
                // 休みか未設定なら何もしない
            } else {
                if (dic.ContainsKey(sDate.Require)) {
                    CScheduledDate source = dic[sDate.Require];
                    CopyFavorites(source, sDate);
                } else {
                    base.AutoAllwithChief(sDate);
                    dic.Add(sDate.Require, sDate);
                }
            }
        }
    }
    /// <summary>１週間同じシフトを繰り返す
    /// </summary>
    public class CWeeklyFavoriteRandomizer : CDefaultFavoriteRandomizer {
        /// <summary>名称
        /// </summary>
        public new const string RANDNAME = "WEEKLY";
        private Dictionary<CRequirePatterns, CScheduledDate> dic = new Dictionary<CRequirePatterns, CScheduledDate>();
        /// <summary>名称
        /// </summary>
        public override string Name {
            get {
                return CWeeklyFavoriteRandomizer.RANDNAME;
            }
        }
        /// <summary>オーバーライド
        /// </summary>
        /// <param name="sDate"></param>
        protected override void AutoAllwithChief(CScheduledDate sDate) {
            if (sDate.Date.DayOfWeek == DayOfWeek.Monday) {
                // 月曜日にクリアする
                dic.Clear();
            }
            if (sDate.Require == null || sDate.Require.BuiltIn) {
                // 休みか未設定なら何もしない
            } else {
                if (dic.ContainsKey(sDate.Require)) {
                    CScheduledDate source = dic[sDate.Require];
                    CopyFavorites(source, sDate);
                } else {
                    base.AutoAllwithChief(sDate);
                    dic.Add(sDate.Require, sDate);
                }
            }
        }
    }
    /// <summary>１ヶ月同じ曜日ごとにシフトを繰り返す
    /// </summary>
    public class CMonthlyWeeklyFavoriteRandomizer : CDefaultFavoriteRandomizer {
        /// <summary>名称
        /// </summary>
        public new const string RANDNAME = "MONTHLYWEEKLY";
        private Dictionary<DayOfWeek, CScheduledDate> dic = new Dictionary<DayOfWeek, CScheduledDate>();
        /// <summary>名称
        /// </summary>
        public override string Name {
            get {
                return CMonthlyWeeklyFavoriteRandomizer.RANDNAME;
            }
        }
        /// <summary>オーバーライド
        /// </summary>
        /// <param name="sDate"></param>
        protected override void AutoAllwithChief(CScheduledDate sDate) {
            if (sDate.Date.Day == 1) {
                // 月の頭にクリアする
                dic.Clear();
            }
            if (sDate.Require == null || sDate.Require.BuiltIn) {
                // 休みか未設定なら何もしない
            } else {
                DayOfWeek dayofweek = sDate.Date.DayOfWeek;
                if (dic.ContainsKey(dayofweek)) {
                    CScheduledDate source = dic[dayofweek];
                    CopyFavorites(source, sDate);
                } else {
                    base.AutoAllwithChief(sDate);
                    dic.Add(dayofweek, sDate);
                }
            }
        }
    }
}