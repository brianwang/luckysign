using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AstroCSharpLib.Model;

namespace AstroCSharpLib
{
    public partial class CALC
    {
        public double[] spacex = new double[oNorm + 1];
        public double[] spacey = new double[oNorm + 1];
        public double[] spacez = new double[oNorm + 1];
        double[] force = new double[objMax];
        /*
        ******************************************************************************
        ** Assorted Calculations.
        ******************************************************************************
        */

        /* Given a month, day, and year, convert it into a single Julian day value, */
        /* i.e. the number of days passed since a fixed reference date.             */
        long MdyToJulian(int mon, int day, int yea)
        {
            long im, j;

            im = 12 * ((long)yea + 4800) + (long)mon - 3;
            j = (2 * (im % 12) + 7 + 365 * im) / 12;
            j += (long)day + im / 48 - 32083;
            if (j > 2299171)                   /* Take care of dates in */
                j += im / 4800 - im / 1200 + 38;     /* Gregorian calendar.   */
            return j;
        }

        /* Like above but return a fractional Julian time given the extra info. */
        double MdytszToJulian(int mon, int day, int yea, double tim, double dst, double zon)
        {
            return (double)MdyToJulian(mon, day, yea) +
              (DecToDeg(tim) + DecToDeg(zon) - DecToDeg(dst)) / 24.0;
        }

        /* Take a Julian day value, and convert it back into the corresponding */
        /* month, day, and year.                                               */
        void JulianToMdy(double JD, ref int mon, ref int day, ref int yea)
        {
            long L, N, IT, JT, K, IK;

            L = (long)Math.Floor(JD + rRound) + 68569L;
            N = Dvd(4L * L, 146097L);
            L -= Dvd(146097L * N + 3L, 4L);
            IT = Dvd(4000L * (L + 1L), 1461001L);
            L -= Dvd(1461L * IT, 4L) - 31L;
            JT = Dvd(80L * L, 2447L);
            K = L - Dvd(2447L * JT, 80L);
            L = Dvd(JT, 11L);
            JT += 2L - 12L * L;
            IK = 100L * (N - 49L) + IT + L;
            mon = (int)JT;
            day = (int)K;
            yea = (int)IK;
        }

        /* This is a subprocedure of CastChart(). Once we have the chart parameters, */
        /* calculate a few important things related to the date, i.e. the Greenwich  */
        /* time, the Julian day and fractional part of the day, the offset to the    */
        /* sidereal, and a couple of other things.                                   */
        double ProcessInput(bool fDate)
        {
            double Off, Ln;

            ciCore.tim = RSgn(ciCore.tim) * Math.Floor(Math.Abs(ciCore.tim)) + RFract(Math.Abs(ciCore.tim)) * 100.0 / 60.0 +
              (DecToDeg(ciCore.zon) - DecToDeg(ciCore.dst));
            ciCore.lon = DecToDeg(ciCore.lon);
            ciCore.lat = Math.Min(ciCore.lat, 89.9999);        /* Make sure the chart isn't being cast */
            ciCore.lat = Math.Max(ciCore.lat, -89.9999);       /* on the precise north or south pole.  */
            ciCore.lat = RFromD(DecToDeg(ciCore.lat));

            /* if parameter 'fDate' isn't set, then we can assume that the true time */
            /* has already been determined (as in a -rm switch time midpoint chart). */

            if (fDate)
            {
                iset.JD = (double)MdyToJulian(ciCore.mon, ciCore.day, ciCore.yea);
                if (!us.fProgress || us.fSolarArc)
                {
                    iset.T = (iset.JD + ciCore.tim / 24.0 - 2415020.5) / 36525.0;
                }
                else
                {
                    /* Determine actual time that a progressed chart is to be cast for. */

                    iset.T = ((iset.JD + ciCore.tim / 24.0 + (iset.JDp - (iset.JD + ciCore.tim / 24.0)) / us.rProgDay) -
                      2415020.5) / 36525.0;
                }
            }

            /* Compute angle that the ecliptic is inclined to the Celestial Equator */
            iset.OB = RFromD(23.452294 - 0.0130125 * iset.T);

            Ln = Mod((933060 - 6962911 * iset.T + 7.5 * iset.T * iset.T) / 3600.0);  /* Mean lunar node */
            Off = (259205536.0 * iset.T + 2013816.0) / 3600.0;             /* Mean Sun        */
            Off = 17.23 * Math.Sin(RFromD(Ln)) + 1.27 * Math.Sin(RFromD(Off)) - (5025.64 + 1.11 * iset.T) * iset.T;
            Off = (Off - 84038.27) / 3600.0;
            iset.rSid = (us.fSidereal ? Off : 0.0) + us.rZodiacOffset;
            return Off;
        }

