namespace WebApiContactChallenge.BusinessObject.Base
{
    public interface IBusinessObjectBaseKey : IBusinessObjectBase
    {
        string Key { get; set; }
    }
}