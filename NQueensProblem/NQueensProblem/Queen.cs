namespace NQueensProblem
{
    public class Queen
    {
        public Cell Cell { get; set; }

        public Queen(Cell cell)
        {
            this.Cell = cell;
            cell.WasHere = true;
        }
    }
}
