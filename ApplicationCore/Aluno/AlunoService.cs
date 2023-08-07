using ApplicationCore.Models;

namespace ApplicationCore;

public class AlunoService : IAlunoService
{
    private readonly IAlunoRepositorio _alunoRepositorio;

    public AlunoService(IAlunoRepositorio alunoRepositorio)
    {
        _alunoRepositorio = alunoRepositorio;
    }

    public void AtualizarAluno(Aluno aluno)
    {
        _alunoRepositorio.AtualizarAluno(aluno);
    }

    public Aluno BuscarAlunoById(string id)
    {
        return _alunoRepositorio.BuscarAlunoById(id);
    }

    public List<Aluno> BuscarAlunos()
    {
        return _alunoRepositorio.BuscarAlunos();
    }

    public void CadastrarAluno(Aluno aluno)
    {
        _alunoRepositorio.CadastrarAluno(aluno);
    }


    public void DeletarAluno(string id)
    {
        _alunoRepositorio.DeletarAluno(id);
    }

    public void BloquearAluno(string id)
    {
        _alunoRepositorio.BloquearAluno(id);
    }

    public void DesbloquearAluno(string id)
    {
        _alunoRepositorio.DesbloquearAluno(id);
    }
}
