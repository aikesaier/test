using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebApplication2mvc.Models;

namespace WebApplication2mvc.Data_Access_Layer
{
    public class SalesERPDAL : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
       modelBuilder.Entity<Employee>().ToTable("员工模型对应的表");
        base.OnModelCreating(modelBuilder);
    }

        public DbSet<Employee> Employees { get; set; }

        public System.Data.Entity.DbSet<WebApplication2mvc.Models.打手表> 打手表 { get; set; }


        //  public DbSet<Employee> Employees { get; set; }  第二个绑定不能用




    }




}