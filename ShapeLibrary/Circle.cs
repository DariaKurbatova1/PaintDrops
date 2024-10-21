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
        private Vector _center;
        private float _radius;
        private Colour _colour;

        public Circle(float x, float y, float radius, Colour colour)
        {
            _center = new Vector(x, y);
            _radius = radius;
            _colour = colour;
        }
        public float Radius => _radius;

        public Vector Center => _center;

        public Vector[] Vertices => calculateVertices();

        public Colour Colour => _colour;

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
                x_i = _center.X + (_radius * (float)Math.Cos((double)theta_i));
                y_i = _center.Y + (_radius * (float)Math.Sin((double)theta_i));
                vertices[i] = new Vector(x_i, y_i);
            }
            return vertices;
        }
    }
}
