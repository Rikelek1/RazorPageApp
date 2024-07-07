using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesApp.Data;
using RazorPagesApp.Data.Entities;

namespace RazorPagesApp.Pages.Products;

public class DetailsModel(ApplicationDbContext context) : PageModel
{
    public Product Product { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
            return NotFound();

        Product? product = await context.Products.FirstOrDefaultAsync(m => m.Id == id);
            
        if (product == null)
            return NotFound();

        Product = product;
        return Page();
    }
}