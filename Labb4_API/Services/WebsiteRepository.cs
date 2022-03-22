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
        private readonly InterestDbContext _interestContext;
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

        public Task<IEnumerable<Website>> InterestsPerPerson(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Website>> WebsitesPerPerson(int personId)
        {
            var personResult = await (from pil in _interestContext.PersonInterestLinks
                                      join w in _interestContext.Websites on pil.WebsiteId equals w.WebsiteId
                                      join p in _interestContext.Persons on pil.PersonId equals p.PersonId
                                      where pil.PersonId == personId
                                      select w).Distinct().ToListAsync();

            if (personResult != null)
            {
                return personResult;
            }

            return null;
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

        public Task<Website> AddPersonInterest(Website newEntity, int id)
        {
            throw new NotImplementedException();
        }
    }
}
