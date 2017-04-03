namespace DataAccess
{
    using System;

    using Exceptions;

    public class Operation : IDisposable
    {
        #region PrivateAttributes
        /// Flag for disposed resources
        private bool _IsDisposed = false;
        #endregion

        #region Properties
        public string Command { get; internal set; }
        public bool ItsAdding { get; internal set; }
        public bool ItsRemoving { get; internal set; }
        public bool AddsPassenger { get; internal set; }
        public bool AddsMerchandise { get; internal set; }
        #endregion

        #region Constructor
        public Operation(string line)
        {
            if (this.ValidateLine(line.ToUpperInvariant()))
            {
                this.Command = line.ToUpperInvariant();
                if (this.Command.StartsWith("A", StringComparison.Ordinal))
                {
                    this.ItsAdding = true;
                    this.AddsPassenger = this.Command.Split(';')[1].Equals("P");
                    this.AddsMerchandise = this.Command.Split(';')[1].Equals("M");
                }
                if (this.Command.StartsWith("S", StringComparison.Ordinal))
                {
                    this.ItsRemoving = true;
                    this.AddsPassenger = false;
                    this.AddsMerchandise = false;
                }
            }
        }
        #endregion

        #region Destructor
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// is reclaimed by garbage collection.
        /// This destructor will run only if the Dispose method does not get called.
        /// It gives your base class the opportunity to finalize.
        /// Do not provide destructor in types derived from this class.
        ~Operation()
        {
            // Do not re-create Dispose clean-up code here.
            // Calling Dispose(false) is optimal in terms of readability and maintainability.
            this.Dispose(false);
        }
        #endregion

        #region PublicOverride
        public override string ToString()
        {
            return this.Command;
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
                    this.Command = String.Empty;
                }
                //unmanaged resources clean
                this.ItsAdding = this.ItsRemoving = this.AddsPassenger = this.AddsMerchandise = false;
                //confirm cleaning
                this._IsDisposed = true;
            }
        }
        private bool ValidateLine(string line)
        {
            string[] strings = line.Split(';');
            int length = strings.Length;
            if (length<2 || length>3)
                throw new ConvoyArgumentException("Wrong number of parameters:" + length);
            if (length == 2)
            {
                if (!line.StartsWith("S", StringComparison.Ordinal))
                    throw new ConvoyOutOfRangeException("Wrong starting parameter:" + strings[0]);
                if (int.Parse(strings[1]) < 0)
                    throw new ConvoyOutOfRangeException("Wrong parameter:" + strings[1]);
            }
            if (length == 3)
            {
                if (!line.StartsWith("A", StringComparison.Ordinal))
                    throw new ConvoyOutOfRangeException("Wrong starting parameter:" + strings[0]);
                if (!strings[1].Equals("M") && !strings[1].Equals("P"))
                    throw new ConvoyArgumentException("Wrong parameter:" + strings[1]);
                if (int.Parse(strings[2]) < 0)
                    throw new ConvoyOutOfRangeException("Wrong parameter:" + strings[2]);
            }
            return true;
        }
        #endregion
    }
}