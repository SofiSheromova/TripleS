using System.Drawing;
using System.Linq;
using NUnit.Framework;

namespace TowerDefense.Tests
{
    [TestFixture]
    public class DijkstraPathFinder_Should
    {
        //названия не очень
        [TestCase(@"T  
   
   ", 0, 0, 5, TestName = "Path To Start Position")]
        [TestCase(@"   
   
  T", 0, 0, 5, TestName = "Normal Path")]
        [TestCase(@"   
  W
 WT", 0, 0, 6, TestName = "Tower is surrounded")]
        [TestCase(@" W 
WTW
 W ", 0, 0, 6, TestName = "Tower is surrounded in center")]
        [TestCase(@"  W 
 WTW
    ", 0, 0, 5, TestName = "Tower is not surrounded")]
        [TestCase(@" W 
 TW
   ", 2, 2, 5, TestName = "Other start position")]
        [TestCase(@"
         W       
         W       
        WWW      
       WWTWW     
        WWW      
                 ", 7, 1, 6, TestName = "Need to go around")]

        [TestCase(@"
       WW        
       WW        
       WWW       
       WWT       
       WWW       
        W        ", 0, 4, 6, TestName = "just map")]

        [TestCase(@"
    WWW          
      WW         
       WWW       
      WWWT       
      WW         
     WW          ", 0, 4, 7, TestName = "minus dijkstra")]
        [TestCase(@"
    WWW          
      WW         
        33       
        2T       
      WW         
     W           ", 0, 4, 6, TestName = "different walls")]
        [TestCase(@"
    32           
      2W         
        33       
       22T2      
      33 2       
     3           ", 0, 4, 8, TestName = "different walls 2")]

        public void Find_Path_When_Paths_Exists(string map, int x, int y, int expectedCosts)
        {
            PerformTest(map, new Point(x, y), expectedCosts);
        }

        public void PerformTest(string map, Point start, int expectedCosts)
        {
            Level level = new Level(100, map, 'e');
            var game = new Game(level);
            var path = DijkstraPathFinder.Dijkstra(start, game.TowerPos, game);
            var cost = 0;
            foreach (var step in path)
            {
                cost += game.Map[step.X, step.Y]?.Live ?? 0;
            }
            Assert.AreEqual(expectedCosts, cost);
            Assert.AreEqual(path.Last(), game.TowerPos);
        }
    }
}
