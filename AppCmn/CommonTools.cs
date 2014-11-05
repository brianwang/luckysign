using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;
using System.Net;
using System.Collections.Generic;
using System.Collections;

namespace AppCmn
{
    /// <summary>
    /// CommonTools 的摘要说明
    /// </summary>
    public class CommonTools
    {
        public CommonTools()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        



        #region Encode And Decode

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string md5(string str, int code)
        {
            string ret = "";
            if (code == 16) //16位md5加密（取32位加密的9~25字符） 
            {
                ret = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "md5").ToLower().Substring(8, 16);
            }
            if (code == 32) //32位加密 
            {
                ret = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "md5").ToLower();
            }
            return ret;
        }

        public static string Enc_PW(string xID, string xPW, int xLen)
        {
            xID = "EWRTYUuhinom@#$%^&*()_VGhdtqawf";
            string eStr1 = FormsAuthentication.HashPasswordForStoringInConfigFile(xID, "sha1"); // 40
            string eStr2 = "";
            string tStr;
            for (int i = 0; i < 4; i++)
            {
                tStr = eStr1.Substring(10 * i, 10);
                eStr2 += FormsAuthentication.HashPasswordForStoringInConfigFile(xPW + tStr, "md5"); // 32
            }
            int ne1 = (128 - xLen) / 2;
            return eStr2.Substring(ne1, xLen);
        }

        const string KEY_64 = "LuckSign";

        const string IV_64 = "LuckSign";

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string Encode(string data)
        {

            byte[] byKey = System.Text.ASCIIEncoding.ASCII.GetBytes(KEY_64);

            byte[] byIV = System.Text.ASCIIEncoding.ASCII.GetBytes(IV_64);

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();

            int i = cryptoProvider.KeySize;

            MemoryStream ms = new MemoryStream();

            CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateEncryptor(byKey, byIV), CryptoStreamMode.Write);

            StreamWriter sw = new StreamWriter(cst);

            sw.Write(data);

            sw.Flush();

            cst.FlushFinalBlock();

            sw.Flush();

            return Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length).Replace("/","XiEGoN");

        }
        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string Decode(string data)
        {

            byte[] byKey = System.Text.ASCIIEncoding.ASCII.GetBytes(KEY_64);

            byte[] byIV = System.Text.ASCIIEncoding.ASCII.GetBytes(IV_64);

            byte[] byEnc;

            try
            {

                byEnc = Convert.FromBase64String(data.Replace("XiEGoN","/"));

            }

            catch
            {

                return null;

            }

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();

            MemoryStream ms = new MemoryStream(byEnc);

            CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateDecryptor(byKey, byIV), CryptoStreamMode.Read);

            StreamReader sr = new StreamReader(cst);

            return sr.ReadToEnd();

        }
        #endregion

        /// <summary>
        /// check if the client's cookies is on
        /// </summary>
        /// <returns></returns>
        public static bool CheckCookiesOn()
        {
            bool ret = false;
            HttpContext.Current.Response.Cookies["astrotest"]["ttt"] = "text";
            if (HttpContext.Current.Server.UrlDecode(HttpContext.Current.Request.Cookies["astrotest"]["ttt"]) != null)
            {
                ret = true;
                HttpContext.Current.Request.Cookies["astrotest"].Expires = DateTime.Now.AddDays(-1);
            }
            return ret;
        }

        public static bool IsDataTableNoRow(DataTable dt)
        {
            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 用于过滤内容敏感词
        /// </summary>
        /// <param name="inputstr"></param>
        /// <returns></returns>
        public static string StringFilter(string inputstr)
        {
            string ret;
            ret = inputstr;
            return ret;
        }

        /// <summary>
        /// 超过字符数加点截断
        /// </summary>
        /// <param name="stringToSub">要截取的字符串</param>
        /// <param name="length">截取的长度(汉字)</param>
        /// <returns>截取后的字符串</returns>
        public static string CutStr(string stringToSub, int length)
        {
            length = length * 2;
            Regex regex = new Regex("[\u4e00-\u9fa5]+", RegexOptions.Compiled);
            char[] stringChar = stringToSub.ToCharArray();
            StringBuilder sb = new StringBuilder();
            int nLength = 0;
            for (int i = 0; i < stringChar.Length; i++)
            {
                if (regex.IsMatch((stringChar[i]).ToString()))
                {
                    nLength += 2;
                }
                else
                {
                    nLength = nLength + 1;
                }

                if (nLength <= length)
                {
                    sb.Append(stringChar[i]);
                }
                else
                {
                    break;
                }
            }
            if (sb.ToString() != stringToSub)
            {
                sb.Remove(sb.Length - 2, 2);
                sb.Append("...");
            }
            return sb.ToString();
        }

        #region 生成随机值

        private static Random _ra = new Random();
        public static Random ra()
        {
            if (_ra == null)
            { _ra = new Random(); }
            return _ra;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static int ThrowRandom(int min, int max)
        {
            return ra().Next(min, max + 1);
        }

        public static char GetRandomChar()
        {
            int ret = ra().Next(122);
            //while (ret < 48 || (ret > 57 && ret < 65) || (ret > 90 && ret < 97))


            while (ret < 48 || (ret > 57 && ret < 97))
            {
                ret = ra().Next(122);

            }
            return (char)ret;
        }

        public static string GetRandomString(int length)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                sb.Append(GetRandomChar());
            }
            return sb.ToString();
        }

        #endregion

        #region 身份证验证

        private bool CheckIDCard(string Id)
        {
            if (Id.Length == 18)
            {
                bool check = CheckIDCard18(Id);
                return check;
            }
            else if (Id.Length == 15)
            {
                bool check = CheckIDCard15(Id);
                return check;
            }
            else
            {
                return false;
            }
        }

        private bool CheckIDCard18(string Id)
        {
            long n = 0;
            if (long.TryParse(Id.Remove(17), out n) == false || n < Math.Pow(10, 16) || long.TryParse(Id.Replace('x', '0').Replace('X', '0'), out n) == false)
            {
                return false;//数字验证
            }
            string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(Id.Remove(2)) == -1)
            {
                return false;//省份验证
            }
            string birth = Id.Substring(6, 8).Insert(6, "-").Insert(4, "-");
            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false;//生日验证
            }
            string[] arrVarifyCode = ("1,0,x,9,8,7,6,5,4,3,2").Split(',');
            string[] Wi = ("7,9,10,5,8,4,2,1,6,3,7,9,10,5,8,4,2").Split(',');
            char[] Ai = Id.Remove(17).ToCharArray();
            int sum = 0;
            for (int i = 0; i < 17; i++)
            {
                sum += int.Parse(Wi[i]) * int.Parse(Ai[i].ToString());
            }
            int y = -1;
            Math.DivRem(sum, 11, out y);
            if (arrVarifyCode[y] != Id.Substring(17, 1).ToLower())
            {
                return false;//校验码验证
            }
            return true;//符合GB11643-1999标准
        }

        private bool CheckIDCard15(string Id)
        {
            long n = 0;
            if (long.TryParse(Id, out n) == false || n < Math.Pow(10, 14))
            {
                return false;//数字验证
            }
            string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(Id.Remove(2)) == -1)
            {
                return false;//省份验证
            }
            string birth = Id.Substring(6, 6).Insert(4, "-").Insert(2, "-");
            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false;//生日验证
            }
            return true;//符合15位身份证标准
        }

        #endregion

        public static string TimeSimpleShow(TimeSpan input)
        {
            if (input.TotalDays > 0)
            {
                return Convert.ToInt16(Math.Floor(input.TotalDays)).ToString() + "天";
            }
            else if (input.TotalHours > 0)
            {
                return Convert.ToInt16(Math.Floor(input.TotalHours)).ToString() + "小时";
            }
            else if (input.TotalMinutes > 0)
            {
                return Convert.ToInt16(Math.Floor(input.TotalMinutes)).ToString() + "小时";
            }
            else 
            {
                return "小于1分钟";
            }
        }

        public static int CheckPasswordLevel(string pass)
        {
            int ret = 5;
            if (pass.Length > 0)
            {
                char[] tmps = pass.ToCharArray();

                bool allsame = true;
                char tmpchar = tmps[0];
                foreach (char tmp in tmps)
                {
                    if (tmpchar != tmp)
                    {
                        allsame = false;
                    }
                    tmpchar = tmp;
                }
                if (allsame)
                {
                    ret = 0;
                }
            }
            return ret;
        }

        public static string ReadHtmFile(string filePath)
        {
            string templet = "";

            if (filePath.Contains("http:"))
            {
                HttpWebResponse myRes;
                HttpWebRequest myReq;
                Stream m_stream;
                StreamReader m_reader;
                myReq = (HttpWebRequest)WebRequest.Create(filePath);
                myReq.UserAgent = "Mozilla/4.0 (compatible; MSIE 5.5; Windows NT 4.0)";

                try
                {
                    myRes = (HttpWebResponse)myReq.GetResponse();
                    m_stream = myRes.GetResponseStream();
                }
                catch
                { return ""; }
                m_reader = new StreamReader(m_stream, Encoding.GetEncoding("gb2312"));
                StringBuilder m_strb = new StringBuilder();
                string tmpstr;
                while ((tmpstr = m_reader.ReadLine()) != null)
                {
                    m_strb.Append(tmpstr + "\r\n");
                }
                templet = m_strb.ToString();
            }
            else
            {
                FileStream aFile;
                try
                {
                    aFile = new FileStream(@filePath, FileMode.Open, FileAccess.Read);
                }
                catch
                {
                    return "";
                }
                StreamReader sr = new StreamReader(aFile, System.Text.Encoding.GetEncoding("gb2312"));

                templet = sr.ReadToEnd();
                sr.Close();
            }
            return templet;
        }

        public static bool HasForbiddenWords(string input)
        {
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Htmlstring"></param>
        /// <returns></returns>
        public static string NoHTML(string Htmlstring)   
        {   
            //删除注释
            Htmlstring = Regex.Replace(Htmlstring, @"<!--\[if[\d\D]*?<!\[endif\]-->", "",  
                RegexOptions.IgnoreCase); 
            
            //删除脚本  
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "",  
                RegexOptions.IgnoreCase);   
            //删除HTML   
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", 
                RegexOptions.IgnoreCase); 
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "",  
                RegexOptions.IgnoreCase); 
            //Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);  
            //Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);  
            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"",  
                RegexOptions.IgnoreCase);  
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&",  
                RegexOptions.IgnoreCase);  
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", 
                RegexOptions.IgnoreCase);  
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", 
                RegexOptions.IgnoreCase);  
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", "   ", 
                RegexOptions.IgnoreCase);  
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", 
                RegexOptions.IgnoreCase);  
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2",  
                RegexOptions.IgnoreCase);  
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3",  
                RegexOptions.IgnoreCase);  
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9",  
                RegexOptions.IgnoreCase);  
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "",  
                RegexOptions.IgnoreCase);  
            Htmlstring.Replace("<", "");  
            Htmlstring.Replace(">", "");  
            Htmlstring.Replace("\r\n", "");  
            Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();  
            return Htmlstring;  
        }

        public static string SystemInputFilter(string input)
        {
            input = StringFilter(input);
            input = NoHTML(input);
            input = SQLData.SQLFilter(input);
            return input;
        }

      

    }
}