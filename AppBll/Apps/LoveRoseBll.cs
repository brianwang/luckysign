﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppMod.Apps;
using AppDal.Apps;
using AppCmn;

namespace AppBll.Apps
{
    public class LoveRoseBll
    {
        private readonly LoveRoseDal dal = new LoveRoseDal();
        private static LoveRoseBll _instance;
        public static LoveRoseBll GetInstance()
        {
            if (_instance == null)
            {
                _instance = new LoveRoseBll();
            }
            return _instance;
        }
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(LoveRoseMod model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public void Update(LoveRoseMod model)
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

        public LoveRoseMod GetModel(int SysNo)
        {
            return dal.GetModel(SysNo);
        }
        #endregion  成员方法
    }

}
