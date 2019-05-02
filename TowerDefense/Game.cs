using System;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace TowerDefense
{
    public static class Game
    {
        public static ICreature[,] Map;
        public static Tower Tower;
        public static int Cash;
        public static bool IsOver;

        public static Keys KeyPressed;
        public static int MapWidth => Map.GetLength(0);
        public static int MapHeight => Map.GetLength(1);
        

        public static void CreateMap()
        {
            Map = CreatureMapCreator.CreateMap(19, new Point(){X = 9, Y = 9});
        }
    }
}