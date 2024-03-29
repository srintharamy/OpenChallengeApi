﻿using System;

namespace WebApiContactChallenge.BusinessObject.Base
{
    public interface IBusinessObjectBase
    {
        DateTime CreatedDate { get; set; }
        string CreatedBy { get; set; }
        DateTime? UpdatedDate { get; set; }
        string UpdatedBy { get; set; }
    }
}