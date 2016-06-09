using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TimeTableManager.Element;
using TimeTableManager.ElementCollection;

namespace TimeTableManager.UI {
    /// <summary>ファイルをインポートするダイアログ
    /// </summary>
    public partial class FImportDialog : Form {
        /// <summary>コピーするタイムテーブル
        /// </summary>
        private CTimeTable source, target;
        /// <summary>コピー元のファイル名
        /// </summary>
        private string sourceName;
        /// <summary>コピー先（現在のタイムテーブル）
        /// </summary>
        public CTimeTable Target {
            get { return target; }
            set { target = value; }
        }
        /// <summary>コピー元
        /// </summary>
        public CTimeTable Source {
            get { return source; }
            set { source = value; }
        }
        /// <summary>コピー元のファイル名
        /// </summary>
        public string SourceName {
            get { return sourceName; }
            set { sourceName = value; }
        }
        /// <summary>コンストラクタ
        /// </summary>
        public FImportDialog () {
            InitializeComponent();
        }
        /// <summary>コンボボックスを作成する
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">発生したイベント</param>
        private void FImportDialog_Shown (object sender, EventArgs e) {
            TxtSourceFile.Text = SourceName;
            MakeMembers();
            MakePatterns();
            MakeRequires();
            MakeDayOffs();
        }
        #region 一覧の作成処理
        /// <summary>メンバー一覧の作成
        /// </summary>
        private void MakeMembers () {
            for (int i = 0; i < Source.Members.Size(true); i++) {
                CMember member = Source.Members[i, true];
                if (!member.BuiltIn) {
                    DataRow dr = TblImportMember.NewRow();
                    dr[ClmImportMember] = member;
                    dr[ClmImportMemberName] = member.Name + (member.Removed == null ? "" : "(削除されています)");
                    TblImportMember.Rows.Add(dr);
                }
            }
        }
        /// <summary>勤務シフト一覧の作成
        /// </summary>
        private void MakePatterns () {
            for (int i = 0; i < Source.Patterns.Size(true); i++) {
                CPattern pattern = Source.Patterns[i, true];
                if (!pattern.BuiltIn) {
                    DataRow dr = TblImportPattern.NewRow();
                    dr[ClmImportPattern] = pattern;
                    dr[ClmImportPatternName] = pattern.Name + (pattern.Removed == null ? "" : "(削除されています)");
                    TblImportPattern.Rows.Add(dr);
                }
            }
        }
        /// <summary>人員配置一覧の作成
        /// </summary>
        private void MakeRequires () {
            for (int i = 0; i < Source.Requires.Size(true); i++) {
                CRequirePatterns requires = Source.Requires[i, true];
                if (!requires.BuiltIn) {
                    DataRow dr = TblImportRequires.NewRow();
                    dr[ClmImportRequires] = requires;
                    dr[ClmImportRequiresName] = requires.Name + (requires.Removed == null ? "" : "(削除されています)");
                    TblImportRequires.Rows.Add(dr);
                }
            }
        }
        /// <summary>休日一覧の作成
        /// </summary>
        private void MakeDayOffs () {
            for (int i = 0; i < Source.DayOffs.Size(); i++) {
                CDayOff dayoff = Source.DayOffs[i];
                DataRow dr = TblImportDayOff.NewRow();
                dr[ClmImportDayOff] = dayoff;
                dr[ClmImportDayOffName] = dayoff.Name + (dayoff.Removed == null ? "" : "(削除されています)");
                TblImportDayOff.Rows.Add(dr);
            }
        }
        #endregion
        /// <summary>キャンセル
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">発生したイベント</param>
        private void BtnCancel_Click (object sender, EventArgs e) {
            Dispose();
        }
        /// <summary>インポートする
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">発生したイベント</param>
        private void BtnOK_Click (object sender, EventArgs e) {
            try {
                foreach (DataRowView view in LstImportMember.CheckedItems) {
                    CMember item = view.Row["ClmImportMember"] as CMember;
                    ImportMember(item);
                }
                foreach (DataRowView view in LstImportPattern.CheckedItems) {
                    CPattern item = view.Row["ClmImportPattern"] as CPattern;
                    ImportPattern(item);
                }
                foreach (DataRowView view in LstImportRequires.CheckedItems) {
                    CRequirePatterns item = view.Row["ClmImportRequires"] as CRequirePatterns;
                    ImportRequires(item);
                }
                foreach (DataRowView view in LstImportDayOff.CheckedItems) {
                    CDayOff item = view.Row["ClmImportDayOff"] as CDayOff;
                    ImportDayOff(item);
                }
            } catch (Exception ex) {
                MessageBox.Show(this, ex.StackTrace, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Dispose();
        }
        #region 各アイテムのインポート処理
        /// <summary>メンバーのインポート
        /// </summary>
        /// <param name="member">インポートするメンバー</param>
        /// <returns>成功：追加したエレメント／不成功：null</returns>
        private CMember ImportMember (CMember member) {
            #region 重複チェック
            CMemberCollection col = Target.Members;
            if (col.GetByName(member.Name) != null) {
                return null;
            }
            if (col.Size() >= FMainForm.MaxItemCount) {
                return null;
            }
            #endregion
            #region インポート
            CMember newmember = col.CreateMember(true);
            newmember.Name = member.Name;
            newmember.IsChief = member.IsChief;
            newmember.SetAvailableDay(CTimeTable.tMonday, member.IsAvailableDay(CTimeTable.tMonday));
            newmember.SetAvailableDay(CTimeTable.tTuesday, member.IsAvailableDay(CTimeTable.tTuesday));
            newmember.SetAvailableDay(CTimeTable.tWednesday, member.IsAvailableDay(CTimeTable.tWednesday));
            newmember.SetAvailableDay(CTimeTable.tThursday, member.IsAvailableDay(CTimeTable.tThursday));
            newmember.SetAvailableDay(CTimeTable.tFriday, member.IsAvailableDay(CTimeTable.tFriday));
            newmember.SetAvailableDay(CTimeTable.tSaturday, member.IsAvailableDay(CTimeTable.tSaturday));
            newmember.SetAvailableDay(CTimeTable.tSunday, member.IsAvailableDay(CTimeTable.tSunday));
            newmember.Spacetime = member.Spacetime;
            newmember.Continuas = member.Continuas;
            newmember.Notes = member.Notes + "\nインポートされました。";
            foreach (string key in member.properties.AllKeys) {
                newmember[key] = member[key];
            }
            #endregion
            col.AddMember(newmember);
            // 終端
            return newmember;
        }
        /// <summary>勤務シフトのインポート
        /// </summary>
        /// <param name="pattern">インポートする勤務シフト</param>
        /// <returns>成功：追加したエレメント／不成功：null</returns>
        private CPattern ImportPattern (CPattern pattern) {
            #region 重複チェック
            CPatternCollection col = Target.Patterns;
            if (col.GetByName(pattern.Name) != null) {
                return null;
            }
            if (col.Size() >= FMainForm.MaxItemCount) {
                return null;
            }
            #endregion
            #region インポート
            CPattern newpattern = col.CreatePattern(true);
            newpattern.Name = pattern.Name;
            newpattern.Start = pattern.Start;
            newpattern.Scope = pattern.Scope;
            newpattern.Rest = pattern.Rest;
            newpattern.Notes = pattern.Notes + "\nインポートされました。";
            foreach (string key in pattern.properties.AllKeys) {
                newpattern[key] = pattern[key];
            }
            #endregion
            col.AddPattern(newpattern);
            // 終端
            return newpattern;
        }
        /// <summary>人員配置のインポート
        /// </summary>
        /// <param name="requires">インポートする人員配置</param>
        /// <returns>成功：追加したエレメント／不成功：null</returns>
        private CRequirePatterns ImportRequires (CRequirePatterns requires) {
            #region 重複チェック
            CRequirePatternsCollection col = Target.Requires;
            if (col.GetByName(requires.Name) != null) {
                return null;
            }
            if (col.Size() >= FMainForm.MaxItemCount) {
                return null;
            }
            #endregion
            #region インポート
            CRequirePatterns newrequires = col.CreateRequirePatterns(true);
            newrequires.Name = requires.Name;
            for (int i = 0; i < Source.Patterns.Size(true); i++) {
                CPattern pattern = Source.Patterns[i, true];
                int needs = requires.GetRequire(pattern);
                if (!pattern.BuiltIn && (pattern.Removed == null || needs > 0)) {
                    CPattern newpattern = Target.Patterns.GetByName(pattern.Name);
                    if (newpattern == null) {
                        newpattern = ImportPattern(pattern);
                    }
                    newrequires.SetRequire(newpattern, needs);
                }
            }
            newrequires.Notes = requires.Notes + "\nインポートされました。";
            foreach (string key in requires.properties.AllKeys) {
                newrequires[key] = requires[key];
            }
            #endregion
            col.AddRequirePatterns(newrequires);
            // 終端
            return newrequires;
        }
        /// <summary>休日のインポート
        /// </summary>
        /// <param name="dayoff">インポートする休日</param>
        /// <returns>成功：追加したエレメント／不成功：null</returns>
        private CDayOff ImportDayOff (CDayOff dayoff) {
            #region 重複チェック
            CDayOffCollection col = Target.DayOffs;
            if (col.GetByName(dayoff.Name) != null) {
                return null;
            }
            if (col.Size() >= FMainForm.MaxItemCount) {
                return null;
            }
            #endregion
            #region インポート
            CDayOff newdayoff = col.CreateDayOff(true);
            newdayoff.Name = dayoff.Name;
            newdayoff.StartDate = dayoff.StartDate;
            newdayoff.EndDate = dayoff.EndDate;
            foreach (string key in dayoff.properties.AllKeys) {
                newdayoff[key] = dayoff[key];
            }
            #endregion
            col.AddDayOff(newdayoff);
            // 終端
            return newdayoff;
        }
        #endregion
    }
}