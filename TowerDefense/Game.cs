using System;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace TowerDefense
{
    public class Game
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
            Map = CreatureMapCreator.CreateMap(this, level);
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