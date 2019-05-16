using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Forms;

namespace TowerDefense
{
    public class GameState
    {
        public const int ElementSize = 32;
        public List<CreatureAnimation> Animations = new List<CreatureAnimation>();
        public double TimeInSecond;
        private const int MonsterFrequency = 1;
        private double _lastMonsterTime = -MonsterFrequency;
        public Game game;

        public GameState(Level level)
        {
            game = new Game(level);
        }

        public void BeginAct()
        {
            Animations.Clear();
            
            if (game.IsOver || game.Tower.Live < 1) return;

            if (_lastMonsterTime + MonsterFrequency <= TimeInSecond)
            {
                _lastMonsterTime += MonsterFrequency;
                game.Generator.Act();
            }

            if (GameWindow.RightClickIndexes != null && game.Map[GameWindow.RightClickIndexes.Item1, GameWindow.RightClickIndexes.Item2] == null)
            {
                game.Map[GameWindow.RightClickIndexes.Item1, GameWindow.RightClickIndexes.Item2] = new Wall();
                GameWindow.RightClickIndexes = null;
            }
            
            for (var x = 0; x < game.MapWidth; x++)
            for (var y = 0; y < game.MapHeight; y++)
            {
                var creature = game.Map[x, y];
                if (creature == null) continue;
                var command = creature.Act(x, y);

                if (x + command.DeltaX < 0 || x + command.DeltaX >= game.MapWidth || y + command.DeltaY < 0 ||
                    y + command.DeltaY >= game.MapHeight)
                    continue;

                if (creature is Monster monster && ClickOnMonster(Tuple.Create(x, y), GameWindow.ClickPosition))
                {
                    if (game.RemainingMonsters > 1)
                        game.RemainingMonsters--;
                    else
                        game.IsOver = true; // TODO это победа на самом деле
                    game.Cash += monster.GetReward();
                    game.Map[x, y] = null;
                    if (creature is Creeper)
                    {
                        Tuple<int, int>[] delta =
                                {Tuple.Create(0, 1), Tuple.Create(1, 0), Tuple.Create(-1, 0), Tuple.Create(0, -1)};
                        foreach (var d in delta)
                            if (x + d.Item1 < game.MapWidth && x + d.Item1 >= 0 && y + d.Item2 < game.MapHeight && y + d.Item2 >= 0
                                && game.Map[x + d.Item1, y + d.Item2] != null)
                                Animations.Add(
                                    new CreatureAnimation
                                    {
                                        Command = new CreatureCommand(),
                                        Creature = new Slime(game),
                                        Location = new Point((x + d.Item1) * ElementSize, (y + d.Item2) * ElementSize),
                                        TargetLogicalLocation = new Point(x + d.Item1, y + d.Item2)
                                    });
                    }
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

            GameWindow.ClickPosition = new Point(-32, -32);

            Animations = Animations.OrderByDescending(z => z.Creature.GetDrawingPriority()).ToList();
        }

        private static bool ClickOnMonster(Tuple<int, int> indexes, Point click)
        {
            return (indexes.Item1 - 1) * ElementSize < click.X
                   && click.X < (indexes.Item1 + 1) * ElementSize
                   && indexes.Item2 * ElementSize  < click.Y
                   && click.Y < (indexes.Item2 + 2) * ElementSize;
        }

        public void EndAct()
        {
            var creaturesPerLocation = GetCandidatesPerLocation();
            for (var x = 0; x < game.MapWidth; x++)
            for (var y = 0; y < game.MapHeight; y++)
                game.Map[x, y] = SelectWinnerCandidatePerLocation(creaturesPerLocation, x, y);
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
            var creatures = new List<ICreature>[game.MapWidth, game.MapHeight];
            for (var x = 0; x < game.MapWidth; x++)
            for (var y = 0; y < game.MapHeight; y++)
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
    }
}