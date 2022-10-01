using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2mvc.Controllers
{
    public class 不加控制器后缀Controller : Controller
    {
        // GET: 不加控制器后缀
        public ActionResult 索引页()
        {
            return View("测试视图1");
        }
    }
}