using WebApiContactChallenge.BusinessObject.BusinessObjects;
using WebApiContactChallenge.Infrastructure.Interface.Base;

namespace WebApiContactChallenge.Infrastructure.DapperSql.Base
{
    public class UowFactory: IUowFactory
    {
        public User User { get; set; }
        public UowFactory(User user)
        {
            User = user;
        }
        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public IUnitOfWork Create(bool useTransactionScope = false)
        {
            return new UnitOfWork(User);
        }
    }
}