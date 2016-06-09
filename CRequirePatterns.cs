using System;
using System.Collections;
using System.Collections.Generic;
using TimeTableManager.ElementCollection;

namespace TimeTableManager.Element {
    /// <summary>
    /// 人員配置
    /// </summary>
    public class CRequirePatterns : CAbstractElement {
        /// <summary>休みの日
        /// </summary>
        public static readonly CRequirePatterns DAYOFF = new DAYOFF_REQUIRE();
        /// <summary>Nullの代わり
        /// </summary>
        public static readonly CRequirePatterns NULL = new NULL_REQUIRE();
        /// <summary>名前(初期値="")
        /// </summary>
        private string name = "";
        /// <summary>コレクション
        /// </summary>
        private CRequirePatternsCollection parent;
        /// <summary>勤務シフトのリスト
        /// </summary>
        private CPatternCollection patternList;
        /// <summary>勤務シフト/人数のセット
        /// </summary>
        private Dictionary<CPattern, int> Requires = new Dictionary<CPattern, int>();
        /// <summary>展開された人数またはのべ人数
        /// </summary>
        virtual public int ExtractedSize {
            get {
                int retValue = 0;
                for (int i = 0; i < Size(); i++) {
                    CPattern pat = GetPattern(i);
                    //retValue += (int)Requires[pat];
                    retValue += GetRequire(pat);
                }
                return retValue;
            }

        }
        /// <summary>名前
        /// </summary>
        virtual public string Name {
            get {
                return name;
            }

            set {
                this.name = value;
            }

        }
        /// <summary>タイムテーブル
        /// </summary>
        override public CTimeTable TimeTable {
            get {
                if (parent == null) return null;
                return parent.TimeTable;
            }
        }
        /// <summary>人数が０より大きいシフトの数
        /// </summary>
        virtual public int ValidSize {
            get {
                int ret = 0;
                for (int i = 0; i < Size(); i++) {
                    CPattern pat = GetPattern(i);
                    //if (pat != null && (int)Requires[pat] > 0) {
                    if (pat != null && GetRequire(pat) > 0) {
                        ret++;
                    }
                }
                return ret;
            }

        }
        /// <summary>コンストラクタ
        /// </summary>
        /// <param name="patternList">勤務シフトのリスト</param>
        /// <param name="parent">タイムテーブル</param>
        public CRequirePatterns (CPatternCollection patternList, CRequirePatternsCollection parent)
            : base() {
            this.patternList = patternList;
            this.parent = parent;
        }
        /// <summary>展開された人数
        /// </summary>
        /// <param name="n">何番目？</param>
        /// <returns>n番目のシフトの人数</returns>
        public virtual CPattern GetExtractedPattern (int n) {
            CPattern retValue = null;
            int m = 0;
            for (int i = 0; i < Size(); i++) {
                CPattern pw = GetPattern(i);
                for (int j = 0; j < Requires[pw]; j++) {
                    if (m == n)
                        retValue = pw;
                    m++;
                }
            }
            return retValue;
        }
        /// <summary>勤務シフト
        /// </summary>
        /// <param name="n">何番目？</param>
        /// <returns>n番目のシフト</returns>
        public virtual CPattern GetPattern (int n) {
            return patternList[n];
        }
        /// <summary>指定された時間の稼動中（であるべき）人数
        /// </summary>
        /// <param name="time">時間（時刻）</param>
        /// <returns>指定された時間の稼動中（であるべき）人数</returns>
        public virtual int GetPatternTotal (TimeSpan time) {
            int ret = 0;
            int validsize = ValidSize;
            for (int i = 0; i < validsize; i++) {
                CPattern pattern = GetValid(i);

                if (pattern.Start <= time && time <= pattern.Start + pattern.Scope) {
                    ret += GetRequire(pattern);
                }
            }
            return ret;
        }
        /// <summary>ターンの人数
        /// </summary>
        /// <param name="pattern">勤務シフト</param>
        /// <returns>人数</returns>
        public virtual int GetRequire (CPattern pattern) {
            if (!Requires.ContainsKey(pattern)) {
                return 0;
            }
            return Requires[pattern];
        }
        /// <summary>有効な人数
        /// </summary>
        /// <param name="n">n番目？</param>
        /// <returns>n番目のシフトの人数</returns>
        public virtual CPattern GetValid (int n) {
            CPattern ret = null;
            int c = 0;
            for (int i = 0; i < Size(); i++) {
                CPattern work = GetPattern(i);
                if (GetRequire(work) > 0) {
                    if (c == n)
                        ret = GetPattern(i);
                    c++;
                }
            }
            return ret;
        }
        /// <summary>人員配置をセットする
        /// </summary>
        /// <param name="n">n番目？</param>
        /// <param name="require">n番目の人数</param>
        public virtual void SetRequire (CPattern n, int require) {
            Requires[n] = require;
        }
        /// <summary>勤務シフトの数
        /// </summary>
        /// <returns>勤務シフトの数</returns>
        public virtual int Size () {
            return patternList.Size();
        }
        /// <summary>区切りになる時間
        /// </summary>
        /// <returns>タイムスパンの配列</returns>
        public List<TimeSpan> GetPeriodTimes () {
            List<TimeSpan> ret = new List<TimeSpan>();
            int max = ValidSize;
            for (int i = 0; i < max; i++) {
                CPattern work = GetValid(i);
                TimeSpan start = work.Start;
                TimeSpan end = work.End;
                if (!ret.Contains(start)) {
                    // 開始時間
                    ret.Add(start);
                }
                if (!ret.Contains(end)) {
                    // 終了時間
                    ret.Add(end);
                }
            }
            return ret;
        }
    }
    /// <summary>休みの日の人員配置
    /// </summary>
    public class DAYOFF_REQUIRE : CRequirePatterns {
        /// <summary>コンストラクタ
        /// </summary>
        public DAYOFF_REQUIRE ()
            : base(null, null) {
        }
        /// <summary>展開された人数は常に０
        /// </summary>
        override public int ExtractedSize {
            get {
                return 0;
            }
        }
        /// <summary>名前は常に”休み”
        /// </summary>
        override public string Name {
            get {
                return "休み";
            }

            set {
                //this.name = value;
            }

        }
        /// <summary>サイズは常に０
        /// </summary>
        override public int ValidSize {
            get {

                return 0;
            }

        }
        /// <summary>無効なオブジェクトIDを返す
        /// </summary>
        public override long ObjectID {
            get {
                return -9999;
            }
            set {
            }
        }
        /// <summary>展開された人数
        /// </summary>
        /// <param name="n">何番目？</param>
        /// <returns>n番目のシフトの人数</returns>
        public override CPattern GetExtractedPattern (int n) {

            return null;
        }
        /// <summary>勤務シフト
        /// </summary>
        /// <param name="n">何番目？</param>
        /// <returns>n番目のシフト</returns>
        public override CPattern GetPattern (int n) {
            return null;
        }
        /// <summary>指定された時間の稼動中（であるべき）人数
        /// </summary>
        /// <param name="time">時間（時刻）</param>
        /// <returns>指定された時間の稼動中（であるべき）人数</returns>
        public override int GetPatternTotal (TimeSpan time) {
            return 0;
        }
        /// <summary>勤務シフトの人数を取得する
        /// </summary>
        /// <param name="pattern">勤務シフト</param>
        /// <returns>勤務シフトの人数</returns>
        public override int GetRequire (CPattern pattern) {
            return 0;
        }
        /// <summary>有効な人数
        /// </summary>
        /// <param name="n">n番目？</param>
        /// <returns>n番目のシフトの人数</returns>
        public override CPattern GetValid (int n) {
            return null;
        }
        /// <summary>人員配置をセットする
        /// </summary>
        /// <param name="n">n番目？</param>
        /// <param name="require">n番目の人数</param>
        public override void SetRequire (CPattern n, int require) {
        }
        /// <summary>勤務シフトの数
        /// </summary>
        /// <returns>勤務シフトの数</returns>
        public override int Size () {
            return 0;
        }
        /// <summary>このオブジェクトはビルトインオブジェクトです
        /// </summary>
        public override bool BuiltIn {
            get {
                return true;
            }
        }
        /// <summary>作成日は日付の最小値
        /// </summary>
        public override DateTime Created {
            get {
                return DateTime.MinValue;
            }
        }
        /// <summary>常に削除されない
        /// </summary>
        public override DateTime? Removed {
            get {
                return null;
            }
        }
        /// <summary>常に有効
        /// </summary>
        /// <param name="now">日付にかかわらない</param>
        /// <returns>常に有効</returns>
        public override bool IsAvailable (DateTime now) {
            return true;
        }
        /// <summary>常に有効
        /// </summary>
        /// <param name="param0">日付にかかわらない</param>
        /// <param name="param1">日付にかかわらない</param>
        /// <returns>常に有効</returns>
        public override bool IsAvailable (DateTime param0, DateTime param1) {
            return true;
        }
    }
    /// <summary>Nullの代わり
    /// </summary>
    public class NULL_REQUIRE : CRequirePatterns {
        /// <summary>コンストラクタ
        /// </summary>
        public NULL_REQUIRE ()
            : base(null, null) {
        }
        /// <summary>展開された人数は常に０
        /// </summary>
        override public int ExtractedSize {
            get {

                return 0;
            }

        }
        /// <summary>名前は常に””
        /// </summary>
        override public string Name {
            get {
                return "";
            }

            set {
                //this.name = value;
            }

        }
        /// <summary>サイズは常に０
        /// </summary>
        override public int ValidSize {
            get {

                return 0;
            }

        }
        /// <summary>無効なオブジェクトIDを返す
        /// </summary>
        public override long ObjectID {
            get {
                return -10000;
            }
            set {
            }
        }
        /// <summary>展開された人数
        /// </summary>
        /// <param name="n">何番目？</param>
        /// <returns>n番目のシフトの人数</returns>
        public override CPattern GetExtractedPattern (int n) {

            return null;
        }
        /// <summary>勤務シフト
        /// </summary>
        /// <param name="n">何番目？</param>
        /// <returns>n番目のシフト</returns>
        public override CPattern GetPattern (int n) {
            return null;
        }
        /// <summary>指定された時間の稼動中（であるべき）人数
        /// </summary>
        /// <param name="time">時間（時刻）</param>
        /// <returns>指定された時間の稼動中（であるべき）人数</returns>
        public override int GetPatternTotal (TimeSpan time) {
            return 0;
        }
        /// <summary>勤務シフトの人数を取得する
        /// </summary>
        /// <param name="pattern">勤務シフト</param>
        /// <returns>勤務シフトの人数</returns>
        public override int GetRequire (CPattern pattern) {
            return 0;
        }
        /// <summary>有効な人数
        /// </summary>
        /// <param name="n">n番目？</param>
        /// <returns>n番目のシフトの人数</returns>
        public override CPattern GetValid (int n) {
            return null;
        }
        /// <summary>人員配置をセットする
        /// </summary>
        /// <param name="n">n番目？</param>
        /// <param name="require">n番目の人数</param>
        public override void SetRequire (CPattern n, int require) {
        }
        /// <summary>勤務シフトの数
        /// </summary>
        /// <returns>勤務シフトの数</returns>
        public override int Size () {
            return 0;
        }
        /// <summary>このオブジェクトはビルトインオブジェクトです
        /// </summary>
        public override bool BuiltIn {
            get {
                return true;
            }
        }
        /// <summary>作成日は日付の最小値
        /// </summary>
        public override DateTime Created {
            get {
                return DateTime.MinValue;
            }
        }
        /// <summary>常に削除されない
        /// </summary>
        public override DateTime? Removed {
            get {
                return null;
            }
        }
        /// <summary>常に有効
        /// </summary>
        /// <param name="now">日付にかかわらない</param>
        /// <returns>常に有効</returns>
        public override bool IsAvailable (DateTime now) {
            return true;
        }
        /// <summary>常に有効
        /// </summary>
        /// <param name="param0">日付にかかわらない</param>
        /// <param name="param1">日付にかかわらない</param>
        /// <returns>常に有効</returns>
        public override bool IsAvailable (DateTime param0, DateTime param1) {
            return true;
        }
    }

}