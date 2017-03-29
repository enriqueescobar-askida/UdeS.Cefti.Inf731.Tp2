namespace Exceptions
{
    using System;

    public class ConvoyArgumentException : ArgumentException
    {
        public ConvoyArgumentException(string message) : base(message)
        {
        }
    }
}
