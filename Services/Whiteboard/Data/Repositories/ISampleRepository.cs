using OrgaTools.Services.Whiteboard.Data.Entities;

namespace OrgaTools.Services.Whiteboard.Data.Repositories;

public interface ISampleRepository
{
    Task<List<SampleEntity>> GetAllAsync();
    Task AddAsync(SampleEntity sampleEntity);

     /// <summary>
    /// Commits all tracked changes to the database.
    /// </summary>
    Task SaveChangesAsync();
}