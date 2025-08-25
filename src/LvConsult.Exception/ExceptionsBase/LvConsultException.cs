namespace LvConsult.Exception.ExceptionsBase;
public abstract class LvConsultException : SystemException
{
    protected LvConsultException(string message) : base(message)
    {
        
    }

    public abstract int StatusCode { get; }
    public abstract List<string> GetErrors();
}
