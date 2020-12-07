namespace WebApiContactChallenge.Api.Core
{
    public interface IResponseItem<T> : IResponseBase
    {
        T Item { get; set; }
    }
}