        /* Convert polar to rectangular coordinates. */
        void PolToRec(double A, double R, ref double X, ref double Y)
        {
            if (A == 0.0)
                A = rSmall;
            X = R * Math.Cos(A);
            Y = R * Math.Sin(A);
        }

        /* Convert rectangular to polar coordinates. */
        void RecToPol(double X, double Y, ref double A, ref double R)
        {
            if (Y == 0.0)
                Y = rSmall;
            R = Math.Sqrt(X * X + Y * Y);
            A = Angle(X, Y);
        }

        /* Convert rectangular to spherical coordinates. */
        double RecToSph(double B, double L, double O)
        {
            double R, Q, G, X = 0, Y = 0, A;
            A = B; R = 1.0;
            PolToRec(A, R, ref X, ref Y);
            Q = Y; R = X; A = L;
            PolToRec(A, R, ref X, ref Y);
            G = X; X = Y; Y = Q;
            RecToPol(X, Y, ref A, ref R);
            A += O;
            PolToRec(A, R, ref X, ref Y);
            Q = Math.Asin(Y);
            Y = X; X = G;
            RecToPol(X, Y, ref A, ref R);
            if (A < 0.0)
                A += 2 * rPi;
            G = A;
            return G;  /* We only ever care about and return one of the coordinates. */
        }

        /* Do a coordinate transformation: Given a longitude and latitude value,    */
        /* return the new longitude and latitude values that the same location      */
        /* would have, were the equator tilted by a specified number of degrees.    */
        /* In other words, do a pole shift! This is used to convert among ecliptic, */
        /* equatorial, and local coordinates, each of which have zero declination   */
        /* in different planes. In other words, take into account the Earth's axis. */
        void CoorXform(ref double azi, ref double alt, double tilt)
        {
            double x, y, a1, l1;
            double sinalt, cosalt, sinazi, sintilt, costilt;

            sinalt = Math.Sin(alt); cosalt = Math.Cos(alt); sinazi = Math.Sin(azi);
            sintilt = Math.Sin(tilt); costilt = Math.Cos(tilt);

            x = cosalt * sinazi * costilt;
            y = sinalt * sintilt;
            x -= y;
            a1 = cosalt;
            y = cosalt * Math.Cos(azi);
            l1 = Angle(y, x);
            a1 = a1 * sinazi * sintilt + sinalt * costilt;
            a1 = Math.Asin(a1);
            azi = l1; alt = a1;
        }

        void EclToEqu(ref double Z, ref double L)
        {
            CoorXform(ref Z, ref L, RFromD(rAxis));
        }

        void EquToEcl(ref double azi, ref double alt)
        {
            CoorXform(ref azi, ref alt, RFromD(-rAxis));
        }

        /* This is another subprocedure of CastChart(). Calculate a few variables */
        /* corresponding to the chart parameters that are used later on. The      */
        /* astrological vertex (object number nineteen) is also calculated here.  */
        public void ComputeVariables(ref double vtx)
        {
            double R, R2, B, L, O, G, X = 0, Y = 0, A;

            iset.RA = RFromD(Mod((6.6460656 + 2400.0513 * iset.T + 2.58E-5 * iset.T * iset.T + ciCore.tim) * 15.0 - ciCore.lon));
            R2 = iset.RA; O = -iset.OB; B = ciCore.lat; A = R2; R = 1.0;
            PolToRec(A, R, ref X, ref Y);
            X *= Math.Cos(O);
            RecToPol(X, Y, ref A, ref R);
            iset.MC = Mod(iset.rSid + DFromR(A));           /* Midheaven */
            //#if FALSE
            //  L = R2;
            //  G = RecToSph(B, L, O);
            //  is.Asc = Mod(is.rSid + Mod(G+rPiHalf));     /* Ascendant */
            //#endif
            L = R2 + rPi; B = rPiHalf - Math.Abs(B);
            if (ciCore.lat < 0.0)
                B = -B;
            G = RecToSph(B, L, O);
            vtx = Mod(iset.rSid + DFromR(G + rPiHalf));    /* Vertex */
        }


