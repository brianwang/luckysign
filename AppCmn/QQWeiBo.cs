using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Web;
using System.Data;
using System.Security.Cryptography;
using System.Net;
using System.IO;

namespace AppCmn
{
    public class QQWeiBo
    {
        public bool AddFriend(string openid, string openkey, string ip, string name, AppEnum.Apps app)
        {
            bool flag = false;
            SortedDictionary<string, string> dictionary = new SortedDictionary<string, string>();
            dictionary.Add("format", "xml");
            dictionary.Add("name", name);
            dictionary.Add("clientip", ip);
            dictionary.Add("appid", AppConfig.QQWeiBoAppID()[(int)app]);
            dictionary.Add("openid", openid);
            dictionary.Add("openkey", openkey);
            TimeSpan span = new TimeSpan(DateTime.Now.Ticks);
            dictionary.Add("reqtime", ((int)Math.Floor(span.TotalSeconds)).ToString());
            dictionary.Add("wbversion", "1");
            string paras = "";
            foreach (KeyValuePair<string, string> pair in dictionary)
            {
                string str3 = paras;
                paras = str3 + pair.Key + "=" + pair.Value + "&";
            }
            paras.Remove(paras.Length - 1);
            paras = paras + "&sig=" + this.GetSign("friends/add", paras, "POST", app);
            string xml = this.HttpPost(HttpUtility.UrlPathEncode(paras), "http://open.t.qq.com/api/friends/add", "utf-8");
            XmlDocument document = new XmlDocument();
            document.LoadXml(xml);
            if (document != null)
            {
                XmlNode node = document.SelectSingleNode("//root");
                if ((node != null) && (node.SelectSingleNode("//ret").InnerXml == "0"))
                {
                    flag = true;
                }
            }
            return flag;
        }

        public bool AddFriend(string openid, string accesstoken, string ip, string name, AppEnum.Apps app, bool isaccesstoken)
        {
            bool flag = false;
            SortedDictionary<string, string> dictionary = new SortedDictionary<string, string>();
            dictionary.Add("format", "xml");
            dictionary.Add("name", name);
            dictionary.Add("oauth_consumer_key", AppConfig.QQWeiBoAppID()[(int)app]);
            dictionary.Add("openid", openid);
            dictionary.Add("access_token", accesstoken);
            dictionary.Add("clientip", ip);
            dictionary.Add("oauth_version", "2.a");
            dictionary.Add("scope", "all");
            string str = "";
            foreach (KeyValuePair<string, string> pair in dictionary)
            {
                string str3 = str;
                str = str3 + pair.Key + "=" + pair.Value + "&";
            }
            str.Remove(str.Length - 1);
            string xml = this.HttpPost(HttpUtility.UrlPathEncode(str), "https://open.t.qq.com/api/friends/add", "utf-8");
            XmlDocument document = new XmlDocument();
            document.LoadXml(xml);
            if (document != null)
            {
                XmlNode node = document.SelectSingleNode("//root");
                if ((node != null) && (node.SelectSingleNode("//ret").InnerXml == "0"))
                {
                    flag = true;
                }
            }
            return flag;
        }

        public bool CheckFriend(string openid, string openkey, string ip, AppEnum.Apps app)
        {
            bool flag = false;
            SortedDictionary<string, string> dictionary = new SortedDictionary<string, string>();
            dictionary.Add("format", "xml");
            dictionary.Add("names", "iamsnowsnow");
            dictionary.Add("flag", "1");
            dictionary.Add("appid", AppConfig.QQWeiBoAppID()[(int)app]);
            dictionary.Add("openid", openid);
            dictionary.Add("openkey", openkey);
            dictionary.Add("clientip", ip);
            TimeSpan span = new TimeSpan(DateTime.Now.Ticks);
            dictionary.Add("reqtime", ((int)Math.Floor(span.TotalSeconds)).ToString());
            dictionary.Add("wbversion", "1");
            string paras = "";
            foreach (KeyValuePair<string, string> pair in dictionary)
            {
                string str3 = paras;
                paras = str3 + pair.Key + "=" + pair.Value + "&";
            }
            paras.Remove(paras.Length - 1);
            paras = "http://open.t.qq.com/api/friends/check?" + paras + "&sig=" + this.GetSign("friends/check", paras, "GET", app);
            string xml = this.HttpGet(paras, "utf-8");
            XmlDocument document = new XmlDocument();
            document.LoadXml(xml);
            if (document != null)
            {
                XmlNode node = document.SelectSingleNode("//root");
                if (node == null)
                {
                    return flag;
                }
                if (node.SelectSingleNode("//ret").InnerXml != "0")
                {
                    return flag;
                }
                if (node.SelectSingleNode("//data").FirstChild.InnerXml == "true")
                {
                    flag = true;
                }
            }
            return flag;
        }

