namespace Client
{
    using System;
    using System.Collections.Generic;

    using BusinessLogic;

    using DataAccess;
    class Program
    {
        static void Main(string[] args)
        {
            Convoy convoy;
            List<string> operationList;
            using (ConvoyReader convoyReader = new ConvoyReader(@"..\..\..\train1.txt"))
            {
                convoyReader.ReadFile();
                convoy = new Convoy(convoyReader.LocomotiveInfo);
                operationList = convoyReader.OperationList;
            }
            Console.Out.WriteLine(operationList.Count);
            Console.Out.WriteLine(convoy.Locomotive);
            Console.Out.WriteLine(convoy.Transaction("A;M;10500"));
            Console.Out.WriteLine(convoy.Transaction("A;M;11111"));
            Console.Out.WriteLine(convoy.Transaction("A;P;85"));
            Console.Out.WriteLine(convoy.WagonStack.Count);
            //Console.Out.WriteLine(convoy.Transaction("S;5"));
            Console.In.ReadLine();
        }
    }
}
