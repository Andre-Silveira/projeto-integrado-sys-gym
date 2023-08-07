using ApplicationCore;
using ApplicationCore.Models;
using Infrastructure.Entity;
using MongoDB.Bson;
using MongoDB.Driver;
namespace Infrastructure;

public class AlunoRepositorio : IAlunoRepositorio
{
    private readonly IMongoDbContext _mongoDBContext;
    private readonly IMongoCollection<Alunos> _alunoCollection;

    public AlunoRepositorio(IMongoDbContext mongoDBContext)
    {
        _mongoDBContext = mongoDBContext;
        _alunoCollection = _mongoDBContext.GetCollection<Alunos>("aluno");
    }

    public void AtualizarAluno(Aluno aluno)
    {
        var filtro = Builders<Alunos>.Filter.Eq(x => x.Id, ObjectId.Parse(aluno.Id));

        var update = Builders<Alunos>.Update.Set(x => x.Nome, aluno.Nome)
                            .Set(x => x.Email, aluno.Email)
                            .Set(x => x.Telefone, aluno.Telefone)
                            .Set(x => x.CPF, aluno.CPF)
                            .Set(x => x.Endereco, aluno.Endereco)
                            .Set(x => x.Aula, aluno.Aula)
                            .Set(x => x.DataNascimento, aluno.DataNascimento);
        _alunoCollection.UpdateOne(filtro, update);

    }

    public Aluno BuscarAlunoById(string id)
    {
        var filtro = Builders<Alunos>.Filter.Eq(x => x.Id, ObjectId.Parse(id));

        var aluno = _alunoCollection.Find(filtro).First();
        if (aluno == null)
            throw new Exception("Não foi encontrado nenhum aluno!");
        else
            return new()
            {
                Id = id,
                Nome = aluno.Nome,
                Email = aluno.Email,
                Telefone = aluno.Telefone,
                CPF = aluno.CPF,
                Endereco = aluno.Endereco,
                Aula = aluno.Aula,
                DataNascimento = aluno.DataNascimento,
                Ativo = aluno.Ativo,
            };
    }

    public List<Aluno> BuscarAlunos()
    {
        return _alunoCollection.Find(p => true).ToList().Select(aluno => new Aluno
        {
            Id = aluno.Id.ToString(),
            Nome = aluno.Nome,
            Email = aluno.Email,
            Telefone = aluno.Telefone,
            CPF = aluno.CPF,
            Endereco = aluno.Endereco,
            Aula = aluno.Aula,
            DataNascimento = aluno.DataNascimento
        }).ToList();
    }


    public void CadastrarAluno(Aluno aluno)
    {
        _alunoCollection.InsertOne(new()
        {
            Nome = aluno.Nome,
            Email = aluno.Email,
            Telefone = aluno.Telefone,
            CPF = aluno.CPF,
            Endereco = aluno.Endereco,
            Aula = aluno.Aula,
            DataNascimento = aluno.DataNascimento,

        });
    }


    public void DeletarAluno(string id)
    {
        var filtro = Builders<Alunos>.Filter.Eq(x => x.Id, ObjectId.Parse(id));

        _alunoCollection.DeleteOne(filtro);
    }

    public void BloquearAluno(string id)
    {
        var filtro = Builders<Alunos>.Filter.Eq(x => x.Id, ObjectId.Parse(id));
        var update = Builders<Alunos>.Update.Set(x => x.Ativo, true);
                           
        _alunoCollection.UpdateOne(filtro, update);
    }

    public void DesbloquearAluno(string id)
    {
        var filtro = Builders<Alunos>.Filter.Eq(x => x.Id, ObjectId.Parse(id));
        var update = Builders<Alunos>.Update.Set(x => x.Ativo, false);
                           
        _alunoCollection.UpdateOne(filtro, update);
    }

}
