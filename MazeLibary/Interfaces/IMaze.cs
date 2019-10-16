using System;
using System.Collections.Generic;
using System.Text;
using MazeLibrary.Cells;

namespace MazeLibrary
{
    /// <summary>
    /// Contains info about <c>Maze</c>.
    /// </summary>
    public interface IMaze
    {
        /// <summary>
        /// Gets the height of the maze.
        /// </summary>
        int Height { get; }
        /// <summary>
        /// Gets the width of the maze.
        /// </summary>
        int Width { get; }
        /// <summary>
        /// Contains all the cells of the maze.
        /// </summary>
        List<BaseCell> Cells { get; }
        /// <summary>
        /// Provides a convenient access to the <c>List<BaseCell> Cells</c> by X-Y value.
        /// </summary>
        /// <param name="x">X position of the cell</param>
        /// <param name="y">X position of the cell</param>
        /// <returns>the needed cell</returns>
        BaseCell this[int x, int y] { get; set; }

        /// <summary>
        /// Moves the player to the needed cell.
        /// </summary>
        /// <param name="direction">The type of movement(Up,Down,Right,Left).</param>
        void TryToMove(Direction direction);
    }
}
