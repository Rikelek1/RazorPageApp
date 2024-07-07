using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RazorPagesApp.Data.Entities;

namespace RazorPagesApp.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Movie> Movies { get; set; } = default!;
    public DbSet<Collection> Collections { get; set; } = default!;
}