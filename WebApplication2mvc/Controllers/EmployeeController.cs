using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2mvc.Models;
using WebApplication2mvc.ViewModels;
using WebApplication2mvc.Data_Access_Layer;

namespace WebApplication2mvc.Controllers
{

    /****
    public class Employee11
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Salary { get; set; }
    }

    ***/

    public class EmployeeController : Controller
    {
        // GET: test
        public string GetString()
        {        return "Hello World is old now. It’s time for wassup bro ;)"; 
       }


      


    public ActionResult Index()
  {
            /***
            Employee emp = new Employee();
             emp.FirstName = "你好啊";
            emp.LastName = "Marla";
           emp.Salary = 20000;


            ViewData["Employee"] = emp;
            return View("MyView");
            ***/

            /***
            Employee emp = new Employee();
              emp.FirstName = "Sukesh";
             emp.LastName = "Marla";
            emp.Salary = 20000;
             return View("MyView", emp);

            ***2版***/



            /***

            Employee emp = new Employee();
            emp.FirstName = "Sukesh";
            emp.LastName = "Marla";
            emp.Salary = 20000;

            EmployeeViewModel vmEmp = new EmployeeViewModel();
            vmEmp.EmployeeName = emp.FirstName + " " + emp.LastName;
            vmEmp.Salary = emp.Salary.ToString("C");
            if (emp.Salary > 15000)
            {
                vmEmp.SalaryColor = "yellow";
            }
            else
            {
                vmEmp.SalaryColor = "green";
            }

            vmEmp.UserName = "Admin";


   return View("MyView", vmEmp);  
            3版***/


        

            EmployeeBusinessLayer empBal = new EmployeeBusinessLayer();
            List<Employee> employees = empBal.GetEmployees();


            List<EmployeeViewModel> empViewModels = new List<EmployeeViewModel>();
            string mingcheng="yuiyuiuy地方的法规的非官方的";
            //ViewData["name"] = mingcheng;
            ViewBag.name = mingcheng;
            foreach (Employee emp in employees)
            {
                EmployeeViewModel empViewModel = new EmployeeViewModel();
                empViewModel.EmployeeName = emp.FirstName + " " + emp.LastName;
                empViewModel.Salary = emp.Salary.ToString("C");
                if (emp.FirstName == "版本")
                {
                    ViewBag.name = emp.LastName;
                }
                if (emp.Salary > 15000)
                {
                    empViewModel.SalaryColor = "yellow";
                }
                else
                {
                    empViewModel.SalaryColor = "green";
                }
                empViewModels.Add(empViewModel);
            }

            EmployeeListViewModel employeeListViewModel = new EmployeeListViewModel();
            employeeListViewModel.Employees = empViewModels;
       


            // employeeListViewModel.UserName = "Admin";
            employeeListViewModel.UserName = Request.QueryString["username1"];


            Console.WriteLine(Request.QueryString["username"]);
            //Response.Write(mingcheng);
            
            return View("Index", employeeListViewModel);


        }

        public ActionResult AddNew()
    {
      return View("CreateEmployee");
  }

        public ActionResult SaveEmployee(Employee e, string BtnSubmit)
        {
           // return e.FirstName + "|" + e.LastName + "|" + e.Salary;

             switch (BtnSubmit)
    {
        case "Save Employee":
                    //return Content(e.FirstName + "|" + e.LastName + "|" + e.Salary);
                    if (ModelState.IsValid)
                    { 
                        EmployeeBusinessLayer empBal = new EmployeeBusinessLayer();
                                empBal.SaveEmployee(e);

                        //  String sql = "update user set userName=?,password=? where userID=?";
                        //  Object[] obj = new Object[] { user.getUserName(), user.getPassword(), user.getUserID() };
                        // int rs = DBHelper.ExecSql(sql, obj);
                   


                        return RedirectToAction("Index");
                    }
                                else
                                  {
                                      return View("CreateEmployee");
                                    }
                case "Cancel":
            return RedirectToAction("Index");
    }
    return new EmptyResult();


        }
    }


    public class Customer
      {
            public string CustomerName { get; set; }
        public string Address { get; set; }

           public override string ToString()
   {
        return this.CustomerName+"|"+this.Address;
    }

}



    public class Test1Controller : Controller
         {
          public Customer GetCustomer()
           {
                Customer c = new Customer();
            c.CustomerName = "Customer 1";
                          c.Address = "Address1";
              return c;
         }
      }

}