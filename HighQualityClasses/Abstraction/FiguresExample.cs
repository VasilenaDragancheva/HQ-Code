namespace Abstraction
{
    using System;

    public class FiguresExample
    {
        public static void Main()
        {
            Circle circle = new Circle(5);
            Rectangle rect = new Rectangle(2, 3);
            Console.WriteLine(circle);
            Console.WriteLine(rect);       
        }
    }
}