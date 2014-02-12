using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using XMS.Core;
using AppCmn;
using AppBll.User;
using AppBll.QA;
using AppBll.Fate;
using System.IO;
using System.Configuration;
using AppMod.QA;
using AppMod.User;
using AppMod.Fate;
using System.Data;

namespace WebServiceForApp
{
    public class QAService : IQAService
    {
        public ReturnValue<List<QA_CategoryMod>> GetCates(int parent)
        {
            DataTable m_dt = QA_CategoryBll.GetInstance().GetCates(parent);
            if (m_dt == null || m_dt.Rows.Count == 0)
            {
                throw new BusinessException("该分类下无子分类");
            }
            List<QA_CategoryMod> ret = new List<QA_CategoryMod>();
            for (int i = 0; i < m_dt.Rows.Count; i++)
            {
                QA_CategoryMod tmp_cate = MapQA_Category(m_dt.Rows[i]);
                ret.Add(tmp_cate);
            }
            return ReturnValue<List<QA_CategoryMod>>.Get200OK(ret);
        }

        public ReturnValue<List<USR_CustomerMaintain>> GetStarsList(int catesysno)
        {
            DataTable m_dt = REL_Customer_CategoryBll.GetInstance().GetListByCate(catesysno,(int)AppEnum.CategoryType.QA);
            if (m_dt == null || m_dt.Rows.Count == 0)
            {
                throw new BusinessException("该分类下无版主");
            }
            List<USR_CustomerMaintain> ret = new List<USR_CustomerMaintain>();
            CustomerService tmpsvr = new CustomerService();
            for (int i = 0; i < m_dt.Rows.Count; i++)
            {
                USR_CustomerMaintain tmp_star = tmpsvr.MapUSR_CustomerMaintain(m_dt.Rows[i]);
                ret.Add(tmp_star);
            }
            return ReturnValue<List<USR_CustomerMaintain>>.Get200OK(ret);
        }

        public ReturnValue<List<QA_QuestionShowMini>> GetQuestionList(int pagesize, int pageindex, string key, int cate, string orderby)
        {
            int total = 0;
            DataTable m_dt = QA_QuestionBll.GetInstance().GetList(pagesize, pageindex,key,cate,orderby,ref total);
            if (m_dt == null || m_dt.Rows.Count == 0)
            {
                throw new BusinessException("没有符合条件的数据项");
            }
            List<QA_QuestionShowMini> ret = new List<QA_QuestionShowMini>();
            for (int i = 0; i < m_dt.Rows.Count; i++)
            {
                QA_QuestionShowMini tmp_quest = MapQA_QuestionShowMini(m_dt.Rows[i]);
                ret.Add(tmp_quest);
            }
            return ReturnValue<List<QA_QuestionShowMini>>.Get200OK(ret);
        }

        public ReturnValue<QA_QuestionShow> GetQuestion(int sysno)
        {
            QA_QuestionShow ret = (QA_QuestionShow)QA_QuestionBll.GetInstance().GetModel(sysno);

            ret.Customer = (USR_CustomerMaintain)USR_CustomerBll.GetInstance().GetModel(ret.CustomerSysNo);
            ret.Chart = QA_QuestionBll.GetInstance().GetChartByQuest(ret.SysNo);
            return ReturnValue<QA_QuestionShow>.Get200OK(ret);
        }

        public ReturnValue<List<QA_AnswerShow>> GetAnswerByQuest(int pagesize, int pageindex, int sysno)
        {
            int total = 0;
            DataTable m_dt = QA_AnswerBll.GetInstance().GetListByQuest(pagesize, pageindex, sysno, ref total);
            if (m_dt == null || m_dt.Rows.Count == 0)
            {
                throw new BusinessException("没有符合条件的数据项");
            }
            List<QA_AnswerShow> ret = new List<QA_AnswerShow>();
            for (int i = 0; i < m_dt.Rows.Count; i++)
            {
                QA_AnswerShow tmp_answer = MapQA_AnswerShow(m_dt.Rows[i]);
                tmp_answer.Customer = (USR_CustomerMaintain)USR_CustomerBll.GetInstance().GetModel(tmp_answer.CustomerSysNo);
                DataTable tmp_dt = QA_CommentBll.GetInstance().GetListByAnswer(tmp_answer.SysNo);
                if (tmp_dt != null && tmp_dt.Rows.Count > 0)
                {
                    List<QA_CommentShow> commentlist = new List<QA_CommentShow>();
                    for (int j = 0; j < m_dt.Rows.Count&&j<=3; j++)
                    {
                        QA_CommentShow tmp_comment = MapQA_CommentShow(m_dt.Rows[i]);
                        commentlist.Add(tmp_comment);
                    }
                    tmp_answer.TopComments = commentlist;
                    if (m_dt.Rows.Count > 3)
                    {
                        tmp_answer.HasMoreComment = true;
                    }
                    else
                    {
                        tmp_answer.HasMoreComment = false;
                    }
                }
                ret.Add(tmp_answer);
            }
            return ReturnValue<List<QA_AnswerShow>>.Get200OK(ret);
        }

