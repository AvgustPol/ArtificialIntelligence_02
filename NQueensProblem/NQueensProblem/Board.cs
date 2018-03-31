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
                queens.Add(queen);
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

        private void RemoveQueenFromBoard(Queen queen)
        {
            queens.Remove(queen);
            queen.cell.CellControl.RemoveImage();
        }

        public List<Queen> ForwardChecking()
        {
            FindQueensRecursiveForwardChencking(0);
            return queens;
        }

        private bool FindQueensRecursiveForwardChencking(int yPosition) 
        {
            if (yPosition == Parametrs.BOARD_DIMENSION)
                return true;
            //ищем следующий свободный на уровне y + такой , что бы мы там еще не были 
            Cell nextEmptyCell = GetNextEmptyCell(yPosition);
            if (nextEmptyCell != null)
            {
                Queen queen = new Queen(nextEmptyCell);
                if (FindQueensRecursiveForwardChencking(yPosition + 1))
                    return true;
                else
                {
                    // was here = false для всех строк от (yPosition + 1) до Parametrs.BOARD_DIMENSION
                    ClearAllCells(yPosition + 1);
                    RemoveQueenFromBoard(queen);
                    if (!FindQueensRecursiveForwardChencking(yPosition))
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        private Cell GetNextEmptyCell(int yPosition)
        {
            foreach (var cell in cells)
            {
                //should optimize
                Queen tmpQueen = new Queen(cell);
                //should optimize 
                queens.Add(tmpQueen);
                tmpQueen.cell.WasHere = false;
                //если тут еще не пробовали поставить королеву и она никому тут не мешает
                if (!cell.WasHere && !FoundSafe())
                {
                    //should optimize
                    RemoveQueenFromBoard(tmpQueen);
                    return cell;
                }
                //should optimize
                RemoveQueenFromBoard(tmpQueen);
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
            if(queens.Count < 2)
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
            RenderAllLinesForQueen(queen, Parametrs.COLOR_DOESNT_BEAT);
        }

        #region Grapth part

        /// <summary>
        /// 2 - обычное сравнение
        /// 1 - для диагнальных 
        /// </summary>
        /// <param name="center"></param>
        /// <param name="desiredDifference"></param>
        /// <returns></returns>
        private bool IsBadVerticalColor(Cell center, int desiredDifference)
        {
            int leftX = center.PositionX - 1;
            int rightX = center.PositionX + 1;
            int centerValue = GetCell(center.PositionX, center.PositionY).ColorValue;
            //checkes if we are in board
            if (leftX >= 0)
            {
                if (GetCell(leftX, center.PositionY).ColorValue - centerValue >= desiredDifference)
                {
                    return true;
                }
            }
            //checkes if we are in board
            if (rightX != Parametrs.BOARD_DIMENSION)
            {
                if (GetCell(center.PositionX, rightX).ColorValue - centerValue >= desiredDifference)
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsBadHorizontalColor(Cell center, int desiredDifference)
        {
            int topY = center.PositionY + 1;
            int bottomY = center.PositionY - 1;
            int centerValue = GetCell(center.PositionX, center.PositionY).ColorValue;
            //checkes if we are in board
            if (bottomY != Parametrs.BOARD_DIMENSION)
            {
                if (GetCell(center.PositionX, bottomY).ColorValue - centerValue >= desiredDifference)
                {
                    return true;
                }
            }
            //checkes if we are in board
            if (topY >= 0)
            {
                if (GetCell(center.PositionX, topY).ColorValue - centerValue >= desiredDifference)
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsBadDiagonalColor(Cell center)
        {
            //todo - смоти слайд;
            int desiredDifference = Parametrs.DIAGONAL_DESIRED_DIFFERENCE;
            int topLeftX = center.PositionX - 1;
            int topLeftY = center.PositionY - 1;

            int bottomLeftX = center.PositionX - 1;
            int bottomLeftY = center.PositionY + 1;

            int topRightX = center.PositionX + 1;
            int topRightY = center.PositionY - 1;

            int bottomRightX = center.PositionX + 1;
            int bottomRightY = center.PositionY + 1;

            int centerValue = GetCell(center.PositionX, center.PositionY).ColorValue;
            bool result = IsBadVerticalColor(GetCell(topLeftX, topLeftY), desiredDifference) 
                    && IsBadVerticalColor(GetCell(bottomLeftX, bottomLeftY), desiredDifference)  
                    && IsBadHorizontalColor(GetCell(topRightX, topRightY), desiredDifference) 
                    && IsBadHorizontalColor(GetCell(bottomRightX, bottomRightY), desiredDifference);
            return (result);
            
        }

        #endregion

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
    }
}

