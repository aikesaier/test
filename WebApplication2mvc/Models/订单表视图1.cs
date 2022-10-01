namespace WebApplication2mvc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class 订单表视图1
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

        [StringLength(50)]
        public string 备注 { get; set; }

        public DateTime? 日期 { get; set; }

        [StringLength(50)]
        public string 订单状态 { get; set; }

        [StringLength(50)]
        public string 打手qq { get; set; }

        [StringLength(50)]
        public string 打手状态 { get; set; }

        public decimal? 材料单价 { get; set; }
    }
}
