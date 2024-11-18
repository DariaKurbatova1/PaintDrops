﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
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
        public bool Intersect(IRectangle rectangle)
        {
            rectangle = new Rectangle(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, rectangle.Colour);
            double minX = Math.Min(rectangle.X, X);
            double minY = Math.Min(rectangle.Y, Y);
            double maxX = Math.Max(rectangle.X + rectangle.Width, X + _width);
            double maxY = Math.Max(rectangle.Y + rectangle.Height, Y + _height);
            if (minX < maxX && minY < maxY) return false;
            return true;
        }
    }
}
