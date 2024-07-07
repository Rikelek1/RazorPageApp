using Microsoft.EntityFrameworkCore.Infrastructure;

namespace RazorPagesApp.Data.Entities;

public class Cart : Entity
{
    public List<Product> Products { get; set; } = default!;
}