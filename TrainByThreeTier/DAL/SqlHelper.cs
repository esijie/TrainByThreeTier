using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data ;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace TrainByThreeTier.DAL
{
    public class SqlHelper
    {
        /// <summary>
        /// dtl_server数据库连接串
        /// </summary>
        public static string MYSQL_SERVER = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;


        #region
        /// <summary>
        /// ExecuteReader
        /// </summary>
        /// <param name="commandText">命令语句</param>
        /// <returns>MySqlDataReader结果</returns>
        public static MySqlDataReader ExecuteReader(string cmdText)
        {
            return ExecuteReader(cmdText, null);
        }
        #endregion

        #region
        /// <summary>
        /// ExecuteReader
        /// </summary>
        /// <param name="commandText">命令语句</param>
        /// <param name="commandParameters">命令的参数</param>
        /// <returns>MySqlDataReader结果</returns>
        public static MySqlDataReader ExecuteReader(string cmdText, params MySqlParameter[] commandParameters)
        {
            return ExecuteReader(MYSQL_SERVER, CommandType.Text, cmdText, commandParameters);
        }
        #endregion

        #region
        /// <summary>
        /// ExecuteReader
        /// </summary>
        /// <param name="commandType">MySql命令类型</param>
        /// <param name="commandText">命令语句</param>
        /// <param name="commandParameters">命令的参数</param>
        /// <returns>MySqlDataReader结果</returns>
        public static MySqlDataReader ExecuteReader(CommandType cmdType, string cmdText, params MySqlParameter[] commandParameters)
        {
            return ExecuteReader(MYSQL_SERVER, cmdType, cmdText, commandParameters);
        }
        #endregion

        #region
        /// <summary>
        /// 重载：ExecuteReader
        /// </summary>
        /// <param name="connString">数据库连接字符串</param>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public static MySqlDataReader ExecuteReader(string connString, CommandType cmdType, string cmdText, params MySqlParameter[] commandParameters)
        {
            MySqlConnection conn = new MySqlConnection(connString);
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandTimeout = 30;

                PrepareCommand(cmd, conn, cmdType, cmdText, commandParameters);
                MySqlDataReader rdr = null;
                try
                {
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                }
                catch (MySqlException e)
                {
                    conn.Close();
                    conn.Dispose();

                    throw e;
                }
                cmd.Parameters.Clear();

                return rdr;
            }
        }
        #endregion



        #region

        /// <summary>
        /// ExecuteScalar
        /// </summary>
        /// <param name="commandText">命令语句</param>
        /// <returns>一个须转换成其它类型的值</returns>
        public static object ExecuteScalar(string cmdText)
        {
            return ExecuteScalar(cmdText, null);
        }

        /// <summary>
        /// ExecuteScalar
        /// </summary>
        /// <param name="commandText">命令语句</param>
        /// <param name="commandParameters">命令的参数</param>
        /// <returns>一个须转换成其它类型的值</returns>
        public static object ExecuteScalar(string cmdText, params MySqlParameter[] commandParameters)
        {
            return ExecuteScalar(MYSQL_SERVER, CommandType.Text, cmdText, commandParameters);
        }

        /// <summary>
        /// ExecuteScalar
        /// </summary>
        /// <param name="commandType">MySql命令类型</param>
        /// <param name="commandText">命令语句</param>
        /// <param name="commandParameters">命令的参数</param>
        /// <returns>一个须转换成其它类型的值</returns>
        public static object ExecuteScalar(CommandType cmdType, string cmdText, params MySqlParameter[] commandParameters)
        {
            return ExecuteScalar(MYSQL_SERVER, cmdType, cmdText, commandParameters);
        }

        /// <summary>
        /// 重载:ExecuteScalar
        /// </summary>
        /// <param name="connString">数据库连接字符串</param>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string connString, CommandType cmdType, string cmdText, params MySqlParameter[] commandParameters)
        {
            object val;
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandTimeout = 30;

                PrepareCommand(cmd, conn, cmdType, cmdText, commandParameters);

                try
                {
                    val = cmd.ExecuteScalar();
                }
                catch (MySqlException e)
                {
                    conn.Close();
                    conn.Dispose();

                    throw e;
                }

                cmd.Parameters.Clear();
                cmd.Dispose();
                conn.Close();
                conn.Dispose();
            }



            return val;


        }
        #endregion

        #region
        /// <summary>
        /// ExecuteNonQuery
        /// </summary>
        /// <param name="commandText">命令语句</param>
        /// <returns>一个须转换成其它类型的值</returns>
        public static bool ExecuteNonQuery(string cmdText)
        {
            return ExecuteNonQuery(cmdText, null);
        }

        /// <summary>
        /// ExecuteNonQuery
        /// </summary>
        /// <param name="commandText">命令语句</param>
        /// <param name="commandParameters">命令的参数</param>
        /// <returns>一个须转换成其它类型的值</returns>
        public static bool ExecuteNonQuery(string cmdText, params MySqlParameter[] commandParameters)
        {
            return ExecuteNonQuery(MYSQL_SERVER, CommandType.Text, cmdText, commandParameters);
        }

        /// <summary>
        /// ExecuteNonQuery
        /// </summary>
        /// <param name="commandType">MySql命令类型</param>
        /// <param name="commandText">命令语句</param>
        /// <param name="commandParameters">命令的参数</param>
        /// <returns>一个须转换成其它类型的值</returns>
        public static bool ExecuteNonQuery(CommandType cmdType, string cmdText, params MySqlParameter[] commandParameters)
        {
            return ExecuteNonQuery(MYSQL_SERVER, cmdType, cmdText, commandParameters);
        }
        #endregion

        #region
        /// <summary>
        /// ExecuteNonQuery
        /// </summary>
        /// <param name="commandType">MySql命令类型</param>
        /// <param name="commandText">命令语句</param>
        /// <param name="commandParameters">命令的参数</param>
        /// <returns>一个须转换成其它类型的值</returns>
        public static bool ExecuteNonQuery(string connString, CommandType cmdType, string cmdText, params MySqlParameter[] commandParameters)
        {
            int effectRows = 0;
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandTimeout = 30;

                PrepareCommand(cmd, conn, cmdType, cmdText, commandParameters);
                try
                {
                    effectRows = cmd.ExecuteNonQuery();
                }
                catch (MySqlException e)
                {
                    conn.Close();
                    conn.Dispose();

                    throw e;
                }
                cmd.Parameters.Clear();
                cmd.Dispose();
                conn.Close();
                conn.Dispose();
            }

            return effectRows > 0;
        }
        #endregion

        #region
        /// <summary>
        /// 配置一个用来执行的Command对像
        /// </summary>
        /// <param name="cmd">Command对像,在本方法中被改变</param>
        /// <param name="conn">数据库连接对像</param>
        /// <param name="cmdType">命令类型</param>
        /// <param name="cmdText">命令文本</param>
        /// <param name="cmdParms">命令的参数</param>
        private static void PrepareCommand(MySqlCommand cmd, MySqlConnection conn, CommandType cmdType, string cmdText, MySqlParameter[] cmdParms)
        {

            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = cmdText;

            cmd.CommandType = cmdType;

            if (cmdParms != null)
            {
                foreach (MySqlParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }
        #endregion

        #region
        /// <summary>
        /// 为事务作准备
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="cmdParms"></param>
        private static void PrepareCommand(MySqlCommand cmd, MySqlConnection conn, MySqlTransaction trans, CommandType cmdType, string cmdText, MySqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = cmdType;
            if (cmdParms != null)
            {
                foreach (MySqlParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }
        #endregion

        #region

        public static DataRow ExecuteRow(string commandText)
        {
            try
            {
                return ExecuteDataTable(commandText).Rows[0];
            }
            catch { }

            return null;
        }

        public static DataTable ExecuteDataTable(string commandText)
        {
            using (MySqlConnection con = new MySqlConnection(MYSQL_SERVER))
            {
                con.Open();

                MySqlCommand com = new MySqlCommand();
                com.Connection = con;
                com.CommandType = CommandType.Text;
                com.CommandTimeout = 60;
                com.CommandText = commandText;

                //MySqlDataAdapter da = new MySqlDataAdapter(com);

                MySqlDataReader re = com.ExecuteReader();


                DataTable dt = new DataTable();
                dt.Load(re);

                //da.Fill(dt);

                re.Close();
                com.Dispose();

                con.Close();
                con.Dispose();

                return dt;
            }
        }


        public static DataTable ExecuteDataTable(string commandText, params MySqlParameter[] commandParameters)
        {
            return ExecuteDataTable(CommandType.Text, commandText, commandParameters);
        }


        public static DataTable ExecuteDataTable(CommandType commandType, string commandText, params MySqlParameter[] commandParameters)
        {
            return ExecuteDataTable(MYSQL_SERVER, commandType, commandText, commandParameters);
        }

        public static DataTable ExecuteDataTable(string connString, CommandType commandType, string commandText, params MySqlParameter[] commandParameters)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                MySqlCommand cmd = new MySqlCommand();

                cmd.CommandTimeout = 120;

                bool mustCloseConnection = true;
                PrepareCommand(cmd, conn, commandType, commandText, commandParameters);

                using (MySqlDataAdapter da = new MySqlDataAdapter(commandText, conn))
                {

                    DataTable tb = new DataTable();

                    try
                    {
                        da.Fill(tb);
                    }
                    catch (MySqlException e)
                    {
                        conn.Close();
                        conn.Dispose();

                        throw e;
                    }

                    cmd.Parameters.Clear();

                    if (mustCloseConnection)
                        conn.Close();

                    return tb;
                }

                cmd.Dispose();
                conn.Close();
                conn.Dispose();
            }
        }
        #endregion

        #region
        /// <summary>
        /// 返回DataSet
        /// </summary>
        /// <param name="commandType"></param>
        /// <param name="commandText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public static DataSet ExecuteDataset(string commandText)
        {
            return ExecuteDataset(commandText, null);
        }

        /// <summary>
        /// 返回DataSet
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public static DataSet ExecuteDataset(string commandText, params MySqlParameter[] commandParameters)
        {
            return ExecuteDataset(MYSQL_SERVER, CommandType.Text, commandText, commandParameters);
        }

        /// <summary>
        /// 返回DataSet
        /// </summary>
        /// <param name="commandType"></param>
        /// <param name="commandText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public static DataSet ExecuteDataset(CommandType commandType, string commandText, params MySqlParameter[] commandParameters)
        {
            return ExecuteDataset(MYSQL_SERVER, commandType, commandText, commandParameters);
        }
        #endregion

        #region
        /// <summary>
        /// 重载：返回DataSet
        /// </summary>
        /// <param name="commandType"></param>
        /// <param name="commandText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public static DataSet ExecuteDataset(string connString, CommandType commandType, string commandText, params MySqlParameter[] commandParameters)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                MySqlCommand cmd = new MySqlCommand();

                cmd.CommandTimeout = 360;

                bool mustCloseConnection = true;
                PrepareCommand(cmd, conn, commandType, commandText, commandParameters);

                using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        da.Fill(ds);
                    }
                    catch (MySqlException e)
                    {
                        conn.Close();
                        conn.Dispose();

                        throw e;
                    }

                    cmd.Parameters.Clear();

                    if (mustCloseConnection)
                        conn.Close();

                    return ds;
                }

                cmd.Dispose();
                conn.Close();
                conn.Dispose();
            }
        }
        #endregion

        #region
        /// <summary>
        /// 返回读取适配器
        /// </summary>
        /// <param name="connectString">数据库连接字符串</param>
        /// <param name="cmdType">命令类型</param>
        /// <param name="cmdText">命令文本</param>
        /// <param name="commandParameters">参数</param>
        /// <returns></returns>
        public static MySqlDataAdapter ExecuteAdapter(string connectString, CommandType cmdType, string cmdText, params MySqlParameter[] commandParameters)
        {
            MySqlConnection conn = new MySqlConnection(connectString);
            MySqlCommand cmd = new MySqlCommand();

            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            cmd.CommandType = cmdType;
            if (commandParameters != null)
            {
                foreach (MySqlParameter parm in commandParameters)
                {
                    cmd.Parameters.Add(parm);
                }
            }



            return new MySqlDataAdapter(cmd);
        }

        /// <summary>
        /// 返回读取适配器
        /// </summary>
        /// <param name="cmdType">命令类型</param>
        /// <param name="cmdText">命令文本</param>
        /// <param name="commandParameters">参数</param>
        /// <returns></returns>
        public static MySqlDataAdapter ExecuteAdapter(CommandType cmdType, string cmdText, params MySqlParameter[] commandParameters)
        {
            return ExecuteAdapter(MYSQL_SERVER, cmdType, cmdText, commandParameters);
        }
        #endregion

        #region
        /// <summary>
        /// 执行带事务的操作
        /// </summary>
        /// <param name="trans"></param>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(MySqlTransaction trans, CommandType cmdType, string cmdText, params MySqlParameter[] commandParameters)
        {
            MySqlCommand cmd = new MySqlCommand();
            PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, commandParameters);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }
        #endregion

        #region Sql分页方法
        /// <summary>
        /// 分页方法(可以选择是否返回总记录数)
        /// </summary>
        /// <param name="keyfield">主键</param>
        /// <param name="fields">要查询的字段</param>
        /// <param name="table">表名</param>
        /// <param name="orderField">排序字段(必须参数,可以多个字段  如: id,date desc  不能有order by)</param>
        /// <param name="sqlWhere">条件(不带 where)</param>
        /// <param name="pageSize">每页多少条记录</param>
        /// <param name="pageIndex">当前第几页(从1开始)</param>
        /// <param name="RowCount">要返回的总记录数</param>
        /// <param name="isRowCount">是否返回总页数</param>
        /// <param name="paramters">Sql语句参数</param>
        /// <returns></returns>
        public static DataTable SplitPage1(string keyfield, string fields, string table, string orderField, string sqlWhere, int pageSize, int pageIndex, out int RowCount, bool isRowCount, params MySqlParameter[] paramters)
        {
            if (sqlWhere.Trim().Length > 0)
            {
                sqlWhere = " AND " + sqlWhere;
            }
            int rowIndex = pageSize * (pageIndex - 1);

            string StrSql = "select " + fields + " from " + table + " Where 1=1 " + sqlWhere + " order by " + orderField;
            StrSql += " LIMIT " + rowIndex + "," + pageSize + " ; ";


            if (isRowCount)
            {
                StrSql = StrSql + " SELECT COUNT(*) FROM " + table + " Where 1=1 " + sqlWhere;
            }
            DataSet ds = ExecuteDataset(MYSQL_SERVER, CommandType.Text, StrSql, paramters);
            DataTable dt = null;
            RowCount = 0;
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                if (isRowCount && ds.Tables.Count > 1)
                {

                    int.TryParse(ds.Tables[1].Rows[0][0].ToString(), out RowCount);
                }
            }
            return dt;
        }

        #endregion

   
    }
}
