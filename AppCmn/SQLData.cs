using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using WebMonitor;

namespace AppCmn
{
    /// <summary>
    /// Data 的摘要说明
    /// </summary>
    public class SQLData : System.IDisposable
    {
        public SQLData()
        {
            m_cmd.Connection = m_conn;
        }
        public SQLData(string connStrName)
        {
            m_conn = new SqlConnection(ConfigurationManager.ConnectionStrings[connStrName].ConnectionString);
            m_cmd.Connection = m_conn;
        }

        private SqlConnection m_conn = new SqlConnection(AppConfig.ConnectionString);
        private SqlCommand m_cmd = new SqlCommand();
        public string ReturnValue = "";

        public SqlParameter[] CmdParas
        {
            get
            {
                SqlParameter[] ret = new SqlParameter[m_cmd.Parameters.Count];
                for (int i = 0; i < m_cmd.Parameters.Count; i++)
                {
                    ret[i] = m_cmd.Parameters[i];
                }
                return ret;
            }
        }

        public void Dispose()
        {
            m_conn.Dispose();
            m_cmd.Dispose();
        }

        /// <summary>
        /// 添加SQL参数
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void AddParameter(string name, object value)
        {
            //value = SQLFilter((string)value);
            SqlParameter m_para = new SqlParameter(name, value);
            this.m_cmd.Parameters.Add(m_para);
        }
        public void AddParameter(string name, int outputlenth,string output)
        {
            SqlParameter m_para = new SqlParameter(name, SqlDbType.VarChar, outputlenth);
            m_para.Direction = ParameterDirection.Output;
            this.m_cmd.Parameters.Add(m_para);
        }
        public void AddParameter(SqlParameter input)
        {
            input.Value = SQLFilter((string)input.Value);
            this.m_cmd.Parameters.Add(input);
        }

        #region 执行命令

        /// <summary>
        /// 执行存储过程返回DataRow
        /// </summary>
        /// <param name="StoredProcedure"></param>
        /// <returns></returns>
        public DataRow SPtoDataRow(string StoredProcedure)
        {
            DataTable ret = new DataTable();
            try
            {
                SqlParameter retpara = m_cmd.Parameters.Add("@reValue", SqlDbType.Int);
                retpara.Direction = ParameterDirection.ReturnValue;
                
                m_cmd.CommandText = StoredProcedure;
                m_cmd.CommandType = CommandType.StoredProcedure;
                m_conn.Open();
                SqlDataAdapter m_adpt = new SqlDataAdapter(m_cmd);
                m_adpt.Fill(ret);
                ReturnValue = m_cmd.Parameters["@reValue"].Value.ToString();
            }
            catch (Exception ex)
            {
                LogManagement.getInstance().WriteException(ex, "SQLData,相关SP：" + StoredProcedure, HttpContext.Current.Request.RawUrl + " | " + HttpContext.Current.Request.UserHostAddress);
            }
            finally
            {
                m_conn.Close();
            }
            return ret.Rows[0];
        }
        /// <summary>
        /// 执行存储过程返回DataTable
        /// </summary>
        /// <param name="StoredProcedure"></param>
        /// <returns></returns>
        public DataTable SPtoDataTable(string StoredProcedure)
        {
            DataTable ret = new DataTable();
            try
            {

                SqlParameter retpara = m_cmd.Parameters.Add("@reValue", SqlDbType.Int);
                retpara.Direction = ParameterDirection.ReturnValue;
                
                m_cmd.CommandText = StoredProcedure;
                m_cmd.CommandType = CommandType.StoredProcedure;
                m_conn.Open();
                SqlDataAdapter m_adpt = new SqlDataAdapter(m_cmd);
                m_adpt.Fill(ret);
                ReturnValue = m_cmd.Parameters["@reValue"].Value.ToString();
            }
            catch (Exception ex)
            {
                LogManagement.getInstance().WriteException(ex, "SQLData,相关SP：" + StoredProcedure, HttpContext.Current.Request.RawUrl + " | " + HttpContext.Current.Request.UserHostAddress);
            }
            finally
            {
                m_conn.Close();
            }
            return ret;
        }
        /// <summary>
        /// 执行存储过程返回DataSet
        /// </summary>
        /// <param name="StoredProcedure"></param>
        /// <returns></returns>
        public DataSet SPtoDataSet(string StoredProcedure)
        {
            DataSet ret = new DataSet();
            try
            {

                SqlParameter retpara = m_cmd.Parameters.Add("@reValue", SqlDbType.Int);
                retpara.Direction = ParameterDirection.ReturnValue;
                
                m_cmd.CommandText = StoredProcedure;
                m_cmd.CommandType = CommandType.StoredProcedure;
                m_conn.Open();
                SqlDataAdapter m_adpt = new SqlDataAdapter(m_cmd);
                m_adpt.Fill(ret);
                ReturnValue = m_cmd.Parameters["@reValue"].Value.ToString();
            }
            catch (Exception ex)
            {
                LogManagement.getInstance().WriteException(ex, "SQLData,相关SP：" + StoredProcedure, HttpContext.Current.Request.RawUrl + " | " + HttpContext.Current.Request.UserHostAddress);
            }
            finally
            {
                m_conn.Close();
            }
            return ret;
        }

