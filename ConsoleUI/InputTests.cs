using BattleShipsLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    public class InputTests
    {
        public static string ValidMapPointTest(string input, List<MapPointModel> playerMap)
        {
            string output = input;
            bool inputFound = false;

            while (inputFound == false)
            {
                foreach (MapPointModel point in playerMap)
                {
                    if (output == point.Position)
                    {
                        inputFound = true;
                    }
                }

                if (inputFound == false)
                {
                    Console.WriteLine($"Input is invalid. Please enter a valid position on the grid (A1-E5)");
                    output = Console.ReadLine();
                }
            }

            return output;
        }
        public static string OccupiedPointTest(string input, List<MapPointModel> playerMap)
        {
            string output = input;
            bool pointOccupied = false;

            do
            {
                pointOccupied = false;

                foreach (MapPointModel point in playerMap)
                {
                    if (output == point.Position && point.Status == "Floating")
                    {
                        Console.WriteLine("You have already placed a ship here. Please choose a different position on the grid (A1-E5)");
                        pointOccupied = true;
                        output = Console.ReadLine();
                        output = InputTests.ValidMapPointTest(output, playerMap);
                    }
                }
            }
            while (pointOccupied == true);

            return output;
        }
    }
    
}
