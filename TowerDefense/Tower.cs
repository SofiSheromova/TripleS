namespace TowerDefense
{
    public class Tower : ICreature
    {
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
            return conflictedObject is Monster;
        }
    }
}