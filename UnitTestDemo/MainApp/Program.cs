using System;

// Handleiding: https://docs.microsoft.com/en-us/visualstudio/test/create-a-unit-test-project?view=vs-2019

namespace MainApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Berekeningen berekeningen = new Berekeningen();

            double dResult = berekeningen.AddTwoNumbers(1.0, 2.0);
            long iResult = berekeningen.AddTwoNumbers(3, 4);
            float fResult = berekeningen.AddTwoNumbers(5f, 6f);  // add letter f to indicate FLOAT (compiler trick)

            Console.WriteLine("Resultaten: {0} / {1} / {2}", dResult, iResult, fResult);
            
        }
    }
}