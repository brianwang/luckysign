using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AstroCSharpLib
{
    public partial class CALC
    {
        rememberdat earthrem = new rememberdat();
        rememberdat moonrem = new rememberdat();
        double thelup = HUGE8;  /* is initialized only once at load time */

        int calc(int planet, double jd_ad, int flag, ref double alng, ref double arad, ref double alat, ref double alngspeed)
        {

            double c, s, x, knn, knv;
            double rp = 0.0, zp = 0.0; /* needed to call hel! */
            double azet = alat;
            bool calc_geo, calc_helio, calc_apparent, calc_speed, calc_nut;

            /* helup checks whether it was already called with same time */
            helup(jd_ad);
            /* we could return now if we only wanted to compute ecl and nut */

            calc_helio = (flag & CALC_BIT_HELIO) != 0;
            calc_geo = !calc_helio;
            calc_apparent = (flag & CALC_BIT_NOAPP) == 0;
            calc_nut = (flag & CALC_BIT_NONUT) == 0;
            calc_speed = (flag & CALC_BIT_SPEED) != 0;
            /*
            ** it is necessary to compute EARTH in the following cases:
            ** heliocentric MOON or EARTH
            ** geocentric any planet except MOON or nodes or LILITH
            */
            if (calc_helio && (planet == MOON || planet == EARTH)
              || calc_geo && planet != MOON
              && planet != MEAN_NODE
              && planet != TRUE_NODE
              && planet != LILITH)
            {
                if (earthrem.calculation_time != jd_ad)
                {
                    hel(EARTH, jd_ad, ref alng, ref arad, ref azet, ref alngspeed, ref rp, ref zp);
                    /* store earthdata for geocentric calculation: */
                    earthrem.lng = alng;
                    earthrem.rad = arad;
                    earthrem.zet = azet;
                    earthrem.lngspeed = alngspeed;
                    earthrem.radspeed = rp;
                    earthrem.zetspeed = zp;
                    earthrem.calculation_time = jd_ad;
                }
            }
            switch (planet)
            {

                case EARTH: /* has been already computed */
                    alng = earthrem.lng;
                    arad = earthrem.rad;
                    azet = earthrem.zet;
                    alngspeed = earthrem.lngspeed;
                    rp = earthrem.radspeed;
                    zp = earthrem.zetspeed;
                    if (calc_geo)
                    { /* SUN seen from earth */
                        alng = smod8360(alng + 180.0);
                        azet = -azet;
                    }
                    if (calc_apparent)
                        alng = alng - 0.0057683 * (arad) * (alngspeed);
                    break;

                case MOON:
                    moon(ref alng, ref arad, ref azet);
                    moonrem.lng = alng;  /* moonrem will be used for TRUE_NODE */
                    moonrem.rad = arad;
                    moonrem.zet = azet;
                    alngspeed = 12;
                    moonrem.calculation_time = jd_ad;
                    if (calc_helio || calc_speed)
                    {/* get a second moon position */
                        double lng2 = 0.0, rad2 = 0.0, zet2 = 0.0;
                        helup(jd_ad + MOON_SPEED_INTERVAL);
                        moon(ref lng2, ref rad2, ref zet2);
                        helup(jd_ad);
                        if (calc_helio)
                        { /* moon as seen from sun */
                            togeo(earthrem.lng, -earthrem.rad, moonrem.lng, moonrem.rad,
                            moonrem.zet, ref alng, ref arad);
                            togeo(earthrem.lng + MOON_SPEED_INTERVAL * earthrem.lngspeed,
                            -(earthrem.rad + MOON_SPEED_INTERVAL * earthrem.radspeed),
                            lng2, rad2, zet2, ref lng2, ref rad2);
                        }
                        alngspeed = diff8360(lng2, alng) / MOON_SPEED_INTERVAL;
                        /* rp = (rad2 - *arad) / MOON_SPEED_INTERVAL;       */
                        /* zp = (zet2 - moonrem.zet) / MOON_SPEED_INTERVAL; */
                    }
                    alat = RADTODEG * Math.Asin(azet / arad);
                    /*
                    ** light time correction, not applied for moon or nodes;
                    ** moon would have only term of ca. 0.02", see Expl.Sup.1961 p.109
                    */
                    break;

                case MERCURY:
                case VENUS:
                case MARS:
                case JUPITER:
                case SATURN:
                case URANUS:
                case NEPTUNE:
                case PLUTO:
                case CHIRON:
                case CERES:
                case PALLAS:
                case JUNO:
                case VESTA:
                    if (hel(planet, jd_ad, ref alng, ref arad, ref azet, ref alngspeed, ref rp, ref zp) != 0)
                        return -1; /* outer planets can fail if out of ephemeris range */
                    if (calc_geo)
                    {       /* geocentric */
                        double lng1 = 0.0, rad1 = 0.0, lng2 = 0.0, rad2 = 0.0;
                        togeo(earthrem.lng, earthrem.rad, alng, arad, azet, ref lng1, ref rad1);
                        togeo(earthrem.lng + earthrem.lngspeed,
                        earthrem.rad + earthrem.radspeed,
                        alng + alngspeed, arad + rp, azet + zp, ref lng2, ref rad2);
                        alng = lng1;
                        arad = rad1;
                        alngspeed = diff8360(lng2, lng1);
                        /* rp = rad2 - rad1; */
                    }
                    alat = RADTODEG * Math.Asin(azet / arad);
                    if (calc_apparent)
                        alng = alng - 0.0057683 * arad * alngspeed;
                    break;

                case MEAN_NODE:
                    alng = smod8360(el[MOON].kn);
                    /*
                    * the distance of the node is the 'orbital parameter' p = a (1-e^2);
                    * Our current use of the axis a is wrong, but is never used.
                    */
                    arad = pd[MOON].axis;
                    alat = 0.0;
                    alngspeed = -0.053;
                    break;

                case TRUE_NODE:
                    {
                        /* see comment 'Note 7 May 1991' above */
                        double ln = 0, rn = 0, zn = 0,
                        lv = 0, rv = 0, zv = 0,
                        l1 = 0, r1 = 0, z1 = 0,
                        xn, yn, xv, yv, r0, x0, y0;

                        helup(jd_ad + NODE_INTERVAL);
                        moon(ref ln, ref rn, ref zn);
                        helup(jd_ad - NODE_INTERVAL);
                        moon(ref lv, ref rv, ref zv);
                        helup(jd_ad);
                        if (moonrem.calculation_time != jd_ad)
                            moon(ref l1, ref r1, ref z1);
                        else
                        {  /* moon is already calculated */
                            l1 = moonrem.lng;
                            r1 = moonrem.rad;
                            z1 = moonrem.zet;
                        }
                        rn = Math.Sqrt(rn * rn - zn * zn);
                        rv = Math.Sqrt(rv * rv - zv * zv);
                        r0 = Math.Sqrt(r1 * r1 - z1 * z1);
                        xn = rn * Math.Cos(DEGTORAD * ln);
                        yn = rn * Math.Sin(DEGTORAD * ln);
                        xv = rv * Math.Cos(DEGTORAD * lv);
                        yv = rv * Math.Sin(DEGTORAD * lv);
                        x0 = r0 * Math.Cos(DEGTORAD * l1);
                        y0 = r0 * Math.Sin(DEGTORAD * l1);
                        x = test_near_zero(x0 * yn - xn * y0);
                        s = (y0 * zn - z1 * yn) / x;
                        c = test_near_zero((x0 * zn - z1 * xn) / x);
                        knn = smod8360(RADTODEG * Math.Atan2(s, c)); /* = ATAN8(s / c) */
                        x = test_near_zero(y0 * xv - x0 * yv);
                        s = (yv * z1 - zv * y0) / x;
                        c = test_near_zero((xv * z1 - zv * x0) / x);
                        knv = smod8360(RADTODEG * Math.Atan2(s, c));
                        alng = smod8360((knv + knn) / 2);
                        /*
                        ** the distance of the node is the 'orbital parameter' p = a (1-e^2);
                        ** Our current use of the axis a is wrong.
                        */
                        arad = pd[MOON].axis;
                        alat = 0.0;
                        alngspeed = diff8360(knn, knv) / NODE_INTERVAL;
                    }
                    break;

                case LILITH:
                    {
                        /*
                        ** Added 22-Jun-93
                        ** Lilith or Dark Moon is the empty focal point of the mean lunar ellipse.
                        ** This is 180 degrees from the perihel.
                        ** Because the lunar orbit is not in the ecliptic, it must be
                        ** projected onto the ecliptic in the same way as the planetary orbits
                        ** are (see for example Montenbruck, Grundlagen der Ephemeridenrechnung).
                        **
                        ** We compute the MEAN Lilith, not the TRUE one which would have to be
                        ** derived in a similar way as the true node.
                        ** For the radius vector of Lilith we use a simple formula;
                        ** to get a precise value, the fact that the focal point of the ellipse
                        ** is not at the center of the earth but at the barycenter moon-earth
                        ** would have to be accounted for.
                        ** For the speed we always return a constant: the T term from the
                        ** lunar perihel.
                        ** Joelle de Gravelaine publishes in her book "Lilith der schwarze Mond"
                        ** (Astrodata, 1990) an ephemeris which gives noon (12.00) positions
                        ** but does not project onto the ecliptic.
                        ** This creates deviations
                        */
                        double arg_lat, lon, cosi;
                        elements e = el[MOON];
                        arg_lat = degnorm(e.pe - e.kn + 180.0);
                        cosi = COSDEG(e.inc);
                        if (e.inc == 0 || Math.Abs(arg_lat - 90.0) < TANERRLIMIT
                          || Math.Abs(arg_lat - 270.0) < TANERRLIMIT)
                        {
                            lon = arg_lat;
                        }
                        else
                        {
                            lon = Math.Atan(TANDEG(arg_lat) * cosi);
                            lon = RADTODEG * lon;
                            if (arg_lat > 90.0 && arg_lat < 270.0) lon += 180.0;
                        }
                        lon = degnorm(lon + e.kn);
                        alng = lon;
                        alngspeed = 0.111404;  /* 6'41.05" per day */
                        arad = 2 * pd[MOON].axis * e.ex;
                        /*
                        ** To test Gravalaines error, return unprojected long in alat.
                        ** the correct latitude would be:
                        ** *alat = RADTODEG * ASIN8(SINDEG(arg_lat) * SINDEG(e->in));
                        */
                        alat = RADTODEG * Math.Sin(SINDEG(arg_lat) * SINDEG(e.inc));
                    }
                    break;

                default:
                    return -1;
            } /* end switch */

            if (calc_nut)
                alng += nut;
            alng = smod8360(alng);  /* normalize to circle */
            return 0;
        }


        /* helio to geocentric conversion */
        void togeo(double lngearth, double radearth, double lng, double rad, double zet, ref double alnggeo, ref double aradgeo)
        {
            double r1, x, y;

            r1 = Math.Sqrt(rad * rad - zet * zet);
            x = r1 * Math.Cos(DEGTORAD * lng) - radearth * Math.Cos(DEGTORAD * lngearth);
            y = r1 * Math.Sin(DEGTORAD * lng) - radearth * Math.Sin(DEGTORAD * lngearth);
            aradgeo = Math.Sqrt(x * x + y * y + zet * zet);
            x = test_near_zero(x);
            alnggeo = smod8360(RADTODEG * Math.Atan2(y, x));
        }

        /*
        ** helup()
        ** prepares the orbital elements and the disturbation arguments for the
        ** inner planets and the moon. helup(t) is called by hel() and by calc().
        ** helup() returns its results in global variables.
        ** helup() remembers the t it has been called with before and does
        ** not recalculate its results when it is called more than once with
        ** the same t.
        */
        void helup(double jd_ad)
        {
            int i = 0;
            elements ee = el[EARTH];     /* pointer to el[EARTH] */
            double td, ti, ti2, tj1, tj2, tj3;

            if (thelup == jd_ad)
                return; /* if already calculated then return */

            for (i = SUN; i <= MARS; i++)
            {
                td = jd_ad - pd[i].epoch;
                ti = el[i].tj = td / 36525.0;  /* julian centuries from epoch */
                ti2 = ti * ti;
                tj1 = ti / 3600.0;  /* used when coefficients are in seconds of arc */
                tj2 = ti * tj1;
                tj3 = ti * tj2;
                el[i].lg = mod8360(pd[i].lg0 + pd[i].lg1 * td + pd[i].lg2 * tj2 + pd[i].lg3 * tj3);
                /* also with moon lg1 *td is exact to 10e-8 degrees within 5000 years */
                el[i].pe = mod8360(pd[i].pe0 + pd[i].pe1 * tj1 + pd[i].pe2 * tj2 + pd[i].pe3 * tj3);
                el[i].ex = pd[i].ex0 + pd[i].ex1 * ti + pd[i].ex2 * ti2;
                el[i].kn = mod8360(pd[i].kn0 + pd[i].kn1 * tj1 + pd[i].kn2 * tj2 + pd[i].kn3 * tj3);
                el[i].inc = pd[i].in0 + pd[i].in1 * tj1 + pd[i].in2 * tj2;
                el[i].ma = smod8360(el[i].lg - el[i].pe);

                if (i == MOON)
                {
                    /* calculate ekliptic according Newcomb, APAE VI,
                    ** and nutation according Exp.Suppl. 1961, identical
                    ** with Mark Potttenger elemnut()
                    ** all terms >= 0.01" only .
                    ** The 1984 IAU Theory of Nutation, as published in
                    ** AE 1984 suppl. has not yet been implemented
                    ** because it would mean to use other elements of
                    ** moon and sun */

                    double mnode, mlong2, slong2, mg, sg, d2;

                    mnode = DEGTORAD * el[i].kn;        /* moon's mean node */
                    mlong2 = DEGTORAD * 2.0 * el[i].lg;  /* 2 x moon's mean longitude */
                    mg = DEGTORAD * el[i].ma;        /* moon's mean anomaly (g1) */
                    slong2 = DEGTORAD * 2.0 * el[i].lg; /* 2 x sun's mean longitude (L), with
                                                  the phase 180 deg earth-sun irrelevant
                                                  because 2 x 180 = 360 deg */
                    sg = DEGTORAD * ee.ma; /* sun's mean anomaly = earth's */
                    d2 = mlong2 - slong2;   /* 2 x elongation of moon from sun */
                    meanekl = ekld[0] + ekld[1] * tj1 + ekld[2] * tj2 + ekld[3] * tj3;
                    ekl = meanekl +
                      (9.2100 * Math.Cos(mnode)
                      - 0.0904 * Math.Cos(2.0 * mnode)
                      + 0.0183 * Math.Cos(mlong2 - mnode)
                      + 0.0884 * Math.Cos(mlong2)
                      + 0.0113 * Math.Cos(mlong2 + mg)
                      + 0.5522 * Math.Cos(slong2)
                      + 0.0216 * Math.Cos(slong2 + sg)) / 3600.0;
                    nut = ((-17.2327 - 0.01737 * ti) * Math.Sin(mnode)
                    + 0.2088 * Math.Sin(2.0 * mnode)
                    + 0.0675 * Math.Sin(mg)
                    - 0.0149 * Math.Sin(mg - d2)
                    - 0.0342 * Math.Sin(mlong2 - mnode)
                    + 0.0114 * Math.Sin(mlong2 - mg)
                    - 0.2037 * Math.Sin(mlong2)
                    - 0.0261 * Math.Sin(mlong2 + mg)
                    + 0.0124 * Math.Sin(slong2 - mnode)
                    + 0.0214 * Math.Sin(slong2 - sg)
                    - 1.2729 * Math.Sin(slong2)
                    - 0.0497 * Math.Sin(slong2 + sg)
                    + 0.1261 * Math.Sin(sg)) / 3600.0;
                }
            }

            /* calculate the arguments sa[] for the disturbation terms */
            ti = (jd_ad - EPOCH1850) / 365.25;  /* julian years from 1850 */
            for (i = 0; i < _sd.Length; i++)
                sa[i] = mod8360(_sd[i].sd0 + _sd[i].sd1 * ti);
            /*
            ** sa[2] += 0.3315 * SIN8 (DEGTORAD *(133.9099 + 38.39365 * el[SUN].tj));
            **
            ** correction of jupiter perturbation argument for sun from Pottenger;
            ** creates only .03" and 1e-7 rad, not applied because origin unclear */
            thelup = jd_ad;               /* note the last helup time */
        }


        /*
        ** hel()
        ** Computes the heliocentric positions for all planets except the moon.
        ** The outer planets from Jupiter onwards, including Chiron, are
        ** actually done by a subsequent call to outer_hel() which takes
        ** exactly the same parameters.
        ** hel() does true position relative to the mean ecliptic and equinox
        ** of date. Nutation is not added and must be done so by the caller.
        ** The latitude of the Sun (max. 0.5") is neglected and always returned
        ** as zero.
        **
        ** return: OK or ERR
        */

        //int planet;   /* planet index as defined by placalc.h */
        //REAL8 t;      /* relative juliand date, ephemeris time */
        //              /* Now come 6 pointers to return values. */
        //REAL8 *al;    /* longitude in degrees */
        //REAL8 *ar;    /* radius in AU */
        //REAL8 *az;    /* distance from ecliptic in AU */
        //REAL8 *alp;   /* speed in longitude, degrees per day */
        //REAL8 *arp;   /* speed in radius, AU per day */
        //REAL8 *azp;   /* speed in z, AU per day */
        int hel(int planet, double t, ref double al, ref double ar, ref double az, ref double alp, ref double arp, ref double azp)
        {
            //elements e;
            //eledata  d;
            //double lk = 0.0;
            //double rk = 0.0;
            //double b, h1, sini, sinv, cosi, cosu, cosv, man, truanom, esquare,
            //  k8, u, up, v, vp;

            //if (planet >= JUPITER)
            //  return (outer_hel(planet, t, al, ar, az, alp, arp, azp));
            //if (planet < SUN || planet == MOON)
            //  return -1;

            //e = el[planet];
            //d = pd[planet];
            //sini = Math.Sin(DEGTORAD * e.inc);
            //cosi = Math.Cos(DEGTORAD * e.inc);
            //esquare = Math.Sqrt((1.0 + e.ex) / (1.0 - e.ex)); /* H6 in old version */
            //man = e.ma;
            //if (planet == EARTH)  /* some longperiodic terms in mean longitude */
            //  man += (0.266 * Math.Sin (DEGTORAD * (31.8 + 119.0 * e.tj))
            //    + 6.40 * Math.Sin(DEGTORAD * (231.19 + 20.2 * e.tj))
            //    + (1.882-0.016*e.tj) * Math.Sin(DEGTORAD * (57.24 + 150.27 * e.tj))
            //    ) / 3600.0;
            //if (planet == MARS)  /* some longperiodic terms */
            //  man += (0.606 * Math.Sin(DEGTORAD * (212.87 + e.tj * 119.051))
            //    + 52.490 * Math.Sin(DEGTORAD * (47.48 + e.tj * 19.771))
            //    +  0.319 * Math.Sin(DEGTORAD * (116.88 + e.tj * 773.444))
            //    +  0.130 * Math.Sin(DEGTORAD * (74 + e.tj * 163))
            //    +  0.280 * Math.Sin(DEGTORAD * (300 + e.tj * 40.8))
            //    -  (37.05 +13.5 * e.tj)
            //    ) / 3600.0;
            //u = fnu (man, e.ex, 0.0000003); /* error 0.001" returns radians */
            //cosu = Math.Cos(u);
            //h1 = 1 - e.ex * cosu;
            //ar = d.axis * h1;
            //if (Math.Abs(rPi - u) < TANERRLIMIT)
            //  truanom = u; /* very close to aphel */
            //else
            //  truanom = 2.0 * ATAN8(esquare * TAN8(u * 0.5)); /* true anomaly, rad*/
            //v = smod8360(truanom * RADTODEG + e->pe - e->kn); /* argument of latitude */
            //if (sini == 0.0 || ABS8(v -  90.0) < TANERRLIMIT
            //  || ABS8(v - 270.0) < TANERRLIMIT) {
            //  *al = v;
            //} else {
            //  *al = RADTODEG * ATAN8(TAN8(v * DEGTORAD) * cosi);
            //  if (v > 90.0 && v < 270.0)  *al += 180.0;
            //}
            //*al = smod8360(*al + e->kn);
            //sinv = SIN8(v * DEGTORAD);
            //cosv = COS8(v * DEGTORAD);
            //*az = *ar * sinv * sini;
            //b = ASIN8(sinv * sini);     /* latitude in radians */
            //k8 = cosv / COS8(b) * sini;
            //up = 360.0 / d->period / h1;    /* du/dt degrees/day */
            //if (ABS8(rPi - u) < TANERRLIMIT)
            //  vp = up / esquare;  /* speed at aphel */
            //else
            //  vp = up * esquare * (1 + COS8 (truanom)) / (1 + cosu);
            ///* dv/dt degrees/day */
            //*arp = d->axis * up * DEGTORAD * SIN8(u) * e->ex;
            ///* dr/dt AU/day */
            //*azp = *arp * sinv * sini + *ar * vp * DEGTORAD * cosv * sini;  /* dz/dt */
            //*alp = vp / cosi * (1 - k8 * k8);

            ///* now come the disturbations */
            //      double am, mma, ema, u2;
            //switch (planet) {


            //case EARTH:
            //  /*
            //  ** earth has some special moon values and a disturbation series due to the
            //  ** planets. The moon stuff is due to the fact, that the mean elements
            //  ** give the coordinates of the earth-moon barycenter. By adding the
            //  ** corrections we effectively reduce to the center of the earth.
            //  ** We neglect the correction in latitude, which is about 0.5", because
            //  ** for astrological purposes we want the Sun to have latitude zero.
            //  */
            //  am = DEGTORAD * smod8360(el[MOON].lg - e->lg + 180.0); /* degrees */
            //  mma = DEGTORAD * el[MOON].ma;
            //  ema = DEGTORAD * e->ma;
            //  u2 = 2.0 * DEGTORAD * (e->lg - 180.0 - el[MOON].kn); /* 2u' */
            //  lk = 6.454 * SIN8(am)
            //    + 0.013 * SIN8(3.0 * am)
            //    + 0.177 * SIN8(am + mma)
            //    - 0.424 * SIN8(am - mma)
            //    + 0.039 * SIN8(3.0 * am - mma)
            //    - 0.064 * SIN8(am + ema)
            //    + 0.172 * SIN8(am - ema)
            //    - 0.013 * SIN8(am - mma - ema)
            //    - 0.013 * SIN8(u2);
            //  rk = 13360 * COS8(am)
            //    + 30    * COS8(3.0 * am)
            //    + 370   * COS8(am + mma)
            //    - 1330  * COS8(am - mma)
            //    + 80    * COS8(3.0 * am - mma)
            //    - 140   * COS8(am + ema)
            //    + 360   * COS8(am - ema)
            //    - 30    * COS8(am - mma - ema)
            //    + 30    * COS8(u2);
            //  /* long periodic term from mars 15g''' - 8g'', Vol 6 p19, p24 */
            //  lk += 0.202 * SIN8(DEGTORAD * (315.6 + 893.3 * e->tj));
            //  disturb(earthkor, al, ar, lk, rk, man);
            //  break;

            //case MERCURY:  /* only normal disturbation series */
            //  disturb(mercurykor, al, ar, 0.0, 0.0, man);
            //  break;

            //case VENUS:  /* some longperiod terms and normal series */
            //  lk = (2.761 - 0.22*e->tj) * SIN8(DEGTORAD * (237.24 + 150.27 * e->tj))
            //  + 0.269 * SIN8(DEGTORAD * (212.2  + 119.05 * e->tj))
            //  - 0.208 * SIN8(DEGTORAD * (175.8  + 1223.5 * e->tj));
            //  /* make seconds */
            //  disturb(venuskor, al, ar, lk, 0.0, man);
            //  break;

            //case MARS:  /* only normal disturbation series */
            //  disturb(marskor, al, ar, 0.0, 0.0, man);
            //  break;
            //}
            return 0;
        }

        //register struct kor *k;  /* ENDMARK-terminated array of struct kor */
        //REAL8 *al, /* longitude in degrees, use a pointer to return value */
        //*ar;       /* radius in AU */
        //REAL8 lk,  /* longitude correction in SECONDS OF ARC */
        //           /* function can be called with an lk and rk already
        //              != 0, but no value is returned */
        //rk,        /* radius correction in units of 9th place of log r */
        //man;       /* mean anomaly of planet */
        void disturb(kor[] k, ref double al, ref double ar, double lk, double rk, double man)
        {
            double arg;
            for (int i = 0; i < k.Length; i++)
            {
                arg = k[i].j * sa[k[i].k] + k[i].i * man;
                lk += k[i].lampl * Math.Cos(DEGTORAD * (k[i].lphase - arg));
                rk += k[i].rampl * Math.Cos(DEGTORAD * (k[i].rphase - arg));
            }
            ar *= Math.Pow(10.0f, rk * 1.0E-9);  /* 10^rk */
            al += lk / 3600.0;
        }

        int moon(ref double al, ref double ar, ref double az)  /* return OK or ERR */
        {
            double a1, a2, a3, a4, a5, a6, a7, a8, a9, c2, c4, arg, b, d, f, dgc, dlm, dpm, dkm, dls;
            double ca, cb, cd, f_2d, f_4d, g1c, lk, lk1, man, ms, nib, s, sinarg, sinp, sk;
            double t, tb, t2c, r2rad, i1corr, i2corr, dlid;
            int i;
            elements e = el[MOON];

            t = e.tj * 36525;  /* days from epoch 1900 */

            /* new format table II, parameters in full rotations of 360 degrees */
            r2rad = 360.0 * DEGTORAD;
            tb = t * 1e-12;  /* units of 10^12 */
            t2c = t * t * 1e-16;  /* units of 10^16 */
            a1 = Math.Sin(r2rad * (0.53733431 - 10104982 * tb + 191 * t2c));
            a2 = Math.Sin(r2rad * (0.71995354 - 147094228 * tb + 43 * t2c));
            c2 = Math.Cos(r2rad * (0.71995354 - 147094228 * tb + 43 * t2c));
            a3 = Math.Sin(r2rad * (0.14222222 + 1536238 * tb));
            a4 = Math.Sin(r2rad * (0.48398132 - 147269147 * tb + 43 * t2c));
            c4 = Math.Cos(r2rad * (0.48398132 - 147269147 * tb + 43 * t2c));
            a5 = Math.Sin(r2rad * (0.52453688 - 147162675 * tb + 43 * t2c));
            a6 = Math.Sin(r2rad * (0.84536324 - 11459387 * tb));
            a7 = Math.Sin(r2rad * (0.23363774 + 1232723 * tb + 191 * t2c));
            a8 = Math.Sin(r2rad * (0.58750000 + 9050118 * tb));
            a9 = Math.Sin(r2rad * (0.61043085 - 67718733 * tb));

            dlm = 0.84 * a3 + 0.31 * a7 + 14.27 * a1 + 7.261 * a2 + 0.282 * a4
              + 0.237 * a6;
            dpm = -2.1 * a3 - 2.076 * a2 - 0.840 * a4 - 0.593 * a6;
            dkm = 0.63 * a3 + 95.96 * a2 + 15.58 * a4 + 1.86 * a5;
            dls = -6.4 * a3 - 0.27 * a8 - 1.89 * a6 + 0.20 * a9;
            dgc = (-4.318 * c2 - 0.698 * c4) / 3600.0 / 360.0;  /* in revolutions */
            dgc = (1.000002708 + 139.978 * dgc);  /* in this form used later */
            man = DEGTORAD * (e.ma + (dlm - dpm) / 3600.0);
            /* man with periodic and secular corr. */
            ms = DEGTORAD * (el[EARTH].ma + dls / 3600.0);
            f = DEGTORAD * (e.lg - e.kn + (dlm - dkm) / 3600.0);
            d = DEGTORAD * (e.lg + 180 - el[EARTH].lg + (dlm - dls) / 3600.0);

            lk = lk1 = sk = sinp = nib = g1c = 0;
            i1corr = 1.0 - 6.8320E-8 * t;
            i2corr = dgc * dgc; /* i2 occurs only as -2, 2 */
            for (i = 0; i < m45.Length; i++)
            {
                /* arg = mp->i0 * man + mp->i1 * ms + mp->i2 * f + mp->i3 * d; */
                arg = m45[i].i0 * man;
                arg += m45[i].i3 * d;
                arg += m45[i].i2 * f;
                arg += m45[i].i1 * ms;
                sinarg = Math.Sin(arg);
                /*
                ** now apply corrections due to changes in constants;
                ** we correct only terms in l' (i1) and F (i2), not in l (i0), because
                ** the latter are < 0.05"
                ** We don't apply corrections  for cos(arg), i.e. for parallax
                */
                if (m45[i].i1 != 0)
                {  /* i1 can be -2, -1, 0, 1, 2 */
                    sinarg *= i1corr;
                    if (m45[i].i1 == 2 || m45[i].i1 == -2)
                        sinarg *= i1corr;
                }
                if (m45[i].i2 != 0)  /* i2 can be -2, 0, 2 */
                    sinarg *= i2corr;
                lk += m45[i].lng * sinarg;
                sk += m45[i].lat * sinarg;
                sinp += m45[i].par * Math.Cos(arg);
            }

            /*
            ** now compute some planetary terms in longitude, list i delta;
            ** we take all > 0.5" and neglect secular terms in the arguments. These
            ** produce phase errors > 10 degrees only after 3000 years.
            */
            dlid = 0.822 * Math.Sin(r2rad * (0.32480 - 0.0017125594 * t));
            dlid += 0.307 * Math.Sin(r2rad * (0.14905 - 0.0034251187 * t));
            dlid += 0.348 * Math.Sin(r2rad * (0.68266 - 0.0006873156 * t));
            dlid += 0.662 * Math.Sin(r2rad * (0.65162 + 0.0365724168 * t));
            dlid += 0.643 * Math.Sin(r2rad * (0.88098 - 0.0025069941 * t));
            dlid += 1.137 * Math.Sin(r2rad * (0.85823 + 0.0364487270 * t));
            dlid += 0.436 * Math.Sin(r2rad * (0.71892 + 0.0362179180 * t));
            dlid += 0.327 * Math.Sin(r2rad * (0.97639 + 0.0001734910 * t));

            /* without nutation */
            al = smod8360(e.lg + (dlm + lk + lk1 + dlid) / 3600.0);

            /* solar Terms in latitude Nibeta */
            f_2d = f - 2.0 * d;
            f_4d = f - 4.0 * d;
            nib += -526.069 * Math.Sin(f_2d);
            nib += -3.352 * Math.Sin(f_4d);
            nib += 44.297 * Math.Sin(man + f_2d);
            nib += -6.000 * Math.Sin(man + f_4d);
            nib += 20.599 * Math.Sin(-man + f);
            nib += -30.598 * Math.Sin(-man + f_2d);
            nib += -24.649 * Math.Sin(-2 * man + f);
            nib += -2.000 * Math.Sin(-2 * man + f_2d);
            nib += -22.571 * Math.Sin(ms + f_2d);
            nib += 10.985 * Math.Sin(-ms + f_2d);

            /* new gamma1C from 29 Jul 88, all terms > 0.4 " in table III, code 2 */
            g1c += -0.725 * Math.Cos(d);
            g1c += 0.601 * Math.Cos(2 * d);
            g1c += 0.394 * Math.Cos(3 * d);
            g1c += -0.445 * Math.Cos(man + 4 * d);
            g1c += 0.455 * Math.Cos(man + 1 * d);
            g1c += 5.679 * Math.Cos(2 * man - 2 * d);
            g1c += -1.300 * Math.Cos(3 * man);
            g1c += -1.302 * Math.Cos(ms);
            g1c += -0.416 * Math.Cos(ms - 4 * d);
            g1c += -0.740 * Math.Cos(2 * ms - 2 * d);
            g1c += 0.787 * Math.Cos(man + ms + 2 * d);
            g1c += 0.461 * Math.Cos(man + ms);
            g1c += 2.056 * Math.Cos(man + ms - 2 * d);
            g1c += -0.471 * Math.Cos(man + ms - 4 * d);
            g1c += -0.443 * Math.Cos(-man + ms + 2 * d);
            g1c += 0.679 * Math.Cos(-man + ms);
            g1c += -1.540 * Math.Cos(-man + ms - 2 * d);

            s = f + sk / 3600.0 * DEGTORAD;
            ca = 18519.7 + g1c;
            cb = -0.000336992 * ca * dgc * dgc * dgc;
            cd = ca / 18519.7;
            b = (ca * Math.Sin(s) * dgc + cb * Math.Sin(3.0 * s) + cd * nib) / 3600.0;

            /* we neglect the planetary terms in latitude, code 4 in table III */

            sinp = (sinp + 3422.451);
            /*
            ** Improved lunar ephemeris and APAE until ca. 1970 had here
            ** 3422.54 as constant of moon's sine parallax.
            ** The difference can be applied by direct addition of 0.089" to
            ** our parallax results.
            **
            ** To get the radius in A.U. from the sine parallax,
            ** we use 1964 IAU value 8.794" for solar parallax.
            ** sinp is still in seconds of arc.
            ** To calculate moon parallax in " it would be:
            ** p = sinp (1  + sinp * sinp * 3.917405E-12)
            ** based on the formula p = sinp + 1/6 sinp^3
            ** and taking into account the conversion of " to radians.
            ** The semidiameter of the moon is: (Expl.Suppl. 61, p 109)
            ** s = 0.0796 + 0.272446 * p
            */

            ar = 8.794 / sinp;
            az = ar * Math.Sin(DEGTORAD * b);
            return 0;
        }

        /*
        ** outer_hel()
        ** Computes the position of Jupiter, Saturn, Uranus, Neptune, Pluto and
        ** Chiron by reading our stored ephemeris in steps of 80 (!) days and
        ** applying a high order interpolation to it. The interpolation errors are
        ** less than 0.01" seconds of arc.
        ** The stored ephemeris is packed in a special format consisting of
        ** 32 bit numbers; it has been created on the Astrodienst Unix system
        ** by numerical integration with routines provided originally by Marc
        ** Pottenger, USA, which we improved for better long term precision.
        ** Because the Unix system uses a different byte order than the MSDOS
        ** systems, the bytes must be reordered for MSDOS after reading from
        ** the binary files.
        **
        ** outer_hel() takes the same parameters as hel().
        ** It returns the same type of values.
        **
        ** The access to the ephemeris files is done in the functions chi_file_posit()
        ** and lrz_file_posit().
        */

        double last_j0_outer = HUGE8;
        double last_j0_chiron = HUGE8;
        double last_j0_aster = HUGE8;
        Int32[, ,] icoord = new Int32[6, 5, 3];
        Int32[,] chicoord = new Int32[6, 3];
        Int32[, ,] ascoord = new Int32[6, 4, 3];
        double j0, jd, jfrac;
        int outer_hel(int planet, double jd_ad, ref double al, ref double ar, ref double az, ref double alp, ref double arp, ref double azp)
        {
            string outerfp, chironfp, asterfp;

            double[] l = new double[6];
            double[] r = new double[6];
            double[] z = new double[6];
            int n, order, p;
            int offset = 0;
            
            if ((planet < JUPITER || planet > PLUTO) && planet != CHIRON &&
              (planet < CERES || planet > VESTA))
                return -1;
            jd = jd_ad + JUL_OFFSET;
            j0 = Math.Floor((jd - 0.5) / EPHE_STEP) * EPHE_STEP + 0.5;
            jfrac = (jd - j0) / EPHE_STEP;
            if (planet == CHIRON)
            {
                if (last_j0_chiron != j0)
                {
                    for (n = 0; n < 6; n++)
                    { /* read 6 days */
                        jd = j0 + (n - 2) * EPHE_STEP;
                        chironfp = file_posit(EPHE_CHIRON, jd, out offset);
                        using (FileStream fs = new FileStream(chironfp, FileMode.Open))
                        {
                            fs.Seek(offset, SeekOrigin.Begin);
                            byte[] buffer = new byte[4];
                            for (int i = 0; i < 3; i++)
                            {
                                fs.Read(buffer, i * buffer.Length, buffer.Length);
                                chicoord[n, i] = BitConverter.ToInt32(longreorder(buffer), 0);
                            }
                        }
                    }
                    last_j0_chiron = j0;
                }
                for (n = 0; n < 6; n++)
                {
                    l[n] = chicoord[n, 0] / DEG2MSEC;
                    r[n] = chicoord[n, 1] / AU2INT;
                    z[n] = chicoord[n, 2] / AU2INT;
                }
            }
            else if (planet >= CERES && planet <= VESTA)
            {
                if (last_j0_aster != j0)
                {  /* read all 4 asteroids for 6 steps */
                    for (n = 0; n < 6; n++)
                    {
                        jd = j0 + (n - 2) * EPHE_STEP;
                        asterfp = file_posit(EPHE_ASTER, jd, out offset);
                        using (FileStream fs = new FileStream(asterfp, FileMode.Open))
                        {
                            fs.Seek(offset, SeekOrigin.Begin);
                            byte[] buffer = new byte[4];
                            for (int i = 0; i < 12; i++)
                            {
                                fs.Read(buffer, i * buffer.Length, buffer.Length);
                                ascoord[n, i / 4, i % 4] = BitConverter.ToInt32(longreorder(buffer), 0);
                            }
                        }
                    }
                    last_j0_outer = j0;
                }
                p = planet - CERES;
                for (n = 0; n < 6; n++)
                {
                    l[n] = ascoord[n, p, 0] / DEG2MSEC;
                    r[n] = ascoord[n, p, 1] / AU2INT;
                    z[n] = ascoord[n, p, 2] / AU2INT;
                }
            }
            else
            {  /* an outerplanet */
                if (last_j0_outer != j0)
                {  /* read all 5 planets for 6 steps */
                    for (n = 0; n < 6; n++)
                    {
                        jd = j0 + (n - 2) * EPHE_STEP;
                        outerfp = file_posit(EPHE_OUTER, jd, out offset);
                        using (FileStream fs = new FileStream(outerfp, FileMode.Open))
                        {
                            fs.Seek(offset, SeekOrigin.Begin);
                            byte[] buffer = new byte[4];
                            for (int i = 0; i < 15; i++)
                            {
                                fs.Read(buffer, i * buffer.Length, buffer.Length);
                                ascoord[n, i / 5, i % 5] = BitConverter.ToInt32(longreorder(buffer), 0);
                            }
                        }
                    }
                    last_j0_outer = j0;
                }
                p = planet - JUPITER;
                for (n = 0; n < 6; n++)
                {
                    l[n] = icoord[n, p, 0] / DEG2MSEC;
                    r[n] = icoord[n, p, 1] / AU2INT;
                    z[n] = icoord[n, p, 2] / AU2INT;
                }
            }
            if (planet > SATURN)
                order = 3;
            else
                order = 5;
            inpolq(2, order, jfrac, l, ref al, ref alp);
            alp /= EPHE_STEP;
            inpolq(2, order, jfrac, r, ref ar, ref arp);
            arp /= EPHE_STEP;
            inpolq(2, order, jfrac, z, ref az, ref azp);
            azp /= EPHE_STEP;
            return 0;
        }

        /*
        ** quicker Everett interpolation, after Pottenger
        ** version 9 Jul 1988 by Alois Treindl
        ** return OK or ERR.
        */
        //int n,     /* interpolate between x[n] and x[n-1], at argument n+p */
        //o;         /* order of interpolation, maximum 5 */
        //double p,  /* argument , intervall [0..1] */
        //x[],       /* array of function values, x[n-o]..x[n+o] must exist */
        //*axu,      /* pointer for storage of result */
        //*adxu;     /* pointer for storage of dx/dt  */
        int inpolq(int n, int o, double p, double[] x, ref double axu, ref double adxu)
        {
            double q, q2, q3, q4, q5, p2, p3, p4, p5, u, u0, u1, u2;
            double dm2, dm1, d0, dp1, dp2,
              d2m1, d20, d2p1, d2p2, d30, d3p1, d3p2, d4p1, d4p2;
            double offset = 0.0;

            q = 1.0 - p;
            q2 = q * q;
            q3 = (q + 1.0) * q * (q - 1.0) / 6.0;       /* q - 1 over 3; u5 */
            p2 = p * p;
            p3 = (p + 1.0) * p * (p - 1.0) / 6.0;       /* p - 1 over 3; u8 */
            u = (3.0 * p2 - 1.0) / 6.0;
            u0 = (3.0 * q2 - 1.0) / 6.0;
            q4 = q2 * q2;                       /* f5 */
            p4 = p2 * p2;                       /* f4 */
            u1 = (5.0 * p4 - 15.0 * p2 + 4.0) / 120.0;  /* u1 */
            u2 = (5.0 * q4 - 15.0 * q2 + 4.0) / 120.0;  /* u2 */
            q5 = q3 * (q + 2.0) * (q - 2.0) / 20.0;     /* q - 2 over 5; u6 */
            p5 = (p + 2.0) * p3 * (p - 2.0) / 20.0;     /* p - 2 over 5; u9 */

            dm1 = x[n] - x[n - 1];
            if (dm1 > 180.0)
                dm1 -= 360.0;
            if (dm1 < -180.0)
                dm1 += 360.0;
            d0 = x[n + 1] - x[n];
            if (d0 > 180.0)
            {
                d0 -= 360.0;
                offset = 360.0;
            }
            if (d0 < -180.0)
            {
                d0 += 360.0;
                offset = -360.0;
            }
            dp1 = x[n + 2] - x[n + 1];
            if (dp1 > 180.0)
                dp1 -= 360.0;
            if (dp1 < -180.0)
                dp1 += 360.0;
            d20 = d0 - dm1;    /* f8 */
            d2p1 = dp1 - d0;    /* f9 */

            /* Everett interpolation 3rd order */

            axu = q * (x[n] + offset) + q3 * d20 + p * x[n + 1] + p3 * d2p1;
            adxu = d0 + u * d2p1 - u0 * d20;
            if (o > 3)
            {    /* 5th order */
                dm2 = x[n - 1] - x[n - 2];
                if (dm2 > 180.0)
                    dm2 -= 360.0;
                if (dm2 < -180.0)
                    dm2 += 360.0;
                dp2 = x[n + 3] - x[n + 2];
                if (dp2 > 180.0)
                    dp2 -= 360.0;
                if (dp2 < -180.0)
                    dp2 += 360.0;
                d2m1 = dm1 - dm2;
                d2p2 = dp2 - dp1;
                d30 = d20 - d2m1;
                d3p1 = d2p1 - d20;
                d3p2 = d2p2 - d2p1;
                d4p1 = d3p1 - d30;     /* f7 */
                d4p2 = d3p2 - d3p1;    /* f */
                axu += p5 * d4p2 + q5 * d4p1;
                adxu += u1 * d4p2 - u2 * d4p1;
            }
            return 0;
        }


        string file_posit(string filePrefix, double jd, out int offset)
        {
            int filenr, jlong;

            jlong = (int)Math.Floor(jd);
            filenr = (int)(jlong / EPHE_DAYS_PER_FILE);
            if (jlong < 0 && filenr * EPHE_DAYS_PER_FILE != jlong)
                filenr--;
            offset = jlong - filenr * EPHE_DAYS_PER_FILE;
            offset = (offset / (int)EPHE_STEP) * EPHE_OUTER_BSIZE;
            return string.Format("{0}{1}{2}", filePrefix, filenr < 0 ? "M" : "", Math.Abs(filenr));
        }
    }
}
