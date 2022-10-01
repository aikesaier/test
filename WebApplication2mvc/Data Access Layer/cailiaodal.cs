using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebApplication2mvc.Models;

namespace WebApplication2mvc.Data_Access_Layer
{
    public class cailiaodal : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<cailiao>().ToTable("材料表");
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<cailiao> cailiaodbset { get; set; }


        //  public DbSet<Employee> Employees { get; set; }  第二个绑定不能用




    }




}