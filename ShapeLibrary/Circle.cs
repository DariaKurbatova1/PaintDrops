using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLibrary
{
    public class Circle : ICircle
    {
        private float _x;
        private float _y;
        private float _radius;
        private Colour _colour;

        public Circle(float x, float y, float radius, Colour colour)
        {
            _x = x;
            _y = y;
            _radius = radius;
            _colour = colour;
        }
        public float Radius => throw new NotImplementedException();

        public Vector Center => throw new NotImplementedException();

        public Vector[] Vertices => throw new NotImplementedException();

        public Colour Colour => throw new NotImplementedException();
    }
}
