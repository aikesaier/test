namespace WebApplication2mvc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class 打手表视图
    {
        public int id { get; set; }

        [StringLength(50)]
        public string 打手名称 { get; set; }

        [StringLength(50)]
        public string qq { get; set; }

        [StringLength(50)]
        public string b站id { get; set; }

        [StringLength(50)]
        public string b站直播id { get; set; }

        public DateTime? 日期 { get; set; }

        [StringLength(50)]
        public string 状态 { get; set; }

        [StringLength(50)]
        public string 打手类别 { get; set; }

        [StringLength(50)]
        public string uid { get; set; }

        [StringLength(50)]
        public string 在线时间 { get; set; }

        [StringLength(50)]
        public string 地区 { get; set; }

        [StringLength(50)]
        public string b站昵称 { get; set; }

        [StringLength(50)]
        public string 打手信息 { get; set; }

        [StringLength(9)]
        public string 隐藏打手qq { get; set; }

        [StringLength(100)]
        public string 业务 { get; set; }

        [StringLength(50)]
        public string 安全系数 { get; set; }

        [StringLength(100)]
        public string 直播或主页链接 { get; set; }
    }
}
