using Microsoft.AspNetCore.Mvc;
using WebApiContactChallenge.Api.Controllers.Base;
using WebApiContactChallenge.Api.Core;
using WebApiContactChallenge.Application.Interface;
using WebApiContactChallenge.BusinessObject.BusinessObjects;
using WebApiContactChallenge.BusinessObject.Interface;

namespace WebApiContactChallenge.Api.Controllers
{
    [Route("api/ContactController/")]
    [ApiController]
    public class ContactController : ChallengeControllerBase<Contact>
    {
        public ContactController(IContactService contactService)
        {
            _service = contactService; // inject by ioc
        }

        /// <summary>
        ///     Retrieve all Contact
        /// </summary>
        /// <remarks>Retrieve all Contact from database</remarks>
        [HttpGet]
        [Route("GetAllContact")]
        public IResponseItems<IContact> GetAllContact()
        {
            var result = CreateResponseItems<IContact>(() => _service.GetAll());
            return result;
        }

        /// <summary>
        ///     Get contact by key
        /// </summary>
        /// <remarks>Get contact by key (key is the email, unique identifier)... </remarks>
        [HttpGet]
        [Route("GetContact")]
        public IResponseItem<IContact> GetContact([FromQuery] string key)
        {
            return CreateResponseItem<IContact>(() => _service.GetByKey(key));
        }

        /// <summary>
        ///     Delete contact by key
        /// </summary>
        /// <remarks>Delete contact by key (key is the email, unique identifier)... </remarks>
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
        ///     Insert new Contact
        /// </summary>
        /// <remarks>See json sample description for the model</remarks>
        [HttpPut]
        [Route("Insert")]
        [ValidateModel]
        public IResponseItem<IContact> Insert([FromBody] Contact contact)
        {
            return CreateResponseItem<IContact>(() => _service.Insert(contact));
        }

        /// <summary>
        ///     Update Contact
        /// </summary>
        /// <remarks>See json sample description for the model</remarks>
        [HttpPost]
        [Route("Update")]
        [ValidateModel]
        public IResponseItem<IContact> Update([FromBody] Contact contact)
        {
            return CreateResponseItem<IContact>(() => _service.Update(contact));
        }
    }
}