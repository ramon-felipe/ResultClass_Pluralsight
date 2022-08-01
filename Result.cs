using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestResult
{
    internal class Result
    {
        public bool IsSuccess { get; }
        public ResultError Error { get; private set; } = new ResultError();
        public bool IsFailure => !IsSuccess;

        protected Result(bool isSuccess, ResultError error)
        {

            if (isSuccess && error !=  null)
                throw new InvalidOperationException();

            if (!isSuccess && error == null)
                throw new InvalidOperationException();

            IsSuccess = isSuccess;
            Error = error;
        }

        public static Result Fail(ResultError error)
        {
            return new Result(false, error);
        }

        public static Result<T> Fail<T>(ResultError error)
        {
            return new Result<T>(default, false, error);
        }

        public static Result Ok()
        {
            return new Result(true, null);
        }

        public static Result<T> Ok<T>(T value)
        {
            return new Result<T>(value, true, null);
        }
    }

    internal class Result<T>: Result
    {
        private readonly T _value;
        public T Value
        {
            get
            {
                if (!IsSuccess)
                    throw new InvalidOperationException();

                return _value;
            }
        }

        protected internal Result(T value,  bool isSuccess, ResultError error )
            : base(isSuccess, error)
        {
            _value = value;
        }
    }
}
