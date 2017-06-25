using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NEILREN.DAL;
using System.Data;

namespace NEILREN.Models
{
    public class SearchModel
    {
        public Int32 Total { get; set; }
        public List<Metadata> Meta { get; set; }
        public class Metadata
        {
            public String TITLE { get; set; }
            public String ID { get; set; }
            public String TYPE { get; set; }
            public String IMAGE { get; set; }
            public String CONTENT { get; set; }
            public String DATE { get; set; }
        }

        public SearchModel(string Search, string PageNum)
        {
            try
            {
                int PagNum = Int32.Parse(PageNum);
                PagNum = (PagNum - 1) * 10;
                SearchDAL DAL=new SearchDAL();
                DataSet ds = DAL.SearchByWd(Search,PagNum.ToString(), "10");
                //计算总行数
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Total += Int32.Parse(ds.Tables[0].Rows[i]["RowNum"].ToString());
                }
                int pag = Total / 10;
                if (Total % 10 > 0)
                    pag++;
                Total = pag;
                DataTable dt = ds.Tables[1];
                List<Metadata> ListObj = new List<Metadata>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Metadata obj = new Metadata();
                    obj.TITLE = dt.Rows[i]["TITLE"].ToString();
                    obj.ID = dt.Rows[i]["ID"].ToString();
                    obj.TYPE = dt.Rows[i]["TTYPE"].ToString();
                    obj.IMAGE = dt.Rows[i]["IMAGES"].ToString();
                    obj.CONTENT = dt.Rows[i]["CONTENT"].ToString();
                    obj.DATE = dt.Rows[i]["DATET"].ToString();
                    ListObj.Add(obj);
                }
                this.Meta = ListObj;
            }
            catch (Exception)
            {
                
            }
        }
    }
}