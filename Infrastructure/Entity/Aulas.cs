using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Infrastructure.Entity
{
    public class Aulas
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public decimal Mensalidade { get; set; }
    }
}
