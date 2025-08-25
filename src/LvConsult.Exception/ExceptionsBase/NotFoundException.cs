using System.Net;

namespace LvConsult.Exception.ExceptionsBase;
public class NotFoundException : LvConsultException
{
    public NotFoundException(string message) : base(message)
    {
    }

    public override int StatusCode => (int)HttpStatusCode.NotFound;

    public override List<string> GetErrors()
    {
        return [Message];
    }
}
