using System;
using System.Data;
using AppMod.QA;
using AppDal.QA;
using AppCmn;

namespace AppBll.QA
{
    public class REL_Question_ChartBll
    {
        private readonly REL_Question_ChartDal dal = new REL_Question_ChartDal();
        private REL_Question_ChartBll()
        {
        }
        private static REL_Question_ChartBll _instance;
        public static REL_Question_ChartBll GetInstance()
        {
            if (_instance == null)
            {
                _instance = new REL_Question_ChartBll();
            }
            return _instance;
        }
        #region  基础成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(REL_Question_ChartMod model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public void UpDate(REL_Question_ChartMod model)
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

        public REL_Question_ChartMod GetModel(int SysNo)
        {
            return dal.GetModel(SysNo);
        }
        #endregion  基础成员方法

        #region  扩展成员方法


        #endregion  扩展成员方法
    }

}
