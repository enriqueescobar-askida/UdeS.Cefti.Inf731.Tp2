namespace Client
{
    using System;
    using System.Collections.Generic;

    using BusinessLogic;

    using DataAccess;
    public class Program
    {
        static void Main(string[] args)
        {
            Convoy convoy;
            List<Operation> operationList;
            using (ConvoyReader convoyReader = new ConvoyReader(@"..\..\..\train1.txt"))
            {
                convoyReader.ReadFile();
                convoy = new Convoy(convoyReader.LocomotiveInfo);
                operationList = convoyReader.OperationList;
            }
            Console.Out.WriteLine("BOO " + operationList[1].ItsAdding);
            Console.Out.WriteLine(convoy.Locomotive);
            Console.Out.WriteLine("BEE " + convoy.Transaction(operationList[1]));
            Console.Out.WriteLine(operationList.Count);
            foreach (Operation o in operationList)
                Console.Out.WriteLine(o.Command);
            /*Console.Out.WriteLine(convoy.Transaction("A;M;10500"));
            Console.Out.WriteLine(convoy.Transaction("A;M;11111"));
            Console.Out.WriteLine(convoy.Transaction("A;P;85"));*/
            //Console.Out.WriteLine(convoy.Transaction("S;5"));
            /*foreach (Operation o in operationList)
                Console.Out.WriteLine(o.Command);*/
            /*Console.Out.WriteLine(convoy.WagonStack.Count);*/
            Console.In.ReadLine();
        }
    }
}
