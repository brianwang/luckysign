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
using System.Web;
using AppMod.WebSys;

namespace WebServiceForApp
{
    public class QAService : IQAService
    {
        public ReturnValue<List<QA_CategoryShow>> GetCates(int parent)
        {
            DataTable m_dt = QA_CategoryBll.GetInstance().GetCates(parent);
            if (m_dt == null || m_dt.Rows.Count == 0)
            {
                throw new BusinessException("该分类下无子分类");
            }
            List<QA_CategoryShow> ret = new List<QA_CategoryShow>();
            DataTable questnum = QA_CategoryBll.GetInstance().GetCatesPostNum().Tables[0];
            DataTable postnum = QA_CategoryBll.GetInstance().GetCatesPostNum().Tables[1];

            for (int i = 0; i < m_dt.Rows.Count; i++)
            {
                QA_CategoryShow tmp_cate = MapQA_Category(m_dt.Rows[i]);
                if (!string.IsNullOrEmpty(tmp_cate.Pic))
                {
                    tmp_cate.Pic = Container.ConfigService.GetAppSetting<string>("WebResourcesPath","") + "img/CatePic/" + tmp_cate.Pic;
                }
                for (int j = 0; j < questnum.Rows.Count; j++)
                {
                    if (questnum.Rows[j]["CateSysNo"].ToString() == tmp_cate.SysNo.ToString())
                    {
                        tmp_cate.QuestNum = tmp_cate.QuestNum + int.Parse(questnum.Rows[j]["questnum"].ToString());
                        if (questnum.Rows[j]["IsSolved"].ToString() == "1")
                        {
                            tmp_cate.SolvedNum = tmp_cate.QuestNum;
                        }
                    }
                }
                for (int j = 0; j < postnum.Rows.Count; j++)
                {
                    if (postnum.Rows[j]["CateSysNo"].ToString() == tmp_cate.SysNo.ToString())
                    {
                        tmp_cate.Replys = int.Parse(tmp_cate.QuestNum.ToString()) + int.Parse(postnum.Rows[j]["AnswerNum"].ToString()) + int.Parse(postnum.Rows[j]["CommentNum"].ToString());
                    }
                }
                ret.Add(tmp_cate);
            }
            return ReturnValue<List<QA_CategoryShow>>.Get200OK(ret);
        }

        public ReturnValue<List<USR_CustomerShow>> GetStarsList(int catesysno)
        {
            DataTable m_dt = REL_Customer_CategoryBll.GetInstance().GetListByCate(catesysno,(int)AppEnum.CategoryType.QA);
            if (m_dt == null || m_dt.Rows.Count == 0)
            {
                throw new BusinessException("该分类下无版主");
            }
            List<USR_CustomerShow> ret = new List<USR_CustomerShow>();
            for (int i = 0; i < m_dt.Rows.Count; i++)
            {
                CustomerService m_service = new CustomerService();
                USR_CustomerShow tmp_star = m_service.MapUSR_CustomerShow(m_dt.Rows[i]);
                ret.Add(tmp_star);
            }
            return ReturnValue<List<USR_CustomerShow>>.Get200OK(ret);
        }

        public ReturnValue<PageInfo<QA_QuestionShowMini>> GetQuestionList(int pagesize, int pageindex, string key, int cate, string orderby)
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
            PageInfo<QA_QuestionShowMini> rett = new PageInfo<QA_QuestionShowMini>();
            rett.List = ret;
            rett.Total = total;
            if (pagesize * pageindex >= total)
            {
                rett.HasNextPage = false;
            }
            else
            {
                rett.HasNextPage = true;
            }
            return ReturnValue<PageInfo<QA_QuestionShowMini>>.Get200OK(rett);
        }

        public ReturnValue<QA_QuestionShow> GetQuestion(int sysno)
        {
            QA_QuestionMod tmp = QA_QuestionBll.GetInstance().GetModel(sysno);
            QA_QuestionShow ret = new QA_QuestionShow();
            tmp.MemberwiseCopy(ret);

            USR_CustomerShow tmpu = new USR_CustomerShow();
            USR_CustomerBll.GetInstance().GetModel(ret.CustomerSysNo).MemberwiseCopy(tmpu);
            ret.Customer = tmpu;
            ret.Chart = QA_QuestionBll.GetInstance().GetChartByQuest(ret.SysNo);
            return ReturnValue<QA_QuestionShow>.Get200OK(ret);
        }

