using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppMod.User;

namespace WebForMain
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
            GradeEntity = new USR_GradeMod();
            CustomerEntity = new USR_CustomerMod();

        }

        public USR_GradeMod GradeEntity;
        public USR_CustomerMod CustomerEntity;


    }
}
