using ShapeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintDropSimulation
{
    public class Surface : ISurface
    {

        public Surface(int width, int height) {

            Width = width;
            Height = height;
            Drops = new List<IPaintDrop>();
            surfaceBorder = new Rectangle(0, 0, Width, Height, new Colour(4, 4, 4));
        }
        public IRectangle surfaceBorder { get; private set; }
        public event CalculatePatternPoint PatternGeneration;
        public int Width { get; }

        public int Height { get; }
        public Vector posisition = new Vector();

        public List<IPaintDrop> Drops { get; }
        public void GeneratePaintDropPattern(float radius, Colour colour)
        {
            
            Vector? position = PatternGeneration?.Invoke(this);
            if (position.HasValue)
            {
                AddPaintDrop(new PaintDrop(new Circle(position.Value.X, position.Value.Y, radius, colour)));

            }
        }

        public void AddPaintDrop(IPaintDrop drop)
        {
            //List<IPaintDrop> marbled = new List<IPaintDrop>();
            //remove paintdrops outside of surface border




            /*foreach (PaintDrop item in Drops)
            {
                item.Marble(drop);
                if (item.BoundingBox.Intersect(surfaceBorder))
                {
                    Drops.Remove(item);
                }
            }*//*
            Parallel.For(0, Drops.Count, i =>
            {
                drop.Marble(Drops[i]);

            });*/

            for (int i = 0; i < Drops.Count; i++)
            {
                drop.Marble(Drops[i]);
                if (Drops[i].BoundingBox.Intersect(surfaceBorder))
                {
                    Drops.RemoveAt(i);
                }
            }
            Drops.Add(drop);
        }
    }
}
