﻿using ShapeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
[assembly: InternalsVisibleTo("PaintDrop")]
namespace PaintDropSimulation
{
    
    internal class PaintDropSimulation
    {
        public PaintDropSimulation() {

        }
        public Surface surface { get; }
        public ISurface createSurface(int width, int height)
        {
            return new Surface(width, height);
        }
        public IPaintDrop paintDrop { get; set; }
        public IPaintDrop createPaintDrop(Circle circle)
        {
            return new PaintDrop(circle);
        }
        
    }
}
