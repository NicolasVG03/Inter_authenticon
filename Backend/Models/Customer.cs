using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace authenticon.Models;

[Table("Customers")]
public class Customer : Person
{
    [MaxLength(11)]
    public string? CPF { get; set; } = null!;

    [MaxLength(20)]
    public string Password { get; set; } = null!;

    public char? Gender { get; set; } = null;

}
