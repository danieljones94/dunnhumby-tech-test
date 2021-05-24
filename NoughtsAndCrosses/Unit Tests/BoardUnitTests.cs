using NoughtsAndCrosses.Models;
using NUnit.Framework;

namespace UnitTests
{
    public class BoardUnitTests
    {
        private Board _board;

        [SetUp]
        public void Setup()
        {
            _board = new Board();
        }

        [Test]
        public void GetBoard()
        {
            //Act
            _board.GetBoard();

            //Assert
            Assert.AreEqual(3, _board.rows.Length);
        }

        [Test]
        public void ChooseRowOverMax()
        {
            //Act 
            int result = _board.ChooseRow("4");

            //Assert 
            Assert.AreEqual(0, result);
        }

        [Test]
        public void ChooseRowUnderMin()
        {
            //Act 
            int result = _board.ChooseRow("0");

            //Assert 
            Assert.AreEqual(0, result);
        }

        [Test]
        public void ChooseInvalidCharachter()
        {
            int result = _board.ChooseRow("t");

            Assert.AreEqual(0, result);
        }
    }
}
