using System;
using K123ShopApp.Core.Utilities.Results.Abstract;
using K123ShopApp.Core.Utilities.Results.Concrete.ErrorResults;
using K123ShopApp.Core.Utilities.Results.Concrete.SuccessResults;

namespace K123ShopApp.Core.Utilities.Business
{
    public class BusinessRule
    {
        public static IResult CheckRules(params IResult[] logic)
        {
            foreach (var method in logic)
            {
                if (!method.Success)
                {
                    return new ErrorResult();
                }
            }
            return new SuccessResult();
        }
    }
}

