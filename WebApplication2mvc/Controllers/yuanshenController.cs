using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebApplication2mvc.Data_Access_Layer;
using WebApplication2mvc.Models;
using WebApplication2mvc.ViewModels;

namespace WebApplication2mvc.Controllers
{


   

    public class yuanshenController : Controller
    {

        private static string GetUniqueKey()
        {
            int maxSize = 8;
            int minSize = 5;
            char[] chars = new char[62];
            string a;
            a = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            chars = a.ToCharArray();
            int size = maxSize;
            byte[] data = new byte[1];

            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            crypto.GetNonZeroBytes(data);
            size = maxSize;
            data = new byte[size];
            crypto.GetNonZeroBytes(data);
            StringBuilder result = new StringBuilder(size);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length - 1)]);
            }
            return result.ToString();
        }

        public static string GetCheckCode(int codeCount)
        {
            string str = string.Empty;
            int rep = 0;
            long num2 = DateTime.Now.Ticks + rep;
            rep++;
            Random random = new Random(((int)(((ulong)num2) & 0xffffffffL)) | ((int)(num2 >> rep)));
            for (int i = 0; i < codeCount; i++)
            {
                char ch;
                int num = random.Next();
                if ((num % 2) == 0)
                    ch = (char)(0x30 + ((ushort)(num % 10)));
                else
                    ch = (char)(0x41 + ((ushort)(num % 0x1a)));
                str = str + ch.ToString();
            }
            return str;
        }


        // GET: yuanshen
        public ActionResult Index()
        {

          
                
                  

               // string str = string.Format("{0}{1}", DateTime.Now.ToString("yyyyMMddHHmmss"), GetUniqueKey());
            string str = GetCheckCode(15);
                ViewBag.测试=  str;
          


            return View("主页");
        }


        public ActionResult 每日任务()
        {

            // string str = string.Format("{0}{1}", DateTime.Now.ToString("yyyyMMddHHmmss"), GetUniqueKey());
        
            return View("每日任务");
        }


        public ActionResult 主页2()
        {

            // string str = string.Format("{0}{1}", DateTime.Now.ToString("yyyyMMddHHmmss"), GetUniqueKey());

            return View("主页2");
        }


        public ActionResult 旅行者大厅()
        {
            Model6 ddd = new Model6();
            List<需求表视图> eee = ddd.需求表视图.ToList();
          


            return View("旅行者大厅",eee);
        }

        public ActionResult 打手大厅()
        {
            Model6 ddd = new Model6();

            string sql = " select * from 打手表视图 where 打手类别='代肝' ";
            // string sql = " select * from 打手接单视图表1 ";
            List<打手表视图> eee = ddd.打手表视图.SqlQuery(sql).ToList();



            return View("打手大厅", eee);
        }


        public ActionResult 代肝故事计划()
        {
            Model6 ddd = new Model6();

            string sql = " select * from 打手表视图 where 打手类别='代肝' ";
            // string sql = " select * from 打手接单视图表1 ";
            List<打手表视图> eee = ddd.打手表视图.SqlQuery(sql).ToList();



            return View("代肝故事计划", eee);
        }



        public ActionResult 需求详情()
        {

            string 需求编号 = Request.QueryString["q"];
            ViewBag.需求编号 = 需求编号;
            Model6 ddd = new Model6();

            string sql = " select * from 打手接单视图表1 where 需求编号='" + 需求编号 + "'";
           // string sql = " select * from 打手接单视图表1 ";
            List<打手接单视图表1> eee = ddd.打手接单视图表1.SqlQuery(sql).ToList();


        
            foreach (打手接单视图表1 emp in eee)
            {
                

                System.Diagnostics.Debug.WriteLine(emp.打手qq);

               
            }





            return View("需求详情", eee);
        }


        public ActionResult 报价(打手接需求表 e)
        {

            Model6 aa = new Model6();


            string 判断打手是否存在 = " select * from 打手表 where qq='" + e.打手qq + "'";
            List<打手表> 订单返回 = aa.打手表.SqlQuery(判断打手是否存在).ToList();

            System.Diagnostics.Debug.WriteLine(订单返回.Count);
            if (订单返回.Count > 0) { aa.打手接需求表.Add(e); 
                try
                {
                    aa.SaveChanges();
                }

                catch (DbEntityValidationException dbEx)
                {

                    // System.Diagnostics.Debug.WriteLine(dbEx.ToString());
                } }


            string redirectUrl = "/需求详情";
            return RedirectToAction(redirectUrl, new
            {
                q = e.需求编号
            }) ;

           // return View("需求详情");
        }

        public string 查询买家qq()
        {
            Model6 aa = new Model6();
            string 买家输入qq = Request.QueryString["q"];
            string 需求编号 = Request.QueryString["q1"];
            System.Diagnostics.Debug.WriteLine(买家输入qq);
            System.Diagnostics.Debug.WriteLine(需求编号);
            string 判断订单是否存在 = " select * from 打手接单视图表1 where qq='" + 买家输入qq + "' and 需求编号='" + 需求编号 + "'" ;
            List<打手接单视图表1> 订单返回 = aa.打手接单视图表1.SqlQuery(判断订单是否存在).ToList();
            if (订单返回.Count == 0) { return "0"; }
            return "1";
        }


        public string 打手查询中标qq()
        {
            Model6 aa = new Model6();
            string 买家输入qq = Request.QueryString["q"];
            string 需求编号 = Request.QueryString["q1"];
            System.Diagnostics.Debug.WriteLine(买家输入qq);
            System.Diagnostics.Debug.WriteLine(需求编号);
            string 判断订单是否存在 = " select * from 打手接单视图表1 where 选择的打手qq='" + 买家输入qq + "' and 需求编号='" + 需求编号 + "'";
            List<打手接单视图表1> 订单返回 = aa.打手接单视图表1.SqlQuery(判断订单是否存在).ToList();
            if (订单返回.Count == 0) { return "0"; }
            return "1";
        }




        public ActionResult 需求详情选择打手()
        {

            string 需求编号 = Request.QueryString["q"];
            ViewBag.需求编号 = 需求编号;
            Model6 ddd = new Model6();

            string sql = " select * from 打手接单视图表1 where 需求编号='" + 需求编号 + "'";
            List<打手接单视图表1> eee = ddd.打手接单视图表1.SqlQuery(sql).ToList();


            return View("需求详情选择打手", eee);
        }



        public ActionResult 需求详情查看买家()
        {

            string 需求编号 = Request.QueryString["q"];
            ViewBag.需求编号 = 需求编号;
            Model6 ddd = new Model6();

            string sql = " select * from 打手接单视图表1 where 需求编号='" + 需求编号 + "'";
            List<打手接单视图表1> eee = ddd.打手接单视图表1.SqlQuery(sql).ToList();


            return View("需求详情查看买家", eee);
        }





        public string 确定打手()
        {
            Model6 aa = new Model6();
            string 选择的打手qq = Request.QueryString["q"];
            string 需求编号 = Request.QueryString["q1"];

            string sql = "  select  * from 需求表  where  需求编号='" + 需求编号 + "'";
            List<需求表> aaa = aa.需求表.SqlQuery(sql).ToList();

            foreach (需求表 emp in aaa)
            {
                if (emp.需求状态 == "已选择")
                {
                    return "已经选择" +emp.选择的打手qq;
                }

            }




            //   System.Diagnostics.Debug.WriteLine(选择的打手qq);
            // System.Diagnostics.Debug.WriteLine(需求编号);
            string sql1 = " update 需求表 set 选择的打手qq=" + 选择的打手qq + ",需求状态=  '已选择'  " + " where 需求编号='" + 需求编号 + "'; select  * from 打手接单视图表1  where  需求编号='" + 需求编号 + "'";
            //  string 判断订单是否存在 = " select * from 打手接单视图表1 where qq='" + 选择的打手qq + "' and 需求编号='" + 需求编号 + "'";
             List<打手接单视图表1> 订单返回 = aa.打手接单视图表1.SqlQuery(sql1).ToList();
            //  if (订单返回.Count == 0) { return "0"; }
            return 选择的打手qq;
        }



        public ActionResult 发布需求()
        {

            ViewBag.需求编号 = GetCheckCode(15);
            Model6 ddd = new Model6();
            List<需求表> eee = ddd.需求表.ToList();

           // DateTime.Now.ToLocalTime().ToString();
           // System.Diagnostics.Debug.WriteLine(DateTime.Now.ToLocalTime().ToString());

            return View("发布需求", eee);
        }


        public ActionResult 打手注册()
        {

            ViewBag.需求编号 = GetCheckCode(15);
            Model6 ddd = new Model6();
            List<需求表> eee = ddd.需求表.ToList();

            // DateTime.Now.ToLocalTime().ToString();
            // System.Diagnostics.Debug.WriteLine(DateTime.Now.ToLocalTime().ToString());

            return View("打手注册", eee);
        }





        public ActionResult 保存需求信息(需求表 e)
        {

            Model6 aa = new Model6();
            string 订单号 = Request.QueryString["dingdanhao"];
            string 判断订单是否存在 = " select * from 需求表 where 需求编号='" + 订单号 + "'";
            List<需求表> 订单返回 = aa.需求表.SqlQuery(判断订单是否存在).ToList();
            if (ModelState.IsValid)
            {
                System.Diagnostics.Debug.WriteLine(订单返回.Count);
                System.Diagnostics.Debug.WriteLine("aaaaaaaaaaa");

                List<string> keys = ModelState.Keys.ToList();  //测试错误信息
                foreach (var key in keys)
                {
                    var errors = ModelState[key].Errors.ToList();
                    foreach (var error in errors)
                    {
                       // Response.Write(error.ErrorMessage);
                        System.Diagnostics.Debug.WriteLine(error.ErrorMessage);


                    }
                }

 



                if (订单返回.Count == 0) { aa.需求表.Add(e); aa.SaveChanges(); }

                // salesDal.Employees.SqlQuery("SELECT * FROM  员工模型对应的表  WHERE lastname = @p0", "hhh");






                return RedirectToAction("旅行者大厅", 订单返回);

              //  return View("旅行者大厅", 订单返回);

            }
            else
            {
                System.Diagnostics.Debug.WriteLine(ModelState.IsValid);

                System.Diagnostics.Debug.WriteLine("bbbb");

                return RedirectToAction("旅行者大厅", 订单返回);

            }


        }



        public ActionResult 保存打手信息(打手表 e)
        {

            Model6 aa = new Model6();
            
            string 判断打手是否存在 = " select * from 打手表 where qq='" + e.qq + "'";
            List<打手表> 订单返回 = aa.打手表.SqlQuery(判断打手是否存在).ToList();
            if (ModelState.IsValid)
            {

                if (订单返回.Count == 0) { aa.打手表.Add(e); aa.SaveChanges(); }

                // salesDal.Employees.SqlQuery("SELECT * FROM  员工模型对应的表  WHERE lastname = @p0", "hhh");






                return RedirectToAction("打手大厅", 订单返回);

                //  return View("旅行者大厅", 订单返回);

            }
            else
            {


                // return RedirectToAction("打手注册", 订单返回);
                return View("打手注册" );


            }


        }




        public ActionResult 黑名单( )
        {
            Model6 aa = new Model6();
            List<黑名单视图> eee = aa.黑名单视图.ToList();
            return View("黑名单",eee);
        }


            public ActionResult 添加黑名单(黑名单 e)
        {


            Model6 aa = new Model6();


            string 判断打手是否存在 = " select * from 打手表 where qq='" + e.举报人qq + "'";
            List<打手表> 订单返回 = aa.打手表.SqlQuery(判断打手是否存在).ToList();

            System.Diagnostics.Debug.WriteLine(订单返回.Count);
            if (订单返回.Count > 0)
            {
                aa.黑名单.Add(e);
                try
                {
                    aa.SaveChanges();
                }

                catch (DbEntityValidationException dbEx)
                {

                    // System.Diagnostics.Debug.WriteLine(dbEx.ToString());
                }
            }


            List<黑名单视图> eee = aa.黑名单视图.ToList();
            return View("黑名单", eee);
        }









        public ActionResult cailiao()
        {
 



            Model6 ddd = new Model6();
            List<材料表> eee = ddd.材料表.ToList();
             List<材料表> eeee = ddd.材料表.SqlQuery(" select * from 材料表  ").ToList();

            //ddd.材料表.SqlQuery("update 材料表  set 材料单价=9999 ;select * from 材料表 where 材料名称='bb' ").ToList();
            
          var result = from i in ddd.材料表  //引用system.data.linq
                         select i;
            List<材料表> list = result.ToList();
            foreach (材料表 emp in list)
            {
                if (emp.材料名称 == "eee")
                {
                    ViewBag.linq ="linq测试";
                }

            }


            材料表 dd = new 材料表();
            foreach (材料表 emp in eeee)
            {
                dd.材料名称 = emp.材料名称;
                dd.材料类型 = emp.材料类型;

            }



        

            Model6 fff= new Model6();
            List<订单表视图> ggg = fff.订单表视图.ToList();

            foreach (订单表视图 emp in ggg)
            {
                if (emp.材料名称 == "eee")
                {
                    ViewBag.视图测试 = emp.材料单价;

                    ViewBag.视图数量 = emp.数量;
                }

            }





            return View("maicailiao", eeee);
        }

        public ActionResult cailiaoxiangqing()
        {

            Model6 ddd = new Model6();
            List<材料表视图> eee = ddd.材料表视图.ToList();
            ViewBag.订单编号 = GetCheckCode(15);

            材料表视图 dd = new 材料表视图();

            foreach (材料表视图 emp in eee)
            {
                if (emp.材料名称 == Request.QueryString["mingcheng"])
                {
                    ViewBag.材料单价 = emp.材料单价;


                    dd.对标时薪 = emp.对标时薪;
                    dd.大佬时薪 = emp.大佬时薪;
                    dd.萌新时薪 = emp.萌新时薪;

                    dd.材料名称 = emp.材料名称;
                    dd.材料数量 = emp.材料数量;
                    dd.大佬时间分钟 = emp.大佬时间分钟;
                    dd.萌新时间分钟 = emp.萌新时间分钟;
             
                    dd.大佬时间分钟 = emp.大佬时间分钟;





                }

            }

            return View("cailiaoxiangqing",dd);
        }



        public ActionResult 每日任务下单页面()
        {

            Model6 ddd = new Model6();
            List<材料表视图> eee = ddd.材料表视图.ToList();
            ViewBag.订单编号 = GetCheckCode(15);

            材料表视图 dd = new 材料表视图();

            foreach (材料表视图 emp in eee)
            {
                if (emp.材料名称 == Request.QueryString["mingcheng"])
                {
                    ViewBag.材料单价 = emp.材料单价;


                    dd.对标时薪 = emp.对标时薪;
                    dd.大佬时薪 = emp.大佬时薪;
                    dd.萌新时薪 = emp.萌新时薪;

                    dd.材料名称 = emp.材料名称;
                    dd.材料数量 = emp.材料数量;
                    dd.大佬时间分钟 = emp.大佬时间分钟;
                    dd.萌新时间分钟 = emp.萌新时间分钟;

                    dd.大佬时间分钟 = emp.大佬时间分钟;





                }

            }

            return View("每日任务下单页面", dd);
        }



        public ActionResult 每日任务下单页面数量()
        {

            Model6 ddd = new Model6();
            List<材料表视图> eee = ddd.材料表视图.ToList();
            ViewBag.订单编号 = GetCheckCode(15);

            材料表视图 dd = new 材料表视图();

            foreach (材料表视图 emp in eee)
            {
                if (emp.材料名称 == Request.QueryString["mingcheng"])
                {
                    ViewBag.材料单价 = emp.材料单价;


                    dd.对标时薪 = emp.对标时薪;
                    dd.大佬时薪 = emp.大佬时薪;
                    dd.萌新时薪 = emp.萌新时薪;

                    dd.材料名称 = emp.材料名称;
                    dd.材料数量 = emp.材料数量;
                    dd.大佬时间分钟 = emp.大佬时间分钟;
                    dd.萌新时间分钟 = emp.萌新时间分钟;

                    dd.大佬时间分钟 = emp.大佬时间分钟;





                }

            }

            return View("每日任务下单页面数量", dd);
        }





        private cailiaodal db = new cailiaodal();
        public ActionResult Create([Bind(Include = "材料名称,材料单价")] cailiao employee)
        {
            if (ModelState.IsValid)
            {
                db.cailiaodbset.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        public ActionResult 保存订单信息(订单表 e )
        {
            if (ModelState.IsValid)
            {
                Model6 aa = new Model6();
                string 订单号 = Request.QueryString["dingdanhao"];
                string 判断订单是否存在 = " select * from 订单表视图 where 订单编号='" + 订单号 + "'";
                List<订单表视图> 订单返回 = aa.订单表视图.SqlQuery(判断订单是否存在).ToList();
                if (订单返回.Count == 0) { aa.订单表.Add(e); aa.SaveChanges(); }
               
                // salesDal.Employees.SqlQuery("SELECT * FROM  员工模型对应的表  WHERE lastname = @p0", "hhh");

               

                System.Diagnostics.Debug.WriteLine(Request.Form["打手id"] + "22222 " + DateTime.Now); // 会输出到 Output




                // Model6 aa = new Model6();
               
                string sql = " select * from 订单表视图 where 订单编号='" + 订单号 + "'";
                List<订单表视图> eeee = aa.订单表视图.SqlQuery(sql).ToList();

                订单表视图 dd = new 订单表视图();
                ViewBag.cc = "ccccccccccccc";
                foreach (订单表视图 emp in eeee)
                {
                    if (emp.订单编号 == 订单号)
                    {
                        ViewBag.aa = emp.订单编号;
                        ViewBag.bb = "bbbbbbbbbbb";
                        dd.订单编号 = emp.订单编号;
                        dd.材料名称 = emp.材料名称;
                        dd.数量 = emp.数量  ?? 0;
                        dd.材料单价 = emp.材料单价;
                        dd.还价金额 = emp.还价金额;
                        dd.打手qq = emp.打手qq;
                        dd.订单状态 = emp.订单状态;
                        dd.金额 = emp.金额;
                        dd.隐藏打手qq = emp.隐藏打手qq;
                        if (emp.订单状态 != "不同意")
                        {
                            ViewBag.按钮状态 = "disabled";
                            ViewBag.按钮模态框 = "#aaa";

                        }
                        else
                        {

                            ViewBag.按钮模态框 = "#myModal";
                        }

                    }

                

                    }

                return View("跳转微信支付", dd);

            } else
            {

                ViewBag.hh = "chhhhhhhh";
                //  return Redirect("cailiaoxiangqing?mingcheng=甜甜花");
                // return RedirectToAction("cailiaoxiangqing");
                ViewBag.材料名称 = e.材料名称;
                ViewBag.订单编号 = e.订单编号;
                // Response.Redirect("cailiaoxiangqing?mingcheng=甜甜花");
                Model6 ddd = new Model6();
                
                List<材料表> eeee = ddd.材料表.SqlQuery(" select * from 材料表 where 材料名称='"+e.材料名称+"'").ToList();
                foreach (材料表 emp in eeee)
                {
                    if (emp.材料名称 == e.材料名称)
                    {
                        ViewBag.材料单价 = emp.材料单价;
                      


                    }

                }
                return View("材料输入错误");
               
            }


        }


        public ActionResult 保存订单信息1(订单表 e)
        {
            Model6 aa = new Model6();

            string 订单号 = Request.QueryString["dingdanhao"];
            string 判断订单是否存在 = " select * from 订单表视图 where 订单编号='" + 订单号 + "'";
            List<订单表视图> 订单返回 = aa.订单表视图.SqlQuery(判断订单是否存在).ToList();
            if (订单返回.Count == 0) { aa.订单表.Add(e); aa.SaveChanges(); }
           
            // salesDal.Employees.SqlQuery("SELECT * FROM  员工模型对应的表  WHERE lastname = @p0", "hhh");

           

            System.Diagnostics.Debug.WriteLine(Request.Form["打手id"] + "22222 " + DateTime.Now); // 会输出到 Output




            // Model6 aa = new Model6();
          
            string sql = " select * from 订单表视图 where 订单编号='" + 订单号 + "'";
            List<订单表视图> eeee = aa.订单表视图.SqlQuery(sql).ToList();

            订单表视图 dd = new 订单表视图();
            ViewBag.cc = "ccccccccccccc";
            foreach (订单表视图 emp in eeee)
            {
                if (emp.订单编号 == 订单号)
                {
                    ViewBag.aa = emp.订单编号;
                    ViewBag.bb = "bbbbbbbbbbb";
                    dd.订单编号 = emp.订单编号;
                    dd.材料名称 = emp.材料名称;
                    dd.数量 = emp.数量;
                    dd.材料单价 = emp.材料单价;
                    dd.还价金额 = emp.还价金额;




                }

            }

            return View("跳转微信支付", dd);
        }


        public ActionResult 继续讨价还价(订单表 e)
        {
            Model6 aa = new Model6();
           // aa.订单表.Add(e);
            // salesDal.Employees.SqlQuery("SELECT * FROM  员工模型对应的表  WHERE lastname = @p0", "hhh");

            //aa.SaveChanges();

            //System.Diagnostics.Debug.WriteLine(Request.Form["打手id"] + "22222 " + DateTime.Now); // 会输出到 Output




            // Model6 aa = new Model6();
            string 订单号 = Request.QueryString["dingdanhao"];
            string sql1 = " update 订单表 set 还价金额=" + e.还价金额 + " where 订单编号='" + 订单号 + "'; select top 1 * from 订单表视图  ";
            List<订单表视图> sql1eeee = aa.订单表视图.SqlQuery(sql1).ToList();
            string sql = " select * from 订单表视图 where 订单编号='" + 订单号 + "'";
            List<订单表视图> eeee = aa.订单表视图.SqlQuery(sql).ToList();

            订单表视图 dd = new 订单表视图();
            ViewBag.cc = "ccccccccccccc";
            foreach (订单表视图 emp in eeee)
            {
                if (emp.订单编号 == 订单号)
                {
                    ViewBag.aa = emp.订单编号;
                    ViewBag.bb = "bbbbbbbbbbb";
                    dd.订单编号 = emp.订单编号;
                    dd.材料名称 = emp.材料名称;
                    dd.数量 = emp.数量 ?? 0;
                    dd.材料单价 = emp.材料单价;
                    dd.还价金额 = emp.还价金额;
                    dd.打手qq = emp.打手qq;
                    if (emp.订单状态 != "不同意")
                    {
                        ViewBag.按钮状态 = "disabled";
                        ViewBag.按钮模态框 = "#aaa";
                    
                    }
                    else
                    {
                      
                        ViewBag.按钮模态框 = "#myModal";
                    }



                }

            }

            return View("跳转微信支付", dd);
        }




        public ActionResult 跳转支付宝支付( )
        {
           

            return View("跳转支付宝支付");
        }

        public ActionResult 跳转微信支付()
        {
            Model6 aa = new Model6();
            string 订单号=Request.QueryString["dingdanhao"];
            string sql = " select * from 订单表视图 where 订单编号='" + 订单号 + "'";
            List<订单表视图> eeee = aa.订单表视图.SqlQuery(sql).ToList();

            订单表视图 dd = new 订单表视图();
            ViewBag.cc = "ccccccccccccc";
            foreach (订单表视图 emp in eeee)
            {
                if (emp.订单编号 == 订单号)
                {
                    ViewBag.aa= emp.订单编号;
                    ViewBag.bb = "bbbbbbbbbbb";
                    dd.订单编号 = emp.订单编号;
                    dd.材料名称 = emp.材料名称;
                    dd.数量 = emp.数量 ?? 0;
                    dd.材料单价 = emp.材料单价;
                    
                    dd.还价金额 = emp.还价金额;
                    dd.打手qq = emp.打手qq;

                    if (emp.订单状态 != "不同意")
                    {
                        ViewBag.按钮状态 = "disabled";
                        ViewBag.按钮模态框 = "#aaa";

                    }
                    else
                    {

                        ViewBag.按钮模态框 = "#myModal";
                    }


                }

            }  

            return View("跳转微信支付", dd);
        }


        public string  付款状态()
        {


           // string aa = Request.QueryString["q"];


            Model6 aa = new Model6();
            string 订单号 = Request.QueryString["q"];
            string sql = " select * from 订单表视图 where 订单编号='" + 订单号 + "'";
            List<订单表视图> eeee = aa.订单表视图.SqlQuery(sql).ToList();

            订单表视图 dd = new 订单表视图();
            ViewBag.cc = "ccccccccccccc";
            foreach (订单表视图 emp in eeee)
            {
                if (emp.订单状态 == "已付款")
                {
                    ViewBag.aa = emp.订单编号;
                    ViewBag.bb = "bbbbbbbbbbb";
                    dd.订单编号 = emp.订单编号;
                    dd.材料名称 = emp.材料名称;
                    dd.数量 = emp.数量;
                    dd.材料单价 = emp.材料单价;
                    return "1";
                }
               
            }


            return "0";
        }

        public string 在线设置()
        {
            Model6 aa = new Model6();
            string 打手qq = Request.QueryString["q"];
            string sql = " update 打手表 set 状态='在线' where qq='" +打手qq  + "'; select top 1 * from 订单表视图  ";
            List<订单表视图> eeee = aa.订单表视图.SqlQuery(sql).ToList();
            return "1";
        }

        public string 离线设置()
        {
            Model6 aa = new Model6();
            string 打手qq = Request.QueryString["q"];
            string sql = " update 打手表 set 状态='离线' where qq='" + 打手qq + "'; select top 1 * from 订单表视图  ";
            List<订单表视图> eeee = aa.订单表视图.SqlQuery(sql).ToList();
            return "1";
        }


        public string 打单中()
        {
            Model6 aa = new Model6();
            string 打手qq = Request.QueryString["q"];
            string sql = " update 打手表 set 状态='打单中，不接单' where qq='" + 打手qq + "'; select top 1 * from 订单表视图  ";
            List<订单表视图> eeee = aa.订单表视图.SqlQuery(sql).ToList();
            return "1";
        }


        public string 同意还价()
        {
            Model6 aa = new Model6();
            string 订单编号 = Request.QueryString["q"];
            string sql = " update 订单表 set 订单状态='同意还价' where 订单编号='" + 订单编号 + "';  select top 1 * from 订单表视图 where 订单编号='" + 订单编号 + "'";
            List<订单表视图> eeee = aa.订单表视图.SqlQuery(sql).ToList();

            订单表视图 dd = new 订单表视图();
            ViewBag.cc = "ccccccccccccc";
            foreach (订单表视图 emp in eeee)
            {

                ViewBag.aa = emp.订单编号;
                ViewBag.bb = "bbbbbbbbbbb";
                dd.订单编号 = emp.订单编号;
                dd.材料名称 = emp.材料名称;
                dd.数量 = emp.数量;
                dd.材料单价 = emp.材料单价;
                dd.验证码 = emp.验证码;
                dd.qq = emp.qq;

            }

            return dd.qq;
        }


        public string 不同意()
        {
            Model6 aa = new Model6();
            string 订单编号 = Request.QueryString["q"];
            string sql = " update 订单表 set 订单状态='不同意' where 订单编号='" + 订单编号 + "'; select top 1 * from 订单表视图  ";
            List<订单表视图> eeee = aa.订单表视图.SqlQuery(sql).ToList();
            return "1";
        }


        public string 我要付款()
        {
            Model6 aa = new Model6();
            string 订单编号 = Request.QueryString["q"];
            string sql = " update 订单表 set 订单状态='买家要付款，等待打手回复' where 订单编号='" + 订单编号 + "'; select top 1 * from 订单表视图  ";
            List<订单表视图> eeee = aa.订单表视图.SqlQuery(sql).ToList();
            return "1";
        }

        public string 同意付款()
        {
            Model6 aa = new Model6();
            string 订单编号 = Request.QueryString["q"];
            string sql = " update 订单表 set 订单状态='打手同意付款，请买家付款' where 订单编号='" + 订单编号 + "'; select top 1 * from 订单表视图 where 订单编号='" + 订单编号 + "'";
            List<订单表视图> eeee = aa.订单表视图.SqlQuery(sql).ToList();
            订单表视图 dd = new 订单表视图();
            ViewBag.cc = "ccccccccccccc";
            foreach (订单表视图 emp in eeee)
            {

                ViewBag.aa = emp.订单编号;
                ViewBag.bb = "bbbbbbbbbbb";
                dd.订单编号 = emp.订单编号;
                dd.材料名称 = emp.材料名称;
                dd.数量 = emp.数量;
                dd.材料单价 = emp.材料单价;
                dd.验证码 = emp.验证码;
                dd.qq = emp.qq;

            }

            return dd.qq;
        }


        public string 不同意付款()
        {
            Model6 aa = new Model6();
            string 订单编号 = Request.QueryString["q"];
            string sql = " update 订单表 set 订单状态='打手不同意付款，此订单不接，请勿付款' where 订单编号='" + 订单编号 + "'; select top 1 * from 订单表视图  ";
            List<订单表视图> eeee = aa.订单表视图.SqlQuery(sql).ToList();
            return "1";
        }



        public string 已付款()
        {
            Model6 aa = new Model6();
            string 订单编号 = Request.QueryString["q"];
            string sql = " update 订单表 set 订单状态='已付款' where 订单编号='" + 订单编号 + "'; select top 1 * from 订单表视图  ";
            List<订单表视图> eeee = aa.订单表视图.SqlQuery(sql).ToList();
            return "1";
        }

        public string 登陆账号中()
        {
            Model6 aa = new Model6();
            string 订单编号 = Request.QueryString["q"];
            string sql = " update 订单表 set 订单状态='登陆账号中' where 订单编号='" + 订单编号 + "'; select top 1 * from 订单表视图  ";
            List<订单表视图> eeee = aa.订单表视图.SqlQuery(sql).ToList();
            return "1";
        }



        public string 代肝中()
        {
            Model6 aa = new Model6();
            string 订单编号 = Request.QueryString["q"];
            string sql = " update 订单表 set 订单状态='代肝中' where 订单编号='" + 订单编号 + "'; select top 1 * from 订单表视图  ";
            List<订单表视图> eeee = aa.订单表视图.SqlQuery(sql).ToList();
            return "1";
        }

        public string 已完成()
        {
            Model6 aa = new Model6();
            string 订单编号 = Request.QueryString["q"];
            string sql = " update 订单表 set 订单状态='已完成' where 订单编号='" + 订单编号 + "'; select top 1 * from 订单表视图  ";
            List<订单表视图> eeee = aa.订单表视图.SqlQuery(sql).ToList();
            return "1";
        }



        public string 刷新验证码()
        {
            Model6 aa = new Model6();
            string 订单编号 = Request.QueryString["q"];   
            string sql =    " select * from 订单表视图 where 订单编号='" + 订单编号 + "'";
            List<订单表视图> eeee = aa.订单表视图.SqlQuery(sql).ToList();

            订单表视图 dd = new 订单表视图();
            ViewBag.cc = "ccccccccccccc";
            foreach (订单表视图 emp in eeee)
            {
              
                    ViewBag.aa = emp.订单编号;
                    ViewBag.bb = "bbbbbbbbbbb";
                    dd.订单编号 = emp.订单编号;
                    dd.材料名称 = emp.材料名称;
                    dd.数量 = emp.数量;
                    dd.材料单价 = emp.材料单价;
                    dd.验证码 = emp.验证码;
                
            }


                return dd.验证码;
        }



        public string 刷新买家进度()
        {
            Model6 aa = new Model6();
            string 订单编号 = Request.QueryString["q"];
            string sql = " select * from 订单表视图 where 订单编号='" + 订单编号 + "'";
            List<订单表视图> eeee = aa.订单表视图.SqlQuery(sql).ToList();

            订单表视图 dd = new 订单表视图();
            ViewBag.cc = "ccccccccccccc";
            foreach (订单表视图 emp in eeee)
            {

                ViewBag.aa = emp.订单编号;
                ViewBag.bb = "bbbbbbbbbbb";
                dd.订单编号 = emp.订单编号;
                dd.材料名称 = emp.材料名称;
                dd.数量 = emp.数量;
                dd.材料单价 = emp.材料单价;
                dd.验证码 = emp.验证码;
                dd.订单状态 = emp.订单状态;

            }


            return dd.订单状态;
        }


        public string 检测不同意状态()
        {


            // string aa = Request.QueryString["q"];


            Model6 aa = new Model6();
            string 订单号 = Request.QueryString["q"];
            string sql = " select * from 订单表视图 where 订单编号='" + 订单号 + "'";
            List<订单表视图> eeee = aa.订单表视图.SqlQuery(sql).ToList();

            订单表视图 dd = new 订单表视图();
            ViewBag.cc = "ccccccccccccc";
            foreach (订单表视图 emp in eeee)
            {
                if (emp.订单状态 == "不同意")
                {
                    ViewBag.aa = emp.订单编号;
                    ViewBag.bb = "bbbbbbbbbbb";
                    dd.订单编号 = emp.订单编号;
                    dd.材料名称 = emp.材料名称;
                    dd.数量 = emp.数量;
                    dd.材料单价 = emp.材料单价;
                    return "不同意";
                }
                if (emp.订单状态 == "同意还价")
                {
                    ViewBag.aa = emp.订单编号;
                    ViewBag.bb = "bbbbbbbbbbb";
                    dd.订单编号 = emp.订单编号;
                    dd.材料名称 = emp.材料名称;
                    dd.数量 = emp.数量;
                    dd.材料单价 = emp.材料单价;
                    return "同意";
                }

                if (emp.订单状态 == "打手同意付款，请买家付款")
                {
                    ViewBag.aa = emp.订单编号;
                    ViewBag.bb = "bbbbbbbbbbb";
                    dd.订单编号 = emp.订单编号;
                    dd.材料名称 = emp.材料名称;
                    dd.数量 = emp.数量;
                    dd.材料单价 = emp.材料单价;
                    return "打手同意付款，请买家付款";
                }



                if (emp.订单状态 == "打手不同意付款，此订单不接，请勿付款")
                {
                    ViewBag.aa = emp.订单编号;
                    ViewBag.bb = "bbbbbbbbbbb";
                    dd.订单编号 = emp.订单编号;
                    dd.材料名称 = emp.材料名称;
                    dd.数量 = emp.数量;
                    dd.材料单价 = emp.材料单价;
                    return "打手不同意付款，此订单不接，请勿付款";
                }



                if (emp.订单状态 == "已付款")
                {
                    ViewBag.aa = emp.订单编号;
                    ViewBag.bb = "bbbbbbbbbbb";
                    dd.订单编号 = emp.订单编号;
                    dd.材料名称 = emp.材料名称;
                    dd.数量 = emp.数量;
                    dd.材料单价 = emp.材料单价;
                    return "已付款";
                }

                if (emp.订单状态 == "登陆账号中")
                {
                    ViewBag.aa = emp.订单编号;
                    ViewBag.bb = "bbbbbbbbbbb";
                    dd.订单编号 = emp.订单编号;
                    dd.材料名称 = emp.材料名称;
                    dd.数量 = emp.数量;
                    dd.材料单价 = emp.材料单价;
                    return "登陆账号中";
                }


                if (emp.订单状态 == "代肝中")
                {
                    ViewBag.aa = emp.订单编号;
                    ViewBag.bb = "bbbbbbbbbbb";
                    dd.订单编号 = emp.订单编号;
                    dd.材料名称 = emp.材料名称;
                    dd.数量 = emp.数量;
                    dd.材料单价 = emp.材料单价;
                    return "代肝中";
                }

                if (emp.订单状态 == "已完成")
                {
                    ViewBag.aa = emp.订单编号;
                    ViewBag.bb = "bbbbbbbbbbb";
                    dd.订单编号 = emp.订单编号;
                    dd.材料名称 = emp.材料名称;
                    dd.数量 = emp.数量;
                    dd.材料单价 = emp.材料单价;
                    return "已完成";
                }

            }


            return "0";
        }



        public ActionResult  已付款订单信息()
        {
            Model6 aa = new Model6();
            string 订单号 = Request.QueryString["q"];
            string sql = " select * from 订单表视图 where 订单编号='" + 订单号 + "'";
            List<订单表视图> eeee = aa.订单表视图.SqlQuery(sql).ToList();

            订单表视图 dd = new 订单表视图();
            ViewBag.cc = "ccccccccccccc";
            foreach (订单表视图 emp in eeee)
            {
                if (emp.订单编号 == 订单号)
                {
                    ViewBag.aa = emp.订单编号;
                    ViewBag.bb = "bbbbbbbbbbb";
                    dd.订单编号 = emp.订单编号;
                    dd.材料名称 = emp.材料名称;
                    dd.数量 = emp.数量;
                    dd.材料单价 = emp.材料单价;
                    dd.账号= emp.账号;
                    dd.订单状态 = emp.订单状态;
                    dd.qq = emp.qq;
                    dd.打手qq = emp.打手qq;
                    dd.金额 = emp.金额;

                    if (emp.订单状态=="同意还价") {
                        if (emp.订单状态 != "不同意")
                        {
                            ViewBag.按钮状态 = "disabled";
                            ViewBag.按钮模态框 = "#aaa";

                        }
                        else
                        {

                            ViewBag.按钮模态框 = "#myModal";
                        }

                        return View("跳转微信支付", dd); }


                    if (emp.订单状态 == "待付款") {
                        if (emp.订单状态 != "不同意")
                        {
                            ViewBag.按钮状态 = "disabled";
                            ViewBag.按钮模态框 = "#aaa";

                        }
                        else
                        {

                            ViewBag.按钮模态框 = "#myModal";
                        }

                        return View("跳转微信支付", dd); }


                    if (emp.订单状态 == "不同意") {
                        if (emp.订单状态 != "不同意")
                        {
                            ViewBag.按钮状态 = "disabled";
                            ViewBag.按钮模态框 = "#aaa";

                        }
                        else
                        {

                            ViewBag.按钮模态框 = "#myModal";
                        }

                        return View("跳转微信支付", dd); }


                }

            }

            return View("已付款订单信息",dd );
        }


        public ActionResult 查询订单1()
        {
            //SendEmail1("1046767183@qq.com", "TideShoe后台登录修改用户信息提示", "aaaaaaaaaaaaaaaaa");
            return View("查询订单1");
        }

        public ActionResult 查询订单2()
        {

           // ViewBag.qq=Request.Form["qq"];
            string qq = ViewBag.qq = Request.Form["qq"];

            Model6 aa = new Model6();
            //string 订单号 = Request.QueryString["q"];
            string sql = " select * from 订单表视图 where qq='" + qq + "'";
            List<订单表视图> eeee = aa.订单表视图.SqlQuery(sql).ToList();

            订单表视图列表 fff = new 订单表视图列表();
            fff.列表list = eeee;

            订单表视图 dd = new 订单表视图();
            ViewBag.cc = "ccccccccccccc";
            foreach (订单表视图 emp in eeee)
            {
                if (emp.qq == qq)
                {
                    ViewBag.aa = emp.订单编号;
                    ViewBag.bb = "bbbbbbbbbbb";
                    dd.订单编号 = emp.订单编号;
                    dd.材料名称 = emp.材料名称;
                    dd.数量 = emp.数量;
                    dd.材料单价 = emp.材料单价;
                    dd.账号 = emp.账号;
                    dd.订单状态 = emp.订单状态;
                    dd.qq = emp.qq;




                }

            }

            return View("查询订单2", fff);
        }

        public ActionResult 打手查询1()
        {
          
            return View("打手查询1");
        }

        public ActionResult 西风骑士团()
        {

            return View("西风骑士团");
        }

        public ActionResult 人菜瘾还大()
        {

            return View("人菜瘾还大");
        }

        public ActionResult 验证码(订单表 e)
        {
            Model6 aa = new Model6();

            string 订单号 = Request.QueryString["dingdanhao"];
            string sql1 = " update 订单表 set 验证码=" + e.验证码 + " where 订单编号='" + 订单号 + "'; select top 1 * from 订单表视图  ";
            List<订单表视图> sql1eeee = aa.订单表视图.SqlQuery(sql1).ToList();

            string sql = " select * from 订单表视图 where 订单编号='" + 订单号 + "'";
            List<订单表视图> eeee = aa.订单表视图.SqlQuery(sql).ToList();
            订单表视图 dd = new 订单表视图();


            foreach (订单表视图 emp in eeee)
            {
                if (emp.订单编号 == 订单号)
                {
                    ViewBag.aa = emp.订单编号;
                    ViewBag.bb = "bbbbbbbbbbb";
                    dd.订单编号 = emp.订单编号;
                    dd.材料名称 = emp.材料名称;
                    dd.数量 = emp.数量;
                    dd.材料单价 = emp.材料单价;
                    dd.账号 = emp.账号;
                    dd.订单状态 = emp.订单状态;
                    dd.qq = emp.qq;
                    dd.打手qq = emp.打手qq;
                    dd.验证码 = emp.验证码;
                    dd.金额 = emp.金额;

                }
            }

                return View("已付款订单信息", dd);



             
        }

     


              
        public ActionResult 打手查询2()
        {


            // ViewBag.qq=Request.Form["qq"];
            string 打手qq = ViewBag.qq = Request.Form["打手qq"];
            Model6 aa = new Model6();
            // string qq = Request.QueryString["qq"];
            //System.Diagnostics.Debug.WriteLine(qq+"的萨顶顶顶顶顶顶顶的");
            string sql = " select * from 订单表视图 where 打手qq='" + 打手qq + "' order by 日期 desc";
            List<订单表视图> eeee = aa.订单表视图.SqlQuery(sql).ToList();

            订单表视图列表 fff = new 订单表视图列表();
            fff.列表list = eeee;

            if (eeee  != null) { System.Diagnostics.Debug.WriteLine("的萨顶顶顶顶顶顶顶的"+eeee.Count); }
            System.Diagnostics.Debug.WriteLine("的萨顶顶顶顶顶顶顶的" + eeee.Count);
            if (eeee.Count == 0) { ViewBag.aa = "0"; }

            订单表视图 dd = new 订单表视图();
            ViewBag.cc = "ccccccccccccc";
            foreach (订单表视图 emp in eeee)
            {
                if (emp.打手qq == 打手qq)
                {
                    ViewBag.aa = emp.订单编号;
                    ViewBag.bb = "bbbbbbbbbbb";
                    ViewBag.dd = emp.打手qq;
                    ViewBag.ee = emp.打手状态;
                
                    dd.订单编号 = emp.订单编号;
                    dd.材料名称 = emp.材料名称;
                    dd.数量 = emp.数量;
                    dd.材料单价 = emp.材料单价;
                    dd.账号 = emp.账号;
                    dd.订单状态 = emp.订单状态;
                    dd.qq = emp.qq;
                    dd.打手状态 = emp.打手状态;
                    dd.验证码 = emp.验证码;
                    dd.金额 = emp.金额;
                    dd.隐藏qq = emp.隐藏qq;




                }

            }

            return View("打手查询2",fff);
        }

        public static void SendEmail1(string mailTo, string mailSubject, string mailContent)
        {
            //("邮箱服务器类型", 端口号);
            SmtpClient mailClient = new SmtpClient("smtp.qq.com");
            mailClient.EnableSsl = true;
            mailClient.UseDefaultCredentials = false;
            //Credentials登陆SMTP服务器的身份验证.
            mailClient.Credentials = new NetworkCredential("1046767183@qq.com", "xczleyfwcvvzbfje");//邮箱，
            MailMessage message = new MailMessage(new MailAddress("1046767183@qq.com"), new MailAddress(mailTo));//发件人，收件人
            message.IsBodyHtml = true;
            message.Body = mailContent;//邮件内容
            message.Subject = mailSubject;
            mailClient.Send(message); // 发送邮件
        }



        public ActionResult 每日价格()
        {
            Model6 aa = new Model6();
         
            string sql = " select * from 材料表视图    ";
            List<材料表视图> eeee = aa.材料表视图.SqlQuery(sql).ToList();

            


            return View("每日价格",eeee);
        }


    }
}