using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;

namespace AppCmn
{
    /// <summary>
    /// AccData 的摘要说明
    /// </summary>
    public class AccData : System.IDisposable
    {
        public AccData(string DB_path)
        {
            m_conn = new OleDbConnection(ConfigurationManager.ConnectionStrings["AccConnStr"].ConnectionString.Replace("{0}", HttpContext.Current.Server.MapPath(DB_path)));
            m_cmd.Connection = m_conn;
        }
        private OleDbConnection m_conn = new OleDbConnection();
        private OleDbCommand m_cmd = new OleDbCommand();
        public string ReturnValue = "";

        public void Dispose()
        {
            m_conn.Dispose();
            m_cmd.Dispose();
        }

        #region 执行命令

        /// <summary>
        /// 执行SQL语句返回DataTable(SQL语句必须过滤参数)
        /// </summary>
        /// <param name="CommandText"></param>
        /// <returns></returns>
        public DataTable CmdtoDataTable(string CommandText)
        {
            DataTable ret = new DataTable();
            try
            {

                m_cmd.CommandText = CommandText;
                m_conn.Open();
                OleDbDataAdapter m_adpt = new OleDbDataAdapter(m_cmd);
                m_adpt.Fill(ret);
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write(ex.Message);
            }
            finally
            {
                m_conn.Close();
            }
            return ret;
        }

        /// <summary>
        /// 执行SQL语句返回DataSet(SQL语句必须过滤参数)
        /// </summary>
        /// <param name="CommandText"></param>
        /// <returns></returns>
        public DataSet CmdtoDataSet(string CommandText)
        {
            DataSet ret = new DataSet();
            try
            {
                m_cmd.CommandText = CommandText;
                m_conn.Open();
                OleDbDataAdapter m_adpt = new OleDbDataAdapter(m_cmd);
                m_adpt.Fill(ret);
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write(ex.Message);
            }
            finally
            {
                m_conn.Close();
            }
            return ret;
        }

        /// <summary>
        /// 执行SQL语句无返回(SQL语句必须过滤参数)
        /// </summary>
        /// <param name="CommandText"></param>
        public void CmdtoNone(string CommandText)
        {
            try
            {
                m_cmd.CommandText = CommandText;
                m_conn.Open();
                m_cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write(ex.Message);
            }
            finally
            {
                m_conn.Close();
            }
        }

        /// <summary>
        /// 执行SQL语句返回是否有记录(SQL语句必须过滤参数)
        /// </summary>
        /// <param name="CommandText"></param>
        /// <returns></returns>
        public bool CmdtoHasRow(string CommandText)
        {
            bool ret = false;
            try
            {
                m_cmd.CommandText = CommandText;
                m_conn.Open();
                OleDbDataReader m_dr = m_cmd.ExecuteReader();
                m_dr.Read();
                if (m_dr.HasRows)
                {
                    ret = false;
                }
                else
                {
                    ret = true;
                }
                m_dr.Close();
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write(ex.Message);
            }
            finally
            {
                m_conn.Close();
            }
            return ret;
        }

        #endregion

        public static DataTable ClearNull(DataTable input, string reg)
        {
            if (input == null || input.Rows.Count == 0)
            {
                return input;
            }
            for (int i = 0; i < input.Rows.Count; i++)
            {
                for (int j = 0; j < input.Columns.Count; j++)
                {
                    if (input.Rows[i][j] == null || input.Rows[i][j].ToString() == "Null" || input.Rows[i][j].ToString() == "")
                    {
                        input.Rows[i][j] = reg;
                    }
                }
            }
            return input;
        }

        /// <summary>
        /// SQL安全过滤
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string SQLFilter(string input)
        {
            return input;
        }
    }
}