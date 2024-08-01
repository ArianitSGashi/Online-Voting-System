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
    public class ComplaintRepository : IComplaintRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public ComplaintRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Complaints entity)
        {
            var exists = _dbContext.Complaints.Any(c => c.ComplaintID == entity.ComplaintID);
            var existsElectronic = _dbContext.Elections.Any(c => c.ElectionID == entity.ElectionID);
            if (exists)
            {
                throw new Exception("This complaint already exists");
            }
            else if (!existsElectronic)
            {
                throw new Exception("Election with id :" + entity.ElectionID + " does not exist.");
            }


            await _dbContext.Complaints.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var campaign = await _dbContext.Complaints.FirstOrDefaultAsync(c => c.ComplaintID == id);
            if (campaign == null)
            {
                throw new Exception("complaint does not exist");
            }
            _dbContext.Complaints.Remove(campaign);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _dbContext.Complaints.AnyAsync(c => c.ComplaintID == id);
        }

        public async Task<IEnumerable<Complaints>> GetAllAsync()
        {
            return await _dbContext.Complaints.ToListAsync();
        }

        public async Task<IEnumerable<Complaints>> GetByComplaintDateAsync(DateTime date)
        {
            return await _dbContext.Complaints.Where(x=> x.ComplaintDate == date).ToListAsync();
        }

        public async Task<IEnumerable<Complaints>> GetByElectionIdAsync(int electionId)
        {
            return await _dbContext.Complaints.Where(x => x.ElectionID == electionId).ToListAsync();
        }

        public async Task<Complaints> GetByIdAsync(int id)
        {
            var complaint = await _dbContext.Complaints.FirstOrDefaultAsync(c => c.ComplaintID == id);
            if (complaint == null)
            {
                throw new Exception("complaint does not exist");
            }
            return complaint;
        }

        public async Task<IEnumerable<Complaints>> GetByUserIdAsync(int userId)
        {
            return await _dbContext.Complaints.Where(x => x.UserID == userId).ToListAsync();
        }

        public async Task UpdateAsync(Complaints entity)
        {
            var complaint = await _dbContext.Complaints.FirstOrDefaultAsync(c => c.ComplaintID == entity.ComplaintID);
            if (complaint == null)
            {
                throw new Exception("complaint does not exist");
            }
            _dbContext.Complaints.Update(complaint);
            await _dbContext.SaveChangesAsync();
        }
    }
}