        public bool CheckFriend(string openid, string accesstoken, string ip, AppEnum.Apps app, bool isaccesstoken)
        {
            bool flag = false;
            SortedDictionary<string, string> dictionary = new SortedDictionary<string, string>();
            dictionary.Add("format", "xml");
            dictionary.Add("names", "iamsnowsnow");
            dictionary.Add("flag", "1");
            dictionary.Add("oauth_consumer_key", AppConfig.QQWeiBoAppID()[(int)app]);
            dictionary.Add("openid", openid);
            dictionary.Add("access_token", accesstoken);
            dictionary.Add("clientip", ip);
            dictionary.Add("oauth_version", "2.a");
            dictionary.Add("scope", "all");
            string str = "";
            foreach (KeyValuePair<string, string> pair in dictionary)
            {
                string str3 = str;
                str = str3 + pair.Key + "=" + pair.Value + "&";
            }
            str.Remove(str.Length - 1);
            str = "https://open.t.qq.com/api/friends/check?" + str;
            string xml = this.HttpGet(str, "utf-8");
            XmlDocument document = new XmlDocument();
            document.LoadXml(xml);
            if (document != null)
            {
                XmlNode node = document.SelectSingleNode("//root");
                if (node == null)
                {
                    return flag;
                }
                if (node.SelectSingleNode("//ret").InnerXml != "0")
                {
                    return flag;
                }
                if (node.SelectSingleNode("//data").FirstChild.InnerXml == "true")
                {
                    flag = true;
                }
            }
            return flag;
        }

        public DataTable GetReList(string openid, string openkey, string ip, int rootid, int type, AppEnum.Apps app)
        {
            DataTable table = new DataTable();
            SortedDictionary<string, string> dictionary = new SortedDictionary<string, string>();
            dictionary.Add("format", "xml");
            dictionary.Add("rootid", rootid.ToString());
            dictionary.Add("flag", type.ToString());
            dictionary.Add("pageflag", "0");
            dictionary.Add("pagetime", "0");
            dictionary.Add("reqnum", "100");
            dictionary.Add("twitterid", "0");
            dictionary.Add("clientip", ip);
            dictionary.Add("appid", AppConfig.QQWeiBoAppID()[(int)app]);
            dictionary.Add("openid", openid);
            dictionary.Add("openkey", openkey);
            TimeSpan span = new TimeSpan(DateTime.Now.Ticks);
            dictionary.Add("reqtime", ((int)Math.Floor(span.TotalSeconds)).ToString());
            dictionary.Add("wbversion", "1");
            string paras = "";
            foreach (KeyValuePair<string, string> pair in dictionary)
            {
                string str3 = paras;
                paras = str3 + pair.Key + "=" + pair.Value + "&";
            }
            paras.Remove(paras.Length - 1);
            paras = paras + "&sig=" + this.GetSign("t/re_list", paras, "POST", app);
            string xml = this.HttpPost(HttpUtility.UrlPathEncode(paras), "https://open.t.qq.com/api/t/re_list", "utf-8");
            XmlDocument document = new XmlDocument();
            document.LoadXml(xml);
            if (document != null)
            {
                XmlNode node = document.SelectSingleNode("//root");
                if (node != null)
                {
                    bool flag1 = node.SelectSingleNode("//ret").InnerXml == "0";
                }
            }
            return table;
        }

        private string GetSign(string URI, string paras, string httptype, AppEnum.Apps app)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(httptype).Append(HttpUtility.UrlEncode(URI)).Append(HttpUtility.UrlEncode(paras));
            HMACSHA1 hmacsha = new HMACSHA1
            {
                Key = Encoding.ASCII.GetBytes(AppConfig.QQWeiBoAppSecret()[(int)app])
            };
            byte[] bytes = Encoding.ASCII.GetBytes(builder.ToString());
            return Convert.ToBase64String(hmacsha.ComputeHash(bytes));
        }

