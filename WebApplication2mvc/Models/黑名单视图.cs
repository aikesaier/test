namespace WebApplication2mvc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class 黑名单视图
    {
        public int id { get; set; }

        [StringLength(50)]
        public string qq { get; set; }

        [StringLength(50)]
        public string b站昵称 { get; set; }

        [StringLength(50)]
        public string b站id { get; set; }

        [StringLength(50)]
        public string 游戏uid { get; set; }

        [StringLength(200)]
        public string 理由 { get; set; }

        [StringLength(100)]
        public string 链接 { get; set; }

        public DateTime? 日期 { get; set; }

        [StringLength(10)]
        public string 隐藏qq { get; set; }

        [StringLength(10)]
        public string 隐藏游戏uid { get; set; }
    }
}
