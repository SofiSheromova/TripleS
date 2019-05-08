using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using TowerDefense.Architecture;
using TowerDefense.Properties;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace TowerDefense.Tests
{
    [TestFixture]
    public class DijkstraPathFinder_Should
    {        
        //хорошая новость - тест есть. плохая новость - он не запускается

        [TestCase(@"T  
   
   ", 0, 0, 0, TestName = "Path To Start Position")]
        public void Find_Path_When_Paths_Exists(string map, int x, int y, int expectedCosts)
        {
            PerformTest(map, new Point(x, y), expectedCosts);
        }

        public void PerformTest(string map, Point start, int expectedCosts)
        {
            Game.CreateMapPreset(map);
            var path = Monster.Dijkstra(start, Game.TowerPos);
            var cost = 0;
            foreach (var step in path)
            {
                cost += Game.Map[step.X, step.Y]?.Live ?? 0;
            }
            Assert.AreEqual(expectedCosts, cost);
            Assert.AreEqual(path.Last(), Game.TowerPos);
        }
    }
}
