using NoughtsAndCrosses.Models;
using NUnit.Framework;

namespace UnitTests
{
    public class GameUnitTests
    {
        public static Game _game;

        [SetUp]
        public void Setup()
        {
            _game = new Game();
        }

        [Test]
        public void NewGameResetsConditions()
        {
            //Act 
            _game.NewGame();

            //Assert
            Assert.AreEqual(_game.turns, 0);
            Assert.AreEqual(_game.player1, "");
            Assert.AreEqual(_game.player2, "");
            Assert.AreEqual(_game.player1Turn, true);
        }

        [Test]
        public void ChecksIfWonHorizonally()
        {
            //Act
            Board board = new Board();
            int[] array = new int[] { 1, 2, 3 };

            for (int i = 0; i < 1; i++)
            {
                board.rows[i].points = array;
            }

            //Assert 
            Assert.AreEqual(true, _game.HasWon());

        }

        [Test]
        public void ChecksIfWonVertically()
        {
            //Act
            Board board = new Board();
            int[] array = new int[] { 1, 0, 0 };

            for (int i = 0; i < 3; i++)
            {
                board.rows[i].points = array;
            }

            //Assert 
            Assert.AreEqual(true, _game.HasWon());

        }

        [Test]
        public void ChecksIfWonDiagonally()
        {
            //Act
            Board board = new Board();
            int[,] grid = new int[,] { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } };

            for (int i = 0; i < 3; i++)
            {
                board.rows[i].points[i] = grid[i, i];
            }

            //Assert 
            Assert.AreEqual(true, _game.HasWon());

        }
    }
}