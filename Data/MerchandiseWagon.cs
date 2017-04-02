namespace Data
{
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
            this.WeightInKilos = weight;
        }
        #endregion
    }
}
