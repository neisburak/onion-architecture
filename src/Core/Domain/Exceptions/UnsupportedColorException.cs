namespace Domain.Exceptions;

public class UnsupportedColorException : Exception
{
    public UnsupportedColorException(string code) : base($"Color with '{code} is not supported.'") { }
}