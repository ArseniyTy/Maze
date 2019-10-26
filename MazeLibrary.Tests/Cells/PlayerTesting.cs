using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using MazeLibrary.Cells;

namespace MazeLibrary.Tests.Cells
{
    class PlayerTesting
    {
        //private vars (initialized in SetUp())
        private Player _player;


        [SetUp]
        public void SetUp()
        {
            _player = Player.GetPlayer;
        }


        //название полностью отражает то, что мы проверяем(хоть до 200 символов может быть)
        [Test]
        public void CheckingTryToStepOnHimself()
        {
            Assert.Throws<Exception>(() => _player.TryToStep());
        }

        [Test]
        public void CanTwoPlayersBeAdded()
        {
            Player player = Player.GetPlayer;
            Assert.AreSame(_player, player);
        }

        /*
        [Test]
        public void CheckingIfSettingRandomCoordinatesToPlayerIsCorrect()
        {
            
        }
        */

        //Из любой одной точки можно придти в другую(поиск в ширину)
        //test cases загуглить
    }
}
