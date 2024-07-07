using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesApp.Data.Entities;

public class Product : Entity
{
    [StringLength(60, MinimumLength = 3)]
    public string Name { get; set; } = string.Empty;

    [StringLength(512)]
    public string Description { get; set; } = string.Empty;

    [Range(1, 100), DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }

    [StringLength(16)]
    public string SKU { get; set; } = string.Empty;

    public int Stock { get; set; }

    [StringLength(128)]
    public string? Category { get; set; }
}
