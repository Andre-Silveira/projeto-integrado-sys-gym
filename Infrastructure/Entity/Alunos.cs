using ApplicationCore.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Infrastructure.Entity;

public class Alunos
{
    [BsonId]
    public ObjectId Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public string CPF { get; set; } = string.Empty;
    public string Endereco { get; set; } = string.Empty;
    public List<Aula> Aula { get; set; } = new();
    public DateTime DataNascimento { get; set; }
    public bool Ativo { get; set; }

}
