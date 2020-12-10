using System;
using System.Collections.Generic;
using WebApiContactChallenge.Application.Base;
using WebApiContactChallenge.Application.Interface;
using WebApiContactChallenge.BusinessObject.BusinessObjects;
using WebApiContactChallenge.Infrastructure.Interface.Base;

namespace WebApiContactChallenge.Application
{
    public class ContactSkillService : ChallengeServiceBase<ContactSkill>, IContactSkillsService
    {
        public ContactSkillService(IUowFactory uowFactory) : base(uowFactory)
        {
        }

        public override IEnumerable<ContactSkill> GetAll()
        {
            // don't use
            throw new NotImplementedException();
        }

        public override ContactSkill GetByKey(string key)
        {
            // don't use
            throw new NotImplementedException();
        }

        public override bool Delete(ContactSkill toDelete)
        {
            return ExecuteWithTransaction(uow => uow.ContactSkillsRepository.Delete(toDelete));
        }

        public override ContactSkill Insert(ContactSkill toInsert)
        {
            return ExecuteWithTransaction(uow => uow.ContactSkillsRepository.Insert(toInsert));
        }

        public override ContactSkill Update(ContactSkill toUpdate)
        {
            return ExecuteWithTransaction(uow => uow.ContactSkillsRepository.Update(toUpdate));
        }
    }
}