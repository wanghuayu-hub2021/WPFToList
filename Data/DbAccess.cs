using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace WPFToDoList.Data
{
    /// <summary>
    /// 数据库
    /// </summary>
    public static class DbAccess
    {
        /// <summary>
        /// 连接字符串
        /// </summary>
        private static string connString =
            ConfigurationManager.ConnectionStrings["DatabaseConnection"].
            ConnectionString;

        /// <summary>
        /// 第一行第一列
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public static object ExecuteDataScalar(string strSql, params SqlParameter[] parms)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(strSql, conn);
                //cmd.CommandType = CommandType.StoredProcedure;   //存储过程
                cmd.CommandType = CommandType.Text;                //Sql语句
                cmd.Parameters.Clear();
                cmd.Parameters.AddRange(parms);
                conn.Open();
                return cmd.ExecuteScalar();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static SqlDataReader ExecuteDataReader(string strSql, params SqlParameter[] parms)
        {
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(strSql, conn);
                //cmd.CommandType = CommandType.StoredProcedure;   //存储过程
                cmd.CommandType = CommandType.Text;                //Sql语句
                cmd.Parameters.Clear();
                cmd.Parameters.AddRange(parms);
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return reader;
            }
            catch (SqlException ex)
            {
                conn.Close();
                throw new Exception("执行SqlDataReader出现异常", ex);
            }
        }

        /// <summary>
        /// DataTable
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public static DataTable ExecuteDataTable(string strSql, params SqlParameter[] parms)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(strSql, conn);
                //cmd.CommandType = CommandType.StoredProcedure;   //存储过程
                cmd.CommandType = CommandType.Text;                //Sql语句
                cmd.Parameters.Clear();
                cmd.Parameters.AddRange(parms);
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                adapter.Fill(dt);
                return dt;
            }
        }

        /// <summary>
        /// 增删改
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public static int ExecuteDataNonQuery(string strSql, params SqlParameter[] parms)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(strSql, conn);
                //cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Clear();
                cmd.Parameters.AddRange(parms);
                conn.Open();
                int k = cmd.ExecuteNonQuery();
                return k;
            }
        }

        /// <summary>
        /// 事务执行
        /// </summary>
        /// <param name="comList"></param>
        /// <returns></returns>
        public static bool ExecuteDataTrans(List<SqlCommand> comList)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.Transaction = trans;
                try
                {
                    int count = 0;
                    for (int i = 0; i < comList.Count; i++)
                    {
                        cmd.CommandText = comList[i].CommandText;

                        //存储过程 or Sql语句
                        //if (comList[i].IsProc)
                        //    cmd.CommandType = CommandType.StoredProcedure;
                        //else
                        //    cmd.CommandType = CommandType.Text;
                        cmd.CommandType = comList[i].CommandType;
                        cmd.Parameters.Clear();
                        foreach (SqlParameter p in comList[i].Parameters)
                        {
                            cmd.Parameters.Add(p);
                        }
                        count += cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }
                    trans.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw new Exception("执行事务出现异常", ex);
                }
            }
        }

    }
}
