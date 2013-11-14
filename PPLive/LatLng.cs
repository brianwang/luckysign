using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppMod.WebSys;

namespace PPLive
{
    [Serializable]
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
                name = area.EnglishName;
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

        public LatLng(string inputLat, string inputLng)
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
                name = "";
            }
            catch { }
        }
        
        #region 私有变量
        private decimal _latitude = 0m;//维度
        private decimal _longitude = 0m;//经度
        private string _Lat = "";
        private string _Lng = "";

        private string _name = "";
        private SYS_DistrictMod _area = new SYS_DistrictMod();
        #endregion

        #region 接口
        public decimal latitude
        {
            get { return _latitude; }
            set { _latitude = value; }
        }
        public decimal longitude
        {
            get { return _longitude; }
            set { _longitude = value; }
        }
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Lat
        {
            get { return _Lat; }
            set { _Lat = value; }
        }
        public string Lng
        {
            get { return _Lng; }
            set { _Lng = value; }
        }
        public SYS_DistrictMod Area
        {
            get { return _area; }
            set { _area = value; }
        }

        #endregion


    }
}
