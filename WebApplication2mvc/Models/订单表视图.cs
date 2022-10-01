namespace WebApplication2mvc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class 订单表视图
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int 订单id { get; set; }

        [StringLength(50)]
        public string 订单编号 { get; set; }

        [StringLength(50)]
        public string 材料名称 { get; set; }

        public int? 数量 { get; set; }

        [StringLength(50)]
        public string 账号 { get; set; }

        [StringLength(50)]
        public string qq { get; set; }

        [StringLength(9)]
        public string 隐藏qq { get; set; }

        [StringLength(50)]
        public string 备注 { get; set; }

        public DateTime? 日期 { get; set; }

        [StringLength(50)]
        public string 订单状态 { get; set; }

        [StringLength(50)]
        public string 打手qq { get; set; }

        [StringLength(9)]
        public string 隐藏打手qq { get; set; }

        public decimal? 还价金额 { get; set; }

        [StringLength(50)]
        public string 打手状态 { get; set; }

        public decimal? 材料单价 { get; set; }

        public decimal? 金额 { get; set; }

        public int? 萌新时间分钟 { get; set; }

        public int? 大佬时间分钟 { get; set; }

        public int? 材料数量 { get; set; }

        public int? 对标时薪 { get; set; }

        public decimal? 萌新时薪 { get; set; }

        public decimal? 大佬时薪 { get; set; }

        public decimal? 建议标准金额 { get; set; }

        public decimal? 建议萌新金额 { get; set; }

        public decimal? 建议大佬金额 { get; set; }

        [StringLength(50)]
        public string 验证码 { get; set; }
    }
}
