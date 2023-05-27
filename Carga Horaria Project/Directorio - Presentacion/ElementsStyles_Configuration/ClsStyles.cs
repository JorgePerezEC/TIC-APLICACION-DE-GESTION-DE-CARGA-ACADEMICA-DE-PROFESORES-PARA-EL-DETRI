using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Color = System.Drawing.Color;

namespace Directorio___Presentacion.ElementsStyles_Configuration
{
    public class ClsStyles
    {
        #region Color variables
        private Color MyBlueColor = Color.FromArgb(13, 75, 146);
        private Color MyWhiteColor = Color.FromArgb(255, 255, 255);
        private Color MyYellowColor = Color.FromArgb(0, 255, 255);
        private Color SelectedColorRowB = Color.FromArgb(8, 84, 94);
        private Color SelectedColorRowText = Color.FromArgb(245, 245, 53);
        private Color HeaderBk = Color.FromArgb(0, 102, 120);
        #endregion

        #region TABLE STYLE
        public void tableStyle(DataGridView dgTable)
        {
            dgTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgTable.AllowDrop= false;
            dgTable.AllowUserToAddRows = false;
            dgTable.AllowUserToDeleteRows = false;
            dgTable.ReadOnly = true;
            dgTable.AllowUserToResizeColumns = false;
            dgTable.EnableHeadersVisualStyles = false;
            dgTable.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgTable.BorderStyle = BorderStyle.None;
            dgTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgTable.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dgTable.ColumnHeadersHeight = 50;
            dgTable.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //dgTable.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
            dgTable.RowHeadersDefaultCellStyle.BackColor = MyBlueColor;
            dgTable.RowHeadersBorderStyle= DataGridViewHeaderBorderStyle.Single;
            dgTable.RowHeadersVisible= false;
            dgTable.RowHeadersWidth = 60;
            

            //Table Color define
            dgTable.BackgroundColor = MyBlueColor;
            dgTable.RowsDefaultCellStyle.BackColor = MyBlueColor;
            dgTable.RowsDefaultCellStyle.ForeColor = MyWhiteColor;
            dgTable.RowsDefaultCellStyle.SelectionBackColor = SelectedColorRowB;
            dgTable.RowsDefaultCellStyle.SelectionForeColor = SelectedColorRowText;

            dgTable.ColumnHeadersDefaultCellStyle.BackColor = HeaderBk;
            dgTable.ColumnHeadersDefaultCellStyle.ForeColor = MyWhiteColor;
            dgTable.ColumnHeadersDefaultCellStyle.SelectionBackColor = HeaderBk;
            dgTable.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9.75F, FontStyle.Bold); ;

            dgTable.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }
        #endregion

        #region TreeView Style
        public void treeViewStyle(TreeView treeView)
        {
            treeView.BackColor = MyBlueColor;
        }
        #endregion
    }
}
