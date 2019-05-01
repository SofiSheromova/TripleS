using System;
using System.Linq;

namespace Digger
{
    public static class CreatureMapCreator
    {
        public static ICreature[,] CreateMap(string map, string separator = "\r\n")
        {
            var rows = map.Split(new[] {separator}, StringSplitOptions.RemoveEmptyEntries);
            if (rows.Select(z => z.Length).Distinct().Count() != 1)
                throw new Exception($"Wrong test map '{map}'");
            var result = new ICreature[rows[0].Length, rows.Length];
            for (var x = 0; x < rows[0].Length; x++)
            for (var y = 0; y < rows.Length; y++)
                result[x, y] = CreateCreatureBySymbol(rows[y][x]);
            return result;
        }
        
        private static ICreature CreateCreatureBySymbol(char c)
        {
            switch (c)
            {
                case 'P':
                    return new Player();
                case 'T':
                    return new Terrain();
                case 'G':
                    return new Gold();
                case 'S':
                    return new Sack();
                case 'M':
                    return new Monster();
                case ' ':
                    return null;
                default:
                    throw new Exception($"wrong character for ICreature {c}");
            }
        }
    }
}