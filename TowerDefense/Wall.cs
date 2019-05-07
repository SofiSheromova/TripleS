﻿using System.Drawing;

namespace TowerDefense
{
    public class Wall : ICreature
    {
        public int Live { get; set; }
        //public Point Coordinates { get; }//не знаю зачем

        public Wall(int live = 1)//, Point coordinates)
        {
            Live = live;
            //Coordinates = coordinates;
        }

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
            if (conflictedObject is Monster)
                Live--;

            return conflictedObject is Monster && Live < 1;
        }
    }
}