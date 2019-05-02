using System;
using System.Drawing;
using System.Linq;

namespace TowerDefense
{
    public static class CreatureMapCreator
    {
        public static ICreature[,] CreateMap(int size, Point towerCoordinates, string separator = "\r\n")
        {
            Game.Tower = new Tower(3, towerCoordinates);
            var result = new ICreature[size, size];
            result[towerCoordinates.X, towerCoordinates.Y] = Game.Tower;
            return result;
        }
    }
}