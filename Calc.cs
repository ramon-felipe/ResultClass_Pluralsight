namespace TestResult
{
    internal class Calc
    {
        internal static Result<double> Divide(int n1, int n2)
        {
            try
            {
                var result = n1 / n2;

                return Result.Ok<double>(result);
            }
            catch (DivideByZeroException e)
            {
                var error = new ResultError(e.Message, e);
                return Result.Fail<double>(error);
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal static Result<double> Div(int n1, int n2)
        {
            var result = Divide(n1, n2);

            return result;
        }

        internal static Result2<double> Div2(int n1, int n2)
        {
            var result = Result2.Process<double>(Divide, n1, n2);
            
            return result;
        }
    }
}
