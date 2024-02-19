using System;
using System.Collections.Generic;
using System.Text;
using TimeTableManager.Element;

namespace TimeTableManager.Evaluation {

    /// <summary>ソート用
    /// </summary>
    class BPatternComparer1 : IComparer<BPattern> {
        #region IComparer メンバ
        public int Compare (BPattern x, BPattern y) {
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
    /// <summary>１日分の評価
    /// </summary>
    public class BEvaluation1Day {
        private const string msg_space_occurs = "%1～%2に空白が生じています。";
        private const string msg_needs_unmuch_error = "%1が人員配置を満たしていません。（%2人中%3人）";
        private const string msg_needs_unmuch_worning = "%1が人員配置の半分を満たしていません。（%2人中%3人）";
        private const string msg_needs_unmuch_notice = "%1が人員配置を満たしていません。（%2人中%3人）";
        /// <summary>タイムスパンのセットまたは空白
        /// </summary>
        private class CTimeSpanSet {
            private readonly TimeSpan start, end;
            /// <summary>コンストラクタ
            /// </summary>
            /// <param name="Start"></param>
            /// <param name="End"></param>
            public CTimeSpanSet (TimeSpan Start, TimeSpan End) {
                this.start = Start;
                this.end = End;
            }
            /// <summary>空白の始まり
            /// </summary>
            public TimeSpan Start {
                get {
                    return start;
                }
            }
            /// <summary>空白の終わり
            /// </summary>
            public TimeSpan End {
                get {
                    return end;
                }
            }
        }
        /// <summary>スケジュール日
        /// </summary>
        public readonly BScheduledDate sdate;
        /// <summary>内部リスト
        /// </summary>
        private List<BEvaluationItem> _items = new List<BEvaluationItem>();
        /// <summary>メンバー、評価
        /// </summary>
        private Dictionary<BMember, CEvaluation1Day1Member> _memItems = new Dictionary<BMember, CEvaluation1Day1Member>();
        /// <summary>コンストラクタ
        /// </summary>
        /// <param name="sDate"></param>
        public BEvaluation1Day (BScheduledDate sDate) {
            this.sdate = sDate;
            Check();
        }
        /// <summary>ここで検証
        /// </summary>
        public void Check () {
            Clear();
            CheckPatternMuches();
            CheckSpaces();
            CheckMembers();
        }
        /// <summary>検証結果の追加
        /// </summary>
        /// <param name="item">検証結果</param>
        private void AddItem (BEvaluationItem item) {
            Items.Add(item);
            _items.Add(item);
        }
        /// <summary>検証結果の追加
        /// </summary>
        /// <param name="result">追加される検証結果</param>
        /// <param name="message">メッセージ</param>
        private void AddItem (EEvaluationResult result, string message) {
            AddItem(new BEvaluationItem(result, sdate, message));
        }
        /// <summary>クリア
        /// </summary>
        public void Clear () {
            for (int i = 0; i < _items.Count; i++) {
                Items.Remove(_items[i]);
            }
            _items.Clear();
        }
        /// <summary>メッセージに変換する
        /// </summary>
        /// <param name="message">メッセージ</param>
        /// <param name="param">メッセージ</param>
        /// <returns></returns>
        private string GenerateMessage (string message, string[] param) {
            string ret = message;
            if (param != null) {
                int i = 1;
                foreach (string txt in param) {
                    string p = "%" + i.ToString();
                    ret = ret.Replace(p, txt);
                    i++;
                }
            }
            return ret;
        }
        /// <summary>時間中に空白が生じないか？
        /// </summary>
        /// <returns>空白時間のリスト</returns>
        private List<CTimeSpanSet> CheckSpaces (List<BPattern> patterns) {
            List<CTimeSpanSet> ret = new List<CTimeSpanSet>();
            //List<Pattern> patterns = GetDatePatterns();
            if (patterns.Count > 0) {
                TimeSpan end = patterns[0].End;
                for (int i = 1; i < patterns.Count; i++) {
                    if (patterns[i].Start > end) {
                        // 空白が生じる
                        ret.Add(new CTimeSpanSet(end, patterns[i].Start));
                        AddItem(EEvaluationResult.ERROR, GenerateMessage(msg_space_occurs, new string[] { (sdate.Date + end).ToString(), (sdate.Date + patterns[i].Start).ToString() }));
                    }
                    if (patterns[i].End > end) {
                        // 終端を更新する
                        end = patterns[i].End;
                    }
                }
                // 開始時間
                if (patterns[0].Start > Root.StartTime) {
                    AddItem(EEvaluationResult.WORNING, GenerateMessage(msg_space_occurs, new string[] { (sdate.Date + Root.StartTime).ToString(), (sdate.Date + patterns[0].Start).ToString() }));
                }
                // 終了時間
                if (patterns[patterns.Count - 1].End > Root.EndTime) {
                    AddItem(EEvaluationResult.WORNING, GenerateMessage(msg_space_occurs, new string[] { (sdate.Date + Root.EndTime).ToString(), (sdate.Date + patterns[patterns.Count - 1].End).ToString()}));
                }
            }
            return ret;
        }
        /// <summary>時間中に空白が生じないか？
        /// </summary>
        /// <returns>空白時間のリスト</returns>
        private List<CTimeSpanSet> CheckSpaces () {
            return CheckSpaces(GetDatePatterns());
        }
        /// <summary>勤務シフトに対してマッチしているか？
        /// </summary>
        /// <param name="pattern">勤務シフト</param>
        /// <returns>割合</returns>
        private double CheckPatternMuches (BPattern pattern) {
            double ret = 0;
            BRequirePatterns require = sdate.Require;
            if (require == null || require == BRequirePatterns.DAYOFF || require == BRequirePatterns.NULL) {
                // 休みなら常に条件を満たすことにする（人員配置が０だから）
                ret = 1.0;
            } else {
                int need = require.GetRequire(pattern);
                if (need <= 0) {
                    // 人員配置が０なら条件を常に満たす・・かな？
                    ret = 1.0;
                } else {
                    // 割合を計算してみる
                    int seed = GetPatternMemberCount(pattern);
                    ret = (double)seed / (double)need;
                    if (ret < 1) {
                        if (ret <= 0.0) {
                            AddItem(EEvaluationResult.ERROR, GenerateMessage(msg_needs_unmuch_error, new string[] { pattern.Name, need.ToString(), seed.ToString()}));
                        } else if (ret < 0.5) {
                            AddItem(EEvaluationResult.WORNING, GenerateMessage(msg_needs_unmuch_worning, new string[] { pattern.Name, need.ToString(), seed.ToString() }));
                        } else if (ret < 1) {
                            AddItem(EEvaluationResult.NOTICE, GenerateMessage(msg_needs_unmuch_notice, new string[] { pattern.Name, need.ToString(), seed.ToString() }));
                        }
                    }
                }
            }
            return ret;
        }
        /// <summary>勤務シフトに対してマッチしているか？（１日単位で）
        /// </summary>
        /// <returns>割合</returns>
        private double CheckPatternMuches () {
            double ret = 0.0;
            BRequirePatterns require = sdate.Require;
            if (require == null) return 1.0;
            List<BPattern> patterns = new List<BPattern>();
            for (int i = 0; i < require.Size(); i++) {
                patterns.Add(require.GetPattern(i));
            }
            int j = 0;
            for (int i = 0; i < patterns.Count; i++) {
                BPattern pattern = patterns[i];
                if (pattern.IsAvailable(sdate.Date)) {
                    double work = CheckPatternMuches(pattern);
                    ret += work;
                    j++;
                }
            }
            ret = (j > 0 ? ret / (double)j : 1.0);
            return ret;
        }
        /// <summary>スケジュール日に設定されたシフトの一覧
        /// </summary>
        /// <returns>勤務シフトのリスト</returns>
        private List<BPattern> GetDatePatterns () {
            List<BPattern> ret = new List<BPattern>();
            int max = sdate.ValidMemberSize;
            for (int i = 0; i < max; i++) {
                BMember member = sdate.GetValidMember(i);
                BSchedule schedule = sdate[member];
                if (schedule != null) {
                    BPattern pattern = schedule.Pattern;
                    if (pattern == null || pattern.BuiltIn) {
                    } else {
                        if (!ret.Contains(pattern)) {
                            ret.Add(pattern);
                        }
                    }
                }
            }
            ret.Sort(new BPatternComparer1());
            return ret;
        }
        /// <summary>勤務シフトのメンバー数
        /// </summary>
        /// <param name="pattern">勤務シフト</param>
        /// <returns>勤務シフトに該当するメンバー数</returns>
        private int GetPatternMemberCount (BPattern pattern) {
            int ret = 0;
            int max = sdate.ValidMemberSize;
            for (int i = 0; i < max; i++) {
                BMember member = sdate.GetValidMember(i);
                BSchedule schedule = sdate[member];
                if (schedule.Pattern == pattern) {
                    ret++;
                }
            }
            return ret;
        }
        /// <summary>タイムテーブル
        /// </summary>
        private BTimeTable Root {
            get {
                return sdate.TimeTable;
            }
        }
        /// <summary>リスト
        /// </summary>
        private List<BEvaluationItem> Items {
            get {
                return Root.EvaluationItems;
            }
        }
        /// <summary>メンバーごとのチェック
        /// </summary>
        private void CheckMembers () {
            int j = sdate.ValidMemberSize;
            for (int i = 0; i < j; i++) {
                BSchedule schedule = sdate[i];
                BMember member = schedule.Member;
                if (_memItems.ContainsKey(member)) {
                    CEvaluation1Day1Member work = _memItems[member];
                    work.Check();
                } else {
                    CEvaluation1Day1Member work = new CEvaluation1Day1Member(this, member);
                    _memItems.Add(member, work);
                    work.Check();
                }
            }
        }
    }
    /// <summary>１日分、１メンバー分の評価
    /// </summary>
    public class CEvaluation1Day1Member {
        private const string msg_cont_error = "%1の作業日が%2日以上連続しています。";
        private const string msg_cont_worning = "%1の作業日が%2日連続しています。";
        private const string msg_space_error = "%1の作業時間が重複しています。（%2～%3）";
        private const string msg_space_worning = "%1の作業間隔が不足しています。（%2～%3）";
        private const string msg_pattern_nomatch = "%1は%2の勤務シフトに含まれません。";
        /// <summary>タイムテーブル
        /// </summary>
        private BTimeTable Root {
            get {
                return _parent.sdate.TimeTable;
            }
        }
        /// <summary>リスト
        /// </summary>
        private List<BEvaluationItem> Items {
            get {
                return Root.EvaluationItems;
            }
        }
        /// <summary>内部リスト
        /// </summary>
        private List<BEvaluationItem> _items = new List<BEvaluationItem>();
        /// <summary>親オブジェクト
        /// </summary>
        BEvaluation1Day _parent;
        /// <summary>メンバー 
        /// </summary>
        BMember _member;
        /// <summary>コンストラクタ
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="member"></param>
        public CEvaluation1Day1Member (BEvaluation1Day parent, BMember member) {
            _parent = parent;
            _member = member;
            Check();
        }
        /// <summary>チェックする
        /// </summary>
        public void Check () {
            Clear();
            CheckContinuas();
            CheckSpace();
            CheckPattern();
        }
        /// <summary>クリア
        /// </summary>
        public void Clear () {
            for (int i = 0; i < _items.Count; i++) {
                Items.Remove(_items[i]);
            }
            _items.Clear();
        }
        /// <summary>スケジュール日
        /// </summary>
        private BScheduledDate sdate {
            get {
                return _parent.sdate;
            }
        }
        /// <summary>検証結果の追加
        /// </summary>
        /// <param name="item">検証結果</param>
        private void AddItem (BEvaluationItem item) {
            Items.Add(item);
            _items.Add(item);
        }
        /// <summary>検証結果の追加
        /// </summary>
        /// <param name="result">検証結果</param>
        /// <param name="message">メッセージ</param>
        private void AddItem (EEvaluationResult result, string message) {
            AddItem(new BEvaluationItem(result, sdate, message));
        }
        /// <summary>メンバーの連続稼動日数が※1の日数を超えていたら警告
        /// </summary>
        private void CheckContinuas () {
            BSchedule schedule = sdate[_member];
            if (schedule == null) return;
            BPattern pattern = schedule.Pattern;
            if (pattern == null || pattern.BuiltIn) return;

            // 休み設定
            int conu = _member.ContinuasInt;
            if (conu > 0) {
                int cont = sdate.GetMemberContinues(_member, conu * 2);
                int rest = conu - cont;
                if (rest <= 0) {
                    if (cont >= conu * 2) {
                        AddItem(EEvaluationResult.ERROR, GenerateMessage(msg_cont_error, new string[] { _member.Name, (cont + 1).ToString()}));
                    } else {
                        AddItem(EEvaluationResult.WORNING, GenerateMessage(msg_cont_worning, new string[] { _member.Name, (cont + 1).ToString()}));
                    }
                }
            }
        }
        /// <summary>メンバーの作業時間の重複（エラー）または※2の時間を満たしていなければ警告
        /// </summary>
        private void CheckSpace () {
            BSchedule tsche = sdate[_member];
            BPattern tpatt = tsche.Pattern;
            if (!(tpatt == null || tpatt.BuiltIn)) {
                // 今日のシフトが存在する
                DateTime today = sdate.Date;
                DateTime yesterday = today.AddDays(-1).Date;
                BScheduledDate ydate = Root[yesterday];
                BSchedule ysche = ydate[_member];
                BPattern ypatt = ysche.Pattern;
                if (!(ypatt == null || ypatt.BuiltIn)) {
                    // 昨日のシフトが存在する！
                    DateTime yend = yesterday + ypatt.End;
                    DateTime tend = yend + _member.Spacetime;
                    DateTime tstt = today + tpatt.Start;
                    if (yend >= tstt) {
                        AddItem(EEvaluationResult.ERROR, GenerateMessage(msg_space_error, new string[] { _member.Name, tstt.ToString(), yend.ToString()}));
                    } else if (tend > tstt) {
                        AddItem(EEvaluationResult.WORNING, GenerateMessage(msg_space_worning, new string[] { _member.Name, tstt.ToString(), yend.ToString() }));
                    }
                }
            }
        }
        /// <summary>メンバーがこのパターンを含むかどうかチェックする
        /// </summary>
        private void CheckPattern() {
            BSchedule tsche = sdate[_member];
            BPattern tpatt = tsche.Pattern;
            if (!(tpatt == null || tpatt.BuiltIn)) {
                if (!_member.Contains(tpatt)) {
                    AddItem(EEvaluationResult.NOTICE, GenerateMessage(msg_pattern_nomatch, new string[] { tpatt.Name, _member.Name}));
                }
            }
        }
        /// <summary>メッセージに変換する
        /// </summary>
        /// <param name="message"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        private string GenerateMessage (string message, string[] param) {
            string ret = message;
            if (param != null) {
                int i = 1;
                foreach (string txt in param) {
                    string p = "%" + i.ToString();
                    ret = ret.Replace(p, txt);
                    i++;
                }
            }
            return ret;
        }
    }
}
