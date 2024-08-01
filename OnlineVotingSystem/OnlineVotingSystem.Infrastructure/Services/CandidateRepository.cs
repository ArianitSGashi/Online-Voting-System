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
    public class CandidateRepository : ICandidateRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public CandidateRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Candidates entity)
        {
            var exists = _dbContext.Candidates.Any(c => c.CandidateID == entity.CandidateID);
            var existsElectronic = _dbContext.Elections.Any(c => c.ElectionID == entity.ElectionID);
            if (exists)
            {
                throw new Exception("This candidate already exists");
            }
            else if (!existsElectronic)
            {
                throw new Exception("Election with id :" + entity.ElectionID + " does not exist.");
            }
         

            await _dbContext.Candidates.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var candidate = await _dbContext.Candidates.FirstOrDefaultAsync(c => c.CandidateID == id);
            if (candidate == null)
            {
                throw new Exception("candidate does not exist");
            }
            _dbContext.Candidates.Remove(candidate);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _dbContext.Candidates.AnyAsync(c => c.CandidateID == id);
        }

        public async Task<IEnumerable<Candidates>> GetAllAsync()
        {
            return await _dbContext.Candidates.ToListAsync();
        }

        public async Task<IEnumerable<Candidates>> GetByElectionIdAsync(int electionId)
        {
            return await _dbContext.Candidates.Where(x => x.ElectionID == electionId).ToListAsync();
        }

        public async Task<Candidates> GetByIdAsync(int id)
        {
            var candidate = await _dbContext.Candidates.FirstOrDefaultAsync(c => c.CandidateID == id);
            if (candidate == null)
            {
                throw new Exception("candidate does not exist");
            }
            return candidate;
        }

        public async Task<IEnumerable<Candidates>> GetByMinIncomeAsync(decimal minIncome)
        {
            return await _dbContext.Candidates.Where(x => x.Income >= minIncome).ToListAsync();
        }

        public async Task<IEnumerable<Candidates>> GetByNameAsync(string name)
        {
            return await _dbContext.Candidates.Where(x => x.FullName == name).ToListAsync();
        }

        public async Task<IEnumerable<Candidates>> GetByPartyAsync(string party)
        {
            return await _dbContext.Candidates.Where(x => x.Party == party).ToListAsync();
        }

        public async Task UpdateAsync(Candidates entity)
        {
            var candidate = await _dbContext.Candidates.FirstOrDefaultAsync(c => c.CandidateID == entity.CandidateID);
            if (candidate == null)
            {
                throw new Exception("candidate does not exist");
            }
            _dbContext.Candidates.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
