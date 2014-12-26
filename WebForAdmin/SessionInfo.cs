using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppMod.WebSys;

namespace WebForAdmin
{
    /// <summary>
    ///SessionInfo 的摘要说明
    /// </summary>
    public class SessionInfo
    {
        public SessionInfo()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
            PrivilegeDt = null;
            AdminEntity = null;

        }

        public Dictionary<int, SYS_PrivilegeMod> PrivilegeDt;
        public SYS_AdminMod AdminEntity;


    }
}
