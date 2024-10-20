using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLibrary
{
    public static class ShapeFactory
    {
        public static ICircle CreateCircle()
        {
            Colour colour = new Colour(120, 120, 120);
            return new Circle(4, 4, 2, colour);
        }
        public static IRectangle CreateRectangle()
        {
            Colour colour = new Colour(120, 120, 120);
            return new Rectangle(2, 2, 4, 3, colour);
        }
    }
}
