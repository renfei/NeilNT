using System;

namespace NEILREN
{
    /// <summary>
    /// 数据库评论表
    /// </summary>
    public class tComment
    {
        /// <summary>
        /// 评论ID
        /// </summary>
        public int CommentID { get; set; }
        /// <summary>
        /// 被评论的文章/说说/相册/照片
        /// </summary>
        public int ObjectID { get; set; }
        /// <summary>
        /// 评论类型，评论q文章2说说3相册4相片
        /// </summary>
        public int CommentType { get; set; }
        /// <summary>
        /// 评论者称呼
        /// </summary>
        public string AuthorName { get; set; }
        /// <summary>
        /// 评论者邮箱
        /// </summary>
        public string AuthorEmail { get; set; }
        /// <summary>
        /// 评论者URL
        /// </summary>
        public string AuthorURL { get; set; }
        /// <summary>
        /// 评论者IP
        /// </summary>
        public string AuthorIP { get; set; }
        /// <summary>
        /// 评论时间
        /// </summary>
        public DateTime CommentDate { get; set; }
        /// <summary>
        /// 评论正文
        /// </summary>
        public string CommentContent { get; set; }
        /// <summary>
        /// 父级评论ID
        /// </summary>
        public int CommentParent { get; set; }
        /// <summary>
        /// 评论用户ID(注册用户)
        /// </summary>
        public int UserID { get; set; }
    }
}
