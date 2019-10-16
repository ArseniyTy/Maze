using System;
using System.Collections.Generic;
using System.Text;
using MazeLibrary;

namespace MazeDrawer
{
    /// <summary>
    /// Static class that contains methods to draw a maze.
    /// </summary>
    public static class Drawer
    {
        /// <summary>
        /// Drawes maze in console.
        /// </summary>
        /// <param name="maze">Our current maze</param>
        /// <returns></returns>
        public static string Create(Maze maze)
        {
            var mazeStr = new StringBuilder((maze.Width+2)*maze.Height);

            var hero = Player.GetPlayer;

            for (var i = 0; i < maze.Width + 2; i++)
            {
                mazeStr.Append("-");
            }

            for (var i = 0; i < maze.Height; i++)
            {
                mazeStr.AppendLine();
                mazeStr.Append("|");

                for (var j = 0; j < maze.Width; j++)
                {
                    if (hero.X == j && hero.Y == i)
                    {
                        mazeStr.Append(hero.Skin);
                    }
                    else
                    {
                        if(Math.Abs(hero.X-j)<4 && Math.Abs(hero.Y - i) < 4)
                        {
                            mazeStr.Append(maze[j, i].Skin);
                        }
                        else
                        {//!!!!!!!!!!!!uncomment to see all the maze!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                            //mazeStr.Append(maze[j, i].Skin);
                            mazeStr.Append('~');
                        }
                    }
                }
                mazeStr.Append("|");
            }

            mazeStr.AppendLine();
            for (var i = 0; i < maze.Width+2; i++)
            {
                mazeStr.Append("-");
            }

            return mazeStr.ToString();
        }
    }
}
