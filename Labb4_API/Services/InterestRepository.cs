using Labb4_API.Model;
using Labb4_Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb4_API.Services
{
    public class InterestRepository : IInterest<Interest>
    {
        private InterestDbContext _interestContext;
        public InterestRepository(InterestDbContext interestDbContext)
        {
            _interestContext = interestDbContext;
        }
        public async Task<Interest> Add(Interest newEntity)
        {
            var result = await _interestContext.Interests.AddAsync(newEntity);
            await _interestContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Interest> Delete(int id)
        {
            var result = await _interestContext.Interests.FirstOrDefaultAsync(p => p.InterestId == id);
            if (result != null)
            {
                _interestContext.Interests.Remove(result);
                await _interestContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<Interest>> GetAll()
        {
            return await _interestContext.Interests.ToListAsync();
        }

        public async Task<Interest> GetSingle(int id)
        {
            return await _interestContext.Interests.FirstOrDefaultAsync(p => p.InterestId == id);
        }

        public async Task<Interest> Update(Interest entity)
        {
            var result = await _interestContext.Interests.FirstOrDefaultAsync(p => p.InterestId == entity.InterestId);
            if (result != null)
            {
                result.InterestName = entity.InterestName;
                result.Description = entity.InterestName;

                await _interestContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
