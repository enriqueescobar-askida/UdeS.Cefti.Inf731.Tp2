namespace Exceptions
{
    using System;
    /// <summary>
    ///
    /// </summary>
    /// <seealso cref="System.ArgumentOutOfRangeException" />
    public class WagonOutOfRangeException : ArgumentOutOfRangeException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WagonOutOfRangeException"/> class.
        /// </summary>
        /// <param name="paramName">Name of the parameter.</param>
        public WagonOutOfRangeException(string paramName) : base(paramName)
        {
        }
    }
}