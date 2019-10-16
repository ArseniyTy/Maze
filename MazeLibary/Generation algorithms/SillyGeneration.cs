using System;
using System.Collections.Generic;
using System.Text;
using MazeLibrary.Interfaces;
using MazeLibrary.Cells;

namespace MazeLibrary.Generation_algorithms
{
    /// <summary>
    /// Contains only 1 generation method.
    /// <para>Implements <c>IGeneration</c>.</para>
    /// <para>Strategy pattern.</para>
    /// </summary>
    public class SillyGeneration : IGeneration
    {
        /// <summary>
        /// Generates the maze with a specific algorithm.
        /// </summary>
        /// <param name="height">Height of the maze.</param>
        /// <param name="width">Width of the maze.</param>
        /// <returns><returns><c>List<BaseCell</c></returns>.</returns>
        public List<BaseCell> GenerateMaze(int height, int width)
        {
            //Реализация другого алгоритмы в перспективе
            return new NeighborGeneration().GenerateMaze(height, width);
        }
    }
}
