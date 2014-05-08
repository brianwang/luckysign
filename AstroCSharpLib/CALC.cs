using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroCSharpLib.Model;

namespace AstroCSharpLib
{
    public partial class CALC
    {
        //
        public const int cSign = 12;
        public const int cObj = 87;
        public const int objMax = (cObj + 1);

        /* Objects */
        public const int oEar = 0;
        public const int oSun = 1;
        public const int oMoo = 2;
        public const int oMer = 3;
        public const int oVen = 4;
        public const int oMar = 5;
        public const int oJup = 6;
        public const int oSat = 7;
        public const int oUra = 8;
        public const int oNep = 9;
        public const int oPlu = 10;
        public const int oChi = 11;
        public const int oCer = 12;
        public const int oVes = 15;
        public const int oNod = 16;
        public const int oLil = 17;
        public const int oSou = 17;
        public const int oFor = 18;
        public const int oVtx = 19;
        public const int oEP = 20;
        public const int oAsc = 21;
        public const int oNad = 24;
        public const int oDes = 27;
        public const int oMC = 30;
        //public const int  oOri= (starLo-1+10);
        //public const int  oAnd =(starLo-1+47);


        /* Zodiac signs */

        public const int sAri = 1;
        public const int sTau = 2;
        public const int sGem = 3;
        public const int sCan = 4;
        public const int sLeo = 5;
        public const int sVir = 6;
        public const int sLib = 7;
        public const int sSco = 8;
        public const int sSag = 9;
        public const int sCap = 10;
        public const int sAqu = 11;
        public const int sPis = 12;

        /* Object array index values */

        public const int cPlanet = oVes;
        public const int cThing = oLil;
        public const int oMain = 10;
        public const int oCore = 20;
        public const int cUran = 8;
        public const int cStar = 47;
        public const int cuspLo = 21;
        public const int cuspHi = 32;
        public const int uranLo = 33;
        public const int uranHi = 40;
        public const int oNorm = uranHi;
        public const int starLo = 41;
        public const int starHi = cObj;


        private InternalSettings iset = new InternalSettings();
        public ChartPositions cp = new ChartPositions();
        private UserSettings us = new UserSettings();
        public ChartInfo ciCore = new ChartInfo { mon = 11, day = 19, yea = 1971, tim = 11.01, dst = 0.0, zon = 8.0, lon = 122.20, lat = 47.36, nam = "", loc = "" };

        private int[] starname = new int[cStar + 1];

        //CI ciMain = {-1, 0, 0, 0.0, 0.0, 0.0, 0.0, 0.0, "", ""};
        //CI ciTwin = {9, 11, 1991, 0.01, 0.0, 0.0, 122.20, 47.36, "", ""};
        //CI ciThre = {-1, 0, 0, 0.0, 0.0, 0.0, 0.0, 0.0, "", ""};
        //CI ciFour = {-1, 0, 0, 0.0, 0.0, 0.0, 0.0, 0.0, "", ""};
        //CI ciTran = {12, 31, 1999, 23.59, 0.0, 0.0, 0.0, 0.0, "", ""};
        //CI ciSave = {12, 21, 1998, 17.57, 0.0, 8.0, 122.20, 47.36, "", ""};



        /* Compute the positions of the planets at a certain time using the Placalc */
        /* accurate formulas and ephemeris. This will supersede the Matrix routine  */
        /* values and is only called with the -b switch is in effect. Not all       */
        /* objects or modes are available using this, but some additional values    */
        /* such as Moon and Node velocities not available without -b are. (This is  */
        /* the one place in Astrolog which calls the Placalc package functions.)    */

