
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
            using (ConvoyManager convoyManager = new ConvoyManager(@"..\..\..\train1.txt"))
            using (Convoy convoy = new Convoy(convoyManager.LocomotiveInfo, convoyManager.FilePath))
            {
                // check construction
                Console.Out.WriteLine(convoy.Locomotive);
                // all reads
                int i = 0;
                foreach (Operation o in convoyManager.OperationList)
                {
                    Console.Out.WriteLine(i + ".-" + o.Command.PadRight(12) + "|" + convoy.Transaction(o) + "|" + convoy.WeightInKilos.ToString().PadRight(6) + "|" +convoy.WagonStack.Count);
                    i++;
                }
                // check to string
                Console.WriteLine(convoy.JournalLog.ToString());
                convoyManager.Write(convoy.ToString());
                Console.In.ReadLine();
            }
        }
    }
}
