using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using XMS.Core;

using AppMod.User;
using AppDal.User;
using AppBll.User;

namespace WCFServiceForApp
{
    public class LsService : ILsService
    {
        public ReturnValue<USR_CustomerMod> UserLogin(string username, string password)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new BusinessException("用户名不能为空");
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new BusinessException("密码不能为空");
            }

            USR_CustomerMod m_user = USR_CustomerBll.GetInstance().CheckUser(username, password);
            if (m_user.SysNo != -999999)
            {
                return ReturnValue<USR_CustomerMod>.Get200OK(m_user);
            }
            else
            {
                throw new BusinessException("账号或密码错误，请重新输入！");
            }
        }
    }
}
