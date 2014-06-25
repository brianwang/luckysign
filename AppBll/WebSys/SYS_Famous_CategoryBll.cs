using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppMod.WebSys;
using AppDal.WebSys;
using AppCmn;
namespace AppBll.WebSys
{
    public class SYS_Famous_CategoryBll
    {
        private readonly SYS_Famous_CategoryDal dal = new SYS_Famous_CategoryDal();
        private SYS_Famous_CategoryBll()
        {
        }
        private static SYS_Famous_CategoryBll _instance;
        public static SYS_Famous_CategoryBll GetInstance()
        {
            if (_instance == null)
            {
                _instance = new SYS_Famous_CategoryBll();
            }
            return _instance;
        }
        #region  基础成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(SYS_Famous_CategoryMod model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public void Update(SYS_Famous_CategoryMod model)
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

        public SYS_Famous_CategoryMod GetModel(int SysNo)
        {
            return dal.GetModel(SysNo);
        }
        #endregion  成员方法

        #region  扩展成员方法

        public DataTable GetList()
        {
            DataTable table = new DataTable();
            Dictionary<int, SYS_PrivilegeMod> dictionary = new Dictionary<int, SYS_PrivilegeMod>();
            using (SQLData data = new SQLData())
            {
                StringBuilder builder = new StringBuilder();
                builder.Append("select SysNo, [Name], ParentSysNo from SYS_Famous_Category where ParentSysNo=0").Append(" and DR=").Append((int)AppEnum.State.normal);
                try
                {
                    table = data.CmdtoDataTable(builder.ToString());
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
            return table;
        }
        #endregion
    }

}
