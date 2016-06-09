using System;
using System.Collections.Generic;
using System.Text;
using TimeTableManager.DefaultElement;

namespace TimeTableManager.Evaluation {

    /// <summary>
    /// ソート用
    /// </summary>
    class PatternComparer1 : IComparer<CPattern> {
        #region IComparer メンバ
        public int Compare (CPattern x, CPattern y) {
            int ret = 0;
            if (x.Start < y.Start) {
                ret = -1;
            } else if (x.Start > y.Start) {
                ret = 1;
            } else {
                if (x.End < y.End) {
                    ret = -1;
                } else if (x.End > y.End) {
                    ret = 1;
                }
            }
            return ret;
        }
        #endregion
    }
    /// <summary>
    /// １日分の評価
    /// </summary>
    public class CEvaluation1Day {
        /// <summary>
        /// タイムスパンのセットまたは空白
        /// </summary>
        private class TimeSpanSet {
            private readonly TimeSpan start, end;
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="Start"></param>
            /// <param name="End"></param>
            public TimeSpanSet (TimeSpan Start, TimeSpan End) {
                this.start = Start;
                this.end = End;
            }
            /// <summary>
            /// 空白の始まり
            /// </summary>
            public TimeSpan Start {
                get {
                    return start;
                }
            }
            /// <summary>
            /// 空白の終わり
            /// </summary>
            public TimeSpan End {
                get {
                    return end;
                }
            }
        }
        /// <summary>
        /// スケジュール日
        /// </summary>
        public readonly CScheduledDate sdate;
        /// <summary>
        /// 内部リスト
        /// </summary>
        private List<EvaluationItem> _items = new List<EvaluationItem>();
        /// <summary>
        /// メンバー、評価
        /// </summary>
        private Dictionary<CMember, Evaluation1Day1Member> _memItems = new Dictionary<CMember, Evaluation1Day1Member>();
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="sDate"></param>
        public CEvaluation1Day (CScheduledDate sDate) {
            this.sdate = sDate;
            Check();
        }
        /// <summary>
        /// ここで検証
        /// </summary>
        public void Check () {
            Clear();
            CheckPatternMuches();
            CheckSpaces();
            CheckMembers();
        }
        /// <summary>
        /// 検証結果の追加
        /// </summary>
        /// <param name="item"></param>
        private void AddItem (EvaluationItem item) {
            Items.Add(item);
            _items.Add(item);
        }
        /// <summary>
        /// 検証結果の追加
        /// </summary>
        /// <param name="item"></param>
        private void AddItem (EvaluationResult result, string message) {
            AddItem(new EvaluationItem(result, sdate, message));
        }
        /// <summary>
        /// クリア
        /// </summary>
        public void Clear () {
            for (int i = 0; i < _items.Count; i++) {
                Items.Remove(_items[i]);
            }
            _items.Clear();
        }
        /// <summary>
        /// 時間中に空白が生じないか？
        /// </summary>
        /// <returns>空白時間のリスト</returns>
        private List<TimeSpanSet> CheckSpaces (List<CPattern> patterns) {
            List<TimeSpanSet> ret = new List<TimeSpanSet>();
            //List<Pattern> patterns = GetDatePatterns();
            if (patterns.Count > 0) {
                TimeSpan end = patterns[0].End;
                for (int i = 1; i < patterns.Count; i++) {
                    if (patterns[i].Start > end) {
                        // 空白が生じる
                        ret.Add(new TimeSpanSet(end, patterns[i].Start));
                        AddItem(EvaluationResult.ERROR, (sdate.Date + end) + "～" + (sdate.Date + patterns[i].Start) + "に空白が生じています。");
                    }
                    if (patterns[i].End > end) {
                        // 終端を更新する
                        end = patterns[i].End;
                    }
                }
                // 開始時間
                if (patterns[0].Start > Root.StartTime) {
                    AddItem(EvaluationResult.WARNING, (sdate.Date + Root.StartTime) + "～" + (sdate.Date + patterns[0].Start) + "に空白が生じています。");
                }
                // 終了時間
                if (patterns[patterns.Count - 1].End > Root.EndTime) {
                    AddItem(EvaluationResult.WARNING, (sdate.Date + Root.EndTime) + "～" + (sdate.Date + patterns[patterns.Count - 1].End) + "に空白が生じています。");
                }
            }
            return ret;
        }
        /// <summary>
        /// 時間中に空白が生じないか？
        /// </summary>
        /// <returns>空白時間のリスト</returns>
        private List<TimeSpanSet> CheckSpaces () {
            return CheckSpaces(GetDatePatterns());
        }
        /// <summary>
        /// パターンに対してマッチしているか？
        /// </summary>
        /// <param name="pattern">パターン</param>
        /// <returns>割合</returns>
        private double CheckPatternMuches (CPattern pattern) {
            double ret = 0;
            CRequirePatterns require = sdate.Require;
            if (require == null || require == CRequirePatterns.DAYOFF || require == CRequirePatterns.NULL) {
                // 休みなら常に条件を満たすことにする（必要人数が０だから）
                ret = 1.0;
            } else {
                int need = require.GetRequire(pattern);
                if (need <= 0) {
                    // 必要人数が０なら条件を常に満たす・・かな？
                    ret = 1.0;
                } else {
                    // 割合を計算してみる
                    int seed = GetPatternMemberCount(pattern);
                    ret = (double)seed / (double)need;
                    if (ret < 1) {
                        if (ret <= 0.0) {
                            AddItem(EvaluationResult.ERROR, pattern.Name + "が必要な人数を満たしていません。（" + need + "人中" + seed + "人）");
                        } else if (ret < 0.5) {
                            AddItem(EvaluationResult.WARNING, pattern.Name + "が必要な人数の半分を満たしていません。（" + need + "人中" + seed + "人）");
                        } else if (ret < 1) {
                            AddItem(EvaluationResult.NOTICE, pattern.Name + "が必要な人数を満たしていません。（" + need + "人中" + seed + "人）");
                        }
                    }
                }
            }
            return ret;
        }
        /// <summary>
        /// パターンに対してマッチしているか？（１日単位で）
        /// </summary>
        /// <returns>割合</returns>
        private double CheckPatternMuches () {
            double ret = 0.0;
            CRequirePatterns require = sdate.Require;
            if (require == null) return 1.0;
            List<CPattern> patterns = new List<CPattern>();
            for (int i = 0; i < require.Size(); i++) {
                patterns.Add(require.GetPattern(i));
            }
            int j = 0;
            for (int i = 0; i < patterns.Count; i++) {
                CPattern pattern = patterns[i];
                if (pattern.IsAvailable(sdate.Date)) {
                    double work = CheckPatternMuches(pattern);
                    //if (work > 1) {
                    //    work = 1.0;
                    //} else {
                    //    if (work < 1) {
                    //        AddItem(EvaluationResult.NOTICE, pattern.Name + "が必要な人数を満たしていません。");
                    //    } else if (work < 0.5) {
                    //        AddItem(EvaluationResult.WARNING, pattern.Name + "が必要な人数の半分を満たしていません。");
                    //    } else if (work <= 0.0) {
                    //        AddItem(EvaluationResult.ERROR, pattern.Name + "が必要な人数を満たしていません。");
                    //    }
                    //}
                    ret += work;
                    j++;
                }
            }
            ret = (j > 0 ? ret / (double)j : 1.0);
            return ret;
        }
        /// <summary>
        /// スケジュール日に設定されたパターンの一覧
        /// </summary>
        /// <returns>パターンのリスト</returns>
        private List<CPattern> GetDatePatterns () {
            List<CPattern> ret = new List<CPattern>();
            int max = sdate.ValidMemberSize;
            for (int i = 0; i < max; i++) {
                CMember member = sdate.GetValidMember(i);
                CSchedule schedule = sdate[member];
                if (schedule != null) {
                    CPattern pattern = schedule.Pattern;
                    if (pattern == null || pattern.BuiltIn) {
                    } else {
                        if (!ret.Contains(pattern)) {
                            ret.Add(pattern);
                        }
                    }
                }
            }
            ret.Sort(new PatternComparer1());
            return ret;
        }
        /// <summary>
        /// パターンのメンバー数
        /// </summary>
        /// <param name="pattern">パターン</param>
        /// <returns>パターンに該当するメンバー数</returns>
        private int GetPatternMemberCount (CPattern pattern) {
            int ret = 0;
            int max = sdate.ValidMemberSize;
            for (int i = 0; i < max; i++) {
                CMember member = sdate.GetValidMember(i);
                CSchedule schedule = sdate[member];
                if (schedule.Pattern == pattern) {
                    ret++;
                }
            }
            return ret;
        }
        /// <summary>
        /// タイムテーブル
        /// </summary>
        private CTimeTable Root {
            get {
                return sdate.TimeTable;
            }
        }
        /// <summary>
        /// リスト
        /// </summary>
        private List<EvaluationItem> Items {
            get {
                return Root.EvaluationItems;
            }
        }
        /// <summary>
        /// メンバーごとのチェック
        /// </summary>
        private void CheckMembers () {
            int j = sdate.ValidMemberSize;
            for (int i = 0; i < j; i++) {
                CSchedule schedule = sdate[i];
                CMember member = schedule.Member;
                if (_memItems.ContainsKey(member)) {
                    Evaluation1Day1Member work = _memItems[member];
                    work.Check();
                } else {
                    Evaluation1Day1Member work = new Evaluation1Day1Member(this, member);
                    _memItems.Add(member, work);
                    work.Check();
                }
            }
        }
    }
    /// <summary>
    /// １日分、１メンバー分の評価
    /// </summary>
    public class Evaluation1Day1Member {
        /// <summary>
        /// タイムテーブル
        /// </summary>
        private CTimeTable Root {
            get {
                return _parent.sdate.TimeTable;
            }
        }
        /// <summary>
        /// リスト
        /// </summary>
        private List<EvaluationItem> Items {
            get {
                return Root.EvaluationItems;
            }
        }
        /// <summary>
        /// 内部リスト
        /// </summary>
        private List<EvaluationItem> _items = new List<EvaluationItem>();
        /// <summary>
        /// 親オブジェクト
        /// </summary>
        CEvaluation1Day _parent;
        /// <summary>
        /// メンバー 
        /// </summary>
        CMember _member;
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="member"></param>
        public Evaluation1Day1Member (CEvaluation1Day parent, CMember member) {
            _parent = parent;
            _member = member;
            Check();
        }
        /// <summary>
        /// チェックする
        /// </summary>
        public void Check () {
            Clear();
            CheckContinuas();
            CheckSpace();
        }
        /// <summary>
        /// クリア
        /// </summary>
        public void Clear () {
            for (int i = 0; i < _items.Count; i++) {
                Items.Remove(_items[i]);
            }
            _items.Clear();
        }
        /// <summary>
        /// スケジュール日
        /// </summary>
        private CScheduledDate sdate {
            get {
                return _parent.sdate;
            }
        }
        /// <summary>
        /// 検証結果の追加
        /// </summary>
        /// <param name="item"></param>
        private void AddItem (EvaluationItem item) {
            Items.Add(item);
            _items.Add(item);
        }
        /// <summary>
        /// 検証結果の追加
        /// </summary>
        /// <param name="item"></param>
        private void AddItem (EvaluationResult result, string message) {
            AddItem(new EvaluationItem(result, sdate, message));
        }
        /// <summary>
        /// メンバーの連続稼動日数が※1の日数を超えていたら警告
        /// </summary>
        private void CheckContinuas () {
            CSchedule schedule = sdate[_member];
            if (schedule == null) return;
            CPattern pattern = schedule.Pattern;
            if (pattern == null || pattern.BuiltIn) return;

            // 休み設定
            int conu = _member.ContinuasInt;
            if (conu > 0) {
                int cont = sdate.GetMemberContinues(_member, conu * 2);
                int rest = conu - cont;
                if (rest <= 0) {
                    if (cont >= conu * 2) {
                        AddItem(EvaluationResult.ERROR, _member.Name + "の作業日が" + (cont + 1) + "日以上連続しています。");
                    } else {
                        AddItem(EvaluationResult.WARNING, _member.Name + "の作業日が" + (cont + 1) + "日連続しています。");
                    }
                }
            }
        }
        /// <summary>
        /// メンバーの作業時間の重複（エラー）または※2の時間を満たしていなければ警告
        /// </summary>
        private void CheckSpace () {
            CSchedule tsche = sdate[_member];
            CPattern tpatt = tsche.Pattern;
            if (!(tpatt == null || tpatt.BuiltIn)) {
                // 今日のパターンが存在する
                DateTime today = sdate.Date;
                DateTime yesterday = today.AddDays(-1).Date;
                CScheduledDate ydate = Root[yesterday];
                CSchedule ysche = ydate[_member];
                CPattern ypatt = ysche.Pattern;
                if (!(ypatt == null || ypatt.BuiltIn)) {
                    // 昨日のパターンが存在する！
                    DateTime yend = yesterday + ypatt.End;
                    DateTime tend = yend + _member.Spacetime;
                    DateTime tstt = today + tpatt.Start;
                    if (yend >= tstt) {
                        AddItem(EvaluationResult.ERROR, _member.Name + "の作業時間が重複しています。（" + tstt + "～" + yend + "）");
                    } else if (tend > tstt) {
                        AddItem(EvaluationResult.WARNING, _member.Name + "の作業間隔が不足しています。（" + yend + "～" + tstt + "）");
                    }
                }
            }
        }
    }
}
