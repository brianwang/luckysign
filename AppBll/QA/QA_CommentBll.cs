using System;
using System.Data;
using AppMod.QA;
using AppDal.QA;
using AppCmn;
using System.Text;
using System.Transactions;

namespace AppBll.QA
{
    public class QA_CommentBll
    {
        private readonly QA_CommentDal dal = new QA_CommentDal();
        private QA_CommentBll()
        {
        }
        private static QA_CommentBll _instance;
        public static QA_CommentBll GetInstance()
        {
            if (_instance == null)
            {
                _instance = new QA_CommentBll();
            }
            return _instance;
        }
        #region  基础成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(QA_CommentMod model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public void Update(QA_CommentMod model)
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

        public QA_CommentMod GetModel(int SysNo)
        {
            return dal.GetModel(SysNo);
        }
        #endregion  基础成员方法

        #region 扩展成员方法

        public DataTable GetListByAnswer(int answersysno)
        {
            DataTable m_dt = new DataTable();
            using (SQLData data = new SQLData())
            {
                StringBuilder builder = new StringBuilder();
                builder.Append(@"select QA_Comment.*,NickName,Photo from QA_Comment left join USR_Customer on CustomerSysNo=USR_Customer.SysNo where AnswerSysNo=").Append(answersysno).Append(" and QA_Comment.DR=").Append((int)AppEnum.State.normal).Append(" order by QA_Comment.SysNo");
                try
                {
                    m_dt =data.CmdtoDataTable(builder.ToString());
                }
                catch (Exception exception)
                {
                    return null;
                }
            }
            return m_dt;
        }

        public bool IfReplyed(int answersysno,int questsysno)
        {
            bool ret = false;
            QA_QuestionMod m_qa = QA_QuestionBll.GetInstance().GetModel(questsysno);
            QA_AnswerMod m_answer = QA_AnswerBll.GetInstance().GetModel(answersysno);
            DataTable m_dt = GetListByAnswer(answersysno);
            for (int i = 0; i < m_dt.Rows.Count;i++ )
            {
                if (m_dt.Rows[i]["CustomerSysNo"].ToString() == m_qa.CustomerSysNo.ToString())
                {
                    ret = true;
                    break;
                }
            }
            return ret;
        }

        public void AddComment(QA_CommentMod model)
        {
            bool isquest = false;
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = TransactionManager.DefaultTimeout;

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, options))
            {
                int sysno = Add(model);

                QA_QuestionMod m_qa = QA_QuestionBll.GetInstance().GetModel(model.QuestionSysNo);
                m_qa.ReplyCount++;
                m_qa.LastReplyUser = model.CustomerSysNo;
                m_qa.LastReplyTime = DateTime.Now;
                QA_QuestionBll.GetInstance().Update(m_qa);
                if (QA_CategoryBll.GetInstance().GetModel(m_qa.CateSysNo).TopSysNo == 1)
                {
                    isquest = true;
                }

                AppMod.User.USR_RecordMod m_record = new AppMod.User.USR_RecordMod();
                m_record.CustomerSysNo = model.CustomerSysNo;
                m_record.TargetSysNo = sysno;
                m_record.TS = DateTime.Now;
                m_record.Type = 63;
                User.USR_RecordBll.GetInstance().Add(m_record);

                if (model.CustomerSysNo == m_qa.CustomerSysNo )
                {
                    User.USR_CustomerBll.GetInstance().AddPoint(AppConst.ReplyPoint, model.CustomerSysNo);
                    User.USR_CustomerBll.GetInstance().AddExp(AppConst.ReplyExp, model.CustomerSysNo);
                    User.USR_CustomerBll.GetInstance().AddCount(model.CustomerSysNo, 0, 0, 0, 1, 0, 0);
                }
                else if (!isquest)
                {
                    User.USR_CustomerBll.GetInstance().AddCount(model.CustomerSysNo, 0, 0, 0, 0, 0, 1);
                }
                User.USR_CustomerBll.GetInstance().AddPoint(AppConst.CommentPoint, model.CustomerSysNo);
                User.USR_CustomerBll.GetInstance().AddExp(AppConst.CommentExp, model.CustomerSysNo);

                QA_AnswerMod m_answer = QA_AnswerBll.GetInstance().GetModel(model.AnswerSysNo);
                AppMod.User.USR_MessageMod m_notice = new AppMod.User.USR_MessageMod();
                m_notice.CustomerSysNo = m_answer.CustomerSysNo;
                if (model.CustomerSysNo == m_qa.CustomerSysNo)
                {
                    m_notice.Context = "";
                    m_notice.Title = AppConst.FeedbackReport.Replace("@url", AppConfig.HomeUrl() + "Quest/Question.aspx?id=" + m_qa.SysNo).Replace("@question", m_qa.Title);
                }
                else
                {
                    m_notice.Context = "";
                    m_notice.Title = AppConst.CommentReport.Replace("@url", AppConfig.HomeUrl() + "Quest/Question.aspx?id=" + m_qa.SysNo);
                }
                m_notice.DR = 0;
                m_notice.IsRead = 0;
                m_notice.TS = DateTime.Now;
                m_notice.Type = (int)AppEnum.MessageType.notice;
                User.USR_MessageBll.GetInstance().AddMessage(m_notice);
                scope.Complete();
            }
        }
            
        #endregion 扩展成员方法
    }

}
