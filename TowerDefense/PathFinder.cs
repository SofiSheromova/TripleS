using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace TowerDefense
{
    class DijkstraData
    {
        public Point Previous { get; set; }
        public double Price { get; set; }
    }

    public static class DijkstraPathFinder
    {
        public static List<Point> Dijkstra(Point start, Point end, Game game)
        {
            var notVisited = GetPointMap(game.MapWidth, game.MapHeight);
            var track = new Dictionary<Point, DijkstraData>
                {[start] = new DijkstraData {Previous = new Point(-1, -1), Price = 0}};

            while (true)
            {
                var toOpen = new Point(-1, -1);
                var bestPrice = double.PositiveInfinity;
                foreach (var point in notVisited)
                {
                    if (track.ContainsKey(point) && track[point].Price < bestPrice)
                    {
                        bestPrice = track[point].Price;
                        toOpen = point;
                    }
                }

                if (toOpen == end) break;
                //if (toOpen.X == -1) break;

                foreach (var point in GetIncidentPoint(toOpen, game.MapWidth, game.MapHeight))
                {
                    var currentPrice = track[toOpen].Price + game.Map[point.X, point.Y]?.Live ?? 0;
                    if (!track.ContainsKey(point) || track[point].Price > currentPrice)
                        track[point] = new DijkstraData {Previous = toOpen, Price = currentPrice};
                }

                notVisited.Remove(toOpen);
            }

            var result = new List<Point>();

            while (end.X != -1)
            {
                result.Add(end);
                end = track[end].Previous;
            }

            result.Reverse();
            return result;
        }

        private static IEnumerable<Point> GetIncidentPoint(Point point, int mapWidth, int mapHeight)
        {
            Tuple<int, int>[] delta =
                {Tuple.Create(0, 1), Tuple.Create(1, 0), Tuple.Create(-1, 0), Tuple.Create(0, -1)};
            foreach (var d in delta)
                if (point.X + d.Item1 < mapWidth && point.X + d.Item1 >= 0 && point.Y + d.Item2 < mapHeight
                    && point.Y + d.Item2 >= 0)
                    yield return new Point(point.X + d.Item1, point.Y + d.Item2);
        }

        private static List<Point> GetPointMap(int width, int height)
        {
            var result = new List<Point>();
            for (var x = 0; x < width; x++)
            for (var y = 0; y < height; y++)
                result.Add(new Point(x, y));
            return result;
        }
    }
}
