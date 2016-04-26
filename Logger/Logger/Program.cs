namespace Logger
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            DateTime dateTime = DateTime.Now;
            Console.WriteLine(dateTime.ToLongDateString());
            Console.WriteLine(dateTime.ToString("d"));
        }
    }
}