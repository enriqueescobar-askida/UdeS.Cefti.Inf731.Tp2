namespace Data
{
    /// <summary>
    ///
    /// </summary>
    public abstract class AbstractWagon
    {
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
        /// <summary>
        /// Returns true if ... is valid.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is valid; otherwise, <c>false</c>.
        /// </value>
        public bool IsValid { get; internal set; }
        #endregion
    }
}
