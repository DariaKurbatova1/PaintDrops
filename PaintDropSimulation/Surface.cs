using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintDropSimulation
{
    internal class Surface : ISurface
    {
        public int Width => throw new NotImplementedException();

        public int Height => throw new NotImplementedException();

        public List<IPaintDrop> Drops => throw new NotImplementedException();

        public void AddPaintDrop(IPaintDrop drop)
        {
            throw new NotImplementedException();
        }
    }
}
