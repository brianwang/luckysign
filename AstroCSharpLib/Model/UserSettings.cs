using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AstroCSharpLib.Model
{
    public class UserSettings
    {
        public bool fProgress;
        public bool fSolarArc;
        public bool fSidereal;
        public bool fGeodetic;
        public bool fPlacalc;

        public bool fTrueNode;    /* -Yn */
        public bool fHouseAngle;  /* -Yc */
        public bool fUranian;     /* -u */
        public bool fVelocity;    /* -v0 */
        public bool fEquator;     /* -sr */
       
        public bool fDecan;       /* -3 */
        public bool fFlip;        /* -f */
        public bool fNavamsa;     /* -9 */

        public int objCenter;    /* -h */
        public int nStar;        /* -U */
        public int nHarmonic;    /* Harmonic chart value passed to -x switch.     */
        public int objOnAsc;     /* House value passed to -1 or -2 switch.        */

        public int nHouseSystem; /* -c */

        public double rZodiacOffset;   /* Position shifting value passed to -s switch.  */
        public double rProgDay;        /* Progression day value passed to -pd switch.   */
        public int nArabicNight;    /* -YP */
    }
}
