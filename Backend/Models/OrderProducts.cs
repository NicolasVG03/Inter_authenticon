using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace authenticon.Models;

public class OrderProducts
{

    public int QuantityOrdered { get; set; }

    [Precision(9, 2)]
    public decimal TotalPriceProduct { get; set; }

    public int OrderID { get; set; }

    [ForeignKey("OrderID")]
    public Order? Order { get; set; }

    public int ProductID { get; set; }

    [ForeignKey("ProductID")]
    public Product? Product { get; set; }

}