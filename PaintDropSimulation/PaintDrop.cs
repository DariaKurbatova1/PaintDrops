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
        public ICircle Circle { get; }
        public PaintDrop(ICircle circle)
        {
            Circle = circle;
        }

        public void Marble(IPaintDrop other)
        {
            Vector[] newVertices = new Vector[Circle.Vertices.Length];
            //apply the algorithm to all vertices
            var otherCenter = other.Circle.Center;
            var otherRadius = other.Circle.Radius;
            int index = 0;
            foreach (var vertice in Circle.Vertices)
            {
                var squareRoot = Math.Sqrt(1 + (otherRadius * otherRadius) / (Vector.magnitude(vertice - otherCenter)));
                var newVertice = otherCenter + (float)squareRoot * (vertice - otherCenter);
                newVertices[index] = newVertice;
                index++;
            }
        }

    }
}
