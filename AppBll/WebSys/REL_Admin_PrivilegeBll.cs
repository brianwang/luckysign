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
    public class REL_Admin_PrivilegeBll
    {
        private readonly REL_Admin_PrivilegeDal dal = new REL_Admin_PrivilegeDal();
        private REL_Admin_PrivilegeBll()
        {
        }
        private static REL_Admin_PrivilegeBll _instance;
        public static REL_Admin_PrivilegeBll GetInstance()
        {
            if (_instance == null)
            {
                _instance = new REL_Admin_PrivilegeBll();
            }
            return _instance;
        }
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(REL_Admin_PrivilegeMod model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public void Update(REL_Admin_PrivilegeMod model)
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

        public REL_Admin_PrivilegeMod GetModel(int SysNo)
        {
            return dal.GetModel(SysNo);
        }
        #endregion  成员方法

        #region 扩展成员方法
        public DataTable GetListByAdmin(int sysno)
        {
            DataTable m_dt = new DataTable();

            using (SQLData m_data = new SQLData())
            {
                m_dt = m_data.CmdtoDataTable("select * from REL_Admin_Privilege where Admin_SysNo=" + sysno);
            }
            return m_dt;
        }
        #endregion
    }

}
