namespace Exceptions
{
    using System.IO;
    public class ConvoyFileNotFoundException : FileNotFoundException
    {
        public ConvoyFileNotFoundException(string message) : base(message)
        {
        }
    }
}
