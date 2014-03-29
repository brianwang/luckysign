using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AstroCSharpLib.Model
{
    public class ChartPositions
    {
        public double[] obj;   /* The zodiac positions.    */
        public double[] alt;   /* Ecliptic declination.    */
        public double[] dir;   /* Retrogradation velocity. */
        public double[] cusp; /* House cusp positions.    */
        public byte[] house; /* House each object is in. */

        public ChartPositions()
        {
            obj = new double[CALC.objMax];
            alt = new double[CALC.objMax];
            dir = new double[CALC.objMax];
            cusp = new double[CALC.cSign + 1];
            house = new byte[CALC.objMax];
        }
    }
}
