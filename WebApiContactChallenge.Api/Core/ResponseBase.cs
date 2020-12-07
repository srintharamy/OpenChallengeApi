namespace WebApiContactChallenge.Api.Core
{
    public class ResponseBase : IResponseBase
    {
        public string RespMessage { get; set; }

        public eResponseStatus RespStatus { get; set; }
    }
}