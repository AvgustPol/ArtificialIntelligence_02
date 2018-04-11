using CSVFileReadWrite;
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

        private delegate void CountTimeFucntion();

        CountTimeFucntion delegateBakcTrackingFunc;
        CountTimeFucntion delegateForwardCheckingFunc;

        public FormMain()
        {
            InitializeComponent();
            // just because XD -> Parametrs.FORWARD_CHECKING_PARAMETR
            // нужно создать таблицу, что бы вызывать функции, так что сначала создаем с как-нибудь (вообще 
            // стоит так не делать и удалить ненужное создавание.)
            CreateBoard(Parametrs.BOARD_DIMENSION, Parametrs.FORWARD_CHECKING_PARAMETR);

            

            
        }
        
        private CountTimeFucntion CreateBoard(int boardDimention, char functionParametr)
        {
            Parametrs.SetBoardDIMENSION(boardDimention);

            cellControls = new List<CellControl>();
            board = new Board(this);

            for (int x = 0; x < boardDimention; x++)
            {
                for (int y = 0; y < boardDimention; y++)
                {
                    cellControls.Add(new CellControl(this, x, y, board));
                }
            }

            if (functionParametr == Parametrs.BACK_TRACKING_PARAMETR)
            {
                delegateBakcTrackingFunc = board.BackTracking;
                return delegateBakcTrackingFunc;
            }
            else
            {
                delegateForwardCheckingFunc = board.ForwardChecking;
                return delegateForwardCheckingFunc;
            }
        }

        private void buttonBacktracking_Click(object sender, EventArgs e)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            board.BackTracking();

            stopWatch.Stop();
            int timeMs = (int) stopWatch.ElapsedMilliseconds; 
            Finished(timeMs);
        }

        public void AddTextToTextBox(string text)
        {
            textBoxEvents.Text += $"{text}\n";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            board.ForwardChecking();

            stopWatch.Stop();
            int timeMs = (int)stopWatch.ElapsedMilliseconds;
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

        private void buttonStartFullAnalization_Click(object sender, EventArgs e)
        {
            CountTimeForFucnc(Parametrs.FORWARD_CHECKING_PARAMETR);
            //CountTimeForFucnc(Parametrs.BACK_TRACKING_PARAMETR);
        }

        private void CountTimeForFucnc(char functionParametr)
        {
            ExcelWorker excel = new ExcelWorker($"Full analyze {functionParametr}");

            for (int i = 0; i < Parametrs.DIMENSIONS.Length; i++)
            {
                
                int averageTime = 0;
                int counter = 30;

                for (int l = 0; l < counter; l++)
                {
                    CountTimeFucntion countTimeFucntion = CreateBoard(Parametrs.DIMENSIONS[i], functionParametr);
                    int timeMs = CountTime(countTimeFucntion);
                    averageTime += timeMs;
                }

                excel.AddCellToWorksheetIntoColumnsAB(Parametrs.DIMENSIONS[i], averageTime/ counter);
                //excel.AddCellToWorksheetIntoColumnsAB(Parametrs.DIMENSIONS[i], timeMs);
            }
        }

        private int CountTime(CountTimeFucntion delegateCountTimeFucntion)
        {
            Stopwatch stopWatch = new Stopwatch();
            
            stopWatch.Start();

            delegateCountTimeFucntion();

            stopWatch.Stop();
            return (int)stopWatch.ElapsedMilliseconds;
        }
    }
}
