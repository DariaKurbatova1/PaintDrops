using ShapeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLibraryTest
{
    [TestClass]
    public class VectorTest
    {
        [TestMethod]
        public void addVectorTest()
        {
            var v1 = new Vector(2, 3);
            var v2 = new Vector(1, 2);
            var result = v1 + v2;

            Assert.AreEqual(3, result.X);
            Assert.AreEqual(5, result.Y);
        }
        [TestMethod]
        public void SubstractVectorTest()
        {
            var v1 = new Vector(2, 2);
            var v2 = new Vector(1, 3);
            var result = v1 - v2;

            Assert.AreEqual(1, result.X);
            Assert.AreEqual(-1, result.Y);
        }
        [TestMethod]
        public void MultiplyVectorTest()
        {
            var v1 = new Vector(2, 3);
            var result = 2 * v1;

            Assert.AreEqual(4, result.X);
            Assert.AreEqual(6, result.Y);
        }
        [TestMethod]
        public void DivideVectorTest()
        {
            var v1 = new Vector(2, 6);
            var result = v1/2;

            Assert.AreEqual(1, result.X);
            Assert.AreEqual(3, result.Y);
        }
        [TestMethod]
        public void EqualsTest()
        {
            var v1 = new Vector(2, 3);
            var v2 = new Vector(2, 3);
            var v3 = new Vector(0, 0);

            Assert.IsTrue(v1 == v2);
            Assert.IsFalse(v1 == v3);
        }
        [TestMethod]
        public void NotEqualsTest()
        {
            var v1 = new Vector(2, 3);
            var v2 = new Vector(0, 0);

            Assert.IsTrue(v1 != v2);
        }
        [TestMethod]
        public void ToStringTest()
        {
            var v1 = new Vector(2, 3);
            var result = v1.ToString();

            Assert.AreEqual("(2, 3)", result);
        }
    }
}
