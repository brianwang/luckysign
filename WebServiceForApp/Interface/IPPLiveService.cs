﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.ComponentModel;
using System.IO;
using XMS.Core;
using PPLive.BaZi;
using PPLive.Astro;
using PPLive.ZiWei;

namespace WebServiceForApp
{
     [ServiceContract(Namespace = "http://api.ssqian.com/QA")]
    public interface IPPLiveService
    {
        [OperationContract,WebGet(UriTemplate = "/TimeToBaZi")]
        [Description("排八字命盘,/TimeToBaZi")]
        ReturnValue<BaZiMod> TimeToBaZi();

        [OperationContract, WebInvoke(UriTemplate = "/TimeToZiWei")]
        [Description("排紫薇命盘,/TimeToZiWei")]
        ReturnValue<ZiWeiMod> TimeToZiWei(Stream openPageData);

        [OperationContract, WebInvoke(UriTemplate = "/TimeToAstro")]
        [Description("排占星命盘,/TimeToAstro")]
        ReturnValue<AstroMod> TimeToAstro(Stream openPageData);


    }

}