        public string GetUserSimpleInfo(string openid, string openkey, string ip, AppEnum.Apps app)
        {
            string str = "|||0|0";
            SortedDictionary<string, string> dictionary = new SortedDictionary<string, string>();
            dictionary.Add("format", "xml");
            dictionary.Add("appid", AppConfig.QQWeiBoAppID()[(int)app]);
            dictionary.Add("openid", openid);
            dictionary.Add("openkey", openkey);
            dictionary.Add("clientip", ip);
            TimeSpan span = new TimeSpan(DateTime.Now.Ticks);
            dictionary.Add("reqtime", ((int)Math.Floor(span.TotalSeconds)).ToString());
            dictionary.Add("wbversion", "1");
            string paras = "";
            foreach (KeyValuePair<string, string> pair in dictionary)
            {
                string str4 = paras;
                paras = str4 + pair.Key + "=" + pair.Value + "&";
            }
            paras.Remove(paras.Length - 1);
            paras = "http://open.t.qq.com/api/user/info?" + paras + "&sig=" + this.GetSign("user/info", paras, "GET", app);
            string xml = this.HttpGet(paras, "utf-8");
            XmlDocument document = new XmlDocument();
            document.LoadXml(xml);
            if (document == null)
            {
                return str;
            }
            XmlNode node = document.SelectSingleNode("//root");
            if (node == null)
            {
                return str;
            }
            if (node.SelectSingleNode("//ret").InnerXml != "0")
            {
                return str;
            }
            XmlNode node2 = node.SelectSingleNode("//data");
            return (node2.SelectSingleNode("//name").InnerXml + "|" + node2.SelectSingleNode("//nick").InnerXml + "|" + node2.SelectSingleNode("//location").InnerXml + "|" + node2.SelectSingleNode("//fansnum").InnerXml + "|" + node2.SelectSingleNode("//isvip").InnerXml + "|" + node2.SelectSingleNode("//head").InnerXml + "|" + node2.SelectSingleNode("//introduction").InnerXml + "|" + node2.SelectSingleNode("//sex").InnerXml);
        }

        public string GetUserSimpleInfo(string openid, string accesstoken, string ip, AppEnum.Apps app, bool isaccesstoken)
        {
            string str = "|||0|0";
            SortedDictionary<string, string> dictionary = new SortedDictionary<string, string>();
            dictionary.Add("format", "xml");
            dictionary.Add("oauth_consumer_key", AppConfig.QQWeiBoAppID()[(int)app]);
            dictionary.Add("openid", openid);
            dictionary.Add("access_token", accesstoken);
            dictionary.Add("clientip", ip);
            dictionary.Add("oauth_version", "2.a");
            dictionary.Add("scope", "all");
            string str2 = "";
            foreach (KeyValuePair<string, string> pair in dictionary)
            {
                string str4 = str2;
                str2 = str4 + pair.Key + "=" + pair.Value + "&";
            }
            str2.Remove(str2.Length - 1);
            str2 = "https://open.t.qq.com/api/user/info?" + str2;
            string xml = this.HttpGet(str2, "utf-8");
            XmlDocument document = new XmlDocument();
            document.LoadXml(xml);
            if (document == null)
            {
                return str;
            }
            XmlNode node = document.SelectSingleNode("//root");
            if (node == null)
            {
                return str;
            }
            if (node.SelectSingleNode("//ret").InnerXml != "0")
            {
                return str;
            }
            XmlNode node2 = node.SelectSingleNode("//data");
            return (node2.SelectSingleNode("//name").InnerXml + "|" + node2.SelectSingleNode("//nick").InnerXml + "|" + node2.SelectSingleNode("//location").InnerXml + "|" + node2.SelectSingleNode("//fansnum").InnerXml + "|" + node2.SelectSingleNode("//isvip").InnerXml + "|" + node2.SelectSingleNode("//head").InnerXml + "|" + node2.SelectSingleNode("//introduction").InnerXml + "|" + node2.SelectSingleNode("//sex").InnerXml);
        }

