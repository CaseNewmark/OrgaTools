using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Microsoft.Extensions.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

var api = builder.AddProject<Projects.Api>("api");

if (builder.Environment.IsDevelopment())
{
       var dbServer = builder.AddPostgres("dbserver")
                                         .WithDockerfile("../../Infrastructure/Postgres")
                                         .WithDataVolume()
                                         .WithHostPort(5432);
       var db = dbServer.AddDatabase("orgatools-database");
       api.WithReference(db)
          .WaitFor(db);
}

builder.AddNpmApp("frontend", "../../Frontend")
       .WithReference(api)
       .WaitFor(api)
       .WithExternalHttpEndpoints();

builder.Build().Run();