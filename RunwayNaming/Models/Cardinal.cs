using System;
using System.Collections.Generic;

namespace RunwayNaming.Models
{
    public class Cardinal
    {
        public double N {get; set;}
        public double NE {get; set;}
        public double E {get; set;}
        public double SE {get; set;}
        public double S {get; set;}
        public double SW {get; set;}
        public double W {get; set;}
        public double NW {get; set;}

        private Cardinal()
        {
            N = 360;
            NE = 45;
            E = 90;
            SE = 135;
            S = 180;
            SW = 225;
            W = 270;
            NW = 315;
        }
    }
}