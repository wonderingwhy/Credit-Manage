using BLL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CreditManage
{
    /// <summary>
    /// buyHandler1 的摘要说明
    /// </summary>
    public class buyHandler1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            if (context.Request["goodId"] == null||context.Request["phone"]==null)
            {
                return;
            }
            Person person = new Person();
            AdminMng.QueryPersonByPhone(context.Request["phone"], ref person);
            Good good = new Good();
            PersonMng.GetGoodById(Convert.ToInt32(context.Request["goodId"]), ref good);
            Buy buy = new Buy();
            buy.PersonId = person.Id;
            buy.GoodId = good.Id;
            buy.IsCheck = false;
            buy.Num = Convert.ToInt32(context.Request["num"]);
            buy.Date = System.DateTime.Now.ToString();
            PersonMng.AddBuy(buy);
            context.Response.Redirect("goodHandler.ashx");
            return;
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