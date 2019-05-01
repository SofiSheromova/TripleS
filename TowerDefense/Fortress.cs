namespace TowerDefense
{
    public class Fortress : ICreature
    {
        public string GetImageFileName()
        {
            return "Terrain.png";
        }

        public int GetDrawingPriority()
        {
            return 2;
        }

        public CreatureCommand Act(int x, int y)
        {
            return new CreatureCommand();
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            return true;
        }
    }
}