using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace CreditManage
{
    /// <summary>
    /// logoutHandler 的摘要说明
    /// </summary>
    public class logoutHandler : IHttpHandler,IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Session.Remove("UserName");
            context.Response.Redirect("mHandler.ashx");
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