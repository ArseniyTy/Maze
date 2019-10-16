using System;
using System.Collections.Generic;
using System.Text;
using MazeLibrary.Interfaces;

namespace MazeLibrary.Cells
{
    /// <summary>
    /// Base class for <c>Ground</c> and <c>Wall</c>.
    /// <para>Abstract class that implements <c>IBaseCell</c>.</para>
    /// </summary>
    public abstract class BaseCell : IBaseCell
    {
        protected BaseCell(int x, int y, char skin)
        {
            X = x;
            Y = y;
            Skin = skin;
        }

        /// <summary>
        /// Gets and sets position of the object on the X axis.
        /// </summary>
        public int X { get; set; }
        /// <summary>
        /// Gets and sets position of the object on the Y axis.
        /// </summary>
        public int Y { get; set; }
        public char Skin { get; private set; }
        public abstract bool TryToStep();
    }
}
