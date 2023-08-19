using System;
namespace K123ShopApp.Core.Utilities.Results.Abstract
{
    public interface IDataResult<T> : IResult
    {
        public T Data { get; set; }
    }
}

