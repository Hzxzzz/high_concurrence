using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KDIT.QPAL.Models;
using MainWeb.ServiceReference;

namespace MainWeb.Controllers
{
    // 主进程
    public class TestController : Controller
    {
        ServiceClient s = new ServiceClient();
        /// <summary>
        /// 对外秒杀接口
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool TestBehavior(int Id)
        {
            // 获取用户
            var c = VisitorHelper.GetCurrentUser(HttpContext);
            return s.OrderFormBehavior(c.Id, Id);
        }
        /// <summary>
        /// 测试用展示库存
        /// </summary>
        /// <returns></returns>
        public JsonResult ShowCount()
        {
            return Json(s.GetCommodity(), JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 测试用重置库存
        /// </summary>
        /// <returns></returns>
        public bool StokInit()
        {
            return s.StokInit();
        }
    }
    public class VisitorHelper
    {
        //获取当前用户身份信息
        public static CRM_Customer GetCurrentUser(HttpContextBase httpcontext, String OpenId = null)
        {
            WebDatabase db = new WebDatabase();
            CRM_Customer c = null;

            if (!String.IsNullOrEmpty(OpenId))//OpenId优先级最高
            {
                c = db.Customers.FirstOrDefault(e => e.OpenId == OpenId);
            }
            if (c == null && httpcontext.Session["CurrentUser"] != null //Session凭据
                && httpcontext.Session["CurrentUser"] as CRM_Customer != null)
            {
                var _t = httpcontext.Session["CurrentUser"] as CRM_Customer;
                if (_t != null)
                    c = db.Customers.FirstOrDefault(e => e.Id == _t.Id);
            }
            if (c == null && httpcontext.Request.Cookies.Get("UserToken") != null)//Cookie凭据
            {
                String Token = httpcontext.Request.Cookies.Get("UserToken").Value;
                c = db.Customers.FirstOrDefault(e => e.Token == Token);
            }

            if (c != null)
            {
                c.VisitDate = DateTime.Now;
                if (String.IsNullOrEmpty(c.Token))
                    c.Token = Guid.NewGuid().ToString();
                if (!String.IsNullOrEmpty(OpenId))
                    c.OpenId = OpenId;
                db.SaveChanges();
            }
            else//初次访问新客户
            {
                c = new CRM_Customer
                {
                    Token = Guid.NewGuid().ToString(),
                    GroupId = db.Groups.FirstOrDefault().Id,
                    VisitDate = DateTime.Now,
                    InitiationDate = DateTime.Now,
                    OpenId = OpenId
                };
                db.Customers.Add(c);
                db.SaveChanges();
            }


            httpcontext.Session["CurrentUser"] = c;
            return c;
        }
    }
}
