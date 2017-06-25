using System;

namespace NEILREN
{
    /// <summary>
    /// 数据库说说表
    /// </summary>
    public class tTalking
    {
        /// <summary>
        /// 说说ID
        /// </summary>
        public int TalkID { get; set; }
        /// <summary>
        /// 表类别
        /// </summary>
        public string TableType { get; set; }
        /// <summary>
        /// 特色图像
        /// </summary>
        public string TalkImage { get; set; }
        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime TalkDate { get; set; }
        /// <summary>
        /// 说说正文
        /// </summary>
        public string TalkContent { get; set; }
    }
}
