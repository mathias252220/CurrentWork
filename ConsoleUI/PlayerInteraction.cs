using BattleShipsLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    public class PlayerInteraction
    {
        public static void PlaceShips(List<MapPointModel> playerMap, string playerName)
        {
            for (int i = 1; i <= 5; i++)
            {
                Console.Write($"{playerName}, where would you like to place your #{i} ship?: ");
                string tempPosition = Console.ReadLine();
                tempPosition = InputTests.ValidMapPointTest(tempPosition, playerMap);
                tempPosition = InputTests.OccupiedPointTest(tempPosition, playerMap);

                foreach (MapPointModel point in playerMap)
                {
                    if (tempPosition == point.Position)
                    {
                        point.Status = "Floating";
                    }
                }
            }
            Console.Clear();
        }
        public static void ShootShips(List<MapPointModel> opponentMap, string playerName, List<MapPointModel> playerMap)
        {
            PlayerMessages.DisplayMapMessage(playerName, playerMap, opponentMap);

            Console.Write($"Please choose a position to shoot: ");
            string tempPosition = Console.ReadLine();
            tempPosition = InputTests.ValidMapPointTest(tempPosition, opponentMap);

            foreach (MapPointModel point in opponentMap)
            {
                if (tempPosition == point.Position && point.Status == "Floating")
                {
                    Console.WriteLine("You hit a ship!");
                    point.Status = "Sunk";
                }
                else if (tempPosition == point.Position && (point.Status == "Empty" || point.Status == "Fired"))
                {
                    Console.WriteLine("You missed!");
                    point.Status = "Fired";
                }
            }
            Console.ReadLine();
            Console.Clear();
        }
        public static bool CheckPlayerFloating(List<MapPointModel> playerMap)
        {
            bool player1Floating = false;
            foreach (MapPointModel point in playerMap)
            {
                if (point.Status == "Floating")
                {
                    player1Floating = true;
                }
            }

            return player1Floating;
        }
        public static (bool, bool) PlayGame(List<MapPointModel> player1Map, List<MapPointModel> player2Map)
        {
            bool player1Floating = true;
            bool player2Floating = true;

            while (player1Floating == true && player2Floating == true)
            {
                PlayerInteraction.ShootShips(player2Map, "Player 1", player1Map);
                PlayerInteraction.ShootShips(player1Map, "Player 2", player2Map);
                player1Floating = PlayerInteraction.CheckPlayerFloating(player1Map);
                player2Floating = PlayerInteraction.CheckPlayerFloating(player2Map);
            }

            return (player1Floating, player2Floating);
        }
    }
}
