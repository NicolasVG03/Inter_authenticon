using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace authenticon.Models;

public class Address
{
    [Key]
    public int AddressID { get; set; }

    [MaxLength(100)]
    public string AddressName { get; set; } = null!;

    [MaxLength(6)]
    public string Number { get; set; } = null!;

    [MaxLength(8)]
    public string ZipCode { get; set; } = null!;

    [MaxLength(100)]
    public string AddressComplement { get; set; } = null!;

    public int CustomerID { get; set; }

    [ForeignKey("CustomerID")]
    public Customer Customer { get; set; } = null!;

}
