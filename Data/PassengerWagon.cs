namespace Data
{
    using System.Collections.Generic;
    using System.Linq;

    using Exceptions;

    /// <summary>
    ///
    /// </summary>
    /// <seealso cref="Data.AbstractWagon" />
    public class PassengerWagon : AbstractWagon
    {
        #region PrivateAttributes
        /// Flag for disposed resources
        private bool _IsDisposed = false;
        #endregion

        #region AbstractProperties
        /// <summary>
        /// The limit
        /// </summary>
        private const int limit = 11000;
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
        /// The passenger limit
        /// </summary>
        private const int passengerLimit = 100;
        /// <summary>
        /// The default kilos
        /// </summary>
        private const int defaultKilos = 3000;
        /// <summary>
        /// Gets the passenger list.
        /// </summary>
        /// <value>
        /// The passenger list.
        /// </value>
        public List<Passenger> PassengerList { get; internal set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="PassengerWagon"/> class.
        /// </summary>
        /// <param name="weight">The weight.</param>
        /// <exception cref="Exceptions.WagonOutOfRangeException">Weight is out of range [ + defaultKilos + , + this.Limit + ]</exception>
        public PassengerWagon(int weight = defaultKilos)
        {
            if (weight < defaultKilos || weight > Limit)
                throw new WagonOutOfRangeException("Weight is out of range [" + defaultKilos + "," + Limit + "]");
            WeightInKilos = weight;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="PassengerWagon"/> class.
        /// </summary>
        /// <param name="passengers">The passengers.</param>
        public PassengerWagon(List<Passenger> passengers)
        {
            /*if (passengers.Count > passengerLimit)
                throw new WagonOutOfRangeException("Passenger number is out of range " + passengers.Count + ">" + passengerLimit);*/
            PassengerList = passengers;
            int kilos = passengers.Sum(passenger => passenger.WeightInKilos);

            /*if (kilos < defaultKilos || kilos > this.Limit)
                throw new WagonOutOfRangeException("Weight is out of range [" + defaultKilos + "," + this.Limit + "]");*/
            WeightInKilos = kilos;
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
                    this.PassengerList = null;
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
