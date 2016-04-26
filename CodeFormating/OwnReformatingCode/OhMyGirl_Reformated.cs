namespace OwnReformatingCode
{
    using System;
    using System.Text;

    public class OhMyGirl_Reformated
    {
        public static void Execute(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            char[,] matrix = new char[n, n];
            int direction = 0;

            // 0->to the right 1-dows 2 left 3 up;
            // max moves in one direction; decremens on dircetion 3;
            int maxMoves = n - 1;
            int movesInDirection = 0;
            int row = 0;
            int col = 0;
            for (int i = 0; i < input.Length; i++)
            {
                matrix[row, col] = input[i];
                switch (direction)
                {
                    case 0:
                        col++;
                        break;
                    case 1:
                        row++;
                        break;
                    case 2:
                        col--;
                        break;
                    case 3:
                        row--;
                        break;
                }

                movesInDirection++;
                if (movesInDirection >= maxMoves)
                {
                    if (direction < 3)
                    {
                        movesInDirection = 0;
                        direction++;
                        if (direction == 3)
                        {
                            maxMoves--;
                        }

                        if (direction == 1 && i > (2 * n) - 2)
                        {
                            maxMoves--;
                        }

                        continue;
                    }

                    if (direction == 3)
                    {
                        direction = 0;
                        movesInDirection = 0;
                    }
                }
            }

            StringBuilder white = new StringBuilder();
            StringBuilder black = new StringBuilder();
            int index = 0;
            for (int r = 0; r < n; r++)
            {
                for (int c = 0; c < n; c++)
                {
                    if ((r % 2 == 0 && c % 2 == 0) || (r % 2 == 1 && c % 2 == 1))
                    {
                        white.Append(matrix[r, c]);
                    }
                    else
                    {
                        black.Append(matrix[r, c]);
                    }

                    index++;
                }
            }

            white.Append(black.ToString());

            bool isPalindrome = CheckPalindrome(white);
            string color = isPalindrome ? "#4FE000" : "#E0000F";
            Console.WriteLine(@"<div style='background-color:{0}'>{1}</div>", color, white.ToString());
        }

        private static bool CheckPalindrome(StringBuilder white)
        {
            string whiteString = white.ToString().ToLower();
            bool isPalindrome = false;
            StringBuilder left = new StringBuilder();
            StringBuilder right = new StringBuilder();

            for (int i = 0; i < whiteString.Length; i++)
            {
                if (char.IsLetter(whiteString[i]))
                {
                    left.Append(whiteString[i]);
                }
            }

            for (int i = whiteString.Length - 1; i >= 0; i--)
            {
                if (char.IsLetter(whiteString[i]))
                {
                    right.Append(whiteString[i]);
                }
            }

            isPalindrome = right.ToString() == left.ToString();
            return isPalindrome;
        }
    }
}