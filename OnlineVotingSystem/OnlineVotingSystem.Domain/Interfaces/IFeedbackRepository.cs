using System;
using OnlineVotingSystem.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    namespace OnlineVotingSystem.Domain.Interfaces
    {

    public interface IFeedbackRepository : IGenericRepository<Feedback>
    {
        Task<IEnumerable<Feedback>> GetByUserIdAsync(int userId);

        Task<IEnumerable<Feedback>> GetByElectionIdAsync(int electionId);

        Task<IEnumerable<Feedback>> GetByFeedbackDateAsync(DateTime date);
    }
}
