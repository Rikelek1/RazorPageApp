using Microsoft.AspNetCore.Identity;

namespace RazorPagesApp.Data.Entities;

public class ApplicationUser : IdentityUser
{
    public List<Collection> Collections { get; set; } = [];
}