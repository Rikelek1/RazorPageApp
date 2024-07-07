using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesApp.Data;
using RazorPagesApp.Data.Entities;

namespace RazorPagesApp.Pages.Collections
{
    public class CreateModel(ApplicationDbContext context) : PageModel
    {
        [BindProperty]
        public Collection Collection { get; set; } = default!;

        public IActionResult OnGet()
        {
            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
              return Page();

          context.Collections.Add(Collection);
          await context.SaveChangesAsync();

          return RedirectToPage("./Index");
        }
    }
}
