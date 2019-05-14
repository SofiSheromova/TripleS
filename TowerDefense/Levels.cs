namespace TowerDefense
{
    public class Level
    {
        public int CountMonsters;
        public string Map;
        // TODO generator

        public Level(int count, string map)
        {
            CountMonsters = count;
            Map = map;
            // generator
        }
    }

    class Maps
    {
        public const string TestLevel = @"
          
          
          
          
     T    
          
          
          
          
          ";

    }

    class Levels
    {
        public static readonly Level TestLevel = new Level(30, Maps.TestLevel);
    }
}
