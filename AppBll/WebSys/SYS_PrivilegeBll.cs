using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppMod.WebSys;
using AppDal.WebSys;
using AppCmn;
using System.Data;

namespace AppBll.WebSys
{
    public class SYS_PrivilegeBll
    {
        private readonly SYS_PrivilegeDal dal = new SYS_PrivilegeDal();
        private SYS_PrivilegeBll()
        {
        }
        private static SYS_PrivilegeBll _instance;
        public static SYS_PrivilegeBll GetInstance()
        {
            if (_instance == null)
            {
                _instance = new SYS_PrivilegeBll();
            }
            return _instance;
        }
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(SYS_PrivilegeMod model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public void UpDate(SYS_PrivilegeMod model)
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

        public SYS_PrivilegeMod GetModel(int SysNo)
        {
            return dal.GetModel(SysNo);
        }
        #endregion  成员方法

        #region 扩展成员方法
        public void CopyPrivilege(int fromuser, int touser)
        {
            using (SQLData data = new SQLData())
            {
                StringBuilder builder = new StringBuilder();
                builder.Append(@"insert into REL_Admin_Privilege (Privilege_sysno,admin_sysno) select privilege_sysno,").Append(touser).Append(" where admin_sysno=").Append(fromuser).Append(" and dr=0");

                try
                {
                    data.CmdtoNone(builder.ToString());
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
        }

        public DataTable GetList()
        {
            DataTable m_dt = new DataTable();

            using (SQLData m_data = new SQLData())
            {
                m_dt = m_data.CmdtoDataTable("select * from SYS_Privilege");
            }
            return m_dt;
        }
        #endregion
    }

}
