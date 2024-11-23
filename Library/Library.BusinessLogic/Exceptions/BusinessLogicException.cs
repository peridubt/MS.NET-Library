namespace Library.BusinessLogic.Exceptions;

public class BusinessLogicException : Exception
{
    public ResultCode? Code { get; set; }

    public BusinessLogicException(string message) : base(message)
    {
    }

    public BusinessLogicException(ResultCode code) : base(code.ToString())
    {
        Code = code;
    }
}