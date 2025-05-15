using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace APICatalogo.Controllers;

[Route("api/v{version:apiVersion}/teste")]
[ApiController]
[ApiVersion("1.0", Deprecated = true)]
public class TesteV1Controller : Controller
{
    [HttpGet]
    public string GetVersion()
    {
        return "TesteV1 - GET - Api Versão 1.0";
    }
}
