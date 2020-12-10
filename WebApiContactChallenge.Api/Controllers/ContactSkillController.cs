using Microsoft.AspNetCore.Mvc;
using WebApiContactChallenge.Api.Controllers.Base;
using WebApiContactChallenge.Api.Core;
using WebApiContactChallenge.Application.Interface;
using WebApiContactChallenge.BusinessObject.BusinessObjects;
using WebApiContactChallenge.BusinessObject.Interface;
using WebApiContactChallenge.Common;

namespace WebApISkillChallenge.Api.Controllers
{
    [Route("api/ContactSkillController/")]
    [ApiController]
    public class ContactSkillController : ChallengeControllerBase<ContactSkill>
    {
        public ContactSkillController(IContactSkillsService contactSkillService)
        {
            _service = contactSkillService; // inject by ioc
        }

        /// <summary>
        ///     Insert Skill for a contact
        /// </summary>
        /// <remarks>See json sample description for the model</remarks>
        [HttpPut]
        [Route("Insert")]
        [ValidateModel]
        public IResponseItem<IContactSkill> Insert([FromBody] ContactSkill contactSkill)
        {
            CheckSpecialAuthUser(contactSkill);
            return CreateResponseItem<IContactSkill>(() => _service.Insert(contactSkill));
        }

        /// <summary>
        ///     Update Skill for a contact
        /// </summary>
        /// <remarks>See json sample description for the model</remarks>
        [HttpPost]
        [Route("Update")]
        [ValidateModel]
        public IResponseItem<IContactSkill> Update([FromBody] ContactSkill contactSkill)
        {
            CheckSpecialAuthUser(contactSkill);
            return CreateResponseItem<IContactSkill>(() => _service.Update(contactSkill));
        }

        /// <summary>
        ///     Update Skill for a contact
        /// </summary>
        /// <remarks>See json sample description for the model</remarks>
        [HttpDelete]
        [Route("Delete")]
        [ValidateModel]
        public IResponseItem<IContactSkill> Delete([FromBody] ContactSkill contactSkill)
        {
            CheckSpecialAuthUser(contactSkill);
            return CreateResponseItem<IContactSkill>(() => _service.Delete(contactSkill));
        }

        private void CheckSpecialAuthUser(ContactSkill contactSkill)
        {
            if (_service.UserConnected != contactSkill.Key)
            {
                throw new ChallengeFunctionnalException("You are not authorized to update skill for another contact than you ...");
            }
        }
    }
}