using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace authenticon.Models;

[Table("Administrators")]
public class Administrator : Person
{
    [MaxLength(20)]
    public string Password { get; set; } = null!;
}
