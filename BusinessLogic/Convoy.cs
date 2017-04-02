namespace BusinessLogic
{
    using System.Collections.Generic;
    using System.Linq;

    using Data;

    public class Convoy
    {
        #region Properties
        public Locomotive Locomotive { get; internal set; }
        public Stack<AbstractWagon> WagonStack { get; internal set; }
        public JournalLog JournalLog { get; internal set; }
        #endregion

        #region Constructor
        public Convoy(string locomotiveInfo)
        {
            this.Locomotive = new Locomotive(locomotiveInfo);
            this.WagonStack = new Stack<AbstractWagon>();
        }
        #endregion

        #region PublicMethods
        public bool Transaction(string operation)
        {
            if (this.ValidateTransation(operation))
            {
                if (this.IsSuppression(operation)) return true;
                if (this.IsAddition(operation))
                    this.AddWagon(operation);
                
                return true;
            }
            return false;
        }
        #endregion

        #region PrivateMethods
        private void AddWagon(string operation)
        {
            if (operation.Split(';')[1].Equals("M")) this.AddMerchandiseWagon(operation);
            if (operation.Split(';')[1].Equals("P")) this.AddPassengerWagon(operation);
        }

        private void AddPassengerWagon(string operation)
        {
            int count = int.Parse(operation.Split(';')[2]);
            List<Passenger> passengers = new List<Passenger>(count);
            for (int i = 0; i < count; i++) 
                passengers.Add(new Passenger());

            PassengerWagon p = new PassengerWagon(passengers);
            this.WagonStack.Push(p);
        }
        private void AddMerchandiseWagon(string operation)
        {
            MerchandiseWagon m = new MerchandiseWagon(int.Parse(operation.Split(';')[2]));
            this.WagonStack.Push(m);
        }

        private bool IsAddition(string operation)
        {
            return operation.StartsWith("A");
        }
        private bool IsSuppression(string operation)
        {
            return operation.StartsWith("S");
        }
        private bool ValidateTransation(string operation)
        {
            if (operation.Split(';')[0].StartsWith("A"))
                return this.ValidateAddition(operation);
            if (operation.Split(';')[0].StartsWith("S"))
                return this.ValidateRemoval(operation);
            else return false;
        }
        private bool ValidateRemoval(string operation)
        {
            return operation.Split(';').Length == 2;
        }
        private bool ValidateAddition(string operation)
        {
            string s = operation.Split(';')[1];
            return operation.Split(';').Length == 3 && (s.Equals("M") || s.Equals("P"));
        }
        #endregion
    }
}
