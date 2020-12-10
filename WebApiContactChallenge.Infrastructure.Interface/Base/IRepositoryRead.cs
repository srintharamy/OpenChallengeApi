using System.Collections.Generic;
using WebApiContactChallenge.BusinessObject.Base;

namespace WebApiContactChallenge.Infrastructure.Interface.Base
{
    public interface IRepositoryRead<T> where T : IBusinessObjectBase
    {
        IEnumerable<T> GetAll();
        T Get(string key);
    }
}