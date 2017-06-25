using System;

namespace NEILREN
{
    /// <summary>
    /// 数据库相册表
    /// </summary>
    public class tAlbum
    {
        /// <summary>
        /// 相册编号
        /// </summary>
        public int AlbumID { get; set; }
        /// <summary>
        /// 表类别
        /// </summary>
        public string TableType { get; set; }
        /// <summary>
        /// 相册名
        /// </summary>
        public string AlbumTitle { get; set; }
        /// <summary>
        /// 相册描述
        /// </summary>
        public string AlbumDesc { get; set; }
        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime AlbumDate { get; set; }
        /// <summary>
        /// 缩略图
        /// </summary>
        public string AlbumImage { get; set; }
    }
}
