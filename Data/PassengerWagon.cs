namespace Data
{
    using System.Collections.Generic;

    public class PassengerWagon : AbstractWagon
    {
        #region AbstractProperties
        private const int limit = 11000;
        public override int Limit => limit;
        #endregion

        #region Properties
        public List<Passenger> PassengerList { get; internal set; }
        #endregion

        #region Constructor
        public PassengerWagon()
        {
            this.WeightInKilos = 3000;
        }
        #endregion
    }
}
