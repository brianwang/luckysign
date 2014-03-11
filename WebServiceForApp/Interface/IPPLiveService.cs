using System;
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
using PPLive;

namespace WebServiceForApp
{
    [ServiceContract(Namespace = "http://api.ssqian.com/QA")]
    [ServiceKnownType(typeof(BaZiDaYun))]
    [ServiceKnownType(typeof(DateEntity))]
    [ServiceKnownType(typeof(PublicValue.TianGan))]
    [ServiceKnownType(typeof(PublicValue.DiZhi))]
    [ServiceKnownType(typeof(PublicValue.ShuXing))]
    [ServiceKnownType(typeof(AppCmn.AppEnum.Gender))]
    [ServiceKnownType(typeof(PublicValue.ZiWeiChangSheng))]
    [ServiceKnownType(typeof(PublicValue.AllJieQi))]
    [ServiceKnownType(typeof(PublicValue.Nayin))]
    [ServiceKnownType(typeof(PublicValue.ShiShen))]
    [ServiceKnownType(typeof(PublicValue.NongliMonth))]
    [ServiceKnownType(typeof(PublicValue.NongliDay))]
    public interface IPPLiveService
    {
        [OperationContract, WebGet(UriTemplate = "/TimeToBaZi")]
        [Description("排八字命盘,/TimeToBaZi")]
        ReturnValue<BaZiMod> TimeToBaZi();

        [OperationContract, WebInvoke(UriTemplate = "/TimeToZiWei")]
        [Description("排紫薇命盘,/TimeToZiWei")]
        ReturnValue<ZiWeiMod> TimeToZiWei(Stream openPageData);

        [OperationContract, WebInvoke(UriTemplate = "/TimeToAstro")]
        [Description("排占星命盘,/TimeToAstro")]
        ReturnValue<AstroMod> TimeToAstro(Stream openPageData);


        [OperationContract, WebGet(UriTemplate = "/Hello")]
        [Description("测试,/Hello")]
        ReturnValue<DateEntity> Hello();
    }

}
