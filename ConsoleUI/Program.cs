using BattleShipsLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            PlayerMessages.WelcomemMessage();

            List<MapPointModel> player1Map = MapGeneration.MapGenerator();
            List<MapPointModel> player2Map = MapGeneration.MapGenerator();

            PlayerInteraction.PlaceShips(player1Map, "Player 1");
            PlayerInteraction.PlaceShips(player2Map, "Player 2");

            (bool player1Floating, bool player2Floating) = PlayerInteraction.PlayGame(player1Map, player2Map);

            PlayerMessages.AnnounceWinnerMessage(player1Floating, player2Floating);

            PlayerMessages.GoodbyeMessage();
        }
    }
}
