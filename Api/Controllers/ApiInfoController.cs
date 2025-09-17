using Microsoft.AspNetCore.Mvc;
using OrgaTools.Api.Dtos;

namespace OrgaTools.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ApiInfoController : ControllerBase
{
    [HttpGet]
    public ApiInfoDto Get()
    {
        return ApiInfoDto.Instance;
    }
}
