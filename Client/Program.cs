
namespace Client
{
    using System;
    using System.IO;

    using BusinessLogic;

    using DataAccess;
    /// <summary>
    /// Main program
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Mains the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
            // using convoy reader that self destroys itself
            // using convoy that self destroys itself
            using (ConvoyReader convoyReader = new ConvoyReader(@"..\..\..\train1.txt"))
            using (Convoy convoy = new Convoy(convoyReader.LocomotiveInfo, convoyReader.FilePath))
            {
                // check construction
                Console.Out.WriteLine(convoy.Locomotive);
                // check reads
                foreach (Operation o in convoyReader.OperationList)
                    Console.Out.WriteLine(o.Command);
                // check empty stack
                Console.Out.WriteLine(convoy.WagonStack.Count);
                // all reads
                foreach (Operation o in convoyReader.OperationList)
                {
                    // add read
                    Console.Out.WriteLine(convoy.Transaction(o));
                    // check stack size
                    Console.Out.WriteLine(convoy.WagonStack.Count);
                }
                //check to string
                Console.Out.WriteLine(convoy.JournalLog.ToString());
                Console.In.ReadLine();
            }
        }
    }
}
