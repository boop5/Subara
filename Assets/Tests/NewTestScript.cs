using Assets.Scripts;
using NUnit.Framework;
using UnityEngine;

namespace Assets.Tests
{
    public class NewTestScript
    {
        [Test]
        public void Util_IndexToXPosition()
        {
            var n = 1;
            for (var i = 0; i < Mathf.Pow(GameGrid.Size, 2); i++)
            {
                Assert.AreEqual(Util.IndexToXPosition(i), n);

                if (n++ == 5) n = 1;
            }
        }

        [Test]
        public void Util_IndexToYPosition()
        {
            var n = 1;
            for (var i = 0; i < Mathf.Pow(GameGrid.Size, 2); i++)
            {
                if (Mathf.Max(i, 1) % GameGrid.Size == 0) n++;

                Assert.AreEqual(Util.IndexToYPosition(i), n);
            }
        }

        [Test]
        public void xd()
        {
            Assert.AreEqual(1, Util.IndexToYPosition(0));
            Assert.AreEqual(1, Util.IndexToYPosition(1));
            Assert.AreEqual(1, Util.IndexToYPosition(2));
            Assert.AreEqual(1, Util.IndexToYPosition(3));
            Assert.AreEqual(1, Util.IndexToYPosition(4));
            Assert.AreEqual(2, Util.IndexToYPosition(5));
            Assert.AreEqual(2, Util.IndexToYPosition(6));
            Assert.AreEqual(2, Util.IndexToYPosition(7));
            Assert.AreEqual(2, Util.IndexToYPosition(8));
            Assert.AreEqual(2, Util.IndexToYPosition(9));
            Assert.AreEqual(3, Util.IndexToYPosition(10));
            Assert.AreEqual(3, Util.IndexToYPosition(11));
            Assert.AreEqual(3, Util.IndexToYPosition(12));
            Assert.AreEqual(3, Util.IndexToYPosition(13));
            Assert.AreEqual(3, Util.IndexToYPosition(14));
            Assert.AreEqual(4, Util.IndexToYPosition(15));
            Assert.AreEqual(4, Util.IndexToYPosition(16));
            Assert.AreEqual(4, Util.IndexToYPosition(17));
            Assert.AreEqual(4, Util.IndexToYPosition(18));
            Assert.AreEqual(4, Util.IndexToYPosition(19));
            Assert.AreEqual(5, Util.IndexToYPosition(20));
            Assert.AreEqual(5, Util.IndexToYPosition(21));
            Assert.AreEqual(5, Util.IndexToYPosition(22));
            Assert.AreEqual(5, Util.IndexToYPosition(23));
            Assert.AreEqual(5, Util.IndexToYPosition(24));

            Assert.AreEqual(1, Util.IndexToXPosition(0));
            Assert.AreEqual(2, Util.IndexToXPosition(1));
            Assert.AreEqual(3, Util.IndexToXPosition(2));
            Assert.AreEqual(4, Util.IndexToXPosition(3));
            Assert.AreEqual(5, Util.IndexToXPosition(4));
            Assert.AreEqual(1, Util.IndexToXPosition(5));
            Assert.AreEqual(2, Util.IndexToXPosition(6));
            Assert.AreEqual(3, Util.IndexToXPosition(7));
            Assert.AreEqual(4, Util.IndexToXPosition(8));
            Assert.AreEqual(5, Util.IndexToXPosition(9));
            Assert.AreEqual(1, Util.IndexToXPosition(10));
            Assert.AreEqual(2, Util.IndexToXPosition(11));
            Assert.AreEqual(3, Util.IndexToXPosition(12));
            Assert.AreEqual(4, Util.IndexToXPosition(13));
            Assert.AreEqual(5, Util.IndexToXPosition(14));
            Assert.AreEqual(1, Util.IndexToXPosition(15));
            Assert.AreEqual(2, Util.IndexToXPosition(16));
            Assert.AreEqual(3, Util.IndexToXPosition(17));
            Assert.AreEqual(4, Util.IndexToXPosition(18));
            Assert.AreEqual(5, Util.IndexToXPosition(19));
            Assert.AreEqual(1, Util.IndexToXPosition(20));
            Assert.AreEqual(2, Util.IndexToXPosition(21));
            Assert.AreEqual(3, Util.IndexToXPosition(22));
            Assert.AreEqual(4, Util.IndexToXPosition(23));
            Assert.AreEqual(5, Util.IndexToXPosition(24));

            Assert.AreEqual(new Position(1, 1), Util.IndexToPosition(0));
            Assert.AreEqual(new Position(1, 2), Util.IndexToPosition(1));
            Assert.AreEqual(new Position(1, 3), Util.IndexToPosition(2));
            Assert.AreEqual(new Position(1, 4), Util.IndexToPosition(3));
            Assert.AreEqual(new Position(1, 5), Util.IndexToPosition(4));
            Assert.AreEqual(new Position(2, 1), Util.IndexToPosition(5));
            Assert.AreEqual(new Position(2, 2), Util.IndexToPosition(6));
            Assert.AreEqual(new Position(2, 3), Util.IndexToPosition(7));
            Assert.AreEqual(new Position(2, 4), Util.IndexToPosition(8));
            Assert.AreEqual(new Position(2, 5), Util.IndexToPosition(9));
            Assert.AreEqual(new Position(3, 1), Util.IndexToPosition(10));
            Assert.AreEqual(new Position(3, 2), Util.IndexToPosition(11));
            Assert.AreEqual(new Position(3, 3), Util.IndexToPosition(12));
            Assert.AreEqual(new Position(3, 4), Util.IndexToPosition(13));
            Assert.AreEqual(new Position(3, 5), Util.IndexToPosition(14));
            Assert.AreEqual(new Position(4, 1), Util.IndexToPosition(15));
            Assert.AreEqual(new Position(4, 2), Util.IndexToPosition(16));
            Assert.AreEqual(new Position(4, 3), Util.IndexToPosition(17));
            Assert.AreEqual(new Position(4, 4), Util.IndexToPosition(18));
            Assert.AreEqual(new Position(4, 5), Util.IndexToPosition(19));
            Assert.AreEqual(new Position(5, 1), Util.IndexToPosition(20));
            Assert.AreEqual(new Position(5, 2), Util.IndexToPosition(21));
            Assert.AreEqual(new Position(5, 3), Util.IndexToPosition(22));
            Assert.AreEqual(new Position(5, 4), Util.IndexToPosition(23));
            Assert.AreEqual(new Position(5, 5), Util.IndexToPosition(24));

        }

        [Test]
        public void Position_PlusOperator()
        {
            Assert.AreEqual(new Position(1, 2), new Position(0, 7) + new Position(0, 0));
            Assert.AreEqual(new Position(0, 0), new Position(0, 0) + new Position(0, 0));
            Assert.AreEqual(new Position(1, 0), new Position(1, 0) + new Position(0, 0));
            Assert.AreEqual(new Position(4, 0), new Position(1, 0) + new Position(3, 0));
            Assert.AreEqual(new Position(4, 1), new Position(2, 2) + new Position(1, 4));
        }
    }
}