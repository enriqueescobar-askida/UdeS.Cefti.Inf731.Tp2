namespace Exceptions
{
    using System;
    /// <summary>
    ///
    /// </summary>
    /// <seealso cref="System.ArgumentOutOfRangeException" />
    public class ConvoyOutOfRangeException : ArgumentOutOfRangeException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConvoyOutOfRangeException"/> class.
        /// </summary>
        /// <param name="paramName">Name of the parameter.</param>
        public ConvoyOutOfRangeException(string paramName) : base(paramName)
        {
        }
    }
}