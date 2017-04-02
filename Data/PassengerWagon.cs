namespace Data
{
    using System.Collections.Generic;
    using System.Linq;

    using Exceptions;

    public class PassengerWagon : AbstractWagon
    {
        private const int passengerLimit = 100;
        private const int defaultKilos = 3000;

        #region AbstractProperties
        private const int limit = 11000;
        public override int Limit => limit;
        #endregion

        #region Properties
        public List<Passenger> PassengerList { get; internal set; }
        #endregion

        #region Constructor
        public PassengerWagon(int weight = defaultKilos)
        {
            if (weight < defaultKilos || weight > this.Limit)
                throw new WagonOutOfRangeException("Weight is out of range [" + defaultKilos + "," + this.Limit + "]");
            this.WeightInKilos = weight;
        }
        public PassengerWagon(List<Passenger> passengers)
        {
            /*if (passengers.Count > passengerLimit)
                throw new WagonOutOfRangeException("Passenger number is out of range " + passengers.Count + ">" + passengerLimit);*/
            this.PassengerList = passengers;
            int kilos = passengers.Sum(passenger => passenger.WeightInKilos);

            /*if (kilos < defaultKilos || kilos > this.Limit)
                throw new WagonOutOfRangeException("Weight is out of range [" + defaultKilos + "," + this.Limit + "]");*/
            this.WeightInKilos = kilos;
        }
        #endregion
    }
}
