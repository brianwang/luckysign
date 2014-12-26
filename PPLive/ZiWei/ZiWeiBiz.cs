using System; 
using System.Collections.Generic; 
using System.ComponentModel; 
using System.Linq; 
using System.Text; 
//using System.Reflection; 
using System.Collections; 
using PPLive;

namespace PPLive.ZiWei
{
    /// <summary>
    /// ziwei 的摘要说明
    /// </summary>
    public class ZiWeiBiz
    {
        private ZiWeiBiz()
        {
        }
        private static ZiWeiBiz _instance;
        public static ZiWeiBiz GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ZiWeiBiz();
            }
            return _instance;
        }
        
        #region 紫微基础常量
        private PublicValue.ZiWeiStar[] BeiDouMain = { 
        PublicValue.ZiWeiStar.ziwei,
        PublicValue.ZiWeiStar.tianji,
        PublicValue.ZiWeiStar.wu,
        PublicValue.ZiWeiStar.taiyang,
        PublicValue.ZiWeiStar.wuqu,
        PublicValue.ZiWeiStar.tiantong,  
        PublicValue.ZiWeiStar.wu,
        PublicValue.ZiWeiStar.wu,
        PublicValue.ZiWeiStar.lianzhen,
        PublicValue.ZiWeiStar.wu,
        PublicValue.ZiWeiStar.wu,
        PublicValue.ZiWeiStar.wu,};
        private PublicValue.ZiWeiStar[] NanDouMain = { 
        PublicValue.ZiWeiStar.tianfu,
        PublicValue.ZiWeiStar.taiyin,
        PublicValue.ZiWeiStar.tanlang,
        PublicValue.ZiWeiStar.jvmen,
        PublicValue.ZiWeiStar.tianxiang,
        PublicValue.ZiWeiStar.tianliang,
        PublicValue.ZiWeiStar.qisha,
        PublicValue.ZiWeiStar.wu,
        PublicValue.ZiWeiStar.wu,
        PublicValue.ZiWeiStar.wu,
        PublicValue.ZiWeiStar.pojun,
        PublicValue.ZiWeiStar.wu,};
        #region 中州庙旺表   顺序以寅卯辰巳。。。子丑的顺序排列
        private PublicValue.ZiWeiMiaowang[] ZiweiMiaowang ={
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.wang,
        PublicValue.ZiWeiMiaowang.xian,
        PublicValue.ZiWeiMiaowang.wang,
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.wang,
        PublicValue.ZiWeiMiaowang.ping,
        PublicValue.ZiWeiMiaowang.xia,
        PublicValue.ZiWeiMiaowang.wang,
        PublicValue.ZiWeiMiaowang.ping,
        PublicValue.ZiWeiMiaowang.miao,};
        private PublicValue.ZiWeiMiaowang[] TianjiMiaowang ={
        PublicValue.ZiWeiMiaowang.wang,
        PublicValue.ZiWeiMiaowang.wang,
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.ping,
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.xian,
        PublicValue.ZiWeiMiaowang.ping,
        PublicValue.ZiWeiMiaowang.wang,
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.ping,
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.xian,};
        private PublicValue.ZiWeiMiaowang[] TaiyangMiaowang ={
        PublicValue.ZiWeiMiaowang.wang,
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.wang,
        PublicValue.ZiWeiMiaowang.wang,
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.ping,
        PublicValue.ZiWeiMiaowang.xia,
        PublicValue.ZiWeiMiaowang.xia,
        PublicValue.ZiWeiMiaowang.xian,
        PublicValue.ZiWeiMiaowang.xian,
        PublicValue.ZiWeiMiaowang.xian,
        PublicValue.ZiWeiMiaowang.xian,};
        private PublicValue.ZiWeiMiaowang[] WuquMiaowang ={
        PublicValue.ZiWeiMiaowang.xia,
        PublicValue.ZiWeiMiaowang.xian,
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.ping,
        PublicValue.ZiWeiMiaowang.wang,
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.ping,
        PublicValue.ZiWeiMiaowang.wang,
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.ping,
        PublicValue.ZiWeiMiaowang.wang,
        PublicValue.ZiWeiMiaowang.miao,};
        private PublicValue.ZiWeiMiaowang[] TiantongMiaowang ={
        PublicValue.ZiWeiMiaowang.xia,
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.ping,
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.xian,
        PublicValue.ZiWeiMiaowang.xian,
        PublicValue.ZiWeiMiaowang.wang,
        PublicValue.ZiWeiMiaowang.ping,
        PublicValue.ZiWeiMiaowang.ping,
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.wang,
        PublicValue.ZiWeiMiaowang.xian,};
        private PublicValue.ZiWeiMiaowang[] LianzhenMiaowang ={
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.xia,
        PublicValue.ZiWeiMiaowang.wang,
        PublicValue.ZiWeiMiaowang.xian,
        PublicValue.ZiWeiMiaowang.ping,
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.ping,
        PublicValue.ZiWeiMiaowang.wang,
        PublicValue.ZiWeiMiaowang.xian,
        PublicValue.ZiWeiMiaowang.ping,
        PublicValue.ZiWeiMiaowang.wang,};
        private PublicValue.ZiWeiMiaowang[] TianfuMiaowang ={
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.ping,
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.ping,
        PublicValue.ZiWeiMiaowang.wang,
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.ping,
        PublicValue.ZiWeiMiaowang.xian,
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.wang,
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.miao,};
        private PublicValue.ZiWeiMiaowang[] TaiyinMiaowang ={
        PublicValue.ZiWeiMiaowang.xia,
        PublicValue.ZiWeiMiaowang.xian,
        PublicValue.ZiWeiMiaowang.xia,
        PublicValue.ZiWeiMiaowang.xian,
        PublicValue.ZiWeiMiaowang.xian,
        PublicValue.ZiWeiMiaowang.ping,
        PublicValue.ZiWeiMiaowang.ping,
        PublicValue.ZiWeiMiaowang.wang,
        PublicValue.ZiWeiMiaowang.wang,
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.miao,};
        private PublicValue.ZiWeiMiaowang[] TanlangMiaowang ={
        PublicValue.ZiWeiMiaowang.ping,
        PublicValue.ZiWeiMiaowang.di,
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.xian,
        PublicValue.ZiWeiMiaowang.wang,
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.ping,
        PublicValue.ZiWeiMiaowang.ping,
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.xian,
        PublicValue.ZiWeiMiaowang.wang,
        PublicValue.ZiWeiMiaowang.miao,};
        private PublicValue.ZiWeiMiaowang[] JvmenMiaowang ={
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.ping,
        PublicValue.ZiWeiMiaowang.ping,
        PublicValue.ZiWeiMiaowang.wang,
        PublicValue.ZiWeiMiaowang.xian,
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.wang,
        PublicValue.ZiWeiMiaowang.wang,
        PublicValue.ZiWeiMiaowang.wang,
        PublicValue.ZiWeiMiaowang.wang,};
        private PublicValue.ZiWeiMiaowang[] TianxiangMiaowang ={
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.xian,
        PublicValue.ZiWeiMiaowang.wang,
        PublicValue.ZiWeiMiaowang.ping,
        PublicValue.ZiWeiMiaowang.wang,
        PublicValue.ZiWeiMiaowang.xia,
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.xian,
        PublicValue.ZiWeiMiaowang.xia,
        PublicValue.ZiWeiMiaowang.ping,
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.miao,};
        private PublicValue.ZiWeiMiaowang[] TianliangMiaowang ={
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.wang,
        PublicValue.ZiWeiMiaowang.xian,
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.wang,
        PublicValue.ZiWeiMiaowang.xian,
        PublicValue.ZiWeiMiaowang.di,
        PublicValue.ZiWeiMiaowang.wang,
        PublicValue.ZiWeiMiaowang.xian,
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.wang,};
        private PublicValue.ZiWeiMiaowang[] QishaMiaowang ={
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.xian,
        PublicValue.ZiWeiMiaowang.wang,
        PublicValue.ZiWeiMiaowang.ping,
        PublicValue.ZiWeiMiaowang.wang,
        PublicValue.ZiWeiMiaowang.wang,
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.xia,
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.ping,
        PublicValue.ZiWeiMiaowang.wang,
        PublicValue.ZiWeiMiaowang.miao,};
        private PublicValue.ZiWeiMiaowang[] PojunMiaowang ={
        PublicValue.ZiWeiMiaowang.xian,
        PublicValue.ZiWeiMiaowang.wang,
        PublicValue.ZiWeiMiaowang.wang,
        PublicValue.ZiWeiMiaowang.xia,
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.xian,
        PublicValue.ZiWeiMiaowang.xian,
        PublicValue.ZiWeiMiaowang.wang,
        PublicValue.ZiWeiMiaowang.ping,
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.wang,};

        private PublicValue.ZiWeiMiaowang[] DikongMiaowang ={
        PublicValue.ZiWeiMiaowang.xian,
        PublicValue.ZiWeiMiaowang.ping,
        PublicValue.ZiWeiMiaowang.xian,
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.ping,
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.xian,
        PublicValue.ZiWeiMiaowang.xian,
        PublicValue.ZiWeiMiaowang.ping,
        PublicValue.ZiWeiMiaowang.xian,};
        private PublicValue.ZiWeiMiaowang[] DijieMiaowang ={
        PublicValue.ZiWeiMiaowang.ping,
        PublicValue.ZiWeiMiaowang.ping,
        PublicValue.ZiWeiMiaowang.xian,
        PublicValue.ZiWeiMiaowang.xia,
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.ping,
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.ping,
        PublicValue.ZiWeiMiaowang.ping,
        PublicValue.ZiWeiMiaowang.wang,
        PublicValue.ZiWeiMiaowang.xian,
        PublicValue.ZiWeiMiaowang.xian,};
        private PublicValue.ZiWeiMiaowang[] QingyangMiaowang ={
        PublicValue.ZiWeiMiaowang.none,
        PublicValue.ZiWeiMiaowang.xian,
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.none,
        PublicValue.ZiWeiMiaowang.ping,
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.none,
        PublicValue.ZiWeiMiaowang.xian,
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.none,
        PublicValue.ZiWeiMiaowang.xian,
        PublicValue.ZiWeiMiaowang.miao,};
        private PublicValue.ZiWeiMiaowang[] TuoluoMiaowang ={
        PublicValue.ZiWeiMiaowang.xian,
        PublicValue.ZiWeiMiaowang.none,
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.xian,
        PublicValue.ZiWeiMiaowang.none,
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.xian,
        PublicValue.ZiWeiMiaowang.none,
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.xian,
        PublicValue.ZiWeiMiaowang.none,
        PublicValue.ZiWeiMiaowang.miao,};
        private PublicValue.ZiWeiMiaowang[] HuoxingMiaowang ={
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.ping,
        PublicValue.ZiWeiMiaowang.xia,
        PublicValue.ZiWeiMiaowang.wang,
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.xia,
        PublicValue.ZiWeiMiaowang.xian,
        PublicValue.ZiWeiMiaowang.xian,
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.ping,
        PublicValue.ZiWeiMiaowang.ping,
        PublicValue.ZiWeiMiaowang.wang,};
        private PublicValue.ZiWeiMiaowang[] LingxingMiaowang ={
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.wang,
        PublicValue.ZiWeiMiaowang.wang,
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.wang,
        PublicValue.ZiWeiMiaowang.wang,
        PublicValue.ZiWeiMiaowang.xian,
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.xian,
        PublicValue.ZiWeiMiaowang.xian,};

        private PublicValue.ZiWeiMiaowang[] TianmaMiaowang ={
        PublicValue.ZiWeiMiaowang.wang,
        PublicValue.ZiWeiMiaowang.none,
        PublicValue.ZiWeiMiaowang.none,
        PublicValue.ZiWeiMiaowang.ping,
        PublicValue.ZiWeiMiaowang.none,
        PublicValue.ZiWeiMiaowang.none,
        PublicValue.ZiWeiMiaowang.wang,
        PublicValue.ZiWeiMiaowang.none,
        PublicValue.ZiWeiMiaowang.none,
        PublicValue.ZiWeiMiaowang.ping,
        PublicValue.ZiWeiMiaowang.none,
        PublicValue.ZiWeiMiaowang.none,};
        private PublicValue.ZiWeiMiaowang[] LucunMiaowang ={
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.wang,
        PublicValue.ZiWeiMiaowang.none,
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.wang,
        PublicValue.ZiWeiMiaowang.none,
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.wang,
        PublicValue.ZiWeiMiaowang.none,
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.wang,
        PublicValue.ZiWeiMiaowang.none,};
        private PublicValue.ZiWeiMiaowang[] WenquMiaowang ={
        PublicValue.ZiWeiMiaowang.ping,
        PublicValue.ZiWeiMiaowang.wang,
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.xian,
        PublicValue.ZiWeiMiaowang.wang,
        PublicValue.ZiWeiMiaowang.ping,
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.xian,
        PublicValue.ZiWeiMiaowang.wang,
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.miao,};
        private PublicValue.ZiWeiMiaowang[] WenchangMiaowang ={
        PublicValue.ZiWeiMiaowang.xian,
        PublicValue.ZiWeiMiaowang.ping,
        PublicValue.ZiWeiMiaowang.wang,
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.xian,
        PublicValue.ZiWeiMiaowang.ping,
        PublicValue.ZiWeiMiaowang.wang,
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.xian,
        PublicValue.ZiWeiMiaowang.wang,
        PublicValue.ZiWeiMiaowang.wang,
        PublicValue.ZiWeiMiaowang.miao,};
        private PublicValue.ZiWeiMiaowang[] YoubiMiaowang ={
        PublicValue.ZiWeiMiaowang.wang,
        PublicValue.ZiWeiMiaowang.xian,
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.ping,
        PublicValue.ZiWeiMiaowang.wang,
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.xia,
        PublicValue.ZiWeiMiaowang.xian,
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.ping,
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.miao,};
        private PublicValue.ZiWeiMiaowang[] ZuofuMiaowang ={
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.xian,
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.ping,
        PublicValue.ZiWeiMiaowang.wang,
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.ping,
        PublicValue.ZiWeiMiaowang.xian,
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.xia,
        PublicValue.ZiWeiMiaowang.wang,
        PublicValue.ZiWeiMiaowang.miao,};
        private PublicValue.ZiWeiMiaowang[] TianyueMiaowang ={
        PublicValue.ZiWeiMiaowang.wang,
        PublicValue.ZiWeiMiaowang.none,
        PublicValue.ZiWeiMiaowang.none,
        PublicValue.ZiWeiMiaowang.wang,
        PublicValue.ZiWeiMiaowang.none,
        PublicValue.ZiWeiMiaowang.wang,
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.none,
        PublicValue.ZiWeiMiaowang.none,
        PublicValue.ZiWeiMiaowang.none,
        PublicValue.ZiWeiMiaowang.none,};
        private PublicValue.ZiWeiMiaowang[] TiankuiMiaowang ={
        PublicValue.ZiWeiMiaowang.none,
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.none,
        PublicValue.ZiWeiMiaowang.none,
        PublicValue.ZiWeiMiaowang.none,
        PublicValue.ZiWeiMiaowang.miao,
        PublicValue.ZiWeiMiaowang.none,
        PublicValue.ZiWeiMiaowang.none,
        PublicValue.ZiWeiMiaowang.none,
        PublicValue.ZiWeiMiaowang.wang,
        PublicValue.ZiWeiMiaowang.wang,
        PublicValue.ZiWeiMiaowang.wang,};
        #endregion 中州庙旺表
        #endregion 紫微基础数据

        /// <summary>
        /// 
        /// </summary>
        /// <param name="DateEntity"></param>
        /// <param name="gender"></param>
        /// <param name="flags">开关符，YueMa，MingShenZhu,ShiShang,HuanYun</param>
        /// <returns></returns>
        public ZiWeiMod TimeToZiWei(DateEntity DateEntity, AppCmn.AppEnum.Gender gender, int[] flags)
        {
            ZiWeiMod ret = new ZiWeiMod();
            ret.BirthTime = DateEntity;
            ret.Gender = gender;
            ret.YueMa = flags[0];
            ret.MingShenZhu = flags[1];
            ret.ShiShang = flags[2];
            ret.HuanYun = flags[3];

            setrunyue(ref ret);
            gongwei(ref ret);
            getgonggz(ref ret);
            getmingju(ref ret);
            getyingyang(ref ret);
            gettransit(ref ret);
            getzwstar(ref ret);
            setmainstar(ref ret);
            setassiststar(ref ret);
            setluma(ref ret, ret.YueMa);
            setbadstar(ref ret);
            setsihua(ref ret);
            setbadstar(ref ret);
            setguanfo(ref ret);
            setsihua(ref ret);
            setkong(ref ret);
            settaohua(ref ret);
            setfangchan(ref ret);
            setcaishou(ref ret);
            setguxing(ref ret);
            setwenguan(ref ret);
            setmonthstars(ref ret);
            setdaystars(ref ret, ret.ShiShang);
            setyearstars(ref ret);
            setmingshenzhu(ref ret, ret.MingShenZhu);
            changsheng(ref ret);
            taisui(ref ret);
            jiangqian(ref ret);
            boshi(ref ret);
            SetMiaoWang(ref ret);
            SetZiDou(ref ret);
            SetXingGong(ref ret);
            return ret;
        }

        public ZiWeiMod TransitToZiWei(DateEntity DateEntity,DateEntity Transit, AppCmn.AppEnum.Gender gender, int[] flags)
        {
            ZiWeiMod ret = new ZiWeiMod();
            ret.BirthTime = DateEntity;
            ret.TransitTime = Transit;
            ret.Gender = gender;
            ret.Type = 1;
            ret.YueMa = flags[0];
            ret.MingShenZhu = flags[1];
            ret.ShiShang = flags[2];
            ret.HuanYun = flags[3];

            setrunyue(ref ret);
            gongwei(ref ret);
            getgonggz(ref ret);
            getmingju(ref ret);
            getyingyang(ref ret);
            gettransit(ref ret);
            getzwstar(ref ret);
            setmainstar(ref ret);
            setassiststar(ref ret);
            setluma(ref ret, ret.YueMa);
            setbadstar(ref ret);
            setsihua(ref ret);
            setbadstar(ref ret);
            setguanfo(ref ret);
            setsihua(ref ret);
            setkong(ref ret);
            settaohua(ref ret);
            setfangchan(ref ret);
            setcaishou(ref ret);
            setguxing(ref ret);
            setwenguan(ref ret);
            setmonthstars(ref ret);
            setdaystars(ref ret, ret.ShiShang);
            setyearstars(ref ret);
            setmingshenzhu(ref ret, ret.MingShenZhu);
            changsheng(ref ret);
            taisui(ref ret);
            jiangqian(ref ret);
            boshi(ref ret);
            SetMiaoWang(ref ret);
            SetZiDou(ref ret);
            SetXiaoXian(ref ret);
            SetXingGong(ref ret);
            SetLiuSiHua(ref ret);
            SetLiuGong(ref ret);
            SetLiuChangQu(ref ret);
            SetLiuKuiYue(ref ret);
            SetLiuYangTuoLu(ref ret);
            return ret;
        }

        #region 细节算法
        //按闰月算法确定临时月份
        public void setrunyue(ref ZiWeiMod mod)
        {
            int ret = 0;
            int retliu = 0;
            if((int)mod.BirthTime.NongliMonth<100)
            {
                ret = (int)mod.BirthTime.NongliMonth;
                retliu = (int)mod.TransitTime.NongliMonth;
            }
            else if (mod.RunYue == PublicValue.ZiWeiRunYue.dang)
            {
                ret = (int)mod.BirthTime.NongliMonth%100;
                retliu = (int)mod.TransitTime.NongliMonth%100;
            }
            else if (mod.RunYue == PublicValue.ZiWeiRunYue.xia)
            {
                ret = ((int)mod.BirthTime.NongliMonth+1) % 100;
                if (ret == 13)
                {
                    ret = 1;
                }
                retliu = ((int)mod.TransitTime.NongliMonth + 1) % 100;
                if (retliu == 13)
                {
                    retliu = 1;
                }
            }
            else if (mod.RunYue == PublicValue.ZiWeiRunYue.dangxia)
            {
                if ((int)mod.BirthTime.NongliDay > 15)
                {
                    ret = ((int)mod.BirthTime.NongliMonth + 1) % 100;
                    if (ret == 13)
                    {
                        ret = 1;
                    }
                }
                else
                {
                    ret = (int)mod.BirthTime.NongliMonth % 100;
                }
                if ((int)mod.TransitTime.NongliDay > 15)
                {
                    retliu = ((int)mod.TransitTime.NongliMonth + 1) % 100;
                    if (retliu == 13)
                    {
                        retliu = 1;
                    }
                }
                else
                {
                    retliu = (int)mod.TransitTime.NongliMonth % 100;
                }

            }
            mod.TmpMonth = ret;
            mod.TmpLiuMonth = retliu;
            return;
        }
        //命身及其他宫位确定
        public void gongwei(ref ZiWeiMod mod)
        {
            mod.Ming = (mod.TmpMonth - 1 - ((int)mod.BirthTime.NongliHour) + 12) % 12;
            mod.Shen = (mod.TmpMonth - 1 + ((int)mod.BirthTime.NongliHour)) % 12;
            for (int i = 0; i < 12; i++)
            {
                mod.Gong[i].GongName = (PublicValue.ZiWeiGong)Enum.Parse(typeof(PublicValue.ZiWeiGong), ((mod.Ming - i + 12) % 12).ToString());
            }
            return;
        }

        //为宫的天干地支赋值
        public void getgonggz(ref ZiWeiMod mod)
        {
            DateTime newdate = new DateTime(mod.BirthTime.Date.Year,2,10);

            int tempmonth = (int)mod.BirthTime.NongliTG;//此天干为农历年天干
            tempmonth = (tempmonth % 5 + 1) * 2 % 10;
            for(int i=0;i<12;i++)
            {
                mod.Gong[i].TG = (PublicValue.TianGan)Enum.Parse(typeof(PublicValue.TianGan), ((tempmonth+i)%10).ToString());
                mod.Gong[i].DZ = (PublicValue.DiZhi)Enum.Parse(typeof(PublicValue.DiZhi), ((2 + i) % 12).ToString());
            }
            return;
        }

        //取纳音五行的命局号,输入命宫干支
        public void getmingju(ref ZiWeiMod mod)
        {
            int dznum = 0, tgnum = 0;
            tgnum = (((int)mod.Gong[mod.Ming].TG)) / 2;
            dznum = (((int)mod.Gong[mod.Ming].DZ)) / 2;
            dznum = (dznum+2) % 3;
            if (dznum == 2)
            {
                dznum = 4;
            }
            int nynum = (dznum + tgnum) % 5;
            switch (nynum)
            {
                case 0:
                    nynum = 2;
                    break;
                case 1:
                    nynum = 6;
                    break;
                case 2:
                    nynum = 5;
                    break;
                case 3:
                    nynum = 3;
                    break;
                case 4:
                    nynum = 4;
                    break;
            }
            mod.MingJu = (PublicValue.ZiWeiMingJu)Enum.Parse(typeof(PublicValue.ZiWeiMingJu), nynum.ToString());
            return;
        }

        //判断盘主阴阳
        public void getyingyang(ref ZiWeiMod mod)
        {
            int tempy = ((int)mod.BirthTime.NongliTG + 1) % 2;
            mod.ShuXing = (PublicValue.ShuXing)Enum.Parse(typeof(PublicValue.ShuXing), tempy.ToString());
            return;
        }

        //起各宫大限
        public void gettransit(ref ZiWeiMod mod)
        {
            if ((int)mod.Gender + (int)mod.ShuXing != 1)
            {
                for (int i = 0; i <= 8; i++)
                {
                    mod.Gong[(mod.Ming + i) % 12].TransitA = i * 10 + (int)mod.MingJu;
                    mod.Gong[(mod.Ming + i) % 12].TransitB = (i + 1) * 10 + (int)mod.MingJu - 1;
                }
            }
            else
            {
                for (int i = 0; i <= 8; i++)
                {
                    mod.Gong[(mod.Ming - i + 12) % 12].TransitA = i * 10 + (int)mod.MingJu;
                    mod.Gong[(mod.Ming - i + 12) % 12].TransitB = (i + 1) * 10 + (int)mod.MingJu - 1;
                }
            }
            return;
        }

        //起紫微星
        public void getzwstar(ref ZiWeiMod mod)
        {
            int[] gongindex = { 7, 4, 9, 2, 11, 0 };

            int yu = (int)mod.BirthTime.NongliDay % (int)mod.MingJu;
            int shang = (int)mod.BirthTime.NongliDay / (int)mod.MingJu;

            int tmp = 5 - (int)mod.MingJu + yu;

            if (yu == 0)
            {
                mod.Xing[0].Gong = (shang - 1) % 12;
            }
            else if ((int)mod.BirthTime.NongliDay < (int)mod.MingJu)
            {
                mod.Xing[0].Gong = gongindex[tmp] % 12;
            }
            else
            {
                mod.Xing[0].Gong = (gongindex[tmp] + shang) % 12;
            }
            return;
        }

        //安十四正耀
        public void setmainstar(ref ZiWeiMod mod)
        {
            int ziwei = mod.Xing[0].Gong;//获取紫薇星宫位号
            for (int i = 0; i <= 11; i++)
            {
                if (BeiDouMain[i] != PublicValue.ZiWeiStar.wu)
                {
                    mod.Xing[(int)BeiDouMain[i]].Gong = (ziwei - i + 12) % 12;
                }
            }
            for (int i = 0; i <= 11; i++)
            {
                if (NanDouMain[i] != PublicValue.ZiWeiStar.wu)
                {
                    mod.Xing[(int)NanDouMain[i]].Gong = ((12-ziwei) % 12 + i) % 12;
                }
            }
        }

        //安6辅星,左辅、右弼、文昌、文曲、天魁、天钺
        public void setassiststar(ref ZiWeiMod mod)
        {
            PublicValue.TianGan yeartg = mod.BirthTime.NongliTG;//此处为农历年天干
            //安左辅
            mod.Xing[(int)PublicValue.ZiWeiStar.zuofu].Gong = (2 + mod.TmpMonth - 1) % 12;
            //安右弼
            mod.Xing[(int)PublicValue.ZiWeiStar.youbi].Gong = (8 - mod.TmpMonth + 1 + 12) % 12;
            //安文曲
            mod.Xing[(int)PublicValue.ZiWeiStar.wenqu].Gong = (2 + (int)mod.BirthTime.NongliHour) % 12;
            //安文昌
            mod.Xing[(int)PublicValue.ZiWeiStar.wenchang].Gong = (8 - (int)mod.BirthTime.NongliHour+12) % 12;
            //安天魁天钺
            if (yeartg == PublicValue.TianGan.jia || yeartg == PublicValue.TianGan.wu || yeartg == PublicValue.TianGan.geng)
            {
                mod.Xing[(int)PublicValue.ZiWeiStar.tiankui].Gong = 11;
                mod.Xing[(int)PublicValue.ZiWeiStar.tianyue].Gong = 5;
            }
            else if (yeartg == PublicValue.TianGan.yi || yeartg == PublicValue.TianGan.ji)
            {
                mod.Xing[(int)PublicValue.ZiWeiStar.tiankui].Gong = 10;
                mod.Xing[(int)PublicValue.ZiWeiStar.tianyue].Gong = 6;
            }
            else if (yeartg == PublicValue.TianGan.bing || yeartg == PublicValue.TianGan.ding)
            {
                mod.Xing[(int)PublicValue.ZiWeiStar.tiankui].Gong = 9;
                mod.Xing[(int)PublicValue.ZiWeiStar.tianyue].Gong = 7;
            }
            else if (yeartg == PublicValue.TianGan.xin)
            {
                mod.Xing[(int)PublicValue.ZiWeiStar.tiankui].Gong = 4;
                mod.Xing[(int)PublicValue.ZiWeiStar.tianyue].Gong = 0;
            }
            else if (yeartg == PublicValue.TianGan.ren || yeartg == PublicValue.TianGan.gui)
            {
                mod.Xing[(int)PublicValue.ZiWeiStar.tiankui].Gong = 1;
                mod.Xing[(int)PublicValue.ZiWeiStar.tianyue].Gong = 3;
            }
            return;
        }

        //安天马、禄存
        public void setluma(ref ZiWeiMod mod, int tianma)
        {
            PublicValue.TianGan yeartg = mod.BirthTime.NongliTG;//此处为农历年天干
            //安禄存
            if (yeartg == PublicValue.TianGan.jia)
                mod.Xing[(int)PublicValue.ZiWeiStar.lucun].Gong = 0;
            else if (yeartg == PublicValue.TianGan.yi)
                mod.Xing[(int)PublicValue.ZiWeiStar.lucun].Gong = 1;
            else if (yeartg == PublicValue.TianGan.bing || yeartg == PublicValue.TianGan.wu)
                mod.Xing[(int)PublicValue.ZiWeiStar.lucun].Gong = 3;
            else if (yeartg == PublicValue.TianGan.ding || yeartg == PublicValue.TianGan.ji)
                mod.Xing[(int)PublicValue.ZiWeiStar.lucun].Gong = 4;
            else if (yeartg == PublicValue.TianGan.geng)
                mod.Xing[(int)PublicValue.ZiWeiStar.lucun].Gong = 6;
            else if (yeartg == PublicValue.TianGan.xin)
                mod.Xing[(int)PublicValue.ZiWeiStar.lucun].Gong = 7;
            else if (yeartg == PublicValue.TianGan.ren)
                mod.Xing[(int)PublicValue.ZiWeiStar.lucun].Gong = 9;
            else if (yeartg == PublicValue.TianGan.gui)
                mod.Xing[(int)PublicValue.ZiWeiStar.lucun].Gong = 10;
            //安天马
            int tmp = 0;
            if (tianma == 1)
            {
                tmp = 9 - ((mod.TmpMonth) % 4) * 3;//月马
            }
            else
            {
                tmp = (12 - (int)mod.BirthTime.NongliDZ % 4 * 3) % 12;//年马
            }
            mod.Xing[(int)PublicValue.ZiWeiStar.tianma].Gong = tmp;
            return;
        }

        //安六煞星 擎羊、陀罗、火星、铃星、地空、地劫
        public void setbadstar(ref ZiWeiMod mod)
        {
            PublicValue.DiZhi yeardz = mod.BirthTime.NongliDZ;//此处为农历年支
            //安擎羊
            mod.Xing[(int)PublicValue.ZiWeiStar.qingyang].Gong = (mod.Xing[(int)PublicValue.ZiWeiStar.lucun].Gong + 1)%12;
            //安陀罗
            mod.Xing[(int)PublicValue.ZiWeiStar.tuoluo].Gong = (mod.Xing[(int)PublicValue.ZiWeiStar.lucun].Gong - 1+12)%12;
            //安火铃
            switch ((int)yeardz % 4)
            {
                case 0:
                    mod.Xing[(int)PublicValue.ZiWeiStar.huoxing].Gong = 0;
                    mod.Xing[(int)PublicValue.ZiWeiStar.lingxing].Gong = 8;
                    break;
                case 1:
                    mod.Xing[(int)PublicValue.ZiWeiStar.huoxing].Gong = 1;
                    mod.Xing[(int)PublicValue.ZiWeiStar.lingxing].Gong = 8;
                    break;
                case 2:
                    mod.Xing[(int)PublicValue.ZiWeiStar.huoxing].Gong = 11;
                    mod.Xing[(int)PublicValue.ZiWeiStar.lingxing].Gong = 1;
                    break;
                case 3:
                    mod.Xing[(int)PublicValue.ZiWeiStar.huoxing].Gong = 7;
                    mod.Xing[(int)PublicValue.ZiWeiStar.lingxing].Gong = 8;
                    break;
            }
            mod.Xing[(int)PublicValue.ZiWeiStar.huoxing].Gong = (mod.Xing[(int)PublicValue.ZiWeiStar.huoxing].Gong + (int)mod.BirthTime.NongliHour) % 12;
            mod.Xing[(int)PublicValue.ZiWeiStar.lingxing].Gong = (mod.Xing[(int)PublicValue.ZiWeiStar.lingxing].Gong + (int)mod.BirthTime.NongliHour) % 12;
            //安地空
            mod.Xing[(int)PublicValue.ZiWeiStar.dikong].Gong = (9 - (int)mod.BirthTime.NongliHour + 12) % 12;
            //安地劫
            mod.Xing[(int)PublicValue.ZiWeiStar.dijie].Gong = (9 + (int)mod.BirthTime.NongliHour) % 12;
            return;
        }

        //安天官、天福
        public void setguanfo(ref ZiWeiMod mod)
        {
            PublicValue.TianGan yeartg = mod.BirthTime.NongliTG;//此处取农历天干

            switch((int)yeartg)
            {
                case 0:
                    mod.Xing[(int)PublicValue.ZiWeiStar.tianguan].Gong = 5;
                    mod.Xing[(int)PublicValue.ZiWeiStar.tianfo].Gong = 7;
                    break;
                case 1:
                    mod.Xing[(int)PublicValue.ZiWeiStar.tianguan].Gong = 2;
                    mod.Xing[(int)PublicValue.ZiWeiStar.tianfo].Gong = 6;
                    break;
                case 2:
                    mod.Xing[(int)PublicValue.ZiWeiStar.tianguan].Gong = 3;
                    mod.Xing[(int)PublicValue.ZiWeiStar.tianfo].Gong = 10;
                    break;
                case 3:
                    mod.Xing[(int)PublicValue.ZiWeiStar.tianguan].Gong = 0;
                    mod.Xing[(int)PublicValue.ZiWeiStar.tianfo].Gong = 9;
                    break;
                case 4:
                    mod.Xing[(int)PublicValue.ZiWeiStar.tianguan].Gong = 1;
                    mod.Xing[(int)PublicValue.ZiWeiStar.tianfo].Gong = 1;
                    break;
                case 5:
                    mod.Xing[(int)PublicValue.ZiWeiStar.tianguan].Gong = 7;
                    mod.Xing[(int)PublicValue.ZiWeiStar.tianfo].Gong = 0;
                    break;
                case 6:
                    mod.Xing[(int)PublicValue.ZiWeiStar.tianguan].Gong = 9;
                    mod.Xing[(int)PublicValue.ZiWeiStar.tianfo].Gong = 4;
                    break;
                case 7:
                    mod.Xing[(int)PublicValue.ZiWeiStar.tianguan].Gong = 7;
                    mod.Xing[(int)PublicValue.ZiWeiStar.tianfo].Gong = 3;
                    break;
                case 8:
                    mod.Xing[(int)PublicValue.ZiWeiStar.tianguan].Gong = 8;
                    mod.Xing[(int)PublicValue.ZiWeiStar.tianfo].Gong = 4;
                    break;
                case 9:
                    mod.Xing[(int)PublicValue.ZiWeiStar.tianguan].Gong = 4;
                    mod.Xing[(int)PublicValue.ZiWeiStar.tianfo].Gong = 3;
                    break;
            }
            return;
        }

        //安四化星
        public void setsihua(ref ZiWeiMod mod)
        {
            PublicValue.TianGan yeartg = mod.BirthTime.NongliTG;

            switch ((int)yeartg)
            {
                case 0:
                    mod.Xing[(int)PublicValue.ZiWeiStar.lianzhen].Hua = PublicValue.ZiWeiSihua.lu;
                    mod.Xing[(int)PublicValue.ZiWeiStar.pojun].Hua = PublicValue.ZiWeiSihua.quan;
                    mod.Xing[(int)PublicValue.ZiWeiStar.wuqu].Hua = PublicValue.ZiWeiSihua.ke;
                    mod.Xing[(int)PublicValue.ZiWeiStar.taiyang].Hua = PublicValue.ZiWeiSihua.ji;
                    break;
                case 1:
                    mod.Xing[(int)PublicValue.ZiWeiStar.tianji].Hua = PublicValue.ZiWeiSihua.lu;
                    mod.Xing[(int)PublicValue.ZiWeiStar.tianliang].Hua = PublicValue.ZiWeiSihua.quan;
                    mod.Xing[(int)PublicValue.ZiWeiStar.ziwei].Hua = PublicValue.ZiWeiSihua.ke;
                    mod.Xing[(int)PublicValue.ZiWeiStar.taiyin].Hua = PublicValue.ZiWeiSihua.ji;
                    break;
                case 2:
                    mod.Xing[(int)PublicValue.ZiWeiStar.tiantong].Hua = PublicValue.ZiWeiSihua.lu;
                    mod.Xing[(int)PublicValue.ZiWeiStar.tianji].Hua = PublicValue.ZiWeiSihua.quan;
                    mod.Xing[(int)PublicValue.ZiWeiStar.wenchang].Hua = PublicValue.ZiWeiSihua.ke;
                    mod.Xing[(int)PublicValue.ZiWeiStar.lianzhen].Hua = PublicValue.ZiWeiSihua.ji;
                    break;
                case 3:
                    mod.Xing[(int)PublicValue.ZiWeiStar.taiyin].Hua = PublicValue.ZiWeiSihua.lu;
                    mod.Xing[(int)PublicValue.ZiWeiStar.tiantong].Hua = PublicValue.ZiWeiSihua.quan;
                    mod.Xing[(int)PublicValue.ZiWeiStar.tianji].Hua = PublicValue.ZiWeiSihua.ke;
                    mod.Xing[(int)PublicValue.ZiWeiStar.jvmen].Hua = PublicValue.ZiWeiSihua.ji;
                    break;
                case 4:
                    mod.Xing[(int)PublicValue.ZiWeiStar.tanlang].Hua = PublicValue.ZiWeiSihua.lu;
                    mod.Xing[(int)PublicValue.ZiWeiStar.taiyin].Hua = PublicValue.ZiWeiSihua.quan;
                    mod.Xing[(int)PublicValue.ZiWeiStar.taiyang].Hua = PublicValue.ZiWeiSihua.ke;
                    mod.Xing[(int)PublicValue.ZiWeiStar.tianji].Hua = PublicValue.ZiWeiSihua.ji;
                    break;
                case 5:
                    mod.Xing[(int)PublicValue.ZiWeiStar.wuqu].Hua = PublicValue.ZiWeiSihua.lu;
                    mod.Xing[(int)PublicValue.ZiWeiStar.tanlang].Hua = PublicValue.ZiWeiSihua.quan;
                    mod.Xing[(int)PublicValue.ZiWeiStar.tianliang].Hua = PublicValue.ZiWeiSihua.ke;
                    mod.Xing[(int)PublicValue.ZiWeiStar.wenqu].Hua = PublicValue.ZiWeiSihua.ji;
                    break;
                case 6:
                    mod.Xing[(int)PublicValue.ZiWeiStar.taiyang].Hua = PublicValue.ZiWeiSihua.lu;
                    mod.Xing[(int)PublicValue.ZiWeiStar.wuqu].Hua = PublicValue.ZiWeiSihua.quan;
                    mod.Xing[(int)PublicValue.ZiWeiStar.taiyin].Hua = PublicValue.ZiWeiSihua.ke;
                    mod.Xing[(int)PublicValue.ZiWeiStar.tiantong].Hua = PublicValue.ZiWeiSihua.ji;
                    break;
                case 7:
                    mod.Xing[(int)PublicValue.ZiWeiStar.jvmen].Hua = PublicValue.ZiWeiSihua.lu;
                    mod.Xing[(int)PublicValue.ZiWeiStar.taiyang].Hua = PublicValue.ZiWeiSihua.quan;
                    mod.Xing[(int)PublicValue.ZiWeiStar.wenqu].Hua = PublicValue.ZiWeiSihua.ke;
                    mod.Xing[(int)PublicValue.ZiWeiStar.wenchang].Hua = PublicValue.ZiWeiSihua.ji;
                    break;
                case 8:
                    mod.Xing[(int)PublicValue.ZiWeiStar.tianliang].Hua = PublicValue.ZiWeiSihua.lu;
                    mod.Xing[(int)PublicValue.ZiWeiStar.ziwei].Hua = PublicValue.ZiWeiSihua.quan;
                    mod.Xing[(int)PublicValue.ZiWeiStar.tianfu].Hua = PublicValue.ZiWeiSihua.ke;
                    mod.Xing[(int)PublicValue.ZiWeiStar.wuqu].Hua = PublicValue.ZiWeiSihua.ji;
                    break;
                case 9:
                    mod.Xing[(int)PublicValue.ZiWeiStar.pojun].Hua = PublicValue.ZiWeiSihua.lu;
                    mod.Xing[(int)PublicValue.ZiWeiStar.jvmen].Hua = PublicValue.ZiWeiSihua.quan;
                    mod.Xing[(int)PublicValue.ZiWeiStar.taiyin].Hua = PublicValue.ZiWeiSihua.ke;
                    mod.Xing[(int)PublicValue.ZiWeiStar.tanlang].Hua = PublicValue.ZiWeiSihua.ji;
                    break;
            }
            return;
        }

        //安截空旬空
        public void setkong(ref ZiWeiMod mod)
        {
            PublicValue.TianGan yeartg = mod.BirthTime.NongliTG;//农历年干
            //截空
            int tmp = (6 - (int)yeartg % 5 * 2 + 12) % 12 + (int)yeartg / 5;
            mod.Xing[(int)PublicValue.ZiWeiStar.jiekong].Gong = tmp;
            //旬空
            int temp = (9 - (int)mod.BirthTime.NongliTG + (int)mod.BirthTime.NongliDZ + 1) % 12;

            if ((int)mod.BirthTime.NongliTG % 2 == 0)
            {
                mod.Xing[(int)PublicValue.ZiWeiStar.xunkong].Gong = (temp - 2+12)%12;
            }
            else
            {
                mod.Xing[(int)PublicValue.ZiWeiStar.xunkong].Gong = (temp - 1+12)%12;
            }
            return;
        }

        //安天喜、红鸾
        public void settaohua(ref ZiWeiMod mod)
        {
            PublicValue.DiZhi yeardz = mod.BirthTime.NongliDZ;//农历年支
            //红鸾
            mod.Xing[(int)PublicValue.ZiWeiStar.hongluan].Gong = (1-(int)yeardz+12)%12;
            //天喜
            mod.Xing[(int)PublicValue.ZiWeiStar.tianxi].Gong = (mod.Xing[(int)PublicValue.ZiWeiStar.hongluan].Gong + 6) % 12;
            return;
        }

        //安龙池凤阁三台八座
        public void setfangchan(ref ZiWeiMod mod)
        {
            PublicValue.DiZhi yeardz = mod.BirthTime.NongliDZ;//农历年支
            //龙池
            mod.Xing[(int)PublicValue.ZiWeiStar.longchi].Gong = (2 + (int)yeardz) % 12;
            //凤阁
            mod.Xing[(int)PublicValue.ZiWeiStar.fengge].Gong = (8 - (int)yeardz+12) % 12;
            //三台
            mod.Xing[(int)PublicValue.ZiWeiStar.santai].Gong = (mod.Xing[(int)PublicValue.ZiWeiStar.zuofu].Gong + (int)mod.BirthTime.NongliDay - 1) % 12;
            //八座
            mod.Xing[(int)PublicValue.ZiWeiStar.bazuo].Gong = (mod.Xing[(int)PublicValue.ZiWeiStar.youbi].Gong - ((int)mod.BirthTime.NongliDay - 1) + 36) % 12;
            return;
        }

        //安天才天寿
        public void setcaishou(ref ZiWeiMod mod)
        {
            PublicValue.DiZhi yeardz = mod.BirthTime.NongliDZ;//农历年支
            //天才
            mod.Xing[(int)PublicValue.ZiWeiStar.tiancai].Gong = (mod.Ming + (int)yeardz) % 12;
            //天寿
            mod.Xing[(int)PublicValue.ZiWeiStar.tianshou].Gong = (mod.Shen + (int)yeardz) % 12;
            return;
        }

        //安孤辰寡宿
        public void setguxing(ref ZiWeiMod mod)
        {
            PublicValue.DiZhi yeardz = mod.BirthTime.NongliDZ;//农历年支
            int tmp = ((int)yeardz + 1) / 3 * 3;
            mod.Xing[(int)PublicValue.ZiWeiStar.guchen].Gong = tmp%12;
            mod.Xing[(int)PublicValue.ZiWeiStar.guasu].Gong = (tmp - 4 + 12) % 12;
            return;
        }

        //安台辅封诰
        public void setwenguan(ref ZiWeiMod mod)
        {
            mod.Xing[(int)PublicValue.ZiWeiStar.taifu].Gong = (mod.Xing[(int)PublicValue.ZiWeiStar.wenqu].Gong + 2) % 12;
            mod.Xing[(int)PublicValue.ZiWeiStar.fenggao].Gong = (mod.Xing[(int)PublicValue.ZiWeiStar.wenqu].Gong - 2 + 12) % 12;
            return;
        }

        //安月干众星，天刑、天姚、解神、天巫、天月、阴煞
        public void setmonthstars(ref ZiWeiMod mod)
        {
            //安天刑
            mod.Xing[(int)PublicValue.ZiWeiStar.tianxing].Gong = (7 + mod.TmpMonth - 1) % 12;
            //安天姚
            mod.Xing[(int)PublicValue.ZiWeiStar.tianyao].Gong = (11 + mod.TmpMonth - 1) % 12;
            //安解神
            mod.Xing[(int)PublicValue.ZiWeiStar.jieshen].Gong = ((mod.TmpMonth + 1) / 2* 2 + 4)  % 12;
            //安天巫
            int tmp = mod.TmpMonth % 4;
            switch (tmp)
            {
                case 0:
                    mod.Xing[(int)PublicValue.ZiWeiStar.tianwu].Gong = 9;
                    break;
                case 1:
                    mod.Xing[(int)PublicValue.ZiWeiStar.tianwu].Gong = 3;
                    break;
                case 2:
                    mod.Xing[(int)PublicValue.ZiWeiStar.tianwu].Gong = 6;
                    break;
                case 3:
                    mod.Xing[(int)PublicValue.ZiWeiStar.tianwu].Gong = 0;
                    break;
            }
            //安天月
            switch (mod.TmpMonth)
            {
                case 1:
                    mod.Xing[(int)PublicValue.ZiWeiStar.tianyu].Gong = 8;
                    break;
                case 2:
                    mod.Xing[(int)PublicValue.ZiWeiStar.tianyu].Gong = 3;
                    break;
                case 3:
                    mod.Xing[(int)PublicValue.ZiWeiStar.tianyu].Gong = 2;
                    break;
                case 4:
                    mod.Xing[(int)PublicValue.ZiWeiStar.tianyu].Gong = 0;
                    break;
                case 5:
                    mod.Xing[(int)PublicValue.ZiWeiStar.tianyu].Gong = 5;
                    break;
                case 6:
                    mod.Xing[(int)PublicValue.ZiWeiStar.tianyu].Gong = 1;
                    break;
                case 7:
                    mod.Xing[(int)PublicValue.ZiWeiStar.tianyu].Gong = 9;
                    break;
                case 8:
                    mod.Xing[(int)PublicValue.ZiWeiStar.tianyu].Gong = 5;
                    break;
                case 9:
                    mod.Xing[(int)PublicValue.ZiWeiStar.tianyu].Gong = 0;
                    break;
                case 10:
                    mod.Xing[(int)PublicValue.ZiWeiStar.tianyu].Gong = 4;
                    break;
                case 11:
                    mod.Xing[(int)PublicValue.ZiWeiStar.tianyu].Gong = 8;
                    break;
                case 12:
                    mod.Xing[(int)PublicValue.ZiWeiStar.tianyu].Gong = 0;
                    break;
            }
            //安阴煞
            mod.Xing[(int)PublicValue.ZiWeiStar.yinsha].Gong = (12 - (mod.TmpMonth-1) % 6 * 2) % 12;
            return;
        }

        //安天伤、天使、恩光、天贵
        public void setdaystars(ref ZiWeiMod mod,int type)
        {
            //安天伤天使
            int puyi = 0;
            for(int i=0;i<12;i++)
            {
                if(mod.Gong[i].GongName == PublicValue.ZiWeiGong.puyi)
                {
                    puyi = i;
                    break;
                }
            }
            if (type == 0)  //阴阳不同
            {
                if ((int)mod.Gender + (int)mod.ShuXing == 1)
                {
                    mod.Xing[(int)PublicValue.ZiWeiStar.tianshang].Gong = (puyi + 2) % 12;
                    mod.Xing[(int)PublicValue.ZiWeiStar.tianshi].Gong = puyi;
                }
                else
                {
                    mod.Xing[(int)PublicValue.ZiWeiStar.tianshi].Gong = (puyi + 2) % 12;
                    mod.Xing[(int)PublicValue.ZiWeiStar.tianshang].Gong = puyi;
                }
            }
            else if (type == 1)  //阴阳相同
            {
                mod.Xing[(int)PublicValue.ZiWeiStar.tianshi].Gong = (puyi + 2) % 12;
                mod.Xing[(int)PublicValue.ZiWeiStar.tianshang].Gong = puyi;
            }
            //安恩光天贵
            mod.Xing[(int)PublicValue.ZiWeiStar.enguang].Gong = (mod.Xing[(int)PublicValue.ZiWeiStar.wenchang].Gong + (int)mod.BirthTime.NongliDay - 2+12) % 12;
            mod.Xing[(int)PublicValue.ZiWeiStar.tiangui].Gong = (mod.Xing[(int)PublicValue.ZiWeiStar.wenqu].Gong + (int)mod.BirthTime.NongliDay - 2+12) % 12;
            return;
        }

        //安年干众星，天厨、天空、天哭、天虚、劫杀、大耗、蜚廉、破碎、华盖、咸池、龙德、月德、天德、年解
        public void setyearstars(ref ZiWeiMod mod)
        {
            PublicValue.TianGan yeartg = mod.BirthTime.NongliTG;
            PublicValue.DiZhi yeardz = mod.BirthTime.NongliDZ;
            //安天厨
            if (yeartg == PublicValue.TianGan.jia || yeartg == PublicValue.TianGan.ding)
            {
                mod.Xing[(int)PublicValue.ZiWeiStar.tianchu].Gong = 3;
            }
            else if (yeartg == PublicValue.TianGan.yi || yeartg == PublicValue.TianGan.wu || yeartg == PublicValue.TianGan.xin)
            {
                mod.Xing[(int)PublicValue.ZiWeiStar.tianchu].Gong = 4;
            }
            else if (yeartg == PublicValue.TianGan.bing)
            {
                mod.Xing[(int)PublicValue.ZiWeiStar.tianchu].Gong = 10;
            }
            else if (yeartg == PublicValue.TianGan.ji)
            {
                mod.Xing[(int)PublicValue.ZiWeiStar.tianchu].Gong = 6;
            }
            else if (yeartg == PublicValue.TianGan.geng)
            {
                mod.Xing[(int)PublicValue.ZiWeiStar.tianchu].Gong = 0;
            }
            else if (yeartg == PublicValue.TianGan.ren)
            {
                mod.Xing[(int)PublicValue.ZiWeiStar.tianchu].Gong = 7;
            }
            else if (yeartg == PublicValue.TianGan.gui)
            {
                mod.Xing[(int)PublicValue.ZiWeiStar.tianchu].Gong = 9;
            }
            //安天空
            mod.Xing[(int)PublicValue.ZiWeiStar.tiankong].Gong = ((int)yeardz - 1 + 12) % 12;
            //安天哭
            mod.Xing[(int)PublicValue.ZiWeiStar.tianku].Gong = (4 - (int)yeardz + 12) % 12;
            //安天虚
            mod.Xing[(int)PublicValue.ZiWeiStar.tianxu].Gong = (4 + (int)yeardz) % 12;
            //安劫杀
            mod.Xing[(int)PublicValue.ZiWeiStar.jiesha].Gong = (-(int)yeardz % 4 * 3 - 3 + 12) % 12;
            //安大耗
            mod.Xing[(int)PublicValue.ZiWeiStar.dahao].Gong = (int)yeardz + 6;
            if ((int)yeardz / 2 == 0)
            {
                mod.Xing[(int)PublicValue.ZiWeiStar.dahao].Gong = (mod.Xing[(int)PublicValue.ZiWeiStar.dahao].Gong + 1) % 12;
            }
            else
            {
                mod.Xing[(int)PublicValue.ZiWeiStar.dahao].Gong = (mod.Xing[(int)PublicValue.ZiWeiStar.dahao].Gong - 1) % 12;
            }
            //安蜚廉
            int tmp = ((int)yeardz + 6) / 3 * 3;
            mod.Xing[(int)PublicValue.ZiWeiStar.chilian].Gong = ((int)yeardz % 3 - tmp + 24) % 12;
            //安破碎
            mod.Xing[(int)PublicValue.ZiWeiStar.posui].Gong = (12 - (int)yeardz % 3 * 4 + 3) % 12;
            //安华盖
            mod.Xing[(int)PublicValue.ZiWeiStar.huagai].Gong = (12 - (int)yeardz % 4 * 3 + 2) % 12;
            //安咸池
            mod.Xing[(int)PublicValue.ZiWeiStar.xianchi].Gong = (12 - (int)yeardz % 4 * 3 + 7) % 12;
            //安龙德
            mod.Xing[(int)PublicValue.ZiWeiStar.longde].Gong = ((int)yeardz + 5) % 12;
            //安月德
            mod.Xing[(int)PublicValue.ZiWeiStar.yuede].Gong = ((int)yeardz + 3) % 12;
            //安天德
            mod.Xing[(int)PublicValue.ZiWeiStar.tiande].Gong = ((int)yeardz + 7) % 12;
            //安年解
            mod.Xing[(int)PublicValue.ZiWeiStar.nianjie].Gong = (12 - (int)yeardz + 8) % 12;
        }

        //安命主、身主
        public void setmingshenzhu(ref ZiWeiMod mod, int type)
        {
            //安命主
            int tmp = 0;
            if (type == 1)     //按生年年支安
            {
                tmp = ((int)mod.BirthTime.NongliDZ - 2 + 12) % 12;
            }
            else     //按命宫地支安
            {
                tmp = (int)mod.Ming;
            }
            switch (tmp)
            {
                case 0:
                    mod.MingZhu = PublicValue.ZiWeiStar.lucun;
                    break;
                case 1:
                    mod.MingZhu = PublicValue.ZiWeiStar.wenqu;
                    break;
                case 2:
                    mod.MingZhu = PublicValue.ZiWeiStar.lianzhen;
                    break;
                case 3:
                    mod.MingZhu = PublicValue.ZiWeiStar.wuqu;
                    break;
                case 4:
                    mod.MingZhu = PublicValue.ZiWeiStar.pojun;
                    break;
                case 5:
                    mod.MingZhu = PublicValue.ZiWeiStar.wuqu;
                    break;
                case 6:
                    mod.MingZhu = PublicValue.ZiWeiStar.lianzhen;
                    break;
                case 7:
                    mod.MingZhu = PublicValue.ZiWeiStar.wenqu;
                    break;
                case 8:
                    mod.MingZhu = PublicValue.ZiWeiStar.lucun;
                    break;
                case 9:
                    mod.MingZhu = PublicValue.ZiWeiStar.jvmen;
                    break;
                case 10:
                    mod.MingZhu = PublicValue.ZiWeiStar.tanlang;
                    break;
                case 11:
                    mod.MingZhu = PublicValue.ZiWeiStar.jvmen;
                    break;
            }
            //安身主
            switch (((int)mod.BirthTime.NongliDZ - 2 + 12) % 6)
            {
                case 0:
                    mod.ShenZhu = PublicValue.ZiWeiStar.tianliang;
                    break;
                case 1:
                    mod.ShenZhu = PublicValue.ZiWeiStar.tiantong;
                    break;
                case 2:
                    mod.ShenZhu = PublicValue.ZiWeiStar.wenchang;
                    break;
                case 3:
                    mod.ShenZhu = PublicValue.ZiWeiStar.tianji;
                    break;
                case 4:
                    mod.ShenZhu = PublicValue.ZiWeiStar.huoxing;
                    break;
                case 5:
                    mod.ShenZhu = PublicValue.ZiWeiStar.tianxiang;
                    break;
            }
            return;
        }

        //安长生十二神
        public void changsheng(ref ZiWeiMod mod)
        {
            int tmp = 0;
            switch ((int)mod.MingJu)
            {
                case 2:
                    tmp = 6;
                    break;
                case 3:
                    tmp = 9;
                    break;
                case 4:
                    tmp = 3;
                    break;
                case 5:
                    tmp = 6;
                    break;
                case 6:
                    tmp = 0;
                    break;
            }
            if ((int)mod.ShuXing + (int)mod.Gender == 1)
            {
                for (int i = 0; i < 12; i++)
                {
                    mod.Gong[(tmp - i + 12) % 12].ChangSheng = (PublicValue.ZiWeiChangSheng)Enum.Parse(typeof(PublicValue.ZiWeiChangSheng), i.ToString());
                }
            }
            else
            {
                for (int i = 0; i < 12; i++)
                {
                    mod.Gong[(tmp + i) % 12].ChangSheng = (PublicValue.ZiWeiChangSheng)Enum.Parse(typeof(PublicValue.ZiWeiChangSheng), i.ToString());
                }
            }
            return;
        }

        //安太岁十二神
        public void taisui(ref ZiWeiMod mod)
        {
            int tmp = ((int)mod.BirthTime.NongliDZ - 2 + 12) % 12;
            for (int i = 0; i < 12; i++)
            {
                mod.Gong[(tmp + i) % 12].TaiSui = (PublicValue.ZiWeiTaiSui)Enum.Parse(typeof(PublicValue.ZiWeiTaiSui), i.ToString());
            }
            return;
        }

        //安将前十二神
        public void jiangqian(ref ZiWeiMod mod)
        {
            int tmp = 0;
            switch (mod.BirthTime.NongliDZ)
            {
                case PublicValue.DiZhi.shen:
                case PublicValue.DiZhi.zi:
                case PublicValue.DiZhi.chen:
                    tmp = 10;
                    break;
                case PublicValue.DiZhi.yin:
                case PublicValue.DiZhi.wu:
                case PublicValue.DiZhi.xu:
                    tmp = 4;
                    break;
                case PublicValue.DiZhi.si:
                case PublicValue.DiZhi.you:
                case PublicValue.DiZhi.chou:
                    tmp = 7;
                    break;
                case PublicValue.DiZhi.hai:
                case PublicValue.DiZhi.mao:
                case PublicValue.DiZhi.wei:
                    tmp = 1;
                    break;
            }
            for (int i = 0; i < 12; i++)
            {
                mod.Gong[(tmp + i) % 12].JiangQian = (PublicValue.ZiWeiJiangQian)Enum.Parse(typeof(PublicValue.ZiWeiJiangQian), i.ToString());
            }
            return;
        }

        //安生年博士十二神
        public void boshi(ref ZiWeiMod mod)
        {
            int tmp = mod.Xing[(int)PublicValue.ZiWeiStar.lucun].Gong;
            if ((int)mod.ShuXing + (int)mod.Gender == 1)
            {
                for (int i = 0; i < 12; i++)
                {
                    mod.Gong[(tmp - i + 12) % 12].BoShi = (PublicValue.ZiWeiBoShi)Enum.Parse(typeof(PublicValue.ZiWeiBoShi), i.ToString());
                }
            }
            else
            {
                for (int i = 0; i < 12; i++)
                {
                    mod.Gong[(tmp + i) % 12].BoShi = (PublicValue.ZiWeiBoShi)Enum.Parse(typeof(PublicValue.ZiWeiBoShi), i.ToString());
                }
            }
            return;
        }

        //设庙旺
        public void SetMiaoWang(ref ZiWeiMod mod)
        {
            mod.Xing[(int)PublicValue.ZiWeiStar.ziwei].Wang = ZiweiMiaowang[mod.Xing[(int)PublicValue.ZiWeiStar.ziwei].Gong];
            mod.Xing[(int)PublicValue.ZiWeiStar.tianji].Wang = TianjiMiaowang[mod.Xing[(int)PublicValue.ZiWeiStar.tianji].Gong];
            mod.Xing[(int)PublicValue.ZiWeiStar.taiyang].Wang = TaiyangMiaowang[mod.Xing[(int)PublicValue.ZiWeiStar.taiyang].Gong];
            mod.Xing[(int)PublicValue.ZiWeiStar.wuqu].Wang = WuquMiaowang[mod.Xing[(int)PublicValue.ZiWeiStar.wuqu].Gong];
            mod.Xing[(int)PublicValue.ZiWeiStar.tiantong].Wang = TiantongMiaowang[mod.Xing[(int)PublicValue.ZiWeiStar.tiantong].Gong];
            mod.Xing[(int)PublicValue.ZiWeiStar.lianzhen].Wang = LianzhenMiaowang[mod.Xing[(int)PublicValue.ZiWeiStar.lianzhen].Gong];
            mod.Xing[(int)PublicValue.ZiWeiStar.tianfu].Wang = TianfuMiaowang[mod.Xing[(int)PublicValue.ZiWeiStar.tianfu].Gong];
            mod.Xing[(int)PublicValue.ZiWeiStar.taiyin].Wang = TaiyinMiaowang[mod.Xing[(int)PublicValue.ZiWeiStar.taiyin].Gong];
            mod.Xing[(int)PublicValue.ZiWeiStar.tanlang].Wang = TanlangMiaowang[mod.Xing[(int)PublicValue.ZiWeiStar.tanlang].Gong];
            mod.Xing[(int)PublicValue.ZiWeiStar.jvmen].Wang = JvmenMiaowang[mod.Xing[(int)PublicValue.ZiWeiStar.jvmen].Gong];
            mod.Xing[(int)PublicValue.ZiWeiStar.tianxiang].Wang = TianxiangMiaowang[mod.Xing[(int)PublicValue.ZiWeiStar.tianxiang].Gong];
            mod.Xing[(int)PublicValue.ZiWeiStar.tianliang].Wang = TianliangMiaowang[mod.Xing[(int)PublicValue.ZiWeiStar.tianliang].Gong];
            mod.Xing[(int)PublicValue.ZiWeiStar.qisha].Wang = QishaMiaowang[mod.Xing[(int)PublicValue.ZiWeiStar.qisha].Gong];
            mod.Xing[(int)PublicValue.ZiWeiStar.pojun].Wang = PojunMiaowang[mod.Xing[(int)PublicValue.ZiWeiStar.pojun].Gong];

            mod.Xing[(int)PublicValue.ZiWeiStar.dikong].Wang = DikongMiaowang[mod.Xing[(int)PublicValue.ZiWeiStar.dikong].Gong];
            mod.Xing[(int)PublicValue.ZiWeiStar.dijie].Wang = DijieMiaowang[mod.Xing[(int)PublicValue.ZiWeiStar.dijie].Gong];
            mod.Xing[(int)PublicValue.ZiWeiStar.huoxing].Wang = HuoxingMiaowang[mod.Xing[(int)PublicValue.ZiWeiStar.huoxing].Gong];
            mod.Xing[(int)PublicValue.ZiWeiStar.lingxing].Wang = LingxingMiaowang[mod.Xing[(int)PublicValue.ZiWeiStar.lingxing].Gong];
            mod.Xing[(int)PublicValue.ZiWeiStar.qingyang].Wang = QingyangMiaowang[mod.Xing[(int)PublicValue.ZiWeiStar.qingyang].Gong];
            mod.Xing[(int)PublicValue.ZiWeiStar.tuoluo].Wang = TuoluoMiaowang[mod.Xing[(int)PublicValue.ZiWeiStar.tuoluo].Gong];

            mod.Xing[(int)PublicValue.ZiWeiStar.tianma].Wang = TianmaMiaowang[mod.Xing[(int)PublicValue.ZiWeiStar.tianma].Gong];
            mod.Xing[(int)PublicValue.ZiWeiStar.lucun].Wang = LucunMiaowang[mod.Xing[(int)PublicValue.ZiWeiStar.lucun].Gong];
            mod.Xing[(int)PublicValue.ZiWeiStar.wenqu].Wang = WenquMiaowang[mod.Xing[(int)PublicValue.ZiWeiStar.wenqu].Gong];
            mod.Xing[(int)PublicValue.ZiWeiStar.wenchang].Wang = WenchangMiaowang[mod.Xing[(int)PublicValue.ZiWeiStar.wenchang].Gong];
            mod.Xing[(int)PublicValue.ZiWeiStar.zuofu].Wang = ZuofuMiaowang[mod.Xing[(int)PublicValue.ZiWeiStar.zuofu].Gong];
            mod.Xing[(int)PublicValue.ZiWeiStar.youbi].Wang = YoubiMiaowang[mod.Xing[(int)PublicValue.ZiWeiStar.youbi].Gong];
            mod.Xing[(int)PublicValue.ZiWeiStar.tianyue].Wang = TianyueMiaowang[mod.Xing[(int)PublicValue.ZiWeiStar.tianyue].Gong];
            mod.Xing[(int)PublicValue.ZiWeiStar.tiankui].Wang = TiankuiMiaowang[mod.Xing[(int)PublicValue.ZiWeiStar.tiankui].Gong];
        }

        //设子年斗君
        public void SetZiDou(ref ZiWeiMod mod)
        {
            mod.ZiDou = (PublicValue.DiZhi)((0 - mod.TmpMonth + 1 + (int)mod.BirthTime.NongliHour + 24) % 12);
        }

        //设小限
        public void SetXiaoXian(ref ZiWeiMod mod)
        {
            mod.XiaoXian = (PublicValue.DiZhi)(((int)mod.BirthTime.NongliDZ%4*3+10)%12);
        }

        //设大运流年分别行入的宫位
        public void SetXingGong(ref ZiWeiMod mod)
        {
            //计算推运时间的农历日期
            DateTime TransitNongli = new DateTime(mod.TransitTime.Date.Year, (int)mod.TransitTime.NongliMonth % 100, (int)mod.TransitTime.NongliDay);
            if (mod.TransitTime.NongliYearFlag)
            {
                TransitNongli = TransitNongli.AddYears(-1);
            }
            if ((int)mod.TransitTime.NongliMonth > 100)
            {
                TransitNongli = new DateTime(TransitNongli.Year, TransitNongli.Month, 1, 0, 0, 0).AddMonths(1);
            }
            mod.DaYunGong = mod.Ming;

            //计算农历生日
            DateTime LiuNongliBirth = new DateTime(mod.BirthTime.Date.Year, (int)mod.TransitTime.NongliMonth % 100, (int)mod.TransitTime.NongliDay);
            if (mod.BirthTime.NongliYearFlag)
            {
                LiuNongliBirth = LiuNongliBirth.AddYears(-1);
            }
            if ((int)mod.BirthTime.NongliMonth > 100)
            {
                LiuNongliBirth = new DateTime(LiuNongliBirth.Year, LiuNongliBirth.Month, 1, 0, 0, 0).AddMonths(1);
            }
            if (mod.HuanYun == 1)//按农历新年换运
            {
                for (int i = 0; i < 12; i++)
                {
                    if (mod.Gong[i].TransitA - 1 + LiuNongliBirth.Year <= TransitNongli.Year && TransitNongli.Year <= mod.Gong[i].TransitB - 1 + LiuNongliBirth.Year)
                    {
                        mod.DaYunGong = i;
                    }
                }
                mod.Age = TransitNongli.Year - LiuNongliBirth.Year + 1;
            }
            else//按农历生日换运
            {
                for (int i = 0; i < 12; i++)
                {
                    DateTime tmpbottom = new DateTime(LiuNongliBirth.Year, LiuNongliBirth.Month, LiuNongliBirth.Day, LiuNongliBirth.Hour, LiuNongliBirth.Minute, LiuNongliBirth.Second).AddYears(mod.Gong[i].TransitA - 1);
                    DateTime tmpup = new DateTime(LiuNongliBirth.Year, LiuNongliBirth.Month, LiuNongliBirth.Day, LiuNongliBirth.Hour, LiuNongliBirth.Minute, LiuNongliBirth.Second).AddYears(mod.Gong[i].TransitB - 1);
                    if (tmpbottom <= TransitNongli && TransitNongli <= tmpup)
                    {
                        mod.DaYunGong = i;
                    }
                }
                if (new DateTime(TransitNongli.Year, LiuNongliBirth.Month, LiuNongliBirth.Day) < TransitNongli)
                {
                    mod.Age = TransitNongli.Year - LiuNongliBirth.Year + 1;
                }
                else
                {
                    mod.Age = TransitNongli.Year - LiuNongliBirth.Year;
                }
            }
            for (int i = 0; i < 12; i++)
            {
                if (mod.Gong[i].DZ == mod.TransitTime.NongliDZ)
                {
                    mod.LiuNianGong = i;
                }
            }
            mod.LiuYueGong = ((int)mod.ZiDou - 2 + (int)mod.TransitTime.NongliDZ + 12) % 12;

        }
        //设大运流年四化
        public void SetLiuSiHua(ref ZiWeiMod mod)
        {
            ZiWeiMod tmpyearmod = new ZiWeiMod();
            tmpyearmod.BirthTime.NongliTG = mod.TransitTime.NongliTG;
            setsihua(ref tmpyearmod);

            ZiWeiMod tmpyunmod = new ZiWeiMod();
            tmpyunmod.BirthTime.NongliTG = mod.Gong[mod.DaYunGong].TG;
            setsihua(ref tmpyunmod);

            for (int i = 0; i < mod.Xing.Length; i++)
            {
                mod.Xing[i].LiuHua = tmpyearmod.Xing[i].Hua;
                mod.Xing[i].YunHua = tmpyunmod.Xing[i].Hua;
            }
        }
        //设大运流年各宫
        public void SetLiuGong(ref ZiWeiMod mod)
        {
            for (int i = 0; i < 12; i++)
            {
                mod.Gong[i].LiuGongName = (PublicValue.ZiWeiGong)Enum.Parse(typeof(PublicValue.ZiWeiGong), ((mod.LiuNianGong - i + 12) % 12).ToString());
                mod.Gong[i].YunGongName = (PublicValue.ZiWeiGong)Enum.Parse(typeof(PublicValue.ZiWeiGong), ((mod.DaYunGong - i + 12) % 12).ToString());
            }
            return;
        }
        //设流曲流昌
        public void SetLiuChangQu(ref ZiWeiMod mod)
        {
            int tmp = (int)mod.TransitTime.NongliTG;
            if (tmp <= 3)
            {
                mod.LiuYao[0] = (tmp / 2 * 3 + tmp % 2 + 3) % 12;
                mod.LiuYao[1] = (7 - (tmp / 2 * 3 + tmp % 2) + 12) % 12;
            }
            else
            {
                mod.LiuYao[0] = (tmp / 2 * 3 + tmp % 2) % 12;
                mod.LiuYao[1] = (10 - (tmp / 2 * 3 + tmp % 2) + 12) % 12;
            }
            tmp = (int)mod.Gong[mod.DaYunGong].TG;
            if (tmp <= 3)
            {
                mod.YunYao[0] = (tmp / 2 * 3 + tmp % 2 + 3) % 12;
                mod.YunYao[1] = (7 - (tmp / 2 * 3 + tmp % 2) + 12) % 12;
            }
            else
            {
                mod.YunYao[0] = (tmp / 2 * 3 + tmp % 2) % 12;
                mod.YunYao[1] = (10 - (tmp / 2 * 3 + tmp % 2) + 12) % 12;
            }
        }
        //设流魁钺
        public void SetLiuKuiYue(ref ZiWeiMod mod)
        {
            ZiWeiMod tmp = new ZiWeiMod();
            tmp.BirthTime.Date = DateTime.Now;
            tmp.BirthTime.NongliTG = mod.TransitTime.NongliTG;
            setassiststar(ref tmp);
            mod.LiuYao[2] = tmp.Xing[(int)PublicValue.ZiWeiStar.tiankui].Gong;
            mod.LiuYao[3] = tmp.Xing[(int)PublicValue.ZiWeiStar.tianyue].Gong;

            tmp.BirthTime.NongliTG = mod.Gong[mod.DaYunGong].TG;
            setassiststar(ref tmp);
            mod.YunYao[2] = tmp.Xing[(int)PublicValue.ZiWeiStar.tiankui].Gong;
            mod.YunYao[3] = tmp.Xing[(int)PublicValue.ZiWeiStar.tianyue].Gong;
        }
        //设流羊陀，禄存
        public void SetLiuYangTuoLu(ref ZiWeiMod mod)
        {
            ZiWeiMod tmp = new ZiWeiMod();
            tmp.BirthTime.Date = DateTime.Now;
            tmp.BirthTime.NongliTG = mod.TransitTime.NongliTG;
            setluma(ref tmp, mod.YueMa);
            setbadstar(ref tmp);
            mod.LiuYao[4] = tmp.Xing[(int)PublicValue.ZiWeiStar.qingyang].Gong;
            mod.LiuYao[5] = tmp.Xing[(int)PublicValue.ZiWeiStar.tuoluo].Gong;
            mod.LiuYao[6] = tmp.Xing[(int)PublicValue.ZiWeiStar.lucun].Gong;

            tmp.BirthTime.NongliTG = mod.Gong[mod.DaYunGong].TG;
            setluma(ref tmp, mod.YueMa);
            setbadstar(ref tmp);
            mod.YunYao[4] = tmp.Xing[(int)PublicValue.ZiWeiStar.qingyang].Gong;
            mod.YunYao[5] = tmp.Xing[(int)PublicValue.ZiWeiStar.tuoluo].Gong;
            mod.YunYao[6] = tmp.Xing[(int)PublicValue.ZiWeiStar.lucun].Gong;
        }
        #endregion 细节算法

        public string ZiWeiToHTML(ZiWeiMod mod)
        {
            StringBuilder sb = new StringBuilder();
            string[,,] tmpgong = new string[12,7,10];//12宫，每宫7行，每行10个字
            string[] middle = new string[15];
            bool starflag = false;
            string tmphtmla = "";
            string tmphtmlb = "</font>";

            #region 星体与庙旺四化
            for (int i = 0; i < mod.Xing.Length; i++)
            {
                if (i == 58 || i == 59 || i == 62 || i == 63 || i == 66 || i == 64 || i == 67)
                {
                    continue;
                }
                if (i <= 13)
                {
                    tmphtmla = "<font color=#ff2a01>";//主星颜色
                }
                else if (i <= 21)
                {
                    tmphtmla = "<font color=#fe30d9>";//辅星颜色
                }
                else if(i<=27)
                {
                    tmphtmla = "<font color=#6f25e6>";//凶星颜色
                }
                else
                {
                    tmphtmla = "<font color=#cb8430>";//小星颜色
                }
                starflag = false;
                //每个宫内打印10列
                for (int j = 9; j >=0; j--)
                {
                    if (tmpgong[mod.Xing[i].Gong, 0, j] == null || tmpgong[mod.Xing[i].Gong, 0, j] == "")
                    {
                        tmpgong[mod.Xing[i].Gong, 0, j] = tmphtmla + PublicValue.GetZiWeiStar(mod.Xing[i].StarName).Substring(0, 1) + tmphtmlb;
                        tmpgong[mod.Xing[i].Gong, 1, j] = tmphtmla + PublicValue.GetZiWeiStar(mod.Xing[i].StarName).Substring(1, 1) + tmphtmlb;
                        if ((int)mod.Xing[i].Wang != 0)
                        {
                            tmpgong[mod.Xing[i].Gong, 2, j] = PublicValue.GetZiWeiMiaowang(mod.Xing[i].Wang);
                        }
                        if ((int)mod.Xing[i].Hua != 0)
                        {
                            tmpgong[mod.Xing[i].Gong, 3, j] = "<font color=#EEEEEE><span style='background-color: #ff2a01'>" +
                                PublicValue.GetZiWeiSihua(mod.Xing[i].Hua) + "</span></font>";
                        }
                        starflag = true;
                        break;
                    }
                }
                if (starflag)
                {
                    continue;
                }
                for (int j = 0; j <=4; j++)
                {
                    if (tmpgong[mod.Xing[i].Gong, 2, j] == null || tmpgong[mod.Xing[i].Gong, 2, j] == "")
                    {
                        tmpgong[mod.Xing[i].Gong, 2, j] = tmphtmla + PublicValue.GetZiWeiStar(mod.Xing[i].StarName).Substring(0, 1) + tmphtmlb;
                        tmpgong[mod.Xing[i].Gong, 3, j] = tmphtmla + PublicValue.GetZiWeiStar(mod.Xing[i].StarName).Substring(1, 1) + tmphtmlb;
                        starflag = true;
                        break;
                    }
                }
            }
            #endregion

            #region 十二神与宫名
            for (int i = 0; i < 12; i++)
            {
                string boshicolor = "#005995";
                string taisuicolor = "#018e98";
                string jiangqiancolor = "#1a85c2";
                string changshengcolor = "#149e11";

                tmpgong[i, 5, 0] = "<font color=" + boshicolor + ">" + PublicValue.GetZiWeiBoShi(mod.Gong[i].BoShi).Substring(0, 1) + "</font>";
                tmpgong[i, 6, 0] = "<font color=" + boshicolor + ">" + PublicValue.GetZiWeiBoShi(mod.Gong[i].BoShi).Substring(1, 1) + "</font>";
                tmpgong[i, 5, 1] = "<font color=" + taisuicolor + ">" + PublicValue.GetZiWeiTaiSui(mod.Gong[i].TaiSui).Substring(0, 1) + "</font>";
                tmpgong[i, 6, 1] = "<font color=" + taisuicolor + ">" + PublicValue.GetZiWeiTaiSui(mod.Gong[i].TaiSui).Substring(1, 1) + "</font>";
                tmpgong[i, 5, 2] = "<font color=" + jiangqiancolor + ">" + PublicValue.GetZiWeiJiangQian(mod.Gong[i].JiangQian).Substring(0, 1) + "</font>";
                tmpgong[i, 6, 2] = "<font color=" + jiangqiancolor + ">" + PublicValue.GetZiWeiJiangQian(mod.Gong[i].JiangQian).Substring(1, 1) + "</font>";

                //tmpgong[i, 5, 3] = "　";
                //tmpgong[i, 6, 3] = "　";
                if (transittohtml(mod.Gong[i].TransitA, mod.Gong[i].TransitB) != "　　　")
                {
                    if (mod.DaYunGong == i)
                    {
                        tmpgong[i, 5, 4] = "<u>";
                        tmpgong[i, 5, 6] = "</u>";
                        tmpgong[i, 5, 7] = "　";
                    }
                    else
                    {
                        tmpgong[i, 5, 4] = "";
                        tmpgong[i, 5, 6] = "";
                    }

                    tmpgong[i, 5, 4] += transittohtml(mod.Gong[i].TransitA, mod.Gong[i].TransitB).Substring(0, 2);
                    tmpgong[i, 5, 5] = transittohtml(mod.Gong[i].TransitA, mod.Gong[i].TransitB).Substring(2, 1);
                    tmpgong[i, 5, 6] = transittohtml(mod.Gong[i].TransitA, mod.Gong[i].TransitB).Substring(3, 2) + tmpgong[i, 5, 6];
                }

                tmpgong[i, 6, 4] = "<font id='gong" + i + "' onMouseOver='sansi(this);' color=#ff2a01>" + PublicValue.GetZiWeiGong(mod.Gong[i].GongName).Substring(0, 1);
                if (mod.Shen == i)
                {
                    tmpgong[i, 6, 5] = "★";
                    tmpgong[i, 6, 6] = "身" + "</font>";
                    if (mod.Ming == i)
                    {
                        tmpgong[i, 6, 4] = "<font id='gong" + i + "' onMouseOver='sansi(this);' color=#ff2a01>命";
                    }
                }
                else
                {
                    tmpgong[i, 6, 5] = PublicValue.GetZiWeiGong(mod.Gong[i].GongName).Substring(1, 1);
                    tmpgong[i, 6, 6] = PublicValue.GetZiWeiGong(mod.Gong[i].GongName).Substring(2, 1) + "</font>";
                }
                

                tmpgong[i, 5, 8] = "<font color=" + changshengcolor + ">" + PublicValue.GetZiWeiChangSheng(mod.Gong[i].ChangSheng).Substring(0, 1) + "</font>";
                tmpgong[i, 6, 8] = "<font color=" + changshengcolor + ">" + PublicValue.GetZiWeiChangSheng(mod.Gong[i].ChangSheng).Substring(1, 1) + "</font>";
                tmpgong[i, 5, 9] = PublicValue.GetTianGan(mod.Gong[i].TG);
                tmpgong[i, 6, 9] = PublicValue.GetDiZhi(mod.Gong[i].DZ);
            }
            #endregion

            #region 设置中部内容

            string red = "#ff2a01";
            string blue1 = "#005995";
            string green = "#149e11";
            string blue2 = "#1a85c2";

            for (int i = 0; i < 15; i++)
            {
                middle[i] = "　　　　　　　　　　　　　　　　　　　　　";
            }
            middle[0] = "盘类：天盘　" + PublicValue.GetZiWeiMingJu(mod.MingJu) + "　" + PublicValue.GetShuXing(mod.ShuXing) + AppCmn.AppEnum.GetGender(mod.Gender) + "　　　子年斗君：" + PublicValue.GetDiZhi(mod.ZiDou);
            middle[1] = "公历：<font color=" + red + ">"+mod.BirthTime.Date.Year.ToString("0000")+ "</font>年<font color=" + red + ">"+
                mod.BirthTime.Date.Month.ToString("00")+ "</font>月<font color=" + red + ">"+mod.BirthTime.Date.Day.ToString("00")+ "</font>日<font color=" + red + ">"+
                mod.BirthTime.Date.Hour.ToString("00")+"</font>时" + "生　　　<font color=" + blue1 + ">命主：" + PublicValue.GetZiWeiStar(mod.MingZhu) + "</font>";
            middle[2] = "农历：<font color=" + red + ">" + PublicValue.GetTianGan(mod.BirthTime.NongliTG) + PublicValue.GetDiZhi(mod.BirthTime.NongliDZ) + "</font>年<font color=" + red + ">" +
                PublicValue.GetNongliMonth(mod.BirthTime.NongliMonth) + "</font>月<font color=" + red + ">" + PublicValue.GetNongliDay(mod.BirthTime.NongliDay)
                + PublicValue.GetDiZhi(mod.BirthTime.NongliHour) + "</font>时生";
            int tmpcol = 4 - PublicValue.GetNongliMonth(mod.BirthTime.NongliMonth).Length;
            for (int i = 0; i <tmpcol ; i++)
            {
                middle[2] += "　";
            }
            middle[2] += "<font color=" + blue1 + ">身主：" + PublicValue.GetZiWeiStar(mod.ShenZhu) + "</font>";
            BaZi.BaZiMod m_bazi = new BaZi.BaZiMod();
            m_bazi.BirthTime = mod.BirthTime;
            m_bazi.Gender = mod.Gender;
            BaZi.BaZiBiz bazibiz = BaZi.BaZiBiz.GetInstance();
            bazibiz.TimeToBaZi(ref m_bazi);
            middle[4] = "　　<font color=" + green + ">" + PublicValue.GetNayin(10000 + ((int)m_bazi.YearTG) * 100 + m_bazi.YearDZ) + "</font>　<font color=" + green + ">" +
                PublicValue.GetNayin(10000 + ((int)m_bazi.MonthTG) * 100 + m_bazi.MonthDZ) + "</font>　<font color=" + green + ">" +
                PublicValue.GetNayin(10000 + ((int)m_bazi.DayTG) * 100 + m_bazi.DayDZ) + "</font>　<font color=" + green + ">" +
                PublicValue.GetNayin(10000 + ((int)m_bazi.HourTG) * 100 + m_bazi.HourDZ) + "</font>　　　　";
            middle[5] = "　　<font color=" + blue2 + ">" + PublicValue.GetShiShen(PublicDeal.GetInstance().GZWuXing(new WuXingRelation(m_bazi.YearTG, m_bazi.DayTG)).ShiShen) + "</font>　　<font color=" + blue2 + ">" +
                 PublicValue.GetShiShen(PublicDeal.GetInstance().GZWuXing(new WuXingRelation(m_bazi.MonthTG, m_bazi.DayTG)).ShiShen) + "</font>　　<font color=" + blue2 + ">日主</font>　　<font color=" + blue2 + ">" +
                   PublicValue.GetShiShen(PublicDeal.GetInstance().GZWuXing(new WuXingRelation(m_bazi.DayTG, m_bazi.DayTG)).ShiShen) + "</font>　　　　　";
            if (mod.Gender == AppCmn.AppEnum.Gender.male)
            {
                middle[6] = "乾：";
            }
            else
            {
                middle[6] = "坤：";
            }
            middle[6] += "<font color=" + red + ">" + PublicValue.GetTianGan(m_bazi.YearTG) + PublicValue.GetDiZhi(m_bazi.YearDZ) + "</font>　　<font color=" + red + ">" +
                PublicValue.GetTianGan(m_bazi.MonthTG) + PublicValue.GetDiZhi(m_bazi.MonthDZ) + "</font>　　<font color=" + red + ">" +
                PublicValue.GetTianGan(m_bazi.DayTG) + PublicValue.GetDiZhi(m_bazi.DayDZ) + "</font>　　<font color=" + red + ">" +
                PublicValue.GetTianGan(m_bazi.HourTG) + PublicValue.GetDiZhi(m_bazi.HourDZ) + "</font>（<font color=" + red + ">" + PublicValue.GetDiZhi(m_bazi.XunKong0) + PublicValue.GetDiZhi(m_bazi.XunKong1) + "</font>空）";
            for (int j = 0; j < 3; j++)
            {
                middle[j + 7] = "　　";
                for (int i = 0; i < 4; i++)
                {
                    if (!(j != 0 && (int)m_bazi.CangGan[i, j] == 0))
                        middle[j + 7] += PublicValue.GetTianGan(m_bazi.CangGan[i, j]) + "<font color=" + blue2 + ">" + PublicValue.GetShiShen(PublicDeal.GetInstance().GZWuXing(new WuXingRelation(m_bazi.CangGan[i, j], m_bazi.DayTG)).ShiShen) + "</font>　";
                    else
                        middle[j + 7] += "　　　　";
                }
                middle[j + 7] += "　　　";
            }

            middle[11] = "　大运[<font color=" + red + ">" + m_bazi.JiaoYun.Month + "</font>月换运]";
            if (m_bazi.JiaoYun.Month < 10)
            { middle[11] += " "; }
            middle[11] += "　　　　　　　　　　　　　";
            middle[12] = "　";
            middle[13] = "　";
            middle[14] = "　";
            for (int i = 0; i < 8; i++)
            {
                middle[12] += "<font color=" + red + ">" + PublicValue.GetTianGan(m_bazi.Dayun[i].YearTG) + PublicValue.GetDiZhi(m_bazi.Dayun[i].YearDZ) + "</font> ";
                middle[13] += "<font color=" + blue2 + ">" + PublicValue.GetShiShen(PublicDeal.GetInstance().GZWuXing(new WuXingRelation(m_bazi.Dayun[i].YearTG, m_bazi.DayTG)).ShiShen) + "</font> ";
                middle[14] += m_bazi.Dayun[i].Begin.ToString("0000") + " ";
            } 
            #endregion

                sb.Append("┌───────────────────────────────────────────┐").Append("<br />");
                sb.Append("│　　　　　　　　　上上签神秘学社区紫微斗数在线排盘系统　<a href='" + AppCmn.AppConfig.HomeUrl() + "'>" + AppCmn.AppConfig.HomeUrl() + "</a>　　　　│").Append("<br />");
            sb.Append("├──────────┬──────────┬──────────┬──────────┤").Append("<br />");
            //3,4,5,6宫
            for (int i = 0; i < 7; i++)
            {
                sb.Append("│");
                for (int j = 3; j < 7; j++)
                {
                    sb.Append(gongstartohtml(tmpgong, j, i)).Append("│");
                } 
                sb.Append("<br />");
            }
            sb.Append("├──────────┼──────────┴──────────┼──────────┤").Append("<br />");
            //2,7宫
            for (int i = 0; i < 7; i++)
            {
                sb.Append("│").Append(gongstartohtml(tmpgong, 2, i)).Append("│").Append(middle[i]).Append("│").Append(gongstartohtml(tmpgong, 7, i)).Append("│").Append("<br />");
            }
            sb.Append("├──────────┤").Append(middle[7]).Append("├──────────┤").Append("<br />");
            //1,8宫
            for (int i = 0; i < 7; i++)
            {
                sb.Append("│").Append(gongstartohtml(tmpgong, 1, i)).Append("│").Append(middle[i+8]).Append("│").Append(gongstartohtml(tmpgong, 8, i)).Append("│").Append("<br />");
            }
            sb.Append("├──────────┼──────────┬──────────┼──────────┤").Append("<br />");
            //0,11,10,9宫
            for (int i = 0; i < 7; i++)
            {
                sb.Append("│");
                for (int j = 12; j >8; j--)
                {
                    sb.Append(gongstartohtml(tmpgong, j%12, i)).Append("│");
                }
                sb.Append("<br />");
            }
            sb.Append("└──────────┴──────────┴──────────┴──────────┘");

            return sb.ToString();
        }

        public string ZiWeiLiuToHTML(ZiWeiMod mod)
        {
            StringBuilder sb = new StringBuilder();
            string[, ,] tmpgong = new string[12, 9, 10];//12宫，每宫9行，每行10个字
            string[] middle = new string[19];
            bool starflag = false;
            string tmphtmla = "";
            string tmphtmlb = "</font>";

            #region 星体与庙旺四化
            for (int i = 0; i < mod.Xing.Length; i++)
            {
                if (i == 58 || i == 59 || i == 62 || i == 63 || i == 66 || i == 64 || i == 67)
                {
                    continue;
                }
                if (i <= 13)
                {
                    tmphtmla = "<font color=#ff2a01>";//主星颜色
                }
                else if (i <= 21)
                {
                    tmphtmla = "<font color=#fe30d9>";//辅星颜色
                }
                else if (i <= 27)
                {
                    tmphtmla = "<font color=#6f25e6>";//凶星颜色
                }
                else
                {
                    tmphtmla = "<font color=#cb8430>";//小星颜色
                }
                starflag = false;
                //每个宫内打印10列
                for (int j = 9; j >= 0; j--)
                {
                    if (tmpgong[mod.Xing[i].Gong, 0, j] == null || tmpgong[mod.Xing[i].Gong, 0, j] == "")
                    {
                        tmpgong[mod.Xing[i].Gong, 0, j] = tmphtmla + PublicValue.GetZiWeiStar(mod.Xing[i].StarName).Substring(0, 1) + tmphtmlb;
                        tmpgong[mod.Xing[i].Gong, 1, j] = tmphtmla + PublicValue.GetZiWeiStar(mod.Xing[i].StarName).Substring(1, 1) + tmphtmlb;
                        if ((int)mod.Xing[i].Wang != 0)
                        {
                            tmpgong[mod.Xing[i].Gong, 2, j] = PublicValue.GetZiWeiMiaowang(mod.Xing[i].Wang);
                        }
                        if ((int)mod.Xing[i].Hua != 0)
                        {
                            tmpgong[mod.Xing[i].Gong, 3, j] = "<font color=#FFFFFF><span style='background-color: #ff2a01'>" +
                                PublicValue.GetZiWeiSihua(mod.Xing[i].Hua) + "</span></font>";
                        }
                        if ((int)mod.Xing[i].YunHua != 0)
                        {
                            tmpgong[mod.Xing[i].Gong, 4, j] = "<font color=#FFFFFF><span style='background-color: #149e11'>" +
                                PublicValue.GetZiWeiSihua(mod.Xing[i].YunHua) + "</span></font>";
                        }
                        if ((int)mod.Xing[i].LiuHua != 0)
                        {
                            tmpgong[mod.Xing[i].Gong, 5, j] = "<font color=#FFFFFF><span style='background-color: #005995'>" +
                                PublicValue.GetZiWeiSihua(mod.Xing[i].LiuHua) + "</span></font>";
                        }
                        starflag = true;
                        break;
                    }
                }
                
                if (starflag)
                {
                    continue;
                }
                for (int j = 0; j <= 4; j++)//第一行放不下的小星
                {
                    if (tmpgong[mod.Xing[i].Gong, 2, j] == null || tmpgong[mod.Xing[i].Gong, 2, j] == "")
                    {
                        tmpgong[mod.Xing[i].Gong, 2, j] = tmphtmla + PublicValue.GetZiWeiStar(mod.Xing[i].StarName).Substring(0, 1) + tmphtmlb;
                        tmpgong[mod.Xing[i].Gong, 3, j] = tmphtmla + PublicValue.GetZiWeiStar(mod.Xing[i].StarName).Substring(1, 1) + tmphtmlb;
                        starflag = true;
                        break;
                    }
                }
                
            }
            for (int i = 0; i < 7; i++)//流耀
            {
                string tmp = "昌曲魁钺羊陀禄";
                for (int j = 0; j < 4; j++)
                {
                    if (tmpgong[mod.YunYao[i], 4, j] == null || tmpgong[mod.YunYao[i], 4, j] == "")
                    {
                        tmpgong[mod.YunYao[i], 4, j] = "<font color=#149e11>运</font>";
                        tmpgong[mod.YunYao[i], 5, j] = "<font color=#149e11>" + tmp.Substring(i, 1) + "</font>";
                        break;
                    }
                }
                for (int j = 0; j < 4; j++)
                {
                    if (tmpgong[mod.LiuYao[i], 4, j] == null || tmpgong[mod.LiuYao[i], 4, j] == "")
                    {
                        tmpgong[mod.LiuYao[i], 4, j] = "<font color=#005995>流</font>";
                        tmpgong[mod.LiuYao[i], 5, j] = "<font color=#005995>" + tmp.Substring(i, 1) + "</font>";
                        break;
                    }
                }
            }
            #endregion

            #region 十二神与宫名
            for (int i = 0; i < 12; i++)
            {
                string boshicolor = "#005995";
                string taisuicolor = "#018e98";
                string jiangqiancolor = "#1a85c2";
                string changshengcolor = "#149e11";

                tmpgong[i, 7, 0] = "<font color=" + boshicolor + ">" + PublicValue.GetZiWeiBoShi(mod.Gong[i].BoShi).Substring(0, 1) + "</font>";
                tmpgong[i, 8, 0] = "<font color=" + boshicolor + ">" + PublicValue.GetZiWeiBoShi(mod.Gong[i].BoShi).Substring(1, 1) + "</font>";
                tmpgong[i, 7, 1] = "<font color=" + taisuicolor + ">" + PublicValue.GetZiWeiTaiSui(mod.Gong[i].TaiSui).Substring(0, 1) + "</font>";
                tmpgong[i, 8, 1] = "<font color=" + taisuicolor + ">" + PublicValue.GetZiWeiTaiSui(mod.Gong[i].TaiSui).Substring(1, 1) + "</font>";
                tmpgong[i, 7, 2] = "<font color=" + jiangqiancolor + ">" + PublicValue.GetZiWeiJiangQian(mod.Gong[i].JiangQian).Substring(0, 1) + "</font>";
                tmpgong[i, 8, 2] = "<font color=" + jiangqiancolor + ">" + PublicValue.GetZiWeiJiangQian(mod.Gong[i].JiangQian).Substring(1, 1) + "</font>";


                //本命宫位
                tmpgong[i, 6, 4] = "<font id='gong" + i + "' onMouseOver='liusansi(" + i + ");' color=#ff2a01>" + PublicValue.GetZiWeiGong(mod.Gong[i].GongName).Substring(0, 1);
                if (mod.Shen == i)
                {
                    tmpgong[i, 6, 5] = "★";
                    tmpgong[i, 6, 6] = "身" + "</font>";
                    if (mod.Ming == i)
                    {
                        tmpgong[i, 6, 4] = "<font id='gong" + i + "' onMouseOver='liusansi(" + i + ");' color=#ff2a01>命"; 
                    }
                }
                else
                {
                    tmpgong[i, 6, 5] = PublicValue.GetZiWeiGong(mod.Gong[i].GongName).Substring(1, 1);
                    tmpgong[i, 6, 6] = PublicValue.GetZiWeiGong(mod.Gong[i].GongName).Substring(2, 1) + "</font>";
                }
                //大运宫位
                tmpgong[i, 7, 4] = "<font id='yun" + i + "' onMouseOver='liusansi(" + i + ");' color=#149e11>运";
                tmpgong[i, 7, 5] = PublicValue.GetZiWeiGong(mod.Gong[i].YunGongName).Substring(0, 1);
                tmpgong[i, 7, 6] = PublicValue.GetZiWeiGong(mod.Gong[i].YunGongName).Substring(1, 1) + "</font>";
                //流年宫位
                tmpgong[i, 8, 4] = "<font id='liu" + i + "' onMouseOver='liusansi(" + i + ");' color=#005995>流";
                tmpgong[i, 8, 5] = PublicValue.GetZiWeiGong(mod.Gong[i].LiuGongName).Substring(0, 1);
                tmpgong[i, 8, 6] = PublicValue.GetZiWeiGong(mod.Gong[i].LiuGongName).Substring(1, 1) + "</font>";

                tmpgong[i, 7, 8] = "<font color=" + changshengcolor + ">" + PublicValue.GetZiWeiChangSheng(mod.Gong[i].ChangSheng).Substring(0, 1) + "</font>";
                tmpgong[i, 8, 8] = "<font color=" + changshengcolor + ">" + PublicValue.GetZiWeiChangSheng(mod.Gong[i].ChangSheng).Substring(1, 1) + "</font>";
                tmpgong[i, 7, 9] = PublicValue.GetTianGan(mod.Gong[i].TG);
                tmpgong[i, 8, 9] = PublicValue.GetDiZhi(mod.Gong[i].DZ);

                //流年月日显示
                if (transittohtml(mod.Gong[i].TransitA, mod.Gong[i].TransitB) != "　　　")
                {
                    tmpgong[i, 5, 4] = transittohtml(mod.Gong[i].TransitA, mod.Gong[i].TransitB).Substring(0, 2);
                    tmpgong[i, 5, 5] = transittohtml(mod.Gong[i].TransitA, mod.Gong[i].TransitB).Substring(2, 1);
                    tmpgong[i, 5, 6] = transittohtml(mod.Gong[i].TransitA, mod.Gong[i].TransitB).Substring(3, 2);
                }

                string monthname = PublicValue.GetNongliMonth((PublicValue.NongliMonth)((i - mod.LiuYueGong + 12) % 12+1));
                tmpgong[i, 6, 0] = monthname.Substring(0, 1);
                if (monthname.Length == 2)
                {
                    tmpgong[i, 6, 1] = monthname.Substring(1, 1);
                    tmpgong[i, 6, 2] = "月";
                }
                else
                {
                    tmpgong[i, 6, 1] = "月";
                }

                int firstdaygong = mod.LiuYueGong + (int)mod.TransitTime.NongliMonth % 100 - 1;
                int xun = (int)mod.TransitTime.NongliDay / 12;
                int thisday = (i - firstdaygong + 12) % 12 + 1 + xun * 12;
                if (thisday <= 0)
                {
                    thisday += 12;
                }
                if (thisday > mod.TransitTime.NongliMonthDays)
                {
                    thisday -= 12;
                }
                tmpgong[i, 6, 8] = PublicValue.GetNongliDay(thisday).Substring(0, 1);
                tmpgong[i, 6, 9] = PublicValue.GetNongliDay(thisday).Substring(1, 1);
            }
            #endregion

            #region 设置中部内容

            string red = "#ff2a01";
            string blue1 = "#005995";
            string green = "#149e11";
            string blue2 = "#1a85c2";

            for (int i = 0; i < 19; i++)
            {
                middle[i] = "　　　　　　　　　　　　　　　　　　　　　";
            }
            middle[0] = "盘类：流限盘　" + PublicValue.GetZiWeiMingJu(mod.MingJu) + "　" + PublicValue.GetShuXing(mod.ShuXing) + AppCmn.AppEnum.GetGender(mod.Gender) + "　　子年斗君：" + PublicValue.GetDiZhi(mod.ZiDou);
            middle[1] = "公历：<font color=" + red + ">" + mod.BirthTime.Date.Year.ToString("0000") + "</font>年<font color=" + red + ">" +
                mod.BirthTime.Date.Month.ToString("00") + "</font>月<font color=" + red + ">" + mod.BirthTime.Date.Day.ToString("00") + "</font>日<font color=" + red + ">" +
                mod.BirthTime.Date.Hour.ToString("00") + "</font>时" + "生　　　<font color=" + blue1 + ">命主：" + PublicValue.GetZiWeiStar(mod.MingZhu) + "</font>";
            middle[2] = "农历：<font color=" + red + ">" + PublicValue.GetTianGan(mod.BirthTime.NongliTG) + PublicValue.GetDiZhi(mod.BirthTime.NongliDZ) + "</font>年<font color=" + red + ">" +
                PublicValue.GetNongliMonth(mod.BirthTime.NongliMonth) + "</font>月<font color=" + red + ">" + PublicValue.GetNongliDay(mod.BirthTime.NongliDay)
                + PublicValue.GetDiZhi(mod.BirthTime.NongliHour) + "</font>时生";
            int tmpcol = 4 - PublicValue.GetNongliMonth(mod.BirthTime.NongliMonth).Length;
            for (int i = 0; i < tmpcol; i++)
            {
                middle[2] += "　";
            }
            middle[2] += "<font color=" + blue1 + ">身主：" + PublicValue.GetZiWeiStar(mod.ShenZhu) + "</font>";
            middle[3] = "推运：<font color=" + red + ">" + mod.TransitTime.Date.Year.ToString("0000") + "</font>年<font color=" + red + ">" +
                mod.TransitTime.Date.Month.ToString("00") + "</font>月<font color=" + red + ">" + mod.TransitTime.Date.Day.ToString("00") + "</font>日" +
                "　小限在" + PublicValue.GetDiZhi(mod.XiaoXian) + "　";
            if (mod.Age.ToString().Length == 1)
            {
                middle[3] += "　虚岁：" + mod.Age + " ";
            }
            else if (mod.Age.ToString().Length == 2)
            {
                middle[3] += "　虚岁：" + mod.Age;
            }
            else if (mod.Age.ToString().Length == 3)
            {
                middle[3] += " 虚岁：" + mod.Age;
            }
            BaZi.BaZiMod m_bazi = new BaZi.BaZiMod();
            m_bazi.BirthTime = mod.BirthTime;
            m_bazi.Gender = mod.Gender;
            BaZi.BaZiBiz bazibiz = BaZi.BaZiBiz.GetInstance();
            bazibiz.TimeToBaZi(ref m_bazi);
            middle[4] = "流年<font color=" + blue1 + ">" + PublicValue.GetTianGan(mod.TransitTime.NongliTG) + PublicValue.GetDiZhi(mod.TransitTime.NongliDZ) +
                "</font>　流月<font color=" + blue1 + ">" + PublicValue.GetNongliMonth(mod.TransitTime.NongliMonth) + "月 " +
                PublicValue.GetTianGan((2 * ((int)mod.TransitTime.NongliTG - 1) + mod.TmpLiuMonth + 1) % 10) + PublicValue.GetDiZhi((mod.TmpLiuMonth + 1) % 12) + "</font>" +
                "　流日<font color=" + blue1 + ">" + PublicValue.GetNongliDay(mod.TransitTime.NongliDay) + " " + PublicValue.GetTianGan(m_bazi.DayTG) + PublicValue.GetDiZhi(m_bazi.DayDZ) + "</font>";
            tmpcol = 3 - PublicValue.GetNongliMonth(mod.TransitTime.NongliMonth).Length;
            for (int i = 0; i < tmpcol; i++)
            {
                middle[4] += "　";
            }
            
            middle[6] = "　　<font color=" + green + ">" + PublicValue.GetNayin(10000 + ((int)m_bazi.YearTG) * 100 + m_bazi.YearDZ) + "</font>　<font color=" + green + ">" +
                PublicValue.GetNayin(10000 + ((int)m_bazi.MonthTG) * 100 + m_bazi.MonthDZ) + "</font>　<font color=" + green + ">" +
                PublicValue.GetNayin(10000 + ((int)m_bazi.DayTG) * 100 + m_bazi.DayDZ) + "</font>　<font color=" + green + ">" +
                PublicValue.GetNayin(10000 + ((int)m_bazi.HourTG) * 100 + m_bazi.HourDZ) + "</font>　　　　";
            middle[7] = "　　<font color=" + blue2 + ">" + PublicValue.GetShiShen(PublicDeal.GetInstance().GZWuXing(new WuXingRelation(m_bazi.YearTG, m_bazi.DayTG)).ShiShen) + "</font>　　<font color=" + blue2 + ">" +
                 PublicValue.GetShiShen(PublicDeal.GetInstance().GZWuXing(new WuXingRelation(m_bazi.MonthTG, m_bazi.DayTG)).ShiShen) + "</font>　　<font color=" + blue2 + ">日主</font>　　<font color=" + blue2 + ">" +
                   PublicValue.GetShiShen(PublicDeal.GetInstance().GZWuXing(new WuXingRelation(m_bazi.DayTG, m_bazi.DayTG)).ShiShen) + "</font>　　　　　";
            if (mod.Gender == AppCmn.AppEnum.Gender.male)
            {
                middle[8] = "乾：";
            }
            else
            {
                middle[8] = "坤：";
            }
            middle[8] += "<font color=" + red + ">" + PublicValue.GetTianGan(m_bazi.YearTG) + PublicValue.GetDiZhi(m_bazi.YearDZ) + "</font>　　<font color=" + red + ">" +
                PublicValue.GetTianGan(m_bazi.MonthTG) + PublicValue.GetDiZhi(m_bazi.MonthDZ) + "</font>　　<font color=" + red + ">" +
                PublicValue.GetTianGan(m_bazi.DayTG) + PublicValue.GetDiZhi(m_bazi.DayDZ) + "</font>　　<font color=" + red + ">" +
                PublicValue.GetTianGan(m_bazi.HourTG) + PublicValue.GetDiZhi(m_bazi.HourDZ) + "</font>（<font color=" + red + ">" + PublicValue.GetDiZhi(m_bazi.XunKong0) + PublicValue.GetDiZhi(m_bazi.XunKong1) + "</font>空）";
            for (int j = 0; j < 3; j++)
            {
                middle[j + 9] = "　　";
                for (int i = 0; i < 4; i++)
                {
                    if (!(j != 0 && (int)m_bazi.CangGan[i, j] == 0))
                        middle[j + 9] += PublicValue.GetTianGan(m_bazi.CangGan[i, j]) + "<font color=" + blue2 + ">" + PublicValue.GetShiShen(PublicDeal.GetInstance().GZWuXing(new WuXingRelation(m_bazi.CangGan[i, j], m_bazi.DayTG)).ShiShen) + "</font>　";
                    else
                        middle[j + 9] += "　　　　";
                }
                middle[j + 9] += "　　　";
            }

            middle[13] = "　大运[<font color=" + red + ">" + m_bazi.JiaoYun.Month + "</font>月换运]";
            if (m_bazi.JiaoYun.Month < 10)
            { middle[13] += " "; }
            middle[13] += "　　　　　　　　　　　　　";
            middle[14] = "　";
            middle[15] = "　";
            middle[16] = "　";
            for (int i = 0; i < 8; i++)
            {
                middle[14] += "<font color=" + red + ">" + PublicValue.GetTianGan(m_bazi.Dayun[i].YearTG) + PublicValue.GetDiZhi(m_bazi.Dayun[i].YearDZ) + "</font> ";
                middle[15] += "<font color=" + blue2 + ">" + PublicValue.GetShiShen(PublicDeal.GetInstance().GZWuXing(new WuXingRelation(m_bazi.Dayun[i].YearTG, m_bazi.DayTG)).ShiShen) + "</font> ";
                middle[16] += m_bazi.Dayun[i].Begin.ToString("0000") + " ";
            }
            #endregion

            sb.Append("┌───────────────────────────────────────────┐").Append("<br />");
            sb.Append("│　　　　　　　　　上上签神秘学社区紫微斗数在线排盘系统　<a href='" + AppCmn.AppConfig.HomeUrl() + "'>" + AppCmn.AppConfig.HomeUrl() + "</a>　　　　│").Append("<br />");
            sb.Append("├──────────┬──────────┬──────────┬──────────┤").Append("<br />");
            //3,4,5,6宫
            for (int i = 0; i < 9; i++)
            {
                sb.Append("│");
                for (int j = 3; j < 7; j++)
                {
                    sb.Append(gongstartohtml(tmpgong, j, i)).Append("│");
                }
                sb.Append("<br />");
            }
            sb.Append("├──────────┼──────────┴──────────┼──────────┤").Append("<br />");
            //2,7宫
            for (int i = 0; i < 9; i++)
            {
                sb.Append("│").Append(gongstartohtml(tmpgong, 2, i)).Append("│").Append(middle[i]).Append("│").Append(gongstartohtml(tmpgong, 7, i)).Append("│").Append("<br />");
            }
            sb.Append("├──────────┤").Append(middle[9]).Append("├──────────┤").Append("<br />");
            //1,8宫
            for (int i = 0; i < 9; i++)
            {
                sb.Append("│").Append(gongstartohtml(tmpgong, 1, i)).Append("│").Append(middle[i + 10]).Append("│").Append(gongstartohtml(tmpgong, 8, i)).Append("│").Append("<br />");
            }
            sb.Append("├──────────┼──────────┬──────────┼──────────┤").Append("<br />");
            //0,11,10,9宫
            for (int i = 0; i < 9; i++)
            {
                sb.Append("│");
                for (int j = 12; j > 8; j--)
                {
                    sb.Append(gongstartohtml(tmpgong, j % 12, i)).Append("│");
                }
                sb.Append("<br />");
            }
            sb.Append("└──────────┴──────────┴──────────┴──────────┘");

            return sb.ToString();
        }

        #region 打印算法
        public string gongstartohtml(string[, ,] gongstr,int gongnum,int row)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 10; i++)
            {
                if (gongstr[gongnum, row, i] != null && gongstr[gongnum, row, i] != "")
                {
                    sb.Append(gongstr[gongnum, row, i]);
                }
                else
                {
                    sb.Append("　");
                }
            }
            return sb.ToString();
        }

        public string transittohtml(int transa,int transb)
        {
            string ret = "";
            if(transa == AppCmn.AppConst.IntNull || transa == 0)
            {
                ret = "　　　"; 
            }
            else
            {
                ret = transa.ToString() + "－" + transb.ToString();
                if (transa < 10)
                {
                    ret = "0" + ret;
                }
            }
            return ret;
        }
        #endregion 打印算法

    }
}