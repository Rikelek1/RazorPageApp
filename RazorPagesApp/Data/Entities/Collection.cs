using System.ComponentModel.DataAnnotations;

namespace RazorPagesApp.Data.Entities;

public class Collection : Entity
{
    [StringLength(128)]
    public string Name { get; set; } = string.Empty;
    public List<Movie> Movies { get; set; } = [];
}