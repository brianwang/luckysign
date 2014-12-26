using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using AppMod.WebSys;
using AppDal.WebSys;
using AppCmn;

namespace AppBll.WebSys
{
    public class SYS_Famous_CommentBll
    {
        private readonly SYS_Famous_CommentDal dal = new SYS_Famous_CommentDal();
        private SYS_Famous_CommentBll()
        {
        }
        private static SYS_Famous_CommentBll _instance;
        public static SYS_Famous_CommentBll GetInstance()
        {
            if (_instance == null)
            {
                _instance = new SYS_Famous_CommentBll();
            }
            return _instance;
        }
        #region  基础成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(SYS_Famous_CommentMod model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public void Update(SYS_Famous_CommentMod model)
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

        public SYS_Famous_CommentMod GetModel(int SysNo)
        {
            return dal.GetModel(SysNo);
        }
        #endregion  成员方法

        #region 扩展成员方法

        public DataTable GetListByFamousSysNo(int pageindex,int pagesize,int famous,ref int total)
        {
            DataTable m_dt = new DataTable();
            string columns = "";
            string tables = "";
            string where = "";
            string order = "";

            #region  设置参数
            columns = @"SYS_Famous_Comment.[SysNo]
                        ,[FamousSysNo]
                        ,[CustomerSysNo]
                        ,[Context]
                        ,SYS_Famous_Comment.[DR]
                        ,SYS_Famous_Comment.[TS]
                        ,USR_Customer.[Photo]
                        ,USR_Customer.[NickName]";
            tables = "SYS_Famous_Comment left join USR_Customer on [CustomerSysNo] = USR_Customer.SysNo";
            order = "SYS_Famous_Comment.SysNo desc";
            where = "FamousSysNo=" + famous + " and SYS_Famous_Comment.dr=" + (int)AppEnum.State.normal;
            
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

        #endregion
    }

}
