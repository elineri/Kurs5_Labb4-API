using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb4_API.Services
{
    public interface IInterest<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetSingle(int id);
        Task<T> Add(T newEntity);
        Task<T> Update(T entity);
        Task<T> Delete(int id);
        Task<IEnumerable<T>> InterestsPerPerson(int id);
        Task<IEnumerable<T>> WebsitesPerPerson(int id);

        Task<T> AddPersonInterest(T newEntity, int id);
        Task<T> AddPersonWebsite(T newEntity, int personId, int interestId);
    }
}
