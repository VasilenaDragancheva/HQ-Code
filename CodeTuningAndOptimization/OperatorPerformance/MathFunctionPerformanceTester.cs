namespace OperatorPerformance
{
    using System;
    using System.Diagnostics;

    public static class MathFunctionPerformanceTester
    {
        public static string DecimalTestMathLog(decimal number, int times)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < times; i++)
            {
                number = (decimal)Math.Log((double)number);
            }

            sw.Stop();

            return sw.Elapsed   .ToString();
        }

        public static string DecimalTestMathSin(decimal number, int times)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < times; i++)
            {
                number = (decimal)Math.Sin((double)number);
            }

            sw.Start();
            return sw.Elapsed.ToString();
        }

        public static string DecimalTestMathSqrt(decimal number, int times)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < times; i++)
            {
                number = (decimal)Math.Sqrt((double)number);
            }

            sw.Start();
            return sw.Elapsed.ToString();
        }

        public static string DoubleTestMathLog(double number, int times)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < times; i++)
            {
                number = Math.Log(number);
            }

            sw.Stop();
            return sw.Elapsed.ToString();
        }

        public static string DoubleTestMathSin(double number, int times)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < times; i++)
            {
                number = Math.Sin(number);
            }

            sw.Start();
            return sw.Elapsed.ToString();
        }

        public static string DoubleTestMathSqrt(double number, int times)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < times; i++)
            {
                number = Math.Sqrt(number);
            }

            sw.Start();
            return sw.Elapsed.ToString();
        }
    }
}