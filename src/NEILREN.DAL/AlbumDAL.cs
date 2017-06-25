using MySql.Data.MySqlClient;
using System.Data;

namespace NEILREN.DAL
{
    public class AlbumDAL
    {
        Command cmd = new Command();
        public DataSet GetAlbumByID(string ID, string StartNum, string NextNum)
        {
            string sql1 = "SELECT * FROM tAlbum WHERE AlbumID=@AlbumID1";
            string sql2 = "SELECT * FROM tPhoto WHERE AlbumID=@AlbumID ORDER BY PhotoID LIMIT @StartNum , @NextNum";
            string sql3 = "SELECT count(*) AS RowNum FROM tPhoto WHERE AlbumID=@AlbumID0";
            MySqlParameter[] parameters0 = { new MySqlParameter("@AlbumID0", MySqlDbType.Int32) };
            parameters0[0].Value = ID;
            MySqlParameter[] parameters1 = { new MySqlParameter("@AlbumID1", MySqlDbType.Int32) };
            parameters1[0].Value = ID;
            MySqlParameter[] parameters2 = { 
                                             new MySqlParameter("@AlbumID", MySqlDbType.Int32) ,
                                             new MySqlParameter("@StartNum", MySqlDbType.Int32) ,
                                             new MySqlParameter("@NextNum", MySqlDbType.Int32) 
                                         };
            parameters2[0].Value = ID;
            parameters2[1].Value = StartNum;
            parameters2[2].Value = NextNum;
            DataTable dt0 = cmd.SqlToDataTable(sql3, parameters0);
            DataTable dt1 = cmd.SqlToDataTable(sql1, parameters1);
            DataTable dt2 = cmd.SqlToDataTable(sql2, parameters2);
            DataSet ds = new DataSet();
            ds.Tables.Add(dt0);
            ds.Tables.Add(dt1);
            ds.Tables.Add(dt2);
            return ds;
        }

        public DataSet GetAlbum(string StartNum, string NextNum)
        {
            string sql1 = "SELECT count(*) AS RowNum FROM tAlbum";
            string sql2 = "SELECT * FROM tAlbum ORDER BY AlbumID DESC LIMIT @StartNum , @NextNum";
            MySqlParameter[] parameters = { 
                                             new MySqlParameter("@StartNum", MySqlDbType.Int32) ,
                                             new MySqlParameter("@NextNum", MySqlDbType.Int32) 
                                         };
            parameters[0].Value = StartNum;
            parameters[1].Value = NextNum;
            DataTable dt1 = cmd.SqlToDataTable(sql1);
            DataTable dt2 = cmd.SqlToDataTable(sql2, parameters);
            DataSet ds = new DataSet();
            ds.Tables.Add(dt1);
            ds.Tables.Add(dt2);
            return ds;
        }

        //public DataSet GetAlbumByID(string ID, string StartNum, string NextNum)
        //{
        //    string sql1 = "SELECT * FROM tAlbum WHERE AlbumID=@AlbumID1";
        //    string sql2 = "SELECT * FROM tPhoto WHERE AlbumID=@AlbumID ORDER BY PhotoID OFFSET @StartNum ROW FETCH NEXT @NextNum ROWS only";
        //    string sql3 = "SELECT count(*) AS RowNum FROM tPhoto WHERE AlbumID=@AlbumID0";
        //    SqlParameter[] parameters0 = { new SqlParameter("@AlbumID0", SqlDbType.Int) };
        //    parameters0[0].Value = ID;
        //    SqlParameter[] parameters1 = { new SqlParameter("@AlbumID1", SqlDbType.Int) };
        //    parameters1[0].Value = ID;
        //    SqlParameter[] parameters2 = {
        //                                     new SqlParameter("@AlbumID", SqlDbType.Int) ,
        //                                     new SqlParameter("@StartNum", SqlDbType.Int) ,
        //                                     new SqlParameter("@NextNum", SqlDbType.Int)
        //                                 };
        //    parameters2[0].Value = ID;
        //    parameters2[1].Value = StartNum;
        //    parameters2[2].Value = NextNum;
        //    DataTable dt0 = cmd.SqlToDataTable(sql3, parameters0);
        //    DataTable dt1 = cmd.SqlToDataTable(sql1, parameters1);
        //    DataTable dt2 = cmd.SqlToDataTable(sql2, parameters2);
        //    DataSet ds = new DataSet();
        //    ds.Tables.Add(dt0);
        //    ds.Tables.Add(dt1);
        //    ds.Tables.Add(dt2);
        //    return ds;
        //}

        //public DataSet GetAlbum(string StartNum, string NextNum)
        //{
        //    string sql1 = "SELECT count(*) AS RowNum FROM tAlbum";
        //    string sql2 = "SELECT * FROM tAlbum ORDER BY AlbumID DESC OFFSET @StartNum ROW FETCH NEXT @NextNum ROWS only";
        //    SqlParameter[] parameters = {
        //                                     new SqlParameter("@StartNum", SqlDbType.Int) ,
        //                                     new SqlParameter("@NextNum", SqlDbType.Int)
        //                                 };
        //    parameters[0].Value = StartNum;
        //    parameters[1].Value = NextNum;
        //    DataTable dt1 = cmd.SqlToDataTable(sql1);
        //    DataTable dt2 = cmd.SqlToDataTable(sql2, parameters);
        //    DataSet ds = new DataSet();
        //    ds.Tables.Add(dt1);
        //    ds.Tables.Add(dt2);
        //    return ds;
        //}
    }
}
