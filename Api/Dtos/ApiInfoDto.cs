using System.Reflection;

namespace OrgaTools.Api.Dtos;

public class ApiInfoDto
{
    protected ApiInfoDto() { }

    public string Version { get; } = Assembly.GetEntryAssembly()!
                                             .GetCustomAttribute<AssemblyInformationalVersionAttribute>()!.InformationalVersion;

    public static ApiInfoDto Instance = new();
}
