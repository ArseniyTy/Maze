using System;
using System.Collections.Generic;
using System.Text;
using MazeLibrary;

namespace MazeDrawer
{
    public static class Drawer
    {
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
                        {//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
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
