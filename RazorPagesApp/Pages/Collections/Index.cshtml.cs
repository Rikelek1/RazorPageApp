using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesApp.Data;
using RazorPagesApp.Data.Entities;

namespace RazorPagesApp.Pages.Collections
{
    public class IndexModel(ApplicationDbContext context) : PageModel
    {
        public IList<Collection> Collections { get;set; }  = default!;
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public SelectList? Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? MovieGenre { get; set; }

        public async Task OnGetAsync()
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = context.Movies.OrderBy(x => x.Genre).Select(x => x.Genre);

            IQueryable<Collection> collections = context.Collections;

            if (!string.IsNullOrEmpty(SearchString))
                collections = collections.Where(s => s.Name.Contains(SearchString));

            if (!string.IsNullOrEmpty(MovieGenre))
                collections = collections.Where(x => x.Movies.Any(y => y.Genre == MovieGenre));
            
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            Collections = await collections.ToListAsync();
        }
    }
}
