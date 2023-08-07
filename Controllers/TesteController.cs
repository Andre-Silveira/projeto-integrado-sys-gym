using ApplicationCore;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
public class TesteController : ControllerBase
{

    public TesteController()
    {
    }


    [HttpGet("")]
    public IActionResult Teste()
    {
        try
        {
            
            return Ok("Hello world!!");
        }
        catch (Exception e)
        {
          
            throw;
        }
    }

}
