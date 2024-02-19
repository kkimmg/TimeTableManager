using System;
using System.Collections;
using System.Collections.Generic;
using TimeTableManager.ElementCollection;
namespace TimeTableManager.Element {
	/// <summary>
	/// スケジュール化された日付
	/// </summary>
	public class BScheduledDate:BAbstractElement {
		/// <summary>
		/// 日付
		/// </summary>
		virtual public System.DateTime Date {
			get {
				return date.Date;
			}
			set {
				this.date = value.Date;
				if (timeTable.IsDayOff(value)) {
					// 休日の場合は無条件に休みの人員配置を設定する
					Require = BRequirePatterns.DAYOFF;
				} else {
					if (Require == null) {
						// 人員配置が未設定であるため設定する
					}
				}
				// 有効なメンバーを再構成する
				MakeMembers();
			}			
		}
		/// <summary>
		/// 人員配置
		/// </summary>
		virtual public BRequirePatterns Require {
			get {
				return requirepatterns;
			}
			set {
                bool Changing = (requirepatterns != value);
				PatternToPatternsMember.Clear();
				requirepatterns = value;
				if (value != null) {
					// お気に入り設定（シフト）
					for (int i = 0; i < value.Size(); i++) {
						BPattern pattern = requirepatterns.GetPattern(i);
						PatternToPatternsMember[pattern]= new PatternsMember(this, pattern);
					}
				}
                if (TimeTable != null && Changing) {
                    TimeTable.NotifyScheduleDateRequirePatternsEdited(this, value);
                }
			}
		}
		/// <summary>
		/// 親
		/// </summary>
		override public BTimeTable TimeTable {
			get {
				return timeTable;
			}			
		}
		/// <summary>
		/// 有効なメンバーの数
		/// </summary>
		virtual public int ValidMemberSize {
			get {
				MakeMembers();
				return validMembers.Count;
			}			
		}
		/// <summary>
		/// 今日は休みか？
		/// </summary>
		virtual public bool DayOff {
			get {
				return timeTable.IsDayOff(date);
			}			
		}
		/// <summary>
		/// メンバーの数
		/// </summary>
		private class MemberCount {
			private void  InitBlock(BScheduledDate enclosingInstance) {
				this.enclosingInstance = enclosingInstance;
			}
			private BScheduledDate enclosingInstance;
			public BScheduledDate Enclosing_Instance {
				get {
					return enclosingInstance;
				}				
			}
			/// <summary>字際にシフトに割り当てられた人数 </summary>
			private int[] _cnt;
			/// <summary>勤務シフトに人員配置 </summary>
			private int[] _max;
			/// <summary>勤務シフト </summary>
			private BPattern[] _pt;
			/// <summary>メンバー数の作成</summary>
			public MemberCount(BScheduledDate enclosingInstance, BRequirePatterns reqpatts) {
				InitBlock(enclosingInstance);
				if (reqpatts != null) {
					int sz = reqpatts.Size();
					_pt = new BPattern[sz];
					_max = new int[sz];
					_cnt = new int[sz];
					for (int i = 0; i < sz; i++) {
						_pt[i] = reqpatts.GetPattern(i);
						_max[i] = reqpatts.GetRequire(_pt[i]);
						_cnt[i] = 0;
					}
				}
			}
			/// <summary>実際に割り当てられた人数の加算</summary>
			internal virtual void  Add(int n) {
				if (n >= _pt.Length)
					return ;
				_cnt[n]++;
			}
			/// <summary>実際に割り当てられた人数の加算</summary>
			public virtual void  Add(BPattern p) {
				Add(Id(p));
			}
			/// <summary>人数は追加可能ですか？</summary>
			internal virtual bool Addable(int n) {
				if (n >= _pt.Length)
					return false;
				return (_cnt[n] < _max[n]);
			}
			/// <summary>人数は追加可能ですか？</summary>
			public virtual bool Addable(BPattern p) {
				return Addable(Id(p));
			}
			/// <summary>このオブジェクト内でのシフトの番号</summary>
			internal virtual int Id(BPattern p) {
				int ret = _pt.Length;
				for (int i = 0; i < _pt.Length; i++) {
					if (_pt[i].Equals(p))
						ret = i;
				}
				return ret;
			}
		}
		/// <summary> メンバーのシフトに対する希望を管理する</summary>
		private class MembersPattern {
			private void  InitBlock(BScheduledDate enclosingInstance) {
				this.enclosingInstance = enclosingInstance;
                _ps = new List<BPattern>();
			}
			private BScheduledDate enclosingInstance;
			public BScheduledDate Enclosing_Instance {
				get {
					return enclosingInstance;
				}				
			}
			/// <summary>メンバー </summary>
			private BMember _m;
			/// <summary>勤務シフトの希望 </summary>
			private List<BPattern> _ps; // 	
			/// <summary>コンストラクタ</summary>
			public MembersPattern(BScheduledDate enclosingInstance, BMember m):base() {
				InitBlock(enclosingInstance);
				this._m = m;
			}
			/// <summary>メンバーの好みのシフト</summary>
			public virtual BPattern GetPattern(int rank) {
                BPattern ret = BPattern.NULL;
                if (rank < _ps.Count) {
                    ret = _ps[rank];
                }
                if (ret == null) ret = BPattern.NULL;
				return ret;
			}
			/// <summary>メンバーの好みのシフトをセット</summary>
			public virtual void  SetPattern(int rank, BPattern pattern) {
				if (rank == _ps.Count) {
					_ps.Add(pattern);
				} else if (rank > _ps.Count) {
					for (int i = _ps.Count; i < rank; i++) {
						_ps.Add(null);
					}
					SetPattern(rank, pattern);
				} else {
					_ps.Remove(pattern);
					_ps.Insert(rank, pattern);
				}
			}
		}
		/// <summary> シフトのメンバーに対する好みを管理する</summary>
		private class PatternsMember {
			private void  InitBlock(BScheduledDate enclosingInstance) {
				this.enclosingInstance = enclosingInstance;
				_ms = new List<BMember>();
			}
			private BScheduledDate enclosingInstance;
			public BScheduledDate Enclosing_Instance {
				get {
					return enclosingInstance;
				}
				
			}
			/// <summary>好みの順番</summary>
			private List<BMember> _ms; //
			/// <summary>管理するシフト</summary>
			private BPattern _p; // 
			/// <summary>コンストラクタ</summary>
			public PatternsMember(BScheduledDate enclosingInstance, BPattern p):base() {
				InitBlock(enclosingInstance);
				this._p = p;
			}
			/// <summary>メンバー</summary>
			public virtual BMember GetMember(int rank) {
                BMember ret = BMember.NULL;
				if (rank < _ms.Count) {
                    ret = _ms[rank]; 
                }
                if (ret == null) ret = BMember.NULL;
				return ret;
			}
			/// <summary>勤務シフトの好みの設定</summary>
			public virtual void  SetMember(int rank, BMember member) {
				if (rank == _ms.Count) {
					_ms.Add(member);
				} else if (rank > _ms.Count) {
					for (int i = _ms.Count; i < rank; i++) {
						_ms.Add(null);
					}
					SetMember(rank, member);
				} else {
					_ms.Remove(member);
					_ms.Insert(rank, member);
				}
			}
		}
		/// <summary>ノードに保存する際の日付の表現形式 </summary>
		public const string DATE_FORMAT = "yyyyMMdd";
		/// <summary>ランダム化に使用する </summary>
		private static System.Random rnd;
		/// <summary>メンバーの好み </summary>
		private Dictionary<BMember, MembersPattern> MemberToMembersPattern;
		/// <summary>勤務シフトの好み </summary>
		private Dictionary<BPattern, PatternsMember> PatternToPatternsMember;
		/// <summary>日付 </summary>
		private System.DateTime date;
		/// <summary>人員配置のコレクション</summary>
		private BRequirePatterns requirepatterns;
		/// <summary>（親オブジェクトである）タイムテーブル </summary>
		private BTimeTable timeTable;
		/// <summary>スケジュールを保存する </summary>
		private Dictionary<BMember, BSchedule> MemberToSchedule;
		/// <summary>有効なメンバー </summary>
		private List<BMember> validMembers;
		/// <summary>スケジュール化された日の作成</summary>
		public BScheduledDate(System.DateTime date, BTimeTable parent):base() {
			// 保持オブジェクト
			timeTable = parent;
			this.date = date;
			//
			MakeMembers();
			// ハッシュテーブル
			MemberToMembersPattern = new Dictionary<BMember, MembersPattern>();
            PatternToPatternsMember = new Dictionary<BPattern, PatternsMember>();
			// 	
			if (validMembers == null) {
				validMembers = new List<BMember>();
			}
			if (MemberToSchedule == null) {
				MemberToSchedule = new Dictionary<BMember, BSchedule>();
			}
		}
		/// <summary>スケジュール化された日の作成</summary>
		public BScheduledDate(BTimeTable parent):base() {
			// 保持オブジェクト
			timeTable = parent;
			// ハッシュテーブル
			MemberToMembersPattern = new Dictionary<BMember, MembersPattern>();
            PatternToPatternsMember = new Dictionary<BPattern, PatternsMember>();
			// 	
			validMembers = new List<BMember>();
            MemberToSchedule = new Dictionary<BMember, BSchedule>();
		}
		/// <summary> 設定されたメンバーとシフトに対して組み合わせを作成する</summary>
		public virtual void  Auto() {
			int[] memRnk = new int[ValidMemberSize];
			bool[] memChk = new bool[ValidMemberSize];
			for (int i = 0; i < ValidMemberSize; i++) {
				memRnk[i] = ValidMemberSize + 1;
				memChk[i] = false;
			}
			MemberCount memCnt = new MemberCount(this, Require);
			int i2 = 0, j = 0;
			//System.out.println("展開サイズ:" + getRequire().getExtractedSize());
			if (Require == null) return;
			//
			while (i2 < Require.ExtractedSize) {
				j = 0;
				while (j < ValidMemberSize) {
					if (memChk[j]) {
						// もうすでに決定している
						//System.out.println("すでに決定している:" + i + ":" + j);
					}
					else {
						BMember m1 = GetValidMember(j);
						// i番目のメンバー
						BPattern p1 = GetMembersPattern(m1, i2);
						// メンバーがもっとも望むシフト
						//System.out.println(i + ":" + m1.getName() + ":" + p1);
						int m1rank = GetMemberRank(p1, m1);
						// ↑がシフトにとってどれぐらい望まれているか？
						if ((m1rank < memRnk[j]) && (p1 != null)) {
							// メンバーがシフトを希望していてランクが有効である
							if (memCnt.Addable(p1)) {
								// シフトに登録可能な人数内
								GetSchedule(m1).Pattern = p1;
								memRnk[j] = m1rank;
								memChk[j] = true;
								memCnt.Add(p1);
							}
							else {
								// シフトに登録可能な人数外
								for (int k = 0; k < ValidMemberSize; k++) {
									BMember compM = GetValidMember(k);
									BSchedule compS = GetSchedule(compM);
									BPattern compP = compS.Pattern;
									if (p1.Equals(compP)) {
										if (memRnk[k] > m1rank) {
											//
											GetSchedule(m1).Pattern = p1;
											memRnk[j] = m1rank;
											memChk[j] = true; //
											compS.Pattern = null;
											memRnk[k] = ValidMemberSize;
											memChk[k] = false;
											break;
										}
									}
								}
							}
						}
					}
					j++;
				}
				i2++;
			}
		}
		/// <summary>スケジュールの作成</summary>
		protected internal virtual BSchedule CreateSchedule() {
			return new BSchedule(this);
		}
		/// <summary>勤務シフトにおけるメンバーのランクを取得する</summary>
		public virtual int GetMemberRank(BPattern p, BMember m) {
			int ret = 0;
			while (ret < ValidMemberSize) {
				if (m == null) {
					if (GetPatternsMember(p, ret) == null)
						break;
				}
				else if (m.Equals(GetPatternsMember(p, ret)))
					break;
				ret++;
			}
			return ret;
		}
		/// <summary>メンバーのrank番目に好まれるシフトを取得する</summary>
		public virtual BPattern GetMembersPattern(BMember m, int rank) {
            MembersPattern mp = null;
			if (MemberToMembersPattern.ContainsKey(m)) {
                mp = MemberToMembersPattern[m];
            } else {
				mp = new MembersPattern(this, m);
				MemberToMembersPattern[ m] =mp;
			}
			return mp.GetPattern(rank);
		}
		/// <summary>メンバーの合計 指定した時間で働く予定の人数</summary>
		public virtual int GetMemberTotal(TimeSpan time) {
			int ret = 0;
			for (int i = 0; i < ValidMemberSize; i++) {
				BMember member = GetValidMember(i);
				BSchedule schedule = GetSchedule(member);
				if (schedule != null) {
                    BPattern pattern = schedule.Pattern;
                    if (pattern != null) {
                        if (pattern.Start <= time && time <= pattern.End) {
                            ret++;
                        }
                    }
				}
			}
			return ret;
		}
		/// <summary>このオブジェクトのIDは内部日付を"yyyyMMdd"で変換したint型とする</summary>
		public override long ObjectID {
			get {
				return date.Year * 10000 + date.Month * 100 + date.Day;
			}
			set {
                int dvalue = (int)value;
				DateTime datetime = new DateTime(dvalue / 10000, (dvalue % 10000) / 100, dvalue % 100);
				Date = datetime;
			}
		}
		/// <summary>勤務シフトのrank番目に好まれるメンバーを取得する</summary>
		public virtual BMember GetPatternsMember(BPattern p, int rank) {
			if (p == null) {
				// シフトがnullのとき
				return null;
			}
			PatternsMember pm = null;
            if (PatternToPatternsMember.ContainsKey(p)) {
                pm = PatternToPatternsMember[p];
            } else {
				pm = new PatternsMember(this, p);
				PatternToPatternsMember[ p] =pm;
			}
			return pm.GetMember(rank);
		}
		/// <summary>今の人員配置だとこの時間何人くらい必要なんだろう？</summary>
        public virtual int GetPatternTotal (TimeSpan time) {
			int ret = 0;
			BRequirePatterns require = Require;
			if (require != null) {
				ret = require.GetPatternTotal(time);
			}
			return ret;
		}
		/// <summary>メンバーのスケジュールを取得する</summary>
		private BSchedule GetSchedule(int i) {
			BMember work = GetValidMember(i);
			return GetSchedule(work);
		}
		/// <summary>メンバーのスケジュールを取得する</summary>
		private BSchedule GetSchedule(BMember member) {
			if (member == null)
				return null;
            BSchedule ret = null;;
			if (MemberToSchedule.ContainsKey(member)) {
                // 存在する
                ret = MemberToSchedule[member];
            } else {
				// メンバーに対応したスケジュールが存在しなければ作成する
				BSchedule schedule = CreateSchedule();
				schedule.Member = member;
                if (member.IsAvailable(Date)) {
                    MemberToSchedule[member] = schedule;
                }
				ret = schedule;
			}
			return ret;
		}
		/// <summary>有効なメンバーの取得</summary>
		public virtual BMember GetValidMember(int n) {
			MakeMembers();
			if (n >= validMembers.Count)
				return null;
			return validMembers[n];
		}
		/// <summary>有効なメンバーの設定</summary>
		public virtual void  MakeMembers() {
			if (validMembers == null) {
				// 配列の再確保
				validMembers = new List<BMember>();
			}
			if (MemberToSchedule == null) {
                MemberToSchedule = new Dictionary<BMember, BSchedule>();
			}
			//		validMembers.clear(); // 初期化
			BMemberCollection members = timeTable.Members;
			for (int i = 0; i < members.Size(true); i++) {
				BMember member1 = members[i, true];
				if (member1.IsAvailable(Date)) {
					if (!validMembers.Contains(member1)) {
						validMembers.Add(member1);
					}
				}
				else {
					if (validMembers.Contains(member1)) {
						//System.out.println("完全削除３：" + member1.getName());
						validMembers.Remove(member1);
					}
					if (MemberToSchedule.ContainsKey(member1)) {
						//System.out.println("完全削除４：" + member1.getName());
						// スケジュールの完全削除
						BSchedule scd = MemberToSchedule[member1];
						if (scd != null) {
							//System.out.println("完全削除５：" + member1.getName());
							MemberToSchedule.Remove(member1);
						}
					}
				}
			}
			List<BMember> work = new List<BMember>();
			int sz1 = validMembers.Count;
			for (int i = 0; i < sz1; i++) {
				//System.out.println("Step1");
				BMember mem = validMembers[i];
				long id = mem.ObjectID;
				if (members.GetByID(id) == null) {
					work.Add(mem);
				}
			}
			int sz2 = work.Count;
			for (int i = 0; i < sz2; i++) {
				validMembers.Remove(work[i]);
			}
		}
		/// <summary>勤務シフトに対するメンバーのランクを設定する</summary>
		public virtual void  SetMemberRank(BPattern p, BMember m, int rank) {
			if (!p.IsAvailable(Date)) {
				return ;
			}
			PatternsMember pm = null;
			if (PatternToPatternsMember.ContainsKey(p)) {
                pm = PatternToPatternsMember[p];
            } else {
				pm = new PatternsMember(this, p);
				PatternToPatternsMember[ p]= pm;
			}
			pm.SetMember(rank, m);
		}
		/// <summary>メンバーに対するシフトのランクを設定する</summary>
		public virtual void  SetPatternRank(BMember m, BPattern p, int rank) {
			if (!m.IsAvailable(Date)) {
				return ;
			}
			MembersPattern mp = null;
			if (MemberToMembersPattern.ContainsKey(m)) {
                mp = MemberToMembersPattern[m];
            } else {
				mp = new MembersPattern(this, m);
				MemberToMembersPattern[ m] =mp;
			}
			mp.SetPattern(rank, p);
		}
		/// <summary>スケジュールをセットする</summary>
		public virtual void  SetSchedule(BSchedule sc) {
			MemberToSchedule[ sc.Member]= sc;
		}
		/// <summary>
		/// スタティック
		/// 乱数初期化
		/// </summary>
		static BScheduledDate() {
			rnd = new System.Random();
		}
        /// <summary>
        /// スケジュール
        /// </summary>
        /// <param name="member">メンバー</param>
        /// <returns>スケジュール</returns>
		public BSchedule this[BMember member] {
			get {
				return GetSchedule(member);
			}
		}
        /// <summary>
        /// スケジュール
        /// </summary>
        /// <param name="i">n番目？</param>
        /// <returns>スケジュール</returns>
		public BSchedule this[int i] {
			get {
				return GetSchedule(i);
			}
		}
        /// <summary>
        /// メンバーは何日連続で働いているか？
        /// </summary>
        /// <param name="member">メンバー</param>
        /// <param name="max">最大値</param>
        /// <returns>メンバーは何日連続で働いているか</returns>
        public virtual int GetMemberContinues (BMember member, int max) {
            int ret = 0;
            DateTime work = this.Date;
            work = work.AddDays(-1);
            BScheduledDate wDate = TimeTable[work];
            BPattern pattern = wDate[member].Pattern;
            while (pattern != null && !pattern.BuiltIn) {
                work = work.AddDays(-1);
                ret++;
                wDate = TimeTable[work];
                pattern = wDate[member].Pattern;
            }
            return ret;
        }
        /// <summary>
        /// 稼動中のメンバーの数
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public virtual List<BMember> GetTime2ValidMember (TimeSpan time) {
            List<BMember> ret = new List<BMember>();
            int max = ValidMemberSize;
            for (int i = 0; i < max; i++) {
                BMember mbr = GetValidMember(i);
                BSchedule scd = GetSchedule(mbr);
                BPattern ptn = scd.Pattern;
                if (ptn == null) {
                    // 何もしない
                } else if (ptn.BuiltIn) {
                    // 何もしないって！
                } else {
                    if (ptn.Start <= time && ptn.End >= time) {
                        // 稼働時間中
                        ret.Add(mbr);
                    }
                }
            }
            return ret;
        }
        /// <summary>
        /// 稼動中のメンバーの数
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public virtual List<BMember> GetTime2ValidMember (DateTime time) {
            TimeSpan work = time - this.date.Date;
            return GetTime2ValidMember(work);
        }
        /// <summary>
        /// 区切りになる時間
        /// </summary>
        /// <returns>タイムスパンの配列</returns>
        public List<TimeSpan> GetPeriodTimes () {
            List<TimeSpan> ret = new List<TimeSpan>();
            int max = ValidMemberSize;
            for (int i = 0; i < max; i++) {
                BMember member = GetValidMember(i);
                BSchedule schedule = GetSchedule(member);
                BPattern work = (schedule != null ? schedule.Pattern : null);
                if (work == null || work.BuiltIn) {
                    // ヌルも同然
                } else {
                    // 存在する
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
            }
            return ret;
        }
	}
}