        /*
        ******************************************************************************
        ** House Cusp Calculations.
        ******************************************************************************
        */

        /* The following three functions calculate the Midheaven, Ascendant, and  */
        /* East Point of the chart in question, based on time and location. The   */
        /* first two are also used in some of the house cusp calculation routines */
        /* as a quick way to get the 10th and 1st cusps. The East Point object is */
        /* technically defined as the Ascendant's position at zero latitude.      */
        double CuspMidheaven()
        {
            double MC;

            MC = Math.Atan(Math.Tan(iset.RA) / Math.Cos(iset.OB));
            if (MC < 0.0)
                MC += rPi;
            if (iset.RA > rPi)
                MC += rPi;
            return Mod(DFromR(MC) + iset.rSid);
        }

        double CuspAscendant()
        {
            double Asc;

            Asc = Angle(-Math.Sin(iset.RA) * Math.Cos(iset.OB) - Math.Tan(ciCore.lat) * Math.Sin(iset.OB), Math.Cos(iset.RA));
            return Mod(DFromR(Asc) + iset.rSid);
        }

        double CuspEastPoint()
        {
            double EP;

            EP = Angle(-Math.Sin(iset.RA) * Math.Cos(iset.OB), Math.Cos(iset.RA));
            return Mod(DFromR(EP) + iset.rSid);
        }


        /* These are various different algorithms for calculating the house cusps: */
        double CuspPlacidus(double deg, double FF, bool fNeg)
        {
            double LO, R1, XS, X;
            int i;

            R1 = iset.RA + RFromD(deg);
            X = fNeg ? 1.0 : -1.0;
            /* Looping 10 times is arbitrary, but it's what other programs do. */
            for (i = 1; i <= 10; i++)
            {

                /* This formula works except at 0 latitude (AA == 0.0). */

                XS = X * Math.Sin(R1) * Math.Tan(iset.OB) * Math.Tan(ciCore.lat == 0.0 ? 0.0001 : ciCore.lat);
                XS = Math.Acos(XS);
                if (XS < 0.0)
                    XS += rPi;
                R1 = iset.RA + (fNeg ? rPi - (XS / FF) : (XS / FF));
            }
            LO = Math.Atan(Math.Tan(R1) / Math.Cos(iset.OB));
            if (LO < 0.0)
                LO += rPi;
            if (Math.Sin(R1) < 0.0)
                LO += rPi;
            return DFromR(LO);
        }

        void HousePlacidus()
        {
            int i;

            cp.cusp[1] = Mod(iset.Asc - iset.rSid);
            cp.cusp[4] = Mod(iset.MC + rDegHalf - iset.rSid);
            cp.cusp[5] = CuspPlacidus(30.0, 3.0, false) + rDegHalf;
            cp.cusp[6] = CuspPlacidus(60.0, 1.5, false) + rDegHalf;
            cp.cusp[2] = CuspPlacidus(120.0, 1.5, true);
            cp.cusp[3] = CuspPlacidus(150.0, 3.0, true);
            for (i = 1; i <= cSign; i++)
            {
                if (i <= 6)
                    cp.cusp[i] = Mod(cp.cusp[i] + iset.rSid);
                else
                    cp.cusp[i] = Mod(cp.cusp[i - 6] + rDegHalf);
            }
        }

