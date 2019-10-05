using System;
using System.Collections.Generic;
using System.Linq;
using MazeLibrary.Cells;
using MazeLibrary.Interfaces;

namespace MazeLibrary
{
    public class Maze : IMaze
    {
        public int Height { get; }
        public int Width { get; }
        public List<BaseCell> Cells { get; } = new List<BaseCell>();

        public Maze(int height, int width)
        {
            this.Height = height;
            this.Width = width;

            MazeGeneration();
        }

        private void MazeGeneration()
        {
            for (int y = 1; y < Height-1; y++)
            {
                for (int x = 1; x < Width-1; x++)
                {
                    Cells.Add(new Ground(x, y));
                }
            }

            var rnd = new Random();
            int xRnd = rnd.Next(1, Width - 1);
            int yRnd = rnd.Next(1, Height - 1);


            var wallsStack = new Stack<BaseCell>();
            this[xRnd, yRnd] = new Wall(xRnd, yRnd);
            wallsStack.Push(this[xRnd, yRnd]);


            while (wallsStack.Count!=0)
            {
                BaseCell cell = wallsStack.Peek();
                var cellsToBuildWall = new List<BaseCell>();


                //доступные для постройки клетки
                BaseCell[] cellsToBuild = { this[cell.X - 1, cell.Y], this[cell.X + 1, cell.Y], this[cell.X, cell.Y-1], this[cell.X, cell.Y + 1] };
                foreach (var cellToBuild in cellsToBuild)
                {
                    if (cellToBuild?.TryToStep() ?? false) //если земля
                    {
                        bool noNeib = true;
                        //соседи клетки, которая является землёй
                        BaseCell[] cellsNeib = new BaseCell[5];

                        //соседи выбираются из той стороны, куда походили
                        #region InisializingNeighbours
                        if (cellToBuild == this[cell.X - 1, cell.Y])
                        {
                            cellsNeib[0] = this[cellToBuild.X - 1, cellToBuild.Y - 1];
                            cellsNeib[1] = this[cellToBuild.X - 1, cellToBuild.Y + 1];
                            cellsNeib[2] = this[cellToBuild.X - 2, cellToBuild.Y - 1];
                            cellsNeib[3] = this[cellToBuild.X - 2, cellToBuild.Y];
                            cellsNeib[4] = this[cellToBuild.X - 2, cellToBuild.Y + 1];
                        }
                        else if (cellToBuild == this[cell.X + 1, cell.Y])
                        {
                            cellsNeib[0] = this[cellToBuild.X + 1, cellToBuild.Y - 1];
                            cellsNeib[1] = this[cellToBuild.X + 1, cellToBuild.Y + 1];
                            cellsNeib[2] = this[cellToBuild.X + 2, cellToBuild.Y - 1];
                            cellsNeib[3] = this[cellToBuild.X + 2, cellToBuild.Y];
                            cellsNeib[4] = this[cellToBuild.X + 2, cellToBuild.Y + 1];
                        }
                        else if (cellToBuild == this[cell.X, cell.Y - 1])
                        {
                            cellsNeib[0] = this[cellToBuild.X - 1, cellToBuild.Y - 1];
                            cellsNeib[1] = this[cellToBuild.X + 1, cellToBuild.Y - 1];
                            cellsNeib[2] = this[cellToBuild.X - 1, cellToBuild.Y - 2];
                            cellsNeib[3] = this[cellToBuild.X, cellToBuild.Y - 2];
                            cellsNeib[4] = this[cellToBuild.X + 1, cellToBuild.Y - 2];
                        }
                        else if (cellToBuild == this[cell.X, cell.Y + 1])
                        {
                            cellsNeib[0] = this[cellToBuild.X - 1, cellToBuild.Y + 1];
                            cellsNeib[1] = this[cellToBuild.X + 1, cellToBuild.Y + 1];
                            cellsNeib[2] = this[cellToBuild.X - 1, cellToBuild.Y + 2];
                            cellsNeib[3] = this[cellToBuild.X, cellToBuild.Y + 2];
                            cellsNeib[4] = this[cellToBuild.X + 1, cellToBuild.Y + 2];
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
                        if(noNeib)
                        {
                            cellsToBuildWall.Add(cellToBuild);
                        }
                    }
                }
                
                

                if (cellsToBuildWall.Count==0)
                {
                    wallsStack.Pop();
                }
                else
                {
                    int indToBuild = rnd.Next(0, cellsToBuildWall.Count);
                    BaseCell newCell = cellsToBuildWall[indToBuild];

                    this[newCell.X, newCell.Y] = new Wall(newCell.X, newCell.Y);
                    wallsStack.Push(this[newCell.X, newCell.Y]);
                }
                
            }
            for (int x = 0; x < Width; x++)
            {
                if(this[x,0]==null)
                {
                    Cells.Add(new Ground(x, 0));
                }
                if (this[x, Height - 1] == null)
                {
                    Cells.Add(new Ground(x, Height - 1));
                }
            }
            for (int y = 0; y < Height; y++)
            {
                if (this[0, y] == null)
                {
                    Cells.Add(new Ground(0, y));
                }
                if (this[Width-1, y] == null)
                {
                    Cells.Add(new Ground(Width - 1, y));
                }
            }
        }

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


        public void TryToStep(Direction direction)
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
