namespace Exceptions
{
    using System.Diagnostics.Eventing.Reader;

    public class ConvoyDataException : EventLogInvalidDataException
    {
        public ConvoyDataException(string message) : base(message)
        {
        }
    }
}
