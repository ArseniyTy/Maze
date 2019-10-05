using System;
using System.Collections.Generic;
using System.Text;
using MazeLibrary.Interfaces;

namespace MazeLibrary.Cells
{
    public abstract class BaseCell : ICoordinates
    {
        protected BaseCell(int x, int y, char skin)
        {
            X = x;
            Y = y;
            Skin = skin;
        }

        public char Skin { get; private set; }
        public int X { get; set; }
        public int Y { get; set; }

        public abstract bool TryToStep();
    }
}
