using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2mvc.Models
{
    public class cailiao
    {
        [Key]
        public int 材料id { get; set; }
        public string 材料名称 { get; set; }

        public string 材料单价 { get; set; }

        public DateTime 日期 { get; set; }
    }
}