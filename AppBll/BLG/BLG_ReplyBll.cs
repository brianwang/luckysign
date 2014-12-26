using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppMod.BLG;
using AppDal.BLG;
using AppCmn;

namespace AppBll.BLG
{
    public class BLG_ReplyBll
    {
        private readonly BLG_ReplyDal dal = new BLG_ReplyDal();
        private BLG_ReplyBll()
        {
        }
        private static BLG_ReplyBll _instance;
        public static BLG_ReplyBll GetInstance()
        {
            if (_instance == null)
            {
                _instance = new BLG_ReplyBll();
            }
            return _instance;
        }
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>

        public void Add(BLG_ReplyMod model)
        {
            dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public void Update(BLG_ReplyMod model)
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

        public BLG_ReplyMod GetModel(int SysNo)
        {
            return dal.GetModel(SysNo);
        }
        #endregion  成员方法
    }

}
