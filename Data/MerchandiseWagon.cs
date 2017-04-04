namespace Data
{
    using Exceptions;

    /// <summary>
    ///
    /// </summary>
    /// <seealso cref="Data.AbstractWagon" />
    public class MerchandiseWagon : AbstractWagon
    {
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
    }
}
