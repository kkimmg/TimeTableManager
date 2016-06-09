using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using TimeTableManager.DefaultElement;

namespace TimeTableManager.Component {
    /// <summary>
    /// パターンコンボボックス
    /// </summary>
    class PatternComboBoxColumn : DataGridViewComboBoxColumn {
        private Member member;
        /// <summary>
        /// メンバー
        /// </summary>
        public Member Member {
            get { return member; }
            set {
                member = value;
                this.HeaderText = member.Name;
            }
        }
    }
}
