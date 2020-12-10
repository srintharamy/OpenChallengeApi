using System;
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
            throw new NotImplementedException();
        }

        public IEnumerable<T> Insert(IEnumerable<T> objListToInsert)
        {
            throw new NotImplementedException();
        }

        public T Insert(T objToInsert)
        {
            throw new NotImplementedException();
        }

        public T Update(T objToUpdate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Update(IEnumerable<T> objListToUpdate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T Get(string key)
        {
            throw new NotImplementedException();
        }
    }
}