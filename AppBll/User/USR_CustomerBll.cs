using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using AppMod.User;
using AppDal.User;
using AppCmn;
using System.Web;
using System.Transactions;

namespace AppBll.User
{
    public class USR_CustomerBll
    {
        private readonly USR_CustomerDal dal = new USR_CustomerDal();
        private USR_CustomerBll()
        {
        }
        private static USR_CustomerBll _instance;
        public static USR_CustomerBll GetInstance()
        {
            if (_instance == null)
            {
                _instance = new USR_CustomerBll();
            }
            return _instance;
        }
        #region  基本成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>

        public int Add(USR_CustomerMod model)
        {
            int ret = 0;
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = TransactionManager.DefaultTimeout;

            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, options))
            {

                ret =  dal.Add(model);
                USR_MessageMod m_notice = new USR_MessageMod();
                m_notice.CustomerSysNo = ret;
                m_notice.Context = AppConst.NewUserWelcome.Replace("@nickname", model.NickName)
                    .Replace("@userinfourl", AppConfig.HomeUrl() + "Qin/UserInfo.aspx?id="+model.SysNo)
                    .Replace("@pointhelpurl", AppConfig.HomeUrl() + "About/HelpCenter.aspx?memo=POINTANDCREDIT");
                m_notice.DR = 0;
                m_notice.IsRead = 0;
                m_notice.Title = "欢迎加入上上签";
                m_notice.TS = DateTime.Now;
                m_notice.Type = (int)AppEnum.MessageType.notice;
                USR_MessageBll.GetInstance().AddMessage(m_notice);
                scope.Complete();
            }
            return ret;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>

        public void UpDate(USR_CustomerMod model)
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

        public USR_CustomerMod GetModel(int SysNo)
        {
            return dal.GetModel(SysNo);
        }
        #endregion  成员方法

        #region  扩展成员方法
        /// <summary>
        /// 仅用于用户登录
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public USR_CustomerMod CheckUser(string username, string password)
        {
            USR_CustomerMod model = new USR_CustomerMod();
            using (SQLData data = new SQLData())
            {
                StringBuilder builder = new StringBuilder();
                builder.Append("select SysNo from USR_Customer where Email='").Append(SQLData.SQLFilter(username)).Append("' and Password='").Append(SQLData.SQLFilter(password)).Append("' and Status=").Append((int)AppEnum.State.normal);
                try
                {
                    model.SysNo = int.Parse(data.CmdtoDataRow(builder.ToString())["SysNo"].ToString());
                }
                catch (Exception exception)
                {
                    //throw exception;
                }
            }
            if (model.SysNo != AppConst.IntNull)
            {
                model = this.GetModel(model.SysNo);
                model.LastLoginTime = DateTime.Now;
                this.UpDate(model);
            }
            return model;
        }
        public USR_CustomerMod CheckUser(string username)
        {
            USR_CustomerMod model = new USR_CustomerMod();
            using (SQLData data = new SQLData())
            {
                StringBuilder builder = new StringBuilder();
                builder.Append("select SysNo from USR_Customer where Email='").Append(SQLData.SQLFilter(username)).Append("' and Status=").Append((int)AppEnum.State.normal);
                try
                {
                    model.SysNo = int.Parse(data.CmdtoDataRow(builder.ToString())["SysNo"].ToString());
                    model.Email = username;
                }
                catch (Exception exception)
                {
                    //throw exception;
                }
            }
            if (model.SysNo != AppConst.IntNull)
            {
                model = this.GetModel(model.SysNo);
            }
            return model;
        }

        public USR_CustomerMod CheckPhone(string phone)
        {
            USR_CustomerMod model = new USR_CustomerMod();
            using (SQLData data = new SQLData())
            {
                StringBuilder builder = new StringBuilder();
                builder.Append("select SysNo from USR_Customer where Phone='").Append(SQLData.SQLFilter(phone)).Append("' and Status=").Append((int)AppEnum.State.normal);
                try
                {
                    model.SysNo = int.Parse(data.CmdtoDataRow(builder.ToString())["SysNo"].ToString());
                }
                catch (Exception exception)
                {
                    //throw exception;
                }
            }
            if (model.SysNo != AppConst.IntNull)
            {
                model = this.GetModel(model.SysNo);
            }
            return model;
        }

