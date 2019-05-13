using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace TowerDefense
{
    public class Slime : ICreature
    {
        public int Live { get; set; }
        protected Game Game;

        public Slime(Game game)
        {
            Game = game;
        }

        public virtual string GetImageFileName() => "Slime.png";
        public virtual int GetReward() => 0;
        public int GetDrawingPriority() => 0;
        public CreatureCommand Act(int x, int y) => new CreatureCommand();

        public bool DeadInConflict(ICreature conflictedObject)
        {
            return true;
        }
    }
}