using System;
using System.Data;
using AppMod.User;
using AppDal.User;
using AppCmn;

namespace AppBll.User
{
    public class USR_ActionBll
    {
        private readonly USR_ActionDal dal = new USR_ActionDal();
        private USR_ActionBll()
        {
        }
        private static USR_ActionBll _instance;
        public static USR_ActionBll GetInstance()
        {
            if (_instance == null)
            {
                _instance = new USR_ActionBll();
            }
            return _instance;
        }
        #region  基础成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>

        public void Add(USR_ActionMod model)
        {
            dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public void Update(USR_ActionMod model)
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

        public USR_ActionMod GetModel(int SysNo)
        {
            return dal.GetModel(SysNo);
        }
        #endregion  基础成员方法

        #region  扩展成员方法
        /// <summary>
        /// 获取用户关注者的动态
        /// </summary>
        /// <param name="UserSysno"></param>
        /// <param name="pagesize"></param>
        /// <param name="pageindex"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public DataTable GetUserAction(int UserSysno, int pagesize, int pageindex, ref int total)
        {
            DataTable m_dt = new DataTable();
            string columns = "";
            string tables = "";
            string where = "";
            string order = "USR_Action.SysNo desc";

            #region  设置参数
            columns = @"USR_Action.[SysNo]
                      ,USR_Action.[CustomerSysNo]
                      ,USR_Action.[xml]
                      ,USR_Action.[Type]
                      ,USR_Action.[TS]
                      ,[NickName]
                      ,[Photo]
                      ,[Credit]
                      ,[Point]";
            tables = "USR_Action left join USR_Customer on CustomerSysNo=USR_Customer.SysNo";
            where = "USR_Action.CustomerSysNo in (select targetsysno from BLG_Attention where CustomerSysNo=" + UserSysno + " and BLG_Attention.dr=" + (int)AppEnum.State.normal + " aaa) and USR_Action.dr=" + (int)AppEnum.State.normal + " and USR_Customer.dr=" + (int)AppEnum.State.normal;

            #endregion

            using (SQLData m_data = new SQLData())
            {
                m_data.AddParameter("SelectList", columns);
                m_data.AddParameter("TableSource", tables);
                m_data.AddParameter("SearchCondition", where);
                m_data.AddParameter("OrderExpression", order);
                m_data.AddParameter("PageIndex", pageindex);
                m_data.AddParameter("pagesize", pagesize);
                DataSet m_ds = m_data.SPtoDataSet("GetRecordFromPage");
                if (m_ds.Tables.Count == 2)
                {
                    m_dt = m_ds.Tables[0];
                    total = int.Parse(m_ds.Tables[1].Rows[0][0].ToString());
                }
            }
            return m_dt;
        }


        public string  SetXML(string UserID,int UserSysNo,string Title,string Content,DateTime time,int TargetSysNo,int Type)
        {
            return "";
        }
        #endregion  扩展成员方法
    }

}
