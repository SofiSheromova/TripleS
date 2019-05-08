﻿using System;
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
