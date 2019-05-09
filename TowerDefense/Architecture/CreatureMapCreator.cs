using System;
using System.Drawing;
using System.Linq;

namespace TowerDefense
{
    public static class CreatureMapCreator
    {
        public static ICreature[,] CreateMap(Game game, int size, Point towerCoordinates, string separator = "\r\n")
        {
            game.Tower = new Tower(3);
            var result = new ICreature[size, size];
            result[towerCoordinates.X, towerCoordinates.Y] = game.Tower;
            return result;
        }

        public static ICreature[,] CreateMap(Game game, string map, string separator = "\r\n")
        {
            var rows = map.Split(new[] { separator }, StringSplitOptions.RemoveEmptyEntries);
            if (rows.Select(z => z.Length).Distinct().Count() != 1)
                throw new Exception($"Wrong test map '{map}'");
            var result = new ICreature[rows[0].Length, rows.Length];
            for (var x = 0; x < rows[0].Length; x++)
            for (var y = 0; y < rows.Length; y++)
                result[x, y] = CreateCreatureBySymbol(game, rows[y][x]);
            return result;
        }

        private static ICreature CreateCreatureBySymbol(Game game, char c)
        {
            switch (c)
            {
                case 'W':
                    return new Wall();
                case 'T':
                    return new Tower();
                case 'M':
                    return new Monster(game);
                case 'S':
                    return new SmartMonster(game);
                case ' ':
                    return null;
                default:
                    throw new Exception($"wrong character for ICreature {c}");
            }
        }
    }
}