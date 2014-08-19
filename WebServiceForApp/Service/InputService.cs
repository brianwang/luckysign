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
using PPLive.Astro;
using PPLive.BaZi;
using PPLive.ZiWei;
using AppBll.WebSys;
using PPLive;

namespace WebServiceForApp
{
    public class InputService : IInputService
    {
        public ReturnValue<USR_CustomerShow> AddQuestionWithChart(Stream openPageData)
        {
            QA_QuestionInput<FATE_ChartMod> input;
            //try
            //{
            int nReadCount = 0;
            MemoryStream ms = new MemoryStream();
            byte[] buffer = new byte[1024];
            while ((nReadCount = openPageData.Read(buffer, 0, 1024)) > 0)
            {
                ms.Write(buffer, 0, nReadCount);
            }
            byte[] byteJson = ms.ToArray();
            string textJson = System.Text.Encoding.UTF8.GetString(byteJson);

            input = XMS.Core.Json.JsonSerializer.Deserialize<QA_QuestionInput<FATE_ChartMod>>(textJson);

            if (input == null)
            {
                throw new BusinessException("参数有误");
            }
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}

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

            //try
            //{
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
            if (input.Chart.Count > 0)
            {
                FATE_ChartMod m_chart = new FATE_ChartMod();
                m_chart.CharType = input.Chart[0].CharType; ;
                if (m_chart.CharType != (int)AppEnum.ChartType.nochart)
                {
                    m_chart.FirstBirth = input.Chart[0].FirstBirth;
                    m_chart.FirstPoi = input.Chart[0].FirstPoi;
                    m_chart.Transit = DateTime.Now;
                    m_chart.TransitPoi = input.Chart[0].FirstPoi;
                    m_chart.TheoryType = 0;
                    m_chart.FirstPoiName = input.Chart[0].FirstPoiName;
                    m_chart.FirstTimeZone = -8;
                    m_chart.FirstGender = input.Chart[0].FirstGender;
                    m_chart.FirstDayLight = input.Chart[0].FirstDayLight;
                    if (m_chart.CharType == (int)AppEnum.ChartType.relation)
                    {
                        m_chart.SecondBirth = input.Chart[0].SecondBirth;
                        m_chart.SecondPoi = input.Chart[0].SecondPoi;
                        m_chart.SecondPoiName = input.Chart[0].SecondPoiName;
                        m_chart.SecondTimeZone = -8;
                        m_chart.SecondGender = input.Chart[0].SecondGender;
                        m_chart.SecondDayLight = input.Chart[0].SecondDayLight;
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
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}

            USR_CustomerShow ret = new USR_CustomerShow();
            USR_CustomerBll.GetInstance().GetModel(input.CustomerSysNo).MemberwiseCopy(ret);
            return ReturnValue<USR_CustomerShow>.Get200OK(ret);

        }

        public ReturnValue<AstroMod> TimeToAstro(Stream openPageData)
        {
            AstroMod input = null;
            int nReadCount = 0;
            MemoryStream ms = new MemoryStream();
            byte[] buffer = new byte[1024];
            while ((nReadCount = openPageData.Read(buffer, 0, 1024)) > 0)
            {
                ms.Write(buffer, 0, nReadCount);
            }
            byte[] byteJson = ms.ToArray();
            string textJson = System.Text.Encoding.UTF8.GetString(byteJson);

            if (!string.IsNullOrEmpty(textJson))
            {
                input = XMS.Core.Json.JsonSerializer.Deserialize<AstroMod>(textJson);
            }

            if (input == null)
            {
                input = new AstroMod();
                input.birth = DateTime.Now;
                input.position = new LatLng(SYS_DistrictBll.GetInstance().GetModel(37));
                input.IsDaylight = AppEnum.BOOL.False;
                input.zone = -8;
                input.startsShow.Clear();
                for (int i = 1; i <= 30; i++)
                {
                    input.startsShow.Add(i, PublicValue.GetAstroStar((PublicValue.AstroStar)i));
                }
                input.aspectsShow.Clear();
                input.aspectsShow.Add(1, 0);
                input.aspectsShow.Add(2, 180);
                input.aspectsShow.Add(4, 120);
                input.aspectsShow.Add(3, 90);
                input.aspectsShow.Add(5, 60);
            }

            input.graphicID = AstroBiz.GetInstance().SetGraphicID(input);
            AstroBiz.GetInstance().GetParamters(ref input);
            return ReturnValue<AstroMod>.Get200OK(input);
        }

    }
}