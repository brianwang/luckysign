using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PPLive.ZiWei
{
    [Serializable]
    [DataContract]
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
        private bool realtime = false;
        private string areaname = "";
        private string longitude = "";
        private int type = 0;
        private bool isdaylight = false;

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
        [DataMember]
        public DateEntity BirthTime
        {
            get { return birthTime; }
            set { birthTime = value; }
        }
        [DataMember]
        public DateEntity TransitTime
        {
            get { return transitTime; }
            set { transitTime = value; }
        }
        [DataMember]
        public AppCmn.AppEnum.Gender Gender
        {
            get { return gender; }
            set { gender = value; }
        }
        [DataMember]
        public int Type
        {
            get { return type; }
            set { type = value; }
        }
        [DataMember]
        public bool IsDayLight
        {
            get { return isdaylight; }
            set { isdaylight = value; }
        }
        [DataMember]
        public PublicValue.ShuXing ShuXing
        {
            get { return shuxing; }
            set { shuxing = value; }
        }
        [DataMember]
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        [DataMember]
        public int Ming
        {
            get { return ming; }
            set { ming = value; }
        }
        [DataMember]
        public int Shen
        {
            get { return shen; }
            set { shen = value; }
        }
        [DataMember]
        public PublicValue.ZiWeiMingJu MingJu
        {
            get { return mingju; }
            set { mingju = value; }
        }
        [DataMember]
        public ZiWeiGong[] Gong
        {
            get { return gong; }
            set { gong = value; }
        }
        [DataMember]
        public ZiWeiStar[] Xing
        {
            get { return xing; }
            set { xing = value; }
        }
        [DataMember]
        public PublicValue.ZiWeiStar MingZhu
        {
            get { return mingzhu; }
            set { mingzhu = value; }
        }
        [DataMember]
        public PublicValue.ZiWeiStar ShenZhu
        {
            get { return shenzhu; }
            set { shenzhu = value; }
        }
        [DataMember]
        public PublicValue.ZiWeiRunYue RunYue
        {
            get { return runyue; }
            set { runyue = value; }
        }
        [DataMember]
        public int TmpMonth
        {
            get { return tmpmonth; }
            set { tmpmonth = value; }
        }
        [DataMember]
        public int TmpLiuMonth
        {
            get { return tmpliumonth; }
            set { tmpliumonth = value; }
        }
        [DataMember]
        public PublicValue.DiZhi ZiDou
        {
            get { return zidou; }
            set { zidou = value; }
        }
        [DataMember]
        public PublicValue.DiZhi XiaoXian
        {
            get { return xiaoxian; }
            set { xiaoxian = value; }
        }
        [DataMember]
        public int YueMa
        {
            get { return yuema; }
            set { yuema = value; }
        }
        [DataMember]
        public int MingShenZhu
        {
            get { return mingshenzhu; }
            set { mingshenzhu = value; }
        }
        [DataMember]
        public int ShiShang
        {
            get { return shishang; }
            set { shishang = value; }
        }
        [DataMember]
        public int HuanYun
        {
            get { return huanyun; }
            set { huanyun = value; }
        }
        [DataMember]
        public int LiuNianGong
        {
            get { return liuniangong; }
            set { liuniangong = value; }
        }
        [DataMember]
        public int DaYunGong
        {
            get { return dayungong; }
            set { dayungong = value; }
        }
        [DataMember]
        public int LiuYueGong
        {
            get { return liuyuegong; }
            set { liuyuegong = value; }
        }
        [DataMember]
        public int[] LiuYao
        {
            get { return liuyao; }
            set { liuyao = value; }
        }
        [DataMember]
        public int[] YunYao
        {
            get { return yunyao; }
            set { yunyao = value; }
        }
        [DataMember]
        public bool RealTime
        {
            get { return realtime; }
            set { realtime = value; }
        }
        [DataMember]
        public string AreaName
        {
            get { return areaname; }
            set { areaname = value; }
        }
        [DataMember]
        public string Longitude
        {
            get { return longitude; }
            set { longitude = value; }
        }
        #endregion
    }
    [Serializable]
    [DataContract]
    public class ZiWeiGong
    {
        public ZiWeiGong()
        { }
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
        [DataMember]
        public PublicValue.ZiWeiGong GongName
        {
            get { return gongname; }
            set { gongname = value; }
        }
        [DataMember]
        public PublicValue.ZiWeiGong YunGongName
        {
            get { return yungongname; }
            set { yungongname = value; }
        }
        [DataMember]
        public PublicValue.ZiWeiGong LiuGongName
        {
            get { return liugongname; }
            set { liugongname = value; }
        }
        [DataMember]
        public PublicValue.TianGan TG
        {
            get { return tg; }
            set { tg = value; }
        }
        [DataMember]
        public PublicValue.DiZhi DZ
        {
            get { return dz; }
            set { dz = value; }
        }
        [DataMember]
        public int TransitA
        {
            get { return transita; }
            set { transita = value; }
        }
        [DataMember]
        public int TransitB
        {
            get { return transitb; }
            set { transitb = value; }
        }
        [DataMember]
        public PublicValue.ZiWeiChangSheng ChangSheng
        {
            get { return changsheng; }
            set { changsheng = value; }
        }
        [DataMember]
        public PublicValue.ZiWeiTaiSui TaiSui
        {
            get { return taisui; }
            set { taisui = value; }
        }
        [DataMember]
        public PublicValue.ZiWeiJiangQian JiangQian
        {
            get { return jiangqian; }
            set { jiangqian = value; }
        }
        [DataMember]
        public PublicValue.ZiWeiBoShi BoShi
        {
            get { return boshi; }
            set { boshi = value; }
        }
        #endregion
    }
    [Serializable]
    [DataContract]
    public class ZiWeiStar
    {
        public ZiWeiStar()
        { }
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

        #region 属性
        [DataMember]
        public PublicValue.ZiWeiStar StarName
        {
            get { return starname; }
            set { starname = value; }
        }
        [DataMember]
        public int Gong
        {
            get { return gong; }
            set { gong = value; }
        }
        [DataMember]
        public PublicValue.ZiWeiSihua Hua
        {
            get { return hua; }
            set { hua = value; }
        }
        [DataMember]
        public PublicValue.ZiWeiSihua YunHua
        {
            get { return yunhua; }
            set { yunhua = value; }
        }
        [DataMember]
        public PublicValue.ZiWeiSihua LiuHua
        {
            get { return liuhua; }
            set { liuhua = value; }
        }
        [DataMember]
        public PublicValue.ZiWeiMiaowang Wang
        {
            get { return wang; }
            set { wang = value; }
        }
        #endregion
    }
}
