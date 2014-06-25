using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using AppMod.User;
using AppDal.User;
using AppCmn;

namespace AppBll.User
{
    public class USR_ThirdLoginBll
    {
        private readonly USR_ThirdLoginDal dal = new USR_ThirdLoginDal();
        private USR_ThirdLoginBll()
        {
        }
        private static USR_ThirdLoginBll _instance;
        public static USR_ThirdLoginBll GetInstance()
        {
            if (_instance == null)
            {
                _instance = new USR_ThirdLoginBll();
            }
            return _instance;
        }
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(USR_ThirdLoginMod model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public void Update(USR_ThirdLoginMod model)
        {
            dal.Update(model);
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

        public USR_ThirdLoginMod GetModel(int SysNo)
        {
            return dal.GetModel(SysNo);
        }
        #endregion  成员方法
    }

}
