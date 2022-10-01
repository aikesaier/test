namespace WebApplication2mvc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class 推荐人视图
    {
        public int id { get; set; }

        [StringLength(50)]
        public string 推荐人qq { get; set; }

        [StringLength(50)]
        public string 推荐人b站昵称 { get; set; }

        [StringLength(50)]
        public string 打手qq { get; set; }

        [StringLength(50)]
        public string 网址 { get; set; }

        [StringLength(50)]
        public string 推荐人认证状态 { get; set; }

        public DateTime? 日期 { get; set; }

        [StringLength(10)]
        public string 隐藏推荐人qq { get; set; }

        [StringLength(10)]
        public string 隐藏打手qq { get; set; }
    }
}
