namespace Exceptions
{
    using System;
    public class ConvoyOutOfRangeException : ArgumentOutOfRangeException
    {
        public ConvoyOutOfRangeException(string paramName) : base(paramName)
        {
        }
    }
}