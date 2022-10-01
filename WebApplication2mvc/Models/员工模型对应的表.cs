namespace WebApplication2mvc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class 员工模型对应的表
    {
        [Key]
        [Column(Order = 0)]
        public int EmployeeId { get; set; }

        [Key]
        [Column(Order = 1)]
        public string FirstName { get; set; }

        [StringLength(5)]
        public string LastName { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Salary { get; set; }
    }
}