        public USR_CustomerMod CheckNickName(string nickname)
        {
            USR_CustomerMod model = new USR_CustomerMod();
            using (SQLData data = new SQLData())
            {
                StringBuilder builder = new StringBuilder();
                builder.Append("select SysNo from USR_Customer where NickName='").Append(SQLData.SQLFilter(nickname)).Append("' and Status=").Append((int)AppEnum.State.normal);
                try
                {
                    model.SysNo = int.Parse(data.CmdtoDataRow(builder.ToString())["SysNo"].ToString());
                }
                catch (Exception exception)
                {
                    //throw exception;
                }
            }
            if (model.SysNo != AppConst.IntNull)
            {
                model = this.GetModel(model.SysNo);
            }
            return model;
        }

        public void AddCount(int CustomerSysNo,int TotalQuest, int TotalAnswer,int BestAnswer,int TotalReply,int TotalTalk,int TotalTalkReply)
        {
            using (SQLData data = new SQLData())
            {
                StringBuilder builder = new StringBuilder();
                builder.Append("update USR_Customer set TotalQuest = TotalQuest+").Append(TotalQuest).Append(",TotalAnswer = TotalAnswer+").Append(TotalAnswer)
                    .Append(",BestAnswer = BestAnswer+").Append(BestAnswer).Append(",TotalReply = TotalReply+").Append(TotalReply)
                    .Append(",TotalTalk = TotalTalk+").Append(TotalTalk).Append(",TotalTalkReply = TotalTalkReply+").Append(TotalTalkReply)
                    .Append(" where SysNo=").Append(CustomerSysNo);
                try
                {
                    data.CmdtoNone(builder.ToString());
                }
                catch (Exception exception)
                {
                    //throw exception;
                }
            }
        }

        public int AddCredit(int credit,int sysno)
        {
            int ret = 0;
            using (SQLData data = new SQLData())
            {
                StringBuilder builder = new StringBuilder();
                builder.Append("update USR_Customer set Credit = Credit+(").Append(credit).Append(") where SysNo=").Append(sysno)
                    .Append(";select Credit from USR_Customer where SysNo=").Append(sysno);
                try
                {
                    ret = int.Parse(data.CmdtoDataRow(builder.ToString())["Credit"].ToString());
                }
                catch (Exception exception)
                {
                    //throw exception;
                }
            }
            return ret;
        }

        public int AddPoint(int point, int sysno)
        {
            int ret = 0;
            using (SQLData data = new SQLData())
            {
                StringBuilder builder = new StringBuilder();
                builder.Append("update USR_Customer set Point = Point+(").Append(point).Append(") where SysNo=").Append(sysno)
                    .Append(";select Point from USR_Customer where SysNo=").Append(sysno);
                try
                {
                    ret = int.Parse(data.CmdtoDataRow(builder.ToString())["Point"].ToString());
                }
                catch (Exception exception)
                {
                    //throw exception;
                }
            }
            return ret;
        }

        public int AddExp(int exp, int sysno)
        {
            int ret = 0;
            using (SQLData data = new SQLData())
            {
                StringBuilder builder = new StringBuilder();
                builder.Append("update USR_Customer set Exp = Exp+(").Append(exp).Append(") where SysNo=").Append(sysno)
                    .Append(";select Exp from USR_Customer where SysNo=").Append(sysno)
                    .Append(";select * from USR_Grade where SysNo in (select GradeSysNo from USR_Customer where SysNo=").Append(sysno).Append(")");
                try
                {
                    DataSet m_ds = data.CmdtoDataSet(builder.ToString());
                    ret = int.Parse(m_ds.Tables[0].Rows[0]["Exp"].ToString());
                    DataTable m_grade = USR_GradeBll.GetInstance().GetList();
                    for (int i = 0; i < m_grade.Rows.Count; i++)
                    {
                        if (int.Parse(m_grade.Rows[i]["LevelNum"].ToString()) == int.Parse(m_ds.Tables[1].Rows[0]["LevelNum"].ToString()) + 1)
                        {
                            if (ret >= int.Parse(m_grade.Rows[i]["Exp"].ToString()))
                            {
                                data.CmdtoNone("update USR_Customer set GradeSysNo=" + m_grade.Rows[i]["SysNo"].ToString() + " where sysno=" + sysno);
                            }
                        }
                    }
                }
                catch (Exception exception)
                {
                    //throw exception;
                }
            }
            return ret;
        }