        public ReturnValue<PageInfo<QA_AnswerShow>> GetAnswerByQuest(int pagesize, int pageindex, int sysno)
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
                USR_CustomerShow tmpu = new USR_CustomerShow();
                USR_CustomerBll.GetInstance().GetModel(tmp_answer.CustomerSysNo).MemberwiseCopy(tmpu);
                tmp_answer.Customer = tmpu;
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
            PageInfo<QA_AnswerShow> rett = new PageInfo<QA_AnswerShow>();
            rett.List = ret;
            rett.Total = total;
            if (pagesize * pageindex >= total)
            {
                rett.HasNextPage = false;
            }
            else
            {
                rett.HasNextPage = true;
            }
            return ReturnValue<PageInfo<QA_AnswerShow>>.Get200OK(rett);
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

        public ReturnValue<USR_CustomerShow> AddQuestion(Stream openPageData)
        {
            QA_QuestionShow input;
            try
            {
                int nReadCount = 0;
                MemoryStream ms = new MemoryStream();
                byte[] buffer = new byte[1024];
                while ((nReadCount = openPageData.Read(buffer, 0, 1024)) > 0)
                {
                    ms.Write(buffer, 0, nReadCount);
                }
                byte[] byteJson = ms.ToArray();
                string textJson = System.Text.Encoding.Default.GetString(byteJson);

                input = (QA_QuestionShow)XMS.Core.Json.JsonSerializer.Deserialize(textJson, typeof(QA_QuestionShow));

                if (input == null)
                {
                    throw new BusinessException("参数有误");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            #region 判断输入项
            if (input.CateSysNo == 0 || input.CateSysNo == AppConst.IntNull)
            {
                throw new BusinessException("请选择分类");
            }
            if (input.Title.DoTrim() == "")
            {
                throw new BusinessException("请输入标题");
            }
            if (input.Title.DoTrim().Length > 30)
            {
                throw new BusinessException("您输入的标题太长，请控制在30字以内");
            }
            int point = USR_CustomerBll.GetInstance().GetModel(input.CustomerSysNo).Point;
            if (input.Award > point && point != AppConst.IntNull)
            {
                throw new BusinessException("您最多可用" + point + "积分");
            }

            #endregion

            try
            {
                QA_QuestionMod m_quest = new QA_QuestionMod();
                m_quest.Award = input.Award;
                m_quest.CateSysNo = input.CateSysNo;
                m_quest.Context = input.Context;
                m_quest.CustomerSysNo = input.CustomerSysNo;
                m_quest.LastReplyTime = DateTime.Now;
                m_quest.ReplyCount = 0;
                m_quest.ReadCount = 0;
                m_quest.Title = input.Title;
                m_quest.TS = DateTime.Now;
                m_quest.DR = (int)AppEnum.State.normal;

                int sysno = 0;

                QA_QuestionBll.GetInstance().AddQuest(ref m_quest, true);
                sysno = m_quest.SysNo;

                FATE_ChartMod m_chart = new FATE_ChartMod();
                m_chart.CharType = input.Chart.CharType; ;
                if (m_chart.CharType != (int)AppEnum.ChartType.nochart)
                {
                    m_chart.FirstBirth = input.Chart.FirstBirth;
                    m_chart.FirstPoi = input.Chart.FirstPoi;
                    m_chart.Transit = DateTime.Now;
                    m_chart.TransitPoi = input.Chart.FirstPoi;
                    m_chart.TheoryType = 0;
                    m_chart.FirstPoiName = input.Chart.FirstPoiName;
                    m_chart.FirstTimeZone = -8;
                    m_chart.FirstGender = input.Chart.FirstGender;
                    m_chart.FirstDayLight = input.Chart.FirstDayLight;
                    if (m_chart.CharType == (int)AppEnum.ChartType.relation)
                    {
                        m_chart.SecondBirth = input.Chart.SecondBirth;
                        m_chart.SecondPoi = input.Chart.SecondPoi;
                        m_chart.SecondPoiName = input.Chart.SecondPoiName;
                        m_chart.SecondTimeZone = -8;
                        m_chart.SecondGender = input.Chart.SecondGender;
                        m_chart.SecondDayLight = input.Chart.SecondDayLight;
                    }
                    m_chart.TS = DateTime.Now;
                    m_chart.DR = (int)AppEnum.State.normal;
                    int fatesysno = FATE_ChartBll.GetInstance().Add(m_chart);

                    REL_Question_ChartMod m_qchart = new REL_Question_ChartMod();
                    m_qchart.Chart_SysNo = fatesysno;
                    m_qchart.Question_SysNo = sysno;
                    REL_Question_ChartBll.GetInstance().Add(m_qchart);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            USR_CustomerShow ret = new USR_CustomerShow();
            USR_CustomerBll.GetInstance().GetModel(input.CustomerSysNo).MemberwiseCopy(ret);
            return ReturnValue<USR_CustomerShow>.Get200OK(ret);

        }

        public ReturnValue<USR_CustomerShow> AddAnswer(int CustomerSysNo, int QuestionSysNo, string Title, string Context)
        {
            QA_AnswerMod m_answer = new QA_AnswerMod();
            m_answer.Award = 0;
            m_answer.Title = Title;
            m_answer.Context = HttpUtility.HtmlEncode(Context.DoTrim());
            m_answer.CustomerSysNo = CustomerSysNo;
            m_answer.DR = (int)AppEnum.State.normal;
            m_answer.Hate = 0;
            m_answer.Love = 0;
            m_answer.QuestionSysNo = QuestionSysNo;
            m_answer.Title = "";
            m_answer.TS = DateTime.Now;
            QA_AnswerBll.GetInstance().AddAnswer(m_answer);

            USR_CustomerShow ret = new USR_CustomerShow();
            USR_CustomerBll.GetInstance().GetModel(CustomerSysNo).MemberwiseCopy(ret);
            return ReturnValue<USR_CustomerShow>.Get200OK(ret);
        }

        public ReturnValue<USR_CustomerShow> AddComment(int AnswerSysNo, int CustomerSysNo, int QuestionSysNo, string Context)
        {
            QA_CommentMod m_comment = new QA_CommentMod();
            m_comment.AnswerSysNo = AnswerSysNo;
            m_comment.Context = HttpUtility.HtmlEncode(Context.DoTrim());
            m_comment.DR = (int)AppEnum.State.normal;
            m_comment.QuestionSysNo = QuestionSysNo;
            m_comment.TS = DateTime.Now;
            m_comment.CustomerSysNo = CustomerSysNo;
            QA_CommentBll.GetInstance().AddComment(m_comment);

            USR_CustomerShow ret = new USR_CustomerShow();
            USR_CustomerBll.GetInstance().GetModel(CustomerSysNo).MemberwiseCopy(ret);
            return ReturnValue<USR_CustomerShow>.Get200OK(ret);
        }

        public ReturnValue<QA_QuestionShow> SetAward(int answersysno, int score, string msg)
        { 
            QA_AnswerMod m_anser = QA_AnswerBll.GetInstance().GetModel(answersysno);
            QA_AnswerBll.GetInstance().SetAward(m_anser, QA_QuestionBll.GetInstance().GetModel(m_anser.QuestionSysNo), score);

            return GetQuestion(m_anser.SysNo);
        }



        #region map方法

        public QA_CategoryShow MapQA_Category(DataRow input)
        {
            QA_CategoryShow ret = new QA_CategoryShow();
            ret.DR = int.Parse(input["DR"].ToString());
            ret.Name = input["Name"].ToString();
            ret.ParentSysNo = int.Parse(input["ParentSysNo"].ToString());
            ret.SysNo = int.Parse(input["SysNo"].ToString());
            ret.TopSysNo = int.Parse(input["TopSysNo"].ToString());
            ret.TS = DateTime.Parse(input["TS"].ToString());
            ret.Pic = input["Pic"].ToString();
            ret.Intro = input["Intro"].ToString();
            ret.OrderID = int.Parse(input["OrderID"].ToString());
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