        void HouseKoch()
        {
            double A1, A2, A3, KN, D, X;
            int i;

            A1 = Math.Sin(iset.RA) * Math.Tan(ciCore.lat) * Math.Tan(iset.OB);
            A1 = Math.Asin(A1);
            for (i = 1; i <= cSign; i++)
            {
                D = Mod(60.0 + 30.0 * (double)i);
                A2 = D / rDegQuad - 1.0; KN = 1.0;
                if (D >= rDegHalf)
                {
                    KN = -1.0;
                    A2 = D / rDegQuad - 3.0;
                }
                A3 = RFromD(Mod(DFromR(iset.RA) + D + A2 * DFromR(A1)));
                X = Angle(Math.Cos(A3) * Math.Cos(iset.OB) - KN * Math.Tan(ciCore.lat) * Math.Sin(iset.OB), Math.Sin(A3));
                cp.cusp[i] = Mod(DFromR(X) + iset.rSid);
            }
        }
        /* "目前用不到的分宫算法"
        void HouseEqual()
        {
          int i;

          for (i = 1; i <= cSign; i++)
            chouse[i] = Mod(is.Asc + ZFromS(i));
        }

        void HouseCampanus()
        {
          real KO, DN, X;
          int i;

          for (i = 1; i <= cSign; i++) {
            KO = RFromD(60.000001+30.0*(real)i);
            DN = RAtn(RTan(KO)*RCos(AA));
            if (DN < 0.0)
              DN += rPi;
            if (RSin(KO) < 0.0)
              DN += rPi;
            X = Angle(RCos(is.RA+DN)*RCos(is.OB)-RSin(DN)*RTan(AA)*RSin(is.OB),
              RSin(is.RA+DN));
            chouse[i] = Mod(DFromR(X)+is.rSid);
          }
        }

        void HouseMeridian()
        {
          real D, X;
          int i;

          for (i = 1; i <= cSign; i++) {
            D = RFromD(60.0+30.0*(real)i);
            X = Angle(RCos(is.RA+D)*RCos(is.OB), RSin(is.RA+D));
            chouse[i] = Mod(DFromR(X)+is.rSid);
          }
        }

        void HouseRegiomontanus()
        {
          real D, X;
          int i;

          for (i = 1; i <= cSign; i++) {
            D = RFromD(60.0+30.0*(real)i);
            X = Angle(RCos(is.RA+D)*RCos(is.OB)-RSin(D)*RTan(AA)*RSin(is.OB),
              RSin(is.RA+D));
            chouse[i] = Mod(DFromR(X)+is.rSid);
          }
        }

        void HousePorphyry()
        {
          real X, Y;
          int i;

          X = is.Asc-is.MC;
          if (X < 0.0)
            X += rDegMax;
          Y = X/3.0;
          for (i = 1; i <= 2; i++)
            chouse[i+4] = Mod(rDegHalf+is.MC+i*Y);
          X = Mod(rDegHalf+is.MC)-is.Asc;
          if (X < 0.0)
            X += rDegMax;
          chouse[1]=is.Asc;
          Y = X/3.0;
          for (i = 1; i <= 3; i++)
            chouse[i+1] = Mod(is.Asc+i*Y);
          for (i = 1; i <= 6; i++)
            chouse[i+6] = Mod(chouse[i]+rDegHalf);
        }

        void HouseMorinus()
        {
          real D, X;
          int i;

          for (i = 1; i <= cSign; i++) {
            D = RFromD(60.0+30.0*(real)i);
            X = Angle(RCos(is.RA+D), RSin(is.RA+D)*RCos(is.OB));
            chouse[i] = Mod(DFromR(X)+is.rSid);
          }
        }

        real CuspTopocentric(deg)
        real deg;
        {
          real OA, X, LO;

          OA = ModRad(is.RA+RFromD(deg));
          X = RAtn(RTan(AA)/RCos(OA));
          LO = RAtn(RCos(X)*RTan(OA)/RCos(X+is.OB));
          if (LO < 0.0)
            LO += rPi;
          if (RSin(OA) < 0.0)
            LO += rPi;
          return LO;
        }

        void HouseTopocentric()
        {
          real TL, P1, P2, LT;
          int i;

          chouse[4] = ModRad(RFromD(is.MC+rDegHalf-is.rSid));
          TL = RTan(AA); P1 = RAtn(TL/3.0); P2 = RAtn(TL/1.5); LT = AA;
          AA = P1; chouse[5] = CuspTopocentric(30.0) + rPi;
          AA = P2; chouse[6] = CuspTopocentric(60.0) + rPi;
          AA = LT; chouse[1] = CuspTopocentric(90.0);
          AA = P2; chouse[2] = CuspTopocentric(120.0);
          AA = P1; chouse[3] = CuspTopocentric(150.0);
          AA = LT;
          for (i = 1; i <= 6; i++) {
            chouse[i] = Mod(DFromR(chouse[i])+is.rSid);
            chouse[i+6] = Mod(chouse[i]+rDegHalf);
          }
        }
        */


        /*
        ******************************************************************************
        ** Planetary Position Calculations.
        ******************************************************************************
        */

        /* Given three values, return them combined as the coefficients of a */
        /* quadratic equation as a function of the chart time.               */
        double ReadThree(double r0, double r1, double r2)
        {
            return RFromD(r0 + r1 * iset.T + r2 * iset.T * iset.T);
        }


