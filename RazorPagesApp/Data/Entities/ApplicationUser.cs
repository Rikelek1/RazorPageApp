using Microsoft.AspNetCore.Identity;

namespace RazorPagesApp.Data.Entities;

public class ApplicationUser : IdentityUser
{
    public List<Movie> Movies { get; set; } = [];
}