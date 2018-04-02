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
        public Cell(int x, int y, CellControl cellControl)
        {
            CellControl = cellControl;
            Queen = null;
            PositionX = x;
            PositionY = y;
            WasHere = false;
            UnderAttack = false;
        }
    }
}
