

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyBook.Models;

public class Leave
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(15)]
    
    public string Name { get; set; }


}
