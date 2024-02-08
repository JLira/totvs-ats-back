using atsback.Entities;

namespace atsback.Repositories
{
    public interface ICandidatoRepository
    {
        Task<IEnumerable<Candidato>> GetCandidatos();
        Task<Candidato> GetCandidato(string id);
        Task<IEnumerable<Candidato>> GetCandidatoByName(string name);

        Task CreateCandidato(Candidato candidato);
        Task<bool> UpdateCandidato(Candidato candidato);
        Task<bool> DeleteCandidato(string id);  
    }
}
