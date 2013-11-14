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
    public class TopicSendRecordBll
    {
        private readonly TopicSendRecordDal dal = new TopicSendRecordDal();
        private static TopicSendRecordBll _instance;
        public static TopicSendRecordBll GetInstance()
        {
            if (_instance == null)
            {
                _instance = new TopicSendRecordBll();
            }
            return _instance;
        }
        #region  基础成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(TopicSendRecordMod model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public void UpDate(TopicSendRecordMod model)
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

        public TopicSendRecordMod GetModel(int SysNo)
        {
            return dal.GetModel(SysNo);
        }
        #endregion  基础成员方法

        #region  扩展成员方法
        public DataTable GetRecordByUser(int SysNo)
        {
            DataTable table = new DataTable();
            using (SQLData data = new SQLData())
            {
                StringBuilder builder = new StringBuilder();
                builder.Append(@"select TopicSendRecord.*,AdvTopic.Group from [TopicSendRecord] left join AdvTopic on TopicSysNo = AdvTopic.SysNo where UserSysNo=" + SysNo + " and AdvTopic.dr=").Append((int)AppEnum.State.normal);

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


        public DataTable GetRecentRecordByUser(int SysNo)
        {
            DataTable table = new DataTable();
            using (SQLData data = new SQLData())
            {
                StringBuilder builder = new StringBuilder();
                builder.Append(@"select T.*,AdvTopic.Group from (max(TS) as LastTime, TopicSysNo, from [TopicSendRecord] where UserSysNo=" + SysNo + " group by TopicSysNo) as T left join AdvTopic on T.TopicSysNo = AdvTopic.SysNo where AdvTopic.dr=").Append((int)AppEnum.State.normal).Append(" order by LastTime desc");

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

        public DataTable GetReturnRecordByUser(int SysNo)
        {
            DataTable table = new DataTable();
            using (SQLData data = new SQLData())
            {
                StringBuilder builder = new StringBuilder();
                builder.Append(@"select TopicSendRecord.*,AdvTopic.Group from [TopicSendRecord] left join AdvTopic on TopicSysNo = AdvTopic.SysNo where UserSysNo=" + SysNo + " and IsReturn = "+(int)AppEnum.BOOL.True+" and AdvTopic.dr=").Append((int)AppEnum.State.normal);

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
