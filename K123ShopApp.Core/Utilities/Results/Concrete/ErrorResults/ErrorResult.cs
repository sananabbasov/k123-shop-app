using System;
namespace K123ShopApp.Core.Utilities.Results.Concrete.ErrorResults
{
    public class ErrorResult : Result
    {
        public ErrorResult() : base(false)
        {
        }

        public ErrorResult(string message) : base(false, message)
        {
        }
    }
}

