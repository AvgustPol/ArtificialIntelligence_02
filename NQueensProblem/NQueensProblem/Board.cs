#define VISUALIZATION
//#undef VISUALIZATION

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace NQueensProblem
{
    public class Board
    {
        FormMain boardForm;
        List<Cell> cells;
        List<Queen> queens;
        Random random = new Random((int)DateTime.Now.Ticks);

        public Board(FormMain Form)
        {
            this.boardForm = Form;
            queens = new List<Queen>();
            cells = new List<Cell>();
        }

#if VISUALIZATION
        public void RenderAllQueens()
        {
            foreach (var item in queens)
            {
                item.Cell.CellControl.SetDefaultImage();
            }
            Application.DoEvents();
            Thread.Sleep(boardForm.GetRenderDelay());
        }
#endif


        public void BackTracking()
        {
            // first y position is 0
            FindQueensRecursiveBackTracking(0);
        }

        private bool FindQueensRecursiveBackTracking(int yPosition) 
        {
#if VISUALIZATION
            RenderAllQueens();
#endif
            if (yPosition == Parametrs.BOARD_DIMENSION)
                return true;
            for (int xPosition = 0; xPosition < Parametrs.BOARD_DIMENSION; xPosition++)
            {
                Cell newQueenCell = GetCell(xPosition, yPosition);
                
                if (FoundSafeOptimal(newQueenCell))
                {
                    Queen queen = new Queen(newQueenCell);
                    AddQueen(queen);
                    if (FindQueensRecursiveBackTracking(yPosition + 1))
                        return true;
                    else
                        RemoveQueenFromBoard(queen);
                }
            }
            return false;
        }


        public void ForwardChecking()
        {
            // 0 - first cell vertical index
            FindQueensRecursiveForwardChencking(0);
        }
        
        private bool FindQueensRecursiveForwardChencking(int yPosition)
        {
#if VISUALIZATION
            RenderAllQueens();
#endif
            if (yPosition == Parametrs.BOARD_DIMENSION)
                return true;
            //ищем следующий свободный на уровне y + такой , что бы мы там еще не были 
            //Cell nextEmptyCell = GetNextEmptyCell(yPosition); 
            Cell nextEmptyCell = GetNextRandomEmptyCell(yPosition);
            
            if (nextEmptyCell != null)
            {
                Queen queen = new Queen(nextEmptyCell);
                AddQueen(queen);
                boardForm.AddTextToTextBox($"Queen added to {nextEmptyCell.ShowPozitions()}\n");
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
            //boardForm.AddTextToTextBox($"Cell {nextEmptyCell.ShowPozitions()} is bad for queen to find solution\n");
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
            Shuffle(cells);
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

        public void Shuffle(List<Cell> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                Cell value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
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

        #region CellsComparing

        /// <summary>
        /// Checkes if any of queens beats another queen
        /// все королевы не бьют друг друга ? 
        /// </summary>
        /// <returns>true - if any queen doesnt beat any of other queen</returns>
        public bool FoundSafeOptimal(Cell newQueenCell)
        {
            for (int i = 0; i < queens.Count; i++)
            {
                if (CheckBeats(queens.ElementAt(i).Cell, newQueenCell))
                    return false;
            }
            return true;

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
            return BeatsDiagonal(queen.Cell, otherQueen.Cell);
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
            return BeatsVertical(queen.Cell, otherQueen.Cell);
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
            return BeatsHorizontal(queen.Cell, otherQueen.Cell);
        }

        private bool BeatsHorizontal(Cell сell, Cell otherCell)
        {
            if (сell.PositionX == otherCell.PositionX)
            {
                return true;
            }
            return false;
        }
        #endregion

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
#if VISUALIZATION
            RenderAllLinesForQueen(queen, Parametrs.COLOR_DOESNT_BEAT_DART_1);
#endif
        }
        
        private void SetAllCellsUnderAttack(Queen queen)
        {
            foreach (var cell in cells)
            {
                if(CheckBeats(queen.Cell, cell))
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
                if (CheckBeats(queen.Cell, cell))
                    //и никто другой не мог ее там задеть 
                    if(CheckBeatsOtherQueens(queen, cell))
                        cell.UnderAttack = false;
                //в противном случае ничего не происходит, так как другие фигуры и так могут задеть сell
            }
            queen.Cell.UnderAttack = false;
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
                    if (CheckBeats(otherQueen.Cell, cell))
                        return false;
            }
            return true;
        }

        
        
        private void RemoveQueenFromBoard(Queen queen)
        {
#if VISUALIZATION
            queen.Cell.CellControl.BackColor = Color.Red; 
            Application.DoEvents();
            Thread.Sleep(boardForm.GetRenderDelay());
            RenderAllLinesForQueen(queen, Parametrs.COLOR_DOESNT_BEAT_DART_1);
            SetDefualtColorsToLines(queen);
            boardForm.AddTextToTextBox($"Queen deleted from {queen.Cell.ShowPozitions()}");
#endif
            DeleteAllCellsUnderAttack(queen);
            queens.Remove(queen);

#if VISUALIZATION
            queen.Cell.CellControl.RemoveImage();
#endif
        }

#if VISUALIZATION
        public void RenderAllLinesForQueen(Queen queen, Color color)
        {
            foreach (var cell in cells)
            {
                if (CheckBeats(queen.Cell, cell))
                {   
                    if (cell.CellControl.BackColor == Parametrs.COLOR_LIGHT)
                    {
                        cell.CellControl.BackColor = Parametrs.COLOR_DOESNT_BEAT_DART_1;
                    }
                    if (cell.CellControl.BackColor == Parametrs.COLOR_DART)
                    {
                        cell.CellControl.BackColor = Parametrs.COLOR_DOESNT_BEAT_DART_2;
                    }
                }
            }
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
#endif
    }
}

