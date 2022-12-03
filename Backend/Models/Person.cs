using System.ComponentModel.DataAnnotations;

namespace authenticon.Models;

public abstract class Person
{
    [Key]
    public int UserID { get; set; }

    [MaxLength(60)]
    public string? Name { get; set; }

    [MaxLength(100)]
    public string Email { get; set; } = null!;

    public int Status { get; set; }

    public List<Phone>? Phones { get; set; }

}
