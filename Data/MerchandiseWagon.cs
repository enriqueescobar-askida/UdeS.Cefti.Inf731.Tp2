namespace Data
{
    using Exceptions;

    public class MerchandiseWagon : AbstractWagon
    {
        private const int defaultKilos = 2500;

        #region AbstractProperties
        private const int limit = 12000;
        public override int Limit => limit;
        #endregion

        #region Constructor
        public MerchandiseWagon(int weight = defaultKilos)
        {
            /*if (weight<defaultKilos || weight>this.Limit)
                throw new WagonOutOfRangeException("Weight is out of range [" + defaultKilos + "," + this.Limit + "]");*/
            this.WeightInKilos = weight;
        }
        #endregion
    }
}
