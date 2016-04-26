namespace WalkInMatrix.Core
{
    using System;

    using WalkInMatrix.Contracts;

    public class ConsolePrinter : IPrinter
    {
        public void Print(string output)
        {
            Console.WriteLine(output);
        }
    }
}