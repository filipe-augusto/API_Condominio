using Microsoft.AspNetCore.Mvc;
using API_Condominio.Attributes;

namespace API_Condominio.Controllers;

[ApiController]
[Route("")]
public class HomeController : Controller
{
    [HttpGet]

    [Apikey]
    public IActionResult Get()
    {
        return Ok();
    }

    [HttpGet("/config")]
    public IActionResult GetConfiguration([FromServices] IConfiguration config)
    {
        var env = config.GetValue<string>("env");
        return Ok(new
        {
            mensagem = env
        });
    }
}

