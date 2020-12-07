using System;

namespace WebApiContactChallenge.Infrastructure.Interface.Base
{
    public interface IUowFactory : IDisposable
    {
        // TODO
        //User User { get; set; }

        IUnitOfWork Create(bool useTransactionScope = false);
    }
}