using OnlineVotingSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineVotingSystem.Domain.Interfaces
{
    
    public interface IVotesRepository : IGenericRepository<Votes>
    {
        Task<IEnumerable<Votes>> GetByUserIdAsync(int userId);

        Task<IEnumerable<Votes>> GetByElectionIdAsync(int electionId);

        Task<IEnumerable<Votes>> GetByCandidateIdAsync(int candidateId);

        Task<IEnumerable<Votes>> GetByVoteDateAsync(DateTime date);
    }
}
