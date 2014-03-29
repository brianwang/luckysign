using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AstroCSharpLib.Model
{
    public class InternalSettings
    {
        public char fHaveInfo;    /* Do we need to prompt user for chart info?         */
        public char fProgress;    /* Are we doing a chart involving progression?       */
        public char fReturn;      /* Are we doing a transit chart for returns?         */
        public char fMult;        /* Have we already printed at least one text chart?  */
        public char fSeconds;     /* Do we print locations to nearest second?          */
        public char fSzPersist;   /* Are parameter strings persistent when processing? */
        public char fSzInteract;  /* Are we in middle of chart so some setting fixed?  */
        public char fNoEphFile;   /* Have we already had a ephem file not found error? */
        //public char* szProgName;   /* The name and path of the executable running.      */
        //public char* szFileScreen; /* The file to send text output to as passed to -os. */
        //public char* szFileOut;    /* The output chart filename string as passed to -o. */
        //public char** rgszComment; /* Points to any comment strings after -o filename.  */
        public int cszComment;     /* The number of strings after -o that are comments. */
        public int cchCol;         /* The current column text charts are printing at.   */
        public int cchRow;         /* The current row text charts have scrolled to.     */
        public double rSid;          /* Sidereal offset degrees to be added to locations. */
        public double JD;            /* Fractional Julian day for current chart.          */
        public double JDp;           /* Julian day that a progressed chart indicates.     */
        //public FileInfo S;     /* File to write text to.   */
        public double T;   /* Julian time for chart.   */
        public double MC;  /* Midheaven at chart time. */
        public double Asc; /* Ascendant at chart time. */
        public double RA;  /* Right ascension at time. */
        public double OB;  /* Obliquity of ecliptic.   */
    }
}
