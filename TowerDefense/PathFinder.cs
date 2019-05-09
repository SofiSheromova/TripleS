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
        private static readonly Point[] Directions =
        {
            new Point(0, -1),
            new Point(0, 1),
            new Point(-1, 0),
            new Point(1, 0)
        };

        public static List<Point> Dijkstra(Point start, Point end, Game game)
        {
            var notVisited = new List<Point> {start};
            var track = new Dictionary<Point, DijkstraData>
                {[start] = new DijkstraData {Previous = new Point(-1, -1), Price = 0}};
            while (true)
            {
                var toOpen = default(Point);
                var bestPrice = double.PositiveInfinity;
                foreach (var e in notVisited)
                {
                    if (track.ContainsKey(e) && track[e].Price < bestPrice)
                    {
                        bestPrice = track[e].Price;
                        toOpen = e;
                    }
                }

                if (toOpen == end) break;

                foreach (var e in Directions.Select(x => new Point(x.X + toOpen.X, x.Y + toOpen.Y)))
                {
                    if (e.X < 0 || e.X >= game.MapWidth || e.Y < 0 || e.Y >= game.MapHeight)
                        continue;
                    var currentPrice = track[toOpen].Price + game.Map[e.X, e.Y]?.Live ?? 0;
                    if (!track.ContainsKey(e) || track[e].Price > currentPrice)
                    {
                        track[e] = new DijkstraData {Previous = toOpen, Price = currentPrice};
                        notVisited.Add(e);
                    }
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
    }
}
