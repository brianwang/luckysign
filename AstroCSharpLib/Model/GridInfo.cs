using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AstroCSharpLib.Model
{
    public class GridInfo
    {
        public byte[,] n = new byte[CALC.objMax, CALC.objMax];
        public int[,] v = new int[CALC.objMax, CALC.objMax];
    }
}
