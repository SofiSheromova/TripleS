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
        public MonsterGenerator Generator;
        public Point TowerPos;
        public int Cash;

        public bool IsOver;

        public Keys KeyPressed;
        public int MapWidth => Map.GetLength(0);
        public int MapHeight => Map.GetLength(1);
        public static int RemainingMonsters; 

        public Game(Level level)
        {
            Map = CreatureMapCreator.CreateMap(this, level.Map);
            TowerPos = GetTowerPos();
            Tower = (Tower)Map[TowerPos.X, TowerPos.Y];
            Generator = CreatureMapCreator.ChooseGenerator(this, level.Generator);
            RemainingMonsters = level.CountMonsters;

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