        /// <summary>
        /// 执行存储过程无返回
        /// </summary>
        /// <param name="StoredProcedure"></param>
        public void SPtoNone(string StoredProcedure)
        {
            try
            {
                SqlParameter retpara = m_cmd.Parameters.Add("@reValue", SqlDbType.Int);
                retpara.Direction = ParameterDirection.ReturnValue;
                
                m_cmd.CommandText = StoredProcedure;
                m_cmd.CommandType = CommandType.StoredProcedure;
                m_conn.Open();
                m_cmd.ExecuteNonQuery();
                ReturnValue = m_cmd.Parameters["@reValue"].Value.ToString();
            }
            catch (Exception ex)
            {
                LogManagement.getInstance().WriteException(ex, "SQLData,相关SP：" + StoredProcedure, HttpContext.Current.Request.RawUrl + " | " + HttpContext.Current.Request.UserHostAddress);
            }
            finally
            {
                m_conn.Close();
            }
        }

        /// <summary>
        /// 执行存储过程返回是否有记录
        /// </summary>
        /// <param name="StoredProcedure"></param>
        /// <returns></returns>
        public bool SPtoHasRow(string StoredProcedure)
        {
            bool ret = false;
            try
            {

                SqlParameter retpara = m_cmd.Parameters.Add("@reValue", SqlDbType.Int);
                retpara.Direction = ParameterDirection.ReturnValue;
                
                m_cmd.CommandText = StoredProcedure;
                m_cmd.CommandType = CommandType.StoredProcedure;
                m_conn.Open();
                SqlDataReader m_dr = m_cmd.ExecuteReader();
                m_dr.Read();
                if (m_dr.HasRows)
                {
                    ret = false;
                }
                else
                {
                    ret = true;
                }
                ReturnValue = m_cmd.Parameters["@reValue"].Value.ToString();
                m_dr.Close();
            }
            catch (Exception ex)
            {
                LogManagement.getInstance().WriteException(ex, "SQLData,相关SP：" + StoredProcedure, HttpContext.Current.Request.RawUrl + " | " + HttpContext.Current.Request.UserHostAddress);
            }
            finally
            {
                m_conn.Close();
            }
            return ret;
        }

