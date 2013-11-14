using System;
using System.Collections;
using System.Configuration;
using System.Xml.Serialization;

namespace AppCmn
{
    /// <summary>
    /// Summary description for AppConfig.
    /// </summary>
    public class AppConfig
    {
        private AppConfig()
        {

        }

        #region 系统参数
        public static string ConnectionString
        {
            get { return ConfigurationManager.AppSettings["ConnectionString"]; }
        }


        public static string ErrorLogFolder
        {
            get { return ConfigurationManager.AppSettings["ErrorLogFolder"]; }
        }

        public static string AdminSession
        {
            get { return ConfigurationManager.AppSettings["AdminSession"]; }
        }
        public static string CustomerSession
        {
            get { return ConfigurationManager.AppSettings["CustomerSession"]; }
        }
        public static string WaterMarkPath
        {
            get { return ConfigurationManager.AppSettings["WaterMarkPath"]; }
        }
        public static string RegisterEmailCheck
        {
            get { return ConfigurationManager.AppSettings["RegisterEmailCheck"]; }
        }
        #endregion



        #region URL地址
        public static string WebResourcesPath()
        {
             return ConfigurationManager.AppSettings["ImageFolderPath"]; 
        }
        public static string WebResourcesFolderPath()
        {
            return ConfigurationManager.AppSettings["WebResourcesFolderPath"];
        }
        public static string AdvFolderPath
        {
            get { return ConfigurationManager.AppSettings["AdvFolderPath"]; }
        }
        public static string HomeUrl()
        {
            return ConfigurationManager.AppSettings["HomeUrl"];
        }
        public static string PPLiveUrl()
        {
            return ConfigurationManager.AppSettings["PPLiveUrl"];
        }
        #endregion

        #region 占星排盘
        public static string AstrologPath()
        {
            return ConfigurationManager.AppSettings["AstrologPath"];
        }
        public static string AstroGraphicPath()
        {
            return ConfigurationManager.AppSettings["AstroGraphicPath"];
        }
        #endregion

        #region Apps
        public static string AnXin360Key()
        {
            return ConfigurationManager.AppSettings["AnXin360Key"];
        }

        public static string[] QQWeiBoAppID()
        {
            return ConfigurationManager.AppSettings["QQWeiBoAppID"].Split(new char[] { '|' });
        }

            public static string[] QQWeiBoAppSecret()
        {
            return ConfigurationManager.AppSettings["QQWeiBoAppSecret"].Split(new char[] {'|'});
        }
        #endregion

        #region Email
            public static bool IsSendEMail
            {
                get
                {
                    string dd = ConfigurationManager.AppSettings["IsSendEMail"];
                    if (dd == null || dd.ToLower() != "true")
                        return false;
                    else
                        return true;
                }
            }

            public static string MailCharset
            {
                get { return ConfigurationManager.AppSettings["MailCharset"]; }
            }

            public static string MailFrom
            {
                get { return ConfigurationManager.AppSettings["MailFrom"]; }
            }

            public static string MailFromName
            {
                get { return ConfigurationManager.AppSettings["MailFromName"]; }
            }

            public static string MailServer
            {
                get { return ConfigurationManager.AppSettings["MailServer"]; }
            }

            public static string MailUserName
            {
                get { return ConfigurationManager.AppSettings["MailUserName"]; }
            }

            public static string MailUserPassword
            {
                get { return ConfigurationManager.AppSettings["MailUserPassword"]; }
            }
        #endregion
    }
}
