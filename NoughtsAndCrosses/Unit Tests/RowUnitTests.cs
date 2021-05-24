using NoughtsAndCrosses.Models;
using NUnit.Framework;

namespace UnitTests
{
    public class RowUnitTests
    {
        private Row _row;

        [SetUp]
        public void Setup()
        {
            _row = new Row();
        }

        [Test]
        public void ChoosePointOverMax()
        {
            var result = _row.ChoosePointOnRow(4, 2);

            Assert.AreEqual(0, result);
        }

        [Test]
        public void ChoosePointUnderMin()
        {
            var result = _row.ChoosePointOnRow(0, 2);

            Assert.AreEqual(0, result);
        }

        [Test]
        public void ChoosePointReturnsPoint()
        {
            var result = _row.ChoosePointOnRow(1, 2);

            Assert.AreEqual(1, result);
        }
    }
}
