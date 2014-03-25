using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AstroCSharpLib.Model
{
    public class OrbitalElements
    {
        public double ma0, ma1, ma2; /* Mean anomaly.           */
        public double ec0, ec1, ec2; /* Eccentricity.           */
        public double sma;           /* Semi-major axis.        */
        public double ap0, ap1, ap2; /* Argument of perihelion. */
        public double an0, an1, an2; /* Ascending node.         */
        public double in0, in1, in2; /* Inclination.            */
    }
}
