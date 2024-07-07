using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesApp.Data;
using RazorPagesApp.Data.Entities;

namespace RazorPagesApp.Pages.Products;

public class CreateModel(ApplicationDbContext context) : PageModel
{
    [BindProperty]
    public Product Product { get; set; } = default!;
    
    public IActionResult OnGet()
    {
        return Page();
    }

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        context.Products.Add(Product);
        await context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}