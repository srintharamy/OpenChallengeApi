using System.ComponentModel.DataAnnotations;
using WebApiContactChallenge.BusinessObject.Base;
using WebApiContactChallenge.BusinessObject.Interface;

namespace WebApiContactChallenge.BusinessObject.BusinessObjects
{
    /// <summary>
    /// Contact class inherits from BusinessObjectBase
    /// The primary key inherits from BusinessObjectBase // Key corresponding to email
    /// </summary>
    public class Contact : BusinessObjectBase, IContact
    {
        [Required]
        [MaxLength(50)]
        [EmailAddress]
        public override string Key { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        public string FullName => $"{LastName} {FirstName}";
        [Required]
        [MaxLength(150)]
        public string Address { get; set; }
        [Required]
        [MaxLength(10)]
        public string PoBox { get; set; }
        [Required]
        [MaxLength(50)]
        public string City { get; set; }
        [Required]
        [MaxLength(20)]
        public string Country { get; set; }
        [Required]
        [MaxLength(20)]
        [Phone]
        public string MobilePhoneNumber { get; set; }
    }
}