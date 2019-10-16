using System;
using System.Collections.Generic;
using System.Text;
using MazeLibrary.Cells;

namespace MazeLibrary.Interfaces
{
    /// <summary>
    /// Contains GenerateMaze method.
    /// <para>Strategy pattern</para>
    /// </summary>
    public interface IGeneration
    {
        /// <summary>
        /// Generates the maze with a specific algorithm.
        /// </summary>
        /// <param name="height">Height of the maze.</param>
        /// <param name="width">Width of the maze.</param>
        /// <returns><c>List<BaseCell</c>.</returns>
        List<BaseCell> GenerateMaze(int height, int width);
    }
}
