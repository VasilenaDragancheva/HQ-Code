namespace ConsoleApplication1
{
    using System;

    public class MatricesMultiplyProgram
    {
        public static void Main(string[] args)
        {
            var matrix1 = new double[,] { { 1, 3 }, { 5, 7 } };
            var matrix2 = new double[,] { { 4, 2 }, { 1, 5 } };
            var resultMatrix = MultiplyMatrices(matrix1, matrix2);

            for (int row = 0; row < resultMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < resultMatrix.GetLength(1); col++)
                {
                    Console.Write(resultMatrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }

        public static double[,] MultiplyMatrices(double[,] matrix1, double[,] matrix2)
        {
            if (matrix1.GetLength(1) != matrix2.GetLength(0))
            {
                throw new Exception("Error!");
            }

            var index = matrix1.GetLength(1);
            var matrixResult = new double[matrix1.GetLength(0), matrix2.GetLength(1)];
            for (int row = 0; row < matrixResult.GetLength(0); row++)
            {
                for (int col = 0; col < matrixResult.GetLength(1); col++)
                {
                    for (int i = 0; i < index; i++)
                    {
                        matrixResult[row, col] += matrix1[row, i] * matrix2[i, col];
                    }
                }
            }

            return matrixResult;
        }
    }
}