using System;
using System.Data;
using AppMod.WebSys;
using AppDal.WebSys;
using AppCmn;
using System.Net;
using System.IO;
using System.Text;
using System.Web;

namespace AppBll.WebSys
{
    public class SYS_SMSBll
    {
        private readonly SYS_SMSDal dal = new SYS_SMSDal();
        private static SYS_SMSBll _instance;
        public static SYS_SMSBll GetInstance()
        {
            if (_instance == null)
            { _instance = new SYS_SMSBll(); }
            return _instance;
        }
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(SYS_SMSMod model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public void Update(SYS_SMSMod model)
        {
            dal.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>

        public void Delete(int SysNo)
        {
            dal.Delete(SysNo);
        }
        /// <summary>
        ///  得到一个对象实体
        /// </summary>

        public SYS_SMSMod GetModel(int SysNo)
        {
            return dal.GetModel(SysNo);
        }
        #endregion  成员方法

        #region 扩展成员方法

        public void SendSMS(SYS_SMSMod m_sms)
        {
            string strRet = null;
            string url = @"http://utf8.sms.webchinese.cn/?Uid=ssqian&Key=be1bc83c52a767a15d1d&smsMob=" + m_sms.PhoneNum + @"&smsText=" + HttpUtility.UrlEncode(m_sms.Content);
            string targeturl = url.Trim().ToString();
            try
            {
                HttpWebRequest hr = (HttpWebRequest)WebRequest.Create(targeturl);
                hr.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1)";
                hr.Method = "GET";
                hr.Timeout = 30 * 60 * 1000;
                WebResponse hs = hr.GetResponse();
                Stream sr = hs.GetResponseStream();
                StreamReader ser = new StreamReader(sr, Encoding.UTF8);
                strRet = ser.ReadToEnd();
            }
            catch (Exception ex)
            {
                strRet = null;
            }
            if (strRet != null)
            {
                if (int.Parse(strRet) > 0)
                {
                    m_sms.Status = (int)AppEnum.SMSStatus.sended;
                }
                else
                {
                    m_sms.Status = (int)AppEnum.SMSStatus.failed;
                }
                m_sms.ReturnCode = int.Parse(strRet);
                m_sms.SendTime = DateTime.Now;
            }
            else
            {
                m_sms.Status = (int)AppEnum.SMSStatus.failed;
            }
            Update(m_sms);
        }

        #endregion
    }
}
