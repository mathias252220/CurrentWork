using BattleShipsLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    public class MapGeneration
    {
        public static List<MapPointModel> MapGenerator()
        {
            List<MapPointModel> map = new List<MapPointModel>();

            for (char c = 'A'; c <= 'E'; c++)
            {
                for (int j = 1; j <= 5; j++)
                {
                    MapPointModel point = new MapPointModel();

                    point.Row = c;
                    point.Column = j;
                    point.Status = "Empty";
                    map.Add(point);
                }
            }
            return map;
        }
        public static void ShowPlayerMap(List<MapPointModel> map)
        {
            for (char c = 'A'; c <= 'E'; c++)
            {
                for (int j = 1; j <= 5; j++)
                {
                    foreach (MapPointModel point in map)
                    {
                        if (point.Row == c && point.Column == j && point.Status == "Empty")
                        {
                            Console.Write($"[{point.Position}] ");
                        }
                        else if (point.Row == c && point.Column == j && point.Status == "Fired")
                        {
                            Console.Write("[  ] ");
                        }
                        else if (point.Row == c && point.Column == j && point.Status == "Floating")
                        {
                            Console.Write("[ O] ");
                        }
                        else if (point.Row == c && point.Column == j && point.Status == "Sunk")
                        {
                            Console.Write("[ X] ");
                        }
                    }
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }
        public static void ShowOpponentMap(List<MapPointModel> map)
        {
            for (char c = 'A'; c <= 'E'; c++)
            {
                for (int j = 1; j <= 5; j++)
                {
                    foreach (MapPointModel point in map)
                    {
                        if (point.Row == c && point.Column == j && (point.Status == "Empty" || point.Status == "Floating"))
                        {
                            Console.Write($"[{point.Position}] ");
                        }
                        else if (point.Row == c && point.Column == j && point.Status == "Sunk")
                        {
                            Console.Write("[ X]");
                        }
                        else if (point.Row == c && point.Column == j && point.Status == "Fired")
                        {
                            Console.Write("[  ]");
                        }
                    }
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
