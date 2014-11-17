using System;
using System.Data;
using AppMod.Research;
using AppDal.Research;
using AppCmn;
using System.Text;
namespace AppBll.Research
{
    public class RSH_BaziConditionBll
    {
        private readonly RSH_BaziConditionDal dal = new RSH_BaziConditionDal();
        private static RSH_BaziConditionBll _instance;
        public static RSH_BaziConditionBll GetInstance()
        {
            if (_instance == null)
            { _instance = new RSH_BaziConditionBll(); }
            return _instance;
        }
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(RSH_BaziConditionMod model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public void Update(RSH_BaziConditionMod model)
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

        public RSH_BaziConditionMod GetModel(int SysNo)
        {
            return dal.GetModel(SysNo);
        }
        #endregion  成员方法

        #region 扩展成员方法

        public DataTable GetListByLogic(int sysno)
        {
            DataTable m_dt = new DataTable();
            using (SQLData data = new SQLData())
            {
                StringBuilder builder = new StringBuilder();
                builder.Append(@"select * from RSH_BaziCondition where LogicSysNo=").Append(sysno).Append(" order by sysno asc");
                try
                {
                    m_dt = data.CmdtoDataTable(builder.ToString());
                }
                catch (Exception exception)
                {
                    return null;
                }
            }
            return m_dt;
        }

        public void DeleteConditionsByLogic(int sysno)
        {
             using (SQLData data = new SQLData())
            {
                StringBuilder builder = new StringBuilder();
                builder.Append(@"delete RSH_BaziCondition where LogicSysNo=").Append(sysno);
                try
                {
                    data.CmdtoNone(builder.ToString());
                }
                catch (Exception exception)
                {
                    
                }
            }
        }

        #endregion
    }
}