        public XmlDocument GetUserWeiBoList(string openid, string openkey, string ip, string name, int type, AppEnum.Apps app)
        {
            SortedDictionary<string, string> dictionary = new SortedDictionary<string, string>();
            dictionary.Add("format", "xml");
            dictionary.Add("name", name);
            dictionary.Add("type", type.ToString());
            dictionary.Add("pageflag", "0");
            dictionary.Add("pagetime", "0");
            dictionary.Add("reqnum", "100");
            dictionary.Add("lastid", "0");
            dictionary.Add("fopenid", "");
            dictionary.Add("contenttype", "0");
            dictionary.Add("clientip", ip);
            dictionary.Add("appid", AppConfig.QQWeiBoAppID()[(int)app]);
            dictionary.Add("openid", openid);
            dictionary.Add("openkey", openkey);
            TimeSpan span = new TimeSpan(DateTime.Now.Ticks);
            dictionary.Add("reqtime", ((int)Math.Floor(span.TotalSeconds)).ToString());
            dictionary.Add("wbversion", "1");
            string paras = "";
            foreach (KeyValuePair<string, string> pair in dictionary)
            {
                string str3 = paras;
                paras = str3 + pair.Key + "=" + pair.Value + "&";
            }
            paras.Remove(paras.Length - 1);
            string xml = this.HttpGet("https://open.t.qq.com/api/statuses/user_timeline?" + (paras + "&sig=" + this.GetSign("statuses/user_timeline", paras, "GET", app)), "utf-8");
            XmlDocument document = new XmlDocument();
            document.LoadXml(xml);
            if (document == null)
            {
                return null;
            }
            return document;
        }

        public XmlDocument GetTopicList(string openid, string openkey, string ip, string name, int type, AppEnum.Apps app)
        {
            SortedDictionary<string, string> dictionary = new SortedDictionary<string, string>();
            dictionary.Add("format", "xml");
            dictionary.Add("httext", name);
            dictionary.Add("htid", "0");
            dictionary.Add("type", type.ToString());
            dictionary.Add("pageflag", "0");
            dictionary.Add("flag", "0");
            dictionary.Add("time", "0");
            dictionary.Add("reqnum", "100");
            dictionary.Add("tweetid ", "0");
            dictionary.Add("contenttype", "0");
            dictionary.Add("clientip", ip);
            dictionary.Add("appid", AppConfig.QQWeiBoAppID()[(int)app]);
            dictionary.Add("openid", openid);
            dictionary.Add("openkey", openkey);
            TimeSpan span = new TimeSpan(DateTime.Now.Ticks);
            dictionary.Add("reqtime", ((int)Math.Floor(span.TotalSeconds)).ToString());
            dictionary.Add("wbversion", "1");
            string paras = "";
            foreach (KeyValuePair<string, string> pair in dictionary)
            {
                string str3 = paras;
                paras = str3 + pair.Key + "=" + pair.Value + "&";
            }
            paras.Remove(paras.Length - 1);
            string xml = this.HttpGet("https://open.t.qq.com/api/statuses/ht_timeline_ext?" + (paras + "&sig=" + this.GetSign("statuses/user_timeline", paras, "GET", app)), "utf-8");
            XmlDocument document = new XmlDocument();
            document.LoadXml(xml);
            if (document == null)
            {
                return null;
            }
            return document;
        }

