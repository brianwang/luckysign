using System;
using System.Data;
using AppMod.CMS;
using AppDal.CMS;
using AppCmn;
using System.Collections.Generic;

namespace AppBll.CMS
{
    public class SYS_ArticleContentBll
    {
        private readonly SYS_ArticleContentDal dal = new SYS_ArticleContentDal();
        private SYS_ArticleContentBll()
        {
        }
        private static SYS_ArticleContentBll _instance;
        public static SYS_ArticleContentBll GetInstance()
        {
            if (_instance == null)
            {
                _instance = new SYS_ArticleContentBll();
            }
            return _instance;
        }
        #region  基础成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(SYS_ArticleContentMod model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public void UpDate(SYS_ArticleContentMod model)
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

        public SYS_ArticleContentMod GetModel(int SysNo)
        {
            return dal.GetModel(SysNo);
        }
        #endregion  基础成员方法

        #region 扩展成员方法
        public Dictionary<int, SYS_ArticleContentMod> GetContentByArticle(int ArticleSysno)
        {
            Dictionary<int, SYS_ArticleContentMod> ret = new Dictionary<int, SYS_ArticleContentMod>();
            DataTable m_dt = new DataTable();
            string strsql = "select * from SYS_ArticleContent where ArticleSysNo=" + ArticleSysno + " and DR=" + (int)AppEnum.State.normal + " order by Page asc";

            using (SQLData m_data = new SQLData())
            {
                try
                {
                    m_dt = m_data.CmdtoDataTable(strsql);
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
            for (int i = 0; i < m_dt.Rows.Count; i++)
            {
                SYS_ArticleContentMod m_tmp = new SYS_ArticleContentMod();
                m_tmp.ArticleSysNo = int.Parse(m_dt.Rows[i]["ArticleSysNo"].ToString());
                m_tmp.Context = m_dt.Rows[i]["Context"].ToString();
                m_tmp.DR = int.Parse(m_dt.Rows[i]["DR"].ToString());
                m_tmp.Page = int.Parse(m_dt.Rows[i]["Page"].ToString());
                m_tmp.SysNo = int.Parse(m_dt.Rows[i]["SysNo"].ToString());
                m_tmp.TS = DateTime.Parse(m_dt.Rows[i]["TS"].ToString());

                ret.Add(int.Parse(m_dt.Rows[i]["Page"].ToString()), m_tmp);
            }
            return ret;
        }

        #endregion 扩展成员方法
    }

}
