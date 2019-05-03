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
        public static Point TowerPos;
        public static int Cash;

        public static bool IsOver;

        public static Keys KeyPressed;
        public static int MapWidth => Map.GetLength(0);
        public static int MapHeight => Map.GetLength(1);


        // Оставила на случай, если захотим карту создавать не из готовых
        public static void CreateMap()
        {
            Map = CreatureMapCreator.CreateMap(19, new Point(){X = 9, Y = 9});
            Map[8, 8] = new Wall(2);
        }

        public static void CreateMapPreset()
        {
            Map = CreatureMapCreator.CreateMapPreset(testMap);
            TowerPos = GetTowerPos();
            Tower = (Tower)Map[TowerPos.X, TowerPos.Y];
        }

        private static Point GetTowerPos()
        {
            for (int x = 0; x < MapWidth; x++)
            for (int y = 0; y < MapHeight; y++)
            {
                if (Map[x, y] is Tower)
                    return new Point(x, y);
            }
            return new Point(-1, -1);
        }

        private const string testMap = @"
                 
                 
        WW       
        WT       
                 
                 ";
    }
}