using MongoDB.Driver;

namespace Infrastructure;

public interface IMongoDbContext
{
    IMongoCollection<T> GetCollection<T>(string name);

}
