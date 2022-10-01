namespace WebApplication2mvc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class 需求表
    {
        [Key]
        public int 需求id { get; set; }

        [StringLength(50)]
        public string 需求编号 { get; set; }

        [StringLength(200)]
        public string 名称 { get; set; }

        public int? 数量 { get; set; }

        [StringLength(50)]
        public string 花费时间 { get; set; }

        public decimal? 出价 { get; set; }

        [StringLength(50)]
        public string 游戏账号 { get; set; }

        [StringLength(50)]
        public string qq { get; set; }

        [StringLength(50)]
        public string 选择的打手qq { get; set; }

        [StringLength(200)]
        public string 备注 { get; set; }

        public DateTime? 日期 { get; set; }

        [StringLength(50)]
        public string 需求状态 { get; set; }

        [StringLength(50)]
        public string 退款码 { get; set; }
    }
}
