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
            Circle circle = new Circle(0, 0, 10, colour);
            Assert.AreEqual(0, circle.Center.X);
            Assert.AreEqual(0, circle.Center.Y);
            Assert.AreEqual(10, circle.Radius);
            Assert.AreEqual(colour, circle.Colour);
        }

        [TestMethod]
        public void CalculateVerticesTest()
        {
            Colour colour = new Colour(122, 122, 122);
            Circle circle = new Circle(0, 0, 10, colour);
            var expectedVertices = new Vector[100];
            const float PI = (float)Math.PI;

            // Calculate expected vertices
            for (int i = 0; i < 100; i++)
            {
                float theta_i = (2 * PI / 100) * i;
                float x_i = 10 * (float)Math.Cos(theta_i);
                float y_i = 10 * (float)Math.Sin(theta_i);
                expectedVertices[i] = new Vector(x_i, y_i);
            }

            var vertices = circle.Vertices;

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
            Circle circle = new Circle(0, 0, 10, colour);
            Assert.AreEqual(colour, circle.Colour);
        }
    }
}
