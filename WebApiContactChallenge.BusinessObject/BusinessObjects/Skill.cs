using WebApiContactChallenge.BusinessObject.Base;
using WebApiContactChallenge.BusinessObject.Interface;

namespace WebApiContactChallenge.BusinessObject.BusinessObjects
{
    /// <summary>
    /// Skill class inherits from BusinessObjectBase
    /// The primary key inherits from BusinessObjectBase // Key corresponding to Name of the skill
    /// </summary>
    public abstract class Skill : BusinessObjectBase , ISkill
    {
        /// <summary>
        /// Level of the skill from 0(Basic) to 5 (Expert)
        /// </summary>
        public int Level { get; set; }
    }
}
