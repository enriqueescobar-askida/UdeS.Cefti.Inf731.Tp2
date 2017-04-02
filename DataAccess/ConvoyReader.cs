namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    using Exceptions;

    public class ConvoyReader : IDisposable
    {
        #region PrivateAttributes
        /// Flag for disposed resources
        private bool _IsDisposed = false;
        #endregion

        #region Properties
        private string filePath;
        public string LocomotiveInfo { get; internal set; }
        public List<string> OperationList { get; internal set; }
        #endregion

        #region Constructor
        public ConvoyReader(string aFilePath)
        {
            if (new FileInfo(aFilePath).Exists) this.filePath = aFilePath;
            else throw new ConvoyFileNotFoundException("File path cannot be found");
        }
        #endregion

        #region Destructor
        /// Releases unmanaged resources and performs other cleanup operations before the 
        /// is reclaimed by garbage collection. 
        /// This destructor will run only if the Dispose method does not get called. 
        /// It gives your base class the opportunity to finalize. 
        /// Do not provide destructors in types derived from this class.
        ~ConvoyReader()
        {
            // Do not re-create Dispose clean-up code here. 
            // Calling Dispose(false) is optimal in terms of readability and maintainability. 
            this.Dispose(false);
        }
        #endregion

        #region PublicMethods
        public void ReadFile()
        {
            List<string> operationList = new List<string>();
            FileStream fileStream = new FileStream(this.filePath, FileMode.Open, FileAccess.Read);
            using (StreamReader streamReader = new StreamReader(fileStream)) //, Encoding.UTF8))
            {
                string line;
                int count = 0;
                while ((line = streamReader.ReadLine()) != null)
                {
                    line = line.ToUpperInvariant();
                    bool boo = line.Contains(";");
                    if (!boo)
                        throw new ConvoyDataException("Character ';' cannot be found");
                    if (count == 0)
                        this.ValidateLocomotive(line);
                    else if (this.ValidateOperation(line))
                        operationList.Add(line);
                    Console.Out.WriteLine(line);
                    count++;
                }
            }
            this.OperationList = operationList;
        }
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources. 
        /// Do not make this method virtual, a derived class should not be able to override this method.
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        #region PublicOverride
        public override string ToString()
        {
            return this.filePath;
        }
        #endregion

        #region PrivateMethods
        private bool ValidateOperation(string line)
        {
            int count = line.Split(';').Length;

            bool boo = line.Contains("A") || line.Contains("M") || line.Contains("P") || line.Contains("S");
            if (!boo) throw new ConvoyOutOfRangeException("Error A|M|P|S not exists on string:" + line);
            bool hasStart = (line.StartsWith("A") && count==3) || (line.StartsWith("S") && count==2);
            if (!hasStart) throw new ConvoyArgumentException("Error A|M|P|S not exists on string:" + line);

            return boo && hasStart;
        }
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
        private void Dispose(bool isDisposing)
        {
            //Check if Dispose has been called 
            if (!this._IsDisposed)
            {//dispose managed and unmanaged resources 
                if (isDisposing)
                {//managed resources clean 
                    this.OperationList = null;
                    this.LocomotiveInfo = this.filePath = String.Empty;
                }
                //unmanaged resources clean 
                
                //confirm cleaning 
                this._IsDisposed = true;
            }
        }
        #endregion
    }
}
