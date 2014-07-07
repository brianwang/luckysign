using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using XMS.Core;
using AppCmn;
using AppMod.WebSys;
using AppBll.WebSys;
using System.IO;
using System.Configuration;
using System.Data;

namespace WebServiceForApp
{
    public class SystemService : ISystemService
    {
        public ReturnValue<SYS_DistrictMod> GetDistrictByPoi(string longitude, string latitude)
        {
            if (string.IsNullOrEmpty(longitude) || string.IsNullOrEmpty(latitude))
            {
                throw new BusinessException("经纬度不可为空");
            }

            SYS_DistrictMod m_dist = SYS_DistrictBll.GetInstance().GetNearestByPoi(longitude, latitude);

            if (m_dist == null)
            {
                throw new BusinessException("无法搜到结果!");
            }
            return ReturnValue<SYS_DistrictMod>.Get200OK(m_dist);
        }
    }
}
