using System.Drawing;

namespace TowerDefense
{
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

        public CreatureCommand Act(int x, int y)
        {
            return new CreatureCommand();
        }

        
        public bool DeadInConflict(ICreature conflictedObject)
        {
            return conflictedObject is Fortress || conflictedObject is Monster;
        }
    }
}