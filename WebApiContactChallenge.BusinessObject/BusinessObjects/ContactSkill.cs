using System.ComponentModel.DataAnnotations;
using WebApiContactChallenge.BusinessObject.Base;
using WebApiContactChallenge.BusinessObject.Interface;

namespace WebApiContactChallenge.BusinessObject.BusinessObjects
{
    public class ContactSkill : BusinessObjectBaseKey, IContactSkill
    {
        public override string Key { get; set; }
        [Required] [MaxLength(50)] public string ContactKey { get; set; }
        [Required] [MaxLength(100)] public string SkillKey { get; set; }
        [Required] [Range(0, 5)] public int Level { get; set; }
    }
}