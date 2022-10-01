namespace WebApplication2mvc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class 测试视图
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int 需求id { get; set; }

        [StringLength(50)]
        public string 需求编号 { get; set; }

        [StringLength(50)]
        public string 打手qq { get; set; }

        [StringLength(50)]
        public string qq { get; set; }
    }
}
