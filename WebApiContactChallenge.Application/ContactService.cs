using System.Collections.Generic;
using WebApiContactChallenge.Application.Base;
using WebApiContactChallenge.Application.Interface;
using WebApiContactChallenge.BusinessObject.BusinessObjects;
using WebApiContactChallenge.Infrastructure.Interface.Base;

namespace WebApiContactChallenge.Application
{
    public class ContactService : ChallengeServiceBase, IContactService
    {
        public ContactService(IUowFactory uowFactory) : base(uowFactory)
        {
        }

        public IEnumerable<Contact> GetAllContacts()
        {
            return Execute(uow => uow.ContactRepository.GetAll());
        }

        public Contact GetByKey(string key)
        {
            return Execute(uow => uow.ContactRepository.Get(key));
        }

        public bool DeleteContact(Contact toDelete)
        {
            return ExecuteWithTransaction(uow => uow.ContactRepository.Delete(toDelete));
        }

        public Contact InsertContact(Contact toInsert)
        {
            return ExecuteWithTransaction(uow => uow.ContactRepository.Insert(toInsert));
        }

        public Contact UpdateContact(Contact toUpdate)
        {
            return ExecuteWithTransaction(uow => uow.ContactRepository.Update(toUpdate));
        }
    }
}