using System.Collections.Generic;
using System.Linq;
using WebApiContactChallenge.Application.Base;
using WebApiContactChallenge.Application.Interface;
using WebApiContactChallenge.BusinessObject.BusinessObjects;
using WebApiContactChallenge.Infrastructure.Interface.Base;

namespace WebApiContactChallenge.Application
{
    public class ContactService : ChallengeServiceBase<Contact>, IContactService
    {
        public ContactService(IUowFactory uowFactory) : base(uowFactory)
        {
        }

        public override IEnumerable<Contact> GetAll()
        {
            return Execute(uow =>
            {
                var results = uow.ContactRepository.GetAll();

                if (results != null && results.Any())
                {
                    //TODO : Manage agregates in Dapper base class repo
                    var skillsAll = uow.ContactSkillsRepository.GetByContacts(results.Select(x => x.Key));
                    foreach (var contact in results)
                    {
                        contact.MySkills = skillsAll.Where(x => x.ContactKey == contact.Key);
                    }
                }


                return results;
            });
        }

        public override Contact GetByKey(string key)
        {
            return Execute(uow =>
                {
                    var result = uow.ContactRepository.Get(key);
                    if (result != null)
                    {
                        result.MySkills = uow.ContactSkillsRepository.GetByContact(key).ToList(); //TODO Manage aggregate in Repository
                    }

                    return result;
                }
            );
        }

        public override bool Delete(Contact toDelete)
        {
            return ExecuteWithTransaction(uow => uow.ContactRepository.Delete(toDelete));
        }

        public override Contact Insert(Contact toInsert)
        {
            return ExecuteWithTransaction(uow => uow.ContactRepository.Insert(toInsert));
        }

        public override Contact Update(Contact toUpdate)
        {
            return ExecuteWithTransaction(uow => uow.ContactRepository.Update(toUpdate));
        }
    }
}