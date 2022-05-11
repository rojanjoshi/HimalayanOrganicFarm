

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyBook.Models;
//[Index(nameof(Name), IsUnique = true)]
public class Designation
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(15)]
    
    public string Name { get; set; }


}
