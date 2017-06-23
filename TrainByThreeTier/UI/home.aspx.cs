using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TrainByThreeTier.DAL;

namespace TrainByThreeTier.UI
{
    public partial class home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //当前的页码
                int pIndex = 1;
                //每页显示的条目数量
                int pSize = 10;

                if (Request.QueryString["code"]!=null)
                {
                    if (!int.TryParse(Request.QueryString["code"].ToString(), out pIndex))
                        pIndex = 1;
                }

                BindData(pIndex, pSize);
            }
        }

        private void BindData(int pIndex,int pSize)
        {
            BLL.bArticle ba=new BLL.bArticle ();
            List<mArticle> listArticle=ba.getArticle(pIndex ,pSize );
            this.listAL.DataSource = listArticle;
            this.listAL.DataBind();
        }
    }
}