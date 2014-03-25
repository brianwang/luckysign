using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AstroCSharpLib
{
    /*************************************************************
    definitions
    *************************************************************/
    public partial class CALC
    {
        const double HUGE8 = 1.7E+308;     /* biggest value for REAL8 */

        const double TANERRLIMIT = 1.0E-10;     /* used to check for arguments close to pi */
        const double NEAR_ZERO = 1.0E-16;     /* used to compare for divisors close to 0 */
        const double BIGREAL = 1.0E+38;

        const double DEGTORAD = 0.0174532925199433;
        const double RADTODEG = 57.2957795130823;

        const double DEG2MSEC = 3600000.0;  /* degree to milliseconds */
        const double DEG2CSEC = 360000.0;   /* degree to centiseconds */

        const int SEC2CSEC = 100;  /* seconds to centiseconds */

        const double CS2DEG = (1.0 / 360000.0);  /* centisec to degree */
        const double CS2CIRCLE = (CS2DEG / 360.0);  /* centisec to circle */
        const double AU2INT = 1e7;             /* factor for long storage of A.U. */

        double[] ekld = new double[4] { 23.452294, -46.845, -.0059, 0.00181 };
        /*
        * planet index numbers, used to identify a planet in calc() and
        * other related functions.
        */
        const int SUN = 0;   /* used synonymously for earth too */
        const int EARTH = 0;
        const int MOON = 1;
        const int MERCURY = 2;
        const int VENUS = 3;
        const int MARS = 4;
        const int JUPITER = 5;
        const int SATURN = 6;
        const int URANUS = 7;
        const int NEPTUNE = 8;
        const int PLUTO = 9;
        const int MEAN_NODE = 10;
        const int TRUE_NODE = 11;
        const int CHIRON = 12;
        const int LILITH = 13;
        const int CERES = 14;
        const int PALLAS = 15;
        const int JUNO = 16;
        const int VESTA = 17;

        const double NODE_INTERVAL = 0.005;        /* days, = 7m20s */
        const double MOON_SPEED_INTERVAL = 0.0001; /* 8.64 seconds later */


        const double J2000 = 2451545.0; /* Epoch of JPL ephemeris DE200, absolute */
        const double J1950 = 2433282.423;  /* Epoch of JPL ephemeris DE102 */
        const double JUL_OFFSET = 2433282.0;  /* offset of Astrodienst relative Julian date */
        const double EPOCH1850 = -36524.0;  /* jupiter,saturn 0 jan 1850, 12:00 */
        const double EPOCH1900 = -18262.0;  /* inner planets  0 jan 1900, 12:00 */
        const double EPOCH1950 = 0.0;   /* pluto    0 jan 1950, 12:00 */
        /* this is the origin of the Astrodienst
           relative julian calendar system */
        const double EPOCH1960 = 3653.0; /* uranus,neptune 1 jan 1960, 12:00 */
        const int ENDMARK = 99; /* used to mark the end of disturbation terms */

        /*
        * flag bits used in calc and calcserv
        */
        const int CALC_BIT_HELIO = 1;   /* geo/helio */
        const int CALC_BIT_NOAPP = 2;   /* apparent/true positions */
        const int CALC_BIT_NONUT = 4;   /* true eq. of date/ mean equ. of date */
        const int CALC_BIT_EPHE = 8;   /* universal/ephemeris time */
        const int CALC_BIT_SPEED = 16;  /* without/with speed */
        const int CALC_BIT_BETA = 32;  /* without/with latitude */
        const int CALC_BIT_RGEO = 64;  /* without/with relative rgeo */
        const int CALC_BIT_RAU = 128; /* without/with real radius */
        const int CALC_BIT_MUST_USE_EPHE = 256; /* epheserv may not use calc */
        const int CALC_BIT_MAY_USE_EPHE = 512; /* calcserv may use ephread */

        const int SDNUM = 20;
        const int NUM_MOON_CORR = 93;

        const int EPHE_STEP = 80;               /* days step in LRZ ephe */
        const int EPHE_DAYS_PER_FILE = 100000;  /* days per ephe file */
        const string EPHE_OUTER = "LRZ5_";      /* file name prefix */
        const int EPHE_OUTER_BSIZE = 60;        /* blocksize */
        const string EPHE_CHIRON = "CHI_";      /* file name prefix */
        const int EPHE_CHIRON_BSIZE = 12;       /* blocksize */
        const string EPHE_ASTER = "CPJV_";      /* file name prefix */
        const int EPHE_ASTER_BSIZE = 48;        /* blocksize */

        /* actual elements at time thelup */
        class elements
        {
            public double tj,     /* centuries from epoch */
             lg,     /* mean longitude in degrees of arc*/
             pe,     /* longitude of the perihelion in degrees of arc*/
             ex,     /* excentricity in degrees of arc*/
             kn,     /* longitude of node in degrees of arc*/
             inc,     /* inclination of the orbit in degrees of arc*/
             ma;     /* mean anomaly in degrees of arc*/
        }

        class eledata
        {
            public double axis,   /* mean distance, in a.u., A(N) in basic */
            period,   /* days for one revolution, P(N) in basic */
            epoch,    /* relative juldate of epoch, Ep(N) in basic */
                /* T = distance to epoch in jul.centuries 36525 day*/
            lg0, lg1, lg2, lg3,/* deg(epoch), degree/day, seconds/T^2,seconds/T^3 */
                /* Pd(N,0..2) in basic, lg3 was not present */
            pe0, pe1, pe2, pe3,/* deg(epoch), seconds/T,  seconds/T^2,seconds/T^3 */
                /* Pd(N,3..5) in basic, pe3 was not present */
            ex0, ex1, ex2,  /* ecl(epoch), 1/T, 1/T^2 */
                /* Pd(N,6..8) in basic */
            kn0, kn1, kn2, kn3,/* node(epoch),seconds/T,  seconds/T^2,seconds/T^3 */
                /* Pd(N,9..11) in basic, kn3 was not present */
            in0, in1, in2;    /* incl(epoch),1/T, 1/T^2 */
            /* Pd(N,12..14) in basic */
        }


        class kor
        {
            public int j, i;
            public double lampl;  /* amplitude of disturbation in long, seconds of arc */
            public double lphase;   /* phase of disturbation in long, degrees */
            public int rampl;  /* ampl. of disturbation in radius, 9th place of log */
            public double rphase; /* phase of disturbation in radius, degrees */
            public int k;      /* index into disturbing planet anomaly table sa[] */
        }

        class sdat
        {   /* 0..19 mean anomalies of disturbing planets
  Sd(0..19,0..1) in basic */
            public double sd0,  /* mean anomaly at epoch 1850 */
            sd1;  /* degrees/year */
        }

        /* moon correction data; revised 30-jul-88: all long. to 0.3" */
        class m45dat
        {
            public int i0, i1, i2, i3;
            public double lng, lat, par;
        }

        class rememberdat
        {
            public rememberdat()
            {
                this.calculation_time = HUGE8;
                this.lng = HUGE8;
                this.rad = HUGE8;
                this.zet = HUGE8;
                this.lngspeed = HUGE8;
                this.radspeed = HUGE8;
                this.zetspeed = HUGE8;
            }
            public double calculation_time, lng, rad, zet, lngspeed, radspeed, zetspeed;
        }

        elements[] el = new elements[MARS + 1];
        eledata[] pd = new eledata[MARS + 1];
        m45dat[] m45 = new m45dat[NUM_MOON_CORR];

        double meanekl, ekl, nut;

        double[] sa = new double[SDNUM];

        sdat[] _sd = new sdat[SDNUM] {
            new sdat { sd0 = 114.50, sd1=  585.17493},
            new sdat { sd0 =109.856,  sd1= 191.39977},
            new sdat { sd0 =148.031,  sd1= 30.34583},
            new sdat { sd0 =284.716, sd1=  12.21794},
            new sdat { sd0 =114.508, sd1=  585.17656},
            new sdat { sd0 =-0.56,   sd1=  359.99213},
            new sdat { sd0 =148.03, sd1=   30.34743},
            new sdat { sd0 =284.72, sd1=   12.2196},
            new sdat { sd0 =248.07,  sd1=  1494.726615},
            new sdat { sd0 =359.44,  sd1=  359.993595},
            new sdat { sd0 =109.86,  sd1=  191.402867},
            new sdat { sd0 =148.02,  sd1=  30.348930},
            new sdat { sd0 =114.503, sd1=  585.173715},
            new sdat { sd0 =359.444,  sd1= 359.989285},
            new sdat { sd0 =148.021,  sd1= 30.344620},
            new sdat { sd0 =284.716,  sd1= 12.21669},
            new sdat { sd0 =148.0315, sd1= 30.34906264},
            new sdat { sd0 =284.7158, sd1= 12.22117085},
            new sdat { sd0 =220.1695, sd1= 4.284931111},
            new sdat { sd0 =291.8024, sd1= 2.184704167}
        };


        double SINDEG(double x)
        {
            return Math.Sin(DEGTORAD * (x));
        }

        double COSDEG(double x)
        {
            return Math.Cos(DEGTORAD * (x));
        }

        double TANDEG(double x)
        {
            return Math.Tan(DEGTORAD * (x));
        }
    }
}
