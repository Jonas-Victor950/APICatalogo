using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace APICatalogo.Controllers;

[Route("api/teste")]
[ApiController]
[ApiVersion("1.0")]
public class TesteV1Controller : Controller
{
    [HttpGet]
    public string GetVersion()
    {
        return "TesteV1 - GET - Api Versão 1.0";
    }
}
