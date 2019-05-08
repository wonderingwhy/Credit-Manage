using BLL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CreditManage
{
    /// <summary>
    /// buyHandler 的摘要说明
    /// </summary>
    public class buyHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            Person person = new Person();
            AdminMng.QueryPersonByPhone(context.Request["phone"], ref person);
            /*
            if (context.Request["goodId"] != null)
            {
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
            if (person.IsAdmin == true)
            {
                List<Person> p = new List<Person>();
                List<Good> g = new List<Good>();
                List<Buy> b = new List<Buy>();
                AdminMng.GetBuyAll(ref b, ref g, ref p);
                List<BuyShow> bss = new List<BuyShow>();
                for (int i = 0; i < p.Count; ++i)
                {
                    BuyShow bs = new BuyShow();
                    bs.person = p[i];
                    bs.good = g[i];
                    bs.buy = b[i];
                    bs.sum = b[i].Num * g[i].Value;
                    bss.Add(bs);
                }
                bss.Reverse(0, bss.Count);
                var Data = new { data = bss };
                string html = CommonHelper.RenderHtml("check.html", Data);
                context.Response.Write(html);
            }
            else
            {*/
                List<Person> p = new List<Person>();
                List<Good> g = new List<Good>();
                List<Buy> b = new List<Buy>();
                PersonMng.GetBuy(person.Id, ref b, ref g, ref p);
                List<BuyShow> bss = new List<BuyShow>();
                for (int i = 0; i < p.Count; ++i)
                {
                    BuyShow bs = new BuyShow();
                    bs.person = p[i];
                    bs.good = g[i];
                    bs.buy = b[i];
                    bs.sum = b[i].Num * g[i].Value;
                    bss.Add(bs);
                }
                bss.Reverse(0, bss.Count);
                var Data = new { data = bss };
                string html = CommonHelper.RenderHtml("history.html", Data);
                context.Response.Write(html);
            //}
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