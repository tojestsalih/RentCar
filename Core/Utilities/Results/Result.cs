namespace Core.Utilities.Results
{
    public class Result:IResult
    {
        public Result(bool success, string message) : this(success)
        {
            Message = message;
        }
        public Result(bool success)
        {
            Success = success;//Read-only properties can only be set in the constructor
        }

        
        public bool Success { get; }
        public string Message { get; }
    }
}