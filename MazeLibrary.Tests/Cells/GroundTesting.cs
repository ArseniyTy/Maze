using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using MazeLibrary.Cells;

namespace MazeLibrary.Tests.Cells
{
    class GroundTesting
    {
        //private vars (initialized in SetUp())
        private Ground _ground;


        [SetUp]
        public void SetUp()
        {
            _ground = new Ground(0, 0);
        }
        

        //название полностью отражает то, что мы проверяем(хоть до 200 символов может быть)
        [Test]
        public void CheckingTryToStep()
        {
            Assert.IsTrue(_ground.TryToStep());
        }
    }
}
