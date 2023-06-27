namespace src.Exceptions;



public class ObjectNotFoundException : Exception
{
    public ObjectNotFoundException(string message) : base(message)
    {
        
    }
}

public class BadRequestException : Exception
{
    public BadRequestException(string message) : base(message)
    {
        
    }
}