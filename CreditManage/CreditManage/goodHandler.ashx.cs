using BLL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace CreditManage
{
    /// <summary>
    /// goodHandler 的摘要说明
    /// </summary>
    public class goodHandler : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            List<Good> list = new List<Good>();
            PersonMng.GetGood(ref list);
            var Data = new { goods = list};
            string html = CommonHelper.RenderHtml("products.html", Data);
            context.Response.Write(html);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}