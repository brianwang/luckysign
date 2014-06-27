using System;
using System.Data;
using AppMod.QA;
using AppDal.QA;
using AppCmn;
using System.Text;

namespace AppBll.QA
{
    public class QA_OrderBll
    {
        private readonly QA_OrderDal dal = new QA_OrderDal();
        private static QA_OrderBll _instance;
        public static QA_OrderBll GetInstance()
        {
            if (_instance == null)
            { _instance = new QA_OrderBll(); }
            return _instance;
        }
        #region  基础成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(QA_OrderMod model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public void Update(QA_OrderMod model)
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

        public QA_OrderMod GetModel(int SysNo)
        {
            return dal.GetModel(SysNo);
        }
        #endregion  成员方法

        #region 扩展成员方法

        public DataTable GetListByQuest(int SysNo)
        {
            DataTable tables = new DataTable();
            using (SQLData data = new SQLData())
            {
                StringBuilder builder = new StringBuilder();
                builder.Append(@"SELECT [QA_Order].[SysNo]
      ,[AnswerSysNo]
      ,[QuestionSysNo]
      ,[CustomerSysNo]
      ,[Price]
      ,[QA_Order].[Status]
      ,[QA_Order].[TS]
      ,[Words]
      ,[Description]
      ,[Score]
      ,[Trial]
      ,NickName
      ,photo
  FROM [QA_Order] left join USR_Customer on CustomerSysNo=USR_Customer.SysNo where status=").Append((int)AppEnum.State.normal).Append(" and QuestionSysNo=").Append(SysNo);

                try
                {
                    tables = data.CmdtoDataTable(builder.ToString());
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
            return tables;
        }

        #endregion
    }
}
