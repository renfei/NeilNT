using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Text;
using System.Threading;

namespace NEILREN.Models
{
    public class SendMail
    {
        /// <summary>
        /// 要发送的邮箱
        /// </summary>
        public string email { get; set; }
        /// <summary>
        /// 邮箱主题
        /// </summary>
        public string subject { get; set; }
        /// <summary>
        /// 邮箱内容
        /// </summary>
        public string content { get; set; }

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="mailTo">要发送的邮箱</param>
        /// <param name="mailSubject">邮箱主题</param>
        /// <param name="mailContent">邮箱内容</param>
        /// <returns>返回发送邮箱的结果</returns>
        public void SendEmail()
        {
            // 设置发送方的邮件信息
            string smtpServer = "smtp.neilren.com"; //SMTP服务器
            string mailFrom = "no-reply@neilren.com"; //登陆用户名
            string userPassword = "Rf,.,116";//登陆密码

            // 邮件服务设置
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;//指定电子邮件发送方式
            smtpClient.Host = smtpServer; //指定SMTP服务器
            smtpClient.Credentials = new System.Net.NetworkCredential(mailFrom, userPassword);//用户名和密码

            // 发送邮件设置
            MailMessage mailMessage = new MailMessage(mailFrom, this.email); // 发送人和收件人
            mailMessage.Subject = this.subject;//主题
            mailMessage.Body = this.content;//内容
            mailMessage.BodyEncoding = Encoding.UTF8;//正文编码
            mailMessage.IsBodyHtml = true;//设置为HTML格式
            mailMessage.Priority = MailPriority.Normal;//优先级

            try
            {
                smtpClient.Send(mailMessage); // 发送邮件
                //return true;
            }
            catch (SmtpException ex)
            {
                //return false;
            }
        }
    }
}