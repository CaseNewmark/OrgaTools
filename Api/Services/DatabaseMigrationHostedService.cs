using Microsoft.EntityFrameworkCore;
using OrgaTools.Api.Database;

namespace OrgaTools.Api.Services;

public class DatabaseMigrationHostedService : IHostedService
{
    private readonly IServiceProvider _serviceProvider;

    public DatabaseMigrationHostedService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using var scope = _serviceProvider.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<OrgaToolsDbContext>();
        await db.Database.MigrateAsync(cancellationToken);
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}