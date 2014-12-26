using System;
using System.Data;
using System.Web.Script.Services; 
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using AppBll.WebSys;
using AppMod.WebSys;
using AppCmn;

    /// <summary>
    /// SearchKeys 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
     [System.Web.Script.Services.ScriptService]
    public class SearchKeys : System.Web.Services.WebService
    {
        public SearchKeys()
        { }
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public string[] GetCloserKeys(string prefixText, int count)
        {
            string[] ret;
            DataTable m_dt = SYS_Famous_KeyWordsBll.GetInstance().GetCloserKeys(prefixText, count);
            ret = new string[m_dt.Rows.Count];
            for (int i = 0; i < m_dt.Rows.Count; i++)
            {
                ret[i] = m_dt.Rows[i]["KeyWords"].ToString();
            }
            return ret;
        }
    }

