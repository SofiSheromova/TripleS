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

        public const string Level2 = @"
                          
   WWWWW       WWWWW      
                          
                          
          W               
                   W W    
               W     W    
               W  T   W   
               W          
               W          
               W          ";

        public const string Level3 = @"
  WW   WW  
 W  W W  W 
W    W    W
W         W
 W   T   W 
  W     W  
   W   W   
    W W    
     W     ";

    }

    class Levels
    {
        public static readonly Level TestLevel = new Level(5, Maps.TestLevel, 'e');
        public static readonly Level Level2 = new Level(10, Maps.Level2, '2');
        public static readonly Level Level3 = new Level(10, Maps.Level3, '4');
    }
}
