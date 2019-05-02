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
            var monster = new CreatureCommand();
            if (!double.IsNaN(Game.Tower.Coordinates.X))
            {
                var shift = GetMonsterShift(new Point(x, y), Game.Tower.Coordinates);
                monster.DeltaX = shift.X;
                monster.DeltaY = shift.Y;
            }
            return monster;
        }

        private static Point GetMonsterShift(Point start, Point target) //тут конечно же алгоритм Дейкстры
        {
            var shift = new Point();
            shift.X = start.X < target.X ? 1 : 0;
            shift.Y = start.Y < target.Y ? 1 : 0;
            return shift;
        }
        

        public bool DeadInConflict(ICreature conflictedObject)
        {
            return conflictedObject is Fortress || conflictedObject is Tower || conflictedObject is Monster;
        }
    }
}