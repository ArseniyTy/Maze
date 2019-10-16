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
    public class NeighborGeneration : IGeneration
    {
        /// <summary>
        /// Generates the maze with a specific algorithm.
        /// </summary>
        /// <param name="height">Height of the maze.</param>
        /// <param name="width">Width of the maze.</param>
        /// <returns><returns><c>List<BaseCell</c></returns>.</returns>
        public List<BaseCell> GenerateMaze(int height, int width)
        {
            Maze maze = new Maze(height, width);
            for (int y = 1; y < maze.Height - 1; y++)
            {
                for (int x = 1; x < maze.Width - 1; x++)
                {
                    maze.Cells.Add(new Ground(x, y));
                }
            }

            var rnd = new Random();
            int xRnd = rnd.Next(1, maze.Width - 1);
            int yRnd = rnd.Next(1, maze.Height - 1);


            var wallsStack = new Stack<BaseCell>();
            maze[xRnd, yRnd] = new Wall(xRnd, yRnd);
            wallsStack.Push(maze[xRnd, yRnd]);


            while (wallsStack.Count != 0)
            {
                BaseCell cell = wallsStack.Peek();
                var cellsToBuildWall = new List<BaseCell>();


                //доступные для постройки клетки
                BaseCell[] cellsToBuild = { maze[cell.X - 1, cell.Y], maze[cell.X + 1, cell.Y], maze[cell.X, cell.Y - 1], maze[cell.X, cell.Y + 1] };
                foreach (var cellToBuild in cellsToBuild)
                {
                    if (cellToBuild?.TryToStep() ?? false) //если земля
                    {
                        bool noNeib = true;
                        //соседи клетки, которая является землёй
                        BaseCell[] cellsNeib = new BaseCell[5];

                        //соседи выбираются из той стороны, куда походили
                        #region InisializingNeighbours
                        if (cellToBuild == maze[cell.X - 1, cell.Y])
                        {
                            cellsNeib[0] = maze[cellToBuild.X - 1, cellToBuild.Y - 1];
                            cellsNeib[1] = maze[cellToBuild.X - 1, cellToBuild.Y + 1];
                            cellsNeib[2] = maze[cellToBuild.X - 2, cellToBuild.Y - 1];
                            cellsNeib[3] = maze[cellToBuild.X - 2, cellToBuild.Y];
                            cellsNeib[4] = maze[cellToBuild.X - 2, cellToBuild.Y + 1];
                        }
                        else if (cellToBuild == maze[cell.X + 1, cell.Y])
                        {
                            cellsNeib[0] = maze[cellToBuild.X + 1, cellToBuild.Y - 1];
                            cellsNeib[1] = maze[cellToBuild.X + 1, cellToBuild.Y + 1];
                            cellsNeib[2] = maze[cellToBuild.X + 2, cellToBuild.Y - 1];
                            cellsNeib[3] = maze[cellToBuild.X + 2, cellToBuild.Y];
                            cellsNeib[4] = maze[cellToBuild.X + 2, cellToBuild.Y + 1];
                        }
                        else if (cellToBuild == maze[cell.X, cell.Y - 1])
                        {
                            cellsNeib[0] = maze[cellToBuild.X - 1, cellToBuild.Y - 1];
                            cellsNeib[1] = maze[cellToBuild.X + 1, cellToBuild.Y - 1];
                            cellsNeib[2] = maze[cellToBuild.X - 1, cellToBuild.Y - 2];
                            cellsNeib[3] = maze[cellToBuild.X, cellToBuild.Y - 2];
                            cellsNeib[4] = maze[cellToBuild.X + 1, cellToBuild.Y - 2];
                        }
                        else if (cellToBuild == maze[cell.X, cell.Y + 1])
                        {
                            cellsNeib[0] = maze[cellToBuild.X - 1, cellToBuild.Y + 1];
                            cellsNeib[1] = maze[cellToBuild.X + 1, cellToBuild.Y + 1];
                            cellsNeib[2] = maze[cellToBuild.X - 1, cellToBuild.Y + 2];
                            cellsNeib[3] = maze[cellToBuild.X, cellToBuild.Y + 2];
                            cellsNeib[4] = maze[cellToBuild.X + 1, cellToBuild.Y + 2];
                        }
                        #endregion

                        foreach (var neib in cellsNeib)
                        {
                            if (!(neib?.TryToStep() ?? true))
                            {
                                noNeib = false; //у стены в нужной плоскости есть сосед-стена
                                break;
                            }
                        }
                        if (noNeib)
                        {
                            cellsToBuildWall.Add(cellToBuild);
                        }
                    }
                }



                if (cellsToBuildWall.Count == 0)
                {
                    wallsStack.Pop();
                }
                else
                {
                    int indToBuild = rnd.Next(0, cellsToBuildWall.Count);
                    BaseCell newCell = cellsToBuildWall[indToBuild];

                    maze[newCell.X, newCell.Y] = new Wall(newCell.X, newCell.Y);
                    wallsStack.Push(maze[newCell.X, newCell.Y]);
                }

            }
            for (int x = 0; x < maze.Width; x++)
            {
                if (maze[x, 0] == null)
                {
                    maze.Cells.Add(new Ground(x, 0));
                }
                if (maze[x, maze.Height - 1] == null)
                {
                    maze.Cells.Add(new Ground(x, maze.Height - 1));
                }
            }
            for (int y = 0; y < maze.Height; y++)
            {
                if (maze[0, y] == null)
                {
                    maze.Cells.Add(new Ground(0, y));
                }
                if (maze[maze.Width - 1, y] == null)
                {
                    maze.Cells.Add(new Ground(maze.Width - 1, y));
                }
            }

            return maze.Cells;
        }
    }
}
