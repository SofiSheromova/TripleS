using System.Drawing;
using System.Windows.Forms;

namespace Digger
{
    public class Terrain : ICreature
    {
        public string GetImageFileName()
        {
            return "Terrain.png";
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
            return true;
        }
    }

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


    public class Gold : ICreature
    {
        public string GetImageFileName()
        {
            return "Gold.png";
        }

        public int GetDrawingPriority()
        {
            return 3;
        }

        public CreatureCommand Act(int x, int y)
        {
            return new CreatureCommand();
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            if (conflictedObject is Player)
            {
                Game.Scores += 10;
                return true;
            }
            return conflictedObject is Monster;
        }
    }

    public class Monster : ICreature
    {
        public string GetImageFileName()
        {
            return "Monster.png";
        }

        public int GetDrawingPriority()
        {
            return 4;
        }

        public CreatureCommand Act(int x, int y)
        {
            var monster = new CreatureCommand();
            var diggerCoordinates = FindDigger();
            if (!double.IsNaN(diggerCoordinates.X))
            {
                monster.DeltaX = GetMonsterXShift(diggerCoordinates.X, x, y);
                monster.DeltaY = GetMonsterYShift(diggerCoordinates.Y, x, y);
            }
            return monster;
        }

        private int GetMonsterXShift(float diggerCoordinate, int x, int y)
        {
            if (diggerCoordinate < x && x > 0 && CanGoTo(x - 1, y))
                return -1;
            if (diggerCoordinate > x && x < Game.MapWidth - 1 && CanGoTo(x + 1, y))
                return 1;
            return 0;
        }

        private int GetMonsterYShift(float diggerCoordinate, int x, int y)
        {
            if (diggerCoordinate < y && y > 0 && CanGoTo(x, y - 1))
                return -1;
            if (diggerCoordinate > y && y < Game.MapHeight - 1 && CanGoTo(x, y + 1))
                return 1;
            return 0;
        }

        private static bool CanGoTo(int x, int y)
        {
            return !(Game.Map[x, y] is Terrain || Game.Map[x, y] is Sack || Game.Map[x, y] is Monster);
        }

        private PointF FindDigger()
        {
            for (var i = 0; i < Game.MapWidth; i++)
            {
                for (var j = 0; j < Game.MapHeight; j++)
                {
                    if (Game.Map[i, j] is Player)
                    {
                        return new PointF(i, j);
                    }
                }
            }
            return new PointF(float.NaN, float.NaN);
        }

        public bool DeadInConflict(ICreature conflictedObject)
        {
            return conflictedObject is Sack || conflictedObject is Monster;
        }
    }
}