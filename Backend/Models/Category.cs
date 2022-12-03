using System.ComponentModel.DataAnnotations;

namespace authenticon.Models;

public class Category
{

    [Key]
    public int CategoryID { get; set; }

    [MaxLength(40)]
    public string? Name { get; set; }

}
