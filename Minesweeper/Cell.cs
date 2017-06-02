using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    enum CellState { Untouched, Marked, Uncovered };

    struct Cell
    {
        public CellState State { get; set; }

        public bool Mine { get; set; }

        public Cell(bool mine = false, CellState state = CellState.Untouched)
        {
            State = state;
            Mine = mine;
        }
    }
}
