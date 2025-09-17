using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OrgaTools.Services.Whiteboard.Mapper;

namespace OrgaTools.Services.Whiteboard;

public static class DependencyInjection
{
    public static IHostApplicationBuilder AddWhiteboardServices(this IHostApplicationBuilder builder)
    {
        // Register the Whiteboard services.

        // Options 
        // builder.Services.AddOptionsWithValidateOnStart<SomeOptions>()
        //                 .Bind(builder.Configuration.GetSection(SomeOptions.Section));

        builder.Services.AddSingleton<SampleMapper, SampleMapper>();

        return builder;
    }
}

