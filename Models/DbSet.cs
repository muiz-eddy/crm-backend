using MenuApi.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{

  public DbSet<Product> Products { get; set; } = null!;

  public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
  {

  }
}