        unsafe void ComputePlacalc(double t)
        {
            int i;
            double r1 = 0.0, r2 = 0.0, r3 = 0.0, r4 = 0.0;

            /* We can compute the positions of Sun through Pluto, Chiron, the four */
            /* asteroids, Lilith, and the (true or mean) North Node using Placalc. */
            /* The other objects must be done elsewhere.                           */

            for (i = oSun; i <= oLil; i++)
            {
                //if ((ignore[i] && i > oMoo) ||
                //  (us.fPlacalcAst && FBetween(i, oCer, oVes)))
                //  continue;
                if (FPlacalcPlanet(i, t * 36525.0 + 2415020.0, us.objCenter != oEar,
                  &r1, &r2, &r3, &r4))
                {

                    /* Note that this can't compute charts with central planets other */
                    /* than the Sun or Earth or relative velocities in current state. */
                    cp.obj[i] = Mod(r1 + iset.rSid);
                    cp.alt[i] = r2;
                    cp.dir[i] = RFromD(r3);

                    /* Compute x,y,z coordinates from azimuth, altitude, and distance. */
                    SphToRec(r4, cp.obj[i], cp.alt[i], ref spacex[i], ref spacey[i], ref spacez[i]);
                }
            }

            /* If heliocentric, move Earth position to object slot zero. */
            i = us.objCenter != oEar ? 1 : 0;
            if (i > 0)
            {
                cp.obj[oEar] = cp.obj[oSun];
                cp.alt[oEar] = cp.alt[oSun];
                cp.dir[oEar] = cp.dir[oSun];
                spacex[oEar] = spacex[oSun];
                spacey[oEar] = spacey[oSun];
                spacez[oEar] = spacez[oSun];
            }
            spacex[i] = spacey[i] = spacez[i] =
              cp.obj[i] = cp.alt[i] = cp.dir[i] = 0.0;
            if (us.objCenter < oMoo)
                return;

            /* If other planet centered, shift all positions as in Matrix formulas. */

            for (i = 0; i <= oLil; i++)
            {
                if (i != us.objCenter)
                {
                    spacex[i] -= spacex[us.objCenter];
                    spacey[i] -= spacey[us.objCenter];
                    spacez[i] -= spacez[us.objCenter];
                    ProcessPlanet(i, 0.0);
                }
            }
            spacex[us.objCenter] = spacey[us.objCenter] = spacez[us.objCenter] =
                cp.obj[us.objCenter] = cp.alt[us.objCenter] = cp.dir[us.objCenter] = 0.0;
        }

