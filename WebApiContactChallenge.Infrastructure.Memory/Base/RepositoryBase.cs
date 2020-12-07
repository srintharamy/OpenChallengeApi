using System.Collections.Generic;
using WebApiContactChallenge.BusinessObject.Base;
using WebApiContactChallenge.Infrastructure.Interface.Base;

namespace WebApiContactChallenge.Infrastructure.Memory.Base
{
    public abstract class RepositoryBase<T> : IRepository<T>
        where T : class, IBusinessObjectBase
    {
        public bool Delete(T objToDelete)
        {
            throw new System.NotImplementedException();
        }

        public System.Collections.Generic.IEnumerable<T> Insert(System.Collections.Generic.IEnumerable<T> objListToInsert)
        {
            throw new System.NotImplementedException();
        }

        public T Insert(T objToInsert)
        {
            throw new System.NotImplementedException();
        }

        public T Update(T objToUpdate)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<T> Update(IEnumerable<T> objListToUpdate)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public T Get(string key)
        {
            throw new System.NotImplementedException();
        }
    }
}
