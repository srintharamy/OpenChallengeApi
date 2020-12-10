using System.Collections.Generic;
using WebApiContactChallenge.BusinessObject.Base;

namespace WebApiContactChallenge.BusinessObject.Interface
{
    public interface IContact : IBusinessObjectBaseKey
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string FullName { get; }
        string Address { get; set; }
        string PoBox { get; set; }
        string Country { get; set; }
        string MobilePhoneNumber { get; set; }
        IEnumerable<IContactSkill> MySkills { get; set; }
    }
}