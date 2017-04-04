namespace Data
{
    using System;

    /// <summary>
    ///
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class Locomotive : IDisposable
    {
        #region PrivateAttributes
        /// Flag for disposed resources
        private bool _IsDisposed = false;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the weight in kilos.
        /// </summary>
        /// <value>
        /// The weight in kilos.
        /// </value>
        public int WeightInKilos { get; internal set; }
        /// <summary>
        /// Gets the metric tons.
        /// </summary>
        /// <value>
        /// The metric tons.
        /// </value>
        public int MetricTons { get; internal set; }
        /// <summary>
        /// Returns true if ... is valid.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is valid; otherwise, <c>false</c>.
        /// </value>
        public bool IsValid { get; internal set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Locomotive"/> class.
        /// </summary>
        /// <param name="locomotiveInfo">The locomotive information.</param>
        public Locomotive(string locomotiveInfo)
        {
            this.WeightInKilos = int.Parse(locomotiveInfo.Split(';')[0]);
            this.MetricTons = int.Parse(locomotiveInfo.Split(';')[1]);
            this.IsValid = this.MetricTons * 1000 < this.WeightInKilos;
        }
        #endregion

        #region Destructor
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// is reclaimed by garbage collection.
        /// This destructor will run only if the Dispose method does not get called.
        /// It gives your base class the opportunity to finalize.
        /// Do not provide destructors in types derived from this class.
        ~Locomotive()
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

        #region PublicOverrideMethods
        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return String.Format("Locomotive[{0},{1}]", this.WeightInKilos, this.MetricTons);
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
                }
                //unmanaged resources clean
                this.WeightInKilos = this.MetricTons = 0;
                this.IsValid = false;
                //confirm cleaning
                this._IsDisposed = true;
            }
        }
        #endregion
    }
}
