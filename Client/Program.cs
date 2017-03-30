namespace Client
{
    using System;

    using BusinessLogic;

    using DataAccess;
    class Program
    {
        static void Main(string[] args)
        {
            Convoy convoy;
            using (ConvoyReader convoyReader = new ConvoyReader(@"..\..\..\train1.txt"))
            {
                convoyReader.ReadFile();
                Console.Out.WriteLine(convoyReader.LocomotiveInfo);
                convoy = new Convoy(convoyReader.LocomotiveInfo);
                Console.Out.WriteLine(convoyReader.OperationList.Count);
            }
            Console.Out.WriteLine(convoy.Locomotive);
            Console.Out.WriteLine(convoy.Transaction("A;M;10500"));
            Console.Out.WriteLine(convoy.Transaction("A;P;85"));
            Console.Out.WriteLine(convoy.Transaction("S;5"));
            Console.In.ReadLine();
        }
    }
}
