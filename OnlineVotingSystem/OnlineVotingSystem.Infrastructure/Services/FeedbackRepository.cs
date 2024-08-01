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
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public FeedbackRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Feedback entity)
        {
            var exists = _dbContext.Feedbacks.Any(c => c.FeedbackID == entity.FeedbackID);
            var existsElectronic = _dbContext.Elections.Any(c => c.ElectionID == entity.ElectionID);
            if (exists)
            {
                throw new Exception("This feedback already exists");
            }
            else if (!existsElectronic)
            {
                throw new Exception("Election with id :" + entity.ElectionID + " does not exist.");
            }
            await _dbContext.Feedbacks.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var campaign = await _dbContext.Feedbacks.FirstOrDefaultAsync(c => c.FeedbackID == id);
            if (campaign == null)
            {
                throw new Exception("feedback does not exist.");
            }
            _dbContext.Feedbacks.Remove(campaign);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _dbContext.Feedbacks.AnyAsync(c => c.FeedbackID == id);
        }

        public async Task<IEnumerable<Feedback>> GetAllAsync()
        {
            return await _dbContext.Feedbacks.ToListAsync();
        }

        public async Task<IEnumerable<Feedback>> GetByElectionIdAsync(int electionId)
        {
           return await _dbContext.Feedbacks.Where(c => c.ElectionID == electionId).ToListAsync();
        }

        public async Task<IEnumerable<Feedback>> GetByFeedbackDateAsync(DateTime date)
        {
            return await _dbContext.Feedbacks.Where(c => c.FeedbackDate == date).ToListAsync();
        }

        public async Task<Feedback> GetByIdAsync(int id)
        {
            var feedback = await _dbContext.Feedbacks.FirstOrDefaultAsync(c => c.FeedbackID == id);
            if (feedback == null)
            {
                throw new Exception("feedback does not exist.");
            }
            return feedback;
        }

        public async Task<IEnumerable<Feedback>> GetByUserIdAsync(string userId)
        {
            return await _dbContext.Feedbacks.Where(c => c.UserID == userId).ToListAsync();
        }

        public async Task UpdateAsync(Feedback entity)
        {
            var feedback = await _dbContext.Feedbacks.FirstOrDefaultAsync(c => c.FeedbackID == entity.FeedbackID);
            if (feedback == null)
            {
                throw new Exception("feedback does not exist.");
            }
            _dbContext.Feedbacks.Update(feedback);
            await _dbContext.SaveChangesAsync();
        }
    }
}
