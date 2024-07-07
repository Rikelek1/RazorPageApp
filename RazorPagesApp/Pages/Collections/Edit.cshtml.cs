using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesApp.Data;
using RazorPagesApp.Data.Entities;

namespace RazorPagesApp.Pages.Collections
{
    public class EditModel(ApplicationDbContext context) : PageModel
    {
        [BindProperty]
        public Collection Collection { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
                return NotFound();

            Collection? collection =  await context.Collections.FirstOrDefaultAsync(x => x.Id == id);

            if (collection == null)
                return NotFound();

            Collection = collection;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            context.Attach(Collection).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CollectionExists(Collection.Id))
                    return NotFound();
                
                throw;
            }

            return RedirectToPage("./Index");
        }

        private bool CollectionExists(int id)
        {
          return context.Collections.Any(x => x.Id == id);
        }
    }
}
