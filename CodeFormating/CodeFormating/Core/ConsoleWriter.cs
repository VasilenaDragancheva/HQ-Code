namespace CodeFormating.Core
{
    using System;
    using CodeFormating.Contracts;

    public class ConsoleWriter : IWriter
    {
        public void WriteOutput(string output)
        {
            Console.WriteLine(output);
        }
    }
}