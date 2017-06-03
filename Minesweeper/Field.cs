using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    class Field
    {
        Cell[,] cells = new Cell[10, 10];

        public Field()
        {
            Random rand = new Random();

            for (int i = 0; i < 10; i++)
            {
                int row, column;
                do
                {
                    int n = rand.Next(100);
                    row = n / 10;
                    column = n % 10;
                } while (!PutMine(row, column));
            }
        }

        public int GetNeighbourMinesCount(int row, int column)
        {
            int count = 0;

            int minrow = cells.GetLowerBound(0);
            int maxrow = cells.GetUpperBound(0);
            int mincol = cells.GetLowerBound(1);
            int maxcol = cells.GetUpperBound(1);

            for (int rowOffset = -1; rowOffset <= +1; rowOffset++)
            {
                int currow = row + rowOffset;
                if (currow >= minrow && currow <= maxrow)
                    for (int columnOffset = -1; columnOffset <= +1; columnOffset++)
                    {
                        int curcol = column + columnOffset;
                        if (curcol >= mincol && curcol <= maxcol)
                            if (!(curcol == column && currow == row))
                                if (cells[currow, curcol].Mine)
                                    count++;
                    }
            }

            return count;
        }

        public Cell this[int row, int column]
        {
            get
            {
                return cells[row, column];
            }
        }

        private bool PutMine(int row, int column)
        {
            if (cells[row, column].Mine == false)
            {
                cells[row, column].Mine = true;
                return true;
            }
            else
                return false;
        }

        public void Uncover(int row, int column)
        {
            Debug.Assert(cells[row, column].State != CellState.Uncovered);
            cells[row, column].State = CellState.Uncovered;
        }

        public void Mark(int row, int column)
        {
            Debug.Assert(cells[row, column].State != CellState.Uncovered);
            cells[row, column].State = CellState.Marked;
        }

        public void Unmark(int row, int column)
        {
            Debug.Assert(cells[row, column].State != CellState.Uncovered);
            cells[row, column].State = CellState.Untouched;
        }
    }
}
