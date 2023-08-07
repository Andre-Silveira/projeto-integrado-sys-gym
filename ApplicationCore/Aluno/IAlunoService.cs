using ApplicationCore.Models;

namespace ApplicationCore;

public interface IAlunoService
{
    void AtualizarAluno(Aluno aluno);
    void BloquearAluno(string id);
    Aluno BuscarAlunoById(string id);
    List<Aluno> BuscarAlunos();
    void CadastrarAluno(Aluno aluno);
    void DeletarAluno(string id);
    void DesbloquearAluno(string id);
}
