using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

///教程文章实体类
namespace TrainByThreeTier.DAL
{
    public class mArticle
    {
        public int ID { get; set; }
        public int ClassID { get; set; }
        public string aCode { get; set; }
        public string Title { get; set; }
        public DateTime PublishDate { get; set; }
        public string CoverImg { get; set; }
        public int AuthorID { get; set; }
        public string Author { get; set; }
        public string Remark { get; set; }
        public string Content { get; set; }
        public int PraiseCount { get; set; }
        public int ClickCount { get; set; }
        public int CommentCount { get; set; }
        public string Tag { get; set; }
        public int State { get; set; }
    }
}