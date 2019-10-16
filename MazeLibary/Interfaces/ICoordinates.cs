using System;
using System.Collections.Generic;
using System.Text;

namespace MazeLibrary.Interfaces
{
    /// <summary>
    /// Contains info (2 properties) about the X-Y position of the object.
    /// </summary>
    public interface ICoordinates
    {
        /// <summary>
        /// Gets and sets position of the object on the X axis.
        /// </summary>
        int X { get; set; }

        /// <summary>
        /// Gets and sets position of the object on the Y axis.
        /// </summary>
        int Y { get; set; }
    }
}
