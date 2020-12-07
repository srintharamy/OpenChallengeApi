using System;

namespace WebApiContactChallenge.Common
{
    public class ChallengeFunctionnalException : Exception
    {
        public ChallengeFunctionnalException(string message) : base(message)
        {
        }
    }
}