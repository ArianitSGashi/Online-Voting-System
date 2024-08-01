using Microsoft.EntityFrameworkCore;
using OnlineVotingSystem.Domain.Entities;
using OnlineVotingSystem.Domain.Interfaces;
using OnlineVotingSystem.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OnlineVotingSystem.Infrastructure.Services
{
    public class ResultRepository : IResultRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public ResultRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Result entity)
        {
            var exists = _dbContext.Results.Any(c => c.ResultID == entity.ResultID);
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
            await _dbContext.Results.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _dbContext.Results.FirstOrDefaultAsync(c => c.ResultID == id);
            if (result == null)
            {
                throw new Exception("result does not exist.");
            }
            _dbContext.Results.Remove(result);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _dbContext.Results.AnyAsync(c => c.ResultID == id);
        }

        public async Task<IEnumerable<Result>> GetAllAsync()
        {
            return await _dbContext.Results.ToListAsync();
        }

        public async Task<IEnumerable<Result>> GetByCandidateIdAsync(int candidateId)
        {
            return await _dbContext.Results.Where(c => c.CandidateID == candidateId).ToListAsync();
        }

        public async Task<IEnumerable<Result>> GetByElectionIdAsync(int electionId)
        {
            return await _dbContext.Results.Where(c => c.ElectionID == electionId).ToListAsync();
        }

        public async Task<Result> GetByIdAsync(int id)
        {
            var result = await _dbContext.Results.FirstOrDefaultAsync(c => c.ResultID == id);
            if (result == null)
            {
                throw new Exception("result does not exist.");
            }
            return result;
        }

        public async Task<IEnumerable<Result>> GetByTotalVotesGreaterThanAsync(int votes)
        {
            return await _dbContext.Results.Where(c => c.TotalVotes > votes).ToListAsync();
        }

        public async Task UpdateAsync(Result entity)
        {
            var result = await _dbContext.Results.FirstOrDefaultAsync(c => c.ResultID == entity.ResultID);
            if (result == null)
            {
                throw new Exception("result does not exist.");
            }
            _dbContext.Results.Update(result);
            await _dbContext.SaveChangesAsync();
        }
    }
}
