using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NQueensProblem
{
    public partial class FormMain : Form
    {
        List<CellControl> cellControls;
        Board board;
        public FormMain()
        {
            InitializeComponent();
            cellControls = new List<CellControl>();
            board = new Board(this);
        }

        private void buttonCreateBoard_Click(object sender, EventArgs e)
        {
            //Board board = new Board();
            for (int x = 0; x < Parametrs.BOARD_DIMENSION; x++)
            {
                for (int y = 0; y < Parametrs.BOARD_DIMENSION; y++)
                {
                    cellControls.Add(new CellControl(this, x, y, board));
                }
            }
            
        }

        private void buttonBacktracking_Click(object sender, EventArgs e)
        {
            board.BackTracking();
            board.RenderAllQueens();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            labelIsFound.Text = (board.FoundSafe()).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            board.ForwardChecking();
            board.RenderAllQueens();
        }

        private void buttonMinusDelay_Click(object sender, EventArgs e)
        {
            int delay = GetRenderDelay();
            if(delay > Parametrs.MINIMUM_RENDER_DELAY)
            {
                //makes delay 2 times shorter
                textBoxDelay.Text = (delay / 2).ToString();
            }
            else
            {
                textBoxDelay.Text = Parametrs.MINIMUM_RENDER_DELAY.ToString();
            }
        }

        public int GetRenderDelay()
        {
            int result;
            Int32.TryParse(textBoxDelay.Text, out result);
            return result;
        }

        private void buttonPlusDelay_Click(object sender, EventArgs e)
        {
            int delay = GetRenderDelay();
            //makes delay 2 times longer
            textBoxDelay.Text = (delay * 2).ToString();
        }
    }
}
