using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TimeTableManager.UI;

namespace TimeTableManager {
    static class Program {
        /// <summary>エントリポイント
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FMainForm());
        }
    }
}