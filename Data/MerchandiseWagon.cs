namespace Data
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso cref="Data.AbstractWagon" />
    public class MerchandiseWagon : AbstractWagon
    {
        #region PrivateAttributes
        /// Flag for disposed resources
        private bool _IsDisposed = false;
        #endregion

        #region AbstractProperties
        /// <summary>
        /// The limit
        /// </summary>
        private const int limit = 12000;
        /// <summary>
        /// Gets the limit.
        /// </summary>
        /// <value>
        /// The limit.
        /// </value>
        public override int Limit => limit;
        #endregion

        #region Properties
        /// <summary>
        /// The default kilos
        /// </summary>
        private const int defaultKilos = 2500;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="MerchandiseWagon"/> class.
        /// </summary>
        /// <param name="weight">The weight.</param>
        public MerchandiseWagon(int weight = defaultKilos)
        {
            /*if (weight<defaultKilos || weight>this.Limit)
                throw new WagonOutOfRangeException("Weight is out of range [" + defaultKilos + "," + this.Limit + "]");*/
            this.WeightInKilos = weight;
        }
        #endregion

        #region DisposableMethods
        protected override void Dispose(bool disposing)
        {
            if (!this._IsDisposed)
            {
                if (disposing)
                {
                    // Release managed resources.
                }
                else
                {
                }
                // Release unmanaged resources.
                this._IsDisposed = true;
            }
            // Call Dispose in the base class.
            base.Dispose(disposing);
        }
        // The derived class does not have a Finalize method or a Dispose method
        // without parameters because it inherits them from the base class.
        #endregion
    }
}
