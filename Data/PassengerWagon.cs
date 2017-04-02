namespace Data
{
    using System.Collections.Generic;

    public class PassengerWagon : AbstractWagon
    {
        private const int PassLimit = 100;
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
            this.WeightInKilos = weight;
        }
        #endregion
    }
}
