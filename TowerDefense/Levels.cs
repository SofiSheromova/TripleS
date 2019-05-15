namespace TowerDefense
{
    public class Level
    {
        public int CountMonsters;
        public string Map;
        public char Generator;

        public Level(int count, string map, char generator = 'e')
        {
            CountMonsters = count;
            Map = map;
            Generator = generator;
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
        public static readonly Level TestLevel = new Level(30, Maps.TestLevel, '4');
    }
}
