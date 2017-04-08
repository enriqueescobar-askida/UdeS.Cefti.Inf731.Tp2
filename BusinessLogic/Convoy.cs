﻿namespace BusinessLogic
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
            //EntryLog entryLog = null;
            string s = (o.ItsAdding) ? "+" : "-" ;
            if (o.ItsAdding)
            {
                AbstractWagon a;
                if (o.AddsMerchandise) a = new MerchandiseWagon(o.Value);
                else a = new PassengerWagon(o.Value);
                //entryLog = this.AddWagon(a);
                this.AddWagon(a);
                s += (o.AddsMerchandise) ? "m" : "p";
                s += "_" + a;
                s = s.PadRight(30);
            }
            else
            {
                //entryLog = this.RemoveWagon(o.Value);
                s += "s_" + this.RemoveWagon(o.Value);
                s = s.PadRight(30);
            }
            
            //this.JournalLog.Add(entryLog);
            //return entryLog.Message ;
            return s.PadRight(10) + "?";
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
        private /*EntryLog*/ string RemoveWagon(int times)
        {
            bool boo = false;
            int kays = 0;
            if (times > this.Length) boo = false;
                // return new EntryLog(false, this.Length, this.WeightInKilos, this.Locomotive.MetricTons);
            // if (times <= this.Length)
            else
            {
                AbstractWagon abstractWagon;
                int kilos = 0;
                for (int i = 0; i < times; i++)
                {
                    abstractWagon = this.WagonStack.Pop();
                    kilos += abstractWagon.WeightInKilos;
                }
                kays = kilos;
                this.WeightInKilos -= kilos;
                this.Length = this.WagonStack.Count;
                // return new EntryLog(true, this.Length, this.WeightInKilos, this.Locomotive.MetricTons);
                boo = true;
            }
            //return new EntryLog(boo, this.Length, this.WeightInKilos, this.Locomotive.MetricTons);
            return kays.ToString();
        }
        /// <summary>
        /// Adds the wagon.
        /// </summary>
        /// <param name="a">The abstract wagon.</param>
        /// <returns></returns>
        private /*EntryLog*/ void AddWagon(AbstractWagon a)
        {
            this.WagonStack.Push(a);
            this.WeightInKilos += a.WeightInKilos;
            this.Length = this.WagonStack.Count;
            //return new EntryLog(true, this.Length, this.WeightInKilos, this.Locomotive.MetricTons);
        }
        #endregion
    }
}