        /// <summary>
        /// 执行SQL语句返回DataRow(SQL语句必须过滤参数)
        /// </summary>
        /// <param name="CommandText"></param>
        /// <returns></returns>
        public DataRow CmdtoDataRow(string CommandText)
        {
            DataTable ret = new DataTable();
            try
            {
                m_cmd.CommandText = CommandText;
                m_conn.Open();
                SqlDataAdapter m_adpt = new SqlDataAdapter(m_cmd);
                m_adpt.Fill(ret);
            }
            catch (Exception ex)
            {
                LogManagement.getInstance().WriteException(ex, "SQLData,相关SQL语句：" + CommandText, HttpContext.Current.Request.RawUrl + " | " + HttpContext.Current.Request.UserHostAddress);
            }
            finally
            {
                m_conn.Close();
            }
            return ret.Rows[0];
        }

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
                SqlDataAdapter m_adpt = new SqlDataAdapter(m_cmd);
                m_adpt.Fill(ret);
                ReturnValue = "1";
            }
            catch (Exception ex)
            {
                LogManagement.getInstance().WriteException(ex, "SQLData,相关SQL语句：" + CommandText, HttpContext.Current.Request.RawUrl + " | " + HttpContext.Current.Request.UserHostAddress);
                ReturnValue = "0";
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
                SqlDataAdapter m_adpt = new SqlDataAdapter(m_cmd);
                m_adpt.Fill(ret);
                ReturnValue = "1";
            }
            catch (Exception ex)
            {
                LogManagement.getInstance().WriteException(ex, "SQLData,相关SQL语句：" + CommandText, HttpContext.Current.Request.RawUrl + " | " + HttpContext.Current.Request.UserHostAddress);
                ReturnValue = "0";
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
                ReturnValue = "1";
            }
            catch (Exception ex)
            {
                LogManagement.getInstance().WriteException(ex, "SQLData,相关SQL语句：" + CommandText, HttpContext.Current.Request.RawUrl + " | " + HttpContext.Current.Request.UserHostAddress);
                ReturnValue = "0";
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
                SqlDataReader m_dr = m_cmd.ExecuteReader();
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
                LogManagement.getInstance().WriteException(ex, "SQLData,相关SQL语句：" + CommandText, HttpContext.Current.Request.RawUrl + " | " + HttpContext.Current.Request.UserHostAddress);
            }
            finally
            {
                m_conn.Close();
            }
            return ret;
        }

        #endregion

        /// <summary>
        /// 为SqlCommand绑定参数
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="cmd"></param>
        public static void CommandPackage(ref SqlParameter[] parameters, ref SqlCommand cmd)
        {
            cmd.CommandType = CommandType.StoredProcedure;
            if (parameters != null)
            {
                foreach (SqlParameter parm in parameters)
                    cmd.Parameters.Add(parm);
            }
        }

        /// <summary>
        /// 包装参数数组
        /// </summary>
        /// <param name="para">para[n,2] paraname,paravalue</param>
        /// <param name="output">output param name</param>
        /// <returns></returns>
        public static SqlParameter[] ParaPac(string[,] para, string[] output)
        {
            SqlParameter[] ret = new SqlParameter[para.GetLength(0) + output.Length];
            for (int i = 0; i <= output.Length - 1; i++)
            {
                ret[i] = new SqlParameter(output[i].ToString(), SqlDbType.NVarChar, 300);
                ret[i].Direction = ParameterDirection.Output;
            }
            for (int i = output.Length; i <= ret.Length - 1; i++)
            {
                ret[i] = new SqlParameter(para[i - output.Length, 0].ToString(), para[i - output.Length, 1]);
            }
            return ret;
        }
        public static SqlParameter[] ParaPac(string[,] para)
        {
            SqlParameter[] ret = new SqlParameter[para.GetLength(0)];
            for (int i = 0; i <= ret.Length - 1; i++)
            {
                ret[i] = new SqlParameter(para[i, 0].ToString(), para[i, 1]);
            }
            return ret;
        }

        /// <summary>
        /// 清除DataTable中的空值
        /// </summary>
        /// <param name="input"></param>
        /// <param name="reg"></param>
        /// <returns></returns>
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
        public static string SQLFilter(string input)
        {
            input = input.Replace("--", "");
            input = input.Replace(";", "");
            input = input.Replace("/*", "");
            input = input.Replace("*/", "");
            input = input.Replace("xp_", "");
            input = input.Replace("'", "''");
            return input;
        }

        /// <summary>
        /// SQL字符串包装
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string SQLWrap(string input)
        {
            return "'" + SQLFilter(input) + "'";
        }


        public int GetSequence(string paramTable)
        {
            string sql = " insert into " + paramTable + "(TS) values(getdate());";
            sql += " SELECT SCOPE_IDENTITY()";

            return Convert.ToInt32(SqlHelper.ExecuteScalar(sql));
        }

    }

}