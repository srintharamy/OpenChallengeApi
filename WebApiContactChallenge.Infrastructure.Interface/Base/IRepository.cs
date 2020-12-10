using System.Collections.Generic;
using WebApiContactChallenge.BusinessObject.Base;

namespace WebApiContactChallenge.Infrastructure.Interface.Base
{
    public interface IRepository<T> : IRepositoryRead<T>
        where T : IBusinessObjectBase
    {
        IEnumerable<T> Insert(IEnumerable<T> objListToInsert);
        T Insert(T objToInsert);
        T Update(T objToUpdate);
        IEnumerable<T> Update(IEnumerable<T> objListToUpdate);
        bool Delete(T objToDelete);
    }
}