using ApplicationCore;
using ApplicationCore.Models;
using Infrastructure.Entity;
using MongoDB.Driver;


namespace Infrastructure.Repositorio;

public class AulaRepositorio : IAulaRepositorio
{
    private readonly IMongoDbContext _mongoDBContext;
    private readonly IMongoCollection<Aulas> _aulasCollection;

    public AulaRepositorio(IMongoDbContext mongoDBContext)
    {
        _mongoDBContext = mongoDBContext;
        _aulasCollection = _mongoDBContext.GetCollection<Aulas>("aula");
    }

    public List<Aula> BuscarAulas()
    {
        return _aulasCollection.Find(p => true).ToList().Select(aula => new Aula
        {
            Nome = aula.Nome,
            Mensalidade = aula.Mensalidade
        }).ToList();
    }

    public void CadastrarAula(Aula aula)
    {
        _aulasCollection.InsertOne(new()
        {
            Nome = aula.Nome,
            Mensalidade = aula.Mensalidade
        });
    }
}
