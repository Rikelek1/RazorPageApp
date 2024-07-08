using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesApp.Data;
using RazorPagesApp.Data.Entities;

namespace RazorPagesApp.Pages.Movies
{
    public class EditModel(ApplicationDbContext context, UserManager<ApplicationUser> userManager) : PageModel
    {
        [BindProperty]
        public Movie Movie { get; set; } = default!;

        public List<SelectListItem> Users { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
                return NotFound();

            var user = await userManager.GetUserAsync(User);

            Users = await context.Users.Where(x => user == null || x.Id != user.Id).Select(x => new SelectListItem(x.Email, x.Id)).ToListAsync();

            var movie =  await context.Movies.FirstOrDefaultAsync(m => m.Id == id);

            if (movie == null)
                return NotFound();

            Movie = movie;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            context.Attach(Movie).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(Movie.Id))
                    return NotFound();

                throw;
            }

            return RedirectToPage("./Index");
        }

        private bool MovieExists(int id)
        {
          return context.Movies.Any(e => e.Id == id);
        }
    }
}
