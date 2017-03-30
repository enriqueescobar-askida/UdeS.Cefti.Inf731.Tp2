namespace Data
{
    public class MerchandiseWagon : AbstractWagon
    {
        #region AbstractProperties
        private const int limit = 12000;
        public override int Limit => limit;
        #endregion
        #region Constructor
        public MerchandiseWagon()
        {
            this.WeightInKilos = 2500;
        }
        #endregion
    }
}
