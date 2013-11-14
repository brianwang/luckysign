using System;
using System.Data;
using AppMod.User;
using AppDal.User;
using AppCmn;

namespace AppBll.User
{
    public class USR_RecordBll
    {
        private readonly USR_RecordDal dal = new USR_RecordDal();
        private USR_RecordBll()
        {
        }
        private static USR_RecordBll _instance;
        public static USR_RecordBll GetInstance()
        {
            if (_instance == null)
            {
                _instance = new USR_RecordBll();
            }
            return _instance;
        }
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(USR_RecordMod model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public void UpDate(USR_RecordMod model)
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

        public USR_RecordMod GetModel(int SysNo)
        {
            return dal.GetModel(SysNo);
        }
        #endregion  成员方法
    }

}
