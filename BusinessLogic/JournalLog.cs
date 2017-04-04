namespace BusinessLogic
{
    using System;
    using System.Collections.Generic;

    public class JournalLog : IDisposable
    {
        #region PrivateAttributes
        /// Flag for disposed resources
        private bool _IsDisposed = false;
        #endregion

        #region Properties
        public List<EntryLog> EntryLogs { get; internal set; }
        #endregion

        #region Constructor
        public JournalLog()
        {
            this.EntryLogs = new List<EntryLog>();
        }
        #endregion

        #region Destructor
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// is reclaimed by garbage collection.
        /// This destructor will run only if the Dispose method does not get called.
        /// It gives your base class the opportunity to finalize.
        /// Do not provide destructor in types derived from this class.
        ~JournalLog()
        {
            // Do not re-create Dispose clean-up code here.
            // Calling Dispose(false) is optimal in terms of readability and maintainability.
            this.Dispose(false);
        }
        #endregion

        #region PublicOverride
        public override string ToString()
        {
            string s = String.Empty;
            foreach (EntryLog entryLog in this.EntryLogs)
            {
                s += entryLog.ToString() + "\n";
            }
            return s;
        }
        #endregion

        #region Public
        public void Add(EntryLog entryLog)
        {
            this.EntryLogs.Add(entryLog);
        }
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
                    this.EntryLogs = null;
                }
                //unmanaged resources clean

                //confirm cleaning
                this._IsDisposed = true;
            }
        }
        #endregion
    }
}