namespace TestResult
{
    internal class ResultError : Exception
    {
        public ResultError()
        {

        }

        public ResultError(string? message, Exception? innerException)
            : base(message, innerException)
        {

        }

        public ResultError(string? message)
            :base(message)
        {

        }
    }
}
