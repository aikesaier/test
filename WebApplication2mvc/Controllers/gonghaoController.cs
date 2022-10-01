using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2mvc.Models;

namespace WebApplication2mvc.Controllers
{
    public class gonghaoController : Controller
    {
        // GET: gonghao
        public ActionResult 推荐人()
        {
            Model6 aa = new Model6();
            List<推荐人视图> eee = aa.推荐人视图.ToList();

            return View("推荐人", eee);
        }


        public ActionResult 代肝故事计划()
        {
            

            return View("代肝故事计划" );
        }


        public ActionResult 共号狼人杀()
        {

            Model6 aa = new Model6();
            List<共享账号视图> eee = aa.共享账号视图.ToList();
            return View("共号狼人杀",eee);
        }


        public ActionResult 萌新59级()
        {


            return View("萌新59级");
        }
        public ActionResult 原文()
        {


            return View("原文");
        }

        public ActionResult 原琴()
        {


            return View("原琴");
        }

        public ActionResult 学编程()
        {


            return View("学编程");
        }




        public ActionResult 添加推荐人(推荐人 e)
        {
            Model6 aa = new Model6();


            string 判断打手是否存在 = " select * from 打手表 where qq='" + e.打手qq + "'";
            List<打手表> 订单返回 = aa.打手表.SqlQuery(判断打手是否存在).ToList();

            System.Diagnostics.Debug.WriteLine(订单返回.Count);
            if (订单返回.Count > 0)
            {
                aa.推荐人.Add(e);
                try
                {
                    aa.SaveChanges();
                }

                catch (DbEntityValidationException dbEx)
                {

                    // System.Diagnostics.Debug.WriteLine(dbEx.ToString());
                }
            }


            List<推荐人视图> eee = aa.推荐人视图.ToList();
            return View("推荐人", eee);
        }


        // GET: gonghao/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: gonghao/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: gonghao/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: gonghao/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: gonghao/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: gonghao/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: gonghao/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
