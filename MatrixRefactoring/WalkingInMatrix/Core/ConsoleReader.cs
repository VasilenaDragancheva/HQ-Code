namespace WalkInMatrix.Core
{
    using System;

    using WalkInMatrix.Contracts;

    public class ConsoleReader : IReader
    {
        public string Read()
        {
            string line = Console.ReadLine();
            return line;
        }
    }
}