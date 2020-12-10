using System;
using System.Collections.Generic;
using WebApiContactChallenge.Application.Interface.Base;
using WebApiContactChallenge.BusinessObject.Base;
using WebApiContactChallenge.BusinessObject.BusinessObjects;
using WebApiContactChallenge.Infrastructure.Interface.Base;

namespace WebApiContactChallenge.Application.Base
{
    public class ChallengeServiceBase<T> : IChallengeServiceBase<T>
        where T : IBusinessObjectBase
    {
        public ChallengeServiceBase(IUowFactory uowFactory)
        {
            UowFactory = uowFactory;
        }

        public IUowFactory UowFactory { get; set; }

        public string UserConnected
        {
            get => UowFactory?.User?.Key;
            set => UowFactory.User = new User { Key = value };
        }

        public virtual IEnumerable<T> GetAll()
        {
            return null;
        }

        public virtual T GetByKey(string key)
        {
            return default;
        }

        public virtual bool Delete(T toDelete)
        {
            return false;
        }

        public virtual T Insert(T toInsert)
        {
            return default;
        }

        public virtual T Update(T toUpdate)
        {
            return default;
        }

        public TResult Execute<TResult>(Func<IUnitOfWork, TResult> func)
        {
            using (var uow = UowFactory.Create())
            {
                return func(uow);
            }
        }

        public TResult ExecuteWithTransaction<TResult>(Func<IUnitOfWork, TResult> func)
        {
            TResult result;
            using (var uow = UowFactory.Create(true))
            {
                result = func(uow);
                uow.Complete();
            }

            return result;
        }
    }
}