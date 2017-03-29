namespace Data
{
    public class Locomotive
    {
        public Locomotive(string locomotiveInfo)
        {
            this.WeightInKilos = int.Parse(locomotiveInfo.Split(';')[0]);
            this.MetricTons = int.Parse(locomotiveInfo.Split(';')[1]);
            this.IsValid = this.MetricTons * 1000 < this.WeightInKilos;
        }

        #region Properties
        public int WeightInKilos { get; internal set; }
        public int MetricTons { get; internal set; }
        public bool IsValid { get; internal set; }
        #endregion
    }
}
