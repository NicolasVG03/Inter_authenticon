using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace authenticon.Models;

public class Product
{
    [Key]
    public int ProductID { get; set; }

    [MaxLength(60)]
    public string Name { get; set; } = null!;

    [MaxLength(100)]
    public string Description { get; set; } = null!;

    [MaxLength(20)]
    public string Color { get; set; } = null!;

    [MaxLength(5)]
    public string Size { get; set; } = null!;

    [Precision(9, 2)]
    public decimal UnitPrice { get; set; }

    public int StockQuantity { get; set; }

    public char Gender { get; set; }

    public int Status { get; set; }

    [NotMapped]
    [DisplayName("Upload File")]
    public IFormFile ImageFile { get; set; } = null!;

    public string? ImageUrl { get; set; } = null!;

    public int AdministratorID { get; set; }

    [ForeignKey("AdministratorID")]
    public Administrator? Administrator { get; set; }

    public int CollectionID { get; set; }

    [ForeignKey("CollectionID")]
    public Collection? Collection { get; set; }

    public int CategoryID { get; set; }

    [ForeignKey("CategoryID")]
    public Category? Category { get; set; }

}
