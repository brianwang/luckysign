using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppMod.Fate;
using AppDal.Fate;
using AppCmn;

namespace AppBll.Fate
{
    public class FATE_AstroBll
    {
        private readonly FATE_AstroDal dal = new FATE_AstroDal();
        private FATE_AstroBll()
        {
        }
        private static FATE_AstroBll _instance;
        public static FATE_AstroBll GetInstance()
        {
            if (_instance == null)
            {
                _instance = new FATE_AstroBll();
            }
            return _instance;
        }
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>

        public void Add(FATE_AstroMod model)
        {
            dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public void Update(FATE_AstroMod model)
        {
            dal.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>

        public void Delete(string ID)
        {
            dal.Delete(ID);
        }
        /// <summary>
        ///  得到一个对象实体
        /// </summary>

        public FATE_AstroMod GetModel(string ID)
        {
            return dal.GetModel(ID);
        }
        #endregion  成员方法
    }
}
