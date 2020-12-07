using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiContactChallenge.BusinessObject.Base
{
    public interface IBusinessObjectBase
    {
        string Key { get; set; }
        DateTime CreatedDate { get; set; }
        string CreatedBy { get; set; }
        DateTime? UpdatedDate { get; set; }
        string UpdatedBy { get; set; }
    }
}