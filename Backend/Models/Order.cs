using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace authenticon.Models;

public class Order
{
    [Key]
    public int OrderID { get; set; }

    [Precision(3)]
    public DateTime OrderDate { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime DeliveryDate { get; set; }

    [Precision(6, 2)]
    public decimal Freight { get; set; }

    [Precision(11, 2)]
    public decimal TotalPriceOrder { get; set; }

    public int Status { get; set; }

    public int CustomerID { get; set; }

    [ForeignKey("CustomerID")]
    public Customer? Customer { get; set; }
}