        private string HttpGet(string m_url, string coding)
        {
            string str2;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(m_url);
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 5.5; Windows NT 4.0)";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(coding));
            StringBuilder builder = new StringBuilder();
            while ((str2 = reader.ReadLine()) != null)
            {
                builder.Append(str2 + "\r\n");
            }
            return builder.ToString();
        }

        private string HttpPost(string postData, string url, string coding)
        {
            Encoding encoding = Encoding.GetEncoding(coding);
            byte[] bytes = encoding.GetBytes(postData);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentLength = bytes.Length;
            request.ContentType = "application/x-www-form-urlencoded";
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);
            requestStream.Close();
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), encoding);
            return reader.ReadToEnd();
        }

        public bool SendPicWeiBo(string openid, string openkey, string ip, string content, string pic, AppEnum.Apps app)
        {
            bool flag = false;
            SortedDictionary<string, string> dictionary = new SortedDictionary<string, string>();
            dictionary.Add("format", "xml");
            dictionary.Add("content", content);
            dictionary.Add("pic_url", pic);
            dictionary.Add("clientip", ip);
            dictionary.Add("appid", AppConfig.QQWeiBoAppID()[(int)app]);
            dictionary.Add("openid", openid);
            dictionary.Add("openkey", openkey);
            TimeSpan span = new TimeSpan(DateTime.Now.Ticks);
            dictionary.Add("reqtime", ((int)Math.Floor(span.TotalSeconds)).ToString());
            dictionary.Add("wbversion", "1");
            string paras = "";
            foreach (KeyValuePair<string, string> pair in dictionary)
            {
                string str3 = paras;
                paras = str3 + pair.Key + "=" + pair.Value + "&";
            }
            paras.Remove(paras.Length - 1);
            paras = paras + "&sig=" + this.GetSign("t/add_pic_url", paras, "POST", app);
            string xml = this.HttpPost(HttpUtility.UrlPathEncode(paras), "http://open.t.qq.com/api/t/add_pic_url", "utf-8");
            XmlDocument document = new XmlDocument();
            document.LoadXml(xml);
            if (document != null)
            {
                XmlNode node = document.SelectSingleNode("//root");
                if ((node != null) && (node.SelectSingleNode("//ret").InnerXml == "0"))
                {
                    flag = true;
                }
            }
            return flag;
        }

        public bool SendPicWeiBo(string openid, string accesstoken, string ip, string content, string pic, AppEnum.Apps app, bool isaccesstoken)
        {
            bool flag = false;
            SortedDictionary<string, string> dictionary = new SortedDictionary<string, string>();
            dictionary.Add("format", "xml");
            dictionary.Add("content", content);
            dictionary.Add("pic_url", pic);
            dictionary.Add("clientip", ip);
            dictionary.Add("oauth_consumer_key", AppConfig.QQWeiBoAppID()[(int)app]);
            dictionary.Add("openid", openid);
            dictionary.Add("access_token", accesstoken);
            dictionary.Add("clientip", ip);
            dictionary.Add("oauth_version", "2.a");
            dictionary.Add("scope", "all");
            string str = "";
            foreach (KeyValuePair<string, string> pair in dictionary)
            {
                string str3 = str;
                str = str3 + pair.Key + "=" + pair.Value + "&";
            }
            str.Remove(str.Length - 1);
            string xml = this.HttpPost(HttpUtility.UrlPathEncode(str), "https://open.t.qq.com/api/t/add_pic_url", "utf-8");
            XmlDocument document = new XmlDocument();
            document.LoadXml(xml);
            if (document != null)
            {
                XmlNode node = document.SelectSingleNode("//root");
                if ((node != null) && (node.SelectSingleNode("//ret").InnerXml == "0"))
                {
                    flag = true;
                }
            }
            return flag;
        }

        public bool SendWeiBoWithPic(string openid, string accesstoken, string ip, string content, string pic, AppEnum.Apps app, bool isaccesstoken)
        {
            bool flag = false;
            SortedDictionary<string, string> dictionary = new SortedDictionary<string, string>();
            dictionary.Add("format", "xml");
            dictionary.Add("content", content);
            dictionary.Add("pic", pic);
            dictionary.Add("clientip", ip);
            dictionary.Add("oauth_consumer_key", AppConfig.QQWeiBoAppID()[(int)app]);
            dictionary.Add("openid", openid);
            dictionary.Add("access_token", accesstoken);
            dictionary.Add("clientip", ip);
            dictionary.Add("oauth_version", "2.a");
            dictionary.Add("scope", "all");
            string str = "";
            foreach (KeyValuePair<string, string> pair in dictionary)
            {
                string str3 = str;
                str = str3 + pair.Key + "=" + pair.Value + "&";
            }
            str.Remove(str.Length - 1);
            string xml = this.HttpPost(HttpUtility.UrlPathEncode(str), "https://open.t.qq.com/api/t/add_pic", "utf-8");
            XmlDocument document = new XmlDocument();
            document.LoadXml(xml);
            if (document != null)
            {
                XmlNode node = document.SelectSingleNode("//root");
                if ((node != null) && (node.SelectSingleNode("//ret").InnerXml == "0"))
                {
                    flag = true;
                }
            }
            return flag;
        }

 

 

    }
}
