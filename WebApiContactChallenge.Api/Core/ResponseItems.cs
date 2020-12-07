using System.Collections.Generic;

namespace WebApiContactChallenge.Api.Core
{
    public class ResponseItems<T> : ResponseBase, IResponseItems<T>
    {
        public IEnumerable<T> Items { get; set; }
    }
}