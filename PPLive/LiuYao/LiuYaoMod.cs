using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PPLive.LiuYao
{
    public class LiuYaoMod
    {
        #region 私有变量
        Gua[] guas = new Gua[3];
        #endregion

        #region 接口
        public Gua[] Guas //0,1,2对应主卦，变卦，伏卦
        {
            get { return guas; }
            set { guas = value; }
        }
        public Gua ZhuGua 
        {
            get { return guas[0]; }
            set { guas[0] = value; }
        }
        public Gua BianGua
        {
            get { return guas[1]; }
            set { guas[1] = value; }
        }
        public Gua FuGua
        {
            get { return guas[2]; }
            set { guas[2] = value; }
        }
        #endregion
    }
    public class Gua
    {
        #region 私有变量
        Yao[] yaos = new Yao[6];
        int guahao = 0;
        string name = "";
        int shiyao = 0;
        int yingyao = 0;
        #endregion 

        #region 接口
        public Yao[] Yaos //0,1,2,3,4,5对应1,2,3,4,5,6爻
        {
            get { return yaos; }
            set { yaos = value; }
        }
        public string GuaMing
        {
            get { return name; }
            set { name = value; }
        }
        public int GuaHao
        {
            get { return guahao; }
            set { guahao = value; }
        }
        public int ShiYao
        {
            get { return shiyao; }
            set { shiyao = value; }
        }
        public int YingYao
        {
            get { return yingyao; }
            set { yingyao = value; }
        }
        #endregion
    }

    public class Yao
    {
        #region 私有变量
        bool yaotype = true;
        bool dong = false;

        PublicValue.TianGan tg = new PublicValue.TianGan();
        PublicValue.DiZhi dz = new PublicValue.DiZhi();

        PublicValue.LYLiuQin liuqin = new PublicValue.LYLiuQin();
        #endregion 私有变量

        #region 接口
        public bool YaoType
        {
            get { return yaotype; }
            set { yaotype = value; }
        }
        public bool Dong
        {
            get { return dong; }
            set { dong = value; }
        }

        public PublicValue.TianGan YaoTG
        {
            get { return tg; }
            set { tg = value; }
        }
        public PublicValue.DiZhi YaoDZ
        {
            get { return dz; }
            set { dz = value; }
        }

        public PublicValue.LYLiuQin LiuQin
        {
            get { return liuqin; }
            set { liuqin = value; }
        }
        #endregion

    }

}
