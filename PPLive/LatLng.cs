using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppMod.WebSys;
using System.Runtime.Serialization;
using System.Data;
using AppBll.WebSys;

namespace PPLive
{
    [Serializable]
    [DataContract]
    public class LatLng
    {
        public LatLng()
        { }
        public LatLng(SYS_DistrictMod area)
        {
            try
            {
                _area = area;
                latitude = decimal.Parse(area.Latitude);
                longitude = decimal.Parse(area.longitude);
                if (latitude < 0)
                {
                    Lat = (0 - latitude).ToString("0.00").Replace(".", "S");
                }
                else
                {
                    Lat = latitude.ToString("0.00").Replace(".", "N");
                }
                if (longitude < 0)
                {
                    Lng = (0 - longitude).ToString("0.00").Replace(".", "W");
                }
                else
                {
                    Lng = longitude.ToString("0.00").Replace(".", "E");
                }
                DataTable m_dt = SYS_DistrictBll.GetInstance().GetTreeDetail(area.SysNo);
                StringBuilder m_sb = new StringBuilder();
                m_sb.Append(m_dt.Rows[0]["Name1"].ToString());
                if (!string.IsNullOrEmpty(m_dt.Rows[0]["Name2"].ToString()))
                {
                    m_sb.Append("-").Append(m_dt.Rows[0]["Name2"].ToString());
                }
                if (!string.IsNullOrEmpty(m_dt.Rows[0]["Name3"].ToString()))
                {
                    m_sb.Append("-").Append(m_dt.Rows[0]["Name3"].ToString());
                }
                name = m_sb.ToString();
            }
            catch { }
        }

        //public LatLng(decimal inputLat, decimal inputLng)
        //{
        //    try
        //    {
        //        latitude = inputLat;
        //        longitude = inputLng;
        //        if (latitude < 0)
        //        {
        //            Lat = (0 - latitude).ToString("0.00").Replace(".", "S");
        //        }
        //        else
        //        {
        //            Lat = latitude.ToString("0.00").Replace(".", "N");
        //        }
        //        if (longitude < 0)
        //        {
        //            Lng = (0 - longitude).ToString("0.00").Replace(".", "W");
        //        }
        //        else
        //        {
        //            Lng = longitude.ToString("0.00").Replace(".", "E");
        //        }
        //        name = "";
        //    }
        //    catch { }
        //}

        public LatLng(string inputLat, string inputLng,string poiname)
        {
            try
            {
                Lat = inputLat;
                Lng = inputLng;

                if (inputLat.Contains("."))
                {
                    latitude = decimal.Parse(inputLat);
                    longitude = decimal.Parse(inputLng);
                    if (latitude < 0)
                    {
                        Lat = (0 - latitude).ToString("0.00").Replace(".", "S");
                    }
                    else
                    {
                        Lat = latitude.ToString("0.00").Replace(".", "N");
                    }
                    if (longitude < 0)
                    {
                        Lng = (0 - longitude).ToString("0.00").Replace(".", "W");
                    }
                    else
                    {
                        Lng = longitude.ToString("0.00").Replace(".", "E");
                    }
                }
                else
                {

                    if (inputLat.Contains("S"))
                    {
                        latitude = 0 - decimal.Parse(inputLat.Replace("S", "."));
                    }
                    else if (inputLat.Contains("N"))
                    {
                        latitude = decimal.Parse(inputLat.Replace("N", "."));
                    }
                    if (inputLng.Contains("W"))
                    {
                        longitude = 0 - decimal.Parse(inputLng.Replace("W", "."));
                    }
                    else if (inputLng.Contains("E"))
                    {
                        longitude = decimal.Parse(inputLng.Replace("E", "."));
                    }
                }
                name = poiname;
            }
            catch { }
        }

        private void SetLatLng()
        {
 
        }
        
        #region 私有变量
        private decimal _latitude = 0m;//维度
        private decimal _longitude = 0m;//经度
        private string _Lat = "";
        private string _Lng = "";

        private string _name = "";
        private SYS_DistrictMod _area = new SYS_DistrictMod();
        #endregion

        #region 属性
        [DataMember]
        public decimal latitude
        {
            get {
                if (_latitude == 0m&&_Lat!="") 
                {
                    if (_Lat.Contains("S"))
                    {
                        _latitude = 0 - decimal.Parse(_Lat.Replace("S", "."));
                    }
                    else if (_Lat.Contains("N"))
                    {
                        _latitude = decimal.Parse(_Lat.Replace("N", "."));
                    }
                }
                return _latitude;
            }
            set { _latitude = value; }
        }
        [DataMember]
        public decimal longitude
        {
            get {
                if (_longitude == 0m && _Lng != "")
                {
                    if (_Lng.Contains("W"))
                    {
                        _longitude = 0 - decimal.Parse(_Lng.Replace("W", "."));
                    }
                    else if (_Lng.Contains("E"))
                    {
                        _longitude = decimal.Parse(_Lng.Replace("E", "."));
                    }
                } 
                return _longitude;
            }
            set { _longitude = value; }
        }
        [DataMember]
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        [DataMember]
        public string Lat
        {
            get {
                if (_Lat == "" && _latitude != 0m)
                {
                    if (_latitude < 0)
                    {
                        _Lat = (0 - _latitude).ToString("0.00").Replace(".", "S");
                    }
                    else
                    {
                        _Lat = _latitude.ToString("0.00").Replace(".", "N");
                    }
                }
                return _Lat;
            }
            set { _Lat = value; }
        }
        [DataMember]
        public string Lng
        {
            get {
                if (_Lng == "" && _longitude != 0m)
                {
                    if (_longitude < 0)
                    {
                        _Lng = (0 - _longitude).ToString("0.00").Replace(".", "W");
                    }
                    else
                    {
                        _Lng = _longitude.ToString("0.00").Replace(".", "E");
                    }
                }
                return _Lng;
            }
            set { _Lng = value; }
        }
        [DataMember]
        public SYS_DistrictMod Area
        {
            get { return _area; }
            set { _area = value; }
        }

        #endregion


    }
}
