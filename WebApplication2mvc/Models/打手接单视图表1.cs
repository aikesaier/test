namespace WebApplication2mvc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class 打手接单视图表1
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int 数字 { get; set; }

        public int? id { get; set; }

        [StringLength(50)]
        public string 打手qq { get; set; }

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

        [StringLength(50)]
        public string 预计花费时间 { get; set; }

        public decimal? 报价 { get; set; }

        public DateTime? 报价时间 { get; set; }

        [StringLength(50)]
        public string 打手信息 { get; set; }

        [StringLength(100)]
        public string 业务 { get; set; }

        [StringLength(50)]
        public string 安全系数 { get; set; }

        [StringLength(100)]
        public string 直播或主页链接 { get; set; }

        [StringLength(8)]
        public string 隐藏打手qq { get; set; }

        [StringLength(8)]
        public string 隐藏qq { get; set; }

        [StringLength(8)]
        public string 隐藏已选择的打手qq { get; set; }

        [StringLength(8)]
        public string 隐藏游戏账号 { get; set; }
    }
}
