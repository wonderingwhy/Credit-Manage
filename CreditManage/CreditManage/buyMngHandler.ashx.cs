using BLL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CreditManage
{
    /// <summary>
    /// buyMngHandler 的摘要说明
    /// </summary>
    public class buyMngHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
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

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}