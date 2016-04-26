namespace Exceptions
{
    using System.Collections.Generic;
    using System.Data.SqlTypes;
    using System.Text;

    using global::Exceptions.Models;

    public class Exceptions
    {
        public static bool CheckPrime(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("Input number should be positive");
            }

            bool isPrime = true;
            int maxDivisor = (int)Math.Sqrt(number);
            for (int divisor = 2; divisor <= maxDivisor; divisor++)
            {
                if (number % divisor == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            return isPrime;
        }

        public static string ExtractEnding(string str, int count)
        {
            if (count > str.Length)
            {
                throw new ArgumentException("Count should not be greater than length of string");
            }

            StringBuilder result = new StringBuilder();
            for (int i = str.Length - count; i < str.Length; i++)
            {
                result.Append(str[i]);
            }

            return result.ToString();
        }

        public static void Main()
        {
            // var substr = Subsequence("Hello!".ToCharArray(), 2, 3);
            // Console.WriteLine(substr);

            // var subarr = Subsequence(new[] { -1, 3, 2, 1 }, 0, 2);
            // Console.WriteLine(string.Join(" ", subarr));

            // var allarr = Subsequence(new[] { -1, 3, 2, 1 }, 0, 4);
            // Console.WriteLine(string.Join(" ", allarr));

            // var emptyarr = Subsequence(new[] { -1, 3, 2, 1 }, 0, 0);
            // Console.WriteLine(string.Join(" ", emptyarr));

            // Console.WriteLine(ExtractEnding("I love C#", 2));
            // Console.WriteLine(ExtractEnding("Nakov", 4));
            // Console.WriteLine(ExtractEnding("beer", 4));
            // Console.WriteLine(ExtractEnding("Hi", 100));

            // try
            // {
            // CheckPrime(23);
            // Console.WriteLine("23 is prime.");
            // }
            // catch (Exception ex)
            // {
            // Console.WriteLine("23 is not prime");
            // }

            // try
            // {
            // CheckPrime(33);
            // Console.WriteLine("33 is prime.");
            // }
            // catch (Exception ex)
            // {
            // Console.WriteLine("33 is not prime");
            // }

            // List<IExam> peterExams = new List<IExam>
            // {
            // new SimpleMathExam(2), 
            // new CSharpExam(55), 
            // new CSharpExam(100), 
            // new SimpleMathExam(1), 
            // new CSharpExam(0)
            // };
            // Student peter = new Student("Peter", "Petrov", peterExams);
            // double peterAverageResult = peter.CalcAverageExamResultInPercents();
            // Console.WriteLine("Average results = {0:p0}", peterAverageResult);
            ExamResult res = new ExamResult(-1, 2, 3, "drundrun");
        }

        public static T[] Subsequence<T>(T[] array, int startIndex, int count)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }

            if (startIndex < 0 || startIndex >= array.Length)
            {
                throw new ArgumentOutOfRangeException("Start index should be greater than 0 and less than input tarray lenght");
            }

            if (count <= 0)
            {
                throw new ArgumentOutOfRangeException("Count shuld be positive number");
            }

            if (startIndex + count >= array.Length)
            {
                throw new InvalidOperationException("Count of chars after given index is greater than the rest of its lenght");
            }

            List<T> result = new List<T>();
            for (int i = startIndex; i < startIndex + count; i++)
            {
                result.Add(array[i]);
            }

            return result.ToArray();
        }
    }
}
