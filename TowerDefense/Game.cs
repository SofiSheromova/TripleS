using System;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace TowerDefense
{
    public /*static*/ class Game
    {
        public ICreature[,] Map;
        public Tower Tower;
        public Point TowerPos;
        public int Cash;

        public static bool IsOver;

        public Keys KeyPressed;
        public int MapWidth => Map.GetLength(0);
        public int MapHeight => Map.GetLength(1);

        public Game(string level)
        {
            CreateMapPreset(level);
            Cash = 0;
            IsOver = false;
        }

        // Оставила на случай, если захотим карту создавать не из готовых
        public void CreateMap()
        {
            Map = CreatureMapCreator.CreateMap(this, 19, new Point(){X = 9, Y = 9});
            Map[8, 8] = new Wall(2);
        }

        public void CreateMapPreset(string level)
        {
            Map = CreatureMapCreator.CreateMapPreset(this, level);
            TowerPos = GetTowerPos();
            Tower = (Tower)Map[TowerPos.X, TowerPos.Y];
        }

        private Point GetTowerPos()
        {
            for (int x = 0; x < MapWidth; x++)
            for (int y = 0; y < MapHeight; y++)
            {
                if (Map[x, y] is Tower)
                    return new Point(x, y);
            }
            return new Point(-1, -1);
        }
    }
}