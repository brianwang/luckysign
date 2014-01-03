using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using XMS.Core;
using AppCmn;
using AppMod.User;
using AppDal.User;
using AppBll.User;

namespace WCFServiceForApp
{
    public class CustomerService : ICustomerService
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

        public ReturnValue<USR_CustomerMod> CheckUserName(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new BusinessException("用户名不能为空");
            }

            USR_CustomerMod m_user = USR_CustomerBll.GetInstance().CheckUser(username);
            if (m_user.SysNo != -999999)
            {
                return ReturnValue<USR_CustomerMod>.Get200OK(m_user);
            }
            else
            {
                throw new BusinessException("用户不存在！");
            }
        }

        public ReturnValue<USR_CustomerMod> CheckNickName(string nickname)
        {
            if (string.IsNullOrEmpty(nickname))
            {
                throw new BusinessException("昵称不能为空");
            }

            USR_CustomerMod m_user = USR_CustomerBll.GetInstance().CheckNickName(nickname);
            if (m_user.SysNo != -999999)
            {
                return ReturnValue<USR_CustomerMod>.Get200OK(m_user);
            }
            else
            {
                throw new BusinessException("用户不存在！");
            }
        }

        public ReturnValue<USR_CustomerMod> CheckPhone(string phone)
        {
            if (string.IsNullOrEmpty(phone))
            {
                throw new BusinessException("手机号不能为空");
            }

            USR_CustomerMod m_user = USR_CustomerBll.GetInstance().CheckPhone(phone);
            if (m_user.SysNo != -999999)
            {
                return ReturnValue<USR_CustomerMod>.Get200OK(m_user);
            }
            else
            {
                throw new BusinessException("用户不存在！");
            }
        }

        public ReturnValue<bool> FindPass(string email, string phone)
        {
            if (string.IsNullOrEmpty(phone))
            {
                throw new BusinessException("手机号不能为空");
            }

            USR_CustomerMod m_user = USR_CustomerBll.GetInstance().CheckPhone(phone);
            if (m_user.SysNo != -999999)
            {
                return ReturnValue<bool>.Get200OK(true);
            }
            else
            {
                throw new BusinessException("用户不存在！");
            }
        }

        public ReturnValue<USR_CustomerMod> Register(string email, string password, string phone, string nickname, string fatetype)
        {
            #region 验证输入
            if (email.Trim() != "")
            {
                USR_CustomerMod m_userrr = USR_CustomerBll.GetInstance().CheckUser(email);
                if (m_userrr.SysNo != AppConst.IntNull)
                {
                    throw new BusinessException("该邮箱已注册，请重新输入!");
                }
            }
            else if (phone.Trim() != "")
            {
                if (!Util.IsCellNumber(phone))
                {
                    throw new BusinessException("手机号格式有误，请重新输入!");
                }
                USR_CustomerMod m_userrr = USR_CustomerBll.GetInstance().CheckPhone(phone);
                if (m_userrr.SysNo != AppConst.IntNull)
                {
                    throw new BusinessException("该手机号已注册，请重新输入!");
                }
            }
            if (CommonTools.HasForbiddenWords(nickname))
            {
                throw new BusinessException("您的昵称中有违禁字符,请重新输入!");
            }
            USR_CustomerMod m_userr = USR_CustomerBll.GetInstance().CheckNickName(nickname);
            if (m_userr.SysNo != AppConst.IntNull)
            {
                throw new BusinessException("该昵称已被占用，请尝试使用其他昵称!");
            }
            try
            {
                int fate = int.Parse(fatetype);
            }
            catch
            {
                throw new BusinessException("该昵称已被占用，请尝试使用其他昵称!");
            }

            #endregion

            #region 保存数据
            USR_CustomerMod m_user = new USR_CustomerMod();
            try
            {
                m_user.Email = email.Trim();
                m_user.Phone = phone.Trim();
                m_user.FateType = int.Parse(fatetype);
                m_user.GradeSysNo = AppConst.OriginalGrade; ;
                m_user.NickName = nickname.Trim();
                m_user.Password = password.Trim();
                m_user.RegTime = DateTime.Now;
                m_user.Point = AppConst.OriginalPoint;
                m_user.Photo = AppConst.OriginalPhoto;
                m_user.LastLoginTime = DateTime.Now;
                if (AppConfig.RegisterEmailCheck.ToLower() == "true")
                {
                    m_user.Status = (int)AppEnum.State.prepare;
                }
                else
                {
                    m_user.Status = (int)AppEnum.State.normal;
                }

                m_user.Credit = 0;
                m_user.birth = AppConst.DateTimeNull;
                m_user.IsShowBirth = 1;
                m_user.IsStar = 0;
                m_user.BestAnswer = 0;
                m_user.TotalAnswer = 0;
                m_user.TotalQuest = 0;
                m_user.HomeTown = AppConst.IntNull;
                m_user.Intro = AppConst.OriginalIntro;
                m_user.Signature = AppConst.OriginalSign;
                m_user.Exp = 0;
                m_user.TotalReply = 0;
                m_user.HasNewInfo = 0;

                m_user.SysNo = USR_CustomerBll.GetInstance().Add(m_user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion

            #region 发送验证邮件
            if (AppConfig.RegisterEmailCheck.ToLower() == "true")
            {

            }
            #endregion
            if (m_user.SysNo != -999999)
            {
                return ReturnValue<USR_CustomerMod>.Get200OK(m_user);
            }
            else
            {
                throw new Exception();
            }

        }
    }
}
