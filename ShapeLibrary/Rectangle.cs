using ShapeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLibrary
{
    public class Rectangle : IRectangle
    {
        private float _x;
        private float _y;
        private float _width;
        private float _height;
        private Colour _colour;

        public Rectangle(float x, float y, float width, float height, Colour colour)
        {
            _x = x;
            _y = y;
            _width = width;
            _height = height;
            _colour = colour;
        }

        public float X => _x;

        public float Y => _y;

        public float Width => _width;

        public float Height => _height;

        public Vector[] Vertices => CalculateVertices();

        public Colour Colour =>  _colour;

        private Vector[] CalculateVertices()
        {
            return new Vector[]
            {
                new Vector(_x, _y),
                new Vector(_x + _width, _y),
                new Vector(_x + _width, _y + _height),
                new Vector(_x, _y + _height)
            };
        }
    }
}
