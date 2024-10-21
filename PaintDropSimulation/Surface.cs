using ShapeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintDropSimulation
{
    internal class Surface : ISurface
    {
        public Surface(int width, int height) {
            Width = width;
            Height = height;
        }
        public int Width { get; }

        public int Height { get; }

        public List<IPaintDrop> Drops { get; set; }

        public void AddPaintDrop(IPaintDrop drop)
        {
            List<IPaintDrop> marbled = new List<IPaintDrop>();
            foreach (PaintDrop item in Drops)
            {
                item.Marble(drop);
                marbled.Add(item);
            }
            Drops = marbled;
        }
    }
}
