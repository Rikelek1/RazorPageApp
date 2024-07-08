using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesApp.Data;
using RazorPagesApp.Data.Entities;

namespace RazorPagesApp.Pages.Movies
{
    public class CreateModel(ApplicationDbContext context, UserManager<ApplicationUser> userManager) : PageModel
    {
        [BindProperty]
        public Movie Movie { get; set; } = default!;

        public List<SelectListItem> Users { get; set; } = [];

        public IActionResult OnGet()
        {
            Users = context.Users.Select(x => new SelectListItem(x.Email, x.Id)).ToList();

            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
              return Page();

          context.Movies.Add(Movie);
          await context.SaveChangesAsync();

          return RedirectToPage("./Index");
        }
    }
}
