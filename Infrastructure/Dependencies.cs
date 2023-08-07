using ApplicationCore;
using Infrastructure.Repositorio;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Infrastructure;
public static class Dependencies
{
    public static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
    {
        string connectionString = configuration.GetConnectionString("MongoDb")!;
        string databaseName = configuration.GetSection("MongoDatabaseName").Value!;


        services.AddSingleton<IMongoDbContext>(new MongoDbContext(connectionString, databaseName));
        services.AddScoped(typeof(IAlunoRepositorio), typeof(AlunoRepositorio));
        services.AddScoped(typeof(IAulaRepositorio), typeof(AulaRepositorio));



    }
}