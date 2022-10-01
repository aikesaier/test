using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebApplication2mvc.Models
{
    public partial class bb : DbContext
    {
        public bb()
            : base("name=bb")
        {
        }

        public virtual DbSet<材料表> 材料表 { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
