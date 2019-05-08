using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CreditManage
{
    /// <summary>
    /// checkHandler 的摘要说明
    /// </summary>
    public class checkHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string phone = context.Request["CheckPhone"];
            if (context.Request["buyId"] != null)
            {
                int res = AdminMng.CheckBuy(Convert.ToInt32(context.Request["buyId"]));
                if (res == 0)
                {
                    context.Response.Write("ok");
                }
                else
                {
                    context.Response.Write("no");
                }
                return;
            }
            if (PersonSvc.RetrieveByPhone(phone).Count != 0)
            {
                context.Response.Write("no");
                return;
            }
            context.Response.Write("ok");
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