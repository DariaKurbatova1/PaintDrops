﻿using ShapeLibrary;
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
        }
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
            
            foreach (PaintDrop item in Drops)
            {
                item.Marble(drop);
            }
            Drops.Add(drop);
        }
    }
}
