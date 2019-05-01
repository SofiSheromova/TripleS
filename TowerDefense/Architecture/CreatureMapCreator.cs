using System;
using System.Linq;

namespace TowerDefense
{
    public static class CreatureMapCreator
    {
        public static ICreature[,] CreateMap(int size, Tuple<int, int> towerCoord, string separator = "\r\n")
        {
            var result = new ICreature[size, size];
            result[towerCoord.Item1, towerCoord.Item2] = new Tower();
            return result;
        }
    }
}