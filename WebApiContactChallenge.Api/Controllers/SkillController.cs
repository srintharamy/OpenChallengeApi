using Microsoft.AspNetCore.Mvc;
using WebApiContactChallenge.Api.Controllers.Base;
using WebApiContactChallenge.Api.Core;
using WebApiContactChallenge.Application.Interface;
using WebApiContactChallenge.BusinessObject.BusinessObjects;
using WebApiContactChallenge.BusinessObject.Interface;

namespace WebApISkillChallenge.Api.Controllers
{
    [Route("api/SkillController/")]
    [ApiController]
    public class SkillController : ChallengeControllerBase<Skill>
    {
        public SkillController(ISkillService skillService)
        {
            _service = skillService; // inject by ioc
        }

        /// <summary>
        ///     Retrieve all Skill
        /// </summary>
        /// <remarks>Retrieve all Skill from database</remarks>
        [HttpGet]
        [Route("GetAllSkill")]
        public IResponseItems<ISkill> GetAllSkill()
        {
            return CreateResponseItems<ISkill>(() => _service.GetAll());
        }

        /// <summary>
        ///     Get skill by key
        /// </summary>
        /// <remarks>Get skill by key </remarks>
        [HttpGet]
        [Route("GetSkill")]
        public IResponseItem<ISkill> GetSkill([FromQuery] string key)
        {
            return CreateResponseItem<ISkill>(() => _service.GetByKey(key));
        }

        /// <summary>
        ///     Delete skill by key
        /// </summary>
        /// <remarks>Delete skill by key  </remarks>
        [HttpDelete]
        [Route("Delete")]
        public IResponseItem<bool> Delete([FromQuery] string key)
        {
            return CreateResponse(
                () => new ResponseItem<bool>
                {
                    Item = _service.Delete(_service.GetByKey(key))
                }
            );
        }

        /// <summary>
        ///     Insert new Skill
        /// </summary>
        /// <remarks>See json sample description for the model</remarks>
        [HttpPut]
        [Route("Insert")]
        [ValidateModel]
        public IResponseItem<ISkill> Insert([FromBody] Skill skill)
        {
            return CreateResponseItem<ISkill>(() => _service.Insert(skill));
        }

        /// <summary>
        ///     Update Skill
        /// </summary>
        /// <remarks>See json sample description for the model</remarks>
        [HttpPost]
        [Route("Update")]
        [ValidateModel]
        public IResponseItem<ISkill> Update([FromBody] Skill skill)
        {
            return CreateResponseItem<ISkill>(() => _service.Update(skill));
        }
    }
}