using System;
using MazeLibrary;
using MazeLibrary.Generation_algorithms;
using MazeLibrary.Interfaces;

namespace MazeDrawer
{
    class Program
    {
        static void Main()
        {
            var beginInstructions = "1)Press ESC to quit\n2)Press S to set the size of the Maze\n3)Press Q to set generation algorithm\n4)Press ENTER to start\n";
            var genAlgoInstructions = "1)Press A to set NeighborGeneration algorithm\n2)Press B to set SillyGeneration algorithm";
            var instructions = "1)Press ESC to quit\n2)Press R to restart\n3)Control your hero with W,A,S,D or arrows\n";
            int mazeWidth = 20, mazeHeight = 20;
            IGeneration generator=null;
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
                    case ConsoleKey.Q:
                        {
                            Console.WriteLine(genAlgoInstructions);
                            key = Console.ReadKey();
                            switch (key.Key)
                            {
                                case ConsoleKey.A:
                                    {
                                        generator = new NeighborGeneration();
                                        break;
                                    }
                                case ConsoleKey.B:
                                    {
                                        generator = new SillyGeneration();
                                        break;
                                    }
                            }
                            break;
                        }
                    case ConsoleKey.Enter:
                        {
                            Maze maze = new Maze(mazeHeight, mazeWidth, generator);
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
                                            maze.TryToMove(Direction.Up);
                                            break;
                                        }

                                    case ConsoleKey.A:
                                    case ConsoleKey.LeftArrow:
                                        {
                                            maze.TryToMove(Direction.Left);
                                            break;
                                        }

                                    case ConsoleKey.D:
                                    case ConsoleKey.RightArrow:
                                        {
                                            maze.TryToMove(Direction.Right);
                                            break;
                                        }

                                    case ConsoleKey.S:
                                    case ConsoleKey.DownArrow:
                                        {
                                            maze.TryToMove(Direction.Down);
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