        /* Another coordinate transformation. This is used by the ComputePlanets() */
        /* procedure to rotate rectangular coordinates by a certain amount.        */
        void RecToSph2(double AP, double AN, double IN, ref double X, ref double Y, ref double G)
        {
            double R = 0, D = 0, A = 0;

            RecToPol(X, Y, ref A, ref R); A += AP; PolToRec(A, R, ref X, ref Y);
            D = X; X = Y; Y = 0.0; RecToPol(X, Y, ref A, ref R);
            A += IN; PolToRec(A, R, ref X, ref Y);
            G = Y; Y = X; X = D; RecToPol(X, Y, ref A, ref R); A += AN;
            if (A < 0.0)
                A += 2.0 * rPi;
            PolToRec(A, R, ref X, ref Y);
        }

        /* Calculate some harmonic delta error correction factors to add onto the */
        /* coordinates of Jupiter through Pluto, for better accuracy.             */
        void ErrorCorrect(int ind, ref double x, ref double y, ref double z)
        {
            double U, V, W, A, S0;
            double[] T0 = new double[4];
            int errorDataIndex;
            int IK, IJ, irError;

            irError = rErrorCount[ind - oJup];
            errorDataIndex = rErrorOffset[ind - oJup];
            for (IK = 1; IK <= 3; IK++)
            {
                if (ind == oJup && IK == 3)
                {
                    T0[3] = 0.0;
                    break;
                }
                if (IK == 3)
                    irError--;
                S0 = ReadThree(rErrorData[errorDataIndex], rErrorData[errorDataIndex + 1], rErrorData[errorDataIndex + 2]);
                errorDataIndex += 3;
                A = 0.0;
                for (IJ = 1; IJ <= irError; IJ++)
                {
                    U = rErrorData[errorDataIndex]; V = rErrorData[errorDataIndex + 1]; W = rErrorData[errorDataIndex + 2];
                    errorDataIndex += 3;
                    A += RFromD(U) * Math.Cos((V * iset.T + W) * rPi / rDegHalf);
                }
                T0[IK] = DFromR(S0 + A);
            }
            x += T0[2]; y += T0[1]; z += T0[3];
        }

        /* Another subprocedure of the ComputePlanets() routine. Convert the final */
        /* rectangular coordinates of a planet to zodiac position and declination. */
        void ProcessPlanet(int ind, double aber)
        {
            double ang = 0, rad = 0;

            RecToPol(spacex[ind], spacey[ind], ref ang, ref rad);
            cp.obj[ind] = Mod(DFromR(ang) /*+ NU*/ - aber + iset.rSid);
            RecToPol(rad, spacez[ind], ref ang, ref rad);
            if (us.objCenter == oSun && ind == oSun)
                ang = 0.0;
            ang = DFromR(ang);
            while (ang > rDegQuad)    /* Ensure declination is from -90..+90 degrees. */
                ang -= rDegHalf;
            while (ang < -rDegQuad)
                ang += rDegHalf;
            cp.alt[ind] = ang;
        }

        int IoeFromObj(int obj)
        {
            return (obj < oMoo ? 0 : (obj <= cPlanet ? obj - 2 : obj - uranLo + cPlanet - 1));
        }

        /* Another modulus function, this time for the range of 0 to 2 Pi. */
        double ModRad(double r)
        {
            while (r >= rPi2)    /* We assume our value is only slightly out of       */
                r -= rPi2;         /* range, so test and never do any complicated math. */
            while (r < 0.0)
                r += rPi2;
            return r;
        }

        bool FBetween<T>(T v, T v1, T v2) where T : IComparable
        {
            return v.CompareTo(v1) >= 0 && v.CompareTo(v2) <= 0;
        }

