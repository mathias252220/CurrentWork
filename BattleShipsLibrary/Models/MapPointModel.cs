using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipsLibrary.Models
{
    public class MapPointModel
    {
        public char Row { get; set; }
        public int Column { get; set; }
        public string Status { get; set; }
        public string Position
        {
            get 
            {
                return $"{Row}{Column}";
            }
        }
    }
}
