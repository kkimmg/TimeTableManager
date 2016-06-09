using System;
using TimeTableManager.Element;
namespace TimeTableManager {
	/// <author>  <a mailto="k_kim_mg@mvh.biglobe.ne.jp">Kenji Kimura</a>
	/// </author>
	public interface IFavoriteRandomizer {
        /// <summary>この発生装置の名前
        /// </summary>
        string Name {
            get;
        }
        /// <summary>当日からこの日数は自動設定しない
        /// </summary>
        int DayAfter {
            get;
            set;
        }
        /// <summary>自動設定する
        /// </summary>
        /// <param name="table">設定するタイムテーブル</param>
        /// <param name="Adate">開始</param>
        void AutoAllwithChief (CTimeTable table, DateTime Adate);
        /// <summary>自動設定する
        /// </summary>
        /// <param name="table">設定するタイムテーブル</param>
        /// <param name="start">開始</param>
        /// <param name="end">終了</param>
		void  AutoAllwithChief(CTimeTable table, DateTime start, DateTime end);
        /// <summary>自動設定する
        /// </summary>
        /// <param name="table">設定するタイムテーブル</param>
        /// <param name="today">基準日</param>
        /// <param name="start">開始</param>
        /// <param name="end">終了</param>
        void AutoAllwithChief (CTimeTable table, DateTime today, DateTime start, DateTime end);
	}
}