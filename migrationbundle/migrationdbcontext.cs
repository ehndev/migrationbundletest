using Microsoft.EntityFrameworkCore;
using migrationbundle.models;

namespace migrationbundle;

public class Migrationdbcontext: DbContext
{
    public DbSet<Todo> Todos { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Workflows> Workflows { get; set; }
    public DbSet<Users> Users { get; set; }

    public Migrationdbcontext(DbContextOptions<Migrationdbcontext> options)
        : base(options)
    {
    }
}