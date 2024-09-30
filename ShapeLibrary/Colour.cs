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
            return new Colour(
                a.Red + b.Red,
                a.Green + b.Green,
                a.Blue + b.Blue);
        }
        public static Colour operator -(Colour a, Colour b)
        {
            return new Colour(
                a.Red - b.Red,
                a.Green - b.Green,
                a.Blue - b.Blue);
        }
        public static Colour operator *(int scale, Colour a)
        {
            return new Colour(
                scale * a.Red,
                scale * a.Green,
                scale * a.Blue
                );
        }

    }
}
