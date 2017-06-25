using System;
using System.Configuration;
using System.Data.SqlClient;

namespace NEILREN.DAL
{
    /// <summary>
    /// SQL Server 数据库连接类 任霏 2015年7月4日00:51:51
    /// </summary>
    public class MSSQLConnection
    {
        /// <summary>
        /// SQL连接对象 任霏 2015年7月4日00:52:06
        /// </summary>
        public SqlConnection conn = new SqlConnection();

        /// <summary>
        /// 判断是否已经打开连接 任霏 2015年7月4日00:52:33
        /// </summary>
        private bool bOpen;

        /// <summary>
        /// 错误信息
        /// </summary>
        private string error;

        /// <summary>
        /// 数据库连接打开方法 任霏 2015年7月4日00:52:49
        /// </summary>
        /// <returns></returns>
        public void Open()
        {
            //读取web.config的连接字符串 任霏 2015年7月4日00:52:56
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["sqlConnectionString"].ConnectionString;
            try
            {
                conn.Open();
                bOpen = true;
            }
            catch (Exception exp)
            {
                bOpen = false;
                error = exp.Message;
            }
        }

        /// <summary>
        /// 数据库连接关闭方法 任霏 2015年7月4日01:01:08
        /// </summary>
        public void Close()
        {
            conn.Close();
            bOpen = false;
        }

        /// <summary>
        /// 数据库连接是否打开状态
        /// </summary>
        public bool IsOpen
        {
            get
            {
                return bOpen;
            }
        }

        /// <summary>
        /// 错误信息 任霏 2015年7月4日00:56:43
        /// </summary>
        public string ErrorMessage
        {
            get
            {
                return error;
            }
        }
    }
}
