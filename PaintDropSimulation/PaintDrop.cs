using ShapeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace PaintDropSimulation
{
    public class PaintDrop : IPaintDrop
    {
        public ICircle Circle { get; set; }
        public IRectangle BoudingBox { get;  private set; }
        public PaintDrop(ICircle circle)
        {
            Circle = circle;
            BoudingBox = CalculateBoundingBox();
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
                var magnitude = Vector.Magnitude(vertice - otherCenter);
                var squareRoot = Math.Sqrt(1 + (squareRadius / (magnitude * magnitude)));
                var newVertice = otherCenter + ((float)squareRoot * (vertice - otherCenter));
                Circle.Vertices[index] = newVertice;
                index++;
            }
            //reset bounding box
            BoudingBox = CalculateBoundingBox();
        }
        public IRectangle CalculateBoundingBox()
        {
            //verticles.min(value => vlaue.x)
            //top left corner
            float minX = Circle.Vertices.Min(value => value.X);
            float minY = Circle.Vertices.Min(value => value.Y);

            float maxX = Circle.Vertices.Max(value => value.X);
            float maxY = Circle.Vertices.Max(value => value.Y);

            float width = maxX - minX;
            float height = maxY - minY;

            Colour colour = new Colour(4, 4, 4);
            return new Rectangle(minX, minY, width, height, colour);

        }

    }
}
