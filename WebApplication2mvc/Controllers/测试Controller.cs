using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2mvc.Controllers
{
    public class 测试Controller : Controller
    {
        // GET: 测试
        public ActionResult Index()
        {
            return View("测试对应的视图");
        }
    }
}