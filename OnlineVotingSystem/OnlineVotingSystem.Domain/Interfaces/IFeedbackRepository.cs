using OnlineVotingSystem.Domain.Entities.OnlineVotingSystem.Models;
using OnlineVotingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    namespace OnlineVotingSystem.Domain.Interfaces
    {

    public interface IFeedbackRepository : IGenericRepository<FeedBack>
    {
        Task<IEnumerable<FeedBack>> GetByUserIdAsync(int userId);

        Task<IEnumerable<FeedBack>> GetByElectionIdAsync(int electionId);

        Task<IEnumerable<FeedBack>> GetByFeedbackDateAsync(DateTime date);
    }
}
