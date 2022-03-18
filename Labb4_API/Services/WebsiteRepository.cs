using Labb4_API.Model;
using Labb4_Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb4_API.Services
{
    public class WebsiteRepository : IInterest<Website>
    {
        private InterestDbContext _interestContext;
        public WebsiteRepository(InterestDbContext interestDbContext)
        {
            _interestContext = interestDbContext;
        }
        public async Task<Website> Add(Website newEntity)
        {
            var result = await _interestContext.Websites.AddAsync(newEntity);
            await _interestContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Website> Delete(int id)
        {
            var result = await _interestContext.Websites.FirstOrDefaultAsync(p => p.WebsiteId == id);
            if (result != null)
            {
                _interestContext.Websites.Remove(result);
                await _interestContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<Website>> GetAll()
        {
            return await _interestContext.Websites.ToListAsync();
        }

        public async Task<Website> GetSingle(int id)
        {
            return await _interestContext.Websites.FirstOrDefaultAsync(p => p.WebsiteId == id);
        }

        public async Task<Website> Update(Website entity)
        {
            var result = await _interestContext.Websites.FirstOrDefaultAsync(p => p.WebsiteId == entity.WebsiteId);
            if (result != null)
            {
                result.LinkDescription = entity.LinkDescription;
                result.Link = entity.Link;

                await _interestContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
