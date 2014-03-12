using System;
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

            //BaZiBiz.GetInstance().TimeToBaZi(ref input);
            return ReturnValue<BaZiMod>.Get200OK(input);
        }

        public ReturnValue<AstroMod> TimeToAstro(Stream openPageData)
        {
            AstroMod input;
            int nReadCount = 0;
            MemoryStream ms = new MemoryStream();
            byte[] buffer = new byte[1024];
            while ((nReadCount = openPageData.Read(buffer, 0, 1024)) > 0)
            {
                ms.Write(buffer, 0, nReadCount);
            }
            byte[] byteJson = ms.ToArray();
            string textJson = System.Text.Encoding.Default.GetString(byteJson);

            input = (AstroMod)XMS.Core.Json.JsonSerializer.Deserialize(textJson, typeof(AstroMod));

            if (input == null)
            {
                throw new BusinessException("参数有误");
            }

            input.graphicID = AstroBiz.GetInstance().SetGraphicID(input);
            AstroBiz.GetInstance().GetParamters(ref input);
            return ReturnValue<AstroMod>.Get200OK(input);
        }

        public ReturnValue<ZiWeiMod> TimeToZiWei(Stream openPageData)
        {
            ZiWeiMod input;
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

            if (input == null)
            {
                throw new BusinessException("参数有误");
            }

            int[] _paras = {1,1,0,0};
            input = ZiWeiBiz.GetInstance().TimeToZiWei(input.BirthTime, input.Gender, _paras);
            return ReturnValue<ZiWeiMod>.Get200OK(input);
        }



        public ReturnValue<BaZiDaYun> Hello()
        {
            return ReturnValue<BaZiDaYun>.Get200OK(new BaZiDaYun());
        }

    }

}
