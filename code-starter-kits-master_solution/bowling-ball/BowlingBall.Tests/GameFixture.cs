using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingBall.Tests
{
    [TestClass]
    public class GameFixture
    {
        private Game gameInstance;

        [TestInitialize]
        public void SetUp()
        {
            gameInstance = new Game();
        }
        [TestMethod]
        public void Gutter_game_score_should_be_zero_test()
        {
            gameInstance = new Game();
            Roll(gameInstance, 0, 20);
            Assert.AreEqual(0, gameInstance.GetScore());
        }

        private void Roll(Game game, int pins, int times)
        {
            for (int i = 0; i < times; i++)
            {
                game.Roll(pins);
            }
        }
        [TestMethod]
        public void TestSpare()
        {

            gameInstance.Roll(5);
            gameInstance.Roll(5);
            gameInstance.Roll(4);
            Roll(gameInstance, 0, 17);
            Assert.AreEqual(18, gameInstance.GetScore());
        }

        [TestMethod]
        public void TestAllOne()
        {
            Roll(gameInstance, 1, 20);
            Assert.AreEqual(20, gameInstance.GetScore());
        }

        [TestMethod]
        public void TestStrike()
        {
            gameInstance.Roll(10);
            gameInstance.Roll(5);
            gameInstance.Roll(4);
            Roll(gameInstance, 0, 17);
            Assert.AreEqual(28, gameInstance.GetScore());
        }

        [TestMethod]
        public void TestAllStrike()
        {
            
            Roll(gameInstance, 10, 21);
            Assert.AreEqual(300, gameInstance.GetScore());
        }

        [TestMethod]
        public void TestAllSpare()
        {

            Roll(gameInstance, 5, 21);
            Assert.AreEqual(150, gameInstance.GetScore());
        }

    }
}
