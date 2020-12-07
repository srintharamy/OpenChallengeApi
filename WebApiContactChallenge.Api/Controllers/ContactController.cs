using Microsoft.AspNetCore.Mvc;
using WebApiContactChallenge.Api.Controllers.Base;
using WebApiContactChallenge.Api.Core;
using WebApiContactChallenge.Application;
using WebApiContactChallenge.Application.Interface;
using WebApiContactChallenge.BusinessObject.BusinessObjects;
using WebApiContactChallenge.BusinessObject.Interface;
using WebApiContactChallenge.Infrastructure.DapperSql.Base;

namespace WebApiContactChallenge.Api.Controllers
{
    [Route("api/ContactController/")]
    [ApiController]
    public class ContactController : ChallengeControllerBase
    {
        //TODO Use IOC here
        private readonly IContactService _contactService = new ContactService(new UowFactory(new User { Key = "srintharamy@yahoo.fr" }));

        [HttpGet]
        [Route("GetAllContact")]
        public IResponseItems<IContact> GetAllContact()
        {
            return CreateResponseItems<IContact>(() => _contactService.GetAllContacts());
        }

        [HttpGet]
        [Route("GetContact")]
        public IResponseItem<IContact> GetContact([FromQuery] string key)
        {
            return CreateResponseItem<IContact>(() => _contactService.GetByKey(key));
        }

        [HttpDelete()]
        [Route("DeleteContact")]
        public IResponseItem<bool> Delete([FromQuery] string key)
        {
            return CreateResponse(
                () => new ResponseItem<bool>
                {
                    Item = _contactService.DeleteContact(_contactService.GetByKey(key))
                }
            );
        }

        [HttpPut]
        [Route("InsertContact")]
        [ValidateModel]
        public IResponseItem<IContact> Insert([FromBody] Contact contact)
        {
            return CreateResponseItem<IContact>(() => _contactService.InsertContact(contact));
        }

        [HttpPost]
        [Route("UpdateContact")]
        [ValidateModel]
        public IResponseItem<IContact> Update([FromBody] Contact contact)
        {
            return CreateResponseItem<IContact>(() => _contactService.UpdateContact(contact));
        }
    }
}