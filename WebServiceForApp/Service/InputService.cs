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
            m_quest.Context = SQLData.SQLFilter(AppCmn.CommonTools.StringFilter(input.Context));
            m_quest.CustomerSysNo = input.CustomerSysNo;
            m_quest.LastReplyTime = DateTime.Now;
            m_quest.ReplyCount = 0;
            m_quest.ReadCount = 0;
            m_quest.BuyCount = 0;
            m_quest.OrderCount = 0;
            m_quest.Title = AppCmn.CommonTools.SystemInputFilter(input.Title);
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
                input.IsDayLight = AppEnum.BOOL.False;
                input.zone = -8;

                input.birth1 = DateTime.Now.AddDays(-300);
                input.position1 = new LatLng(SYS_DistrictBll.GetInstance().GetModel(37));
                input.IsDayLight1 = AppEnum.BOOL.False;
                input.zone1 = -8;
                input.type = PublicValue.AstroType.benming;
                input.compose = PublicValue.AstroZuhe.bijiao;
            }
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


            //input.graphicID = AstroBiz.GetInstance().SetGraphicID(input);

            if ((input.type == PublicValue.AstroType.hepan && input.compose == PublicValue.AstroZuhe.bijiao) || (input.type == PublicValue.AstroType.tuiyun && input.transit == PublicValue.AstroTuiyun.xingyun))
            {
                AstroMod tmpinput = new AstroMod();
                tmpinput.aspectsShow = input.aspectsShow;
                tmpinput.startsShow = input.startsShow;
                tmpinput.birth = input.birth;
                tmpinput.position = input.position;
                tmpinput.IsDayLight = input.IsDayLight;
                tmpinput.zone = input.zone;
                AstroBiz.GetInstance().GetParamters(ref tmpinput);
                input.Stars = tmpinput.Stars;

                tmpinput = new AstroMod();
                tmpinput.aspectsShow = input.aspectsShow;
                tmpinput.startsShow = input.startsShow;
                tmpinput.birth = input.birth1;
                tmpinput.position = input.position1;
                tmpinput.IsDayLight = input.IsDayLight1;
                tmpinput.zone = input.zone1;
                AstroBiz.GetInstance().GetParamters(ref tmpinput);
                input.Stars1 = tmpinput.Stars;
            }
            else
            {
                AstroBiz.GetInstance().GetParamters(ref input);
                input.Stars1 = null;
            }
            return ReturnValue<AstroMod>.Get200OK(input);
        }

        public ReturnValue<ZiWeiMod> TimeToZiWei(Stream openPageData)
        {
            ZiWeiMod input = new ZiWeiMod();
            int nReadCount = 0;
            MemoryStream ms = new MemoryStream();
            byte[] buffer = new byte[1024];
            while ((nReadCount = openPageData.Read(buffer, 0, 1024)) > 0)
            {
                ms.Write(buffer, 0, nReadCount);
            }
            byte[] byteJson = ms.ToArray();
            string textJson = System.Text.Encoding.Default.GetString(byteJson);

            input = (ZiWeiMod)XMS.Core.Json.JsonSerializer.Deserialize(textJson, typeof(ZiWeiMod));
            int[] _paras = { 1, 1, 0, 1 };
            if (input == null)
            {
                input = new ZiWeiMod();
                input.BirthTime = new PPLive.DateEntity(DateTime.Now);
                input.Gender = AppEnum.Gender.male;
                input.Type = 1;
                input.TransitTime = new DateEntity(new DateTime(2020, 1, 1));
            }
            else
            {
                _paras[0] = input.YueMa;
                _paras[1] = input.MingShenZhu;
                _paras[2] = input.ShiShang;
                _paras[3] = input.HuanYun;
                if (input.IsDayLight)
                {
                    input.BirthTime = new DateEntity(input.BirthTime.Date.AddHours(-1));
                }
                if (input.RealTime)
                {
                    input.BirthTime = new DateEntity(PublicDeal.GetInstance().RealTime(input.BirthTime.Date, new LatLng("30.00", input.Longitude, input.AreaName)));
                }
                else
                {
                    input.BirthTime = new PPLive.DateEntity(input.BirthTime.Date);
                }
                
            }
            if (input.Type == 0)
            {
                input = ZiWeiBiz.GetInstance().TimeToZiWei(input.BirthTime, input.Gender, _paras);
            }
            else
            {
                input = ZiWeiBiz.GetInstance().TransitToZiWei(input.BirthTime, input.TransitTime, input.Gender, _paras);
            }
            return ReturnValue<ZiWeiMod>.Get200OK(input);
        }

        public ReturnValue<BaZiMod> TimeToBaZi(Stream openPageData)
        {
            BaZiMod input = new BaZiMod();
            int nReadCount = 0;
            MemoryStream ms = new MemoryStream();
            byte[] buffer = new byte[1024];
            while ((nReadCount = openPageData.Read(buffer, 0, 1024)) > 0)
            {
                ms.Write(buffer, 0, nReadCount);
            }
            byte[] byteJson = ms.ToArray();
            string textJson = System.Text.Encoding.Default.GetString(byteJson);

            input = (BaZiMod)XMS.Core.Json.JsonSerializer.Deserialize(textJson, typeof(BaZiMod));



            if (input == null)
            {
                input = new BaZiMod();
                input.BirthTime = new PPLive.DateEntity(DateTime.Now);
                input.Gender = AppEnum.Gender.male;
                input.RealTime = false;
            }
            else
            {
                if (input.IsDayLight)
                {
                    input.BirthTime = new DateEntity(input.BirthTime.Date.AddHours(-1));
                }
                if (input.RealTime)
                {
                    input.BirthTime = new DateEntity(PublicDeal.GetInstance().RealTime(input.BirthTime.Date, new LatLng("30.00",input.Longitude,input.AreaName)));
                }
                else
                {
                    input.BirthTime = new PPLive.DateEntity(input.BirthTime.Date);
                }
            }

            BaZiBiz.GetInstance().TimeToBaZi(ref input);
            return ReturnValue<BaZiMod>.Get200OK(input);
        }

    }
}