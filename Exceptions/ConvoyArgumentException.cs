namespace Exceptions
{
    using System;

    /// <summary>
    ///
    /// </summary>
    /// <seealso cref="System.ArgumentException" />
    public class ConvoyArgumentException : ArgumentException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConvoyArgumentException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public ConvoyArgumentException(string message) : base(message)
        {
        }
    }
}
