using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLibrary
{
    public struct Colour
    {
        private int _red;
        public int Red { get { return _red; } }
        private int _greeen;
        public int Green {  get { return _greeen; } }
        private int _blue;
        public int Blue { get { return _blue; } }
        public Colour(int red, int green, int blue)
        {
            _red = red;
            _greeen = green;
            _blue = blue;
        }
        public static Colour operator +(Colour a, Colour b)
        {

            int red = a.Red + b.Red;
            int green = a.Green + b.Green;
            int blue = a.Blue + b.Blue;

            if (red > 255) { red = 255; }
            if (green > 255) { green = 255; }
            if (blue > 255) { blue = 255; }
            return new Colour(red, green, blue);
        }
        public static Colour operator -(Colour a, Colour b)
        {
            int red = a.Red - b.Red;
            int green = a.Green - b.Green;
            int blue = a.Blue - b.Blue;
            if (red < 0) { red = 0; }
            if (green < 0) { green = 0; }
            if (blue < 0) { blue = 0; }
            return new Colour(red, green, blue);
        }
        public static Colour operator *(int multiplier, Colour a)
        {
            int red = multiplier * a.Red;
            int green = multiplier * a.Green;
            int blue = multiplier * a.Blue;
            if (red > 255) { red = 255; }
            if (green > 255) { green = 255; }
            if (blue > 255) { blue = 255; }
            if (red < 0) { red = 0; }
            if (green < 0) { green = 0; }
            if (blue < 0) { blue = 0; }
            return new Colour(red, green, blue);
        }
        public static bool operator ==(Colour a, Colour b)
        {
            return (a.Red == b.Red) && (a.Green == b.Green) && (a.Blue == b.Blue);
        }
        public static bool operator !=(Colour a, Colour b) {
            return (a.Red != b.Red) || (a.Green != b.Green) || (a.Blue != b.Blue);
        }
        public override string ToString()
        {
            return ("Red: " + Red + ", Green: " + Green + ", Blue: " + Blue);
        }

    }
}
