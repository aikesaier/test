namespace WebApplication2mvc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class 打手接需求表
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string 打手qq { get; set; }

        [StringLength(50)]
        public string 需求编号 { get; set; }

        [StringLength(50)]
        public string 预计花费时间 { get; set; }

        public decimal? 报价 { get; set; }

        public DateTime? 报价时间 { get; set; }
    }
}
