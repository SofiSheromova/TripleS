using System;
using System.Windows.Forms;

namespace TowerDefense
{
    public static class Game
    {
        public static ICreature[,] Map;
        public static int Cash;
        public static bool IsOver;

        public static Keys KeyPressed;
        public static int MapWidth => Map.GetLength(0);
        public static int MapHeight => Map.GetLength(1);

        public static void CreateMap()
        {
            var sizeMap = 19;
            var towerCoord = Tuple.Create(9, 9);
            Map = CreatureMapCreator.CreateMap(sizeMap, towerCoord);
        }
    }
}