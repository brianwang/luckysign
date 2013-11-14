using System;
using System.Data;
using AppMod.Fate;
using AppDal.Fate;
using AppCmn;

namespace AppBll.Fate
{
    public class FATE_ChartBll
    {
        private readonly FATE_ChartDal dal = new FATE_ChartDal();
        private FATE_ChartBll()
        {
        }
        private static FATE_ChartBll _instance;
        public static FATE_ChartBll GetInstance()
        {
            if (_instance == null)
            {
                _instance = new FATE_ChartBll();
            }
            return _instance;
        }
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(FATE_ChartMod model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public void UpDate(FATE_ChartMod model)
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

        public FATE_ChartMod GetModel(int SysNo)
        {
            return dal.GetModel(SysNo);
        }
        #endregion  成员方法
    }

}
