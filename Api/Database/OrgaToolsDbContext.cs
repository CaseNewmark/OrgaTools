using Microsoft.EntityFrameworkCore;

namespace OrgaTools.Api.Database;

public class OrgaToolsDbContext : DbContext
{
    public OrgaToolsDbContext(DbContextOptions<OrgaToolsDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure your entity mappings here
    }
}