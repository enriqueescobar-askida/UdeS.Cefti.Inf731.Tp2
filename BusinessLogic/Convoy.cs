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
        #endregion

        #region Constructor
        public Convoy(string locomotiveInfo)
        {
            this.Locomotive = new Locomotive(locomotiveInfo);
        }
        #endregion

        #region PublicMethods
        public bool Transaction(string operation)
        {
            if (this.ValidateTransation(operation))
            {
                if (this.IsSuppression(operation)) return true;
                if (this.IsAddition(operation)) return true;
                return true;
            }
            return false;
        }
        #endregion

        #region PrivateMethods
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
