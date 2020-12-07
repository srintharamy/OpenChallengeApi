using System.Collections.Generic;
using WebApiContactChallenge.BusinessObject.BusinessObjects;

namespace WebApiContactChallenge.Application.Interface
{
    public interface IContactService
    {
        IEnumerable<Contact> GetAllContacts();
        Contact GetByKey(string key);
        bool DeleteContact(Contact toDelete);
        Contact InsertContact(Contact toInsert);
        Contact UpdateContact(Contact toUpdate);
    }
}