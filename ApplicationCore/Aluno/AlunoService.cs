using System.Net.Mail;
using System.Text.RegularExpressions;
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
        if (!CpfValido(aluno.CPF))
            throw new ArgumentException("CPF inválido!");

        if (!EmailValido(aluno.Email))
            throw new ArgumentException("E-mail inválido!");

        if (!TelefoneValido(aluno.Telefone))
            throw new ArgumentException("Telefone inválido!");

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
        if (!CpfValido(aluno.CPF))
            throw new ArgumentException("CPF inválido!");

        if (!EmailValido(aluno.Email))
            throw new ArgumentException("E-mail inválido!");

        if (!TelefoneValido(aluno.Telefone))
            throw new ArgumentException("Telefone inválido!");

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

    public bool CpfValido(string cpf)
    {
        cpf = cpf.Replace(".", "").Replace("-", "");

        if (cpf.Length != 11 || !long.TryParse(cpf, out _))
            return false;

        int[] peso1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] poso2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

        string digito1 = cpf.Substring(9, 1);
        string digito2 = cpf.Substring(10, 1);

        int soma = 0;
        for (int i = 0; i < 9; i++)
        {
            soma += int.Parse(cpf[i].ToString()) * peso1[i];
        }
        if (soma == 0)
            return false;

        int calculoDigito1 = (soma % 11) < 2 ? 0 : 11 - (soma % 11);

        if (calculoDigito1.ToString() != digito1)
            return false;

        soma = 0;
        for (int i = 0; i < 10; i++)
        {
            soma += int.Parse(cpf[i].ToString()) * poso2[i];
        }
        if (soma == 0)
            return false;

        int calculoDigito2 = (soma % 11) < 2 ? 0 : 11 - (soma % 11);

        return calculoDigito2.ToString() == digito2;
    }

    public bool EmailValido(string email)
    {
        try
        {
            var mailAddress = new MailAddress(email);
            return true;
        }
        catch (FormatException)
        {
            return false;
        }
    }

    public bool TelefoneValido(string telefone)
    {
        string numero = Regex.Replace(telefone, @"\D", "");

        if (numero.Length != 11)
            return false;

        return true;
    }
}
