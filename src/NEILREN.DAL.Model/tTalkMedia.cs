using System;

namespace NEILREN
{
    /// <summary>
    /// 数据库说说媒体表
    /// </summary>
    public class tTalkMedia
    {
        /// <summary>
        /// 媒体ID
        /// </summary>
        public int MediaID { get; set; }
        /// <summary>
        /// 说说ID
        /// </summary>
        public int TalkID { get; set; }
        /// <summary>
        /// 媒体类别,1图片,2自有视频,3站外视频,4音乐
        /// </summary>
        public int MediaType { get; set; }
        /// <summary>
        /// 媒体内容
        /// </summary>
        public string MediaContent { get; set; }
    }
}
