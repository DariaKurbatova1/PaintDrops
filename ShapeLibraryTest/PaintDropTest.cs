using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaintDropSimulation;
using ShapeLibrary;

namespace ShapeLibraryTest
{
    [TestClass]
    internal class PaintDropTest
    {
        [TestMethod]
        public void marbleTest()
        {
            Colour colour = new Colour(2, 2, 2);
            var c2 = new Circle(280, 200, 50, colour);
            var c1 = new Circle(10, 10, 10, colour);
            var p1 = new PaintDrop(c1);
            var p2 = new PaintDrop(c2);
            p1.Marble(p2);


        }
    }
}
