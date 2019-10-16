using System;
using System.Collections.Generic;
using System.Text;
using MazeLibrary.Cells;
using MazeLibrary.Interfaces;

namespace MazeLibrary
{
    /// <summary>
    /// Contains info about <c>Player</c> (who is actually the cell).
    /// <para>Inherits from <c>BaseCell</c>.</para>
    /// </summary>
    public class Player : BaseCell
    {
        #region Singleton
        private static Player _player;
        /// <summary>
        /// Returns the player, or creates it, if the method was called the 1st time.
        /// <para>Singleton pattern</para>
        /// </summary>
        public static Player GetPlayer
        {
            get
            {
                return _player ?? (_player = new Player());
            }
        }

        private Player() : base(0,0, '@') { }
        #endregion

        /// <summary>
        /// Moves player to a random place in the maze.
        /// </summary>
        /// <param name="maze">Our current maze</param>
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

        /// <summary>
        /// Always throws exception, because we can't step on the cell where we are now.
        /// </summary>
        /// <returns>always returns exception.</returns>
        /// <exception cref="Exception">Always throws this exception.</exception>
        public override bool TryToStep()
        {
            throw new Exception("Its not allowed");
        }
    }
}
