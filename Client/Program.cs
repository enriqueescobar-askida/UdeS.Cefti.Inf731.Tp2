namespace Client
{
    using System;

    using BusinessLogic;

    using DataAccess;
    class Program
    {
        static void Main(string[] args)
        {
            ConvoyReader convoyReader = new ConvoyReader(@"..\..\..\train1.txt");
            convoyReader.ReadFile();
            Console.Out.WriteLine(convoyReader.LocomotiveInfo);
            Console.Out.WriteLine(convoyReader.OperationList.Count);
            Console.In.ReadLine();
            Convoy convoy = new Convoy(convoyReader.LocomotiveInfo);
        }
    }
}
