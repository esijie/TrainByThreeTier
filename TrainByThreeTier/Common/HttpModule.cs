using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainByThreeTier.Common
{
    public class HttpModule : System.Web.IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(ReUrl_BeginRequest);
        }

        public void Dispose()
        {

        }

        /// <summary>
        /// 重写Url
        /// </summary>
        /// <param name="sender">事件的源</param>
        /// <param name="e">包含事件数据的 EventArgs</param>
        private void ReUrl_BeginRequest(object sender, EventArgs e)
        {
            HttpContext context = ((HttpApplication)sender).Context;
            string requestPath = context.Request.Path.ToLower();
            string aUrl = context.Request.RawUrl;

            #region 伪静态页面处理

            //这个处理教程文章的伪静态请求
            if (requestPath.StartsWith("/UI/home", StringComparison.CurrentCultureIgnoreCase)
                && aUrl.EndsWith("html", StringComparison.CurrentCultureIgnoreCase))
            {
                string url = string.Empty;

                string uPath = requestPath.ToLower();
                if (uPath.IndexOf("_") > 0)
                {
                    //带翻页
                    uPath = uPath.Replace("/UI/home_", "").Replace(".html", "");
                    url = "/ui/home.aspx?pindex=" + uPath;
                }
                else
                {
                    uPath = uPath.Replace("/UI/home_/", "").Replace(".html", "");
                    url = "/ui/home.aspx";
                }
                context.RewritePath(url);

            }

            #endregion
        }
    }
}