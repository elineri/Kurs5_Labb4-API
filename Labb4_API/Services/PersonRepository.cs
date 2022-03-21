using Labb4_API.Model;
using Labb4_Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb4_API.Services
{
    public class PersonRepository : IInterest<Person>
    {
        private InterestDbContext _interestContext;
        public PersonRepository(InterestDbContext interestDbContext)
        {
            _interestContext = interestDbContext;
        }
        public async Task<Person> Add(Person newEntity)
        {
            var result = await _interestContext.Persons.AddAsync(newEntity);
            await _interestContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Person> Delete(int id)
        {
            var result = await _interestContext.Persons.FirstOrDefaultAsync(p => p.PersonId == id);
            if (result != null)
            {
                _interestContext.Persons.Remove(result);
                await _interestContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<Person>> GetAll()
        {
            return await _interestContext.Persons.ToListAsync();
        }

        public async Task<Person> GetSingle(int id)
        {
            return await _interestContext.Persons.FirstOrDefaultAsync(p => p.PersonId == id);
        }

        public Task<IEnumerable<Person>> InterestsPerPerson(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Person>> WebsitesPerPerson(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Person> Update(Person entity)
        {
            var result = await _interestContext.Persons.FirstOrDefaultAsync(p => p.PersonId == entity.PersonId);
            if (result != null)
            {
                result.FirstName = entity.FirstName;
                result.LastName = entity.LastName;
                result.PhoneNumber = entity.PhoneNumber;

                await _interestContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
