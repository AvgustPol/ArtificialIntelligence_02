//#define VISUALIZATION
#undef VISUALIZATION

using System;
using System.Drawing;
using System.Windows.Forms;

namespace NQueensProblem
{
    public partial class CellControl : UserControl
    {
        Cell cell;
        public Board Board { get; set; }

        public CellControl(Form form, int x, int y, Board board)
        {
            cell = new Cell(x, y, this);
            Board = board;
#if(VISUALIZATION)
            #region Creating cell
            Parent = form;
            Location = new Point(x * Parametrs.CELL_SIZE + Parametrs.CELL_SIZE, y * Parametrs.CELL_SIZE + Parametrs.CELL_SIZE);
            Size = new Size(Parametrs.CELL_SIZE, Parametrs.CELL_SIZE);
            Click += new EventHandler(OnCellClick);
            BackgroundImageLayout = ImageLayout.Stretch;
            SetDefaultColor();
            #endregion
#endif
            Board.Add(cell);
        }

#if VISUALIZATION
        public void SetDefaultColor()
        {
            if (cell.PositionX % 2 == 0)
                if (cell.PositionY % 2 == 1)
                    this.BackColor = Parametrs.COLOR_DART;
                else
                    this.BackColor = Parametrs.COLOR_LIGHT;
            else
                        if (cell.PositionY % 2 == 1)
                this.BackColor = Parametrs.COLOR_LIGHT;
            else
                this.BackColor = Parametrs.COLOR_DART;
        }

        private void OnCellClick(object sender, EventArgs e)
        {
            Queen queen = new Queen(cell);
            SetQueen(queen);
        }

        private void SetQueen(Queen queen)
        {
            this.Board.AddQueen(queen);
            cell.Queen = queen;
            SetDefaultImage();
        }

        public void SetDefaultImage()
        {
            BackgroundImage = Image.FromFile(Parametrs.QUEEN_IMAGE_PATH);
        }

        public void RemoveImage()
        {
            BackgroundImage = null;
        }
#endif
    }
}

