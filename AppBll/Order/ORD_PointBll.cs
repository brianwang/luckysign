using System;
using System.Data;
using AppMod.Order;
using AppDal.Order;
using AppCmn;
namespace AppBll.Order
{
    public class ORD_PointBll
    {
        private readonly ORD_PointDal dal = new ORD_PointDal();
        private static ORD_PointBll _instance;
        public static ORD_PointBll GetInstance()
        {
            if (_instance == null)
            { _instance = new ORD_PointBll(); }
            return _instance;
        }
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(ORD_PointMod model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public void Update(ORD_PointMod model)
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

        public ORD_PointMod GetModel(int SysNo)
        {
            return dal.GetModel(SysNo);
        }
        #endregion  成员方法
    }
}
