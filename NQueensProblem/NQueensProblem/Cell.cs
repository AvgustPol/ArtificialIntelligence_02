namespace NQueensProblem

{
    public class Cell
    {
        public CellControl CellControl{ get; set; }
        public Queen Queen { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int ColorValue { get; set; }
        public bool WasHere { get; set; }
        public Cell(int x, int y, CellControl cellControl)
        {
            CellControl = cellControl;
            Queen = null;
            PositionX = x;
            PositionY = y;
            WasHere = false;
        }        

        public bool IsEmpty()
        {
            return Queen == null;
        }
    }
}
