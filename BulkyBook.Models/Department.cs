

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyBook.Models;
//[Microsoft.EntityFrameworkCore.Index(nameof(Name), IsUnique = true)]
public class Department
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(15)]

    public string Name { get; set; }
    
   
}
