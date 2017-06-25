using System;

namespace NEILREN
{
    /// <summary>
    /// 数据库照片表
    /// </summary>
    public class tPhoto
    {
        /// <summary>
        /// 照片ID
        /// </summary>
        public int PhotoID { get; set; }
        /// <summary>
        /// 所属相册
        /// </summary>
        public int AlbumID { get; set; }
        /// <summary>
        /// 照片地址
        /// </summary>
        public string PhotoURL { get; set; }
        /// <summary>
        /// 照片名
        /// </summary>
        public string PhotoTitle { get; set; }
        /// <summary>
        /// 照片描述
        /// </summary>
        public string PhotoDesc { get; set; }
    }
}
