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
    public class ElectionRepository : IElectionRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public ElectionRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Elections entity)
        {
            var exists = _dbContext.Elections.Any(c => c.ElectionID == entity.ElectionID);
            if (exists)
            {
                throw new Exception("This election already exists");
            }
            else if (entity.StartDate >= entity.EndDate)
            {
                throw new Exception("End Date should be greater than Start Date.");
            }

            await _dbContext.Elections.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var election = await _dbContext.Elections.FirstOrDefaultAsync(c => c.ElectionID == id);
            if (election == null)
            {
                throw new Exception("election does not exist.");
            }
            _dbContext.Elections.Remove(election);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _dbContext.Elections.AnyAsync(c => c.ElectionID == id);
        }

        public async Task<IEnumerable<Elections>> GetActiveElectionsAsync()
        {
            return await _dbContext.Elections.Where(x => x.StartDate > DateTime.UtcNow && x.StartDate <= DateTime.UtcNow).ToListAsync();
        }

        public async Task<IEnumerable<Elections>> GetAllAsync()
        {
            return await _dbContext.Elections.ToListAsync();
        }

        public async Task<Elections> GetByIdAsync(int id)
        {
            var election = await _dbContext.Elections.FirstOrDefaultAsync(c => c.ElectionID == id);
            if (election == null)
            {
                throw new Exception("election does not exist.");
            }
            return election;
        }

        public async Task<IEnumerable<Elections>> GetByTitleAsync(string title)
        {
            return await _dbContext.Elections.Where(x => x.Title == title).ToListAsync();
        }

        public async Task<IEnumerable<Elections>> GetUpcomingElectionsAsync(DateTime date)
        {
            return await _dbContext.Elections.Where(x => x.StartDate > date).ToListAsync();
        }

        public async Task UpdateAsync(Elections entity)
        {
            var election = await _dbContext.Elections.FirstOrDefaultAsync(c => c.ElectionID == entity.ElectionID);
            if (election == null)
            {
                throw new Exception("election does not exist.");
            }
            _dbContext.Elections.Update(election);
            await _dbContext.SaveChangesAsync();
        }
    }
}
