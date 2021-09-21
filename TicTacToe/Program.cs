using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Program
    {
        static int _turnCount = 1;
        static int playerThatWon;
        static int[] gameBoard = new int[9];
        static void Main(string[] args)
        {

            //display game board

            gameBoard[0] = 0;
            gameBoard[1] = 0;
            gameBoard[2] = 0;
            gameBoard[3] = 0;
            gameBoard[4] = 0;
            gameBoard[5] = 0;
            gameBoard[6] = 0;
            gameBoard[7] = 0;
            gameBoard[8] = 0;

            int playerOne;
            int playerTwo;
            
            List<int> selected = new List<int>();

            //while whoWon method equals 0, therefore, there has not been a winner yet
            while (whoWon() == 0)
            {
                displayGameBoard();

                Console.WriteLine("Player One: Enter a number 0 - 8: ");
                playerOne = int.Parse(Console.ReadLine());
                
                //if selection not in list then valid selection = true
                if (selected.Contains(playerOne))
                {
                    bool validSelection = false;
                    while (!validSelection)
                    {
                        Console.WriteLine("This spot is taken. Try again!");
                        playerOne = int.Parse(Console.ReadLine());
                        if (!selected.Contains(playerOne)) validSelection = true;

                    }
                }
                Console.WriteLine("You chose " + playerOne);              
                gameBoard[playerOne] = 1;
                selected.Add(playerOne);


                if (whoWon() == 1)
                {
                    playerThatWon = 1;
                    break;
                }
                _turnCount++;
                displayGameBoard();


                
                Console.WriteLine("Player Two: Enter a number 0 - 8: ");
                playerTwo = int.Parse(Console.ReadLine());

                if (selected.Contains(playerTwo))
                {
                    bool validSelection = false;
                    while (!validSelection)
                    {
                        Console.WriteLine("This spot is taken. Try again!");
                        playerTwo = int.Parse(Console.ReadLine());
                        if (!selected.Contains(playerTwo)) validSelection = true;
                    }
                }
                gameBoard[playerTwo] = 2;
                selected.Add(playerTwo);
                Console.WriteLine("Player two chose " + playerTwo);               
                
                if (whoWon() == 2)
                {
                    playerThatWon = 2;
                    break;
                }
                _turnCount++;

            }            

            displayGameBoard();

            if (playerThatWon == 1 || playerThatWon == 2)
            {
                Console.WriteLine("Player " + playerThatWon + " is the winner!\n Press enter to exit...");
            }
            else
            {
                Console.WriteLine("There was no winner this time. Play again!\n Press enter to exit...");
            }

            Console.ReadLine();
        }

        private static void displayGameBoard()
        {
            for (int i = 0; i < 9; i++)
            {
                //mark X or O for each square

                //0 is empty, player 1 = 1, player 2 = 2
                if (gameBoard[i] == 0)
                {
                    Console.Write("-");
                }
                if (gameBoard[i] == 1)
                {
                    Console.Write("X");
                }
                if (gameBoard[i] == 2)
                {
                    Console.Write("O");
                }
                //print a line every 3rd char
                if (i == 2 || i == 5 || i == 8)
                {
                    Console.WriteLine();
                }
            }
        }

        private static int whoWon()
        {
            if(gameBoard[0] == gameBoard[1] && gameBoard [1] == gameBoard[2])
            {
                return gameBoard[0];
            }
            if(gameBoard[3] == gameBoard[4] && gameBoard[4] == gameBoard[5])
            {
                return gameBoard[3];
            }
            if(gameBoard[6] == gameBoard[7] && gameBoard[7] == gameBoard[8])
            {
                return gameBoard[6];
            }
            if(gameBoard[0] == gameBoard[3] && gameBoard[3] == gameBoard[6])
            {
                return gameBoard[0];
            }
            if (gameBoard[1] == gameBoard[4] && gameBoard[4] == gameBoard[7])
            {
                return gameBoard[1];
            }
            if(gameBoard[2] == gameBoard[5] && gameBoard[5] == gameBoard[8])
            {
                return gameBoard[2];
            }
            if(gameBoard[0] == gameBoard[4] && gameBoard[4] == gameBoard[8])
            {
                return gameBoard[1];
            }
            if(gameBoard[2] == gameBoard[4] && gameBoard[4] == gameBoard[6])
            {
                return gameBoard[2];
            }
            if(_turnCount == 9)
            {
                return 3;
            }
            
            return 0;
        }


    }
}

