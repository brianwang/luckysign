using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PPLive.ZiWei
{
    [Serializable]
    public class ZiWeiMod
    {
        public ZiWeiMod()
        {
            for (int i = 0; i < xing.Length; i++)
            {
                xing[i] = new ZiWeiStar(i);
            }
            for (int i = 0; i < gong.Length; i++)
            {
                gong[i] = new ZiWeiGong(i);
            }
            runyue = PublicValue.ZiWeiRunYue.dangxia;
        }
        
        #region 私有变量
        private DateEntity birthTime = new DateEntity();
        private DateEntity transitTime = new DateEntity(DateTime.Now);
        private AppCmn.AppEnum.Gender gender = new AppCmn.AppEnum.Gender();
        private PublicValue.ShuXing shuxing = new PublicValue.ShuXing();
        private int age = 0;

        private int ming = 0; //命宫号
        private int shen = 0; //身宫号
        private PublicValue.ZiWeiMingJu mingju = new PublicValue.ZiWeiMingJu();
        private ZiWeiGong[] gong = new ZiWeiGong[12]; //以寅卯辰巳。。。子丑的顺序排列
        private ZiWeiStar[] xing = new ZiWeiStar[68]; //紫薇

        private PublicValue.ZiWeiStar mingzhu = new PublicValue.ZiWeiStar();
        private PublicValue.ZiWeiStar shenzhu = new PublicValue.ZiWeiStar();

        private PublicValue.ZiWeiRunYue runyue = new PublicValue.ZiWeiRunYue();//闰月算法类型
        private int tmpmonth = 0;//根据闰月算法类型确定的临时农历月号
        private int yuema = 1;//1为月马，0为年马
        private int mingshenzhu = 1;//1为按生年年支安，0为按命宫地支安
        private int shishang = 1; //安天伤天使,0为阴阳不同，1为阴阳相同
        private int huanyun = 0;//0为按农历生日换运，1为按农历新年换运

        private PublicValue.DiZhi zidou = new PublicValue.DiZhi();//子年斗君
        private PublicValue.DiZhi xiaoxian = new PublicValue.DiZhi();//小限
        private int liuniangong = 0;//推运流年行到的宫位
        private int dayungong = 0;//推运大运行到的宫位
        private int liuyuegong = 0;//推运正月行到的宫位
        private int[] liuyao = new int[7];//流耀 昌曲魁钺羊陀禄
        private int[] yunyao = new int[7]; //运耀 昌曲魁钺羊陀禄
        private int tmpliumonth = 0;//根据闰月算法类型确定的临时流月农历月号
        #endregion

        #region 接口
        public DateEntity BirthTime
        {
            get { return birthTime; }
            set { birthTime = value; }
        }
        public DateEntity TransitTime
        {
            get { return transitTime; }
            set { transitTime = value; }
        }
        public AppCmn.AppEnum.Gender Gender
        {
            get { return gender; }
            set { gender = value; }
        }
        public PublicValue.ShuXing ShuXing
        {
            get { return shuxing; }
            set { shuxing = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public int Ming
        {
            get { return ming; }
            set { ming = value; }
        }
        public int Shen
        {
            get { return shen; }
            set { shen = value; }
        }
        public PublicValue.ZiWeiMingJu MingJu
        {
            get { return mingju; }
            set { mingju = value; }
        }

        public ZiWeiGong[] Gong
        {
            get { return gong; }
            set { gong = value; }
        }

        public ZiWeiStar[] Xing
        {
            get { return xing; }
            set { xing = value; }
        }

        public PublicValue.ZiWeiStar MingZhu
        {
            get { return mingzhu; }
            set { mingzhu = value; }
        }
        public PublicValue.ZiWeiStar ShenZhu
        {
            get { return shenzhu; }
            set { shenzhu = value; }
        }
        public PublicValue.ZiWeiRunYue RunYue
        {
            get { return runyue; }
            set { runyue = value; }
        }
        public int TmpMonth
        {
            get { return tmpmonth; }
            set { tmpmonth = value; }
        }
        public int TmpLiuMonth
        {
            get { return tmpliumonth; }
            set { tmpliumonth = value; }
        }
        public PublicValue.DiZhi ZiDou
        {
            get { return zidou; }
            set { zidou = value; }
        }
        public PublicValue.DiZhi XiaoXian
        {
            get { return xiaoxian; }
            set { xiaoxian = value; }
        }
        public int YueMa
        {
            get { return yuema; }
            set { yuema = value; }
        }
        public int MingShenZhu
        {
            get { return mingshenzhu; }
            set { mingshenzhu = value; }
        }
        public int ShiShang
        {
            get { return shishang; }
            set { shishang = value; }
        }
        public int HuanYun
        {
            get { return huanyun; }
            set { huanyun = value; }
        }
        public int LiuNianGong
        {
            get { return liuniangong; }
            set { liuniangong = value; }
        }
        public int DaYunGong
        {
            get { return dayungong; }
            set { dayungong = value; }
        }
        public int LiuYueGong
        {
            get { return liuyuegong; }
            set { liuyuegong = value; }
        }
        public int[] LiuYao
        {
            get { return liuyao; }
            set { liuyao = value; }
        }
        public int[] YunYao
        {
            get { return yunyao; }
            set { yunyao = value; }
        }
        #endregion
    }
    [Serializable]
    public class ZiWeiGong
    {
        public ZiWeiGong(int i)
        {
            gongname = (PublicValue.ZiWeiGong)Enum.Parse(typeof(PublicValue.ZiWeiGong), i.ToString());
        }
        #region 私有变量
        private PublicValue.ZiWeiGong gongname = new PublicValue.ZiWeiGong();
        private PublicValue.ZiWeiGong yungongname = new PublicValue.ZiWeiGong();//大运宫名
        private PublicValue.ZiWeiGong liugongname = new PublicValue.ZiWeiGong();//流年宫名
        private PublicValue.TianGan tg = new PublicValue.TianGan();
        private PublicValue.DiZhi dz = new PublicValue.DiZhi();
        private int transita = 0;
        private int transitb = 0;
        private PublicValue.ZiWeiChangSheng changsheng = new PublicValue.ZiWeiChangSheng();
        private PublicValue.ZiWeiTaiSui taisui = new PublicValue.ZiWeiTaiSui();
        private PublicValue.ZiWeiJiangQian jiangqian = new PublicValue.ZiWeiJiangQian();
        private PublicValue.ZiWeiBoShi boshi = new PublicValue.ZiWeiBoShi();
        #endregion

        #region 接口
        public PublicValue.ZiWeiGong GongName
        {
            get { return gongname; }
            set { gongname = value; }
        }
        public PublicValue.ZiWeiGong YunGongName
        {
            get { return yungongname; }
            set { yungongname = value; }
        }
        public PublicValue.ZiWeiGong LiuGongName
        {
            get { return liugongname; }
            set { liugongname = value; }
        }
        public PublicValue.TianGan TG
        {
            get { return tg; }
            set { tg = value; }
        }
        public PublicValue.DiZhi DZ
        {
            get { return dz; }
            set { dz = value; }
        }

        public int TransitA
        {
            get { return transita; }
            set { transita = value; }
        }
        public int TransitB
        {
            get { return transitb; }
            set { transitb = value; }
        }

        public PublicValue.ZiWeiChangSheng ChangSheng
        {
            get { return changsheng; }
            set { changsheng = value; }
        }
        public PublicValue.ZiWeiTaiSui TaiSui
        {
            get { return taisui; }
            set { taisui = value; }
        }
        public PublicValue.ZiWeiJiangQian JiangQian
        {
            get { return jiangqian; }
            set { jiangqian = value; }
        }
        public PublicValue.ZiWeiBoShi BoShi
        {
            get { return boshi; }
            set { boshi = value; }
        }
        #endregion
    }
    [Serializable]
    public class ZiWeiStar
    {
        public ZiWeiStar(int i)
        {
            starname = (PublicValue.ZiWeiStar)Enum.Parse(typeof(PublicValue.ZiWeiStar), i.ToString());
        }
        #region 私有变量
        private PublicValue.ZiWeiStar starname = new PublicValue.ZiWeiStar();
        private int gong = 0;//所在宫号
        private PublicValue.ZiWeiSihua hua = new PublicValue.ZiWeiSihua();//四化
        private PublicValue.ZiWeiSihua yunhua = new PublicValue.ZiWeiSihua();//大运四化
        private PublicValue.ZiWeiSihua liuhua = new PublicValue.ZiWeiSihua();//流年四化
        private PublicValue.ZiWeiMiaowang wang = new PublicValue.ZiWeiMiaowang();//庙旺
        #endregion

        #region 接口
        public PublicValue.ZiWeiStar StarName
        {
            get { return starname; }
            set { starname = value; }
        }
        public int Gong
        {
            get { return gong; }
            set { gong = value; }
        }
        public PublicValue.ZiWeiSihua Hua
        {
            get { return hua; }
            set { hua = value; }
        }
        public PublicValue.ZiWeiSihua YunHua
        {
            get { return yunhua; }
            set { yunhua = value; }
        }
        public PublicValue.ZiWeiSihua LiuHua
        {
            get { return liuhua; }
            set { liuhua = value; }
        }
        public PublicValue.ZiWeiMiaowang Wang
        {
            get { return wang; }
            set { wang = value; }
        }
        #endregion
    }
}
