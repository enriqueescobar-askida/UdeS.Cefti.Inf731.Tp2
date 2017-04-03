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
        }
        #endregion

        #region PublicMethods
        public string Transaction(Operation o)
        {
            if(o.ItsAdding) this.AddWagon(o);
            if(o.ItsRemoving) this.RemoveWagon(o.Value);
            return o.Command + " ^^ " ;
        }
        #endregion

        #region PrivateMethods
        private void RemoveWagon(int times)
        {
            bool boo = false;
            if (times <= this.Length)
            {
                for (int i = 0; i < times; i++)
                {
                    this.WagonStack.Pop();
                }
                boo = true;
                this.Length = this.WagonStack.Count;
            }
            else boo = false;
        }
        private void AddWagon(Operation o)
        {
            if (o.AddsMerchandise)
                this.AddMerchandiseWagon(o.Value);
            if (o.AddsPassenger)
                this.AddPassengerWagon(o.Value);
        }

        private bool AddPassengerWagon(int count)
        {
            bool boo = false;
            List<Passenger> passengers = new List<Passenger>(count);
            for (int i = 0; i < passengers.Count; i++)
                passengers.Add(new Passenger());

            PassengerWagon p = new PassengerWagon(passengers);
            this.WagonStack.Push(p);
            this.Length = this.WagonStack.Count;
            boo = true;
            return boo;
        }
        private bool AddMerchandiseWagon(int weight)
        {
            bool boo = false;
            MerchandiseWagon m = new MerchandiseWagon(weight);
            this.WagonStack.Push(m);
            this.Length = this.WagonStack.Count;
            boo = true;
            return boo;
        }
        #endregion
    }
}
