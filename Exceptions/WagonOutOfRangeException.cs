namespace Exceptions
{
    using System;
    public class WagonOutOfRangeException : ArgumentOutOfRangeException
    {
        public WagonOutOfRangeException(string paramName) : base(paramName)
        {
        }
    }
}