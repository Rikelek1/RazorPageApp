using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesApp.Data;
using RazorPagesApp.Data.Entities;

namespace RazorPagesApp.Pages.Products;

public class IndexModel(ApplicationDbContext context) : PageModel
{
    public IList<Product> Products { get;set; }  = default!;
    [BindProperty(SupportsGet = true)]
    public string? SearchString { get; set; }
    public SelectList? Categories { get; set; }
    [BindProperty(SupportsGet = true)]

    public string? Category { get; set; }

    public async Task OnGetAsync()
    {
        IQueryable<Product> products = context.Products;

        if (!string.IsNullOrEmpty(SearchString))
            products = products.Where(x => x.Name.Contains(SearchString) || x.Description.Contains(SearchString) || x.SKU.Contains(SearchString));

        if (!string.IsNullOrEmpty(Category))
            products = products.Where(x => x.Category != null && x.Category.Contains(Category));

        Categories = new SelectList(await products.Select(x => x.Category).ToListAsync());
        Products = await products.ToListAsync();
    }
}