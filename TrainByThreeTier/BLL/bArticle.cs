using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data ;
using TrainByThreeTier.DAL;
using TrainByThreeTier.Common;

///教程文章逻辑处理类
namespace TrainByThreeTier.BLL
{
    public class bArticle
    {
        /// <summary>
        /// 前台教程文章调用方法
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<mArticle> getArticle(int pageIndex,int pageSize)
        {
            
            List<mArticle> listArticle = GetArticleList(cGlobal.OrderBy.ID ,cGlobal.OrderByRole.Desc,pageIndex, pageSize);

            return listArticle;
        }

        /// <summary>
        /// 这是一个完整的返回文章列表的方法，内部使用，根据不同的应用场景设置不同的参数来返回数据
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="classID"></param>
        /// <param name="AuthorID"></param>
        /// <returns></returns>
        private List<mArticle> GetArticleList(cGlobal.OrderBy orderby,cGlobal.OrderByRole orderByRole, int pageIndex, int pageSize = 10, int classID = 0, int AuthorID = -1)
        {
            DAL.dArticle da = new dArticle();

            int rowCount=0;
            DataTable d = da.GetArticleList(pageIndex, pageSize, out rowCount, orderby, orderByRole, -1, -1);

            if (d == null)
                return null;

            //将datatable转换为list，这个过程可以写一个公共类来处理，但在这个项目就直接转了
            List<mArticle> listArticle=new List<mArticle> ();
            for (int i = 0; i < d.Rows.Count;i++ )
            {
                mArticle ma = new mArticle();
                ma.ID = int.Parse (d.Rows[i]["ID"].ToString());
                ma.aCode = d.Rows[i]["aCode"].ToString();
                ma.ClassID = int.Parse (d.Rows[i]["ClassID"].ToString());
                ma.CoverImg = d.Rows[i]["CoverImg"].ToString();
                ma.Title = d.Rows[i]["Title"].ToString();
                ma.PublishDate = DateTime.Parse ( d.Rows[i]["PublishDate"].ToString());
                ma.AuthorID = int.Parse (d.Rows[i]["AuthorID"].ToString());
                ma.Author = d.Rows[i]["Author"].ToString();
                ma.Remark = d.Rows[i]["Remark"].ToString();
                ma.Content = d.Rows[i]["Content"].ToString();
                ma.PraiseCount =int.Parse ( d.Rows[i]["ZanCount"].ToString());
                ma.ClickCount = int.Parse ( d.Rows[i]["ClickCount"].ToString());
                ma.CommentCount = int.Parse ( d.Rows[i]["CommentCount"].ToString());
                ma.Tag = d.Rows[i]["Tag"].ToString();
                ma.State = int.Parse(d.Rows[i]["State"].ToString());

                listArticle.Add(ma);

            }


            return listArticle;
        }
    }
}