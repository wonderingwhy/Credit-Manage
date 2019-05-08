using BLL;
using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CreditManage
{
    /// <summary>
    /// regHandler 的摘要说明
    /// </summary>
    public class regHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            Person person = new Person();
            person.Phone = context.Request["phone"];
            person.Psd = context.Request["psd"];
            person.IsAdmin = false;
            int res = PersonMng.Reg(person);
            if (res == 0)
            {
                context.Response.Write("<script>alert('注册成功');window.location.href='mHandler.ashx';</script>");
            }
            else if (res == -1)
            {
                context.Response.Write("<script>alert('注册失败');window.location.href='mHandler.ashx';</script>");
            }
            else
            {
                context.Response.Write("<script>alert('未知错误');window.location.href='mHandler.ashx';</script>");
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