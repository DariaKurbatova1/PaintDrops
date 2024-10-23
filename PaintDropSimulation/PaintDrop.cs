using ShapeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintDropSimulation
{
    public class PaintDrop : IPaintDrop
    {
        public ICircle Circle { get; set; }
        public PaintDrop(ICircle circle)
        {
            Circle = circle;
        }

        public void Marble(IPaintDrop other)
        {
            //apply the algorithm to all vertices
            var otherCenter = other.Circle.Center;
            var otherRadius = other.Circle.Radius;
            int index = 0;
            foreach (var vertice in Circle.Vertices)
            {
                var squareRadius = (otherRadius * otherRadius);
                var magnitude = Vector.magnitude(vertice - otherCenter);
                var squareRoot = Math.Sqrt(1 + (squareRadius / (magnitude * magnitude)));
                var newVertice = otherCenter + ((float)squareRoot * (vertice - otherCenter));
                Circle.Vertices[index] = newVertice;
                index++;
            }
        }

    }
}
