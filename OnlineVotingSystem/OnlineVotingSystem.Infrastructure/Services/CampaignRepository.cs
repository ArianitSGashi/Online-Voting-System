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
    public class CampaignRepository : ICampaignRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public CampaignRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(Campaign entity)
        {
            var exists = _dbContext.Campaigns.Any(c => c.CampaignID == entity.CampaignID);
            var existsElectronic = _dbContext.Elections.Any(c => c.ElectionID== entity.ElectionID);
            var existsCandidate = _dbContext.Candidates.Any(c => c.CandidateID== entity.CandidateID);
            if (exists)
            {
                throw new Exception("This campain already exists");
            }
            else if (!existsElectronic)
            {
                throw new Exception("Election with id :" + entity.ElectionID + " does not exist.");
            }
            else if (!existsCandidate)
            {
                throw new Exception("Candidate with id :" + entity.CandidateID + " does not exist.");
            }

            await _dbContext.Campaigns.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var campaign = await _dbContext.Campaigns.FirstOrDefaultAsync(c => c.CampaignID == id);
            if (campaign == null)
            {
                throw new Exception("campain does not exist");
            }
            _dbContext.Campaigns.Remove(campaign);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
           return await _dbContext.Campaigns.AnyAsync(c => c.CampaignID == id);
        }

        public async Task<IEnumerable<Campaign>> GetActiveCampaignsAsync()
        {
          return await _dbContext.Campaigns.Where(x=> x.EndDate> DateTime.UtcNow && x.StartDate <= DateTime.UtcNow).ToListAsync();
        }

        public async Task<IEnumerable<Campaign>> GetAllAsync()
        {
            return await _dbContext.Campaigns.ToListAsync();
        }

        public async Task<IEnumerable<Campaign>> GetByCandidateIdAsync(int candidateId)
        {
            return await _dbContext.Campaigns.Where(x => x.CandidateID == candidateId).ToListAsync();
        }

        public async Task<IEnumerable<Campaign>> GetByElectionIdAsync(int electionId)
        {
            return await _dbContext.Campaigns.Where(x => x.ElectionID == electionId).ToListAsync();
        }

        public async Task<Campaign> GetByIdAsync(int id)
        {
            var campaign = await _dbContext.Campaigns.FirstOrDefaultAsync(c => c.CampaignID == id);
            if (campaign == null)
            {
                throw new Exception("campain does not exist");
            }
            return campaign;
        }

        public async Task UpdateAsync(Campaign entity)
        {
            var campaign = await _dbContext.Campaigns.FirstOrDefaultAsync(c => c.CampaignID == entity.CampaignID);
            if (campaign == null)
            {
                throw new Exception("campain does not exist");
            }
            _dbContext.Campaigns.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
