using WebApiContactChallenge.BusinessObject.Base;

namespace WebApiContactChallenge.BusinessObject.Interface
{
    public interface ISkill : IBusinessObjectBaseKey
    {
        string Description { get; set; }
    }
}