using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace authenticon.Models;

public class Collection
{

    [Key]
    public int CollectionID { get; set; }

    [MaxLength(40)]
    public string? Name { get; set; }

}
