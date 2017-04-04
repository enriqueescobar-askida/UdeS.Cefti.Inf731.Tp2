namespace Exceptions
{
    using System.Diagnostics.Eventing.Reader;

    /// <summary>
    ///
    /// </summary>
    /// <seealso cref="System.Diagnostics.Eventing.Reader.EventLogInvalidDataException" />
    public class ConvoyDataException : EventLogInvalidDataException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConvoyDataException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public ConvoyDataException(string message) : base(message)
        {
        }
    }
}
