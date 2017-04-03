namespace BusinessLogic
{
    using System;
    using System.Runtime.CompilerServices;

    public class EntryLog : IDisposable
    {
        private const string Accepted = "Operation permitted";

        private const string Refused = "Operation refused";
        public string Message { get; internal set; }
        public EntryLog(bool boo)
        {
            this.Message = boo ? Accepted : Refused;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}