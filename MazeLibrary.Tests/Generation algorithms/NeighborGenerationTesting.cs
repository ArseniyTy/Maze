using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using MazeLibrary.Generation_algorithms;
using MazeLibrary.Cells;
using MazeLibrary.Interfaces;

namespace MazeLibrary.Tests.Generation_algorithms
{
    class NeighborGenerationTesting
    {
        //[TestCase(-312, -132, TestName = "WrongInput(-312x-132)")]
        //[TestCase(-312, 132, TestName = "WrongInput(-312x132)")]
        //[TestCase(0, 0, TestName = "WrongInput(0x0)")]
        //[TestCase(1, 1, TestName = "1x1")]
        //[TestCase(1, 100, TestName = "1x100")]
        //[TestCase(100, 1, TestName = "100x1")]
        //[TestCase(2, 2, TestName = "2x2")]
        //[TestCase(2, 100, TestName = "2x100")]
        //[TestCase(100, 2, TestName = "100x2")]
        //[TestCase(3, 3, TestName = "3x3")]
        //[TestCase(4, 4, TestName = "4x4")]
        //[TestCase(5, 5, algorithms[0], TestName = "5x5")]
        //[TestCase(5, 51, TestName = "5x50")]
        //[TestCase(51, 5, TestName = "50x5")]
        //[TestCase(10,10, TestName = "10x10")]
        //[TestCase(17, 13, TestName = "20x20")]
        //[TestCase(14, 13, TestName = "20x20")]
        //[TestCase(20, 20, TestName = "20x20")]
        //[TestCase(21, 21, TestName = "20x20")]
        //[TestCase(40, 40, TestName = "40x40")]
        //[TestCase(100, 100, TestName = "100x100]
        [TestCaseSource("Generate")]
        public void CheckingIfYouCanMoveFromAnyGroundOfTheMazeToAnyOtherGroundOfTheMaze(/*int width, int height, IGeneration algo*/TestingMazeConstructor ts)
        {
            var _maze = new Maze(ts.height, ts.width, ts.generation);
            var neighbs = new List<Ground>();
            var ground = _maze[0,0];
            while (!(ground is Ground))
            {
                Random random = new Random();
                int randY = random.Next(0, ts.height);
                int randX = random.Next(0, ts.height);
                ground = _maze[randX, randY];
            }
            neighbs.Add((Ground)ground); //ничего не потеряем, т.к. ground 100 пудов объект класса Ground


            //будем добавлять соседей клеток в общий список
            //делаем это пока не закончатся все клетки
            int k = 0;
            while(k< neighbs.Count)
            {
                ground = neighbs[k];
                IList<IBaseCell> neibghsOfGr = new List<IBaseCell> { _maze[ground.X - 1, ground.Y], _maze[ground.X + 1, ground.Y], _maze[ground.X, ground.Y - 1], _maze[ground.X, ground.Y + 1] };
                foreach(var ne in neibghsOfGr)
                {
                    if(ne is Ground)
                    {
                        if(!ItemIsInList(neighbs, (Ground)ne))
                        {
                            neighbs.Add((Ground)ne);
                        }
                    }
                }
                k++;
            }
            //теперь у нас в neighbs содержатся все доступные
            //для проходов из одной точки в другую клетки


            //смотрим являются ли все Ground-ы в лабиринте доступными для хода
            for (int i = 0; i < ts.width; i++)
            {
                for (int j = 0; j < ts.height; j++)
                {
                    if (_maze[i,j] is Ground)
                    {
                        Assert.IsTrue(ItemIsInList(neighbs, (Ground)_maze[i, j]));
                    }
                }
            }

        }
        private bool ItemIsInList(List<Ground> items, Ground item)
        {
            foreach(var it in items)
            {
                if (it == item)
                    return true;
            }
            return false;
        }


        #region TestCasesWithATestSource
        static IEnumerable<TestingMazeConstructor> Generate()
        {
            for (int i = 0; i < 50; i++)
            {
                yield return new TestingMazeConstructor
                {
                    height = i,
                    width = i,
                    generation = new NeighborGeneration()
                };
            }
        }
        public class TestingMazeConstructor
        {
            public int height, width;
            public IGeneration generation;
        }
        #endregion
    }
}
