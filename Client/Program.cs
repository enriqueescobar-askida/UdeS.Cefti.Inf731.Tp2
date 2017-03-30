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
            Console.Out.WriteLine(convoy);
            Console.In.ReadLine();
        }
    }
}
