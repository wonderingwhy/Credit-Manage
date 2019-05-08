using BLL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CreditManage
{
    /// <summary>
    /// userMng 的摘要说明
    /// </summary>
    public class userMng : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            if (context.Request["phone"] == null && context.Request["val"] == null)
            {
                context.Response.ContentType = "text/html";
                List<Person> list = new List<Person>();
                AdminMng.QueryPersonAll(ref list);
                var Data = new { persons = list };
                string html = CommonHelper.RenderHtml("userMng.html", Data);
                context.Response.Write(html);
                return;
            }
            else if(context.Request["phone"] != null && context.Request["val"] != null)
            {
                context.Response.ContentType = "text/plain";
                string phone = context.Request["phone"];
                int val = Convert.ToInt32(context.Request["val"]);
                Person person = new Person();
                AdminMng.QueryPersonByPhone(phone, ref person);
                person.Value = val;
                int res = AdminMng.EditPerson(person);
                if (res == 0)
                {
                    context.Response.Write("ok");
                }
                else
                {
                    context.Response.Write("no");
                }
            }
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