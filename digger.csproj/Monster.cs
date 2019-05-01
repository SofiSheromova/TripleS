using System.Drawing;

namespace Digger
{
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