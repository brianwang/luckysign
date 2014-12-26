using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using AppCmn;
using WebMonitor;
using AppBll.Apps;
using AppMod.Apps;
using System.Data;

namespace WebForApps.AnXin360
{
    /// <summary>
    /// GetTopic 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class GetTopic : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        /// <summary>
        /// 返回格式  sysno|topic
        /// </summary>
        /// <param name="PhoneNum"></param>
        /// <param name="TimeStamp"></param>
        /// <param name="sign"></param>
        /// <returns></returns>
        [WebMethod]
        public string GetTopicByPhone(string PhoneNum,string TimeStamp,string sign)
        {
            if (CommonTools.md5(PhoneNum + TimeStamp + AppConfig.AnXin360Key(), 32) == sign.ToLower())
            {
                try
                {
                    return SearchTopic(PhoneNum);
                }
                catch(Exception ex)
                {
                    LogManagement.getInstance().WriteException(ex, "AnXin360App", "", "通过手机号获取推广主题");
                    return "Service Error";
                }
            }
            else
            {
                return "Wrong Key";
            }
        }


        private string SearchTopic(string PhoneNum)
        {
            string ret = "";
            AdvUserMod m_user = AdvUserBll.GetInstance().GetModel(PhoneNum);
            if (m_user.SysNo == AppConst.IntNull)//该手机号未发送过主题
            {
                m_user.CellPhone = PhoneNum;
                m_user.DR = (int)AppEnum.State.normal;
                m_user.TS = DateTime.Now;
                m_user.SysNo = AdvUserBll.GetInstance().Add(m_user);

                DataTable m_dt = AdvTopicBll.GetInstance().GetTopicList();
                int ran = CommonTools.ThrowRandom(0, m_dt.Rows.Count - 1);
                ret = m_dt.Rows[ran]["Title"].ToString();

                TopicSendRecordMod m_record = new TopicSendRecordMod();
                m_record.IsReturn = (int)AppEnum.BOOL.False;
                m_record.TopicSysNo = int.Parse(m_dt.Rows[ran]["SysNo"].ToString());
                m_record.UserSysNo = m_user.SysNo;
                m_record.TS = DateTime.Now;
                TopicSendRecordBll.GetInstance().Add(m_record);
            }
            else//该手机号已发送过主题
            {
                DataTable m_dt = TopicSendRecordBll.GetInstance().GetRecentRecordByUser(m_user.SysNo);
                DataTable m_total = AdvTopicBll.GetInstance().GetTopicList().Copy();

                if (m_dt.Rows.Count < m_total.Rows.Count)//还有没有给该用户发送过的主题
                {
                    int choise = 0;
                    string returned = "|";

                    DataTable m_return = TopicSendRecordBll.GetInstance().GetReturnRecordByUser(m_user.SysNo);
                    for (int i = 0; i < m_return.Rows.Count; i++)
                    {
                        returned += m_return.Rows[i]["Group"].ToString() + "|";
                    }

                    for (int i = 0; i < m_total.Rows.Count; i++)
                    {
                        bool exsit = false;
                        for (int j = 0; j < m_dt.Rows.Count; j++)
                        {
                            if (m_dt.Rows[j]["TopicSysNo"].ToString() == m_total.Rows[i]["SysNo"].ToString())
                            {
                                exsit = true;
                                break;
                            }
                        }
                        if (exsit)
                        {
                            continue;
                        }
                        else
                        {
                            choise = i;
                            if (returned.Contains("|" + m_total.Rows[i]["Group"].ToString() + "|"))
                            {
                                break;//如果有之前该用户点击进入过的同类型内容直接选中推送
                            }
                        }
                    }

                    ret = m_total.Rows[choise]["Title"].ToString();

                    TopicSendRecordMod m_record = new TopicSendRecordMod();
                    m_record.IsReturn = (int)AppEnum.BOOL.False;
                    m_record.TopicSysNo = int.Parse(m_total.Rows[choise]["SysNo"].ToString());
                    m_record.UserSysNo = m_user.SysNo;
                    m_record.TS = DateTime.Now;
                    TopicSendRecordBll.GetInstance().Add(m_record);
                }
                else//所有主题都给该用户发送过了
                {
                    ret = m_dt.Rows[0]["Title"].ToString();//可优化

                    TopicSendRecordMod m_record = new TopicSendRecordMod();
                    m_record.IsReturn = (int)AppEnum.BOOL.False;
                    m_record.TopicSysNo = int.Parse(m_dt.Rows[0]["SysNo"].ToString());
                    m_record.UserSysNo = m_user.SysNo;
                    m_record.TS = DateTime.Now;
                    TopicSendRecordBll.GetInstance().Add(m_record);
                }
            }
            return ret;
        }
    }
}
