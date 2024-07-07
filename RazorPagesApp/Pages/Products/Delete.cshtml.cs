using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesApp.Data.Entities;

namespace RazorPagesApp.Pages.Products;

public class DeleteModel(Data.ApplicationDbContext context) : PageModel
{
    [BindProperty]
    public Product Product { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
            return NotFound();

        Product? product = await context.Products.FirstOrDefaultAsync(m => m.Id == id);

        if (product == null)
        {
            return NotFound();
        }

        Product = product;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id == null)
            return NotFound();

        Product? product = await context.Products.FindAsync(id);

        if (product == null)
            return RedirectToPage("./Index");

        Product = product;
        context.Products.Remove(Product);
        await context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}