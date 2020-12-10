using System.Collections.Generic;
using WebApiContactChallenge.BusinessObject.Base;

namespace WebApiContactChallenge.Application.Interface.Base
{
    public interface IChallengeServiceBase<T> where T : IBusinessObjectBase
    {
        string UserConnected { get; set; }
        IEnumerable<T> GetAll();
        T GetByKey(string key);
        bool Delete(T toDelete);
        T Insert(T toInsert);
        T Update(T toUpdate);
    }
}