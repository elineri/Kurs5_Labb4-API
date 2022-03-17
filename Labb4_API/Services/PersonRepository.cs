using Labb4_API.Model;
using Labb4_Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb4_API.Services
{
    public class PersonRepository : IInterestRepository<Person>
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

        public Task<IEnumerable<Person>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Person> GetSingle(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Person> Update(Person entity)
        {
            throw new NotImplementedException();
        }
    }
}
