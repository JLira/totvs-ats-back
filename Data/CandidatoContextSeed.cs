using atsback.Entities;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace atsback.Data
{
    public class CandidatoContextSeed
    {
        public static void SeedData(IMongoCollection<Candidato> candidatoCollection)
        {
            bool existCandidato = candidatoCollection.Find(p => true).Any();
            if (!existCandidato)
            {
                candidatoCollection.InsertManyAsync(GetCandidatos());
            }
        }
        private static IEnumerable<Candidato> GetCandidatos()
        {
            return new List<Candidato>()
            {
                new Candidato()
                {
                    //Id = "602d2149e773f2a3990b47f6",
                    Name = "Josue Mendonça",
                    Email = "josue@email.com",
                    Telefone = "27332237890"
                },
                new Candidato()
                {
                    //Id = "602d2149e773f2a3990b47f7",
                    Name = "Mary Jane",
                    Email = "jane@email.com",
                    Telefone = "27345677890"
                },
                new Candidato()
                {
                    //Id = "602d2149e773f2a3990b47f8",
                    Name = "Tadeu Romeu",
                    Email = "tadeu@email.com",
                    Telefone = "27332267890"
                },
                new Candidato()
                {
                    //Id = "602d2149e773f2a3990b47f9",
                    Name = "Alvi de Souza",
                    Email = "alviv@email.com",
                    Telefone = "29353257890"
                },
            };
        }
    }
}
