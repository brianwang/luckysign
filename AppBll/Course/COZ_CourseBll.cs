using System;
using System.Data;
using AppMod.Course;
using AppDal.Course;
using AppCmn;
namespace AppBll.Course
{
    public class COZ_CourseBll
    {
        private readonly COZ_CourseDal dal = new COZ_CourseDal();
        private static COZ_CourseBll _instance;
        public static COZ_CourseBll GetInstance()
        {
            if (_instance == null)
            { _instance = new COZ_CourseBll(); }
            return _instance;
        }
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(COZ_CourseMod model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public void Update(COZ_CourseMod model)
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

        public COZ_CourseMod GetModel(int SysNo)
        {
            return dal.GetModel(SysNo);
        }
        #endregion  成员方法
    }
}
