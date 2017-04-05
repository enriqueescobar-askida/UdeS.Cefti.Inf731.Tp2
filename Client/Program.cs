
namespace Client
{
    using System;

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
                // all reads
                int i = 0;
                foreach (Operation o in convoyReader.OperationList)
                {
                    Console.Out.WriteLine(i + ".-" + o.Command.PadRight(12) + "|" + convoy.Transaction(o) + "|" + convoy.WeightInKilos.ToString().PadRight(6) + "|" +convoy.WagonStack.Count);
                    i++;
                }
                // check to string
                // Console.WriteLine(convoy.JournalLog.ToString());
                Console.In.ReadLine();
            }
        }
    }
}
