namespace BusinessLogic
{
    using System;
    using System.Collections.Generic;

    public class JournalLog : IDisposable
    {
        public List<EntryLog> EntryLogs { get; internal set; }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}