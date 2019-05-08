using BLL;
using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace CreditManage
{
    /// <summary>
    /// mHandler 的摘要说明
    /// </summary>
    public class mHandler : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            List <Good> list=new List<Good>();
            PersonMng.GetGood(ref list);
            var Data = new { goods = list };
            string html = CommonHelper.RenderHtml("index.html", Data);
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