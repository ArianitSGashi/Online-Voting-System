using Microsoft.EntityFrameworkCore;
using OnlineVotingSystem.Domain.Entities;
using OnlineVotingSystem.Domain.Interfaces;
using OnlineVotingSystem.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineVotingSystem.Infrastructure.Services
{
    public class VotesRepository : IVotesRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public VotesRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Votes entity)
        {
            var exists = _dbContext.Results.Any(c => c.TotalVotes == entity.VoteID);
            var existsElectronic = _dbContext.Results.Any(c => c.ElectionID == entity.ElectionID);
            var existsCandidate = _dbContext.Results.Any(c => c.CandidateID == entity.CandidateID);
            if (exists)
            {
                throw new Exception("This feedback already exists");
            }
            else if (!existsElectronic)
            {
                throw new Exception("Election with id :" + entity.ElectionID + " does not exist.");
            }
            else if (!existsElectronic)
            {
                throw new Exception("Candidate with id :" + entity.CandidateID + " does not exist.");
            }
            await _dbContext.Votes.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _dbContext.Votes.FirstOrDefaultAsync(c => c.VoteID == id);
            if (result == null)
            {
                throw new Exception("result does not exist.");
            }
            _dbContext.Votes.Remove(result);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _dbContext.Votes.AnyAsync(c => c.VoteID == id);
        }

        public async Task<IEnumerable<Votes>> GetAllAsync()
        {
            return await _dbContext.Votes.ToListAsync();
        }

        public async Task<IEnumerable<Votes>> GetByCandidateIdAsync(int candidateId)
        {
            return await _dbContext.Votes.Where(c => c.CandidateID == candidateId).ToListAsync();
        }

        public async Task<IEnumerable<Votes>> GetByElectionIdAsync(int electionId)
        {
            return await _dbContext.Votes.Where(c => c.ElectionID == electionId).ToListAsync();
        }

        public async Task<Votes> GetByIdAsync(int id)
        {
            var vote = await _dbContext.Votes.FirstOrDefaultAsync(c => c.VoteID == id);
            if (vote == null)
            {
                throw new Exception("vote does not exist.");
            }
            return vote;
        }

        public async Task<IEnumerable<Votes>> GetByUserIdAsync(int userId)
        {
            return await _dbContext.Votes.Where(c => c.UserID == userId).ToListAsync();
        }

        public async Task<IEnumerable<Votes>> GetByVoteDateAsync(DateTime date)
        {
            return await _dbContext.Votes.Where(c => c.VoteDate == date).ToListAsync();
        }

        public async Task UpdateAsync(Votes entity)
        {
            var result = await _dbContext.Votes.FirstOrDefaultAsync(c => c.VoteID == entity.VoteID);
            if (result == null)
            {
                throw new Exception("Vote does not exist.");
            }
            _dbContext.Votes.Update(result);
            await _dbContext.SaveChangesAsync();
        }
    }
}
