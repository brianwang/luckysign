using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppMod.Apps;
using AppDal.Apps;
using AppCmn;
using System.Data;

namespace AppBll.Apps
{
    public class AdvTopicContentBll
    {
        private readonly AdvTopicContentDal dal = new AdvTopicContentDal();
        private static AdvTopicContentBll _instance;
        public static AdvTopicContentBll GetInstance()
        {
            if (_instance == null)
            {
                _instance = new AdvTopicContentBll();
            }
            return _instance;
        }
        #region  基础成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(AdvTopicContentMod model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public void Update(AdvTopicContentMod model)
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

        public AdvTopicContentMod GetModel(int SysNo)
        {
            return dal.GetModel(SysNo);
        }
        #endregion  成员方法

        #region 扩展成员方法
        public DataTable GetListByTopic(int SysNo)
        {
            DataTable table = new DataTable();
            using (SQLData data = new SQLData())
            {
                StringBuilder builder = new StringBuilder();
                builder.Append(@"select * from [AdvTopicContent] where TopicSysNo=" + SysNo);

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
