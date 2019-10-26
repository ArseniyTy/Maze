using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using MazeLibrary.Cells;

namespace MazeLibrary.Tests.Cells
{
    class WallTesting
    {
        //private vars (initialized in SetUp())
        private Wall _wall;


        [SetUp]
        public void SetUp()
        {
            _wall = new Wall(0, 0);
        }


        //название полностью отражает то, что мы проверяем(хоть до 200 символов может быть)
        [Test]
        public void CheckingTryToStep()
        {
            Assert.IsFalse(_wall.TryToStep());
        }
    }
}
