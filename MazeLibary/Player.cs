using System;
using System.Collections.Generic;
using System.Text;
using MazeLibrary.Cells;
using MazeLibrary.Interfaces;

namespace MazeLibrary
{
    public class Player : BaseCell
    {
        #region Singleton
        private static Player _player;
        public static Player GetPlayer
        {
            get
            {
                return _player ?? (_player = new Player());
            }
        }

        private Player() : base(0,0, '@') { }
        #endregion

        public void SetRandomCoordinates(Maze maze)
        {
            var posList = new List<ICoordinates>();
            for (int i = 0; i < maze.Height; i++)
            {
                for (int j = 0; j < maze.Width; j++)
                {
                    if(maze[j,i].TryToStep())
                    {
                        posList.Add(maze[j, i]);
                    }
                }
            }
            Random rnd = new Random();
            int ind = rnd.Next(0, posList.Count);
            _player.X = posList[ind].X;
            _player.Y = posList[ind].Y;
        }

        public override bool TryToStep()
        {
            throw new Exception("Its not allowed");
        }
    }
}
