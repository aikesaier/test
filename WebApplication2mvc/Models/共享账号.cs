namespace WebApplication2mvc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class 共享账号
    {
        public int id { get; set; }

        [StringLength(50)]
        public string 账号 { get; set; }

        [StringLength(50)]
        public string 密码 { get; set; }

        [StringLength(50)]
        public string 世界等级 { get; set; }

        [StringLength(50)]
        public string 深渊队伍 { get; set; }

        [StringLength(50)]
        public string 深渊层数 { get; set; }

        [StringLength(50)]
        public string 号主 { get; set; }

        [StringLength(50)]
        public string 日期 { get; set; }

        [StringLength(50)]
        public string 账号链接 { get; set; }
    }
}
