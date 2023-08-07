using ApplicationCore;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AulasController : ControllerBase
{
    private static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
    private readonly IAulaService _aulaService;

    public AulasController(IAulaService aulaService)
    {
        _aulaService = aulaService;
    }


    [HttpPost("CadastrarAula")]
    public IActionResult CadastrarAula([FromBody] Aula aula)
    {
        try
        {
            _aulaService.CadastrarAula(aula);
            return Ok();
        }
        catch (Exception e)
        {
            logger.Error(e, "CadastrarAula");
            throw;
        }
    }

    [HttpGet("ListarAulas")]
    public IActionResult BuscarAulas()
    {
        try
        {
            List<Aula> alunos = _aulaService.BuscarAulas();
            return Ok(alunos);
        }
        catch (Exception e)
        {
            logger.Error(e, "BuscarAulas");
            throw;
        }
    }
}
