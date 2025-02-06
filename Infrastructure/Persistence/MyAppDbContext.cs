using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class MyAppDbContext : DbContext
{
    public MyAppDbContext(DbContextOptions<MyAppDbContext> options) : base(options)
    { }

    public DbSet<Product> Products => Set<Product>();

}