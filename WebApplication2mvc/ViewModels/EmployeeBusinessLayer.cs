using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2mvc.Data_Access_Layer;
using WebApplication2mvc.Models;

namespace WebApplication2mvc.ViewModels
{
    public class EmployeeBusinessLayer
    {
        /****
        public List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();
            Employee emp = new Employee();
            emp.FirstName = "johnson";
            emp.LastName = " fernandes";
            emp.Salary = 14000;
            employees.Add(emp);

            emp = new Employee();
            emp.FirstName = "michael";
            emp.LastName = "jackson";
            emp.Salary = 16000;
            employees.Add(emp);

            emp = new Employee();
            emp.FirstName = "robert";
            emp.LastName = " pattinson";
            emp.Salary = 20000;
            employees.Add(emp);

            return employees;
        }
        **第1版
        ***/

        public List<Employee> GetEmployees()
        {
            Data_Access_Layer.SalesERPDAL salesDal = new SalesERPDAL();

            // return salesDal.Employees.ToList();
           // salesDal.Database.SqlQuery("select * from 员工模型对应的表 where lastname = @p0", "aaaaaaaaaaaaaa").tolist();
            return salesDal.Employees.SqlQuery("update 员工模型对应的表 set firstname = @p0  WHERE lastname = @p1;INSERT INTO  员工模型对应的表 ([FirstName],[LastName],[Salary]) VALUES (@p3, @p4 ,  @p5); select * from 员工模型对应的表 where lastname = @p2", "jjjjjjjjjj" ,"hhh","hhh","bbbbb","bbbb","321").ToList();

           

        }

        public Employee SaveEmployee(Employee e)
        {
            SalesERPDAL salesDal = new SalesERPDAL();
            salesDal.Employees.Add(e);
           // salesDal.Employees.SqlQuery("SELECT * FROM  员工模型对应的表  WHERE lastname = @p0", "hhh");
           
                salesDal.SaveChanges();
            return e;
        }




    }

}