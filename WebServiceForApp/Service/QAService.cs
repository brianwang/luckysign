﻿using System;
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
using PPLive.Astro;
using PPLive.BaZi;
using PPLive.ZiWei;
using PPLive;

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
                if (tmp_cate.TopSysNo == 1)
                {
                    tmp_cate.Pic = tmp_cate.Pic.Replace("pp", "p").Replace("jpg", "png");
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

        public ReturnValue<PageInfo<QA_QuestionShowMini<AstroMod>>> GetQuestionListForAstro(int pagesize, int pageindex, string key, int cate, string orderby)
        {
            int total = 0;
            DataTable m_dt = QA_QuestionBll.GetInstance().GetList(pagesize, pageindex,key,cate,orderby,ref total);
            List<QA_QuestionShowMini<AstroMod>> ret = new List<QA_QuestionShowMini<AstroMod>>();
            PageInfo<QA_QuestionShowMini<AstroMod>> rett = new PageInfo<QA_QuestionShowMini<AstroMod>>();
            if (m_dt == null || m_dt.Rows.Count == 0)
            {
                rett.List = ret;
                rett.Total = total;
                rett.HasNextPage = false;
                return ReturnValue<PageInfo<QA_QuestionShowMini<AstroMod>>>.Get200OK(rett);
            }
            for (int i = 0; i < m_dt.Rows.Count; i++)
            {
                QA_QuestionShowMini<AstroMod> tmp_quest = MapQA_QuestionShowMiniForAstro(m_dt.Rows[i]);
                ret.Add(tmp_quest);
            }

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
            return ReturnValue<PageInfo<QA_QuestionShowMini<AstroMod>>>.Get200OK(rett);
        }
        public ReturnValue<PageInfo<QA_QuestionShowMini<BaZiMod>>> GetQuestionListForBaZi(int pagesize, int pageindex, string key, int cate, string orderby)
        {
            int total = 0;
            DataTable m_dt = QA_QuestionBll.GetInstance().GetList(pagesize, pageindex, key, cate, orderby, ref total);
            List<QA_QuestionShowMini<BaZiMod>> ret = new List<QA_QuestionShowMini<BaZiMod>>();
            PageInfo<QA_QuestionShowMini<BaZiMod>> rett = new PageInfo<QA_QuestionShowMini<BaZiMod>>();
            if (m_dt == null || m_dt.Rows.Count == 0)
            {
                rett.List = ret;
                rett.Total = total;
                rett.HasNextPage = false;
                return ReturnValue<PageInfo<QA_QuestionShowMini<BaZiMod>>>.Get200OK(rett);
            }
            
            for (int i = 0; i < m_dt.Rows.Count; i++)
            {
                QA_QuestionShowMini<BaZiMod> tmp_quest = MapQA_QuestionShowMiniForBaZi(m_dt.Rows[i]);
                ret.Add(tmp_quest);
            }
            
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
            return ReturnValue<PageInfo<QA_QuestionShowMini<BaZiMod>>>.Get200OK(rett);
        }
        public ReturnValue<PageInfo<QA_QuestionShowMini<ZiWeiMod>>> GetQuestionListForZiWei(int pagesize, int pageindex, string key, int cate, string orderby)
        {
            int total = 0;
            DataTable m_dt = QA_QuestionBll.GetInstance().GetList(pagesize, pageindex, key, cate, orderby, ref total);
            List<QA_QuestionShowMini<ZiWeiMod>> ret = new List<QA_QuestionShowMini<ZiWeiMod>>();
            PageInfo<QA_QuestionShowMini<ZiWeiMod>> rett = new PageInfo<QA_QuestionShowMini<ZiWeiMod>>(); 
            if (m_dt == null || m_dt.Rows.Count == 0)
            {
                rett.List = ret;
                rett.Total = total;
                rett.HasNextPage = false;
                return ReturnValue<PageInfo<QA_QuestionShowMini<ZiWeiMod>>>.Get200OK(rett);
            }
            
            for (int i = 0; i < m_dt.Rows.Count; i++)
            {
                QA_QuestionShowMini<ZiWeiMod> tmp_quest = MapQA_QuestionShowMiniForZiWei(m_dt.Rows[i]);
                ret.Add(tmp_quest);
            }
            
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
            return ReturnValue<PageInfo<QA_QuestionShowMini<ZiWeiMod>>>.Get200OK(rett);
        }

        public ReturnValue<PageInfo<QA_AnswerShow>> GetQuestionListByUserAnswer(int pagesize, int pageindex, int customersysno, int cate, string orderby)
        {
            int total = 0;
            DataTable m_dt = QA_AnswerBll.GetInstance().GetListByUser(pagesize, pageindex, customersysno, "", cate, false, orderby, ref total);
            List<QA_AnswerShow> ret = new List<QA_AnswerShow>();
            PageInfo<QA_AnswerShow> rett = new PageInfo<QA_AnswerShow>();
            if (m_dt == null || m_dt.Rows.Count == 0)
            {
                rett.List = ret;
                rett.Total = total;
                rett.HasNextPage = false;
                return ReturnValue<PageInfo<QA_AnswerShow>>.Get200OK(rett);
            }
            for (int i = 0; i < m_dt.Rows.Count; i++)
            {
                QA_AnswerShow tmp_quest = MapQA_AnswerShow(m_dt.Rows[i]);
                tmp_quest.QuestionTitle = m_dt.Rows[i]["QuestTitle"].ToString();
                ret.Add(tmp_quest);
            }

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

        public ReturnValue<PageInfo<QA_QuestionShowMini<AstroMod>>> GetQuestionListByUserAsk(int pagesize, int pageindex, int customersysno, int cate, string orderby)
        {
            int total = 0;
            DataTable m_dt = QA_QuestionBll.GetInstance().GetListByUserAsk(pagesize, pageindex, customersysno, "", cate, orderby, ref total);
            List<QA_QuestionShowMini<AstroMod>> ret = new List<QA_QuestionShowMini<AstroMod>>();
            PageInfo<QA_QuestionShowMini<AstroMod>> rett = new PageInfo<QA_QuestionShowMini<AstroMod>>();
            if (m_dt == null || m_dt.Rows.Count == 0)
            {
                rett.List = ret;
                rett.Total = total;
                rett.HasNextPage = false;
                return ReturnValue<PageInfo<QA_QuestionShowMini<AstroMod>>>.Get200OK(rett);
            }
            for (int i = 0; i < m_dt.Rows.Count; i++)
            {
                QA_QuestionShowMini<AstroMod> tmp_quest = MapQA_QuestionShowMiniForAstro(m_dt.Rows[i]);
                ret.Add(tmp_quest);
            }

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
            return ReturnValue<PageInfo<QA_QuestionShowMini<AstroMod>>>.Get200OK(rett);
        }

        public ReturnValue<QA_QuestionShow<AstroMod>> GetQuestionForAstro(int sysno)
        {
            QA_QuestionMod tmp = QA_QuestionBll.GetInstance().GetModel(sysno);
            QA_QuestionShow<AstroMod> ret = new QA_QuestionShow<AstroMod>();
            tmp.MemberwiseCopy(ret);

            USR_CustomerShow tmpu = new USR_CustomerShow();
            USR_CustomerBll.GetInstance().GetModel(ret.CustomerSysNo).MemberwiseCopy(tmpu);
            ret.Customer = tmpu;
            #region 设置星盘
            FATE_ChartMod m_chart = QA_QuestionBll.GetInstance().GetChartByQuest(ret.SysNo);
            if (m_chart != null)
            {
                AstroMod tmpastro = new AstroMod();

                if (m_chart.CharType.ToString() == ((int)AppEnum.ChartType.personal).ToString())
                {
                    #region 设置实体各种参数

                    tmpastro.type = PublicValue.AstroType.benming;
                    tmpastro.birth = DateTime.Parse(m_chart.FirstBirth.ToString());
                    tmpastro.Gender = (AppEnum.Gender)m_chart.FirstGender;
                    string[] tmplatlng = m_chart.FirstPoi.ToString().Split(new char[] { '|' });
                    tmpastro.position = new LatLng(tmplatlng[1], tmplatlng[0], m_chart.FirstPoiName);
                    if (m_chart.FirstDayLight.ToString() == ((int)AppEnum.BOOL.True).ToString())
                    {
                        tmpastro.IsDayLight = AppEnum.BOOL.True;
                    }
                    else
                    {
                        tmpastro.IsDayLight = AppEnum.BOOL.False;
                    }
                    tmpastro.zone = int.Parse(m_chart.FirstTimeZone.ToString());

                    #endregion
                }
                else if (m_chart.CharType.ToString() == ((int)AppEnum.ChartType.relation).ToString())
                {
                    #region 设置实体各种参数
                    tmpastro.type = PublicValue.AstroType.hepan;
                    tmpastro.compose = PublicValue.AstroZuhe.bijiao;
                    tmpastro.Gender = (AppEnum.Gender)m_chart.FirstGender;
                    tmpastro.Gender1 = (AppEnum.Gender)m_chart.SecondGender;
                    tmpastro.birth = DateTime.Parse(m_chart.FirstBirth.ToString());
                    string[] tmplatlng = m_chart.FirstPoi.ToString().Split(new char[] { '|' });
                    tmpastro.position = new LatLng(tmplatlng[1], tmplatlng[0], m_chart.FirstPoiName);
                    if (m_chart.FirstDayLight.ToString() == ((int)AppEnum.BOOL.True).ToString())
                    {
                        tmpastro.IsDayLight = AppEnum.BOOL.True;
                    }
                    else
                    {
                        tmpastro.IsDayLight = AppEnum.BOOL.False;
                    }
                    tmpastro.zone = int.Parse(m_chart.FirstTimeZone.ToString());
                    tmpastro.birth1 = DateTime.Parse(m_chart.SecondBirth.ToString());
                    tmplatlng = m_chart.SecondPoi.ToString().Split(new char[] { '|' });
                    tmpastro.position1 = new LatLng(tmplatlng[1], tmplatlng[0], m_chart.SecondPoiName);
                    if (m_chart.SecondDayLight.ToString() == ((int)AppEnum.BOOL.True).ToString())
                    {
                        tmpastro.IsDayLight1 = AppEnum.BOOL.True;
                    }
                    else
                    {
                        tmpastro.IsDayLight1 = AppEnum.BOOL.False;
                    }
                    tmpastro.zone1 = int.Parse(m_chart.SecondTimeZone.ToString());

                    #endregion
                }
                tmpastro.startsShow.Clear();
                for (int i = 1; i <= 30; i++)
                {
                    tmpastro.startsShow.Add(i, PublicValue.GetAstroStar((PublicValue.AstroStar)i));
                }
                tmpastro.aspectsShow.Clear();
                tmpastro.aspectsShow.Add(1, 0);
                tmpastro.aspectsShow.Add(2, 180);
                tmpastro.aspectsShow.Add(4, 120);
                tmpastro.aspectsShow.Add(3, 90);
                tmpastro.aspectsShow.Add(5, 60);
                tmpastro.graphicID = AstroBiz.GetInstance().SetGraphicID(tmpastro);
                if ((tmpastro.type == PublicValue.AstroType.hepan && tmpastro.compose == PublicValue.AstroZuhe.bijiao) || (tmpastro.type == PublicValue.AstroType.tuiyun && tmpastro.transit == PublicValue.AstroTuiyun.xingyun))
                {
                    AstroMod tmpinput = new AstroMod();
                    tmpinput.aspectsShow = tmpastro.aspectsShow;
                    tmpinput.startsShow = tmpastro.startsShow;
                    tmpinput.birth = tmpastro.birth;
                    tmpinput.position = tmpastro.position;
                    tmpinput.IsDayLight = tmpastro.IsDayLight;
                    tmpinput.zone = tmpastro.zone;
                    AstroBiz.GetInstance().GetParamters(ref tmpinput);
                    tmpastro.Stars = tmpinput.Stars;

                    tmpinput = new AstroMod();
                    tmpinput.aspectsShow = tmpastro.aspectsShow;
                    tmpinput.startsShow = tmpastro.startsShow;
                    tmpinput.birth = tmpastro.birth1;
                    tmpinput.position = tmpastro.position1;
                    tmpinput.IsDayLight = tmpastro.IsDayLight1;
                    tmpinput.zone = tmpastro.zone1;
                    AstroBiz.GetInstance().GetParamters(ref tmpinput);
                    tmpastro.Stars1 = tmpinput.Stars;
                }
                else
                {
                    AstroBiz.GetInstance().GetParamters(ref tmpastro);
                    tmpastro.Stars1 = null;
                }
                ret.Chart.Add(tmpastro);
            }
            #endregion
            return ReturnValue<QA_QuestionShow<AstroMod>>.Get200OK(ret);
        }

        public ReturnValue<QA_QuestionShow<BaZiMod>> GetQuestionForBaZi(int sysno)
        {
            QA_QuestionMod tmp = QA_QuestionBll.GetInstance().GetModel(sysno);
            QA_QuestionShow<BaZiMod> ret = new QA_QuestionShow<BaZiMod>();
            tmp.MemberwiseCopy(ret);

            USR_CustomerShow tmpu = new USR_CustomerShow();
            USR_CustomerBll.GetInstance().GetModel(ret.CustomerSysNo).MemberwiseCopy(tmpu);
            ret.Customer = tmpu;
            #region 设置命盘
            FATE_ChartMod m_chart = QA_QuestionBll.GetInstance().GetChartByQuest(ret.SysNo);
            if (m_chart != null)
            {
                BaZiMod m_bazi = new BaZiMod();
                string[] tmplatlng = m_chart.FirstPoi.ToString().Split(new char[] { '|' });
                m_bazi.BirthTime = new DateEntity(PublicDeal.GetInstance().RealTime(DateTime.Parse(m_chart.FirstBirth.ToString()),
                    new LatLng(tmplatlng[1], tmplatlng[0], m_chart.FirstPoiName)));
                m_bazi.AreaName = m_chart.FirstPoiName.ToString();
                m_bazi.Longitude = tmplatlng[0];
                m_bazi.Gender = (AppEnum.Gender)m_chart.FirstGender;
                BaZiBiz.GetInstance().TimeToBaZi(ref m_bazi);
                ret.Chart.Add(m_bazi);
                if (m_chart.CharType.ToString() == ((int)AppEnum.ChartType.relation).ToString())
                {
                    BaZiMod m_bazi1 = new BaZiMod();
                    tmplatlng = m_chart.SecondPoi.ToString().Split(new char[] { '|' });
                    m_bazi1.BirthTime = new DateEntity(PublicDeal.GetInstance().RealTime(DateTime.Parse(m_chart.SecondBirth.ToString()),
                        new LatLng(tmplatlng[1], tmplatlng[0], m_chart.SecondPoiName)));
                    m_bazi1.AreaName = m_chart.SecondPoiName.ToString();
                    m_bazi1.Longitude = tmplatlng[0];
                    m_bazi1.Gender = (AppEnum.Gender)m_chart.SecondGender;
                    BaZiBiz.GetInstance().TimeToBaZi(ref m_bazi1);
                    ret.Chart.Add(m_bazi1);
                }
            }
            #endregion
            return ReturnValue<QA_QuestionShow<BaZiMod>>.Get200OK(ret);
        }

        public ReturnValue<QA_QuestionShow<ZiWeiMod>> GetQuestionForZiWei(int sysno)
        {
            QA_QuestionMod tmp = QA_QuestionBll.GetInstance().GetModel(sysno);
            QA_QuestionShow<ZiWeiMod> ret = new QA_QuestionShow<ZiWeiMod>();
            tmp.MemberwiseCopy(ret);

            USR_CustomerShow tmpu = new USR_CustomerShow();
            USR_CustomerBll.GetInstance().GetModel(ret.CustomerSysNo).MemberwiseCopy(tmpu);
            ret.Customer = tmpu;
            #region 设置命盘
            int[] _paras = { 1, 1, 0, 1 };
            FATE_ChartMod m_chart = QA_QuestionBll.GetInstance().GetChartByQuest(ret.SysNo);
            if (m_chart != null)
            {
                ZiWeiMod m_ziwei = new ZiWeiMod();
                #region 设置实体各种参数
                //默认做太阳时修正
                string[] tmplatlng = m_chart.FirstPoi.ToString().Split(new char[] { '|' });
                m_ziwei.BirthTime = new DateEntity(PublicDeal.GetInstance().RealTime(DateTime.Parse(m_chart.FirstBirth.ToString()),
                    new LatLng(tmplatlng[1], tmplatlng[0], m_chart.FirstPoiName)));
                m_ziwei.Gender = (AppEnum.Gender)int.Parse(m_chart.FirstGender.ToString());
                m_ziwei.RunYue = PublicValue.ZiWeiRunYue.dangxia;
                m_ziwei.TransitTime = new DateEntity(DateTime.Now);
                #endregion
                m_ziwei = ZiWeiBiz.GetInstance().TimeToZiWei(m_ziwei.BirthTime, m_ziwei.Gender, _paras);
                ret.Chart.Add(m_ziwei);

                if (m_chart.CharType.ToString() == ((int)AppEnum.ChartType.relation).ToString())
                {
                    ZiWeiMod m_ziwei1 = new ZiWeiMod();
                    #region 设置实体各种参数
                    tmplatlng = m_chart.SecondPoi.ToString().Split(new char[] { '|' });
                    m_ziwei1.BirthTime = new DateEntity(PublicDeal.GetInstance().RealTime(DateTime.Parse(m_chart.SecondBirth.ToString()),
                        new LatLng(tmplatlng[1], tmplatlng[0], m_chart.SecondPoiName)));
                    m_ziwei1.Gender = (AppEnum.Gender)int.Parse(m_chart.SecondGender.ToString());
                    m_ziwei1.RunYue = PublicValue.ZiWeiRunYue.dangxia;
                    m_ziwei1.TransitTime = new DateEntity(DateTime.Now);
                    #endregion
                    m_ziwei1 = ZiWeiBiz.GetInstance().TimeToZiWei(m_ziwei.BirthTime, m_ziwei.Gender, _paras);
                    ret.Chart.Add(m_ziwei1);
                }
            }
            #endregion
            return ReturnValue<QA_QuestionShow<ZiWeiMod>>.Get200OK(ret);
        }

        public ReturnValue<PageInfo<QA_AnswerShow>> GetAnswerByQuest(int pagesize, int pageindex, int sysno)
        {
            int total = 0;
            DataTable m_dt = QA_AnswerBll.GetInstance().GetListByQuest(pagesize, pageindex, sysno, ref total);
            List<QA_AnswerShow> ret = new List<QA_AnswerShow>();
            PageInfo<QA_AnswerShow> rett = new PageInfo<QA_AnswerShow>();
            if (m_dt == null || m_dt.Rows.Count == 0)
            {
                rett.List = ret;
                rett.Total = total;
                rett.HasNextPage = false;
                return ReturnValue<PageInfo<QA_AnswerShow>>.Get200OK(rett);
            }
            
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
                    for (int j = 0; j < tmp_dt.Rows.Count && j <= 3; j++)
                    {
                        QA_CommentShow tmp_comment = MapQA_CommentShow(tmp_dt.Rows[j]);
                        USR_CustomerMaintain tmpuu = new USR_CustomerMaintain();
                        USR_CustomerBll.GetInstance().GetModel(tmp_comment.CustomerSysNo).MemberwiseCopy(tmpuu);
                        tmp_comment.Customer = tmpuu;
                        commentlist.Add(tmp_comment);
                    }
                    tmp_answer.TopComments = commentlist;
                    tmp_answer.ToalComment = tmp_dt.Rows.Count;
                    if (tmp_dt.Rows.Count > 3)
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
            List<QA_CommentShow> ret = new List<QA_CommentShow>();
            if (m_dt == null || m_dt.Rows.Count == 0)
            {
                return ReturnValue<List<QA_CommentShow>>.Get200OK(ret);
            }
            
            for (int i = 0; i < m_dt.Rows.Count; i++)
            {
                QA_CommentShow tmp_comment = MapQA_CommentShow(m_dt.Rows[i]);
                ret.Add(tmp_comment);
            }

            return ReturnValue<List<QA_CommentShow>>.Get200OK(ret);
        }

       

        public ReturnValue<USR_CustomerShow> AddAnswer(int CustomerSysNo, int QuestionSysNo, string Title, string Context)
        {
            QA_AnswerMod m_answer = new QA_AnswerMod();
            m_answer.Award = 0;
            m_answer.Title = Title;
            m_answer.Context = AppCmn.CommonTools.SystemInputFilter(Context.DoTrim());
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
            m_comment.Context = AppCmn.CommonTools.SystemInputFilter(Context.DoTrim());
            m_comment.DR = (int)AppEnum.State.normal;
            m_comment.QuestionSysNo = QuestionSysNo;
            m_comment.TS = DateTime.Now;
            m_comment.CustomerSysNo = CustomerSysNo;
            QA_CommentBll.GetInstance().AddComment(m_comment);

            USR_CustomerShow ret = new USR_CustomerShow();
            USR_CustomerBll.GetInstance().GetModel(CustomerSysNo).MemberwiseCopy(ret);
            return ReturnValue<USR_CustomerShow>.Get200OK(ret);
        }

        public ReturnValue<bool> RemoveComment(int CommentSysNo)
        {
            QA_CommentMod m_comment = QA_CommentBll.GetInstance().GetModel(CommentSysNo);
            if (m_comment != null)
            {
                m_comment.DR = (int)AppEnum.State.deleted;
                QA_CommentBll.GetInstance().Update(m_comment);

                return ReturnValue<bool>.Get200OK(true);
            }
            else
            {
                throw new BusinessException("该评论不存在！");
            }
        }
        public ReturnValue<bool> RemoveAnswer(int AnswerSysNo)
        {
            QA_AnswerMod m_anser = QA_AnswerBll.GetInstance().GetModel(AnswerSysNo);
            if (m_anser != null)
            {
                m_anser.DR = (int)AppEnum.State.deleted;
                QA_AnswerBll.GetInstance().Update(m_anser);

                return ReturnValue<bool>.Get200OK(false);
            }
            else
            {
                throw new BusinessException("该回复不存在！");
            }
        }

        public ReturnValue<QA_QuestionShow<AstroMod>> SetAward(int answersysno, int score, string msg)
        { 
            QA_AnswerMod m_anser = QA_AnswerBll.GetInstance().GetModel(answersysno);
            QA_AnswerBll.GetInstance().SetAward(m_anser, QA_QuestionBll.GetInstance().GetModel(m_anser.QuestionSysNo), score);

            return GetQuestionForAstro(m_anser.SysNo);
        }



        #region map方法

        public QA_CategoryShow MapQA_Category(DataRow input)
        {
            QA_CategoryShow ret = new QA_CategoryShow();
            if (input["DR"].ToString() != "")
            {
                ret.DR = int.Parse(input["DR"].ToString());
            }
            ret.Name = input["Name"].ToString();
            if (input["ParentSysNo"].ToString()!="")
            {
                ret.ParentSysNo = int.Parse(input["ParentSysNo"].ToString());
            }
            if (input["SysNo"].ToString() != "")
            {
                ret.SysNo = int.Parse(input["SysNo"].ToString());
            }
            if (input["TopSysNo"].ToString() != "")
            {
                ret.TopSysNo = int.Parse(input["TopSysNo"].ToString());
            }
            if (input["TS"].ToString() != "")
            {
                ret.TS = DateTime.Parse(input["TS"].ToString());
            }
            ret.Pic = input["Pic"].ToString();
            ret.Intro = input["Intro"].ToString();
            if (input["OrderID"].ToString() != "")
            {
                ret.OrderID = int.Parse(input["OrderID"].ToString());
            }
            return ret;
        }

        public QA_QuestionShowMini<AstroMod> MapQA_QuestionShowMiniForAstro(DataRow input)
        {
            QA_QuestionShowMini<AstroMod> ret = new QA_QuestionShowMini<AstroMod>();
            
            if (input["Award"].ToString() != "")
            {
                ret.Award = int.Parse(input["Award"].ToString());
            }
            if (input["CateSysNo"].ToString() != "")
            {
                ret.CateSysNo = int.Parse(input["CateSysNo"].ToString());
            }
            #region 设置星盘
            FATE_ChartMod m_chart = QA_QuestionBll.GetInstance().GetChartByQuest(int.Parse(input["SysNo"].ToString()));
            if (m_chart != null)
            {
                AstroMod tmpastro = new AstroMod();

                if (m_chart.CharType.ToString() == ((int)AppEnum.ChartType.personal).ToString())
                {
                    #region 设置实体各种参数

                    tmpastro.type = PublicValue.AstroType.benming;
                    tmpastro.birth = DateTime.Parse(m_chart.FirstBirth.ToString());
                    tmpastro.Gender = (AppEnum.Gender)m_chart.FirstGender;
                    string[] tmplatlng = m_chart.FirstPoi.ToString().Split(new char[] { '|' });
                    tmpastro.position = new LatLng(tmplatlng[1], tmplatlng[0], m_chart.FirstPoiName);
                    if (m_chart.FirstDayLight.ToString() == ((int)AppEnum.BOOL.True).ToString())
                    {
                        tmpastro.IsDayLight = AppEnum.BOOL.True;
                    }
                    else
                    {
                        tmpastro.IsDayLight = AppEnum.BOOL.False;
                    }
                    tmpastro.zone = int.Parse(m_chart.FirstTimeZone.ToString());

                    #endregion
                }
                else if (m_chart.CharType.ToString() == ((int)AppEnum.ChartType.relation).ToString())
                {
                    #region 设置实体各种参数
                    tmpastro.type = PublicValue.AstroType.hepan;
                    tmpastro.compose = PublicValue.AstroZuhe.bijiao;
                    tmpastro.Gender = (AppEnum.Gender)m_chart.FirstGender;
                    tmpastro.Gender1 = (AppEnum.Gender)m_chart.SecondGender;
                    tmpastro.birth = DateTime.Parse(m_chart.FirstBirth.ToString());
                    string[] tmplatlng = m_chart.FirstPoi.ToString().Split(new char[] { '|' });
                    tmpastro.position = new LatLng(tmplatlng[1], tmplatlng[0], m_chart.FirstPoiName);
                    if (m_chart.FirstDayLight.ToString() == ((int)AppEnum.BOOL.True).ToString())
                    {
                        tmpastro.IsDayLight = AppEnum.BOOL.True;
                    }
                    else
                    {
                        tmpastro.IsDayLight = AppEnum.BOOL.False;
                    }
                    tmpastro.zone = int.Parse(m_chart.FirstTimeZone.ToString());
                    tmpastro.birth1 = DateTime.Parse(m_chart.SecondBirth.ToString());
                    tmplatlng = m_chart.SecondPoi.ToString().Split(new char[] { '|' });
                    tmpastro.position1 = new LatLng(tmplatlng[1], tmplatlng[0], m_chart.SecondPoiName);
                    if (m_chart.SecondDayLight.ToString() == ((int)AppEnum.BOOL.True).ToString())
                    {
                        tmpastro.IsDayLight1 = AppEnum.BOOL.True;
                    }
                    else
                    {
                        tmpastro.IsDayLight1 = AppEnum.BOOL.False;
                    }
                    tmpastro.zone1 = int.Parse(m_chart.SecondTimeZone.ToString());

                    #endregion
                }
                tmpastro.startsShow.Clear();
                for (int i = 1; i <= 30; i++)
                {
                    tmpastro.startsShow.Add(i, PublicValue.GetAstroStar((PublicValue.AstroStar)i));
                }
                tmpastro.aspectsShow.Clear();
                tmpastro.aspectsShow.Add(1, 0);
                tmpastro.aspectsShow.Add(2, 180);
                tmpastro.aspectsShow.Add(4, 120);
                tmpastro.aspectsShow.Add(3, 90);
                tmpastro.aspectsShow.Add(5, 60);
                tmpastro.graphicID = AstroBiz.GetInstance().SetGraphicID(tmpastro);
                if ((tmpastro.type == PublicValue.AstroType.hepan && tmpastro.compose == PublicValue.AstroZuhe.bijiao) || (tmpastro.type == PublicValue.AstroType.tuiyun && tmpastro.transit == PublicValue.AstroTuiyun.xingyun))
                {
                    AstroMod tmpinput = new AstroMod();
                    tmpinput.aspectsShow = tmpastro.aspectsShow;
                    tmpinput.startsShow = tmpastro.startsShow;
                    tmpinput.birth = tmpastro.birth;
                    tmpinput.position = tmpastro.position;
                    tmpinput.IsDayLight = tmpastro.IsDayLight;
                    tmpinput.zone = tmpastro.zone;
                    AstroBiz.GetInstance().GetParamters(ref tmpinput);
                    tmpastro.Stars = tmpinput.Stars;

                    tmpinput = new AstroMod();
                    tmpinput.aspectsShow = tmpastro.aspectsShow;
                    tmpinput.startsShow = tmpastro.startsShow;
                    tmpinput.birth = tmpastro.birth1;
                    tmpinput.position = tmpastro.position1;
                    tmpinput.IsDayLight = tmpastro.IsDayLight1;
                    tmpinput.zone = tmpastro.zone1;
                    AstroBiz.GetInstance().GetParamters(ref tmpinput);
                    tmpastro.Stars1 = tmpinput.Stars;
                }
                else
                {
                    AstroBiz.GetInstance().GetParamters(ref tmpastro);
                    tmpastro.Stars1 = null;
                }
                ret.Chart.Add(tmpastro);
            }
            #endregion
            ret.Context = input["Context"].ToString();
            if (input["NickName"] == null)
            {
                USR_CustomerMod m_customer = USR_CustomerBll.GetInstance().GetModel(int.Parse(input["CustomerSysNo"].ToString()));

                ret.CustomerNickName = m_customer.NickName;
                ret.CustomerPhoto = m_customer.Photo;
            }
            else
            {
                ret.CustomerNickName = input["NickName"].ToString();
                ret.CustomerPhoto = input["Photo"].ToString();
            }
            if (input["CustomerSysNo"].ToString() != "")
            {
                ret.CustomerSysNo = int.Parse(input["CustomerSysNo"].ToString());
            }
            ret.DR = int.Parse(input["DR"].ToString());
            if (input["EndTime"].ToString() != "")
            {
                ret.EndTime = DateTime.Parse(input["EndTime"].ToString());
            }
            else
            {
                ret.EndTime = AppConst.DateTimeNull;
            }
            if (input["IsSecret"].ToString() != "")
            {
                ret.IsSecret = int.Parse(input["IsSecret"].ToString());
            }
            if (input["LastReplyTime"].ToString() != "")
            {
                ret.LastReplyTime = DateTime.Parse(input["LastReplyTime"].ToString());
            }
            else
            {
                ret.LastReplyTime = AppConst.DateTimeNull;
            }
            if (input["LastReplyUser"].ToString() != "")
            {
                ret.LastReplyUser = int.Parse(input["LastReplyUser"].ToString());
            }
            if (input["ReadCount"].ToString() != "")
            {
                ret.ReadCount = int.Parse(input["ReadCount"].ToString());
            }
            if (input["ReplyCount"].ToString() != "")
            {
                ret.ReplyCount = int.Parse(input["ReplyCount"].ToString());
            }
            if (input["SysNo"].ToString() != "")
            {
                ret.SysNo = int.Parse(input["SysNo"].ToString());
            }
            ret.Title = input["Title"].ToString();
            if (input["TS"].ToString() != "")
            {
                ret.TS = DateTime.Parse(input["TS"].ToString());
            }
            else
            {
                ret.TS = AppConst.DateTimeNull;
            }
            return ret;
        }
        public QA_QuestionShowMini<BaZiMod> MapQA_QuestionShowMiniForBaZi(DataRow input)
        {
            QA_QuestionShowMini<BaZiMod> ret = new QA_QuestionShowMini<BaZiMod>();
            if (input["Award"].ToString() != "")
            {
                ret.Award = int.Parse(input["Award"].ToString());
            }
            if (input["CateSysNo"].ToString() != "")
            {
                ret.CateSysNo = int.Parse(input["CateSysNo"].ToString());
            }
            #region 设置命盘
            FATE_ChartMod m_chart = QA_QuestionBll.GetInstance().GetChartByQuest(int.Parse(input["SysNo"].ToString()));
            if (m_chart != null)
            {
                BaZiMod m_bazi = new BaZiMod();
                string[] tmplatlng = m_chart.FirstPoi.ToString().Split(new char[] { '|' });
                m_bazi.BirthTime = new DateEntity(PublicDeal.GetInstance().RealTime(DateTime.Parse(m_chart.FirstBirth.ToString()),
                    new LatLng(tmplatlng[1], tmplatlng[0], m_chart.FirstPoiName)));
                m_bazi.AreaName = m_chart.FirstPoiName.ToString();
                m_bazi.Longitude = tmplatlng[0];
                m_bazi.Gender = (AppEnum.Gender)m_chart.FirstGender;
                BaZiBiz.GetInstance().TimeToBaZi(ref m_bazi);
                ret.Chart.Add(m_bazi);
                if (m_chart.CharType.ToString() == ((int)AppEnum.ChartType.relation).ToString())
                {
                    BaZiMod m_bazi1 = new BaZiMod();
                    tmplatlng = m_chart.SecondPoi.ToString().Split(new char[] { '|' });
                    m_bazi1.BirthTime = new DateEntity(PublicDeal.GetInstance().RealTime(DateTime.Parse(m_chart.SecondBirth.ToString()),
                        new LatLng(tmplatlng[1], tmplatlng[0], m_chart.SecondPoiName)));
                    m_bazi1.AreaName = m_chart.SecondPoiName.ToString();
                    m_bazi1.Longitude = tmplatlng[0];
                    m_bazi1.Gender = (AppEnum.Gender)m_chart.SecondGender;
                    BaZiBiz.GetInstance().TimeToBaZi(ref m_bazi1);
                    ret.Chart.Add(m_bazi1);
                }
            }
            #endregion
            ret.Context = input["Context"].ToString();
            if (input["NickName"] == null)
            {
                USR_CustomerMod m_customer = USR_CustomerBll.GetInstance().GetModel(int.Parse(input["CustomerSysNo"].ToString()));

                ret.CustomerNickName = m_customer.NickName;
                ret.CustomerPhoto = m_customer.Photo;
            }
            else
            {
                ret.CustomerNickName = input["NickName"].ToString();
                ret.CustomerPhoto = input["Photo"].ToString();
            }
            if (input["CustomerSysNo"].ToString() != "")
            {
                ret.CustomerSysNo = int.Parse(input["CustomerSysNo"].ToString());
            }
            ret.DR = int.Parse(input["DR"].ToString());
            if (input["EndTime"].ToString() != "")
            {
                ret.EndTime = DateTime.Parse(input["EndTime"].ToString());
            }
            if (input["IsSecret"].ToString() != "")
            {
                ret.IsSecret = int.Parse(input["IsSecret"].ToString());
            }
            if (input["LastReplyTime"].ToString() != "")
            {
                ret.LastReplyTime = DateTime.Parse(input["LastReplyTime"].ToString());
            }
            if (input["LastReplyUser"].ToString() != "")
            {
                ret.LastReplyUser = int.Parse(input["LastReplyUser"].ToString());
            }
            if (input["ReadCount"].ToString() != "")
            {
                ret.ReadCount = int.Parse(input["ReadCount"].ToString());
            }
            if (input["ReplyCount"].ToString() != "")
            {
                ret.ReplyCount = int.Parse(input["ReplyCount"].ToString());
            }
            if (input["SysNo"].ToString() != "")
            {
                ret.SysNo = int.Parse(input["SysNo"].ToString());
            }
            ret.Title = input["Title"].ToString();
            if (input["TS"].ToString() != "")
            {
                ret.TS = DateTime.Parse(input["TS"].ToString());
            }

            return ret;
        }
        public QA_QuestionShowMini<ZiWeiMod> MapQA_QuestionShowMiniForZiWei(DataRow input)
        {
            QA_QuestionShowMini<ZiWeiMod> ret = new QA_QuestionShowMini<ZiWeiMod>();
            if (input["Award"].ToString() != "")
            {
                ret.Award = int.Parse(input["Award"].ToString());
            }
            if (input["CateSysNo"].ToString() != "")
            {
                ret.CateSysNo = int.Parse(input["CateSysNo"].ToString());
            }
            #region 设置命盘
            int[] _paras = {1,1,0,1};
            FATE_ChartMod m_chart = QA_QuestionBll.GetInstance().GetChartByQuest(int.Parse(input["SysNo"].ToString()));
            if (m_chart != null)
            {
                ZiWeiMod m_ziwei = new ZiWeiMod();
                #region 设置实体各种参数
                //默认做太阳时修正
                string[] tmplatlng = m_chart.FirstPoi.ToString().Split(new char[] { '|' });
                m_ziwei.BirthTime = new DateEntity(PublicDeal.GetInstance().RealTime(DateTime.Parse(m_chart.FirstBirth.ToString()),
                    new LatLng(tmplatlng[1], tmplatlng[0], m_chart.FirstPoiName)));
                m_ziwei.Gender = (AppEnum.Gender)int.Parse(m_chart.FirstGender.ToString());
                m_ziwei.RunYue = PublicValue.ZiWeiRunYue.dangxia;
                m_ziwei.TransitTime = new DateEntity(DateTime.Now);
                #endregion
                m_ziwei = ZiWeiBiz.GetInstance().TimeToZiWei(m_ziwei.BirthTime, m_ziwei.Gender, _paras);
                ret.Chart.Add(m_ziwei);

                if (m_chart.CharType.ToString() == ((int)AppEnum.ChartType.relation).ToString())
                {
                    ZiWeiMod m_ziwei1 = new ZiWeiMod();
                    #region 设置实体各种参数
                    tmplatlng = m_chart.SecondPoi.ToString().Split(new char[] { '|' });
                    m_ziwei1.BirthTime = new DateEntity(PublicDeal.GetInstance().RealTime(DateTime.Parse(m_chart.SecondBirth.ToString()),
                        new LatLng(tmplatlng[1], tmplatlng[0], m_chart.SecondPoiName)));
                    m_ziwei1.Gender = (AppEnum.Gender)int.Parse(m_chart.SecondGender.ToString());
                    m_ziwei1.RunYue = PublicValue.ZiWeiRunYue.dangxia;
                    m_ziwei1.TransitTime = new DateEntity(DateTime.Now);
                    #endregion
                    m_ziwei1 = ZiWeiBiz.GetInstance().TimeToZiWei(m_ziwei.BirthTime, m_ziwei.Gender, _paras);
                    ret.Chart.Add(m_ziwei1);
                }
            }
            #endregion
            ret.Context = input["Context"].ToString();
            if (input["NickName"] == null)
            {
                USR_CustomerMod m_customer = USR_CustomerBll.GetInstance().GetModel(int.Parse(input["CustomerSysNo"].ToString()));

                ret.CustomerNickName = m_customer.NickName;
                ret.CustomerPhoto = m_customer.Photo;
            }
            else
            {
                ret.CustomerNickName = input["NickName"].ToString();
                ret.CustomerPhoto = input["Photo"].ToString();
            }
            if (input["CustomerSysNo"].ToString() != "")
            {
                ret.CustomerSysNo = int.Parse(input["CustomerSysNo"].ToString());
            }
            ret.DR = int.Parse(input["DR"].ToString());
            if (input["EndTime"].ToString() != "")
            {
                ret.EndTime = DateTime.Parse(input["EndTime"].ToString());
            }
            if (input["IsSecret"].ToString() != "")
            {
                ret.IsSecret = int.Parse(input["IsSecret"].ToString());
            }
            if (input["LastReplyTime"].ToString() != "")
            {
                ret.LastReplyTime = DateTime.Parse(input["LastReplyTime"].ToString());
            }
            if (input["LastReplyUser"].ToString() != "")
            {
                ret.LastReplyUser = int.Parse(input["LastReplyUser"].ToString());
            }
            if (input["ReadCount"].ToString() != "")
            {
                ret.ReadCount = int.Parse(input["ReadCount"].ToString());
            }
            if (input["ReplyCount"].ToString() != "")
            {
                ret.ReplyCount = int.Parse(input["ReplyCount"].ToString());
            }
            if (input["SysNo"].ToString() != "")
            {
                ret.SysNo = int.Parse(input["SysNo"].ToString());
            }
            ret.Title = input["Title"].ToString();
            if (input["TS"].ToString() != "")
            {
                ret.TS = DateTime.Parse(input["TS"].ToString());
            }

            return ret;
        }

        public QA_AnswerShow MapQA_AnswerShow(DataRow input)
        {
            QA_AnswerShow ret = new QA_AnswerShow();

            if (input["Award"].ToString() != "")
            {
                ret.Award = int.Parse(input["Award"].ToString());
            }
            ret.Context = input["Context"].ToString();
            if (input["CustomerSysNo"].ToString() != "")
            {
                ret.CustomerSysNo = int.Parse(input["CustomerSysNo"].ToString());
            }
            if (input["DR"].ToString() != "")
            {
                ret.DR = int.Parse(input["DR"].ToString());
            }
            if (input["Hate"].ToString() != "")
            {
                ret.Hate = int.Parse(input["Hate"].ToString());
            }
            if (input["Love"].ToString() != "")
            {
                ret.Love = int.Parse(input["Love"].ToString());
            }
            if (input["QuestionSysNo"].ToString() != "")
            {
                ret.QuestionSysNo = int.Parse(input["QuestionSysNo"].ToString());
            }
            if (input["SysNo"].ToString() != "")
            {
                ret.SysNo = int.Parse(input["SysNo"].ToString());
            }
            ret.Title = input["Title"].ToString();
            if (input["TS"].ToString() != "")
            {
                ret.TS = DateTime.Parse(input["TS"].ToString()).ToMilliSecondsFrom1970L()/1000;
            }
            return ret;
        }

        public QA_CommentShow MapQA_CommentShow(DataRow input)
        {
            QA_CommentShow ret = new QA_CommentShow();
            USR_CustomerMaintain tmpuu = new USR_CustomerMaintain();
            USR_CustomerBll.GetInstance().GetModel(int.Parse(input["CustomerSysNo"].ToString())).MemberwiseCopy(tmpuu);
            ret.Customer = tmpuu;
            if (input["AnswerSysNo"].ToString() != "")
            {
                ret.AnswerSysNo = int.Parse(input["AnswerSysNo"].ToString());
            }
            ret.Context = input["Context"].ToString();
            if (input["CustomerSysNo"].ToString() != "")
            {
                ret.CustomerSysNo = int.Parse(input["CustomerSysNo"].ToString());
            }
            if (input["DR"].ToString() != "")
            {
                ret.DR = int.Parse(input["DR"].ToString());
            }
            if (input["QuestionSysNo"].ToString() != "")
            {
                ret.QuestionSysNo = int.Parse(input["QuestionSysNo"].ToString());
            }
            if (input["SysNo"].ToString() != "")
            {
                ret.SysNo = int.Parse(input["SysNo"].ToString());
            }
            if (input["TS"].ToString() != "")
            {
                ret.TS = DateTime.Parse(input["TS"].ToString());
            }
            return ret;
        }

        #endregion

    }

}