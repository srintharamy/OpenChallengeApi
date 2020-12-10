using System;
using WebApiContactChallenge.BusinessObject.BusinessObjects;
using WebApiContactChallenge.Infrastructure.Interface.Base;

namespace WebApiContactChallenge.Infrastructure.DapperSql.Base
{
    public class UowFactory : IUowFactory
    {
        public UowFactory(User user)
        {
            User = user;
        }

        public UowFactory()
        {
        }

        public User User { get; set; }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IUnitOfWork Create(bool useTransactionScope = false)
        {
            return new UnitOfWork(User);
        }
    }
}