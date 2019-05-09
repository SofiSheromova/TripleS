using System.Drawing;

namespace TowerDefense
{
    public class Wall : ICreature
    {
        public int Live { get; set; }

        public Wall(int live = 1)
        {
            Live = live;
        }

        public string GetImageFileName() => "Terrain.png";
        public int GetDrawingPriority() => 2;

        public CreatureCommand Act(int x, int y) => new CreatureCommand();

        public bool DeadInConflict(ICreature conflictedObject)
        {
            if (conflictedObject is Monster)
                Live--;

            return conflictedObject is Monster && Live < 1;
        }
    }
}