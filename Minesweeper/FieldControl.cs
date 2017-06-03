using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    partial class FieldControl : Control
    {
        Size cellSize = new Size(16, 16);

        Field field = new Field();

        Image[] nums = new Image[8];
        Image mine;

        public FieldControl()
        {
            InitializeComponent();

            ComponentResourceManager mgr = new ComponentResourceManager(typeof(FieldControl));

            for (int i = 0; i < 8; i++)
            {
                nums[i] = (Image)mgr.GetObject(string.Format("num{0}", i + 1));
            }

            mine = (Image)mgr.GetObject("mine");
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            DrawField(pe);
        }

        private void DrawField(PaintEventArgs pe)
        {
            Size correctedSize = Size.Subtract(cellSize, new Size(1, 1));

            for (int row = 0; row < 10; row++)
            {
                for (int column = 0; column < 10; column++)
                {
                    DrawCell(pe, row, column);
                }
            }
        }

        private void DrawCell(PaintEventArgs pe, int row, int column)
        {
            switch (field[row, column].State)
            {
                case CellState.Untouched:
                    DrawCellCover(pe.Graphics, CellRectangle(row, column));
                    break;
                case CellState.Marked:
                    break;
                case CellState.Uncovered:
                    if (field[row, column].Mine)
                    {
                        DrawCellMine(pe.Graphics, CellRectangle(row, column));
                    }
                    else
                    {
                        int mines = field.GetNeighbourMinesCount(row, column);
                        DrawCellNumber(pe.Graphics, CellRectangle(row, column), mines);
                    }
                    break;
                default:
                    break;
            }
        }

        private void DrawCellMine(Graphics graphics, Rectangle rectangle)
        {
            graphics.FillRectangle(SystemBrushes.ControlDark, rectangle);
            rectangle.Size -= new Size(1, 1);
            graphics.DrawRectangle(new Pen(Color.Gray), rectangle);
            graphics.DrawImage(mine, rectangle);
        }

        Rectangle CellRectangle(int row, int column)
        {
            Point corner = new Point(
                cellSize.Width * column,
                cellSize.Height * row);

            return new Rectangle(corner, cellSize);
        }

        void DrawCellCover(Graphics graphics, Rectangle cell)
        {
            cell.Size -= new Size(1, 1);
            graphics.DrawRectangle(Pens.Black, cell);
        }

        private void DrawCellNumber(Graphics graphics, Rectangle rectangle, int num)
        {
            graphics.FillRectangle(SystemBrushes.ControlDark, rectangle);
            rectangle.Size -= new Size(1, 1);
            graphics.DrawRectangle(new Pen(Color.Gray), rectangle);

            if (num >  0)
            {
                graphics.DrawImage(nums[num - 1], rectangle);
            }
        }

        public event EventHandler<CellClickEventArgs> CellClick;

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            int row = e.Location.Y / cellSize.Height;
            int column = e.Location.X / cellSize.Width;

            Cell cell = field[row, column];

            if (cell.State == CellState.Uncovered)
                return;

            CellAction action = CellAction.None;

            switch (e.Button)
            {
                case MouseButtons.Left:
                    action = CellAction.Uncover;
                    break;
                case MouseButtons.Right:
                    action = cell.State == CellState.Marked ? CellAction.Unmark : CellAction.Mark;
                    break;
            }

            if (action == CellAction.None)
                return;

            OnCellClick(new CellClickEventArgs(row, column, action));
        }

        protected void OnCellClick(CellClickEventArgs e)
        {
            CellClick?.Invoke(this, e);

            switch (e.Action)
            {
                case CellAction.Mark:
                    field.Mark(e.Row, e.Column);
                    break;
                case CellAction.Unmark:
                    field.Unmark(e.Row, e.Column);
                    break;
                case CellAction.Uncover:
                    field.Uncover(e.Row, e.Column);
                    break;
            }
            Rectangle cell = CellRectangle(e.Row, e.Column);
            Invalidate(cell);
        }
    }
}
