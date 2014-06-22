using System;
using System.Data;
using AppMod.QA;
using AppDal.QA;
using AppCmn;
namespace AppBll.QA
{
    public class QA_OrderBll
    {
        private readonly QA_OrderDal dal = new QA_OrderDal();
        private static QA_OrderBll _instance;
        public QA_OrderBll GetInstance()
        {
            if (_instance == null)
            { _instance = new QA_OrderBll(); }
            return _instance;
        }
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(QA_OrderMod model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public void Update(QA_OrderMod model)
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

        public QA_OrderMod GetModel(int SysNo)
        {
            return dal.GetModel(SysNo);
        }
        #endregion  成员方法
    }
}
