using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            CreateBoard();
        }
        
        private void CreateBoard()
        {
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
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            board.BackTracking();

            stopWatch.Stop();
            int timeMs = (int) stopWatch.ElapsedTicks; 
            Finished(timeMs);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            board.ForwardChecking();

            stopWatch.Stop();
            int timeMs = (int)stopWatch.ElapsedTicks;
            Finished(timeMs);
        }

        private void buttonMinusDelay_Click(object sender, EventArgs e)
        {
            int delay = GetRenderDelay();
            if(delay > Parametrs.MINIMUM_RENDER_DELAY)
            {
                //makes delay 2 times shorter
                textBoxGreenDelay.Text = (delay / 2).ToString();
            }
            else
            {
                textBoxGreenDelay.Text = Parametrs.MINIMUM_RENDER_DELAY.ToString();
            }
        }

        public int GetRenderDelay()
        {
            int result;
            Int32.TryParse(textBoxGreenDelay.Text, out result);
            return result;
        }

        private void buttonPlusDelay_Click(object sender, EventArgs e)
        {
            int delay = GetRenderDelay();
            //makes delay 2 times longer
            textBoxGreenDelay.Text = (delay * 2).ToString();
        }

        private void Finished(int timeMs)
        {
            labelFinished.Visible = true;
            SetFinishedTime(timeMs);
            
        }

        private void SetFinishedTime(int timeMs)
        {
            textBoxResultTime.Text = timeMs.ToString();
        }
    }
}
