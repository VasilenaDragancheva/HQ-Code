namespace OperatorPerformance
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class Program
    {
        public static void Main(string[] args)
        {
            
            using (var writer = new StreamWriter(@"..\..\text.txt"))
            {
                var tableContent = new List<string>();
                int number = 100;
                int times = 500;
                string[] operators = { "+", "-", "/", "*", "+1", "post", "pre" };
                string[] types = { "int", "long", "double", "decimal" };

                tableContent.Add(string.Format("n=500    {0}", string.Join("    ", types)));
                for (int i = 0; i < operators.Length; i++)
                {
                    tableContent.Add(
                        string.Format(
                            "{0}    {1}",
                            operators[i],
                            OperatorsPerformanceTester.FormatTableOutput(number, times, operators[i])));
                }

                writer.WriteLine(string.Join(Environment.NewLine, tableContent));

                double doubleNumber = number;
                string log = MathFunctionPerformanceTester.DoubleTestMathLog(doubleNumber, times);
                string sin = MathFunctionPerformanceTester.DoubleTestMathSin(doubleNumber, times);
                string sqrt = MathFunctionPerformanceTester.DoubleTestMathSqrt(doubleNumber, times);

                writer.WriteLine("n=500    double");
                writer.WriteLine("Log    " + log);
                writer.WriteLine("Sin    " + sin);
                writer.WriteLine("Sqrt    " + sqrt);
            }
        }
    }
}