using Infrastructure.Entity;
using MongoDB.Driver;

namespace Infrastructure;

public class MongoDbContext : IMongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(string connectionString, string databaseName)
    {
        var client = new MongoClient(connectionString);
        _database = client.GetDatabase(databaseName);
    }

    public IMongoCollection<Alunos> Alunos => _database.GetCollection<Alunos>("alunos");
    public IMongoCollection<Aulas> Aulas => _database.GetCollection<Aulas>("aulas");

    public IMongoCollection<T> GetCollection<T>(string name)
    {
        return _database.GetCollection<T>(name);
    }
}

