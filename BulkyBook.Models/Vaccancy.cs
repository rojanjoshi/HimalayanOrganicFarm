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
    public class Vaccancy
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Designation")]
        public int DesignationId { get; set; }
        [ForeignKey("DesignationId")]
        [ValidateNever]
        public Designation Designation { get; set; }

        [Display(Name = "Number of positions")]
        [Required]
        public string Nposition { get; set; }

        [Display(Name = "Start date (dd/mm/yy)")]
        [Required]
        public DateTime Startdate { get; set; } = DateTime.Now;

        [Display(Name = "Deadline (dd/mm/yy)")]
        [Required]
        public string Deadline { get; set; }






    }
}
