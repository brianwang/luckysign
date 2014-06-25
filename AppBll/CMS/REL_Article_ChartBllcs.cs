using System;
using System.Data;
using AppMod.CMS;
using AppDal.CMS;
using AppCmn;

namespace AppBll.CMS
{
    public class REL_Article_ChartBll
    {
        private readonly REL_Article_ChartDal dal = new REL_Article_ChartDal();
        public REL_Article_ChartBll()
        { }
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(REL_Article_ChartMod model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public void Update(REL_Article_ChartMod model)
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

        public REL_Article_ChartMod GetModel(int SysNo)
        {
            return dal.GetModel(SysNo);
        }
        #endregion  成员方法
    }

}
