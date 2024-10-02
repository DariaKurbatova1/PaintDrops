﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLibrary
{
    public struct Vector
    {

        public float X { get; }
        public float Y { get; }
        public Vector(float x, float y)
        {
            X = x; 
            Y = y; 
        }
        public Vector(Vector v)
        {
            X = v.X;
            Y = v.Y;
        }

    
    }
}
