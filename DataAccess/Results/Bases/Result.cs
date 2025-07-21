

namespace DataAccess.Results.Bases
{
   public abstract class Result
    {
        public bool IsSuccessfull { get; }
        public string Message { get; }
        public Result(bool isSuccessfull, string message)
        {
            IsSuccessfull = isSuccessfull;
            Message = message;
        }

      
    }
}
