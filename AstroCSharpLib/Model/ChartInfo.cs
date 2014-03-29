using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AstroCSharpLib.Model
{
    public class ChartInfo
    {
        public int mon;   /* Month            */
        public int day;   /* Day              */
        public int yea;   /* Year             */
        public double tim;  /* Time in hours    */
        public double dst;  /* Daylight offset  */
        public double zon;  /* Time zone        */
        public double lon;  /* Longitude        */
        public double lat;  /* Latitude         */
        public string nam; /* Name for chart   */
        public string loc; /* Name of location */
    }
}
