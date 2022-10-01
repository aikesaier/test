using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebApplication2mvc.Models
{
    public partial class Model6 : DbContext
    {
        public Model6()
            : base("name=Model6")
        {
        }

        public virtual DbSet<材料表> 材料表 { get; set; }
        public virtual DbSet<打手接需求表> 打手接需求表 { get; set; }
        public virtual DbSet<订单表> 订单表 { get; set; }
        public virtual DbSet<黑名单> 黑名单 { get; set; }
        public virtual DbSet<需求表> 需求表 { get; set; }
        public virtual DbSet<打手表> 打手表 { get; set; }
        public virtual DbSet<共享账号> 共享账号 { get; set; }
        public virtual DbSet<推荐人> 推荐人 { get; set; }
        public virtual DbSet<员工模型对应的表> 员工模型对应的表 { get; set; }
        public virtual DbSet<材料表视图> 材料表视图 { get; set; }
        public virtual DbSet<测试视图> 测试视图 { get; set; }
        public virtual DbSet<打手表视图> 打手表视图 { get; set; }
        public virtual DbSet<打手接单视图表1> 打手接单视图表1 { get; set; }
        public virtual DbSet<订单表视图> 订单表视图 { get; set; }
        public virtual DbSet<订单表视图1> 订单表视图1 { get; set; }
        public virtual DbSet<共享账号视图> 共享账号视图 { get; set; }
        public virtual DbSet<黑名单视图> 黑名单视图 { get; set; }
        public virtual DbSet<推荐人视图> 推荐人视图 { get; set; }
        public virtual DbSet<需求表视图> 需求表视图 { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<订单表视图>()
                .Property(e => e.金额)
                .HasPrecision(29, 2);
        }
    }
}
