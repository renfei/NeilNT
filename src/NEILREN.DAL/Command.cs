using System;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace NEILREN.DAL
{
    public class Command
    {
        //MSSQLConnection connObj = new MSSQLConnection();
        //SqlCommand cmd = new SqlCommand();
        MYSQLConnection connObj = new MYSQLConnection();
        MySqlCommand cmd = new MySqlCommand();

        /// <summary>
        /// 执行SQL查询语句返回DataTable
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable SqlToDataTable(string sql)
        {
            cmd.Connection = connObj.conn;
            cmd.CommandText = sql;
            try
            {
                if (!connObj.IsOpen)
                    connObj.Open();
                MySqlDataAdapter sdap = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dt.Clear();
                sdap.Fill(dt);
                connObj.Close();
                return dt;
            }
            catch (Exception ex)
            {
                //记录异常信息
                return null;
            }
            finally
            {
                connObj.Close();
            }
        }

        ///// <summary>
        ///// 执行SQL查询语句返回DataTable
        ///// </summary>
        ///// <param name="sql"></param>
        ///// <param name="parameters"></param>
        ///// <returns></returns>
        //public DataTable SqlToDataTable(string sql, SqlParameter[] parameters)
        //{
        //    cmd.Connection = connObj.conn;
        //    cmd.CommandText = sql;
        //    cmd.Parameters.AddRange(parameters);
        //    try
        //    {
        //        if (!connObj.IsOpen)
        //            connObj.Open();
        //        SqlDataAdapter sdap = new SqlDataAdapter();
        //        sdap.SelectCommand = cmd;
        //        DataTable dt = new DataTable();
        //        dt.Clear();
        //        sdap.Fill(dt);
        //        connObj.Close();
        //        return dt;
        //    }
        //    catch (Exception ex)
        //    {
        //        //记录异常信息
        //        return null;
        //    }
        //    finally
        //    {
        //        connObj.Close();
        //    }
        //}

        /// <summary>
        /// 执行MYSQL查询语句返回DataTable
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public DataTable SqlToDataTable(string sql, MySqlParameter[] parameters)
        {
            cmd.Connection = connObj.conn;
            cmd.CommandText = sql;
            cmd.Parameters.AddRange(parameters);
            try
            {
                if (!connObj.IsOpen)
                    connObj.Open();
                MySqlDataAdapter sdap = new MySqlDataAdapter();
                sdap.SelectCommand = cmd;
                DataTable dt = new DataTable();
                dt.Clear();
                sdap.Fill(dt);
                connObj.Close();
                return dt;
            }
            catch (Exception ex)
            {
                //记录异常信息
                return null;
            }
            finally
            {
                connObj.Close();
            }
        }
    }
}
