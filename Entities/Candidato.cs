using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace atsback.Entities
{
    public class Candidato
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; } 

        [BsonElement("Name")]
        public string Name { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }  
    }
}