        /* This is probably the heart of the whole program of Astrolog. Calculate  */
        /* the position of each body that orbits the Sun. A heliocentric chart is  */
        /* most natural; extra calculation is needed to have other central bodies. */
        void ComputePlanets()
        {
            double[] helioret = new double[oNorm + 1];
            double[] heliox = new double[oNorm + 1];
            double[] helioy = new double[oNorm + 1];
            double[] helioz = new double[oNorm + 1];
            double aber = 0.0, AU, E, EA, E1, M, XW, YW, AP, AN, IN, X = 0.0, Y = 0.0, G = 0.0, XS, YS, ZS;
            int ind = oSun, i;
            OrbitalElements poe;

            while (ind <= (us.fUranian ? oNorm : cPlanet))
            {
                //if (ignore[ind] && ind > oSun)
                //  goto LNextPlanet;
                poe = rgoe[IoeFromObj(ind)];

                EA = M = ModRad(ReadThree(poe.ma0, poe.ma1, poe.ma2));
                E = DFromR(ReadThree(poe.ec0, poe.ec1, poe.ec2));
                for (i = 1; i <= 5; i++)
                    EA = M + E * Math.Sin(EA);            /* Solve Kepler's equation */
                AU = poe.sma;                  /* Semi-major axis         */
                E1 = 0.01720209 / (Math.Pow(AU, 1.5) *
                  (1.0 - E * Math.Cos(EA)));                     /* Begin velocity coordinates */
                XW = -AU * E1 * Math.Sin(EA);                    /* Perifocal coordinates      */
                YW = AU * E1 * Math.Pow(1.0 - E * E, 0.5) * Math.Cos(EA);
                AP = ReadThree(poe.ap0, poe.ap1, poe.ap2);
                AN = ReadThree(poe.an0, poe.an1, poe.an2);
                IN = ReadThree(poe.in0, poe.in1, poe.in2); /* Calculate inclination  */
                X = XW; Y = YW;
                RecToSph2(AP, AN, IN, ref X, ref Y, ref G);  /* Rotate velocity coords */
                heliox[ind] = X; helioy[ind] = Y;
                helioz[ind] = G;                    /* Helio ecliptic rectangtular */
                X = AU * (Math.Cos(EA) - E);                /* Perifocal coordinates for        */
                Y = AU * Math.Sin(EA) * Math.Pow(1.0 - E * E, 0.5);   /* rectangular position coordinates */
                RecToSph2(AP, AN, IN, ref X, ref Y, ref G);  /* Rotate for rectangular */
                XS = X; YS = Y; ZS = G;             /* position coordinates   */
                if (FBetween(ind, oJup, oPlu))
                    ErrorCorrect(ind, ref XS, ref YS, ref ZS);
                cp.dir[ind] =                                        /* Helio daily motion */
                  (XS * helioy[ind] - YS * heliox[ind]) / (XS * XS + YS * YS);
                spacex[ind] = XS; spacey[ind] = YS; spacez[ind] = ZS;
                ProcessPlanet(ind, 0.0);
                //LNextPlanet:
                ind += (ind == oSun ? 2 : (ind != cPlanet ? 1 : uranLo - cPlanet));
            }

            spacex[oEar] = spacex[oSun];
            spacey[oEar] = spacey[oSun];
            spacez[oEar] = spacez[oSun];
            cp.obj[oEar] = cp.obj[oSun]; cp.alt[oEar] = cp.alt[oSun];
            cp.dir[oEar] = cp.dir[oSun];
            heliox[oEar] = heliox[oSun]; helioy[oEar] = helioy[oSun];
            helioret[oEar] = helioret[oSun];
            spacex[oSun] = spacey[oSun] = spacez[oSun] =
              cp.obj[oSun] = cp.alt[oSun] = heliox[oSun] = helioy[oSun] = 0.0;
            if (us.objCenter == oSun)
            {
                if (us.fVelocity)
                    for (i = 0; i <= oNorm; i++)    /* Use relative velocity */
                        cp.dir[i] = RFromD(1.0);         /* if -v0 is in effect.  */
                return;
            }

            /* A second loop is needed for geocentric charts or central bodies other */
            /* than the Sun. For example, we can't find the position of Mercury in   */
            /* relation to Pluto until we know the position of Pluto in relation to  */
            /* the Sun, and since Mercury is calculated first, another pass needed.  */

            ind = us.objCenter;
            for (i = 0; i <= oNorm; i++)
            {
                helioret[i] = cp.dir[i];
                if (i != oMoo && i != ind)
                {
                    spacex[i] -= spacex[ind];
                    spacey[i] -= spacey[ind];
                    spacez[i] -= spacez[ind];
                }
            }
            for (i = oEar; i <= (us.fUranian ? oNorm : cPlanet);
              i += (i == oSun ? 2 : (i != cPlanet ? 1 : uranLo - cPlanet)))
            {
                //if ((ignore[i] && i > oSun) || i == ind)
                //  continue;
                XS = spacex[i]; YS = spacey[i]; ZS = spacez[i];
                cp.dir[i] = (XS * (helioy[i] - helioy[ind]) - YS * (heliox[i] - heliox[ind])) /
                  (XS * XS + YS * YS);
                if (ind == oEar)
                    aber = 0.0057756 * Math.Sqrt(XS * XS + YS * YS + ZS * ZS) * DFromR(cp.dir[i]); /* Aberration */
                ProcessPlanet(i, aber);
                if (us.fVelocity)                         /* Use relative velocity */
                    cp.dir[i] = RFromD(cp.dir[i] / helioret[i]);    /* if -v0 is in effect   */
            }
            spacex[ind] = spacey[ind] = spacez[ind] = 0.0;
        }

