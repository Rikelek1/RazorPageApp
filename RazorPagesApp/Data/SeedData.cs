using Microsoft.EntityFrameworkCore;
using RazorPagesApp.Data.Entities;

namespace RazorPagesApp.Data;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using ApplicationDbContext? context = new(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());
            
        if (context.Products == null)
        {
            throw new ArgumentNullException("Null ApplicationDbContext");
        }

        // Look for any movies.
        if (context.Products.Any())
        {
            return; // DB has been seeded
        }

        context.SaveChanges();

        context.Products.AddRange(
            new Product
            {
                Name = "Smart Watch",
                Price = 87.99M,
                SKU = "SWATCH-1234",
                Stock = 150,
                Category = "Watches"
            },
            new Product
            {
                Name = "1080p Dashcam",
                Price = 38.99M,
                SKU = "DCAM-1234",
                Stock = 76,
                Category = "Dashcams"
            },
            new Product
            {
                Name = "Wi-fi 6 Router",
                Price = 65.99M,
                SKU = "ROUTER-1234",
                Stock = 150,
                Category = "Electronics"
            },
            new Product
            {
                Name = "Portable Air-conditioning unit (9000 BTU)",
                Price = 287.99M,
                SKU = "AIRCON-1234",
                Stock = 45,
                Category = "Air conditioning"
            }
        );
            
        context.SaveChanges();
    }
}