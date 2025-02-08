using Microsoft.EntityFrameworkCore;
using migrationbundle.models;

namespace migrationbundle.Orgs;

public class orgdbcontext: DbContext
{
    public DbSet<Organizations> Organizations { get; set; }

    public orgdbcontext(DbContextOptions<orgdbcontext> options)
        : base(options)
    {
    }
}