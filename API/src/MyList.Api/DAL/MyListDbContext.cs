using Microsoft.EntityFrameworkCore;
using MyList.Api.Entities;

namespace MyList.Api.DAL;

internal sealed class MyListDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public MyListDbContext(DbContextOptions<MyListDbContext> options) : base(options)
    {
    }
}
