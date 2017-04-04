namespace Exceptions
{
    using System.IO;
    /// <summary>
    ///
    /// </summary>
    /// <seealso cref="System.IO.FileNotFoundException" />
    public class ConvoyFileNotFoundException : FileNotFoundException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConvoyFileNotFoundException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public ConvoyFileNotFoundException(string message) : base(message)
        {
        }
    }
}
