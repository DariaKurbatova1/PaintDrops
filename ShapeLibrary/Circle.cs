using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLibrary
{
    public class Circle : ICircle
    {
        public Vector Center { get; }
        public float Radius { get; }
        public Colour Colour { get; }


        public Circle(float x, float y, float radius, Colour colour)
        {
            if (radius <= 0)
            {
                throw new ArgumentException("Radius must be a positive value bigger than 0");
            }
            Center = new Vector(x, y);
            Radius = radius;
            Colour = colour;
        }

        public Vector[] Vertices => calculateVertices();

        private Vector[] calculateVertices()
        {
            const float PI = (float)Math.PI;
            //preset number of points
            int n = 100;

            //calculate theta i
            

            Vector[] vertices = new Vector[n];
            float theta_i;
            float x_i;
            float y_i;

            for (int i = 0; i < n; i++)
            {
                theta_i = (2 * PI / n)*(i - 1);
                x_i = Center.X + (Radius * (float)Math.Cos((double)theta_i));
                y_i = Center.Y + (Radius * (float)Math.Sin((double)theta_i));
                vertices[i] = new Vector(x_i, y_i);
            }
            return vertices;
        }
    }
}
