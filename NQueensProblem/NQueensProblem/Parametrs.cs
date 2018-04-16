using System.Drawing;

namespace NQueensProblem
{
    static class Parametrs
    {
        static public int RECURSIVE_COUNTER = 0;

        //, 18, 20, 22, 24, 26, 28, 30, 40, 30
        static readonly public int[] DIMENSIONS = new int[] { 30 };

        static public int BOARD_DIMENSION = 4;

        static readonly public int CELL_SIZE = 50;
        static readonly public int DIAGONAL_DESIRED_DIFFERENCE = 2;

        public const string BACK_TRACKING_PARAMETR             = "BACK_TRACKING";
        public const string FORWARD_CHECKING_PARAMETR          = "FORWARD_CHECKING";
        public const string SQUARE_BACK_TRACKING_PARAMETR      = "squre BACK_TRACKING";
        public const string SQUARE_FORWARD_CHECKING_PARAMETR   = "squre FORWARD_CHECKING";

        static readonly public Color COLOR_DART = Color.FromArgb(202, 167, 132);
        static readonly public Color COLOR_LIGHT = Color.FromArgb(230, 220, 186);
        //static readonly public Color COLOR_DOESNT_BEAT = Color.FromArgb(0, 250, 154); //green
        static readonly public Color COLOR_DOESNT_BEAT_DART_1 = Color.FromArgb(192, 192, 192); //grey 1

        static readonly public Color COLOR_DOESNT_BEAT_DART_2 = Color.FromArgb(128, 128, 128); //grey 1


        static readonly public Color COLOR_BEAT = Color.FromArgb(220, 20, 60); //red

        static readonly public string QUEEN_IMAGE_PATH = @"D:\Google drive\обучение\6 sem\Szt. Inż\Lab02 win forms\NQueensProblem\NQueensProblem\bin\Debug\Images\Queen.png";


        static readonly public int MINIMUM_RENDER_DELAY = 1; // ms

        public static void SetBoardDIMENSION(int dimention)
        {
            BOARD_DIMENSION = dimention;
        }
    }
}
