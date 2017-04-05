namespace Data
{
    using System;
    /// <summary>
    ///
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public abstract class AbstractWagon : IDisposable
    {
        #region PrivateAttributes
        /// Flag for disposed resources
        private bool _IsDisposed = false;
        #endregion

        #region Destructor
        ~AbstractWagon()
        {
            this.Dispose(false);
        }
        /// <summary>
        /// Returns true if ... is valid.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is valid; otherwise, <c>false</c>.
        /// </value>
        public bool IsValid { get; internal set; }
        #endregion

        #region AbstractProperties
        /// <summary>
        /// Gets the limit.
        /// </summary>
        /// <value>
        /// The limit.
        /// </value>
        public abstract int Limit { get; }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the weight in kilos.
        /// </summary>
        /// <value>
        /// The weight in kilos.
        /// </value>
        public int WeightInKilos { get; internal set; }
        #endregion

        #region DisposableMethods
        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this._IsDisposed)
            {
                if (disposing)
                {
                    // Free other state (managed objects).
                }
                else
                {
                }
                this.IsValid = false;
                this.WeightInKilos = 0;
                this._IsDisposed = true;
            }
        }
        #endregion
    }
}
