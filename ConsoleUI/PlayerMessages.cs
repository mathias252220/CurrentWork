using BattleShipsLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    public class PlayerMessages
    {
        public static void WelcomemMessage()
        {
            Console.WriteLine("Welcome to the Battle Ships App by Mathias.");
            Console.WriteLine("The rules are simple:");
            Console.WriteLine("This is a 2 player game.");
            Console.WriteLine("Each player places 5 ships on a 5x5 grid of 25 points (named A1-E5).");
            Console.WriteLine("The players take turns shooting at eachother's ships.");
            Console.WriteLine("First player to take out the opponent's ships wins!");
            Console.Write("Ready to play? Hit Enter!");
            Console.ReadLine();
            Console.Clear();
        }
        public static void DisplayMapMessage(string playerName, List<MapPointModel> playerMap, List<MapPointModel> opponentPlayerMap)
        {
            Console.WriteLine($"{playerName}'s turn!");
            Console.WriteLine("Your opponents ships:");
                MapGeneration.ShowOpponentMap(opponentPlayerMap);
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Your ships:");
            MapGeneration.ShowPlayerMap(playerMap);
            Console.WriteLine();
            Console.WriteLine();
        }
        public static void AnnounceWinnerMessage(bool player1Floating, bool player2Floating)
        {
            if (player1Floating == false && player2Floating == true)
            {
                Console.WriteLine("Player 1 has lost all ships! Player 2 has won!");
            }
            else if (player1Floating == true && player1Floating == false)
            {
                Console.WriteLine("Player 2 has lost all ships! Player 1 has won!");
            }
            else if (player1Floating == false && player2Floating == false)
            {
                Console.WriteLine("Both player 1 and player 2 has lost all ships! It is a draw!");
            }
            Console.WriteLine();
        }
        public static void GoodbyeMessage()
        {
            Console.WriteLine("Thank you for using the Battle Ships App by Mathias");
            Console.Write("Have a nice day!");
            Console.ReadLine();
        } 
    }
    
}
