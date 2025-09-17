using Microsoft.EntityFrameworkCore;
using OrgaTools.Services.Whiteboard.Data.Entities;

namespace OrgaTools.Services.Whiteboard.Data;

public class WhiteboardDbContext : DbContext
{
    public WhiteboardDbContext(DbContextOptions<WhiteboardDbContext> options) : base(options)
    {

    }

    public DbSet<SampleEntity> Samples { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // optional configurations
        modelBuilder.Entity<SampleEntity>()
            .HasIndex(d => d.Id)
            .IsUnique();

        modelBuilder.Entity<SampleEntity>()
                .Property(c => c.Subject)
                .HasConversion<string>();// store the string value of enum instead of string.
        }

}
