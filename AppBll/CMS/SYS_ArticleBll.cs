using System;
using System.Data;
using AppMod.CMS;
using AppDal.CMS;
using AppCmn;
using System.Web;
using System.Text;
using System.Collections.Generic;

namespace AppBll.CMS
{
    public class SYS_ArticleBll
    {
        private readonly SYS_ArticleDal dal = new SYS_ArticleDal();
        private SYS_ArticleBll()
        {
        }
        private static SYS_ArticleBll _instance;
        public static SYS_ArticleBll GetInstance()
        {
            if (_instance == null)
            {
                _instance = new SYS_ArticleBll();
            }
            return _instance;
        }
        #region  基础成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(SYS_ArticleMod model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public void UpDate(SYS_ArticleMod model)
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

        public SYS_ArticleMod GetModel(int SysNo)
        {
            return dal.GetModel(SysNo);
        }
        #endregion  基础成员方法

        
    }

}
