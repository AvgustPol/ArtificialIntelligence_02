namespace NQueensProblem
{
    public class Queen
    {
        public Cell cell { get; set; }

        public Queen(Cell cell)
        {
            this.cell = cell;
            cell.WasHere = true;
        }
        
        
    }
}