        /* This is probably the main routine in all of Astrolog. It generates a   */
        /* chart, calculating the positions of all the celestial bodies and house */
        /* cusps, based on the current chart information, and saves them for use  */
        /* by any of the display routines.                                        */
        public double CastChart(bool fDate)
        {
            ChartInfo ci;
            double[] housetemp = new double[cSign + 1];
            double Off = 0.0, vtx = 0.0, j;
            int i, k;

            /* Hack: Time zone +/-24 means to have the time of day be in Local Mean */
            /* Time (LMT). This is done by making the time zone value reflect the   */
            /* logical offset from GMT as indicated by the chart's longitude value. */

            if (Math.Abs(ciCore.zon) == 24.0)
                ciCore.zon = DegToDec(DecToDeg(ciCore.lon) / 15.0);
            ci = ciCore;


            for (i = 0; i <= cObj; i++)
            {
                cp.obj[i] = cp.alt[i] = 0.0;    /* On ecliptic unless we say so.  */
                cp.dir[i] = 1.0;                      /* Direct until we say otherwise. */
            }
            Off = ProcessInput(fDate);
            ComputeVariables(ref vtx);
            if (us.fGeodetic)               /* Check for -G geodetic chart. */
                iset.RA = RFromD(Mod(-ciCore.lon));
            iset.MC = CuspMidheaven();       /* Calculate our Ascendant & Midheaven. */
            iset.Asc = CuspAscendant();
            ComputeHouses(us.nHouseSystem); /* Go calculate house cusps. */

            /* Go calculate planet, Moon, and North Node positions. */

            ComputePlanets();

            ComputeLunar(ref cp.obj[oMoo], ref cp.alt[oMoo], ref cp.obj[oNod], ref cp.alt[oNod]);
            cp.dir[oNod] = -1.0;

            /* Compute more accurate ephemeris positions for certain objects. */

            if (true/*us.fPlacalc*/)
            {
                ComputePlacalc(iset.T);
            }
            else
            {
                cp.obj[oSou] = Mod(cp.obj[oNod] + rDegHalf);
                cp.dir[oSou] = cp.dir[oNod] = RFromD(-0.053);
                cp.dir[oMoo] = RFromD(12.5);
            }

            /* Calculate position of Part of Fortune. */

            j = cp.obj[oMoo] - cp.obj[oSun];
            if (us.nArabicNight < 0 ||
              (us.nArabicNight == 0 && HousePlaceIn(cp.obj[oSun]) < sLib))
                j = -j;
            j = Math.Abs(j) < rDegQuad ? j : j - Math.Sign(j) * rDegMax;
            cp.obj[oFor] = Mod(j + iset.Asc);

            /* Fill in "planet" positions corresponding to house cusps. */

            cp.obj[oVtx] = vtx; cp.obj[oEP] = CuspEastPoint();
            for (i = 1; i <= cSign; i++)
                cp.obj[cuspLo + i - 1] = cp.obj[i];
            if (!us.fHouseAngle)
            {
                cp.obj[oAsc] = iset.Asc; cp.obj[oMC] = iset.MC;
                cp.obj[oDes] = Mod(iset.Asc + rDegHalf);
                cp.obj[oNad] = Mod(iset.MC + rDegHalf);
            }
            for (i = oFor; i <= cuspHi; i++)
                cp.dir[i] = RFromD(rDegMax);

            /* Go calculate star positions if -U switch in effect. */

            if (us.nStar != 0)
                ComputeStars(us.fSidereal ? 0.0 : -Off);

            /* Transform ecliptic to equatorial coordinates if -sr in effect. */

            if (us.fEquator)
            {
                for (i = 0; i <= cObj; i++)
                {
                    cp.obj[i] = RFromD(Tropical(cp.obj[i]));
                    cp.alt[i] = RFromD(cp.alt[i]);
                    EclToEqu(ref  cp.obj[i], ref cp.alt[i]);
                    cp.obj[i] = DFromR(cp.obj[i]);
                    cp.alt[i] = DFromR(cp.alt[i]);
                }
            }

            /* Now, we may have to modify the base positions we calculated above */
            /* based on what type of chart we are generating.                    */

            if (us.fProgress && us.fSolarArc)
            {  /* Are we doing -p0 solar arc chart? */
                for (i = 0; i <= cObj; i++)
                    cp.obj[i] = Mod(cp.obj[i] + (iset.JDp - iset.JD) / us.rProgDay);
                for (i = 1; i <= cSign; i++)
                    cp.cusp[i] = Mod(cp.cusp[i] + (iset.JDp - iset.JD) / us.rProgDay);
            }
            if (us.nHarmonic > 1) /* Are we doing a -x harmonic chart?     */
            {
                for (i = 0; i <= cObj; i++)
                    cp.obj[i] = Mod(cp.obj[i] * (double)us.nHarmonic);
            }
            if (us.objOnAsc != 0)
            {
                if (us.objOnAsc > 0)           /* Is -1 put on Ascendant in effect?     */
                    j = cp.obj[us.objOnAsc] - iset.Asc;
                else                           /* Or -2 put object on Midheaven switch? */
                    j = cp.obj[-us.objOnAsc] - iset.MC;
                for (i = 1; i <= cSign; i++)   /* If so, rotate the houses accordingly. */
                    cp.cusp[i] = Mod(cp.cusp[i] + j);
            }

            /* Check to see if we are -F forcing any objects to be particular values. */

            for (i = 0; i <= cObj; i++)
                if (force[i] != 0.0)
                {
                    cp.obj[i] = force[i] - rDegMax;
                    cp.alt[i] = cp.dir[i] = 0.0;
                }

            ComputeInHouses();        /* Figure out what house everything falls in. */

            /* If -f domal chart switch in effect, switch planet and house positions. */

            if (us.fFlip)
            {
                for (i = 0; i <= cObj; i++)
                {
                    k = cp.house[i];
                    cp.house[i] = (byte)SFromZ(cp.obj[i]);
                    cp.obj[i] = ZFromS(k) + MinDistance(cp.cusp[k], cp.obj[i]) /
                      MinDistance(cp.cusp[k], cp.cusp[Mod12(k + 1)]) * 30.0;
                }
                for (i = 1; i <= cSign; i++)
                {
                    k = HousePlaceIn(ZFromS(i));
                    housetemp[i] = ZFromS(k) + MinDistance(cp.cusp[k], ZFromS(i)) /
                      MinDistance(cp.cusp[k], cp.cusp[Mod12(k + 1)]) * 30.0;
                }
                for (i = 1; i <= cSign; i++)
                    cp.cusp[i] = housetemp[i];
            }

            /* If -3 decan chart switch in effect, edit planet positions accordingly. */

            if (us.fDecan)
            {
                for (i = 0; i <= cObj; i++)
                    cp.obj[i] = Decan(cp.obj[i]);
                ComputeInHouses();
            }

            /* If -9 navamsa chart switch in effect, edit positions accordingly. */

            if (us.fNavamsa)
            {
                for (i = 0; i <= cObj; i++)
                    cp.obj[i] = Navamsa(cp.obj[i]);
                ComputeInHouses();
            }

            ciCore = ci;
            return iset.T;
        }

        /*
        ******************************************************************************
        ** House Cusp Calculations.
        ******************************************************************************
        */

