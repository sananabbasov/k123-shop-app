using System;
using K123ShopApp.Core.Utilities.Results.Abstract;

namespace K123ShopApp.Core.Utilities.Results.Concrete
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T data, bool success) : base(success)
        {
            Data = data;
        }

        public DataResult(T data, bool success, string message) : base(success, message)
        {
            Data = data;
        }
        public T Data { get; set; }
    }
}

