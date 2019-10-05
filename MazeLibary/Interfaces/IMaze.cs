using System;
using System.Collections.Generic;
using System.Text;
using MazeLibrary.Cells;

namespace MazeLibrary
{
    public interface IMaze
    {
        int Height { get; }
        int Width { get; }
        List<BaseCell> Cells { get; }
        BaseCell this[int x, int y] { get; set; }

        void TryToStep(Direction direction);
    }
}
