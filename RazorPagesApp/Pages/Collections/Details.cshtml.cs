using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesApp.Data;
using RazorPagesApp.Data.Entities;

namespace RazorPagesApp.Pages.Collections
{
    public class DetailsModel(ApplicationDbContext context) : PageModel
    {
        public Collection Collection { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
                return NotFound();

            Collection? collection = await context.Collections.FirstOrDefaultAsync(x => x.Id == id);

            if (collection == null)
                return NotFound();
            
            Collection = collection;
            return Page();
        }
    }
}
