using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.Models
{
    public class CreateLeave
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Employee")]
        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        [ValidateNever]
        public Employee Employee { get; set; }

        [Required]
        [Display(Name = "Leave Type")]
        public int LeaveId { get; set; }
        [ForeignKey("LeaveId")]
        [ValidateNever]
        public Leave Leave { get; set; }



        [Required]
        [Display(Name = "From (dd/mm/yy)")]
        public string Fromdate { get; set; }

       
        [Required]
        [Display(Name = "To (dd/mm/yy)")]
        public string Todate { get; set; }










    }
}
