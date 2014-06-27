using System;
using System.Data;
using AppMod.Order;
using AppDal.Order;
using AppCmn;
namespace AppBll.Order
{
    public class ORD_CashBll
    {
        private readonly ORD_CashDal dal = new ORD_CashDal();
        private static ORD_CashBll _instance;
        public static ORD_CashBll GetInstance()
        {
            if (_instance == null)
            { _instance = new ORD_CashBll(); }
            return _instance;
        }
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(ORD_CashMod model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public void Update(ORD_CashMod model)
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

        public ORD_CashMod GetModel(int SysNo)
        {
            return dal.GetModel(SysNo);
        }
        #endregion  成员方法
    }
}
