using System;
using TimeTableManager.Element;
namespace TimeTableManager {
	/// <summary>
	/// 基本項目
	/// </summary>
	public interface ITimeTableElement {
		/// <summary>作成日
		/// </summary>
		System.DateTime Created {
			get;				
			set;				
		}
		/// <summary>次のID
		/// </summary>
		long NextID {
			get;				
		}
        /// <summary>プロパティキーの一覧
        /// </summary>
        /// <returns>プロパティキーの一覧</returns>
		System.Collections.IEnumerator GetEnumerator();
		/// <summary>削除日
		/// </summary>
		System.DateTime? Removed {
			get;				
			set;				
		}
		/// <summary>スケジュール全て
		/// </summary>
		CTimeTable TimeTable {
			get;				
		}
		/// <summary>オブジェクトID
		/// </summary>
		long ObjectID {
			get;
			set;
		}
		/// <summary>プロパティ
		/// </summary>
		/// <param name="key">キー</param>
		/// <returns>戻り値</returns>
		string GetProperty(string key);
		/// <summary>有効かどうか
		/// </summary>
		/// <param name="now">日付</param>
		/// <returns></returns>
		bool IsAvailable(System.DateTime now);
        /// <summary>有効かどうか
        /// </summary>
        /// <param name="param0">開始</param>
        /// <param name="param1">終了</param>
        /// <returns></returns>
        bool IsAvailable(System.DateTime param0, System.DateTime param1);
		/// <summary>有効かどうか
		/// </summary>
		/// <param name="available">有効かどうか</param>
		void  SetAvailable(bool available);
		/// <summary>有効かどうか
		/// </summary>
		/// <param name="available">有効かどうか</param>
		/// <param name="removed">削除日</param>
		void  SetAvailable(bool available, System.DateTime removed);
		/// <summary>プロパティの値
		/// </summary>
		/// <param name="key">プロパティのキー</param>
		/// <param name="value_Renamed">プロパティの値</param>
		void  SetProperty(string key, string value_Renamed);
        /// <summary>プロパティ
		/// </summary>
		string this[string key] {
			get;
			set;
		}
        /// <summary>コメント
        /// </summary>
        string Notes {
            get;
            set;
        }
        /// <summary>これはビルトインオブジェクトですか？
        /// </summary>
        bool BuiltIn {
            get;
        }
	}
}