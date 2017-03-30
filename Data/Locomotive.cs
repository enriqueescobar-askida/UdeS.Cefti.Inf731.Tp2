namespace Data
{
    using System;

    public class Locomotive : IDisposable
    {
        #region PrivateAttributes
        /// Flag for disposed resources
        private bool _IsDisposed = false;
        #endregion

        #region Properties
        public int WeightInKilos { get; internal set; }
        public int MetricTons { get; internal set; }
        public bool IsValid { get; internal set; }
        #endregion

        #region Constructor
        public Locomotive(string locomotiveInfo)
        {
            this.WeightInKilos = int.Parse(locomotiveInfo.Split(';')[0]);
            this.MetricTons = int.Parse(locomotiveInfo.Split(';')[1]);
            this.IsValid = this.MetricTons * 1000 < this.WeightInKilos;
        }
        #endregion

        #region Destructor
        /// Releases unmanaged resources and performs other cleanup operations before the 
        /// is reclaimed by garbage collection. 
        /// This destructor will run only if the Dispose method does not get called. 
        /// It gives your base class the opportunity to finalize. 
        /// Do not provide destructors in types derived from this class.
        ~Locomotive()
        {
            // Do not re-create Dispose clean-up code here. 
            // Calling Dispose(false) is optimal in terms of readability and maintainability. 
            this.Dispose(false);
        }
        #endregion

        #region PublicMethods
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        #region PublicOverrideMethods
        public override string ToString()
        {
            return String.Format("Locomotive[{0},{1}]", this.WeightInKilos, this.MetricTons);
        }
        #endregion

        #region PrivateMethods
        private void Dispose(bool isDisposing)
        {
            //Check if Dispose has been called 
            if (!this._IsDisposed)
            {//dispose managed and unmanaged resources 
                if (isDisposing)
                {//managed resources clean
                }
                //unmanaged resources clean 
                this.WeightInKilos = this.MetricTons = 0;
                this.IsValid = false;
                //confirm cleaning 
                this._IsDisposed = true;
            }
        }
        #endregion
    }
}
