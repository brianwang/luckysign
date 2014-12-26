using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace AppCmn
{
    public class Passport
    {
        public static bool CheckCookiesOn()
        {
            bool ret = false;
            HttpContext.Current.Response.Cookies["upup1000test"]["ttt"] = "text";
            if (HttpContext.Current.Server.UrlDecode(HttpContext.Current.Request.Cookies["upup1000test"]["ttt"]) != null)
            {
                ret = true;
                HttpContext.Current.Request.Cookies["upup1000test"].Expires = DateTime.Now.AddDays(-1);
            }
            return ret;
        }

        #region 普通用户
        public string userid
        {
            get
            {
                if (HttpContext.Current.Request.Cookies["upup1000"] == null || HttpContext.Current.Request.Cookies["upup1000"]["userid"] == null)
                {
                    return "";
                }
                else
                {
                    return HttpContext.Current.Server.UrlDecode(CommonTools.Decode(HttpContext.Current.Request.Cookies["upup1000"]["userid"].Trim()));
                }
            }
            set
            {
                if (value == "")
                {
                    HttpContext.Current.Response.Cookies["upup1000"]["userid"] = "";
                }
                else
                {
                    HttpContext.Current.Response.Cookies["upup1000"]["userid"] = CommonTools.Encode(value);
                }
            }
        }
        public string uname
        {
            get
            {
                if (HttpContext.Current.Request.Cookies["upup1000"] == null || HttpContext.Current.Request.Cookies["upup1000"]["uname"] == null)
                {
                    return "";
                }
                else
                {
                    return HttpContext.Current.Server.UrlDecode(CommonTools.Decode(HttpContext.Current.Request.Cookies["upup1000"]["uname"].Trim()));
                }
            }
            set
            {
                if (value == "")
                {
                    HttpContext.Current.Response.Cookies["upup1000"]["uname"] = "";
                }
                else
                {
                    HttpContext.Current.Response.Cookies["upup1000"]["uname"] = CommonTools.Encode(value);
                }
            }
        }
        public string area
        {
            get
            {
                if (HttpContext.Current.Request.Cookies["upup1000"] == null || HttpContext.Current.Request.Cookies["upup1000"]["area"] == null)
                {
                    return "";
                }
                else
                {
                    return HttpContext.Current.Server.UrlDecode(CommonTools.Decode(HttpContext.Current.Request.Cookies["upup1000"]["area"].Trim()));
                }
            }
            set
            {
                if (value == "")
                {
                    HttpContext.Current.Response.Cookies["upup1000"]["area"] = "";
                }
                else
                {
                    HttpContext.Current.Response.Cookies["upup1000"]["area"] = CommonTools.Encode(value);
                }
            }
        }
        public string areaname
        {
            get
            {
                if (HttpContext.Current.Request.Cookies["upup1000"] == null || HttpContext.Current.Request.Cookies["upup1000"]["areaname"] == null)
                {
                    return "";
                }
                else
                {
                    return HttpContext.Current.Server.UrlDecode(CommonTools.Decode(HttpContext.Current.Request.Cookies["upup1000"]["areaname"].Trim()));
                }
            }
            set
            {
                if (value == "")
                {
                    HttpContext.Current.Response.Cookies["upup1000"]["areaname"] = "";
                }
                else
                {
                    HttpContext.Current.Response.Cookies["upup1000"]["areaname"] = CommonTools.Encode(value);
                }
            }
        }
        public string photo
        {
            get
            {
                if (HttpContext.Current.Request.Cookies["upup1000"] == null || HttpContext.Current.Request.Cookies["upup1000"]["photo"] == null)
                {
                    return "";
                }
                else
                {
                    return HttpContext.Current.Server.UrlDecode(CommonTools.Decode(HttpContext.Current.Request.Cookies["upup1000"]["photo"].Trim()));
                }
            }
            set
            {
                if (value == "")
                {
                    HttpContext.Current.Response.Cookies["upup1000"]["photo"] = "";
                }
                else
                {
                    HttpContext.Current.Response.Cookies["upup1000"]["photo"] = CommonTools.Encode(value);
                }
            }
        }
        #endregion

    }
}
