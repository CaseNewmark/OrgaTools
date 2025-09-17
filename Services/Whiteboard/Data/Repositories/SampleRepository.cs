using Microsoft.EntityFrameworkCore;
using OrgaTools.Services.Whiteboard.Data.Entities;

namespace OrgaTools.Services.Whiteboard.Data.Repositories;

internal class SampleRepository : ISampleRepository
{

    private readonly WhiteboardDbContext _dbContext;

    public SampleRepository(WhiteboardDbContext whiteboardContext)
    {
        _dbContext = whiteboardContext;
    }

    public async Task AddAsync(SampleEntity sampleEntity)
    {
        if (sampleEntity == null)
            throw new ArgumentNullException(nameof(sampleEntity));

        // Track entity, but do NOT save
        await _dbContext.Samples
                        .AddAsync(sampleEntity);
    }

    public async Task<List<SampleEntity>> GetAllAsync()
    {
        return await _dbContext.Samples
                                .AsNoTracking()
                                .ToListAsync();
    }

    public async Task SaveChangesAsync() => await _dbContext.SaveChangesAsync();
}