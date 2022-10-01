using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2mvc.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Enter First Name555")]
        public string FirstName { get; set; }


        [StringLength(5, ErrorMessage = "Last Name length should not be greater than 5顶顶顶顶顶顶顶顶顶大")]
        public string LastName { get; set; }
        [Range(1, 100)]
        public int Salary { get; set; }
    }
}