        public ReturnValue<List<QA_CommentShow>> GetCommentByAnswer(int sysno)
        {
            DataTable m_dt = QA_CommentBll.GetInstance().GetListByAnswer(sysno);
            if (m_dt == null || m_dt.Rows.Count == 0)
            {
                throw new BusinessException("没有符合条件的数据项");
            }
            List<QA_CommentShow> ret = new List<QA_CommentShow>();
            for (int i = 0; i < m_dt.Rows.Count; i++)
            {
                QA_CommentShow tmp_comment = MapQA_CommentShow(m_dt.Rows[i]);
                ret.Add(tmp_comment);
            }
            return ReturnValue<List<QA_CommentShow>>.Get200OK(ret);
        }


        #region map方法

        public QA_CategoryMod MapQA_Category(DataRow input)
        {
            QA_CategoryMod ret = new QA_CategoryMod();
            ret.DR = int.Parse(input["DR"].ToString());
            ret.Name = input["Name"].ToString();
            ret.ParentSysNo = int.Parse(input["ParentSysNo"].ToString());
            ret.SysNo = int.Parse(input["SysNo"].ToString());
            ret.TopSysNo = int.Parse(input["TopSysNo"].ToString());
            ret.TS = DateTime.Parse(input["TS"].ToString());
            return ret;
        }

        public QA_QuestionShowMini MapQA_QuestionShowMini(DataRow input)
        {
            QA_QuestionShowMini ret = new QA_QuestionShowMini();
            USR_CustomerMod m_customer = USR_CustomerBll.GetInstance().GetModel(int.Parse(input["CustomerSysNo"].ToString()));
            ret.Award = int.Parse(input["Award"].ToString());
            ret.CateSysNo = int.Parse(input["CateSysNo"].ToString());
            ret.Chart = FATE_ChartBll.GetInstance().GetModel(int.Parse(input["CateSysNo"].ToString()));
            ret.Context = input["Context"].ToString();
            ret.CustomerNickName = m_customer.NickName;
            ret.CustomerPhoto = m_customer.Photo;
            ret.CustomerSysNo = int.Parse(input["CustomerSysNo"].ToString());
            ret.DR = int.Parse(input["DR"].ToString());
            ret.EndTime = DateTime.Parse(input["EndTime"].ToString());
            ret.IsSecret = int.Parse(input["IsSecret"].ToString());
            ret.LastReplyTime = DateTime.Parse(input["LastReplyTime"].ToString());
            ret.LastReplyUser = int.Parse(input["LastReplyUser"].ToString());
            ret.ReadCount = int.Parse(input["ReadCount"].ToString());
            ret.ReplyCount = int.Parse(input["ReplyCount"].ToString());
            ret.SysNo = int.Parse(input["SysNo"].ToString());
            ret.Title = input["Title"].ToString();
            ret.TS = DateTime.Parse(input["TS"].ToString());

            return ret;
        }

        public QA_AnswerShow MapQA_AnswerShow(DataRow input)
        {
            QA_AnswerShow ret = new QA_AnswerShow();
            ret.Award = int.Parse(input["Award"].ToString());
            ret.Context = input["Context"].ToString();
            ret.CustomerSysNo = int.Parse(input["CustomerSysNo"].ToString());
            ret.DR = int.Parse(input["DR"].ToString());
            ret.Hate = int.Parse(input["Hate"].ToString());
            ret.Love = int.Parse(input["Love"].ToString());
            ret.QuestionSysNo = int.Parse(input["QuestionSysNo"].ToString());
            ret.SysNo = int.Parse(input["SysNo"].ToString());
            ret.Title = input["Title"].ToString();
            ret.TS = DateTime.Parse(input["TS"].ToString());

            return ret;
        }

        public QA_CommentShow MapQA_CommentShow(DataRow input)
        {
            QA_CommentShow ret = new QA_CommentShow();
            ret.AnswerSysNo = int.Parse(input["AnswerSysNo"].ToString());
            ret.Context = input["Context"].ToString();
            ret.CustomerSysNo = int.Parse(input["CustomerSysNo"].ToString());
            ret.DR = int.Parse(input["DR"].ToString());
            ret.QuestionSysNo = int.Parse(input["QuestionSysNo"].ToString());
            ret.SysNo = int.Parse(input["SysNo"].ToString());
            ret.TS = DateTime.Parse(input["TS"].ToString());

            return ret;
        }

        #endregion

    }

}
