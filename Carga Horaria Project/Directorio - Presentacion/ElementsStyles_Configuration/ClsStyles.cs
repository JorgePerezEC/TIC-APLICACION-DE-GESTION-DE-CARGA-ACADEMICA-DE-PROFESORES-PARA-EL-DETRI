using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.CompilerServices;
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
        public void tableActivateDocentesStyle(DataGridView dgTable)
        {
            dgTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgTable.AllowDrop = false;
            dgTable.AllowUserToAddRows = false;
            dgTable.AllowUserToDeleteRows = false;
            dgTable.ReadOnly = true;
            dgTable.AllowUserToResizeColumns = false;
            dgTable.EnableHeadersVisualStyles = false;
            dgTable.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgTable.BorderStyle = BorderStyle.None;
            //dgTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //dgTable.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dgTable.ColumnHeadersHeight = 20;
            dgTable.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //dgTable.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
            dgTable.RowHeadersDefaultCellStyle.BackColor = MyBlueColor;
            dgTable.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgTable.RowHeadersVisible = false;
            //dgTable.RowHeadersWidth = 60;


            //Table Color define
            dgTable.BackgroundColor = MyBlueColor;
            dgTable.RowsDefaultCellStyle.BackColor = MyBlueColor;
            dgTable.RowsDefaultCellStyle.ForeColor = MyWhiteColor;
            dgTable.RowsDefaultCellStyle.SelectionBackColor = SelectedColorRowB;
            dgTable.RowsDefaultCellStyle.SelectionForeColor = SelectedColorRowText;

            dgTable.ColumnHeadersDefaultCellStyle.BackColor = HeaderBk;
            dgTable.ColumnHeadersDefaultCellStyle.ForeColor = MyWhiteColor;
            dgTable.ColumnHeadersDefaultCellStyle.SelectionBackColor = HeaderBk;
            dgTable.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 11F, FontStyle.Bold);
            dgTable.RowsDefaultCellStyle.Font = new Font("Tahoma", 10F, FontStyle.Regular);

            dgTable.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }
        #endregion

        #region TreeView Style
        public void treeViewStyle(TreeView treeView)
        {
            treeView.BackColor = MyBlueColor;
        }
        #endregion

        #region Button Style
        public void BtnDefault(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Size = new Size(150, 40);
            btn.BackColor = Color.MediumSlateBlue;
            btn.ForeColor = Color.White;
        }

        private GraphicsPath GetFigurePath(RectangleF rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Width-radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Width - radius, rect.Height-radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();

            return path;
        }
        #endregion
    }
}
