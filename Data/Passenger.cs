namespace Data
{
    using System;

    /// <summary>
    ///
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class Passenger : IDisposable
    {
        #region PrivateAttributes
        /// Flag for disposed resources
        private bool _IsDisposed = false;
        #endregion

        #region Properties
        /// <summary>
        /// The default kilos
        /// </summary>
        private const int defaultKilos = 80;
        /// <summary>
        /// Gets the weight in kilos.
        /// </summary>
        /// <value>
        /// The weight in kilos.
        /// </value>
        public int WeightInKilos { get; internal set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Passenger"/> class.
        /// </summary>
        /// <param name="weight">The weight.</param>
        public Passenger(int weight = defaultKilos)
        {
            this.WeightInKilos = weight;
        }
        #endregion

        #region Destructor
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// is reclaimed by garbage collection.
        /// This destructor will run only if the Dispose method does not get called.
        /// It gives your base class the opportunity to finalize.
        /// Do not provide destructors in types derived from this class.
        ~Passenger()
        {
            // Do not re-create Dispose clean-up code here.
            // Calling Dispose(false) is optimal in terms of readability and maintainability.
            this.Dispose(false);
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

        #region PrivateMethods
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
                    //this.WeightInKilos = null;
                }
                //unmanaged resources clean
                this.WeightInKilos = 0;
                //confirm cleaning
                this._IsDisposed = true;
            }
        }
        #endregion
    }
}
