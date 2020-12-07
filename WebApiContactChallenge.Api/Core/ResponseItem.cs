namespace WebApiContactChallenge.Api.Core
{
    public class ResponseItem<T> : ResponseBase, IResponseItem<T>
    {
        public T Item { get; set; }
    }
}