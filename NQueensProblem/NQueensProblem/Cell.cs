#define Kwadrat
//#undef Kwadrat
using System.Collections.Generic;

namespace NQueensProblem

{
    public class Cell
    {
        public CellControl CellControl{ get; set; }
        public Queen Queen { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public bool WasHere { get; set; }
        public bool UnderAttack { get; set; }
#if Kwadrat
        public int? Value { get; set; }
        public HashSet<int> acceptableValues;
#endif
        public Cell(int x, int y, CellControl cellControl)
        {
#if Kwadrat
            acceptableValues = new HashSet<int>();
            for (int i = 1; i < Parametrs.BOARD_DIMENSION + 1; i++)
            {
                acceptableValues.Add(i);
            }
#endif
            CellControl = cellControl;
            Queen = null;
            PositionX = x;
            PositionY = y;
            WasHere = false;
            UnderAttack = false;
            Value = null;
        }

        public string ShowPozitions()
        {
            return $"({PositionX}, {PositionY})";
        }
    }
}