        public DataTable GetList(int pagesize, int pageindex, string name, DateTime timeBegin, DateTime timeEnd, string status, ref int total)
        {
            DataTable m_dt = new DataTable();
            string columns = "";
            string tables = "";
            string where = "";
            string order = "";

            #region  设置参数
            columns = @"*";
            tables = "USR_Customer";
            order = "USR_Customer.SysNo desc";
            where = "1=1";
            if (name != "")
            {
                where += " and (";
                string[] tmpstr = name.Split(new char[] { ' ','@' });
                for (int i = 0; i < tmpstr.Length; i++)
                {
                    where += " (USR_Customer.[Email] like '%" + SQLData.SQLFilter(tmpstr[i]) + "%' or USR_Customer.[NickName] like '%" + SQLData.SQLFilter(tmpstr[i]) + "%') and ";
                }
                where += " 1=1)";
            }
            if (timeBegin != AppCmn.AppConst.DateTimeNull)
            {
                where += " and (RegTime>" + timeBegin.Year.ToString() +
                    " or (RegTime=" + timeBegin.Year.ToString() + " and RegTime>='" + timeBegin.AddYears(AppConst.DateTimeNull.Year - timeBegin.Year).ToString("yyyy-MM-dd 00:00:00") + "'))";
            }
            if (timeEnd != AppCmn.AppConst.DateTimeNull)
            {
                where += " and (RegTime<" + timeEnd.Year.ToString() +
                    " or (RegTime=" + timeEnd.Year.ToString() + " and RegTime<='" + timeEnd.AddYears(AppConst.DateTimeNull.Year - timeEnd.Year).ToString("yyyy-MM-dd 23:59:59") + "'))";
            }
            if (status != "" && status != "100")
            {
                where += " and [Status]=" + status;
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

        public USR_CustomerMod GetUserByThirdID(string id)
        {
            USR_CustomerMod model = new USR_CustomerMod();
            using (SQLData data = new SQLData())
            {
                StringBuilder builder = new StringBuilder();
                builder.Append("select CustomerSysNo from USR_ThirdLogin where OpenID='").Append(SQLData.SQLFilter(id)).Append("'");
                try
                {
                    model.SysNo = int.Parse(data.CmdtoDataRow(builder.ToString())["CustomerSysNo"].ToString());
                }
                catch (Exception exception)
                {
                    //throw exception;
                }
            }
            if (model.SysNo != AppConst.IntNull)
            {
                model = this.GetModel(model.SysNo);
            }
            return model;
        }

        public int GetUnReadInfoNum(int sysno)
        {
            int ret = 0;
            using (SQLData data = new SQLData())
            {
                StringBuilder builder = new StringBuilder();
                builder.Append("select HasNewInfo from USR_Customer where sysno =").Append(sysno);
                try
                {
                    ret = int.Parse(data.CmdtoDataRow(builder.ToString())["HasNewInfo"].ToString());
                }
                catch (Exception exception)
                {
                    //throw exception;
                }
            }
            return ret;
        }

        public void AddUnReadInfo(int sysno)
        {

            using (SQLData data = new SQLData())
            {
                StringBuilder builder = new StringBuilder();
                builder.Append("update USR_Customer set HasNewInfo = HasNewInfo+1 where sysno =").Append(sysno);
                try
                {
                    data.CmdtoNone(builder.ToString());
                }
                catch (Exception exception)
                {
                    //throw exception;
                }
            }

        }
        public void ZeroUnReadInfo(int sysno)
        {

            using (SQLData data = new SQLData())
            {
                StringBuilder builder = new StringBuilder();
                builder.Append("update USR_Customer set HasNewInfo = 0 where sysno =").Append(sysno);
                try
                {
                    data.CmdtoNone(builder.ToString());
                }
                catch (Exception exception)
                {
                    //throw exception;
                }
            }

        }

        #endregion

    }

}
