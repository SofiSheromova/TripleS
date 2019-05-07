using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Forms;

namespace TowerDefense
{
    public class GameState
    {
        public const int ElementSize = 32;
        public List<CreatureAnimation> Animations = new List<CreatureAnimation>();
        public static double timeInSecond;
        private const int monsterFrequency = 3;
        private double lastMonsterTime = - monsterFrequency;

        public void BeginAct()
        {
            Animations.Clear();

            //Порчу 
            if (lastMonsterTime + monsterFrequency <= timeInSecond)
            {
                lastMonsterTime += monsterFrequency;
                Game.Map[0, 0] = new Monster();
            }
            //Испортила

            for (var x = 0; x < Game.MapWidth; x++)
            for (var y = 0; y < Game.MapHeight; y++)
            {
                var creature = Game.Map[x, y];
                if (creature == null) continue;
                var command = creature.Act(x, y);

                if (x + command.DeltaX < 0 || x + command.DeltaX >= Game.MapWidth || y + command.DeltaY < 0 ||
                    y + command.DeltaY >= Game.MapHeight)
                    continue; //вероятно это нужно будет обрабатывать, но пока обойдёмся

                if (creature is Monster && ClickOnMonster(Tuple.Create(x, y), GameWindow.ClickPosition))
                    {
                        GameWindow.ClickPosition = new Point(-32, -32);
                        Game.Cash += 10;
                    }
                else
                    Animations.Add(
                    new CreatureAnimation
                    {
                        Command = command,
                        Creature = creature,
                        Location = new Point(x * ElementSize, y * ElementSize),
                        TargetLogicalLocation = new Point(x + command.DeltaX, y + command.DeltaY)
                    });
                }

            Animations = Animations.OrderByDescending(z => z.Creature.GetDrawingPriority()).ToList();
        }
        
        private static bool ClickOnMonster(Tuple<int, int> indexes, Point click)
        {
            return indexes.Item1 * ElementSize - ElementSize / 2 < click.X
                   && click.X < (indexes.Item1 + 1) * ElementSize - ElementSize / 2
                   && (indexes.Item2 + 1) * ElementSize < click.Y
                   && click.Y < (indexes.Item2 + 2) * ElementSize;
        }

    public void EndAct()
        {
            var creaturesPerLocation = GetCandidatesPerLocation();
            for (var x = 0; x < Game.MapWidth; x++)
            for (var y = 0; y < Game.MapHeight; y++)
                Game.Map[x, y] = SelectWinnerCandidatePerLocation(creaturesPerLocation, x, y);
        }

        private static ICreature SelectWinnerCandidatePerLocation(List<ICreature>[,] creatures, int x, int y)
        {
            var candidates = creatures[x, y];
            var aliveCandidates = candidates.ToList();
            foreach (var candidate in candidates)
            foreach (var rival in candidates)
                if (rival != candidate && candidate.DeadInConflict(rival))
                    aliveCandidates.Remove(candidate);
            //if (aliveCandidates.Count > 1)
            //    throw new Exception(
            //        $"Creatures {aliveCandidates[0].GetType().Name} and {aliveCandidates[1].GetType().Name} claimed the same map cell");

            return aliveCandidates.FirstOrDefault();
        }

        private List<ICreature>[,] GetCandidatesPerLocation()
        {
            var creatures = new List<ICreature>[Game.MapWidth, Game.MapHeight];
            for (var x = 0; x < Game.MapWidth; x++)
            for (var y = 0; y < Game.MapHeight; y++)
                creatures[x, y] = new List<ICreature>();
            foreach (var e in Animations)
            {
                var x = e.TargetLogicalLocation.X;
                var y = e.TargetLogicalLocation.Y;
                var nextCreature = e.Command.TransformTo ?? e.Creature;
                creatures[x, y].Add(nextCreature);
            }

            return creatures;
        }

        public static void TryKillMonster(Tuple<int, int> indexes)
        {
            if (Game.Map[indexes.Item1, indexes.Item2] is Monster)
            {
                Game.Map[indexes.Item1, indexes.Item2] = null;
                Game.Cash += 10;
            }
        }
    }
}