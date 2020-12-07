using System;

namespace WebApiContactChallenge.BusinessObject.Base
{
    public abstract class BusinessObjectBase : IBusinessObjectBase
    {
        public abstract string Key { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
