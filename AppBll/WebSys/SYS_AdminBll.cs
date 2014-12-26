using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppMod.WebSys;
using AppDal.WebSys;
using AppCmn;
namespace AppBll.WebSys
{
    public class SYS_AdminBll
    {
        private readonly SYS_AdminDal dal = new SYS_AdminDal();
        private SYS_AdminBll()
        {
        }
        private static SYS_AdminBll _instance;
        public static SYS_AdminBll GetInstance()
        {
            if (_instance == null)
            {
                _instance = new SYS_AdminBll();
            }
            return _instance;
        }
        #region  基础成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(SYS_AdminMod model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public void Update(SYS_AdminMod model)
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

        public SYS_AdminMod GetModel(int SysNo)
        {
            return dal.GetModel(SysNo);
        }
        #endregion  成员方法


        #region  扩展成员方法

        public SYS_AdminMod CheckAdmin(string username, string password)
        {
            SYS_AdminMod model = new SYS_AdminMod();
            using (SQLData data = new SQLData())
            {
                StringBuilder builder = new StringBuilder();
                builder.Append("select SysNo from SYS_Admin where Username='").Append(SQLData.SQLFilter(username)).Append("' and Password='").Append(SQLData.SQLFilter(password)).Append("' and DR=").Append(0);
                try
                {
                    model.CustomerSysNo =int.Parse(data.CmdtoDataRow(builder.ToString())["SysNo"].ToString());
                }
                catch (Exception exception)
                {
                    //throw exception;
                }
            }
            if (model.CustomerSysNo != -999999)
            {
                model = this.GetModel(model.CustomerSysNo);
                model.LastLogin = DateTime.Now;
                this.Update(model);
            }
            return model;
        }

        public bool IsAdmin(int customersysno)
        {
            bool ret = false;
            using (SQLData data = new SQLData())
            {
                StringBuilder builder = new StringBuilder();
                builder.Append("select * from SYS_Admin where customersysno=").Append(customersysno).Append(" and DR=").Append(0);
                try
                {
                    if (data.CmdtoDataTable(builder.ToString()).Rows.Count > 0)
                    {
                        ret = true;
                    }
                }
                catch (Exception exception)
                {
                    //throw exception;
                }
            }

            return ret;
        }

        public Dictionary<int, SYS_PrivilegeMod> GetAdminPrivilege(int AdminSysNo)
        {
            DataTable table = new DataTable();
            Dictionary<int, SYS_PrivilegeMod> dictionary = new Dictionary<int, SYS_PrivilegeMod>();
            using (SQLData data = new SQLData())
            {
                StringBuilder builder = new StringBuilder();
                builder.Append("select SysNo,[Name],url from SYS_Privilege where SysNo in (select Privilege_SysNo from REL_Admin_Privilege where Admin_SysNo=").Append(AdminSysNo).Append(") and DR=").Append((int)AppEnum.State.normal);
                try
                {
                    table = data.CmdtoDataTable(builder.ToString());
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    SYS_PrivilegeMod mod = new SYS_PrivilegeMod();
                    mod.Name =table.Rows[i]["Name"].ToString();
                    mod.SysNo = int.Parse(table.Rows[i]["SysNo"].ToString());
                    mod.URL = table.Rows[i]["url"].ToString();
                    dictionary.Add(int.Parse(table.Rows[i]["SysNo"].ToString()), mod);
                }
            }
            return dictionary;
        }

        public DataTable GetList(int pagesize, int pageindex, string name, string status, int privilege, ref int total)
        {
            DataTable m_dt = new DataTable();
            string columns = "";
            string tables = "";
            string where = "";
            string order = "";

            #region  设置参数
            columns = @"SYS_Admin.*,Email,NickName";
            tables = "SYS_Admin left join USR_Customer on Customersysno=USR_Customer.sysno";
            order = "SYS_Admin.SysNo desc";
            where = "1=1";
            if (name != "")
            {
                where += " and ((";
                string[] tmpstr = name.Split(new char[] { ' ' });
                for (int i = 0; i < tmpstr.Length; i++)
                {
                    where += " ([name] like '%" + SQLData.SQLFilter(tmpstr[i]) + "%') and ";
                }
                where += " 1=1) or (";
                for (int i = 0; i < tmpstr.Length; i++)
                {
                    where += " ([Email] like '%" + SQLData.SQLFilter(tmpstr[i]) + "%') and ";
                }
                where += " 1=1) or (";
                for (int i = 0; i < tmpstr.Length; i++)
                {
                    where += " ([NickName] like '%" + SQLData.SQLFilter(tmpstr[i]) + "%') and ";
                }
                where += " 1=1))";
            }
            if (privilege != 0 && privilege != AppConst.IntNull)
            {
                where += " and SYS_Admin.sysno in (select AdminSysNo from Rel_AdminPrivilege where PrivilegeSysNo=" + privilege + ")";
            }
            if (status != "" && status != "100")
            {
                where += " and SYS_Admin.[dr]=" + status;
            }
            #endregion

            using (SQLData m_data = new SQLData())
            {
                m_data.AddParameter("SelectList", columns);
                m_data.AddParameter("TableSource", tables);
                m_data.AddParameter("SearchCondition", where);
                m_data.AddParameter("OrderExpression", order);
                m_data.AddParameter("PageIndex", pageindex);
                m_data.AddParameter("pagesize", pagesize);
                DataSet m_ds = m_data.SPtoDataSet("GetRecordFromPage");
                if (m_ds.Tables.Count == 2)
                {
                    m_dt = m_ds.Tables[0];
                    total = int.Parse(m_ds.Tables[1].Rows[0][0].ToString());
                }
            }
            return m_dt;
        }


        #endregion

    }

}
