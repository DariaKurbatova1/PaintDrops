using ShapeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLibraryTest
{
    [TestClass]
    public class CircleTest
    {

        [TestMethod]
        public void InitializesCorrectly()
        {
            Colour colour = new Colour(122, 122, 122);
            Rectangle rectangle = new Rectangle(0, 0, 10, 5, colour);
            Assert.AreEqual(0, rectangle.X);
            Assert.AreEqual(0, rectangle.Y);
            Assert.AreEqual(10, rectangle.Width);
            Assert.AreEqual(5, rectangle.Height);
            Assert.AreEqual(colour, rectangle.Colour);
        }

        [TestMethod]
        public void CalculateVerticesTest()
        {
            Colour colour = new Colour(122, 122, 122);
            Rectangle rectangle = new Rectangle(0, 0, 10, 5, colour);
            var expectedVertices = new Vector[]
            {
                new Vector(0, 0),
                new Vector(10, 0),
                new Vector(10, 5),
                new Vector(0, 5)
            };

            var vertices = rectangle.Vertices;

            Assert.AreEqual(expectedVertices.Length, vertices.Length);
            for (int i = 0; i < expectedVertices.Length; i++)
            {
                Assert.AreEqual(expectedVertices[i], vertices[i]);
            }
        }

        [TestMethod]
        public void ColourPropertyTest()
        {
            Colour colour = new Colour(122, 122, 122);
            Rectangle rectangle = new Rectangle(0, 0, 10, 5, colour);
            Assert.AreEqual(colour, rectangle.Colour);
        }
    }
}
