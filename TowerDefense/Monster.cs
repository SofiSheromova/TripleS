using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;

namespace TowerDefense
{
    class DijkstraData
    {
        public Point Previous { get; set; }
        public double Price { get; set; }
    }

    public class Monster : ICreature
    {
        public string GetImageFileName()
        {
            return "Monster.png";
        }

        public int GetDrawingPriority()
        {
            return 0;
        }

        private static readonly Point[] directions = new Point[]{
                new Point(0, -1),
                new Point(0, 1),
                new Point(-1, 0),
                new Point(1, 0)
        };

        public int Live { get; set; }

        public CreatureCommand Act(int x, int y)
        {
            var monster = new CreatureCommand();
            if (!double.IsNaN(Game.TowerPos.X))
            {
                var shift = GetMonsterShift(new Point(x, y), Game.TowerPos);
                monster.DeltaX = shift.X;
                monster.DeltaY = shift.Y;
            }
            return monster;
        }

        private static Point GetMonsterShift(Point start, Point target)
        {
            return new Point(Dijkstra(start, target)[1].X - start.X, Dijkstra(start, target)[1].Y - start.Y);
        }

        public static List<Point> Dijkstra(Point start, Point end)
        {
            var notVisited = new List<Point>();
            notVisited.Add(start);
            var track = new Dictionary<Point, DijkstraData>();
            track[start] = new DijkstraData { Previous = new Point(-1, -1), Price = 0 };
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

                if (toOpen == null) return null;
                if (toOpen == end) break;

                foreach (var e in directions.Select(x => new Point(x.X + toOpen.X, x.Y + toOpen.Y)))
                {
                    if ((e.X < 0 || e.X >= Game.MapWidth || e.Y < 0 || e.Y >= Game.MapHeight))
                        continue;
                    var currentPrice = track[toOpen].Price + Game.Map[e.X, e.Y]?.Live ?? 0;
                    if (!track.ContainsKey(e) || track[e].Price > currentPrice)
                    {
                        track[e] = new DijkstraData { Previous = toOpen, Price = currentPrice };
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
        
        public bool DeadInConflict(ICreature conflictedObject)
        {
            return conflictedObject is Wall || conflictedObject is Tower || conflictedObject is Monster;
        }
    }
}