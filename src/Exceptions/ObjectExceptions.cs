namespace src.Exceptions;



public class ObjectNotFoundException : Exception
{
    public ObjectNotFoundException(string message) : base(message)
    {
        
    }
}

public class WrongDataException : Exception
{
    public WrongDataException(string message) : base(message)
    {
        
    }
}