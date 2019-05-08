using BLL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CreditManage
{
    /// <summary>
    /// valueHandler 的摘要说明
    /// </summary>
    public class valueHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            if (context.Request["phone"] == null)
            {
                return;
            }
            string phone = context.Request["phone"];
            Person person=new Person();
            AdminMng.QueryPersonByPhone(phone, ref person);
            List<Value> list = new List<Value>();
            PersonMng.GetValue(person.Id, ref list);
            list.Reverse(0, list.Count);
            var Data = new { values = list, value = person.Value };
            string html = CommonHelper.RenderHtml("valueHistory.html", Data);
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