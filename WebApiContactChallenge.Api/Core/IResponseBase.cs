namespace WebApiContactChallenge.Api.Core
{
    public interface IResponseBase
    {
        string RespMessage { get; set; }

        eResponseStatus RespStatus { get; set; }
    }
}