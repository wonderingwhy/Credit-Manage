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
    /// logHandler 的摘要说明
    /// </summary>
    public class logHandler : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            
            context.Response.ContentType = "text/plain";
            if (context.Request["phone"] != null && context.Request["psd"] != null)
            {
                Person person = new Person();
                person.Phone = context.Request["phone"];
                person.Psd = context.Request["psd"];
                int res = PersonMng.Log(ref person);
                if (res == 0)
                {
                    if (person.IsAdmin == true)
                    {
                        context.Session["UserName"] = person.Phone + "a";
                    }
                    else
                    {
                        context.Session["UserName"] = person.Phone + "p";
                    }
                    context.Response.Write(context.Session["UserName"]);
                    return;
                }
                context.Response.Write("no");
                return;
            }
            if (context.Session == null)
            {
                context.Response.Write("no");
                return;
            }
            if (context.Session["UserName"] == null)
            {
                context.Response.Write("no");
                return;
            }
            context.Response.Write(context.Session["UserName"]);
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