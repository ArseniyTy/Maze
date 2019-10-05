using System;
using MazeLibrary;

/*TODO
 * 1) Туман войны не проходит сквозь стены
 * 2) Генерация лабиринта всё же странноватая
*/

namespace MazeDrawer
{
    class Program
    {
        static void Main()
        {
            var beginInstructions = "1)Press ESC to quit\n2)Press S to set the size of the Maze\n3)Press ENTER to start\n";
            var instructions = "1)Press ESC to quit\n2)Press R to restart\n3)Control your hero with W,A,S,D or arrows\n";
            int mazeWidth = 20, mazeHeight = 20;
            var key = new ConsoleKeyInfo();
            while (true)
            {
                Console.WriteLine(beginInstructions);
                key = Console.ReadKey();
                Console.Clear();
                switch (key.Key)
                {
                    case ConsoleKey.Escape:
                        {
                            Environment.Exit(0);
                            break;
                        }
                    case ConsoleKey.S:
                        {
                            Console.WriteLine("Enter the width:");
                            mazeWidth = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter the height:");
                            mazeHeight = int.Parse(Console.ReadLine());
                            break;
                        }
                    case ConsoleKey.Enter:
                        {
                            Maze maze = new Maze(mazeWidth, mazeHeight);
                            Player.GetPlayer.SetRandomCoordinates(maze);

                            Console.WriteLine(instructions + Drawer.Create(maze));
                            while (key.Key != ConsoleKey.Escape)
                            {
                                key = Console.ReadKey();
                                Console.Clear();
                                switch (key.Key)
                                {
                                    case ConsoleKey.W:
                                    case ConsoleKey.UpArrow:
                                        {
                                            maze.TryToStep(Direction.Up);
                                            break;
                                        }

                                    case ConsoleKey.A:
                                    case ConsoleKey.LeftArrow:
                                        {
                                            maze.TryToStep(Direction.Left);
                                            break;
                                        }

                                    case ConsoleKey.D:
                                    case ConsoleKey.RightArrow:
                                        {
                                            maze.TryToStep(Direction.Right);
                                            break;
                                        }

                                    case ConsoleKey.S:
                                    case ConsoleKey.DownArrow:
                                        {
                                            maze.TryToStep(Direction.Down);
                                            break;
                                        }

                                    case ConsoleKey.R:
                                        {
                                            maze = new Maze(mazeWidth, mazeHeight);
                                            Player.GetPlayer.SetRandomCoordinates(maze);
                                            break;
                                        }
                                }
                                Console.WriteLine(instructions + Drawer.Create(maze));
                            }
                            break;
                        }
                }
                Console.Clear();
            }

        }
    }
}
