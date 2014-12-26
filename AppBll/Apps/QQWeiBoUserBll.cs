using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppMod.Apps;
using AppDal.Apps;
using AppCmn;

namespace AppBll.Apps
{
    public class QQWeiBoUserBll
    {
        private readonly QQWeiBoUserDal dal = new QQWeiBoUserDal();
        private static QQWeiBoUserBll _instance;
        public static QQWeiBoUserBll GetInstance()
        {
            if (_instance == null)
            {
                _instance = new QQWeiBoUserBll();
            }
            return _instance;
        }
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(QQWeiBoUserMod model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public void Update(QQWeiBoUserMod model)
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

        public QQWeiBoUserMod GetModel(int SysNo)
        {
            return dal.GetModel(SysNo);
        }
        #endregion  成员方法

        #region 扩展成员方法
        public QQWeiBoUserMod GetRecordByName(string name)
        {
            QQWeiBoUserMod model = new QQWeiBoUserMod();
            using (SQLData data = new SQLData())
            {
                StringBuilder builder = new StringBuilder();
                builder.Append("select SysNo from Apps.dbo.QQWeiBoUser where WB_Name='").Append(SQLData.SQLFilter(name) + "'");
                try
                {
                    model.SysNo = int.Parse(data.CmdtoDataRow(builder.ToString())["SysNo"].ToString());
                }
                catch (Exception)
                {
                }
            }
            if (model.SysNo != -999999)
            {
                model = this.GetModel(model.SysNo);
            }
            return model;
        }

 

 

        #endregion 
    }

}
