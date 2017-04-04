namespace BusinessLogic
{
    using System;
    using System.Collections.Generic;

    public class JournalLog
    {
        public List<EntryLog> EntryLogs { get; internal set; }

        public JournalLog()
        {
            this.EntryLogs = new List<EntryLog>();
        }

        public void Add(EntryLog entryLog)
        {
            this.EntryLogs.Add(entryLog);
        }

        public override string ToString()
        {
            string s = String.Empty;
            foreach (EntryLog entryLog in this.EntryLogs)
            {
                s += "+ " + entryLog.ToString() + "\n";
            }
            return s;
        }
    }
}