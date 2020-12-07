using System;
using WebApiContactChallenge.Application.Interface.Base;
using WebApiContactChallenge.Infrastructure.Interface.Base;

namespace WebApiContactChallenge.Application.Base
{
    public class ChallengeServiceBase : IChallengeServiceBase
    {
        public IUowFactory UowFactory { get; set; }

        public ChallengeServiceBase(IUowFactory uowFactory)
        {
            UowFactory = uowFactory;
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