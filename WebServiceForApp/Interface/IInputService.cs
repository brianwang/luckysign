using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.ComponentModel;
using System.IO;
using XMS.Core;
using AppMod.User;
using AppMod.QA;
using AppMod.WebSys;
using AppDal.QA;
using PPLive.Astro;
using PPLive.BaZi;
using PPLive.ZiWei;

namespace WebServiceForApp
{
    [ServiceContract(Namespace = "http://api.ssqian.com/Input")]
    public interface IInputService
    {

        [OperationContract, WebInvoke(UriTemplate = "/AddQuestionWithChart")]
        [Description("发布问题,/AddQuestionWithChart")]
        ReturnValue<USR_CustomerShow> AddQuestionWithChart(Stream openPageData);

        [OperationContract, WebInvoke(UriTemplate = "/TimeToAstro")]
        [Description("排占星命盘,/TimeToAstro")]
        ReturnValue<AstroMod> TimeToAstro(Stream openPageData);

        [OperationContract, WebInvoke(UriTemplate = "/TimeToBaZi")]
        [Description("排八字命盘,/TimeToBaZi")]
        ReturnValue<BaZiMod> TimeToBaZi(Stream openPageData);

        [OperationContract, WebInvoke(UriTemplate = "/TimeToZiWei")]
        [Description("排紫薇命盘,/TimeToZiWei")]
        ReturnValue<ZiWeiMod> TimeToZiWei(Stream openPageData);
    }

}
