﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using XMS.Core;
using AppCmn;
using System.IO;
using System.Configuration;
using System.Data;
using System.Web;
using PPLive.BaZi;
using PPLive.Astro;
using PPLive.ZiWei;
using PPLive;
using AppBll.WebSys;


namespace WebServiceForApp
{
    public class PPLiveService : IPPLiveService
    {
        public ReturnValue<BaZiMod> TimeToBaZi()
        {
            BaZiMod input = new BaZiMod();
            //int nReadCount = 0;
            //MemoryStream ms = new MemoryStream();
            //byte[] buffer = new byte[1024];
            //while ((nReadCount = openPageData.Read(buffer, 0, 1024)) > 0)
            //{
            //    ms.Write(buffer, 0, nReadCount);
            //}
            //byte[] byteJson = ms.ToArray();
            //string textJson = System.Text.Encoding.Default.GetString(byteJson);

            //input = (BaZiMod)XMS.Core.Json.JsonSerializer.Deserialize(textJson, typeof(BaZiMod));

            //if (input == null)
            //{
                input.BirthTime = new PPLive.DateEntity(DateTime.Now);
                input.Gender = AppEnum.Gender.male;
                input.RealTime = false;
            //}

            BaZiBiz.GetInstance().TimeToBaZi(ref input);
            return ReturnValue<BaZiMod>.Get200OK(input);
        }

        public ReturnValue<AstroMod> TimeToAstro()
        {
            AstroMod input = new AstroMod();
            //int nReadCount = 0;
            //MemoryStream ms = new MemoryStream();
            //byte[] buffer = new byte[1024];
            //while ((nReadCount = openPageData.Read(buffer, 0, 1024)) > 0)
            //{
            //    ms.Write(buffer, 0, nReadCount);
            //}
            //byte[] byteJson = ms.ToArray();
            //string textJson = System.Text.Encoding.Default.GetString(byteJson);

            //input = (AstroMod)XMS.Core.Json.JsonSerializer.Deserialize(textJson, typeof(AstroMod));

            //if (input == null)
            //{
                input.birth = DateTime.Now;
                input.position = new LatLng(SYS_DistrictBll.GetInstance().GetModel(37));
                
                    input.IsDaylight = AppEnum.BOOL.False;

                    input.zone = -8;
                    input.startsShow.Clear();
                for (int i = 1; i <=30; i++)
                {
                        input.startsShow.Add(i, PublicValue.GetAstroStar((PublicValue.AstroStar)i));
                }
                input.aspectsShow.Clear();
                input.aspectsShow.Add(1, 0);
                input.aspectsShow.Add(2, 180);
                input.aspectsShow.Add(4, 120);
                input.aspectsShow.Add(3, 90);
                input.aspectsShow.Add(5, 60);
            //}

            input.graphicID = AstroBiz.GetInstance().SetGraphicID(input);
            AstroBiz.GetInstance().GetParamters(ref input);
            return ReturnValue<AstroMod>.Get200OK(input);
        }

        public ReturnValue<ZiWeiMod> TimeToZiWei()
        {
            ZiWeiMod input = new ZiWeiMod();
            //int nReadCount = 0;
            //MemoryStream ms = new MemoryStream();
            //byte[] buffer = new byte[1024];
            //while ((nReadCount = openPageData.Read(buffer, 0, 1024)) > 0)
            //{
            //    ms.Write(buffer, 0, nReadCount);
            //}
            //byte[] byteJson = ms.ToArray();
            //string textJson = System.Text.Encoding.Default.GetString(byteJson);

            //input = (ZiWeiMod)XMS.Core.Json.JsonSerializer.Deserialize(textJson, typeof(ZiWeiMod));

            //if (input == null)
            //{
                input.BirthTime = new PPLive.DateEntity(DateTime.Now);
                input.Gender = AppEnum.Gender.male;
                input.TransitTime = new DateEntity(new DateTime(2020,1,1));
            //}

            int[] _paras = {1,1,0,1};
            input = ZiWeiBiz.GetInstance().TransitToZiWei(input.BirthTime,input.TransitTime, input.Gender, _paras);
            return ReturnValue<ZiWeiMod>.Get200OK(input);
        }



        public ReturnValue<BaZiDaYun> Hello()
        {
            return ReturnValue<BaZiDaYun>.Get200OK(new BaZiDaYun());
        }

    }

}
