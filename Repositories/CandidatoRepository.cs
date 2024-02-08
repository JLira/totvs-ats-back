using atsback.Data;
using atsback.Entities;
using MongoDB.Driver;
using System.Runtime.InteropServices;

namespace atsback.Repositories
{
    public class CandidatoRepository: ICandidatoRepository
    {
        private readonly ICandidatoContext _context;

        public CandidatoRepository(ICandidatoContext context)
        {
            _context = context;
        }

        public async Task CreateCandidato(Candidato candidato)
        {
            await _context.Candidatos.InsertOneAsync(candidato);
        }

        public async Task<bool> DeleteCandidato(string id)
        {
            FilterDefinition<Candidato> filter = Builders<Candidato>.Filter.Eq(p =>
                                                 p.Id, id);

            DeleteResult deleteResult = await _context.Candidatos
                                          .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;

        }

        public async Task<Candidato> GetCandidato(string id)
        {
            return await _context.Candidatos.Find(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Candidato>> GetCandidatoByName(string name)
        {
            FilterDefinition<Candidato> filter = Builders<Candidato>
                .Filter.ElemMatch(c => c.Name, name);

            return  await _context.Candidatos.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Candidato>> GetCandidatos()
        {
            return await _context.Candidatos.Find(c => true).ToListAsync();
        }

        public async Task<bool> UpdateCandidato(Candidato candidato)
        {
            var updateResult = await _context.Candidatos.ReplaceOneAsync(
                filter: g => g.Id == candidato.Id, replacement: candidato);

            return updateResult.IsAcknowledged &&
                updateResult.ModifiedCount > 0;
        }
    }
}
