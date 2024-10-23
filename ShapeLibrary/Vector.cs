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
        /// <summary>
        /// Returns a double representing the magnitude of the vector
        /// </summary>
        public static double Magnitude(Vector v)
        {
            return Math.Sqrt((v.X * v.X) + (v.Y * v.Y));
        }
        /// <summary>
        /// Returns the normalized version of the vector
        /// </summary>
        public static Vector Normalize(Vector v)
        {
            return new Vector((float)(v.X / Magnitude(v)), (float)(v.Y / Magnitude(v)));
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
        public static Vector operator *(Vector a, float scalar)
        {
            return new Vector(scalar * a.X, scalar * a.Y);
        }
        public static Vector operator /(Vector a, float scalar)
        {
            if (scalar == 0)
            {
                throw new ArgumentException("Division by 0 is not allowed");
            }
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
        public override String ToString()
        {
            return "("+X+", "+Y+")";
        }



    }
}
