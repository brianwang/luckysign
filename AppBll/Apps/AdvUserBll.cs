using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppMod.Apps;
using AppDal.Apps;
using AppCmn;

namespace AppBll.Apps
{
    public class AdvUserBll
    {
        private readonly AdvUserDal dal = new AdvUserDal();
        private static AdvUserBll _instance;
        public static AdvUserBll GetInstance()
        {
            if (_instance == null)
            {
                _instance = new AdvUserBll();
            }
            return _instance;
        }
        #region  基础成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(AdvUserMod model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public void UpDate(AdvUserMod model)
        {
            dal.UpDate(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>

        public void Delete(int SysNo)
        {
            dal.Delete(SysNo);
        }
        /// <summary>
        ///  得到一个对象实体
        /// </summary>

        public AdvUserMod GetModel(int SysNo)
        {
            return dal.GetModel(SysNo);
        }
        #endregion  成员方法

        #region 扩展成员方法
        public AdvUserMod GetModel(string phonenum)
        {
            AdvUserMod model = new AdvUserMod();
            using (SQLData data = new SQLData())
            {
                StringBuilder builder = new StringBuilder();
                builder.Append("select SysNo from AdvUser where CellPhone='").Append(SQLData.SQLFilter(phonenum)).Append("' and DR=").Append((int)AppEnum.State.normal);
                try
                {
                    model.SysNo = int.Parse(data.CmdtoDataRow(builder.ToString())["SysNo"].ToString());
                }
                catch (Exception exception)
                {
                    //throw exception;
                }
            }
            if (model.SysNo != AppConst.IntNull)
            {
                model = this.GetModel(model.SysNo);
            }
            return model;
        }

        #endregion
    }

}
