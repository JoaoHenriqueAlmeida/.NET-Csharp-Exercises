namespace TikTakToe;

public class TikTakToeGame
{
    public char[,] board = new char[3, 3] { { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } };
    public char currentPlayer = 'x';
    public char winner = ' ';

    public void printBoard()
    {
        for (int xAxis = 0; xAxis < 3; xAxis++)
        {
            for (int yAxis = 0; yAxis < 3; yAxis++)
            {
                if (yAxis != 2)
                {
                    Console.Write(board[xAxis, yAxis] + " ");
                }
                else
                {
                    Console.Write(board[xAxis, yAxis]);
                }
            }
            Console.WriteLine("");
        }
    }

    public void makeMove(int line, int column, char player)
    {
        board[line, column] = player;
    }
    
    private void checkRows() {
        
    }
    
    private void checkColumns() {

    }
    
    private void checkDiagonals() {
        
    }

    public bool isGameOver()
    {
        checkRows();
        checkColumns();
        checkDiagonals();
        return true;
    }

    public void printResults()
    {
        throw new NotImplementedException();
    }

    public char getCurrentPlayer()
    {
        return currentPlayer;
    }

    public int[] getPlayerEntry()
    {
        Console.WriteLine("Jogador " + currentPlayer + " informe a linha:");
        string input = Console.ReadLine() ?? "";
        int line = int.Parse(input);

        Console.WriteLine("Jogador " + currentPlayer + " informe a coluna:");
        input = Console.ReadLine() ?? "";
        int column = int.Parse(input);

        return new int[] { line, column };
    }

    public void changePlayer()
    {
        if (currentPlayer == 'x')
        {
            currentPlayer = 'o';
        }
        else
        {
            currentPlayer = 'x';
        }
    }
}
