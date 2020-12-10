using System.ComponentModel.DataAnnotations;
using WebApiContactChallenge.BusinessObject.Base;
using WebApiContactChallenge.BusinessObject.Interface;

namespace WebApiContactChallenge.BusinessObject.BusinessObjects
{
    /// <summary>
    ///     Skill class inherits from BusinessObjectBase
    ///     The primary key inherits from BusinessObjectBase // Key corresponding to Name of the skill
    /// </summary>
    public class Skill : BusinessObjectBaseKey, ISkill
    {
        [Required] [MaxLength(100)] public override string Key { get; set; }

        [MaxLength(250)] public string Description { get; set; }
    }
}