namespace BusinessLogic
{
    using System;

    /// <summary>
    ///
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class EntryLog : IDisposable
    {
        #region PrivateAttributes
        /// Flag for disposed resources
        private bool _IsDisposed = false;
        #endregion

        #region Constants
        /// <summary>
        /// The accepted
        /// </summary>
        private const string Accepted = "Operation permitted";
        /// <summary>
        /// The refused
        /// </summary>
        private const string Refused = "Operation refused";
        #endregion

        #region Properties
        /// <summary>
        /// Gets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message { get; internal set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="EntryLog"/> class.
        /// </summary>
        /// <param name="boo">if set to <c>true</c> [boo].</param>
        /// <param name="length">The length.</param>
        /// <param name="weightInKilos">The weight in kilos.</param>
        /// <param name="locomotiveMetricTons">The locomotive metric tons.</param>
        public EntryLog(bool boo, int length, int weightInKilos, int locomotiveMetricTons)
        {
            this.Message = boo ? Accepted : Refused;
            this.Message = this.Message.PadRight(20) + length + "\t" + weightInKilos + "\t" + 1000 * locomotiveMetricTons;
        }
        #endregion

        #region Destructor
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// is reclaimed by garbage collection.
        /// This destructor will run only if the Dispose method does not get called.
        /// It gives your base class the opportunity to finalize.
        /// Do not provide destructor in types derived from this class.
        ~EntryLog()
        {
            // Do not re-create Dispose clean-up code here.
            // Calling Dispose(false) is optimal in terms of readability and maintainability.
            this.Dispose(false);
        }
        #endregion

        #region PublicOverride
        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return this.Message;
        }
        #endregion

        #region PublicMethods
        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        #region Private
        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="isDisposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        private void Dispose(bool isDisposing)
        {
            //Check if Dispose has been called
            if (!this._IsDisposed)
            {//dispose managed and unmanaged resources
                if (isDisposing)
                {//managed resources clean
                    this.Message = String.Empty;
                }
                //unmanaged resources clean

                //confirm cleaning
                this._IsDisposed = true;
            }
        }
        #endregion
    }
}