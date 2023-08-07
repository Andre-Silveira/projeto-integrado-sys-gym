using ApplicationCore;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PessoasController : ControllerBase
{
    private static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
    private readonly IAlunoService _alunoService;

    public PessoasController(IAlunoService alunoService)
    {
        _alunoService = alunoService;
    }


    [HttpPost("CadastrarAluno")]
    public IActionResult CadastrarAluno([FromBody] Aluno aluno)
    {
        try
        {
            _alunoService.CadastrarAluno(aluno);
            return Ok();
        }
        catch (Exception e)
        {
            logger.Error(e, "CadastrarAluno");
            throw;
        }
    }

    [HttpDelete("DeletarAluno/{id}")]
    public IActionResult DeletarAluno(string id)
    {
        try
        {
            _alunoService.DeletarAluno(id);
            return Ok();
        }
        catch (Exception e)
        {
            logger.Error(e, "DeletarAluno");
            throw;
        }
    }

    [HttpPut("AtualizarAluno")]
    public IActionResult AtualizarAluno([FromBody] Aluno aluno)
    {
        try
        {
            _alunoService.AtualizarAluno(aluno);
            return Ok();
        }
        catch (Exception e)
        {
            logger.Error(e, "AtualizarAluno");
            throw;
        }
    }

    [HttpGet("ListarAlunos")]
    public IActionResult BuscarAlunos()
    {
        try
        {
            List<Aluno> alunos = _alunoService.BuscarAlunos();
            return Ok(alunos);
        }
        catch (Exception e)
        {
            logger.Error(e, "BuscarAlunos");
            throw;
        }
    }

    [HttpGet("BuscarAlunoById/{id}")]
    public IActionResult BuscarAlunoById(string id)
    {
        try
        {
            Aluno aluno = _alunoService.BuscarAlunoById(id);
            return Ok(aluno);
        }
        catch (Exception e)
        {
            logger.Error(e, "BuscarAlunos");
            throw;
        }
    }

    [HttpGet("BloquearAluno/{id}")]
    public IActionResult BloquearAluno(string id)
    {
        try
        {
            _alunoService.BloquearAluno(id);
            return Ok();
        }
        catch (Exception e)
        {
            logger.Error(e, "BuscarAlunos");
            throw;
        }
    }

     [HttpGet("DesbloquearAluno/{id}")]
    public IActionResult DesbloquearAluno(string id)
    {
        try
        {
            _alunoService.DesbloquearAluno(id);
            return Ok();
        }
        catch (Exception e)
        {
            logger.Error(e, "BuscarAlunos");
            throw;
        }
    }
}
