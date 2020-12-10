using WebApiContactChallenge.BusinessObject.Base;

namespace WebApiContactChallenge.BusinessObject.Interface
{
    public interface IContactSkill : IBusinessObjectBase
    {
        string ContactKey { get; set; }
        string SkillKey { get; set; }
        int Level { get; set; }
    }
}