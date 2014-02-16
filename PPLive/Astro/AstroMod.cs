using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PPLive.Astro
{
    [Serializable]
    public class AstroMod
    {
        #region 私有变量
        private string _graphicID = "test";//生成星盘图的信息组合，同为星盘图的文件名
        private LatLng _position = new LatLng();
        private DateTime _birth = DateTime.Now;
        private int _zone = 0;//时区
        private AppCmn.AppEnum.BOOL _isDaylight = AppCmn.AppEnum.BOOL.False;

        private int _houseSystem = 0;//分宫制
        private Dictionary<int, string> _startsShow = new Dictionary<int, string>(); //星体显示
        private Dictionary<int, decimal> _aspectsShow = new Dictionary<int, decimal>();//相位容许度

        private PublicValue.AstroType _type = new PublicValue.AstroType();
        private PublicValue.AstroZuhe _compose = new PublicValue.AstroZuhe();
        private LatLng _position1 = new LatLng();
        private DateTime _birth1 = DateTime.Now;
        private int _zone1 = 0;//时区
        private AppCmn.AppEnum.BOOL _isDaylight1 = AppCmn.AppEnum.BOOL.False;

        private PublicValue.AstroTuiyun _transit = new PublicValue.AstroTuiyun();//推运类型
        private DateTime _transitTime = DateTime.Now;//推运时间
        private LatLng _transitPosition = new LatLng();

        private string _composeFile1 = "";
        private string _composeFile2 = "";

        private AppCmn.AppEnum.Gender _gender = AppCmn.AppEnum.Gender.none;
        private AppCmn.AppEnum.Gender _gender1 = AppCmn.AppEnum.Gender.none;

        private Star[] xing = new Star[32]; 
        #endregion

        #region 接口
        public LatLng position
        {
            get { return _position; }
            set { _position = value; }
        }
        public DateTime birth
        {
            get { return _birth; }
            set { _birth = value; }
        }
        public int zone
        {
            get { return _zone; }
            set { _zone = value; }
        }
        public string graphicID
        {
            get { return _graphicID; }
            set { _graphicID = value; }
        }
        public AppCmn.AppEnum.BOOL IsDaylight
        {
            get { return _isDaylight; }
            set { _isDaylight = value; }
        }
        public AppCmn.AppEnum.Gender Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }
        public AppCmn.AppEnum.Gender Gender1
        {
            get { return _gender1; }
            set { _gender1 = value; }
        }
        public int houseSystem
        {
            get { return _houseSystem; }
            set { _houseSystem = value; }
        }
        public Dictionary<int, string> startsShow
        {
            get { return _startsShow; }
            set { _startsShow = value; }
        }
        public Dictionary<int, decimal> aspectsShow
        {
            get { return _aspectsShow; }
            set { _aspectsShow = value; }
        }
        public PublicValue.AstroType type
        {
            get { return _type; }
            set { _type = value; }
        }
        public PublicValue.AstroTuiyun transit
        {
            get { return _transit; }
            set { _transit = value; }
        }
        public PublicValue.AstroZuhe compose
        {
            get { return _compose; }
            set { _compose = value; }
        }
        public DateTime transitTime
        {
            get { return _transitTime; }
            set { _transitTime = value; }
        }
        public LatLng position1
        {
            get { return _position1; }
            set { _position1 = value; }
        }
        public DateTime birth1
        {
            get { return _birth1; }
            set { _birth1 = value; }
        }
        public int zone1
        {
            get { return _zone1; }
            set { _zone1 = value; }
        }
        public AppCmn.AppEnum.BOOL IsDaylight1
        {
            get { return _isDaylight1; }
            set { _isDaylight1 = value; }
        }
        public string composeFile1
        {
            get { return _composeFile1; }
            set { _composeFile1 = value; }
        }
        public string composeFile2
        {
            get { return _composeFile2; }
            set { _composeFile2 = value; }
        }
        public LatLng transitPosition
        {
            get { return _transitPosition; }
            set { _transitPosition = value; }
        }

        public Star[] Stars
        {
            get { return xing; }
            set { xing = value; }
        }
        #endregion

    }

    [Serializable]
    public class Star
    {
        public Star(int i)
        {
            starname = (PublicValue.AstroStar)Enum.Parse(typeof(PublicValue.AstroStar), i.ToString());
        }
        #region 私有变量
        private PublicValue.AstroStar starname = new PublicValue.AstroStar();
        private int gong = 1;//所在宫号，第一宫为1
        private int degree = 0;//所在星座度数
        private decimal cent = 0;//所在星座分数
        private PublicValue.Constellation constellation = new PublicValue.Constellation();//所在星座
        private decimal progress = 0;//每天推进数
        #endregion

        #region 接口
        public PublicValue.AstroStar StarName
        {
            get { return starname; }
            set { starname = value; }
        }
        public int Gong
        {
            get { return gong; }
            set { gong = value; }
        }
        public int Degree
        {
            get { return degree; }
            set { degree = value; }
        }
        public decimal Cent
        {
            get { return cent; }
            set { cent = value; }
        }
        public PublicValue.Constellation Constellation
        {
            get { return constellation; }
            set { constellation = value; }
        }
        public decimal Progress
        {
            get { return progress; }
            set { progress = value; }
        }
        #endregion
    }
}
