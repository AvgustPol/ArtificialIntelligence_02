using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NQueensProblem
{
    /// <summary>
    /// сделать не статическим и передать его в целл как отец
    /// </summary>

    public class Board
    {
        FormMain Form;
        List<Cell> cells;
        List<Queen> queens;
        Random random = new Random((int)DateTime.Now.Ticks);

        public Board(FormMain Form)
        {
            this.Form = Form;
            queens = new List<Queen>();
            cells = new List<Cell>();
        }

        public void RenderAllQueens()
        {
            foreach (var item in queens)
            {
                item.cell.CellControl.SetDefaultImage();
            }
            Application.DoEvents();
            Thread.Sleep(Form.GetRenderDelay());
        }

        public List<Queen> BackTracking()
        {
            // first y position is 0
            FindQueensRecursiveBackTracking(0);
            return queens;
        }

        private bool FindQueensRecursiveBackTracking(int yPosition)
        {
            RenderAllQueens();
            if (yPosition == Parametrs.BOARD_DIMENSION)
                return true;
            for (int xPosition = 0; xPosition < Parametrs.BOARD_DIMENSION; xPosition++)
            {
                Queen queen = new Queen(GetCell(xPosition, yPosition));
                AddQueen(queen);
                if (FoundSafe())
                {
                    if (FindQueensRecursiveBackTracking(yPosition + 1))
                        return true;
                    else
                        RemoveQueenFromBoard(queen);
                }
                else
                {
                    RemoveQueenFromBoard(queen);
                }

            }
            return false;
        }


        public List<Queen> ForwardChecking()
        {
            bool result = FindQueensRecursiveForwardChencking(0);
            return queens;
        }

        private bool FindQueensRecursiveForwardChencking(int yPosition)
        {
            RenderAllQueens();
            if (yPosition == Parametrs.BOARD_DIMENSION)
                return true;
            //ищем следующий свободный на уровне y + такой , что бы мы там еще не были 
            Cell nextEmptyCell = GetNextEmptyCell(yPosition);
            if (nextEmptyCell != null)
            {
                Queen queen = new Queen(nextEmptyCell);
                AddQueen(queen);
                if (FindQueensRecursiveForwardChencking(yPosition + 1))
                    return true;
                else
                {
                    // was here = false для всех строк от (yPosition + 1) до Parametrs.BOARD_DIMENSION
                    ClearAllCells(yPosition + 1);
                    RemoveQueenFromBoard(queen);
                    if (FindQueensRecursiveForwardChencking(yPosition))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private Cell GetNextEmptyCell(int yPosition)
        {
            foreach (var cell in cells)
            {
                //если тут еще не пробовали поставить королеву и она никому тут не мешает 
                if (!cell.WasHere && cell.PositionY == yPosition && cell.UnderAttack == false)
                {
                    return cell;
                }
            }
            return null;
        }

        private Cell GetNextRandomEmptyCell(int yPosition)
        {
            int randomIndex = random.Next(Parametrs.BOARD_DIMENSION ^ 2);

            foreach (var cell in cells)
            {
                //если тут еще не пробовали поставить королеву и она никому тут не мешает 
                if (!cell.WasHere && cell.PositionY == yPosition && cell.UnderAttack == false)
                {
                    return cell;
                }
            }
            return null;
        }

        private void ClearAllCells(int yPosition)
        {
            foreach (var cell in cells)
            {
                if (cell.PositionY >= yPosition)
                {
                    cell.WasHere = false;
                }
            }
        }

        /// <summary>
        /// Checkes if any of queens beats another queen
        /// все королевы не бьют друг друга ? 
        /// </summary>
        /// <returns>true - if any queen doesnt beat any of other queen</returns>
        public bool FoundSafe()
        {
            // 0 and 1 queen - always safe 
            if (queens.Count < 2)
            {
                return true;
            }
            else
            {
                for (int i = 0; i < queens.Count; i++)
                {
                    for (int j = i + 1; j < queens.Count; j++)
                    {
                        if (QueenCheckBeats(queens.ElementAt(i), queens.ElementAt(j)))
                            return false;
                    }
                }
                return true;
            }
        }

        /// <summary>
        /// Checkes if queen beats other queen
        /// Бьет ли кого-то ферзь????
        /// </summary>
        /// <param name="queen"></param>
        /// <param name="otherQueen"></param>
        /// <returns>false - if queen doesnt beat other queen </returns>
        private bool QueenCheckBeats(Queen queen, Queen otherQueen)
        {
            bool result = false;

            result = QueenBeatsVertical(queen, otherQueen);
            if (!result)
            {
                result = QueenBeatsHorizontal(queen, otherQueen);
                if (!result)
                {
                    result = QueenBeatsDiagonal(queen, otherQueen);
                }
            }
            return result;
        }

        /// <summary>
        /// true - если королева на позиции сell может ударить фигуру на позиции otherCell
        /// </summary>
        /// <param name="cell"></param>
        /// <param name="otherCell"></param>
        /// <returns></returns>
        private bool CheckBeats(Cell cell, Cell otherCell)
        {
            return (BeatsVertical(cell, otherCell) || BeatsHorizontal(cell, otherCell) || BeatsDiagonal(cell, otherCell));
        }

        private bool QueenBeatsDiagonal(Queen queen, Queen otherQueen)
        {
            return BeatsDiagonal(queen.cell, otherQueen.cell);
        }

        private bool BeatsDiagonal(Cell сell, Cell otherCell)
        {
            //диагонали поля это графики ф-ций y = x+n и y=-x+n
            int queenDiagonal1 = сell.PositionX - сell.PositionY;
            int queenDiagonal2 = сell.PositionX + сell.PositionY;

            int otherQueenDiagonal1 = otherCell.PositionX - otherCell.PositionY;
            int otherQueenDiagonal2 = otherCell.PositionX + otherCell.PositionY;

            if (queenDiagonal1 == otherQueenDiagonal1 || queenDiagonal2 == otherQueenDiagonal2)
            {
                return true;
            }

            return false;
        }

        private bool QueenBeatsVertical(Queen queen, Queen otherQueen)
        {
            return BeatsVertical(queen.cell, otherQueen.cell);
        }

        private bool BeatsVertical(Cell сell, Cell otherCell)
        {
            if (сell.PositionY == otherCell.PositionY)
            {
                return true;
            }
            return false;
        }

        private bool QueenBeatsHorizontal(Queen queen, Queen otherQueen)
        {
            return BeatsHorizontal(queen.cell, otherQueen.cell);
        }

        private bool BeatsHorizontal(Cell сell, Cell otherCell)
        {
            if (сell.PositionX == otherCell.PositionX)
            {
                return true;
            }
            return false;
        }

        private Cell GetCell(int x, int y)
        {
            foreach (var cell in cells)
            {
                if (cell.PositionX == x && cell.PositionY == y)
                    return cell;
            }

            return null;
        }

        public void Add(Cell cell)
        {
            cells.Add(cell);
        }

        public void AddQueen(Queen queen)
        {
            queens.Add(queen);
            SetAllCellsUnderAttack(queen);
            RenderAllLinesForQueen(queen, Parametrs.COLOR_DOESNT_BEAT);
        }
        
        private void SetAllCellsUnderAttack(Queen queen)
        {
            foreach (var cell in cells)
            {
                if(CheckBeats(queen.cell, cell))
                {
                    cell.UnderAttack = true;
                }
            }
        }

        private void DeleteAllCellsUnderAttack(Queen queen)
        {
            foreach (var cell in cells)
            {
                //если коровела, которая была ранее могла задеть фигиру на позиции сell
                if (CheckBeats(queen.cell, cell))
                    //и никто другой не мог ее там задеть 
                    if(CheckBeatsOtherQueens(queen, cell))
                        cell.UnderAttack = false;
                //в противном случае ничего не происходит, так как другие фигуры и так могут задеть сell
            }
            queen.cell.UnderAttack = false;
        }

        /// <summary>
        /// true -  если ни одна другая королева не может ударить фигуру на позиции cell
        /// </summary>
        /// <param name="queen"></param>
        /// <param name="cell"></param>
        /// <returns>true -  если ни одна другая королева не может ударить фигуру на позиции cell</returns>
        private bool CheckBeatsOtherQueens(Queen queen, Cell cell)
        {
            foreach (var otherQueen in queens)
            {
                if(queen != otherQueen)
                    if (CheckBeats(otherQueen.cell, cell))
                        return false;
            }
            return true;
        }

        public void RenderAllLinesForQueen(Queen queen, Color color)
        {
            foreach (var cell in cells)
            {
                if (CheckBeats(queen.cell, cell))
                {
                    cell.CellControl.BackColor = color;
                }
            }
        }
        
        private void RemoveQueenFromBoard(Queen queen)
        {
            SetDefualtColorsToLines(queen);
            DeleteAllCellsUnderAttack(queen);
            queens.Remove(queen);
            queen.cell.CellControl.RemoveImage();
        }

        public void SetDefualtColorsToLines(Queen queen)
        {
            foreach (var cell in cells)
            {
                if (CheckBeatsOtherQueens(queen, cell))
                {
                    cell.CellControl.SetDefaultColor();
                }
            }
        }
    }
}

