using System.Windows.Forms;

namespace Digger
{
    public class Player : ICreature
    {
        public string GetImageFileName()
        {
            return "Digger.png";
        }

        public int GetDrawingPriority()
        {
            return 0;
        }

        public CreatureCommand Act(int x, int y)
        {
            var player = new CreatureCommand();
            if (Game.KeyPressed == Keys.Up && y - 1 >= 0 && !(Game.Map[x, y - 1] is Sack))
                player.DeltaY = -1;
            if (Game.KeyPressed == Keys.Down && y + 1 < Game.MapHeight && !(Game.Map[x, y + 1] is Sack))
                player.DeltaY = 1;
            if (Game.KeyPressed == Keys.Left && x - 1 >= 0 && !(Game.Map[x - 1, y] is Sack))
                player.DeltaX = -1;
            if (Game.KeyPressed == Keys.Right && x + 1 < Game.MapWidth && !(Game.Map[x + 1, y] is Sack))
                player.DeltaX = 1;
            return player;
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            if (conflictedObject is Sack || conflictedObject is Monster)
                Game.IsOver = true;
            return conflictedObject is Sack || conflictedObject is Monster;
        }
    }
}