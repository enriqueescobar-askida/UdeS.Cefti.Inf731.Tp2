namespace BusinessLogic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    ///
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class JournalLog : IDisposable
    {
        #region PrivateAttributes
        /// Flag for disposed resources
        private bool _IsDisposed = false;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the entry logs.
        /// </summary>
        /// <value>
        /// The entry logs.
        /// </value>
        public List<EntryLog> EntryLogs { get; internal set; }
        /// <summary>
        /// Set the output path
        /// </summary>
        private string outputFile;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="JournalLog"/> class.
        /// </summary>
        /// <param name="convoyReaderFilePath"></param>
        public JournalLog(string convoyReaderFilePath)
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
        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            string s = String.Empty;
            StringBuilder builder = new StringBuilder();
            builder.Append(s);
            foreach (EntryLog entryLog in this.EntryLogs)
                builder.Append(entryLog + "\n");

            s = builder.ToString();
            return s;
        }
        #endregion

        #region Public
        /// <summary>
        /// Adds the specified entry log.
        /// </summary>
        /// <param name="entryLog">The entry log.</param>
        public void Add(EntryLog entryLog)
        {
            this.EntryLogs.Add(entryLog);
        }
        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        #region Private
        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="isDisposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        private void Dispose(bool isDisposing)
        {
            //Check if Dispose has been called
            if (!this._IsDisposed)
            {//dispose managed and unmanaged resources
                if (isDisposing)
                {//managed resources clean
                    this.EntryLogs = null;
                    this.outputFile = String.Empty;
                }
                //unmanaged resources clean

                //confirm cleaning
                this._IsDisposed = true;
            }
        }
        #endregion
    }
}