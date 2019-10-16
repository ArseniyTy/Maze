using System;
using System.Collections.Generic;
using System.Linq;
using MazeLibrary.Cells;
using MazeLibrary.Interfaces;
using MazeLibrary.Generation_algorithms;

namespace MazeLibrary
{
    /// <summary>
    /// Contains info about maze and provides convenient access to cells of the maze.
    /// <para>Implements <c>IMaze</c>.</para>
    /// </summary>
    public class Maze : IMaze
    {
        /// <summary>
        /// Contains the generation algorithm.
        /// </summary>
        private IGeneration generator;
        /// <summary>
        /// Sets the generation algorithm (saves in generator).
        /// </summary>
        /// <param name="genAlgo">Generation algotithm</param>
        public void SetGenerationAlgorithm(IGeneration genAlgo)
        {
            generator = genAlgo;
        }
        /// <summary>
        /// Gets the height of the maze.
        /// </summary>
        public int Height { get; }
        /// <summary>
        /// Gets the width of the maze.
        /// </summary>
        public int Width { get; }
        /// <summary>
        /// Contains all the cells of the maze.
        /// </summary>
        public List<BaseCell> Cells { get; } = new List<BaseCell>();

        /// <summary>
        /// Constructor of the <c>Maze</c> (with its generation).
        /// </summary>
        /// <param name="height">Height of the maze.</param>
        /// <param name="width">Width of the maze.</param>
        /// <param name="generatorAlgo">Generation algorithm</param>
        public Maze(int height, int width, IGeneration generatorAlgo = null)
        {
            this.Height = height;
            this.Width = width;

            if(generatorAlgo != null)
                Cells = generatorAlgo.GenerateMaze(height, width);
            else
            {
                if(generator==null)
                    SetGenerationAlgorithm(new NeighborGeneration());
                Cells = generator.GenerateMaze(height, width);
            }
                
        }
        /// <summary>
        /// Simple constructor of the <c>Maze</c>.
        /// </summary>
        /// <param name="height">Height of the maze.</param>
        /// <param name="width">Width of the maze.</param>
        internal Maze(int height, int width)
        {
            this.Height = height;
            this.Width = width;
        }

        /// <summary>
        /// Provides a convenient access to the <c>List<BaseCell> Cells</c> by X-Y value.
        /// </summary>
        /// <param name="x">X position of the cell</param>
        /// <param name="y">X position of the cell</param>
        /// <returns>the needed cell</returns>
        public BaseCell this[int x, int y]
        {

            //var cell = Maze[1,2];
            get
            {
                return Cells.SingleOrDefault(cell => cell.X == x && cell.Y == y);
            }

            //Maze[1,2] = new Wall(1,2);
            set
            {
                var oldCell = this[value.X, value.Y];
                if (oldCell != null)
                {
                    Cells.Remove(oldCell);
                }
                Cells.Add(value);
            }
        }

        /// <summary>
        /// Moves the player to the needed cell.
        /// </summary>
        /// <param name="direction">The type of movement(Up,Down,Right,Left).</param>
        public void TryToMove(Direction direction)
        {
            BaseCell cellToMove = null;

            var hero = Player.GetPlayer;

            switch (direction)
            {
                case Direction.Up:
                    cellToMove = this[hero.X, hero.Y - 1];
                    break;
                case Direction.Right:
                    cellToMove = this[hero.X + 1, hero.Y];
                    break;
                case Direction.Down:
                    cellToMove = this[hero.X, hero.Y + 1];
                    break;
                case Direction.Left:
                    cellToMove = this[hero.X - 1, hero.Y];
                    break;
            }

            if (cellToMove?.TryToStep() ?? false)
            {
                hero.X = cellToMove.X;
                hero.Y = cellToMove.Y;
            }
        }
    }
}
