namespace OperatorPerformance
{
    using System.Collections.Generic;
    using System.Diagnostics;

    public class OperatorsPerformanceTester
    {
        public delegate string ExecuteOperationTest<T>(T number, int times);

        public static string FormatTableOutput(int number, int times, string operation)
        {
            var outputResult = new List<string>();

            ExecuteOperationTest<dynamic> testDelegate = null;
            switch (operation)
            {
                case "+":
                    testDelegate = TestAddOperation;
                    break;
                case "-":
                    testDelegate = TestSubtractOperation;
                    break;
                case "/":
                    testDelegate = TestDivideOperation;
                    break;
                case "*":
                    testDelegate = TestMultiplyOperation;
                    break;
                case "+1":
                    testDelegate = TestAdding1Operation;
                    break;
                case "pre":
                    testDelegate = TestPrefixIncrementOperation;
                    break;
                case "post":
                    testDelegate = TestPostfixIncrementOperation;
                    break;
            }

            if (testDelegate != null)
            {
                outputResult.Add(testDelegate(number, times));
                outputResult.Add(testDelegate((long)number, times));
                outputResult.Add(testDelegate((double)number, times));
                outputResult.Add(testDelegate((decimal)number, times));
            }

            return string.Join("    ", outputResult);
        }

        public static string TestAdding1Operation<T>(T number, int times)
        {
            var sw = new Stopwatch();
            dynamic value = number;
            sw.Start();
            for (int i = 0; i < times; i++)
            {
                value += 1;
            }

            sw.Stop();
            return sw.Elapsed.ToString();
        }

        public static string TestAddOperation<T>(T number, int times)
        {
            Stopwatch sw = new Stopwatch();
            dynamic result = number;
            dynamic value = number;
            sw.Start();
            for (int i = 0; i < times; i++)
            {
                result += value;
            }

            sw.Stop();
            return sw.Elapsed.ToString();
        }

        public static string TestDivideOperation<T>(T number, int times)
        {
            Stopwatch sw = new Stopwatch();
            dynamic result = number;
            dynamic value = number;
            sw.Start();
            for (int i = 0; i < times; i++)
            {
                result /= value;
            }

            sw.Stop();
            return sw.Elapsed.ToString();
        }

        public static string TestMultiplyOperation<T>(T number, int times)
        {
            Stopwatch sw = new Stopwatch();
            dynamic result = 0;
            dynamic value = number;
            sw.Start();
            for (int i = 0; i < times; i++)
            {
                result *= value;
            }

            sw.Stop();
            return sw.Elapsed.ToString();
        }

        public static string TestPostfixIncrementOperation<T>(T number, int times)
        {
            dynamic numberToIncrement = number;
            Stopwatch sw = new Stopwatch();

            sw.Start();
            for (int i = 0; i < times; i++)
            {
                numberToIncrement++;
            }

            sw.Stop();
            return sw.Elapsed.ToString();
        }

        public static string TestPrefixIncrementOperation<T>(T number, int times)
        {
            dynamic numberToIncrement = number;
            Stopwatch sw = new Stopwatch();

            sw.Start();
            for (int i = 0; i < times; i++)
            {
                ++numberToIncrement;
            }

            sw.Stop();
            return sw.Elapsed.ToString();
        }

        public static string TestSubtractOperation<T>(T number, int times)
        {
            Stopwatch sw = new Stopwatch();
            dynamic result = number;
            dynamic value = number;
            sw.Start();
            for (int i = 0; i < times; i++)
            {
                result -= value;
            }

            sw.Stop();
            return sw.Elapsed.ToString();
        }
    }
}