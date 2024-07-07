using Microsoft.AspNetCore.Identity;

namespace RazorPagesApp.Data.Entities;

public class ApplicationUser : IdentityUser
{
    public Cart Cart { get; set; } = default!;
}