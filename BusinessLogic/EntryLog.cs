namespace BusinessLogic
{
    using System;

    public class EntryLog : IDisposable
    {
        #region PrivateAttributes
        /// Flag for disposed resources
        private bool _IsDisposed = false;
        #endregion

        #region Constants
        private const string Accepted = "Operation permitted";
        private const string Refused = "Operation refused";
        #endregion

        #region Properties
        public string Message { get; internal set; }
        #endregion

        #region Constructor
        public EntryLog(bool boo, int length, int weightInKilos, int locomotiveMetricTons)
        {
            this.Message = boo ? Accepted : Refused;
            this.Message = this.Message.PadRight(20) + length + "\t" + weightInKilos + "\t" + 1000 * locomotiveMetricTons;
        }
        #endregion

        #region Destructor
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// is reclaimed by garbage collection.
        /// This destructor will run only if the Dispose method does not get called.
        /// It gives your base class the opportunity to finalize.
        /// Do not provide destructor in types derived from this class.
        ~EntryLog()
        {
            // Do not re-create Dispose clean-up code here.
            // Calling Dispose(false) is optimal in terms of readability and maintainability.
            this.Dispose(false);
        }
        #endregion

        #region PublicOverride
        public override string ToString()
        {
            return this.Message;
        }
        #endregion

        #region PublicMethods
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        #region Private
        private void Dispose(bool isDisposing)
        {
            //Check if Dispose has been called
            if (!this._IsDisposed)
            {//dispose managed and unmanaged resources
                if (isDisposing)
                {//managed resources clean
                    this.Message = String.Empty;
                }
                //unmanaged resources clean

                //confirm cleaning
                this._IsDisposed = true;
            }
        }
        #endregion
    }
}