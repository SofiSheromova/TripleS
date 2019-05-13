using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace TowerDefense
{
    public class Monster : ICreature
    {
        public int Live { get; set; }
        protected Game Game;

        public Monster(Game game)
        {
            Game = game;
        }

        public virtual string GetImageFileName() => "Monster.png";
        public virtual int GetReward() => 10;
        public int GetDrawingPriority() => 0;

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

        protected virtual Point GetMonsterShift(Point start, Point target)
        {
            var shift = new Point
            {
                X = Math.Sign(target.X - start.X),
                Y = Math.Sign(target.Y - start.Y)
            };
            if (shift.Y != 0) shift.X = 0;
            return shift;
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            return conflictedObject is Wall || conflictedObject is Tower || conflictedObject is Monster;
        }
    }

    public class SmartMonster : Monster
    {
        public SmartMonster(Game game) : base(game)
        {
            Game = game;
        }

        public override string GetImageFileName() => "Monster2.png";
        public override int GetReward() => 20;

        protected override Point GetMonsterShift(Point start, Point target)
        {
            var path = DijkstraPathFinder.Dijkstra(start, target, Game);
            return path.Count > 1 ? new Point(path[1].X - start.X, path[1].Y - start.Y) : new Point(0, 0);
        }
    }

    public class Creeper : Monster
    {
        public Creeper(Game game) : base(game)
        {
            Game = game;
        }

        public override string GetImageFileName() => "Monster3.png";
        public override int GetReward() => 40;

        protected override Point GetMonsterShift(Point start, Point target)
        {
            var path = DijkstraPathFinder.Dijkstra(start, target, Game);
            return path.Count > 1 ? new Point(path[1].X - start.X, path[1].Y - start.Y) : new Point(0, 0);
        }
    }
}