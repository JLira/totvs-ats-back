using atsback.Entities;
using MongoDB.Driver;

namespace atsback.Data
{
    public interface ICandidatoContext
    {
        IMongoCollection<Candidato> Candidatos { get; }
    }
}
