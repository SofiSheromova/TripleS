using System.Drawing;

namespace TowerDefense
{
    public interface ICreature
    {
        int Live { get; set; }

        string GetImageFileName();
        int GetDrawingPriority();
        CreatureCommand Act(int x, int y);
        bool DeadInConflict(ICreature conflictedObject);
    }
}