        /*
        ******************************************************************************
        ** Lunar Position Calculations
        ******************************************************************************
        */

        /* Calculate the position and declination of the Moon, and the Moon's North  */
        /* Node. This has to be done separately from the other planets, because they */
        /* all orbit the Sun, while the Moon orbits the Earth.                       */

        void ComputeLunar(ref double moonlo, ref double moonla, ref double nodelo, ref double nodela)
        {
            double LL, G, N, G1, D, L, ML, L1, MB, T1, Y, M = 3600.0, T2;

            T2 = iset.T * iset.T;
            LL = 973563.0 + 1732564379.0 * iset.T - 4.0 * T2; /* Compute mean lunar longitude    */
            G = 1012395.0 + 6189.0 * iset.T;              /* Sun's mean longitude of perigee */
            N = 933060.0 - 6962911.0 * iset.T + 7.5 * T2;     /* Compute mean lunar node         */
            G1 = 1203586.0 + 14648523.0 * iset.T - 37.0 * T2; /* Mean longitude of lunar perigee */
            D = 1262655.0 + 1602961611.0 * iset.T - 5.0 * T2; /* Mean elongation of Moo from Sun */
            L = (LL - G1) / M; L1 = ((LL - D) - G) / M;       /* Some auxiliary angles           */
            T1 = (LL - N) / M; D = D / M; Y = 2.0 * D;

            /* Compute Moon's perturbations. */

            ML = 22639.6 * RSinD(L) - 4586.4 * RSinD(L - Y) + 2369.9 * RSinD(Y) +
              769.0 * RSinD(2.0 * L) - 669.0 * RSinD(L1) - 411.6 * RSinD(2.0 * T1) -
              212.0 * RSinD(2.0 * L - Y) - 206.0 * RSinD(L + L1 - Y);
            ML += 192.0 * RSinD(L + Y) - 165.0 * RSinD(L1 - Y) + 148.0 * RSinD(L - L1) -
              125.0 * RSinD(D) - 110.0 * RSinD(L + L1) - 55.0 * RSinD(2.0 * T1 - Y) -
              45.0 * RSinD(L + 2.0 * T1) + 40.0 * RSinD(L - 2.0 * T1);

            moonlo = G = Mod((LL + ML) / M + iset.rSid);    /* Lunar longitude */

            /* Compute lunar latitude. */

            MB = 18461.5 * RSinD(T1) + 1010.0 * RSinD(L + T1) - 999.0 * RSinD(T1 - L) -
              624.0 * RSinD(T1 - Y) + 199.0 * RSinD(T1 + Y - L) - 167.0 * RSinD(L + T1 - Y);
            MB += 117.0 * RSinD(T1 + Y) + 62.0 * RSinD(2.0 * L + T1) -
              33.0 * RSinD(T1 - Y - L) - 32.0 * RSinD(T1 - 2.0 * L) - 30.0 * RSinD(L1 + T1 - Y);
            moonla = MB =
              RSgn(MB) * ((Math.Abs(MB) / M) / rDegMax - Math.Floor((Math.Abs(MB) / M) / rDegMax)) * rDegMax;

            /* Compute position of the North Lunar Node, either True or Mean. */

            if (us.fTrueNode)
                N = N + 5392.0 * RSinD(2.0 * T1 - Y) - 541.0 * RSinD(L1) - 442.0 * RSinD(Y) +
                  423.0 * RSinD(2.0 * T1) - 291.0 * RSinD(2.0 * L - 2.0 * T1);
            nodelo = Mod(N / M + iset.rSid);
            nodela = 0.0;
        }

        double RSinD(double r)
        {
            return Math.Sin(RFromD(r));
        }

        double RCosD(double r)
        {
            return Math.Cos(RFromD(r));
        }
    }
}
