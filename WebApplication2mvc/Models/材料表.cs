namespace WebApplication2mvc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class 材料表
    {
        [Key]
        public int 材料id { get; set; }

        [StringLength(50)]
        public string 材料名称 { get; set; }

        public decimal? 材料单价 { get; set; }

        public DateTime 日期 { get; set; }

        public int? 材料数量 { get; set; }

        public int? 萌新时间分钟 { get; set; }

        public int? 大佬时间分钟 { get; set; }

        public decimal? 时薪 { get; set; }

        public decimal? 材料单价1 { get; set; }

        public decimal? 材料单价2 { get; set; }

        public decimal? 材料单价3 { get; set; }

        [StringLength(50)]
        public string 材料类型 { get; set; }

        [StringLength(200)]
        public string 萌新分钟地址 { get; set; }

        [StringLength(200)]
        public string 大佬分钟地址 { get; set; }
    }
}
