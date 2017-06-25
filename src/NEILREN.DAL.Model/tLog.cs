using System;

namespace NEILREN
{
    /// <summary>
    /// 数据库日志表
    /// </summary>
    public class tLog
    {
        /// <summary>
        /// 系统日志编号
        /// </summary>
        public int LogID { get; set; }
        /// <summary>
        /// 日志日期
        /// </summary>
        public DateTime LogDate { get; set; }
        /// <summary>
        /// 日志类型
        /// </summary>
        public string LogType { get; set; }
        /// <summary>
        /// 日志内容
        /// </summary>
        public string LogContent { get; set; }
    }
}
