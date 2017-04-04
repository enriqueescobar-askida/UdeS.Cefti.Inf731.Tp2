namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    using Exceptions;

    /// <summary>
    ///
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class ConvoyReader : IDisposable
    {
        #region PrivateAttributes
        /// Flag for disposed resources
        private bool _IsDisposed = false;
        #endregion

        #region Properties
        /// <summary>
        /// The file path
        /// </summary>
        public string FilePath { get; internal set; }
        /// <summary>
        /// Gets the locomotive information.
        /// </summary>
        /// <value>
        /// The locomotive information.
        /// </value>
        public string LocomotiveInfo { get; internal set; }
        /// <summary>
        /// Gets the operation list.
        /// </summary>
        /// <value>
        /// The operation list.
        /// </value>
        public List<Operation> OperationList { get; internal set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ConvoyReader"/> class.
        /// </summary>
        /// <param name="aFilePath">a file path.</param>
        /// <exception cref="ConvoyFileNotFoundException">File path cannot be found</exception>
        public ConvoyReader(string aFilePath)
        {
            if (new FileInfo(aFilePath).Exists) this.FilePath = aFilePath;
            else throw new ConvoyFileNotFoundException("File path cannot be found");
            this.ReadFile();
        }
        #endregion

        #region Destructor
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// is reclaimed by garbage collection.
        /// This destructor will run only if the Dispose method does not get called.
        /// It gives your base class the opportunity to finalize.
        /// Do not provide destructor in types derived from this class.
        ~ConvoyReader()
        {
            // Do not re-create Dispose clean-up code here.
            // Calling Dispose(false) is optimal in terms of readability and maintainability.
            this.Dispose(false);
        }
        #endregion

        #region PublicMethods
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// Do not make this method virtual, a derived class should not be able to override this method.
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
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
            return this.FilePath;
        }
        #endregion

        #region PrivateMethods
        /// <summary>
        /// Reads the file.
        /// </summary>
        /// <exception cref="ConvoyDataException">Character ';' cannot be found</exception>
        private void ReadFile()
        {
            List<Operation> operationList = new List<Operation>();
            FileStream fileStream = new FileStream(this.FilePath, FileMode.Open, FileAccess.Read);
            using (StreamReader streamReader = new StreamReader(fileStream)) //, Encoding.UTF8))
            {
                string line;
                int count = 0;
                while ((line = streamReader.ReadLine()) != null)
                {
                    line = line.ToUpperInvariant().Trim();
                    bool boo = line.Contains(";");
                    if (!boo)
                        throw new ConvoyDataException("Character ';' cannot be found");
                    if (count == 0)
                        this.ValidateLocomotive(line);
                    else operationList.Add(new Operation(line));
                    count++;
                }
            }
            this.OperationList = operationList;
        }
        /// <summary>
        /// Validates the locomotive.
        /// </summary>
        /// <param name="line">The line.</param>
        /// <exception cref="ConvoyOutOfRangeException">Wrong number of parameters for locomotive</exception>
        /// <exception cref="ConvoyArgumentException">Wrong argument format</exception>
        private void ValidateLocomotive(string line)
        {
            string[] s = line.Split(';');
            if (s.Length != 2) throw new ConvoyOutOfRangeException("Wrong number of parameters for locomotive");


            int[] ints = new int[2];

            if (int.TryParse(s[0], out ints[0]) & int.TryParse(s[1], out ints[1]))
                this.LocomotiveInfo = line;
            else
                throw new ConvoyArgumentException("Wrong argument format");
        }
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
                    this.OperationList = null;
                    this.LocomotiveInfo = this.FilePath = String.Empty;
                }
                //unmanaged resources clean

                //confirm cleaning
                this._IsDisposed = true;
            }
        }
        #endregion
    }
}
