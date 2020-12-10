using System.Collections.Generic;
using WebApiContactChallenge.Application.Base;
using WebApiContactChallenge.Application.Interface;
using WebApiContactChallenge.BusinessObject.BusinessObjects;
using WebApiContactChallenge.Infrastructure.Interface.Base;

namespace WebApiContactChallenge.Application
{
    public class SkillService : ChallengeServiceBase<Skill>, ISkillService
    {
        public SkillService(IUowFactory uowFactory) : base(uowFactory)
        {
        }

        public override IEnumerable<Skill> GetAll()
        {
            return Execute(uow => uow.SkillRepository.GetAll());
        }

        public override Skill GetByKey(string key)
        {
            return Execute(uow => uow.SkillRepository.Get(key));
        }

        public override bool Delete(Skill toDelete)
        {
            return ExecuteWithTransaction(uow => uow.SkillRepository.Delete(toDelete));
        }

        public override Skill Insert(Skill toInsert)
        {
            return ExecuteWithTransaction(uow => uow.SkillRepository.Insert(toInsert));
        }

        public override Skill Update(Skill toUpdate)
        {
            return ExecuteWithTransaction(uow => uow.SkillRepository.Update(toUpdate));
        }
    }
}