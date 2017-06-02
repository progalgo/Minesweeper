using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    enum CellAction { None, Mark, Unmark, Uncover }

    class CellClickEventArgs : EventArgs
    {
        public int Row { get; private set; }

        public int Column { get; private set; }

        public CellAction Action { get; private set; }

        public CellClickEventArgs(int row, int column, CellAction action)
        {
            Row = row;
            Column = column;
            Action = action;
        }
    }
}
