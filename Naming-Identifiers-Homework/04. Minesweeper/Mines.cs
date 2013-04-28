using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Minesweeper
{
    static void Main()
    {
        string command = string.Empty;
        char[,] field = CreateGameField();
        char[,] mines = LoadMinesFields();
        int counter = 0;
        bool isExplosion = false;
        List<Player> winners = new List<Player>(6);
        int row = 0;
        int coll = 0;
        bool isPlaying = true;
        const int turns = 35;
        bool isWinner = false;

        do
        {
            if (isPlaying)
            {
                Console.WriteLine("Let's play “Minesweeper”. Try your look to open field without mines.\n" +
                "\nCommand: \n 'top' - show the rating,\n 'restart' - starts new game,\n 'exit' - stop the game!");
                DrowFenceOfGameField(field);
                isPlaying = false;
            }
            Console.Write("Type row and coll: ");
            command = Console.ReadLine().Trim();
            if (command.Length >= 3)
            {
                if (int.TryParse(command[0].ToString(), out row) &&
                int.TryParse(command[2].ToString(), out coll) &&
                    row <= field.GetLength(0) && coll <= field.GetLength(1))
                {
                    command = "turn";
                }
            }
            switch (command)
            {
                case "top":
                    SavePlayerRating(winners);
                    break;
                case "restart":
                    field = CreateGameField();
                    mines = LoadMinesFields();
                    DrowFenceOfGameField(field);
                    isExplosion = false;
                    isPlaying = false;
                    break;
                case "exit":
                    Console.WriteLine("Bye, bye!");
                    break;
                case "turn":
                    if (mines[row, coll] != '*')
                    {
                        if (mines[row, coll] == '-')
                        {
                            YourTurn(field, mines, row, coll);
                            counter++;
                        }
                        if (turns == counter)
                        {
                            isWinner = true;
                        }
                        else
                        {
                            DrowFenceOfGameField(field);
                        }
                    }
                    else
                    {
                        isExplosion = true;
                    }
                    break;
                default:
                    Console.WriteLine("\nError! Invalid command\n");
                    break;
            }
            if (isExplosion)
            {
                DrowFenceOfGameField(mines);
                Console.WriteLine("Sorry! You died with {0} points.\n", counter);
                Console.WriteLine("Enter you nickname: ");
                string nickname = Console.ReadLine();
                Player player = new Player(nickname, counter);
                if (winners.Count < 5)
                {
                    winners.Add(player);
                }
                else
                {
                    for (int i = 0; i < winners.Count; i++)
                    {
                        if (winners[i].Points < player.Points)
                        {
                            winners.Insert(i, player);
                            winners.RemoveAt(winners.Count - 1);
                            break;
                        }
                    }
                }
                winners.Sort((Player playerFirst, Player playerSecond) => playerSecond.Name.CompareTo(playerFirst.Name));
                winners.Sort((Player playerFirst, Player playerSecond) => playerSecond.Points.CompareTo(playerFirst.Points));
                SavePlayerRating(winners);

                field = CreateGameField();
                mines = LoadMinesFields();
                counter = 0;
                isExplosion = false;
                isPlaying = true;
            }
            if (isWinner)
            {
                Console.WriteLine("\nCongratulations, you won the game!");
                DrowFenceOfGameField(mines);
                Console.WriteLine("Enter your name: ");
                string winnerName = Console.ReadLine();
                Player winnerResult = new Player(winnerName, counter);
                winners.Add(winnerResult);
                SavePlayerRating(winners);
                field = CreateGameField();
                mines = LoadMinesFields();
                counter = 0;
                isWinner = false;
                isPlaying = true;
            }
        }
        while (command != "exit");
        Console.WriteLine("All rights reserved!");
        Console.WriteLine("Good luck.");
        Console.Read();
    }

    private static void SavePlayerRating(List<Player> points)
    {
        Console.WriteLine("\nPoints:");
        if (points.Count > 0)
        {
            for (int i = 0; i < points.Count; i++)
            {
                Console.WriteLine("{0}. {1} --> {2} cells",
                    i + 1, points[i].Name, points[i].Points);
            }
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("Empty rating!\n");
        }
    }

    private static void YourTurn(char[,] field, char[,] mines, int row, int coll)
    {
        char minesCount = PrepareNumberOfMines(mines, row, coll);
        mines[row, coll] = minesCount;
        field[row, coll] = minesCount;
    }

    private static void DrowFenceOfGameField(char[,] board)
    {
        int row = board.GetLength(0);
        int coll = board.GetLength(1);
        Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
        Console.WriteLine("   ---------------------");
        for (int i = 0; i < row; i++)
        {
            Console.Write("{0} | ", i);
            for (int j = 0; j < coll; j++)
            {
                Console.Write(string.Format("{0} ", board[i, j]));
            }
            Console.Write("|");
            Console.WriteLine();
        }
        Console.WriteLine("   ---------------------\n");
    }

    private static char[,] CreateGameField()
    {
        int boardRows = 5;
        int boardColumns = 10;
        char[,] board = new char[boardRows, boardColumns];
        for (int i = 0; i < boardRows; i++)
        {
            for (int j = 0; j < boardColumns; j++)
            {
                board[i, j] = '?';
            }
        }

        return board;
    }

    private static char[,] LoadMinesFields()
    {
        int row = 5;
        int coll = 10;
        char[,] gameField = new char[row, coll];

        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < coll; j++)
            {
                gameField[i, j] = '-';
            }
        }

        List<int> mines = new List<int>();
        while (mines.Count < 15)
        {
            Random random = new Random();
            int minesCoords = random.Next(50);
            if (!mines.Contains(minesCoords))
            {
                mines.Add(minesCoords);
            }
        }

        foreach (int mine in mines)
        {
            int mineColl = (mine / coll);
            int mineRow = (mine % coll);
            if (mineRow == 0 && mine != 0)
            {
                mineColl--;
                mineRow = coll;
            }
            else
            {
                mineRow++;
            }
            gameField[mineColl, mineRow - 1] = '*';
        }

        return gameField;
    }

    private static void LoadSafetyFields(char[,] field)
    {
        int coll = field.GetLength(0);
        int row = field.GetLength(1);

        for (int i = 0; i < coll; i++)
        {
            for (int j = 0; j < row; j++)
            {
                if (field[i, j] != '*')
                {
                    char cellContent = PrepareNumberOfMines(field, i, j);
                    field[i, j] = cellContent;
                }
            }
        }
    }

    private static char PrepareNumberOfMines(char[,] field, int row, int coll)
    {
        int couter = 0;
        int rows = field.GetLength(0);
        int colls = field.GetLength(1);

        if (row - 1 >= 0)
        {
            if (field[row - 1, coll] == '*')
            {
                couter++;
            }
        }
        if (row + 1 < rows)
        {
            if (field[row + 1, coll] == '*')
            {
                couter++;
            }
        }
        if (coll - 1 >= 0)
        {
            if (field[row, coll - 1] == '*')
            {
                couter++;
            }
        }
        if (coll + 1 < colls)
        {
            if (field[row, coll + 1] == '*')
            {
                couter++;
            }
        }
        if ((row - 1 >= 0) && (coll - 1 >= 0))
        {
            if (field[row - 1, coll - 1] == '*')
            {
                couter++;
            }
        }
        if ((row - 1 >= 0) && (coll + 1 < colls))
        {
            if (field[row - 1, coll + 1] == '*')
            {
                couter++;
            }
        }
        if ((row + 1 < rows) && (coll - 1 >= 0))
        {
            if (field[row + 1, coll - 1] == '*')
            {
                couter++;
            }
        }
        if ((row + 1 < rows) && (coll + 1 < colls))
        {
            if (field[row + 1, coll + 1] == '*')
            {
                couter++;
            }
        }
        return char.Parse(couter.ToString());
    }
}

