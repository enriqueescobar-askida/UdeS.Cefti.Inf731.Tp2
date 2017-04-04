namespace BusinessLogic
{
    using System;
    using System.Collections.Generic;

    using Data;
    using DataAccess;

    /// <summary>
    ///
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class Convoy : IDisposable
    {
        #region PrivateAttributes
        /// Flag for disposed resources
        private bool _IsDisposed = false;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the locomotive.
        /// </summary>
        /// <value>
        /// The locomotive.
        /// </value>
        public Locomotive Locomotive { get; internal set; }
        /// <summary>
        /// Gets the weight in kilos.
        /// </summary>
        /// <value>
        /// The weight in kilos.
        /// </value>
        public int WeightInKilos { get; internal set; }
        /// <summary>
        /// Gets the wagon stack.
        /// </summary>
        /// <value>
        /// The wagon stack.
        /// </value>
        public Stack<AbstractWagon> WagonStack { get; internal set; }
        /// <summary>
        /// Gets the length.
        /// </summary>
        /// <value>
        /// The length.
        /// </value>
        public int Length { get; internal set; }
        /// <summary>
        /// Gets the journal log.
        /// </summary>
        /// <value>
        /// The journal log.
        /// </value>
        public JournalLog JournalLog { get; internal set; }
        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Convoy"/> class.
        /// </summary>
        /// <param name="locomotiveInfo">The locomotive information.</param>
        /// <param name="convoyReaderFilePath"></param>
        public Convoy(string locomotiveInfo, string convoyReaderFilePath)
        {
            this.Locomotive = new Locomotive(locomotiveInfo);
            this.WeightInKilos = this.Locomotive.WeightInKilos;
            this.WagonStack = new Stack<AbstractWagon>();
            this.Length = 0;
            this.JournalLog = new JournalLog(convoyReaderFilePath);
        }
        #endregion

        #region Destructor
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// is reclaimed by garbage collection.
        /// This destructor will run only if the Dispose method does not get called.
        /// It gives your base class the opportunity to finalize.
        /// Do not provide destructor in types derived from this class.
        ~Convoy()
        {
            // Do not re-create Dispose clean-up code here.
            // Calling Dispose(false) is optimal in terms of readability and maintainability.
            this.Dispose(false);
        }
        #endregion

        #region PublicMethods
        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// Transactions the specified o.
        /// </summary>
        /// <param name="o">The o.</param>
        /// <returns></returns>
        public string Transaction(Operation o)
        {
            EntryLog entryLog = null;
            if(o.ItsAdding)
                entryLog = this.AddWagon(o);
            if(o.ItsRemoving)
                entryLog = this.RemoveWagon(o.Value);
            this.JournalLog.Add(entryLog);
            return entryLog.Message ;
        }
        #endregion

        #region PrivateMethods
        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="isDisposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        private void Dispose(bool isDisposing)
        {
            //Check if Dispose has been called
            if (!this._IsDisposed)
            {//dispose managed and unmanaged resources
                if (isDisposing)
                {//managed resources clean
                    this.Locomotive = null;
                    this.WagonStack = null;
                    this.JournalLog = null;
                }
                //unmanaged resources clean
                this.WeightInKilos = this.Length = 0;
                //confirm cleaning
                this._IsDisposed = true;
            }
        }
        /// <summary>
        /// Removes the wagon.
        /// </summary>
        /// <param name="times">The times.</param>
        /// <returns></returns>
        private EntryLog RemoveWagon(int times)
        {
            if (times > this.Length)
                return new EntryLog(false, this.Length, this.WeightInKilos, this.Locomotive.MetricTons);
            // if (times <= this.Length)
            else
            {
                for (int i = 0; i < times; i++)
                {
                    AbstractWagon abstractWagon = this.WagonStack.Pop();
                    this.WeightInKilos -= abstractWagon.WeightInKilos;
                }
                this.Length = this.WagonStack.Count;
                return new EntryLog(true, this.Length, this.WeightInKilos, this.Locomotive.MetricTons);
            }
        }
        /// <summary>
        /// Adds the wagon.
        /// </summary>
        /// <param name="o">The o.</param>
        /// <returns></returns>
        private EntryLog AddWagon(Operation o)
        {
            EntryLog entryLog = null;
            if (o.AddsMerchandise)
                entryLog = this.AddMerchandiseWagon(o.Value);
            if (o.AddsPassenger)
                entryLog = this.AddPassengerWagon(o.Value);
            return entryLog;
        }

        /// <summary>
        /// Adds the passenger wagon.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <returns></returns>
        private EntryLog AddPassengerWagon(int count)
        {
            List<Passenger> passengers = new List<Passenger>(count);
            for (int i = 0; i < passengers.Count; i++)
                passengers.Add(new Passenger());

            PassengerWagon p = new PassengerWagon(passengers);
            this.WagonStack.Push(p);
            this.WeightInKilos += p.WeightInKilos;
            this.Length = this.WagonStack.Count;
            return new EntryLog(true, this.Length, this.WeightInKilos, this.Locomotive.MetricTons);
        }
        /// <summary>
        /// Adds the merchandise wagon.
        /// </summary>
        /// <param name="weight">The weight.</param>
        /// <returns></returns>
        private EntryLog AddMerchandiseWagon(int weight)
        {
            MerchandiseWagon m = new MerchandiseWagon(weight);
            this.WagonStack.Push(m);
            this.WeightInKilos += m.WeightInKilos;
            this.Length = this.WagonStack.Count;
            return new EntryLog(true, this.Length, this.WeightInKilos, this.Locomotive.MetricTons);
        }
        #endregion
    }
}
