using System;

namespace FunctionalCSharp
{
    public class Result<TSuccess, TFailure>
    {
        private Result(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }

        public TFailure FailureValue { get; private set; }

        public bool IsSuccess { get; }

        public TSuccess SuccessValue { get; private set; }

        public static Result<TSuccess, TFailure> FailWith(TFailure value)
        {
            return new Result<TSuccess, TFailure>(false) {FailureValue = value};
        }

        public static Result<TSuccess, TFailure> SucceedWith(TSuccess value)
        {
            return new Result<TSuccess, TFailure>(true) {SuccessValue = value};
        }

        public Result<TSuccess, TFailure> Bind(Func<TSuccess, Result<TSuccess, TFailure>> fn)
        {
            return IsSuccess ? fn(SuccessValue) : this;
        }
    }
}