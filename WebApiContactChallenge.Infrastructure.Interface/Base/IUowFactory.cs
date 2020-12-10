using System;
using WebApiContactChallenge.BusinessObject.BusinessObjects;

namespace WebApiContactChallenge.Infrastructure.Interface.Base
{
    public interface IUowFactory : IDisposable
    {
        User User { get; set; }

        IUnitOfWork Create(bool useTransactionScope = false);
    }
}