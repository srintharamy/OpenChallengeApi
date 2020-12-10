using System.Collections.Generic;
using WebApiContactChallenge.BusinessObject.BusinessObjects;
using WebApiContactChallenge.BusinessObject.Interface;
using WebApiContactChallenge.Infrastructure.Interface.Base;

namespace WebApiContactChallenge.Infrastructure.Interface.Repository
{
    public interface IContactSkillsRepository : IRepository<ContactSkill>
    {
        IEnumerable<IContactSkill> GetByContact(string contactKey);
        IEnumerable<IContactSkill> GetByContacts(IEnumerable<string> contactKeys);
    }
}