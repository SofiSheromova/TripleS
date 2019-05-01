namespace Digger
{
    public class Sack : ICreature
    {
        int passedCells;

        public string GetImageFileName()
        {
            return "Sack.png";
        }

        public int GetDrawingPriority()
        {
            return 2;
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            return false;
        }

        public CreatureCommand Act(int x, int y)
        {
            var bottom = y + 1 < Game.MapHeight ? Game.Map[x, y + 1] : null;
            if (CanFall(x, y))
                return Fall();
            return passedCells > 1 && (bottom is Terrain || bottom is Sack || bottom == null || bottom is Gold)
                ? TurnToGold()
                : Stay();
        }

        private bool CanFall(int x, int y)
        {
            if (y + 1 >= Game.MapHeight)
                return false;
            var bottom = Game.Map[x, y + 1];
            return (bottom is Player && passedCells >= 1) || (bottom == null) ||
                   (bottom is Monster && passedCells >= 1);
        }

        private CreatureCommand Fall()
        {
            passedCells++;
            return new CreatureCommand() { DeltaY = 1 };
        }

        private CreatureCommand Stay()
        {
            passedCells = 0;
            return new CreatureCommand();
        }

        private CreatureCommand TurnToGold()
        {
            return new CreatureCommand() { TransformTo = new Gold() };
        }
    }
}