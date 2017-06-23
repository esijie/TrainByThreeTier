using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data ;
using TrainByThreeTier.Common;

///教程文章数据访问类
namespace TrainByThreeTier.DAL
{
    public class dArticle
    {
        /// <summary>
        /// 获取教程文章列表
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="step"></param>
        /// <param name="rowCount">返回总条数</param>
        /// <param name="orderby"></param>
        /// <param name="orderByRole"></param>
        /// <param name="ClassID">如果查询所有，请输入-1</param>
        /// <param name="authorID">如果查询所有，请输入-1</param>
        /// <returns></returns>
        public DataTable GetArticleList(int startIndex,int step,out int rowCount,cGlobal.OrderBy orderby, cGlobal.OrderByRole orderByRole, int ClassID,int authorID)
        {
            
            string sql = "select * from sys_article " ;
            string sqlWhere=string.Empty ;

            if (ClassID>-1)
            {
                sqlWhere+=" and ClassID=" + ClassID;
            }

            if (authorID>-1)
            {
                sqlWhere+=" and AutherID=" + ClassID;
            }

            if (!string.IsNullOrEmpty (sqlWhere))
            {
                sql=sql + " where " + sqlWhere.Substring (3,sqlWhere.Length -3);
            }

            switch(orderby )
            {
                case cGlobal.OrderBy.ID:
                    sql+=" order by ID";
                    break ;
                case cGlobal.OrderBy.PublishDate:
                    sql+=" order by PublishDate";
                    break ;
                case cGlobal.OrderBy.Count:
                    sql+=" order by CommentCount";
                    break ;
                default :
                    sql+=" order by ID";
                    break ;
            }

            switch(orderByRole)
            {
                case cGlobal.OrderByRole.Asc:
                    break;
                case cGlobal.OrderByRole.Desc:
                    sql += " DESC";
                    break;
            }

            int rowIndex = step * (startIndex - 1);
            sql += " limit " + rowIndex + "," + step + ";";
            sql += "select count(ID) from sys_article ";

            DataSet ds = SqlHelper.ExecuteDataset(sql);
            DataTable tb = null;
            rowCount = 0;

            if (ds != null || ds.Tables.Count > 0)
            {

                tb = ds.Tables[0];

                if (ds.Tables.Count > 1)
                    int.TryParse(ds.Tables[1].Rows[0][0].ToString(), out rowCount);
            }

            return tb;
        }
    }
}