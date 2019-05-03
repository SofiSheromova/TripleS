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

        public string GetImageFileName()
        {
            return "Gold.png";
        }

        public int GetDrawingPriority()
        {
            return 1;
        }

        public CreatureCommand Act(int x, int y)
        {
            return new CreatureCommand();
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            if (conflictedObject is Monster)
                Live--;

            if (Live < 1)
                Game.IsOver = true; //это пока не влияет вроде не на что...

            return conflictedObject is Monster && Live < 1;
        }
    }
}