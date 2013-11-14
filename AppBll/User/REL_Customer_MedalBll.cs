using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppMod.User;
using AppDal.User;
using AppCmn;
using System.Data;

namespace AppBll.User
{
    public class REL_Customer_MedalBll
    {
        private readonly REL_Customer_MedalDal dal = new REL_Customer_MedalDal();
        private REL_Customer_MedalBll()
        {
        }
        private static REL_Customer_MedalBll _instance;
        public static REL_Customer_MedalBll GetInstance()
        {
            if (_instance == null)
            {
                _instance = new REL_Customer_MedalBll();
            }
            return _instance;
        }
        #region  基础成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>

        public void Add(REL_Customer_MedalMod model)
        {
            dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public void UpDate(REL_Customer_MedalMod model)
        {
            dal.UpDate(model);
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

        public REL_Customer_MedalMod GetModel(int SysNo)
        {
            return dal.GetModel(SysNo);
        }
        #endregion  基础成员方法

        #region 扩展成员方法
        public DataTable GetMedalByCustomer(int UserSysno, int type)
        {
            DataTable m_dt = new DataTable();

            #region  设置参数
            string sql = @" select REL_Customer_Medal.*,MedalName,type,Detail" +
            " from REL_Customer_Medal left join USR_Medal on MedalSysNo=USR_Medal.SysNo" +
            " where CustomerSysNo=" + UserSysno + " and REL_Customer_Medal.DR=" + (int)AppEnum.State.normal + " and USR_Medal.DR=" + (int)AppEnum.State.normal;
            if (type != 0 && type != AppConst.IntNull)
            {
                sql += " and type=" + type;
            }
            sql += " order by REL_Customer_Medal.sysno desc";
            #endregion

            using (SQLData m_data = new SQLData())
            {
                m_dt = m_data.CmdtoDataTable(sql);
            }
            return m_dt;
        }

        public bool HasMedal(int usersysno, int medalsysno)
        {
            bool ret = false;
            using (SQLData data = new SQLData())
            {
                StringBuilder builder = new StringBuilder();
                builder.Append("select * from REL_Customer_Medal where customersysno=").Append(usersysno).Append(" and medalsysno=").Append(medalsysno);
                try
                {
                    if (data.CmdtoDataTable(builder.ToString()).Rows.Count > 0)
                    {
                        ret = true;
                    }
                }
                catch (Exception exception)
                {
                    //throw exception;
                }
            }

            return ret;
        }
        #endregion
    }

}
