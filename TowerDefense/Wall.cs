using System;
using System.Drawing;

namespace TowerDefense
{
    public class Wall : ICreature
    {
        private int _live;
        public int Live
        {
            get => _live;
            set
            {
                if (value <= 3)
                    _live = value;
            }
        }

        public Wall(int live = 1)
        {
            Live = live;
            _live = live;
        }

        public string GetImageFileName()
        {
            if (_live == 2)
                return "Wall2.png";
            if (_live == 3)
                return "Wall3.png";
            return "Wall.png";
        }

        public int GetDrawingPriority() => 2;

        public CreatureCommand Act(int x, int y) => new CreatureCommand();

        public bool DeadInConflict(ICreature conflictedObject)
        {
            if (conflictedObject is Monster)
                _live--;

            return _live == 0;
        }
    }
}