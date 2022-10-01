using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebApplication2mvc.Models
{
    public partial class aa : DbContext
    {
        public aa()
            : base("name=aa")
        {
        }

        public virtual DbSet<订单表视图> 订单表视图 { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }


    }
}
