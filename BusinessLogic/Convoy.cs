namespace BusinessLogic
{
    using System;
    using System.Collections.Generic;

    using Data;
    using DataAccess;

    using Microsoft.Win32.SafeHandles;

    public class Convoy
    {
        #region Properties
        public Locomotive Locomotive { get; internal set; }
        public Stack<AbstractWagon> WagonStack { get; internal set; }
        public int Length { get; internal set; }
        public JournalLog JournalLog { get; internal set; }
        #endregion

        #region Constructor
        public Convoy(string locomotiveInfo)
        {
            this.Locomotive = new Locomotive(locomotiveInfo);
            this.WagonStack = new Stack<AbstractWagon>();
            this.Length = 0;
            this.JournalLog = new JournalLog();
        }
        #endregion

        #region PublicMethods
        public string Transaction(Operation o)
        {
            EntryLog entryLog = null;
            if(o.ItsAdding)
                entryLog = this.AddWagon(o);
            if(o.ItsRemoving)
                entryLog = this.RemoveWagon(o.Value);
            this.JournalLog.Add(entryLog);
            return o.Command + " ^^ " ;
        }
        #endregion

        #region PrivateMethods
        private EntryLog RemoveWagon(int times)
        {
            if (times > this.Length)
                return new EntryLog(false);
            // if (times <= this.Length)
            else
            {
                for (int i = 0; i < times; i++)
                {
                    this.WagonStack.Pop();
                }
                this.Length = this.WagonStack.Count;
                return new EntryLog(true);
            }
        }
        private EntryLog AddWagon(Operation o)
        {
            EntryLog entryLog = null;
            if (o.AddsMerchandise)
                entryLog = this.AddMerchandiseWagon(o.Value);
            if (o.AddsPassenger)
                entryLog = this.AddPassengerWagon(o.Value);
            return entryLog;
        }

        private EntryLog AddPassengerWagon(int count)
        {
            List<Passenger> passengers = new List<Passenger>(count);
            for (int i = 0; i < passengers.Count; i++)
                passengers.Add(new Passenger());

            PassengerWagon p = new PassengerWagon(passengers);
            this.WagonStack.Push(p);
            this.Length = this.WagonStack.Count;
            return new EntryLog(true);
        }
        private EntryLog AddMerchandiseWagon(int weight)
        {
            MerchandiseWagon m = new MerchandiseWagon(weight);
            this.WagonStack.Push(m);
            this.Length = this.WagonStack.Count;
            return new EntryLog(true);
        }
        #endregion
    }
}
