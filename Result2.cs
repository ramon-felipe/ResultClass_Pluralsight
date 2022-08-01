namespace TestResult
{
    internal class Result2
    {
        public bool IsSuccess { get; private set; }
        public bool IsFailure { get => !IsSuccess; }
        public ResultError? Error { get; private set; } = new ResultError();


        protected Result2(bool isSuccess, ResultError? error)
        {
            if (isSuccess && error != null)
                throw new InvalidOperationException();

            if (!isSuccess && error == null)
                throw new InvalidOperationException();

            IsSuccess = isSuccess;
            Error = error;
        }

        private static Result2 Ok()
        {
            return new Result2(true, null);
        }

        private static Result2<T> Ok<T>(T value)
        {
            return new Result2<T>(value, true, null);
        }

        private static Result2 Fail(ResultError error)
        {
            return new Result2(false, error);
        }

        private static Result2<T> Fail<T>(ResultError error)
        {
            return new Result2<T>(default, false, error);
        }

        /// <summary>
        /// It process a action and returns <see cref="Ok"/> or <see cref="Fail"/>
        /// </summary>
        /// <param name="act"></param>
        /// <returns></returns>
        internal static Result2 Process(Action act)
        {
            try
            {
                act();

                return Ok();
            }
            catch (Exception e)
            {
                var error = new ResultError(e.Message, e);
                return Fail(error);
            }
        }

        /// <summary>
        /// It process a method and returns <see cref="Ok{T}(T)"/> or <see cref="Fail{T}(ResultError)"/>
        /// </summary>
        /// <typeparam name="Tout"></typeparam>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        internal static Result2<Tout> Process<Tout>(Delegate method, params object[] args)
        {
            try
            {
                var result = (Tout)method.DynamicInvoke(args);

                return Ok<Tout>(result);
            }
            catch (Exception e)
            {
                var error = new ResultError(e.InnerException?.Message, e.InnerException);
                return Fail<Tout>(error);
            }
        }
    }

    internal class Result2<T> : Result2
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

        protected internal Result2(T value, bool isSuccess, ResultError? error)
            : base(isSuccess, error)
        {
            _value = value;
        }
    }
}
