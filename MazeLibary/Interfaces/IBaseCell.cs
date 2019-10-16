using System;
using System.Collections.Generic;
using System.Text;

namespace MazeLibrary.Interfaces
{
    /// <summary>
    /// Contains info about <c>BaseCell</c>.
    /// <para>Inherits from <c>ICoordinates</c>.</para>
    /// </summary>
    public interface IBaseCell : ICoordinates
    {
        /// <summary>
        /// Gets skin of the object.
        /// </summary>
        char Skin { get; }//private
        /// <summary>
        /// Returns true(false) if we can(can't) step in this cell.
        /// </summary>
        /// <returns>The true/false state.</returns>
        bool TryToStep();
    }
}
