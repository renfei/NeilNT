using System;
using NEILREN.DAL;
using System.Data;

namespace NEILREN.Models
{
    /// <summary>
    /// 文章分类
    /// </summary>
    public class CategoryModel
    {
        /// <summary>
        /// 分类ID
        /// </summary>
        public String CatID { get; set; }
        /// <summary>
        /// 分类英文名
        /// </summary>
        public String CatEnName { get; set; }
        /// <summary>
        /// 分类中文名
        /// </summary>
        public String CatCnName { get; set; }
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public CategoryModel() { }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="CatID"></param>
        public CategoryModel(String CatID)
        {
            this.CatID = CatID;
            tCategoryDAL getObj = new tCategoryDAL();
            DataTable dt = getObj.GetByCatID(this.CatID);
            if (dt != null && dt.Rows.Count > 0)
            {
                this.CatEnName = dt.Rows[0]["CatEnName"].ToString();
                this.CatCnName = dt.Rows[0]["CatCnName"].ToString();
            }
            else
            {
                this.CatID = null;
            }
        }
    }
}