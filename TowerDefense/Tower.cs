using System.Drawing;

namespace TowerDefense
{
    public class Tower : ICreature
    {
        public int Live { get; set; }

        public Tower(int live = 5)
        {
            Live = live;
        }

        public string GetImageFileName() => "Tower.png";
        public int GetDrawingPriority() => 1;

        public CreatureCommand Act(int x, int y) => new CreatureCommand();

        public bool DeadInConflict(ICreature conflictedObject)
        {
            if (conflictedObject is Monster || conflictedObject is Slime)
                Live--;

            if (Live < 1)
                Game.IsOver = true;

            return conflictedObject is Monster && Live < 1;
        }
    }
}