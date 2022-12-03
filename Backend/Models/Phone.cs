using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace authenticon.Models;

[Table("Phone")]
public class Phone
{

    [MaxLength(15)]
    public string Number { get; set; } = null!;

    public int PersonID { get; set; }
}
