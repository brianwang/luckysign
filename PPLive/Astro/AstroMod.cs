using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace PPLive.Astro
{
    [Serializable]
    [DataContract]
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

        private PublicValue.AstroType _type = PublicValue.AstroType.benming;
        private PublicValue.AstroZuhe _compose = PublicValue.AstroZuhe.bijiao;
        private LatLng _position1 = new LatLng();
        private DateTime _birth1 = DateTime.Now;
        private int _zone1 = 0;//时区
        private AppCmn.AppEnum.BOOL _isDaylight1 = AppCmn.AppEnum.BOOL.False;

        private PublicValue.AstroTuiyun _transit = PublicValue.AstroTuiyun.xingyun;//推运类型
        private DateTime _transitTime = DateTime.Now;//推运时间
        private LatLng _transitPosition = new LatLng();

        private string _composeFile1 = "";
        private string _composeFile2 = "";

        private AppCmn.AppEnum.Gender _gender = AppCmn.AppEnum.Gender.none;
        private AppCmn.AppEnum.Gender _gender1 = AppCmn.AppEnum.Gender.none;

        private Star[] xing = new Star[32];
        private Star[] xing1 = new Star[32]; 
        #endregion

        #region 接口
        [DataMember]
        public LatLng position
        {
            get { return _position; }
            set { _position = value; }
        }
        [DataMember]
        public DateTime birth
        {
            get { return _birth; }
            set { _birth = value; }
        }
        [DataMember]
        public int zone
        {
            get { return _zone; }
            set { _zone = value; }
        }
        [DataMember]
        public string graphicID
        {
            get { return _graphicID; }
            set { _graphicID = value; }
        }
        [DataMember]
        public AppCmn.AppEnum.BOOL IsDayLight
        {
            get { return _isDaylight; }
            set { _isDaylight = value; }
        }
        [DataMember]
        public AppCmn.AppEnum.Gender Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }
        [DataMember]
        public AppCmn.AppEnum.Gender Gender1
        {
            get { return _gender1; }
            set { _gender1 = value; }
        }
        [DataMember]
        public int houseSystem
        {
            get { return _houseSystem; }
            set { _houseSystem = value; }
        }
        [DataMember]
        public Dictionary<int, string> startsShow
        {
            get { return _startsShow; }
            set { _startsShow = value; }
        }
        [DataMember]
        public Dictionary<int, decimal> aspectsShow
        {
            get { return _aspectsShow; }
            set { _aspectsShow = value; }
        }
        [DataMember]
        public PublicValue.AstroType type
        {
            get { return _type; }
            set { _type = value; }
        }
        [DataMember]
        public PublicValue.AstroTuiyun transit
        {
            get { return _transit; }
            set { _transit = value; }
        }
        [DataMember]
        public PublicValue.AstroZuhe compose
        {
            get { return _compose; }
            set { _compose = value; }
        }
        [DataMember]
        public DateTime transitTime
        {
            get { return _transitTime; }
            set { _transitTime = value; }
        }
        [DataMember]
        public LatLng position1
        {
            get { return _position1; }
            set { _position1 = value; }
        }
        [DataMember]
        public DateTime birth1
        {
            get { return _birth1; }
            set { _birth1 = value; }
        }
        [DataMember]
        public int zone1
        {
            get { return _zone1; }
            set { _zone1 = value; }
        }
        [DataMember]
        public AppCmn.AppEnum.BOOL IsDayLight1
        {
            get { return _isDaylight1; }
            set { _isDaylight1 = value; }
        }
        //[DataMember]
        public string composeFile1
        {
            get { return _composeFile1; }
            set { _composeFile1 = value; }
        }
        //[DataMember]
        public string composeFile2
        {
            get { return _composeFile2; }
            set { _composeFile2 = value; }
        }
        [DataMember]
        public LatLng transitPosition
        {
            get { return _transitPosition; }
            set { _transitPosition = value; }
        }
        [DataMember]
        public Star[] Stars
        {
            get { return xing; }
            set { xing = value; }
        }
        [DataMember]
        public Star[] Stars1
        {
            get { return xing1; }
            set { xing1 = value; }
        }
        #endregion

    }

    [Serializable]
    [DataContract]
    public class Star
    {
        public Star(int i)
        {
            starname = (PublicValue.AstroStar)Enum.Parse(typeof(PublicValue.AstroStar), i.ToString());
        }
        public Star()
        {
            
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
        [DataMember]
        public PublicValue.AstroStar StarName
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
        public int Degree
        {
            get { return degree; }
            set { degree = value; }
        }
        [DataMember]
        public decimal Cent
        {
            get { return cent; }
            set { cent = value; }
        }
        [DataMember]
        public PublicValue.Constellation Constellation
        {
            get { return constellation; }
            set { constellation = value; }
        }
        [DataMember]
        public decimal Progress
        {
            get { return progress; }
            set { progress = value; }
        }
        #endregion
    }
}
