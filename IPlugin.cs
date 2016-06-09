using System;
using System.Collections.Generic;
using System.Text;
using TimeTableManager.Element;
using TimeTableManager.UI;

namespace TimeTableManager.Plugin {
    /// <summary>プラグイン機能のためのインターフェース
    /// </summary>
    public interface IPlugin {
        /// <summary>プラグインの名称
        /// </summary>
        string PluginName {
            get;
        }
        /// <summary>プラグインの説明
        /// </summary>
        string PluginDescription {
            get;
        }
        /// <summary>設定ダイアログ
        /// </summary>
        /// <param name="owner">親画面</param>
        void ShowConfigDialog(System.Windows.Forms.IWin32Window owner);
        /// <summary>画面上で何かする
        /// （メインウインドウは初期化の時点でBindMainWindowされているといいなあ）
        /// </summary>
        /// <param name="TimeTable">タイムテーブル</param>
        /// <param name="Start">対象開始日</param>
        /// <param name="End">対象終了日</param>
        void DoSomething(CTimeTable TimeTable, DateTime Start, DateTime End);
        /// <summary>メインウインドウの関連付け
        /// </summary>
        /// <param name="MainForm">メインウインドウ</param>
        void BindMainWindow(FMainForm MainForm);
        /// <summary>メニューに追加する？
        /// </summary>
        bool IsMenuItem { get; }
    }
}
