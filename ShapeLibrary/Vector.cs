using System;
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
        public static double magnitude(Vector v)
        {
            return Math.Sqrt((v.X * v.X) + (v.Y * v.Y));
        }
        public static Vector normalize(Vector v)
        {
            return new Vector((float)(v.X / magnitude(v)), (float)(v.Y / magnitude(v)));
        }
        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.X + b.X, a.Y + b.Y);
        }
        public static Vector operator -(Vector a, Vector b)
        {
            return new Vector(a.X - b.X, a.Y - b.Y);
        }
        public static Vector operator *(float scalar, Vector a)
        {
            return new Vector(scalar *  a.X, scalar * a.Y);
        }
        public static Vector operator /(float scalar, Vector a)
        {
            return new Vector(a.X / scalar, a.Y / scalar); 
        }
        public static bool operator ==(Vector a, Vector b)
        {
            return (a.X == b.X) && (a.Y == b.Y);
        }
        public static bool operator !=(Vector a, Vector b)
        {
            if (a.X != b.X || a.Y != b.Y) {  return true; }
            return false;
        }



    }
}
