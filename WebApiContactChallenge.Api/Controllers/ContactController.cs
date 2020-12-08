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

        /// <summary>
        /// Retrieve all Contact
        /// </summary>
        /// <remarks>Retrieve all Contact from database</remarks>
        [HttpGet]
        [Route("GetAllContact")]
        public IResponseItems<IContact> GetAllContact()
        {
            return CreateResponseItems<IContact>(() => _contactService.GetAllContacts());
        }

        /// <summary>
        /// Get contact by key
        /// </summary>
        /// <remarks>Get contact by key (key is the email, unique identifier)... </remarks>
        [HttpGet]
        [Route("GetContact")]
        public IResponseItem<IContact> GetContact([FromQuery] string key)
        {
            return CreateResponseItem<IContact>(() => _contactService.GetByKey(key));
        }

        /// <summary>
        /// Delete contact by key
        /// </summary>
        /// <remarks>Delete contact by key (key is the email, unique identifier)... </remarks>
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

        /// <summary>
        /// Insert new Contact
        /// </summary>
        /// <remarks>See json sample description for the model</remarks>
        [HttpPut]
        [Route("InsertContact")]
        [ValidateModel]
        public IResponseItem<IContact> Insert([FromBody] Contact contact)
        {
            return CreateResponseItem<IContact>(() => _contactService.InsertContact(contact));
        }

        /// <summary>
        /// Update Contact
        /// </summary>
        /// <remarks>See json sample description for the model</remarks>
        [HttpPost]
        [Route("UpdateContact")]
        [ValidateModel]
        public IResponseItem<IContact> Update([FromBody] Contact contact)
        {
            return CreateResponseItem<IContact>(() => _contactService.UpdateContact(contact));
        }
    }
}