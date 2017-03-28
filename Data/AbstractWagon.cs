namespace Data
{
    public abstract class AbstractWagon
    {
        #region AbstractProperties
        public abstract int Limit { get; }
        #endregion

        #region Properties
        public int WeightInKilos { get; internal set; }
        public bool IsValid { get; internal set; }
        #endregion
    }
}
