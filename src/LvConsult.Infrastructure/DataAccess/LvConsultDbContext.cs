using LvConsult.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LvConsult.Infrastructure.DataAccess;
public class LvConsultDbContext : DbContext
{
    public LvConsultDbContext(DbContextOptions options) : base(options) { }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
