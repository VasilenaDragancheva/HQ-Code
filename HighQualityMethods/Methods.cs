namespace Methods
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Methods
    {
        public static double CalculateDistance(Point firstPoint, Point secondPoint)
        {
            double distance =
                Math.Sqrt(Math.Pow(secondPoint.X - firstPoint.X, 2) + Math.Pow(secondPoint.Y - firstPoint.Y, 2));
            return distance;
        }

        public static double CalculateDistance(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            return distance;
        }

        public static double CalculateTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("Sides of triangle should be positive");
            }

            double s = (a + b + c) / 2;
            double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));
            return area;
        }

        public static int FindMaxNumber(params int[] numbers)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException("numbers");
            }

            if (numbers.Length == 0)
            {
                throw new ArgumentException("There are no numbers");
            }

            int n = numbers.Length;
            int maxNumber = numbers[0];
            for (int i = 1; i < n; i++)
            {
                if (numbers[i] > maxNumber)
                {
                    maxNumber = numbers[i];
                }
            }

            return maxNumber;
        }

        public static void Main()
        {
            Console.WriteLine(CalculateTriangleArea(3, 4, 5));

            Console.WriteLine(NumberToDigit(5));

            Console.WriteLine(FindMaxNumber(5, -1, 3, 2, 14, 2, 3));

            PrintDoubleRoundToTwoDigits(1.3);
            PrintDoubleAsPercente(0.75);
            PrintNumberPadRight(2.30);

            double aX = 3;
            double aY = -1;
            double bX = 3;
            double bY = 2;
            Point a = new Point(aX, aY);
            Point b = new Point(bX, bY);
            double distance = CalculateDistance(a, b);
            double distanceSecond = CalculateDistance(aX, aY, bX, bY);
            Console.WriteLine("First method overload: " + distance);
            Console.WriteLine("Second method overload: " + distanceSecond);

            Point[] otherPoints = { new Point(3, 1), new Point(3, 6) };
            bool allPointsFormVertical = PointsFormVertical(otherPoints);
            bool allPointsFormHorizontal = PointsFormHorizontal(otherPoints);
            Console.WriteLine("Are points horizontal: " + allPointsFormHorizontal);
            Console.WriteLine("Are points vertical:" + allPointsFormVertical);

            Student peter = new Student("Peter", "Ivanov", "Sofia", new DateTime(1992, 3, 17));
            Student stella = new Student("Stella", "Markova", "Vidin", new DateTime(1993, 3, 11));
            Console.WriteLine("{0} older than {1} -> {2}", peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }

        public static string NumberToDigit(int number)
        {
            const int MinNumber = 0;
            const int MaxNumber = 9;
            if (number < MinNumber || number > MaxNumber)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("Number must be in range of {0} and {1}", MinNumber, MaxNumber));
            }

            List<string> digits = new List<string>
                                      {
                                          "zero", 
                                          "one", 
                                          "two", 
                                          "three", 
                                          "four", 
                                          "five", 
                                          "six", 
                                          "seven", 
                                          "eight", 
                                          "nine"
                                      };
            return digits[number];
        }

        public static bool PointsFormHorizontal(IEnumerable<Point> points)
        {
            if (points == null || points.Count() == 0)
            {
                throw new ArgumentNullException("No input points are supplied");
            }

            int differentValuesOfX = points.Select(point => point.X).Distinct().Count();
            int differentValuesOfY = points.Select(point => point.X).Distinct().Count();
            bool pointsFormHorizontal = differentValuesOfY == 1 && differentValuesOfX > 1;

            return pointsFormHorizontal;
        }

        public static bool PointsFormVertical(IEnumerable<Point> points)
        {
            if (points == null || points.Count() == 0)
            {
                throw new ArgumentNullException("No input points are supplied");
            }

            int differentValuesOfX = points.Select(point => point.X).Distinct().Count();
            int differentValuesOfY = points.Select(point => point.X).Distinct().Count();
            bool pointsFormVertical = differentValuesOfX == 1 && differentValuesOfY > 1;
            return pointsFormVertical;
        }

        public static void PrintDoubleAsPercente(double number)
        {
            Console.WriteLine("{0:p0}", number);
        }

        public static void PrintDoubleRoundToTwoDigits(double number)
        {
            Console.WriteLine("{0:f2}", number);
        }

        public static void PrintNumberPadRight(double number)
        {
            Console.WriteLine("{0,8}", number);
        }
    }
}