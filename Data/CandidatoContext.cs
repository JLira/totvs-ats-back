using atsback.Entities;
using MongoDB.Driver;

namespace atsback.Data
{
    public class CandidatoContext : ICandidatoContext
    {
        public CandidatoContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>
                ("DatabaseSettings:ConnectionString"));

            var database = client.GetDatabase(configuration.GetValue<string>
                ("DatabaseSettings:DatabaseName"));

            Candidatos = database.GetCollection<Candidato>(configuration.GetValue<string>
                ("DatabaseSettings:CollectionName"));

            CandidatoContextSeed.SeedData(Candidatos);

        }
        public IMongoCollection<Candidato> Candidatos { get; }
    }
}