        /* This is a subprocedure of ComputeInHouses(). Given a zodiac position,  */
        /* return which of the twelve houses it falls in. Remember that a special */
        /* check has to be done for the house that spans 0 degrees Aries.         */
        int HousePlaceIn(double rDeg)
        {
            int i = 0;

            rDeg = Mod(rDeg + 0.5 / 60.0 / 60.0);
            do
            {
                i++;
            } while (!(i >= cSign ||
                (rDeg >= cp.cusp[i] && rDeg < cp.cusp[Mod12(i + 1)]) ||
                (cp.cusp[i] > cp.cusp[Mod12(i + 1)] &&
                (rDeg >= cp.cusp[i] || rDeg < cp.cusp[Mod12(i + 1)]))));
            return i;
        }


        /*
        ******************************************************************************
        ** Star Position Calculations.
        ******************************************************************************
        */

        /* This is used by the chart calculation routine to calculate the positions */
        /* of the fixed stars. Since the stars don't move in the sky over time,     */
        /* getting their positions is mostly just reading info from an array and    */
        /* converting it to the correct reference frame. However, we have to add    */
        /* in the correct precession for the tropical zodiac, and sort the final    */
        /* index list based on what order the stars are supposed to be printed in.  */
        void ComputeStars(double SD)
        {
            int i, j;
            double x, y, z;

            /* Read in star positions. */
            for (i = 1; i <= cStar; i++)
            {
                x = rStarData[i * 6 - 6]; y = rStarData[i * 6 - 5]; z = rStarData[i * 6 - 4];
                cp.obj[oNorm + i] = RFromD(x * rDegMax / 24.0 + y * 15.0 / 60.0 + z * 0.25 / 60.0);
                x = rStarData[i * 6 - 3]; y = rStarData[i * 6 - 2]; z = rStarData[i * 6 - 1];
                if (x < 0.0)
                {
                    y = -y;
                    z = -z;
                }
                cp.alt[oNorm + i] = RFromD(x + y / 60.0 + z / 60.0 / 60.0);
                /* Convert to ecliptic zodiac coordinates. */
                EquToEcl(ref cp.obj[oNorm + i], ref cp.alt[oNorm + i]);
                cp.obj[oNorm + i] = Mod(DFromR(cp.obj[oNorm + i]) + rEpoch2000 + SD);
                cp.alt[oNorm + i] = DFromR(cp.alt[oNorm + i]);
                cp.dir[oNorm + i] = RFromD(rDegMax / 26000.0 / 365.25);
                starname[i] = i;
            }
        }

        /* For each object in the chart, determine what house it belongs in. */
        void ComputeInHouses()
        {
            int i;

            for (i = 0; i <= cObj; i++)
                cp.house[i] = (byte)HousePlaceIn(cp.obj[i]);
        }

        void ComputeHouses(int housesystem)
        {

            if (Math.Abs(ciCore.lat) > RFromD(rDegQuad - rAxis) && housesystem < 2)
            {
                ciCore.lat = Math.Sign(ciCore.lat) * RFromD(rDegQuad - rAxis);
                throw new Exception(string.Format("The {0} system of houses is not defined at extreme latitudes.",
                housesystem));

            }

            /* Flip the Ascendant if it falls in the wrong half of the zodiac. */
            if (MinDifference(iset.MC, iset.Asc) < 0.0)
                iset.Asc = Mod(iset.Asc + rDegHalf);

            switch (housesystem)
            {
                case 1: HouseKoch(); break;
                //case  2: HouseEqual();          break;
                //case  3: HouseCampanus();       break;
                //case  4: HouseMeridian();       break;
                //case  5: HouseRegiomontanus();  break;
                //case  6: HousePorphyry();       break;
                //case  7: HouseMorinus();        break;
                //case  8: HouseTopocentric();    break;
                //case  9: HouseAlcabitius();     break;
                //case 10: HouseEqualMidheaven(); break;
                //case 11: HousePorphyryNeo();    break;
                //case 12: HouseWhole();          break;
                //case 13: HouseVedic();          break;
                //case 14: HouseNull();           break;
                default: HousePlacidus();
                    break;
            }
        }

        /* Integer division - like the "/" operator but always rounds result down. */
        long Dvd(long x, long y)
        {
            long z;

            if (y == 0)
                return x;
            z = x / y;
            if (((x >= 0) == (y >= 0)) || x - z * y == 0)
                return z;
            return z - 1;
        }

        double Mod(double d)
        {
            if (d >= rDegMax)        /* In most cases, our value is only slightly */
                d -= rDegMax;          /* out of range, so we can test for it and   */
            else if (d < 0.0)        /* avoid the more complicated arithmetic.    */
                d += rDegMax;
            if (d >= 0 && d < rDegMax)
                return d;
            return (d - Math.Floor(d / rDegMax) * rDegMax);
        }

