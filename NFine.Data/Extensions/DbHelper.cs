/*******************************************************************************
 * Copyright © 2016 NFine.Framework 版权所有
 * Author: NFine
 * Description: NFine快速开发平台
 
*********************************************************************************/
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
namespace NFine.Data.Extensions
{
    public class DbHelper
    {
        private static string connstring = ConfigurationManager.ConnectionStrings["NFineDbContext"].ConnectionString;

        /// <summary>
        /// 要实现数据库备份功能修改此方法
        /// </summary>
        /// <param name="cmdText"></param>
        /// <returns></returns>
        public static int ExecuteSqlCommand(string cmdText)
        {
            using (DbConnection conn = new SqlConnection(connstring))
            {
                DbCommand cmd = new SqlCommand();
                PrepareCommand(cmd, conn, null, CommandType.Text, cmdText, null);
                return cmd.ExecuteNonQuery();
            }
        }
        //public static int ExecuteSqlCommand(string cmdText)
        //{
        //    using (DbConnection conn = new MySqlConnection(connstring))
        //    {
        //        DbCommand cmd = new MySqlCommand();
        //        PrepareCommand(cmd, conn, null, CommandType.Text, cmdText, null);
        //        return cmd.ExecuteNonQuery();
        //    }
        //}
        private static void PrepareCommand(DbCommand cmd, DbConnection conn, DbTransaction isOpenTrans, CommandType cmdType, string cmdText, DbParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (isOpenTrans != null)
                cmd.Transaction = isOpenTrans;
            cmd.CommandType = cmdType;
            if (cmdParms != null)
            {
                cmd.Parameters.AddRange(cmdParms);
            }
        }
    }
}
