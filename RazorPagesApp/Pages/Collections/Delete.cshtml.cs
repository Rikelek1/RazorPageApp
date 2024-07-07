using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesApp.Data.Entities;

namespace RazorPagesApp.Pages.Collections
{
    public class DeleteModel(Data.ApplicationDbContext context) : PageModel
    {
        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
                return NotFound();
            
            Collection? collection = await context.Collections.FindAsync(id);

            if (collection == null)
                return RedirectToPage("./Index");
            
            Collection = collection;
            context.Collections.Remove(Collection);

            await context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
