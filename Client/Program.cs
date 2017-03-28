namespace Client
{
    using System;

    using DataAccess;
    class Program
    {
        static void Main(string[] args)
        {
            ConvoyReader convoyReader = new ConvoyReader(@"..\..\..\train1.txt");
            Console.Out.WriteLine(convoyReader);
            Console.In.ReadLine();
        }
    }
}
