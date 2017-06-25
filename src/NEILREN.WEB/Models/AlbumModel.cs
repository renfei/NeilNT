using NEILREN.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace NEILREN.Models
{
    public class AlbumModel
    {
        public Album Album { get; set; }
        public Int32 Total { get; set; }
        public List<Album> AlbumList { get; set; }
        /// <summary>
        /// 实例化一个相册列表
        /// </summary>
        public AlbumModel(string PageNum)
        {
            int PagNum = Int32.Parse(PageNum);
            PagNum = (PagNum - 1) * 16;
            AlbumDAL DAL = new AlbumDAL();
            DataSet ds = DAL.GetAlbum(PagNum.ToString(), "16");
            //计算总页数，16个一页
            Total = Int32.Parse(ds.Tables[0].Rows[0]["RowNum"].ToString());
            int pag = Total / 16;
            if (Total % 16 > 0)
                pag++;
            Total = pag;
            DataTable dt1 = ds.Tables[1];
            List<Album> AlbumList = new List<Album>();
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                Album obj = new Album();
                obj.AlbumID = dt1.Rows[i]["AlbumID"].ToString();
                obj.TableType = dt1.Rows[i]["TableType"].ToString();
                obj.AlbumTitle = dt1.Rows[i]["AlbumTitle"].ToString();
                obj.AlbumDesc = dt1.Rows[i]["AlbumDesc"].ToString();
                obj.AlbumDate = DateTime.Parse(dt1.Rows[i]["AlbumDate"].ToString());
                obj.AlbumImage = dt1.Rows[i]["AlbumImage"].ToString();
                AlbumList.Add(obj);
            }
            this.AlbumList = AlbumList;
        }
        /// <summary>
        /// 根据相册ID实例化一个相册
        /// </summary>
        /// <param name="id"></param>
        public AlbumModel(string id,string PageNum)
        {
            this.Album = new Album(id,PageNum);
        }
    }
    /// <summary>
    /// 相册基类
    /// </summary>
    public class Album
    {
        public String AlbumID { get; set; }
        public String TableType { get; set; }
        public String AlbumTitle { get; set; }
        public String AlbumDesc { get; set; }
        public DateTime AlbumDate { get; set; }
        public String AlbumImage { get; set; }
        public Int32 Total { get; set; }
        public List<Photo> PhotoList { get; set; }
        /// <summary>
        /// 默认构造函数，不包含相片
        /// </summary>
        public Album()
        {
        }
        /// <summary>
        /// 实例化一个具体的相册，包含相片
        /// </summary>
        /// <param name="id"></param>
        public Album(string id,string PageNum)
        {
            int PagNum = Int32.Parse(PageNum);
            PagNum = (PagNum - 1) * 16;
            AlbumDAL DAL = new AlbumDAL();
            DataSet ds = DAL.GetAlbumByID(id,PagNum.ToString(), "16");
            Total = Int32.Parse(ds.Tables[0].Rows[0]["RowNum"].ToString());
            //计算总页数，16个一页
            int pag = Total / 16;
            if (Total % 16 > 0)
                pag++;
            Total = pag;
            DataTable dt1 = ds.Tables[1];
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                this.AlbumID = dt1.Rows[i]["AlbumID"].ToString();
                this.TableType = dt1.Rows[i]["TableType"].ToString();
                this.AlbumTitle = dt1.Rows[i]["AlbumTitle"].ToString();
                this.AlbumDesc = dt1.Rows[i]["AlbumDesc"].ToString();
                this.AlbumDate = DateTime.Parse(dt1.Rows[i]["AlbumDate"].ToString());
                this.AlbumImage = dt1.Rows[i]["AlbumImage"].ToString();
            }
            DataTable dt2 = ds.Tables[2];
            List<Photo> PhotoList = new List<Photo>();
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                Photo obj = new Photo();
                obj.PhotoID = dt2.Rows[i]["PhotoID"].ToString();
                obj.AlbumID = dt2.Rows[i]["AlbumID"].ToString();
                obj.PhotoURL = dt2.Rows[i]["PhotoURL"].ToString();
                obj.PhotoTitle = dt2.Rows[i]["PhotoTitle"].ToString();
                obj.PhotoDesc = dt2.Rows[i]["PhotoDesc"].ToString();
                PhotoList.Add(obj);
            }
            this.PhotoList = PhotoList;
        }
    }

    /// <summary>
    /// 照片基类
    /// </summary>
    public class Photo
    {
        public String PhotoID { get; set; }
        public String AlbumID { get; set; }
        public String PhotoURL { get; set; }
        public String PhotoTitle { get; set; }
        public String PhotoDesc { get; set; }
    }
}