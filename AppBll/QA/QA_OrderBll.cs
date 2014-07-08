using System;
using System.Data;
using AppMod.QA;
using AppDal.QA;
using AppCmn;
using System.Text;
using System.Transactions;
using AppBll.User;

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

        public void SetOrder(QA_OrderMod order,QA_AnswerMod answer)
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = TransactionManager.DefaultTimeout;

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, options))
            {
                int sysno = QA_AnswerBll.GetInstance().AddAnswer(answer);
                USR_CustomerBll.GetInstance().AddCount(answer.CustomerSysNo, 0, 0, 0, 0, 0, 0, 1, 0, 0);

                order.AnswerSysNo = sysno;
                Add(order);

                QA_QuestionMod m_qa = QA_QuestionBll.GetInstance().GetModel(order.QuestionSysNo);
                m_qa.OrderCount++;
                QA_QuestionBll.GetInstance().Update(m_qa);

                AppMod.User.USR_RecordMod m_record = new AppMod.User.USR_RecordMod();
                m_record.CustomerSysNo = order.CustomerSysNo;
                m_record.TargetSysNo = sysno;
                m_record.TS = DateTime.Now;
                m_record.Type = (int)AppEnum.ActionType.SetOrder;
                User.USR_RecordBll.GetInstance().Add(m_record);

                scope.Complete();
            }
        }

        #endregion
    }
}
