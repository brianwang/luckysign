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
    public class REL_Famous_KeyWordBll
    {
        private readonly REL_Famous_KeyWordDal dal = new REL_Famous_KeyWordDal();
        private REL_Famous_KeyWordBll()
        {
        }
        private static REL_Famous_KeyWordBll _instance;
        public static REL_Famous_KeyWordBll GetInstance()
        {
            if (_instance == null)
            {
                _instance = new REL_Famous_KeyWordBll();
            }
            return _instance;
        }
        #region  基础成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(REL_Famous_KeyWordMod model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public void Update(REL_Famous_KeyWordMod model)
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

        public REL_Famous_KeyWordMod GetModel(int SysNo)
        {
            return dal.GetModel(SysNo);
        }
        #endregion  基础成员方法

        #region 扩展成员方法
        /// <summary>
        /// 获取某案例的所有关键字
        /// </summary>
        /// <param name="SysNo"></param>
        /// <returns></returns>
        public DataTable  GetFamousList(int SysNo)
        {
            DataTable table = new DataTable();
            using (SQLData data = new SQLData())
            {
                StringBuilder builder = new StringBuilder();
                builder.Append("select SYS_Famous_KeyWords.*,REL_Famous_KeyWord.SysNo as RelSysNo,Value from REL_Famous_KeyWord left join SYS_Famous_KeyWords on KeyWord_SysNo = SYS_Famous_KeyWords.SysNo where Famous_SysNo=").Append(SysNo).Append(" and DR=").Append((int)AppEnum.State.normal);
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
        /// <summary>
        /// 删除某案例的所有关键字
        /// </summary>
        /// <param name="SysNo"></param>
        public void RemoveAllKeyByFamous(int SysNo)
        {
            using (SQLData data = new SQLData())
            {
                StringBuilder builder = new StringBuilder();
                builder.Append("delete SYS_Famous_KeyWords where Famous_SysNo=").Append(SysNo);
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
        #endregion

    }
}
