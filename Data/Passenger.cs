namespace Data
{
    public class Passenger
    {
        #region Properties
        public int WeightInKilos { get; internal set; }
        #endregion
        #region Constructor
        public Passenger()
        {
            this.WeightInKilos = 80;
        }
        #endregion
    }
}
