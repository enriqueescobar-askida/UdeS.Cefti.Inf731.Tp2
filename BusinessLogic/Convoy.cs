namespace BusinessLogic
{
    using System.Collections.Generic;

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
            return this.ValidateTransation(operation);
        }
        #endregion
        #region PrivateMethods
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
            return true;
        }
        private bool ValidateAddition(string operation)
        {
            return true;
        }
        #endregion
    }
}
