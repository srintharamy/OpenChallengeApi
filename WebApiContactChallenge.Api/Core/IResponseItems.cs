using System.Collections.Generic;

namespace WebApiContactChallenge.Api.Core
{
    public interface IResponseItems<T> : IResponseBase
    {
        IEnumerable<T> Items { get; set; }
    }
}