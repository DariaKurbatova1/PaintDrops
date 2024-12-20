﻿using PaintDropSimulation;
using ShapeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternGenerationLib
{
    public class PhyllotaxisPatternGeneration : IPatternGenerator
    {
        public const double GOLDEN_ANGLE = 137.5;
        public double A = Math.PI / 180 * GOLDEN_ANGLE;
        public int C = 10; //scaling factor c
        public int N = 1000; //number of points to place
        public int Index = 0;
        public Vector? CalculatePatternPoint(ISurface surface)
        {
            if(Index < N)
            {
                //get center of surface
                int xs = surface.Width / 2;
                int ys = surface.Height / 2;
                //calculate one point
                double ri = C * Math.Sqrt(Index);
                double theta_i = Index * A;
                double xi = xs + ri * Math.Cos(theta_i);
                double yi = ys + ri * Math.Sin(theta_i);
                Index++;
                return new Vector((float)xi, (float)yi);
            }
            return null;
        }
    }
}
