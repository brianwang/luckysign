using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.ComponentModel;

using XMS.Core;

using AppMod.WebSys;

namespace WebServiceForApp
{
    [ServiceContract(Namespace = "http://api.ssqian.com/System")]
    public interface ISystemService
    {
        [OperationContract, WebGet(UriTemplate = "/GetDistrictByPoi?longitude={longitude}&latitude={latitude}")]
        [Description("根据经纬度获取最近地区,/GetDistrictByPoi")]
        ReturnValue<SYS_DistrictMod> GetDistrictByPoi(string longitude, string latitude);

    }

}
