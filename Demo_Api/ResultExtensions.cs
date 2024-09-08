namespace Demo_Api
{
    public static class ResultExtensions
    {
        public static Result<Tout>  Bind<Tin, Tout>(this Result<Tin> inputResult, Func<Tin, Result<Tout>> fn)
        {
            return inputResult.IsSuccess ?
                fn(inputResult.Value) :
                Result<Tout>.Failure(inputResult.Error);
        }
        public static Result<Tout> TryCatch<Tin, Tout>(this Result<Tin> inputResult, Func<Tin, Tout> fn, Error error)
        {
            try
            {
                return inputResult.IsSuccess ?
                    Result<Tout>.Success(fn(inputResult.Value)) :
                    Result<Tout>.Failure(inputResult.Error);
            }
            catch
            {
                return Result<Tout>.Failure(error);
            }
        }
        public static Result<Tin> Tap<Tin>(this Result<Tin> inputResult, Action<Tin> action)
        {
            // Note that we are assuming this action cannot fail , otherwise we should use try catch
            if (inputResult.IsSuccess)
            {
                action(inputResult.Value);
            }

            return inputResult;
        }
        public static Tout Match<Tin, Tout>(this Result<Tin> inputResult, Func<Tin, Tout> OnSuccess, Func<Error, Tout> OnFailure)
        {
            return inputResult.IsSuccess ?
                OnSuccess(inputResult.Value) :
                OnFailure(inputResult.Error);
        }
    }
}
