using System;
using NEILREN.DAL;

namespace NEILREN.Models
{
    /// <summary>
    /// 旧博客地址转新地址
    /// </summary>
    public class BlogTransfer
    {
        public String OldID { get; set; }
        public String NewID { get; set; }
        public Boolean Finish { get; set; }
        public BlogTransfer(string OldID)
        {
            this.OldID = OldID;
            Finish = false;
        }

        public void GetNewID()
        {
            PostToArticle PTA = new PostToArticle();
            string newid = PTA.GetNewID(this.OldID);
            if (newid != "-1")
            {
                this.NewID = newid;
                Finish = true;
            }
            else
                Finish = false;
        }
    }
}