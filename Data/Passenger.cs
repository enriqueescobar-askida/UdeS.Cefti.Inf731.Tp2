namespace Data
{
    using System;

    public class Passenger : IDisposable
    {
        #region PrivateAttributes
        /// Flag for disposed resources
        private bool _IsDisposed = false;
        #endregion

        #region Properties
        public int WeightInKilos { get; internal set; }
        #endregion

        #region Constructor
        public Passenger()
        {
            this.WeightInKilos = 80;
        }
        #endregion

        #region Destructor
        /// Releases unmanaged resources and performs other cleanup operations before the 
        /// is reclaimed by garbage collection. 
        /// This destructor will run only if the Dispose method does not get called. 
        /// It gives your base class the opportunity to finalize. 
        /// Do not provide destructors in types derived from this class.
        ~Passenger()
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

        #region PrivateMethods
        private void Dispose(bool isDisposing)
        {
            //Check if Dispose has been called 
            if (!this._IsDisposed)
            {//dispose managed and unmanaged resources 
                if (isDisposing)
                {//managed resources clean 
                    //this.WeightInKilos = null;
                }
                //unmanaged resources clean 
                this.WeightInKilos = 0;
                //confirm cleaning 
                this._IsDisposed = true;
            }
        }
        #endregion
    }
}
