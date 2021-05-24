using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoughtsAndCrosses.Models
{
    public class Game
    {
        public string player1, player2;

        //Keep track whos turn starting with player 1
        public bool player1Turn;

        //Instance of game board for play
        public Board gameBoard;

        //Keep track of turns - max 9
        public int turns;

        //State of gameplay set to true to allow loop for game to be played continuously until app stopped 
        public bool gameRunning;

        public Game()
        {
            player1 = "";
            player2 = "";
            gameBoard = new Board();
            turns = 0;
            player1Turn = true;
            gameRunning = true;
        }

        public void Start()
        {
            while (gameRunning)
            {
                NewGame();

                Console.WriteLine("Player 1 name:");

                player1 = Console.ReadLine();

                Console.WriteLine("Player 2 name:");

                player2 = Console.ReadLine();

                Play();
            }
        }

        public void NewGame()
        {
            //Reset conditions for new game
            gameBoard = new Board();
            turns = 0;
            player1 = "";
            player2 = "";
            gameRunning = true;
            player1Turn = true;
            //Show empty board to players
            gameBoard.GetBoard();
        }

        public void Play()
        {
            while (gameRunning)
            {
                //Player one chooses row
                int row = ChooseRow();

                //If row is valid then chooses point on row and checks if players has won
                if (row != 0)
                {
                    ChoosePoint(row);
                    if (HasWon())
                    {
                        //Based on amount of turns, the player is calculated and winning message is displayed
                        if (turns % 2 == 0)
                        {
                            Console.WriteLine("{0} has won, congratulations!", player1);
                        }
                        else
                        {
                            Console.WriteLine("{0} has won, congratulations!", player2);
                        }
                        break;
                    }

                    //Change players turns
                    player1Turn = !player1Turn;

                    //Increase amount of turns to calculate at end of game
                    turns++;


                    //Max amount of turns reached
                    if (turns >= 9)
                    {
                        Console.WriteLine("Game tied");
                        break;
                    }
                }

                //Invalid input from player to re calls method to choose a new row
                if (row == 0)
                {
                    Console.WriteLine("Please try again");
                    ChooseRow();
                }

                //Show the board in updated state to the player
                gameBoard.GetBoard();

            }

            Console.WriteLine("Press a key to restart the game");
            Console.ReadKey(true);
        }

        public int ChooseRow()
        {
            Console.WriteLine("Please type a number for the row you would like to choose, from top to bottom");
            string choice = Console.ReadLine();
            return gameBoard.ChooseRow(choice);
        }

        public void ChoosePoint(int row)
        {
            Console.WriteLine("Please choose a point on the row you have just selected, from left to right");
            string pointChoice = Console.ReadLine();

            int point;

            if (int.TryParse(pointChoice, out point))
            {
                UpdateGrid(row, point, turns);
            }
            else
            {
                Console.WriteLine("Please try again");
                ChoosePoint(row);
            }

        }

        public void UpdateGrid(int row, int point, int turns)
        {
            int selection = gameBoard.rows[row - 1].ChoosePointOnRow(point, turns);

            if (selection == 0)
            {
                Console.WriteLine("Please try again");
                ChoosePoint(row);
            }
        }

        public bool HasWon()
        {
            //set winning condition to true as default
            bool hasWon = true;

            //Check if any of the winning patters have been met
            if (HasWonHorizontally(hasWon) || HasWonVertically(hasWon) || HasWonDiagonally(hasWon))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool HasWonHorizontally(bool hasWon)
        {
            for (int i = 0; i < gameBoard.rows.Length; ++i)
            {
                int[] points = gameBoard.rows[i].points;
                int checkPoint = points[0];

                for (int j = 0; j < points.Length; ++j)
                {
                    if (points[j] != checkPoint)
                    {
                        hasWon = false;
                        break;
                    }
                }

                if (hasWon)
                {
                    return true;
                }
            }
            return hasWon;
        }

        public bool HasWonVertically(bool hasWon)
        {
            int[] points = gameBoard.rows[0].points;
            for (int i = 0; i < 3; ++i)
            {
                int checkPoint = points[i];
                for (int j = 0; j < 3; ++j)
                {
                    if (gameBoard.rows[j].points[i] != checkPoint)
                    {
                        hasWon = false;
                        break;
                    }
                }
                if (hasWon)
                {
                    return true;
                }
            }
            return hasWon;
        }

        public bool HasWonDiagonally(bool hasWon)
        {
            int firstSpace = gameBoard.rows[0].points[0];
            int thirdSpace = gameBoard.rows[0].points[2];

            for (int i = 0; i < 3; ++i)
            {
                if (gameBoard.rows[i].points[i] != firstSpace)
                {
                    hasWon = false;
                    break;
                }
            }
            if (hasWon)
            {
                return true;
            }
            for (int i = 0; i < 3; ++i)
            {
                if (gameBoard.rows[i].points[2 - i] != thirdSpace)
                {
                    hasWon = false;
                    break;
                }
            }
            if (hasWon)
            {
                return true;
            }
            return hasWon;
        }
    }
}
