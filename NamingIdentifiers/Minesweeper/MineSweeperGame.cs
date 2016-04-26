namespace Minesweeper
{
    using System;
    using System.Collections.Generic;

    public class Minesweeper
    {
        private const int MaxPoints = 35;
        private const int BoardRows = 5;
        private const int BoardColumns = 10;
        private const int MinesCountOnBoard = 15;

        private static void Main(string[] args)
        {
            List<Player> topScoredPlayers = new List<Player>(6);
            char[,] gameBoard = InitializeGameBoard();
            char[,] gameBoardWithMines = InitializeGameBoardWithMines();

            int currentPoints = 0;
            int row = 0;
            int col = 0;

            bool isNewGame = true;
            bool gameIsWon = false;
            bool hitMine = false;

            string command = string.Empty;
            do
            {
                if (isNewGame)
                {
                    Console.WriteLine("Let`s play MineSweeper!Try to find fields without mines.To view scores write top.To restart game write restart.To exit game write exit");
                    DrawGameBoard(gameBoard);
                    isNewGame = false;
                }

                Console.Write("Choose row and column : ");
                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) && int.TryParse(command[2].ToString(), out col) &&
                        row <= gameBoard.GetLength(0) && col <= gameBoard.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        RatingsPreview(topScoredPlayers);
                        break;
                    case "restart":
                        gameBoard = InitializeGameBoard();
                        gameBoardWithMines = InitializeGameBoardWithMines();
                        DrawGameBoard(gameBoard);
                        break;
                    case "exit":
                        Console.WriteLine("Bye!");
                        break;
                    case "turn":
                        if (gameBoardWithMines[row, col] != '*')
                        {
                            if (gameBoardWithMines[row, col] == '-')
                            {
                                NextMove(gameBoard, gameBoardWithMines, row, col);
                                currentPoints++;
                            }

                            if (MaxPoints == currentPoints)
                            {
                                gameIsWon = true;
                            }
                            else
                            {
                                DrawGameBoard(gameBoard);
                            }
                        }
                        else
                        {
                            hitMine = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nInvalid command!\n");
                        break;
                }

                if (hitMine)
                {
                    DrawGameBoard(gameBoardWithMines);
                    Console.WriteLine("You won {0} points. " + "Write your name ", currentPoints);
                    string playerName = Console.ReadLine();
                    Player player = new Player(playerName, currentPoints);

                    if (topScoredPlayers.Count >= 5)
                    {
                        topScoredPlayers.RemoveAt(topScoredPlayers.Count - 1);
                    }

                    topScoredPlayers.Add(player);
                    topScoredPlayers.Sort((Player r1, Player r2) => r2.Points.CompareTo(r1.Points));
                    topScoredPlayers.Sort((Player r1, Player r2) => r2.Name.CompareTo(r1.Name));

                    RatingsPreview(topScoredPlayers);

                    gameBoard = InitializeGameBoard();
                    gameBoardWithMines = InitializeGameBoardWithMines();
                    currentPoints = 0;
                    hitMine = false;
                    isNewGame = true;
                }

                if (gameIsWon)
                {
                    Console.WriteLine(string.Format("You have found {0} cells.YOU WON!!!", MaxPoints));
                    DrawGameBoard(gameBoardWithMines);
                    Console.WriteLine("Enter yor name: ");
                    string playerName = Console.ReadLine();
                    Player currentPlayer = new Player(playerName, currentPoints);
                    topScoredPlayers.Add(currentPlayer);
                    RatingsPreview(topScoredPlayers);
                    gameBoard = InitializeGameBoard();
                    gameBoardWithMines = InitializeGameBoardWithMines();
                    currentPoints = 0;
                    gameIsWon = false;
                    isNewGame = true;
                }
            }
            while (command != "exit");
            Console.WriteLine("Write enter to exit app!");
            Console.Read();
        }

        private static void RatingsPreview(List<Player> topRatedPlayers)
        {
            Console.WriteLine("\nScores:");
            if (topRatedPlayers.Count > 0)
            {
                for (int i = 0; i < topRatedPlayers.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} scores", i + 1, topRatedPlayers[i].Name, topRatedPlayers[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("No players!\n");
            }
        }

        private static void NextMove(char[,] gameBoard, char[,] mines, int row, int col)
        {
            char minesCount = MinesCount(mines, row, col);
            mines[row, col] = minesCount;
            gameBoard[row, col] = minesCount;
        }

        private static void DrawGameBoard(char[,] board)
        {
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int r = 0; r < rows; r++)
            {
                Console.Write("{0} | ", r);
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(string.Format("{0} ", board[r, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] InitializeGameBoard()
        {
            char[,] board = new char[BoardRows, BoardColumns];
            for (int r = 0; r < BoardRows; r++)
            {
                for (int c = 0; c < BoardColumns; c++)
                {
                    board[r, c] = '?';
                }
            }

            return board;
        }

        private static char[,] InitializeGameBoardWithMines()
        {
            char[,] gameBoard = new char[BoardRows, BoardColumns];
            for (int r = 0; r < BoardRows; r++)
            {
                for (int c = 0; c < BoardColumns; c++)
                {
                    gameBoard[r, c] = '-';
                }
            }

            List<int> minesNumbers = new List<int>();
            while (minesNumbers.Count < MinesCountOnBoard)
            {
                Random random = new Random();
                int number = random.Next(BoardRows * BoardColumns);
                if (!minesNumbers.Contains(number))
                {
                    minesNumbers.Add(number);
                }
            }

            foreach (int number in minesNumbers)
            {
                int row = number / BoardColumns;
                int col = number % BoardColumns;
                if (col == 0 && number != 0)
                {
                    row--;
                    col = BoardColumns;
                }
                else
                {
                    col++;
                }

                gameBoard[row, col - 1] = '*';
            }

            return gameBoard;
        }

        private static char MinesCount(char[,] gameBoard, int row, int col)
        {
            int minesCount = 0;
            int mines = 0;
            int rowPrevios = Math.Max(row - 1, 0);
            int rowNext = Math.Min(row + 1, gameBoard.GetLength(0));
            int colPrevios = Math.Max(col - 1, 0);
            int colNext = Math.Min(col + 1, gameBoard.GetLength(1));

            for (int r = rowPrevios; r <= rowNext; r++)
            {
                for (int c = colPrevios; c <= colNext; c++)
                {
                    if (r == row && c == col)
                    {
                        continue;
                    }

                    if (gameBoard[r, c] == '*')
                    {
                        mines++;
                    }
                }
            }

            return char.Parse(minesCount.ToString());
        }
    }
}