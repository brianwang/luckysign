using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.ComponentModel;

using XMS.Core;

using AppMod.QA;
using AppDal.QA;

namespace WebServiceForApp
{
    [ServiceContract(Namespace = "http://api.ssqian.com/QA")]
    public interface IQAService
    {
        [OperationContract, WebGet(UriTemplate = "/GetCates?parent={parent}")]
        [Description("获取目录列表,/GetCates?parent={parent}")]
        ReturnValue<List<QA_CategoryMod>> GetCates(int parent);

        [OperationContract, WebGet(UriTemplate = "/GetStarsList?count={count}&type={type}")]
        [Description("获取明星列表,/GetStarsList?count={count}&type={type}")]
        ReturnValue<Dictionary<int, QA_CategoryMod>> GetCates(int parent);


    }

}
