
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BulkyBook.Models;
//[Microsoft.EntityFrameworkCore.Index(nameof(Name), IsUnique = true)]
public class Salary
{
    [Key]
    public int Id { get; set; }

    [Required]
    [Display(Name = "Designation")]
    public int DesignationId { get; set; }
    [ForeignKey("DesignationId")]
    [ValidateNever]
    public Designation Designation { get; set; }



    [Required]
    [Range(1,200000)]
    [Display(Name = "Salary")]
    public int TSalary { get; set; }
    
   
}
