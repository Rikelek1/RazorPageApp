using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesApp.Data.Entities;

namespace RazorPagesApp.Pages.Movies
{
    public class DeleteModel(Data.ApplicationDbContext context) : PageModel
    {
        [BindProperty]
      public Movie Movie { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
                return NotFound();

            var movie = await context.Movies.FirstOrDefaultAsync(m => m.Id == id);

            if (movie == null)
                return NotFound();

            Movie = movie;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
                return NotFound();

            var movie = await context.Movies.FindAsync(id);

            if (movie == null)
                return RedirectToPage("./Index");

            Movie = movie;
            context.Movies.Remove(Movie);
            await context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