        /* A similar modulus function: convert an integer to value from 1..12. */
        int Mod12(int i)
        {
            while (i > cSign)
                i -= cSign;
            while (i < 1)
                i += cSign;
            return i;
        }

        /* Convert an inputed fractional degrees/minutes value to a true double   */
        /* degree quantity. For example, the user enters the double value "10.30" */
        /* to mean 10 degrees and 30 minutes; this will return 10.5, i.e. 10       */
        /* degrees and 30 minutes expressed as a doubleing point degree value.      */
        double DecToDeg(double d)
        {
            return Math.Sign(d) * (Math.Floor(Math.Abs(d)) + RFract(Math.Abs(d)) * 100.0 / 60.0);
        }

        /* This is the inverse of the above function. Given a true double value */
        /* for a zodiac degree, adjust it so the degrees are in the integer part */
        /* and the minute expressed as hundredths, e.g. 10.5 degrees -> 10.30    */
        double DegToDec(double d)
        {
            return Math.Sign(d) * (Math.Floor(Math.Abs(d)) + RFract(Math.Abs(d)) * 60.0 / 100.0);
        }

        /* Return the shortest distance between two degrees in the zodiac. This is  */
        /* normally their difference, but we have to check if near the Aries point. */
        double MinDistance(double deg1, double deg2)
        {
            double i;
            i = Math.Abs(deg1 - deg2);
            return i < rDegHalf ? i : rDegMax - i;
        }

        public double RFract(double r)
        {
            return r - Math.Floor(r);
        }

        public double RFromD(double r)
        {
            return r / rDegRad;
        }

        public double DFromR(double r)
        {
            return r * rDegRad;
        }

        public double Angle(double x, double y)
        {
            double a;

            if (x != 0.0)
            {
                if (y != 0.0)
                    a = Math.Atan(y / x);
                else
                    a = x < 0.0 ? rPi : 0.0;
            }
            else
                a = y < 0.0 ? -rPiHalf : rPiHalf;
            if (a < 0.0)
                a += rPi;
            if (y < 0.0)
                a += rPi;
            return a;
        }

        /* This is just like the above routine, except the min distance value  */
        /* returned will either be positive or negative based on whether the   */
        /* second value is ahead or behind the first one in a circular zodiac. */
        public double MinDifference(double deg1, double deg2)
        {
            double i;

            i = deg2 - deg1;
            if (Math.Abs(i) < rDegHalf)
                return i;
            return Math.Sign(i) * (Math.Abs(i) - rDegMax);
        }

        /* Given a zodiac degree, transform it into its Decan sign, where each    */
        /* sign is trisected into the three signs of its element. For example,    */
        /* 1 Aries -> 3 Aries, 10 Leo -> 0 Sagittarius, 25 Sagittarius -> 15 Leo. */
        double Decan(double deg)
        {
            int sign;
            double unit;

            sign = SFromZ(deg);
            unit = deg - ZFromS(sign);
            sign = Mod12(sign + 4 * ((int)Math.Floor(unit / 10.0)));
            unit = (unit - Math.Floor(unit / 10.0) * 10.0) * 3.0;
            return ZFromS(sign) + unit;
        }


        /* Given a zodiac degree, transform it into its Navamsa position, where   */
        /* each sign is divided into ninths, which determines the number of signs */
        /* after a base element sign to use. Degrees within signs are unaffected. */
        double Navamsa(double deg)
        {
            int sign, sign2;
            double unit;

            sign = SFromZ(deg);
            unit = deg - ZFromS(sign);
            sign2 = Mod12(((sign - 1 & 3) ^ (2 * (sign - 1 & 1))) * 3 + (int)(unit * 0.3) + 1);
            return ZFromS(sign2) + unit;
        }

        /* Transform spherical to rectangular coordinates in x, y, z. */
        unsafe void SphToRec(double r, double azi, double alt, ref double rx, ref double ry, ref double rz)
        {
            double rT;
            rz = r * RSinD(alt);
            rT = r * RCosD(alt);
            rx = rT * RCosD(azi);
            ry = rT * RSinD(azi);
        }

        double Tropical(double deg)
        {
            return deg - iset.rSid + us.rZodiacOffset;
        }

        double ZFromS(double s)
        {
            return (s - 1) * 30;
        }

        int SFromZ(double r)
        {
            return (((int)(r)) / 30 + 1);
        }
    }
}
