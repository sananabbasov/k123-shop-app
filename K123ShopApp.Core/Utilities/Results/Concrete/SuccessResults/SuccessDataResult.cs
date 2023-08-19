using System;
namespace K123ShopApp.Core.Utilities.Results.Concrete.SuccessResults
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T data) : base(data, true)
        {
        }

        public SuccessDataResult(T data, string message) : base(data, true, message)
        {
        }

    }
}

