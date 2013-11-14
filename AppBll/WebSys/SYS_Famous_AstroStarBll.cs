using System;
using System.Data;
using AppMod.WebSys;
using AppDal.WebSys;
using AppCmn;

namespace AppBll.WebSys
{
    public class SYS_Famous_AstroStarBll
    {
        private readonly SYS_Famous_AstroStarDal dal = new SYS_Famous_AstroStarDal();
        private SYS_Famous_AstroStarBll()
        {
        }
        private static SYS_Famous_AstroStarBll _instance;
        public static SYS_Famous_AstroStarBll GetInstance()
        {
            if (_instance == null)
            {
                _instance = new SYS_Famous_AstroStarBll();
            }
            return _instance;
        }
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(SYS_Famous_AstroStarMod model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public void UpDate(SYS_Famous_AstroStarMod model)
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

        public SYS_Famous_AstroStarMod GetModel(int SysNo)
        {
            return dal.GetModel(SysNo);
        }
        #endregion  成员方法
    }

}
