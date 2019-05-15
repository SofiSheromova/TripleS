using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;

namespace TowerDefense
{
    public class MonsterGenerator
    {
        protected Game Game;

        protected static void playSimpleSound(string sound)
        {
            SoundPlayer simpleSound = new SoundPlayer(sound);
            simpleSound.Play();
        }

        public MonsterGenerator(Game game)
        {
            Game = game;
        }

        public virtual void Act()
        {
            if (Game.IsOver) return;
            Console.WriteLine("OUCH" + Game.TowerPos);
            Random rand = new Random();
            var chance = rand.NextDouble();
            var creature = chance < 0.2 ? new SmartMonster(Game) : chance < 0.4 ? new Creeper(Game) : new Monster(Game);
            Game.Map[0, 0] = creature;
            playSimpleSound(@"Sounds/ouch.wav");
        }
    }

    public class TwoSideMonsterGenerator : MonsterGenerator
    {
        public TwoSideMonsterGenerator(Game game) : base(game)
        {
            Game = game;
        }

        public override void Act()
        {
            if (Game.IsOver) return;
            Random rand = new Random();
            var monsterChance = rand.NextDouble();
            var creature = monsterChance < 0.2 ? new SmartMonster(Game) : monsterChance < 0.4 ? new Creeper(Game) : new Monster(Game);
            var locationChance = rand.NextDouble();
            var x = locationChance < 0.5 ? 0 : Game.MapWidth - 1;
            var y = locationChance < 0.5 ? 0 : Game.MapHeight - 1;
            Game.Map[x, y] = creature;
            playSimpleSound(@"Sounds/ouch.wav");
        }
    }

    public class ComplexMonsterGenerator : MonsterGenerator
    {
        public ComplexMonsterGenerator(Game game) : base(game)
        {
            Game = game;
        }

        public override void Act()
        {
            if (Game.IsOver) return;
            Random rand = new Random();
            var monsterChance = rand.NextDouble();
            var creature = monsterChance < 0.2 ? new SmartMonster(Game) : monsterChance < 0.4 ? new Creeper(Game) : new Monster(Game);
            var locationChance = rand.NextDouble();
            var x = locationChance < 0.5 ? 0 : Game.MapWidth - 1;
            var y = locationChance < 0.25 || locationChance > 0.75 ? 0 : Game.MapHeight - 1;
            Game.Map[x, y] = creature;
            playSimpleSound(@"Sounds/ouch.wav");
        }
    }
}