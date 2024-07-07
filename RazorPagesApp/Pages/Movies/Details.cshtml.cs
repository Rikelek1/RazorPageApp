using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesApp.Data;
using RazorPagesApp.Data.Entities;

namespace RazorPagesApp.Pages.Movies
{
    public class DetailsModel(ApplicationDbContext context) : PageModel
    {
        public Movie Movie { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
                return NotFound();

            Movie? movie = await context.Movies.FirstOrDefaultAsync(m => m.Id == id);

            if (movie == null)
                return NotFound();
            
            Movie = movie;
            return Page();
        }
    }
}
