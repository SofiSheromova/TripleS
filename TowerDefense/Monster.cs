using System.Drawing;
using System.Runtime.CompilerServices;

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
            if (!double.IsNaN(Game.TowerPos.X))
            {
                var shift = GetMonsterShift(new Point(x, y), Game.TowerPos);
                monster.DeltaX = shift.X;
                monster.DeltaY = shift.Y;
            }
            return monster;
        }

        private static Point GetMonsterShift(Point start, Point target) //тут конечно же алгоритм Дейкстры
        {
            var shift = new Point {X = start.X < target.X ? 1 : 0, Y = start.Y < target.Y ? 1 : 0};
            shift = new Point{X = start.X > target.X ? -1 : shift.X, Y = start.Y > target.Y ? -1 : shift.Y};
            return shift;
        }
        

        public bool DeadInConflict(ICreature conflictedObject)
        {
            return conflictedObject is Wall || conflictedObject is Tower || conflictedObject is Monster;
        }
    }
}