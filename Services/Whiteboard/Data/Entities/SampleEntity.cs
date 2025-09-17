using System.ComponentModel.DataAnnotations;

namespace OrgaTools.Services.Whiteboard.Data.Entities;

public class SampleEntity
{
    [Key]
    public Guid Id { get; set; }

    public string Subject { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}